//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.OpenApi;
using StudentEnrollmentData;
using AutoMapper;
//using StudentEnrollmentApi.DTOs.Student;
using StudentEnrollmentApi.DTOs.Enrollment;
//using StudentEnrollmentApi.DTOs.Course;
using StudentEnrollmentData.Contracts;
using Microsoft.AspNetCore.Authorization;
namespace StudentEnrollmentApi.Endpoints;

public static class EnrollmentEndpoints
{
    public static void MapEnrollmentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Enrollment").WithTags(nameof(Enrollment));

        // StudentEnrollmentDbContext db

        group.MapGet("/", async (IEnrollmentRepository repo, IMapper mapper) =>
        {
            //var enrollments = await db.Enrollments.ToListAsync();
            var enrollments = await repo.GetAllAsync();
            var data = mapper.Map<List<EnrollmentDto>>(enrollments);

            //return await db.Enrollments.ToListAsync();

            return data;
        })
        .WithName("GetAllEnrollments")
        .Produces<List<EnrollmentDto>>(StatusCodes.Status200OK)
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<EnrollmentDto>, NotFound>> (int id, IEnrollmentRepository repo, IMapper mapper) =>
        {
            //var foundModel = await db.Enrollments.FindAsync(id);
            //var foundModel = await repo.GetAsync(id);
            //var data = mapper.Map<EnrollmentDto>(foundModel);

            //if (foundModel is null)
            //{
            //    return TypedResults.NotFound();
            //}

            //return TypedResults.Ok(data);

            //return await db.Enrollments.AsNoTracking()
            //    .FirstOrDefaultAsync(model => model.Id == id)
            //    is Enrollment model
            //        ? TypedResults.Ok(model)
            //        : TypedResults.NotFound();

            return await repo.GetDetails(id)
                is Enrollment model
                    ? TypedResults.Ok(mapper.Map<EnrollmentDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetEnrollmentById")
        .WithOpenApi();

        group.MapPut("/{id}", [Authorize(Roles = "Administrator")] async Task<Results<NoContent, NotFound>> (int id, EnrollmentDto enrollmentDto, IEnrollmentRepository repo, IMapper mapper) =>
        {
            //var foundModel = await db.Enrollments.FindAsync(id);
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            mapper.Map(enrollmentDto, foundModel);

            //await db.SaveChangesAsync();
            await repo.UpdateAsync(foundModel);

            //await db.Enrollments
            //    .Where(model => model.Id == id)
            //    .ExecuteUpdateAsync(setters => setters
            //        .SetProperty(m => m.CourseId, data.CourseId)
            //        .SetProperty(m => m.StudentId, data.StudentId)
            //    );

            return TypedResults.NoContent();
        })
        .WithName("UpdateEnrollment")
        .WithOpenApi();

        group.MapPost("/", async (CreateEnrollmentDto createEnrollmentDto, IEnrollmentRepository repo, IMapper mapper) =>
        {
            var enrollment = mapper.Map<Enrollment>(createEnrollmentDto);
            //db.Enrollments.Add(enrollment);
            //await db.SaveChangesAsync();

            await repo.AddAsync(enrollment);

            return TypedResults.Created($"/api/Enrollment/{enrollment.Id}", enrollment);
        })
        .WithName("CreateEnrollment")
        .WithOpenApi();

        group.MapDelete("/{id}", [Authorize(Roles = "Administrator")] async Task<Results<NoContent, NotFound>> (int id, IEnrollmentRepository repo) =>
        {
            //var foundModel = await db.Courses.FindAsync(id);
            //var foundModel = await repo.GetAsync(id);

            //if (foundModel is null)
            //{
            //    return TypedResults.NotFound();
            //}

            //await db.Enrollments
            //    .Where(model => model.Id == id)
            //    .ExecuteDeleteAsync();

            //await repo.DeleteAsync(id);

            //return TypedResults.NoContent();

            return await repo.DeleteAsync(id) ? TypedResults.NoContent() : TypedResults.NotFound();
        })
        .WithName("DeleteEnrollment")
        .WithOpenApi();
    }
}
