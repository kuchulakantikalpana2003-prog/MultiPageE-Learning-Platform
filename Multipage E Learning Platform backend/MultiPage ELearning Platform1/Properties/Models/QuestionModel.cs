using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPage_ELearning_Platform1.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public int QuizId { get; set; }   // ✅ REQUIRED FIX

        public string? QuestionText { get; set; }
        public string? OptionA { get; set; }
        public string? OptionB { get; set; }
        public string? OptionC { get; set; }
        public string? OptionD { get; set; }
        public string? CorrectAnswer { get; set; }

        public Quiz Quiz { get; set; }
    }
}