using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollmentData;
using StudentEnrollmentApi.DTOs.Course;
using AutoMapper;
using StudentEnrollmentData.Contracts;
using StudentEnrollmentApi.DTOs.Enrollment;

namespace StudentEnrollmentApi.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        //StudentEnrollmentDbContext db

        group.MapGet("/", async (ICourseRepository repo, IMapper mapper) =>
        {
            //var courses = await db.Courses.ToListAsync();
            var courses = await repo.GetAllAsync();
            var data = mapper.Map<List<CourseDto>>(courses);

            //var data = new List<CourseDto>();

            //foreach (var course in courses)
            //{
            //    data.Add(new CourseDto
            //    {
            //        Id = course.Id,
            //        Title = course.Title,
            //        Credits = course.Credits
            //    });
            //}

            return data;
        })
        .WithName("GetAllCourses")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<CourseDto>, NotFound>> (int id, ICourseRepository repo, IMapper mapper) =>
        {
            //var foundModel = await db.Courses.FindAsync(id);
            //var foundModel = await repo.GetAsync(id);

            //var data = mapper.Map<CourseDto>(foundModel);

            //var data = new CourseDto { 
            //    Id = course.Id,
            //    Title = course.Title,
            //    Credits = course.Credits
            //};

            //if (foundModel is null)
            //{
            //    return TypedResults.NotFound();
            //}

            //return TypedResults.Ok(data);

            return await repo.GetAsync(id)
                is Course model
                    ? TypedResults.Ok(mapper.Map<CourseDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi();

        group.MapGet("/GetStudents/{id}", async Task<Results<Ok<CourseDetailsDto>, NotFound>> (int Id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentList(Id) is Course model ? TypedResults.Ok(mapper.Map<CourseDetailsDto>(model)) : TypedResults.NotFound();
        })
        .WithName("GetCourseDetailsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> (int id, CourseDto courseDto, ICourseRepository repo, IMapper mapper) =>
        {
            //var foundModel = await db.Courses.FindAsync(id);
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            mapper.Map(courseDto, foundModel);

            //await db.SaveChangesAsync();
            await repo.UpdateAsync(foundModel);

            return TypedResults.NoContent();
        })
        .WithName("UpdateCourse")
        .WithOpenApi();

        group.MapPost("/", async (CreateCourseDto createCourseDto, ICourseRepository repo, IMapper mapper) =>
        {
            var course = mapper.Map<Course>(createCourseDto);

            //var course = new Course { 
            //    Title = createCourseDto.Title,
            //    Credits = createCourseDto.Credits
            //};

            //db.Courses.Add(course);
            //await db.SaveChangesAsync();

            await repo.AddAsync(course);
            return TypedResults.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> (int id, ICourseRepository repo) =>
        {
            //var foundModel = await db.Courses.FindAsync(id);
            //var foundModel = await repo.GetAsync(id);

            //if (foundModel is null)
            //{
            //    return TypedResults.NotFound();
            //}

            //await db.Courses
            //    .Where(model => model.Id == id)
            //    .ExecuteDeleteAsync();

            //await repo.DeleteAsync(id);

            //return TypedResults.NoContent();

            return await repo.DeleteAsync(id) ? TypedResults.NoContent() : TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi();
    }
}
