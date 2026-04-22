using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPage_ELearning_Platform1.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        // =========================
        // FOREIGN KEY (Course)
        // =========================

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course? Course { get; set; }

        // =========================
        // RELATIONSHIP
        // =========================

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}