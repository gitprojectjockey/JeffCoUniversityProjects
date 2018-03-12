using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeffCoUniversity.Domain.Entities
{
        public class Instructor
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            [Index(IsUnique = true)]
            public string LastName { get; set; }

            public DateTime HireDate { get; set; }

            public string FullName
            {
                get { return LastName + ", " + FirstName; }
            }

            public List<Course> Courses { get; set; }
    }
}
