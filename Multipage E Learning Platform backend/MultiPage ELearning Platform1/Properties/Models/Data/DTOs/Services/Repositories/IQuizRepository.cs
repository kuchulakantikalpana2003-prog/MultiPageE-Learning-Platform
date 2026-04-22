using MultiPage_ELearning_Platform1.Models;

namespace MultiPage_ELearning_Platform1.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetAllAsync();
        Task<List<Quiz>> GetByCourseIdAsync(int courseId);
        Task<Quiz?> GetByIdAsync(int id);
        Task AddAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(Quiz quiz);
        
    }
}