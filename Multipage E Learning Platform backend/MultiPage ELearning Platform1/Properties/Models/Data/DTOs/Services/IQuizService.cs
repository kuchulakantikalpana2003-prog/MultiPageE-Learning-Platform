using MultiPage_ELearning_Platform1.DTOs.QuizDTOs;
using MultiPage_ELearning_Platform1.Models;

namespace MultiPage_ELearning_Platform1.Services.Interfaces
{
    public interface IQuizService
    {
        Task<QuizResponseDto> CreateAsync(CreateQuizDto dto);

        Task<List<QuizResponseDto>> GetByCourseAsync(int courseId);

        Task<object> GetQuizWithQuestionsAsync(int quizId);

        Task<bool> UpdateAsync(int id, CreateQuizDto dto);

        Task<bool> DeleteAsync(int id);
    }
}

