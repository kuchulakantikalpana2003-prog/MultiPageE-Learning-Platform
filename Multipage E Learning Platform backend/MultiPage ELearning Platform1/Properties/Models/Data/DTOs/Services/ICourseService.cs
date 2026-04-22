using MultiPage_ELearning_Platform1.DTOs.CourseDTOs;

namespace MultiPage_ELearning_Platform1.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllAsync();

        Task<CourseDto?> GetByIdAsync(int id);

        Task<CourseDto> CreateAsync(CourseDto dto);

        Task<bool> UpdateAsync(int id, CourseDto dto);

        Task<bool> DeleteAsync(int id);
    }
}