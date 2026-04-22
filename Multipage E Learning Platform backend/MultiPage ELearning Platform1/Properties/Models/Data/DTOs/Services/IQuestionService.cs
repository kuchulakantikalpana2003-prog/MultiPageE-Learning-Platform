using MultiPage_ELearning_Platform1.DTOs.QuestionDTOs;

namespace MultiPage_ELearning_Platform1.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionResponseDto>> GetByQuizAsync(int quizId);

        Task<QuestionResponseDto?> GetByIdAsync(int id);

        Task<QuestionResponseDto> CreateAsync(CreateQuestionDto dto);

        Task<bool> UpdateAsync(int id, CreateQuestionDto dto);

        Task<bool> DeleteAsync(int id);
    }
}