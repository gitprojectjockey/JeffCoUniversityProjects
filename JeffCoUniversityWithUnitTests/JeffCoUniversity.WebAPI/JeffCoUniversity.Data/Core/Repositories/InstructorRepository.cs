using JeffCoUniversity.Data.Core.DataContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using JeffCoUniversity.Domain.Entities;

namespace JeffCoUniversity.Data.Core.Repositories
{
    public class InstructorRepository : TitanRepository<Instructor>, IInstructorRepository
    {
        private readonly TitanDbContext _context;
        public InstructorRepository(TitanDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Instructor> GetInstructorWithCourses(int id)
        {
            return await _context.Instructors
                  .Include(i => i.Courses)
                  .Where(i => i.Id == id)
                  .FirstOrDefaultAsync() as Instructor;
        }

        public async Task<IEnumerable<Instructor>> GetInstructorsWithCourses()
        {
            return await _context.Instructors.Include(i => i.Courses)
                .OrderBy(i => i.LastName)
                .ToListAsync() as IEnumerable<Instructor>;
        }
    }
}

