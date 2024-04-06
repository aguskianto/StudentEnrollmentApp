using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentData.Contracts
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetStudentDetails(int studentId);
    }
}
