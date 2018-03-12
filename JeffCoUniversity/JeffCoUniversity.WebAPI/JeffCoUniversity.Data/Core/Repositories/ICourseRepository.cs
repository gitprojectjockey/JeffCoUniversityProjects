using JeffCoUniversity.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JeffCoUniversity.Data.Core.Repositories
{
    public interface ICourseRepository : ITitanRepository<Course>
    {
        Task<Course> GetCourseWithInstructors(int id);
        Task<IEnumerable<Course>> GetCoursesWithInstructors();
    }
}