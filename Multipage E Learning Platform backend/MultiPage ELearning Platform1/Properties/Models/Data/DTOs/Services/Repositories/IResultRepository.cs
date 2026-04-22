using MultiPage_ELearning_Platform1.Models;

namespace MultiPage_ELearning_Platform1.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<List<Result>> GetByUserIdAsync(int userId);

        Task AddAsync(Result result);
    }
}