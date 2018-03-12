using System;

namespace JeffCoUniversity.DTO.Outbound
{
    public class InstructorOut
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime HireDate { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
