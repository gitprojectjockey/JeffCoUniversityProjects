using JeffCoUniversity.Data.Core.DataContext;
using JeffCoUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace JeffCoUniversity.Data.Core.Initializers
{
    public class JeffCoDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TitanDbContext>
    {
        protected override void Seed(TitanDbContext context)
        {
            var instructors = new List<Instructor>
            {
                new Instructor { FirstName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };


            var courses = new List<Course>
            {
                new Course {CourseNumber = 1050, Title = "Chemistry",Credits = 3,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseNumber  = 4022, Title = "Microeconomics",Credits = 3,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseNumber  = 4041, Title = "Macroeconomics",Credits = 3,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseNumber = 1045, Title = "Calculus",Credits = 4,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseNumber = 3141, Title = "Trigonometry", Credits = 4,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseNumber = 2021, Title = "Composition", Credits = 3,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseNumber = 2042, Title = "Literature", Credits = 4,
                  Instructors = new List<Instructor>()
                },
            };

            //Add Instructor and Courses in many to many relationship
            instructors.ForEach(i => i.Courses = courses);
            instructors.ForEach(instr => context.Instructors.AddOrUpdate(i => i.LastName, instr));
            context.SaveChanges();
        }
    }
}
