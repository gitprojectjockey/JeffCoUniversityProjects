using System.Collections.Generic;
using System.Threading.Tasks;
using JeffCoUniversity.Domain.Entities;

namespace JeffCoUniversity.Services
{
    public interface ICourseService
    {
        Task<Course> GetCourseWithInstructors(int id);
        Task<IEnumerable<Course>> GetCoursesWithInstructors();
    }
}