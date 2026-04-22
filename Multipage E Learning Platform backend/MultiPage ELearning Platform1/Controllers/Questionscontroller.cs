using Microsoft.AspNetCore.Mvc;
using MultiPage_ELearning_Platform1.DTOs.QuestionDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;
using System.Linq;

namespace MultiPage_ELearning_Platform1.Controllers
{
    [ApiController]
    [Route("api")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        // GET QUESTIONS BY QUIZ
        [HttpGet("quizzes/{quizId}/questions")]
        public async Task<IActionResult> GetByQuizId(int quizId)
        {
            var questions = await _service.GetByQuizAsync(quizId);

            if (questions == null || !questions.Any())
                return NotFound("No questions found for this quiz.");

            return Ok(questions);
        }

        // GET QUESTION BY ID
        [HttpGet("questions/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var question = await _service.GetByIdAsync(id);

            if (question == null)
                return NotFound();

            return Ok(question);
        }

        // CREATE QUESTION
        [HttpPost("questions")]
        public async Task<IActionResult> Create([FromBody] CreateQuestionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var question = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = question.QuestionId }, question);
        }

        // UPDATE QUESTION
        [HttpPut("questions/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateQuestionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return Ok("Question updated successfully");
        }

        // DELETE QUESTION
        [HttpDelete("questions/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Question deleted successfully");
        }
    }
}