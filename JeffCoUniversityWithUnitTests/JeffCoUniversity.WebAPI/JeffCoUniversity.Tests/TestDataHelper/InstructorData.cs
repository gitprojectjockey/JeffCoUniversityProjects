using JeffCoUniversity.DTO.Inbound;
using JeffCoUniversity.DTO.Outbound;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeffCoUniversity.Tests.TestDataHelper
{
    public static class InstructorData
    {
        public static IEnumerable<InstructorOut> GetInstructorsOut()
        {
            List<InstructorOut> instructors = new List<InstructorOut>()
            {
                new InstructorOut() { Id = 1, FirstName = "Eric", LastName = "Patterson", HireDate = DateTime.Now.AddDays(-1000) },
                new InstructorOut() { Id = 2, FirstName = "Sam", LastName = "TwoTones", HireDate = DateTime.Now.AddDays(-20) },
                new InstructorOut() { Id = 3, FirstName = "Tammy", LastName = "Millhouse", HireDate = DateTime.Now.AddDays(-60) },
                new InstructorOut() { Id = 4, FirstName = "Bill", LastName = "Tapper", HireDate = DateTime.Now.AddDays(-600) },
                new InstructorOut() { Id = 5, FirstName = "Beckey", LastName = "Mills", HireDate = DateTime.Now.AddDays(-300) }
        };
            return instructors;
        }

        public static InstructorOut GetInstructorOut()
        {
            return new InstructorOut() { Id = 3, FirstName = "Tammy", LastName = "Millhouse", HireDate = DateTime.Now.AddDays(-60) };
        }

        public static InstructorWithCoursesIn GetInstructorWithCoursesIn()
        {
            List<CourseIn> courses = new List<CourseIn>()
            {
                new CourseIn() {Id=1, CourseNumber = 123456,Credits=4, Title="Biology"},
                new CourseIn() {Id=1, CourseNumber = 654321,Credits=3, Title="Math"},
                new CourseIn() {Id=1, CourseNumber = 234511,Credits=3, Title="Social Science"},
                new CourseIn() {Id=1, CourseNumber = 111111,Credits=4, Title="English"},
            };

            return new InstructorWithCoursesIn() { Id = 5, FirstName = "Beckey", LastName = "Mills", HireDate = DateTime.Now.AddDays(-300), Courses = courses };
        }
    }
}
