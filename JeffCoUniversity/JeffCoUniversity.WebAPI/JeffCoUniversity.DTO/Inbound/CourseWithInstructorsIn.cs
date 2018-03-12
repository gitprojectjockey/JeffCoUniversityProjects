using System.Collections.Generic;

namespace JeffCoUniversity.DTO.Inbound

{
    public class CourseWithInstructorsIn
    {
        public int Id { get; set; }

        public int CourseNumber { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public List<InstructorIn> Instructors { get; set; }
    }
}
