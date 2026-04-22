using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Repositories.Interfaces;

namespace MultiPage_ELearning_Platform1.Repositories.Implementations
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext _context;

        public ResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Result>> GetByUserIdAsync(int userId)
        {
            return await _context.Results
                .Where(r => r.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Result result)
        {
            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
        }
    }
}