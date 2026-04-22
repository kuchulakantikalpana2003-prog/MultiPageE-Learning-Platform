using MultiPage_ELearning_Platform1.DTOs.LessonDTOs;

namespace MultiPage_ELearning_Platform1.Services.Interfaces
{
    public interface ILessonService
    {
        Task<LessonResponseDto> CreateAsync(CreateLessonDto dto);

        Task<List<LessonResponseDto>> GetByCourseAsync(int courseId);

        Task<bool> UpdateAsync(int id, UpdateLessonDto dto); // ✅ FIXED
        Task<LessonResponseDto?> GetByIdAsync(int id); // ✅ ADD THIS

        Task<bool> DeleteAsync(int id);
    }
}