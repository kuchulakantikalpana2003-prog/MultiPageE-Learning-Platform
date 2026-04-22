using System.ComponentModel.DataAnnotations;
namespace MultiPage_ELearning_Platform1.DTOs.UserDTOs
{

    public class RegisterUserDto
    {
        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
    }
}