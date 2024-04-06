using Microsoft.EntityFrameworkCore;
using StudentEnrollmentData.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentData.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(StudentEnrollmentDbContext db) : base(db)
        {
        }

        public async Task<Enrollment> GetDetails(int enrollmentId)
        {
            var enrollment = await _db.Enrollments
                .Include(q => q.Course)
                .Include(q => q.Student)
                .FirstOrDefaultAsync(q => q.Id == enrollmentId);

            return enrollment;
        }
    }
}
