namespace MultiPage_ELearning_Platform1.DTOs.CourseDTOs
{
    public class CourseResponseDto
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
    }
}