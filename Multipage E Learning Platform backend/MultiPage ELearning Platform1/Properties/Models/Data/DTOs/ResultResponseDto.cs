namespace MultiPage_ELearning_Platform1.DTOs.ResultDTOs
{
    public class ResultResponseDto
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public double Percentage { get; set; }
        public string Status { get; set; }
        public DateTime AttemptDate { get; set; }
    }
}