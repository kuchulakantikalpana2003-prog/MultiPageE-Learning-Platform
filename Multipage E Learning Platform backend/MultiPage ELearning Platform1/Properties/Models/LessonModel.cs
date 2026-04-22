using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPage_ELearning_Platform1.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public int OrderIndex { get; set; }

        // =========================
        // FOREIGN KEY
        // =========================

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        // Navigation property
        public Course? Course { get; set; }
    }
}