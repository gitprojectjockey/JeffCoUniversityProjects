using JeffCoUniversity.Data.Core.DataContext;
using JeffCoUniversity.Data.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace JeffCoUniversity.Data.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TitanDbContext _context;
        public UnitOfWork(TitanDbContext context)
        {
            _context = context;
            Instructors = new InstructorRepository(_context);
            Courses = new CourseRepository(_context);
        }

        public IInstructorRepository Instructors { get; private set; }
        public ICourseRepository Courses { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
