using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.DTOs.QuestionDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;

namespace MultiPage_ELearning_Platform1.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        // CREATE QUESTION
        public async Task<QuestionResponseDto> CreateAsync(CreateQuestionDto dto)
        {
            var question = new Question
            {
                QuizId = dto.QuizId,
                QuestionText = dto.QuestionText,
                OptionA = dto.OptionA,
                OptionB = dto.OptionB,
                OptionC = dto.OptionC,
                OptionD = dto.OptionD,
                CorrectAnswer = dto.CorrectAnswer
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return new QuestionResponseDto
            {
                QuestionId = question.QuestionId,
                QuizId = question.QuizId,
                QuestionText = question.QuestionText,
                OptionA = question.OptionA,
                OptionB = question.OptionB,
                OptionC = question.OptionC,
                OptionD = question.OptionD
            };
        }

        // GET BY QUIZ
        public async Task<List<QuestionResponseDto>> GetByQuizAsync(int quizId)
        {
            return await _context.Questions
                .AsNoTracking()
                .Where(q => q.QuizId == quizId)
                .Select(q => new QuestionResponseDto
                {
                    QuestionId = q.QuestionId,
                    QuizId = q.QuizId,
                    QuestionText = q.QuestionText,
                    OptionA = q.OptionA,
                    OptionB = q.OptionB,
                    OptionC = q.OptionC,
                    OptionD = q.OptionD
                })
                .ToListAsync();
        }
        public async Task<QuestionResponseDto?> GetByIdAsync(int id)
        {
            var q = await _context.Questions.FindAsync(id);

            if (q == null) return null;

            return new QuestionResponseDto
            {
                QuestionId = q.QuestionId,
                QuizId = q.QuizId,
                QuestionText = q.QuestionText,
                OptionA = q.OptionA,
                OptionB = q.OptionB,
                OptionC = q.OptionC,
                OptionD = q.OptionD
            };
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, CreateQuestionDto dto)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
                return false;

            question.QuestionText = dto.QuestionText;
            question.OptionA = dto.OptionA;
            question.OptionB = dto.OptionB;
            question.OptionC = dto.OptionC;
            question.OptionD = dto.OptionD;
            question.CorrectAnswer = dto.CorrectAnswer;

            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
                return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}