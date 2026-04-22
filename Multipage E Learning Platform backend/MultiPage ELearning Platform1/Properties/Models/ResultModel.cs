using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPage_ELearning_Platform1.Models
{
    public class Result
    {
        public int ResultId { get; set; }

        public int UserId { get; set; }
        public int QuizId { get; set; }

        public int Score { get; set; }

        public double Percentage { get; set; }   // ✅ NEW
        public string Status { get; set; }       // ✅ Pass / Fail

        public DateTime AttemptDate { get; set; }
    }
}