namespace MultiPage_ELearning_Platform1.DTOs.CourseDTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }   // ✅ REQUIRED

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CreatedBy { get; set; }
    }
}