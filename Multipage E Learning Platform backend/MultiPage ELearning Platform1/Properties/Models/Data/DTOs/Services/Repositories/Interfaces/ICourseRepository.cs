using MultiPage_ELearning_Platform1.Models;

namespace MultiPage_ELearning_Platform1.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> AddAsync(Course course);
        Task<bool> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
        
    }
}