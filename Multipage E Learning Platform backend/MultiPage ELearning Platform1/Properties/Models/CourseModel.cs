using System.ComponentModel.DataAnnotations;

namespace MultiPage_ELearning_Platform1.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // =========================
        // RELATIONSHIPS
        // =========================

        public User? User { get; set; }

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}






