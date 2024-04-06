using StudentEnrollmentApi.DTOs.Course;
using StudentEnrollmentApi.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentApi.DTOs.Enrollment
{
    public class EnrollmentDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual CourseDto Course { get; set; }
        public virtual StudentDto Student { get; set; }
    }
}
