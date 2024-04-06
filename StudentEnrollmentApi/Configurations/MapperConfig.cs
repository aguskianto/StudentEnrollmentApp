using AutoMapper;
using StudentEnrollmentApi.DTOs.Course;
using StudentEnrollmentApi.DTOs.Enrollment;
using StudentEnrollmentApi.DTOs.Student;
using StudentEnrollmentData;

namespace StudentEnrollmentApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, CourseDetailsDto>()
                .ForMember(q => q.Students, x => x.MapFrom(course => course.Enrollments.Select(stu => stu.Student)));

            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentDetailsDto>()
                .ForMember(q => q.Courses, x => x.MapFrom(student => student.Enrollments.Select(course => course.Course)));

            CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
        }
    }
}
