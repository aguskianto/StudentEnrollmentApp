using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollmentData;
using AutoMapper;
using StudentEnrollmentApi.DTOs.Student;
using StudentEnrollmentData.Contracts;
using StudentEnrollmentApi.DTOs.Course;
using Microsoft.AspNetCore.Authorization;
namespace StudentEnrollmentApi.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        // StudentEnrollmentDbContext db

        group.MapGet("/", [AllowAnonymous] async (IStudentRepository repo, IMapper mapper) =>
        {
            //var students = await db.Students.ToListAsync();
            var students = await repo.GetAllAsync();
            var data = mapper.Map<List<StudentDto>>(students);

            return TypedResults.Ok(data);
        })
        .WithName("GetAllStudents")
        .Produces<List<StudentDto>>(StatusCodes.Status200OK)
        .WithOpenApi();

        group.MapGet("/{id}", [AllowAnonymous] async Task<Results<Ok<StudentDto>, NotFound>> (int id, IStudentRepository repo, IMapper mapper) =>
        {
            //var foundModel = await db.Students.FindAsync(id);
            //var data = mapper.Map<StudentDto>(foundModel);

            //if (foundModel is null)
            //{
            //    return TypedResults.NotFound();
            //}

            //return TypedResults.Ok(data);

            return await repo.GetAsync(id)
                is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        group.MapGet("/GetDetails/{id}", async Task<Results<Ok<StudentDetailsDto>, NotFound>> (int id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentDetails(id) is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDetailsDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentDetailsById")
        .WithOpenApi();

        group.MapPut("/{id}", [Authorize(Roles = "Administrator")] async Task<Results<NoContent, NotFound>> (int id, StudentDto studentDto, IStudentRepository repo, IMapper mapper) =>
        {
            //var foundModel = await db.Students.FindAsync(id);
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            //update model properties here
            mapper.Map(studentDto, foundModel);
            //await db.SaveChangesAsync();

            await repo.UpdateAsync(foundModel);

            //await db.Students
            //    .Where(model => model.Id == id)
            //    .ExecuteUpdateAsync(setters => setters
            //        .SetProperty(m => m.FirstName, data.FirstName)
            //        .SetProperty(m => m.LastName, data.LastName)
            //        .SetProperty(m => m.DateofBirth, data.DateofBirth)
            //        .SetProperty(m => m.IdNumber, data.IdNumber)
            //        .SetProperty(m => m.Picture, data.Picture)
            //    );

            return TypedResults.NoContent();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", [Authorize(Roles = "Administrator")] async (CreateStudentDto createStudentDto, IStudentRepository repo, IMapper mapper) =>
        {
            var data = mapper.Map<Student>(createStudentDto);

            //db.Students.Add(data);
            //await db.SaveChangesAsync();

            await repo.AddAsync(data);

            return TypedResults.Created($"/api/Student/{data.Id}", data);
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", [Authorize(Roles = "Administrator")] async Task<Results<NoContent, NotFound>> (int id, IStudentRepository repo) =>
        {
            //var foundModel = await db.Students.FindAsync(id);

            //if (foundModel is null)
            //{
            //    return TypedResults.NotFound();
            //}

            //await db.Courses
            //    .Where(model => model.Id == id)
            //    .ExecuteDeleteAsync();

            //return TypedResults.NoContent();

            //var affected = await db.Students
            //    .Where(model => model.Id == id)
            //    .ExecuteDeleteAsync();

            //return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();

            return await repo.DeleteAsync(id) ? TypedResults.NoContent() : TypedResults.NotFound();
        })
        .WithTags(nameof(Student))
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
