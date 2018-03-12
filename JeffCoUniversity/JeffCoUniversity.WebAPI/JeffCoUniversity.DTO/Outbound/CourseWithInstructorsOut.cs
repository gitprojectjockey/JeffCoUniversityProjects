namespace JeffCoUniversity.DTO.Outbound
{
    public class CourseWithInstructorsOut
    {
        public int Id { get; set; }

        public int CourseNumber { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public string CourseInfo => $"Course Number:{CourseNumber} Course Title:{Title} Course Credits:{Credits}";
    }
}
