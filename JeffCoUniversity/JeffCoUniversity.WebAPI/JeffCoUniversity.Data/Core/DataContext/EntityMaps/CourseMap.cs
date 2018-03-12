using JeffCoUniversity.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace JeffCoUniversity.Data.Core.DataContext.EntityMaps
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
              .HasKey(c => c.Id)
              .Property(c => c.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseNumber)
                .IsRequired();

            modelBuilder.Properties<string>()
                .Where(c => c.Name == "Title")
                .Configure(s => s.HasMaxLength(200).HasColumnType("nvarchar").IsRequired());

            modelBuilder.Entity<Course>()
                .Property(c => c.Credits)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Ignore(c => c.Instructors);
        }
    }
}
