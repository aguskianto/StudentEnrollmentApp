using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentApi.DTOs.Student
{
    public class StudentDto : CreateStudentDto
    {
        public int Id { get; set; }
    }
}
