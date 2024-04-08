using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollmentData;
using StudentEnrollmentApi.Endpoints;
using StudentEnrollmentApi.Configurations;
using StudentEnrollmentData.Contracts;
using StudentEnrollmentData.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StudentEnrollmentApi.Services;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("StudentEnrollmentDbConnection");

builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
{
    options.UseSqlServer(conn);
});

builder.Services.AddIdentityCore<SchoolUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StudentEnrollmentDbContext>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddAuthorization(options => {
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });

builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddCors(options => {
    options.AddPolicy("Allow All", policy => policy.AllowAnyHeader().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

//app.MapGet("/courses", async ([FromServices] StudentEnrollmentDbContext context) =>
//{
//    return await context.Courses.ToListAsync();
//});

//app.MapGet("/courses/{id}", async ([FromServices] StudentEnrollmentDbContext context, int id) =>
//{
//    return await context.Courses.FindAsync(id) is Course course ? Results.Ok(course) : Results.NotFound();
//});

//app.MapPost("/courses", async ([FromServices] StudentEnrollmentDbContext context, Course course) =>
//{
//    await context.AddAsync(course);
//    await context.SaveChangesAsync();

//    return Results.Created($"courses/{course.Id}", course);
//});

//app.MapPut("/courses/{id}", async ([FromServices] StudentEnrollmentDbContext context, Course course, int id) =>
//{
//    var recordExists = await context.Courses.AnyAsync(q => q.Id == id);

//    if (!recordExists) return Results.NotFound();

    //record.Title = course.Title; 
    //record.Credits = course.Credits;

//    context.Update(course);
//    await context.SaveChangesAsync();

//    return Results.NoContent();
//});

//app.MapDelete("/courses/{id}", async ([FromServices] StudentEnrollmentDbContext context, int id) => {
//    var record = await context.Courses.FindAsync(id);

//    if (record == null) return Results.NotFound();

//    context.Remove(record);
//    await context.SaveChangesAsync();

//    return Results.NoContent();
//});

app.MapStudentEndpoints();
app.MapEnrollmentEndpoints();
app.MapCourseEndpoints();
app.MapAuthenticationEndpoints();

app.Run();