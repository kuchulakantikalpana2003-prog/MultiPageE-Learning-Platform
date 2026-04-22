using MultiPage_ELearning_Platform1.Models;

namespace MultiPage_ELearning_Platform1.Repositories.Interfaces
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetByCourseIdAsync(int courseId);
        Task<Lesson?> GetByIdAsync(int id);
        Task<Lesson> AddAsync(Lesson lesson);
        Task<bool> UpdateAsync(Lesson lesson);
        Task<bool> DeleteAsync(int id);
    }
}