using Microsoft.AspNetCore.Mvc;
using MultiPage_ELearning_Platform1.DTOs.QuizDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;
using System.Linq;

namespace MultiPage_ELearning_Platform1.Controllers
{
    [ApiController]
    [Route("api/results")]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _service;

        public ResultsController(IResultService service)
        {
            _service = service;
        }

        // GET RESULTS BY USER
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var results = await _service.GetByUserIdAsync(userId);

            if (results == null || !results.Any())
                return NotFound("No results found for this user.");

            return Ok(results);
        }

        // SUBMIT QUIZ
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] SubmitQuizDto dto)
        {
            var result = await _service.SubmitQuizAsync(dto);
            return Ok(result);
        }
    }
}