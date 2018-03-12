using JeffCoUniversity.Common.Factories;
using JeffCoUniversity.Data.Core.UnitOfWork;
using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Inbound;
using JeffCoUniversity.DTO.Outbound;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeffCoUniversity.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstructorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InstructorOut> GetInstructor(int id)
        {
            var instructor = await _unitOfWork.Instructors.Get(id);
            return DTOAssemblerFactory<InstructorOut, Instructor>.CreateAssembler().AssembleDTO(instructor);
        }

        public async Task<IEnumerable<InstructorOut>> GetAllInstructors()
        {
            var instructors = await _unitOfWork.Instructors.GetAll();
            return DTOAssemblerFactory<IEnumerable<InstructorOut>, IEnumerable<Instructor>>.CreateAssembler().AssembleDTO(instructors);
        }

        public async Task<InstructorWithCoursesOut> GetInstructorWithCourses(int id)
        {
            var instructorWithCourses = await _unitOfWork.Instructors.GetInstructorWithCourses(id);
            return DTOAssemblerFactory<InstructorWithCoursesOut, Instructor>.CreateAssembler().AssembleDTO(instructorWithCourses);
        }

        public async Task<IEnumerable<InstructorWithCoursesOut>> GetInstructorsWithCourses()
        {
            var instructorsWithCourses = await _unitOfWork.Instructors.GetInstructorsWithCourses();
            return DTOAssemblerFactory<IEnumerable<InstructorWithCoursesOut>, IEnumerable<Instructor>>.CreateAssembler().AssembleDTO(instructorsWithCourses);
        }

        public async Task CreateInstructor(InstructorWithCoursesIn instructorWithCoursesIn)
        {
            Instructor instructor = EntityAssemblerFactory<Instructor, InstructorWithCoursesIn>.CreateAssembler().AssembleEntity(instructorWithCoursesIn);
            List<Course> existingCourseList = new List<Course>();
            foreach (var course in instructor.Courses)
            {
                existingCourseList.Add(await LoadExistingCourseAsync(c => c.Id == course.Id, course.Id));
            }

            instructor.Courses.Clear();
            instructor.Courses.AddRange(existingCourseList);
            _unitOfWork.Instructors.Add(instructor);

            await _unitOfWork.Complete();
        }

        public async Task CreateInstructors(IEnumerable<InstructorWithCoursesIn> instructorsWithCoursesIn)
        {
            IEnumerable<Instructor> instructors = EntityAssemblerFactory<IEnumerable<Instructor>, IEnumerable<InstructorWithCoursesIn>>.CreateAssembler().AssembleEntity(instructorsWithCoursesIn);

            List<Course> existingCourseList = new List<Course>();
            foreach (Instructor instructor in instructors)
            {
                foreach (var course in instructor.Courses)
                {
                    //Func<Course, bool> predicate = c => c.Id == course.Id;
                    existingCourseList.Add(await LoadExistingCourseAsync(c => c.Id == course.Id, course.Id));
                }
                instructor.Courses.Clear();
                instructor.Courses.AddRange(existingCourseList);
                existingCourseList.Clear();
            }
            _unitOfWork.Instructors.AddRange(instructors);
            await _unitOfWork.Complete();
        }

        private async Task<Course> LoadExistingCourseAsync(Func<Course, bool> p, int Id)
        {
            return await _unitOfWork.Courses.Get(Id);
        }

        public async Task UpdateInstructor(InstructorWithCoursesIn instructorWithCoursesIn)
        {
            Instructor instructorToUpdate = await _unitOfWork.Instructors.GetInstructorWithCourses(instructorWithCoursesIn.Id);

            instructorToUpdate.Id = instructorWithCoursesIn.Id;
            instructorToUpdate.FirstName = instructorWithCoursesIn.FirstName;
            instructorToUpdate.LastName = instructorWithCoursesIn.LastName;
            instructorToUpdate.HireDate = instructorWithCoursesIn.HireDate;

            List<Course> courseList = new List<Course>();
            foreach (var course in instructorWithCoursesIn.Courses)
            {
                var existingCourse = await _unitOfWork.Courses.Get(course.Id);
                if (existingCourse != null)
                {
                    courseList.Add(existingCourse);
                }
            }
            instructorToUpdate.Courses = courseList;
            _unitOfWork.Instructors.Update(instructorToUpdate);
            await _unitOfWork.Complete();
        }
    }
}



