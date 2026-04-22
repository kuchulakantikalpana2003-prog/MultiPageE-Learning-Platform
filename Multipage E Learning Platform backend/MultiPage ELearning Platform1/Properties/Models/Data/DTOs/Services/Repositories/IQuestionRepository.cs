using MultiPage_ELearning_Platform1.Models;

namespace MultiPage_ELearning_Platform1.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetByQuizIdAsync(int quizId);
        Task<Question?> GetByIdAsync(int id);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(Question question);
        
    }
}