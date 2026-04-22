using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.DTOs.ResultDTOs;
using MultiPage_ELearning_Platform1.DTOs.QuizDTOs; // ✅ IMPORTANT
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Services.Interfaces;

namespace MultiPage_ELearning_Platform1.Services.Implementations
{
    public class ResultService : IResultService
    {
        private readonly AppDbContext _context;

        public ResultService(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET RESULTS BY USER
        // =========================
        public async Task<List<ResultResponseDto>> GetByUserIdAsync(int userId)
        {
            return await _context.Results
                .AsNoTracking()
                .Where(r => r.UserId == userId)
                .Select(r => new ResultResponseDto
                {
                    ResultId = r.ResultId,
                    UserId = r.UserId,
                    QuizId = r.QuizId,
                    Score = r.Score,
                    Percentage = r.Percentage,   // ✅ FIX
                    Status = r.Status,           // ✅ FIX
                    AttemptDate = r.AttemptDate
                })
                .ToListAsync();
        }

        // =========================
        // SUBMIT QUIZ
        // =========================
        public async Task<ResultResponseDto> SubmitQuizAsync(SubmitQuizDto dto)
        {
            var questions = await _context.Questions
                .Where(q => q.QuizId == dto.QuizId)
                .ToListAsync();

            int totalQuestions = questions.Count;
            int score = 0;

            foreach (var question in questions)
            {
                var answer = dto.Answers
                    .FirstOrDefault(a => a.QuestionId == question.QuestionId);

                if (answer != null && answer.SelectedOption == question.CorrectAnswer)
                {
                    score++;
                }
            }

            double percentage = totalQuestions == 0 ? 0 :
                ((double)score / totalQuestions) * 100;

            string status = percentage >= 50 ? "Pass" : "Fail";

            var result = new Result
            {
                UserId = dto.UserId,
                QuizId = dto.QuizId,
                Score = score,
                Percentage = percentage,
                Status = status,
                AttemptDate = DateTime.UtcNow
            };

            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return new ResultResponseDto
            {
                ResultId = result.ResultId,
                UserId = dto.UserId,
                QuizId = dto.QuizId,
                Score = score,
                Percentage = percentage,
                Status = status,
                AttemptDate = result.AttemptDate
            };
        }
    }
}