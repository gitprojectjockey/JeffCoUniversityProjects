using JeffCoUniversity.Data.Core.DataContext.EntityMaps;
using JeffCoUniversity.Domain.Entities;
using System.Data.Entity;

namespace JeffCoUniversity.Data.Core.DataContext
{
    public  class TitanDbContext : DbContext
    {
        public TitanDbContext() : base("name=TitanDbContext")
        {
            Database.SetInitializer(new Initializers.JeffCoDataInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new InstructorMap(modelBuilder));
            modelBuilder.Configurations.Add(new CourseMap(modelBuilder));

            base.OnModelCreating(modelBuilder);
        }
    }
}
