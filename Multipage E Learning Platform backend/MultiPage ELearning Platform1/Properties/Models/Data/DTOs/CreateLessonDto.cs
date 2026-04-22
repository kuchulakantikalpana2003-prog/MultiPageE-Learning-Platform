namespace MultiPage_ELearning_Platform1.DTOs.LessonDTOs
{
    public class CreateLessonDto
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int OrderIndex { get; set; }
    }
}