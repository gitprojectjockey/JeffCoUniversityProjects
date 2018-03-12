using System;
using System.Collections.Generic;

namespace JeffCoUniversity.DTO.Outbound
{
    public class InstructorWithCoursesOut
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime HireDate { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public List<CourseOut> Courses { get; set; }
       
    }
}
