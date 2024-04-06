using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollmentData;
using StudentEnrollmentApi.Endpoints;
using StudentEnrollmentApi.Configurations;
using StudentEnrollmentData.Contracts;
using StudentEnrollmentData.Repositories;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("StudentEnrollmentDbConnection");

builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
{
    options.UseSqlServer(conn);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

//builder.Services.AddAutoMapper(typeof(MapperConfig));

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

app.Run();