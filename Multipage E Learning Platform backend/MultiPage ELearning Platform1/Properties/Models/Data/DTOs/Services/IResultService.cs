using MultiPage_ELearning_Platform1.DTOs.ResultDTOs;
using MultiPage_ELearning_Platform1.DTOs.QuizDTOs;

public interface IResultService
{
    Task<List<ResultResponseDto>> GetByUserIdAsync(int userId);
    Task<ResultResponseDto> SubmitQuizAsync(SubmitQuizDto dto);
}