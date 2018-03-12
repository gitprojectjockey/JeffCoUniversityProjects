using JeffCoUniversity.Data.Core.UnitOfWork;
using JeffCoUniversity.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeffCoUniversity.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Course> GetCourse(int id)
        {
            return _unitOfWork.Courses.Get(id);
        }

        public Task<IEnumerable<Course>> GetAllCourses()
        {
            return _unitOfWork.Courses.GetAll();
        }

        public Task<Course> GetCourseWithInstructors(int id)
        {
            return _unitOfWork.Courses.GetCourseWithInstructors(id);
        }

        public Task<IEnumerable<Course>> GetCoursesWithInstructors()
        {
            return _unitOfWork.Courses.GetCoursesWithInstructors();
        }
    }
}
