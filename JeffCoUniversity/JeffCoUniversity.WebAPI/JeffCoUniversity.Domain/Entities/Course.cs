using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeffCoUniversity.Domain.Entities
{
        public class Course
        {
            public int Id { get; set; }

            [Index(IsUnique = true)]
            public int CourseNumber { get; set; }

            public string Title { get; set; }

            public int Credits { get; set; }

            public List<Instructor> Instructors { get; set; }
        }
}
