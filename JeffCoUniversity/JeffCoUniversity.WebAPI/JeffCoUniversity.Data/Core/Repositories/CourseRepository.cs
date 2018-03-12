using JeffCoUniversity.Data.Core.DataContext;
using JeffCoUniversity.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace JeffCoUniversity.Data.Core.Repositories
{
    public class CourseRepository : TitanRepository<Course>, ICourseRepository
    {
        private readonly TitanDbContext _context;
        public CourseRepository(TitanDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseWithInstructors(int id)
        {
            return await _context.Courses
                   .Include(c => c.Instructors)
                   .Where(c => c.Id ==id)
                   .FirstOrDefaultAsync() as Course;
        }

        public async Task<IEnumerable<Course>> GetCoursesWithInstructors()
        {
            return await _context.Courses.Include(c => c.Instructors)
               .OrderBy(c => c.Title)
               .ToListAsync() as IEnumerable<Course>;
        }
    }
}
