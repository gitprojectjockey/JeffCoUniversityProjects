using JeffCoUniversity.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeffCoUniversity.Data.Core.Repositories
{
    public interface IInstructorRepository :ITitanRepository<Instructor>
    {
        Task<Instructor> GetInstructorWithCourses(int id);
        Task<IEnumerable<Instructor>> GetInstructorsWithCourses();
    }
}