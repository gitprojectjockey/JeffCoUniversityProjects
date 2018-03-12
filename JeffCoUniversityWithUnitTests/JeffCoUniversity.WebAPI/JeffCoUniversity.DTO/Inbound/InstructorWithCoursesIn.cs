using System;
using System.Collections.Generic;


namespace JeffCoUniversity.DTO.Inbound

{
    public class InstructorWithCoursesIn
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime HireDate { get; set; }

        public List<CourseIn> Courses { get; set; }
    }
}
