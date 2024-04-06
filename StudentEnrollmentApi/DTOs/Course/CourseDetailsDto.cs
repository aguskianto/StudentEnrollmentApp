using StudentEnrollmentApi.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentApi.DTOs.Course
{
    public class CourseDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
