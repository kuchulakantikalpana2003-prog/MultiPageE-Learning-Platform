using System.ComponentModel.DataAnnotations;

namespace MultiPage_ELearning_Platform1.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // =========================
        // RELATIONSHIPS
        // =========================

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Result> Results { get; set; } = new List<Result>();
    }
}
