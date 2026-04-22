using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.DTOs.QuizDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;

namespace MultiPage_ELearning_Platform1.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly AppDbContext _context;

        public QuizService(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // CREATE QUIZ
        // =========================
        public async Task<QuizResponseDto> CreateAsync(CreateQuizDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var quiz = new Quiz
            {
                Title = dto.Title,
                CourseId = dto.CourseId
            };

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return new QuizResponseDto
            {
                QuizId = quiz.QuizId,
                Title = quiz.Title,
                CourseId = quiz.CourseId
            };
        }

        // =========================
        // GET QUIZZES BY COURSE
        // =========================
        public async Task<List<QuizResponseDto>> GetByCourseAsync(int courseId)
        {
            return await _context.Quizzes
                .AsNoTracking()
                .Where(q => q.CourseId == courseId)
                .Select(q => new QuizResponseDto
                {
                    QuizId = q.QuizId,
                    Title = q.Title,
                    CourseId = q.CourseId
                })
                .ToListAsync();
        }

        // =========================
        // GET QUIZ WITH QUESTIONS (✅ FIXED)
        // =========================
        public async Task<object> GetQuizWithQuestionsAsync(int quizId)
        {
            return await _context.Quizzes
                .Where(q => q.QuizId == quizId)
                .Select(q => new
                {
                    QuizId = q.QuizId,
                    Title = q.Title,
                    Questions = q.Questions.Select(ques => new
                    {
                        QuestionId = ques.QuestionId,
                        QuestionText = ques.QuestionText,
                        OptionA = ques.OptionA,
                        OptionB = ques.OptionB,
                        OptionC = ques.OptionC,
                        OptionD = ques.OptionD
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        // =========================
        // UPDATE QUIZ
        // =========================
        public async Task<bool> UpdateAsync(int id, CreateQuizDto dto)
        {
            if (dto == null)
                return false;

            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
                return false;

            quiz.Title = dto.Title;
            quiz.CourseId = dto.CourseId;

            await _context.SaveChangesAsync();
            return true;
        }

        // =========================
        // DELETE QUIZ
        // =========================
        public async Task<bool> DeleteAsync(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
                return false;

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
