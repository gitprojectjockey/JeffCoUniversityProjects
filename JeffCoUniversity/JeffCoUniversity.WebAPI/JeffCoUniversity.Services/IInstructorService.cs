using System.Collections.Generic;
using System.Threading.Tasks;
using JeffCoUniversity.DTO.Inbound;
using JeffCoUniversity.DTO.Outbound;

namespace JeffCoUniversity.Services
{
    public interface IInstructorService
    {
        Task CreateInstructor(InstructorWithCoursesIn instructorWithCoursesIn);
        Task CreateInstructors(IEnumerable<InstructorWithCoursesIn> instructorsWithCoursesIn);
        Task<IEnumerable<InstructorOut>> GetAllInstructors();
        Task<InstructorOut> GetInstructor(int id);
        Task<IEnumerable<InstructorWithCoursesOut>> GetInstructorsWithCourses();
        Task<InstructorWithCoursesOut> GetInstructorWithCourses(int id);
        Task UpdateInstructor(InstructorWithCoursesIn instructorWithCoursesIn);
    }
}