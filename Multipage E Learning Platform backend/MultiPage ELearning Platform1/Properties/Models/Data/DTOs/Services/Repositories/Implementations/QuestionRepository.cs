using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Repositories.Interfaces;

namespace MultiPage_ELearning_Platform1.Repositories.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetByQuizIdAsync(int quizId)
        {
            return await _context.Questions
                .Where(q => q.QuizId == quizId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions
                .FirstOrDefaultAsync(q => q.QuestionId == id);
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Question question)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}