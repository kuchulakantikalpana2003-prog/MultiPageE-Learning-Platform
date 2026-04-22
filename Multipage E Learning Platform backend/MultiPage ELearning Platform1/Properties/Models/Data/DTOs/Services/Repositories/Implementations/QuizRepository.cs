using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Repositories.Interfaces;

namespace MultiPage_ELearning_Platform1.Repositories.Implementations
{
    public class QuizRepository : IQuizRepository
    {
        private readonly AppDbContext _context;

        public QuizRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Quiz>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Quizzes
                .Where(q => q.CourseId == courseId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Quiz?> GetByIdAsync(int id)
        {
            return await _context.Quizzes
                .FirstOrDefaultAsync(q => q.QuizId == id);
        }

        public async Task AddAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Quiz quiz)
        {
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }
    }
}