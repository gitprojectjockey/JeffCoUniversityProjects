
using JeffCoUniversity.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace JeffCoUniversity.Data.Core.DataContext.EntityMaps
{
    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>()
                .HasKey(i => i.Id)
                .Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Properties<string>()
               .Where(c => c.Name == "FirstName")
               .Configure(s => s.HasMaxLength(200).HasColumnType("nvarchar").IsRequired());

            modelBuilder.Properties<string>()
               .Where(c => c.Name == "LastName")
               .Configure(s => s.HasMaxLength(250).HasColumnType("nvarchar").IsRequired());

            modelBuilder.Entity<Instructor>()
                .Property(i => i.HireDate)
                .IsRequired()
                .HasColumnType("DateTime");

            modelBuilder.Entity<Instructor>()
                .Ignore(i => i.Courses);
        }

    }
}
