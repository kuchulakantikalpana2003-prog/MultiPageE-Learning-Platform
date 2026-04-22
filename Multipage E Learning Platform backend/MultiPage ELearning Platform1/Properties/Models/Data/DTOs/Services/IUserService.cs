using MultiPage_ELearning_Platform1.DTOs.UserDTOs;

namespace MultiPage_ELearning_Platform1.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterAsync(RegisterUserDto dto);

        Task<UserResponseDto?> GetByIdAsync(int id);

        Task<List<UserResponseDto>> GetAllAsync();

        Task<bool> UpdateAsync(int id, UpdateUserDto dto);

        Task<bool> DeleteAsync(int id);
    }
}