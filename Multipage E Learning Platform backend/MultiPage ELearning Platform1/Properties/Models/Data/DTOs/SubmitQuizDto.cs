using System.Collections.Generic;

namespace MultiPage_ELearning_Platform1.DTOs.QuizDTOs
{
    public class SubmitQuizDto
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public List<UserAnswerDto> Answers { get; set; }
    }

    public class UserAnswerDto
    {
        public int QuestionId { get; set; }
        public string SelectedOption { get; set; }
    }
}