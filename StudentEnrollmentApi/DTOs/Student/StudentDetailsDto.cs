using StudentEnrollmentApi.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentApi.DTOs.Student
{
    public class StudentDetailsDto : CreateStudentDto
    {
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
}
