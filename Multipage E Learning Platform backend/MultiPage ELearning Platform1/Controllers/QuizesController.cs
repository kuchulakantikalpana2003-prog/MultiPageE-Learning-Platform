using Microsoft.AspNetCore.Mvc;
using MultiPage_ELearning_Platform1.DTOs.QuizDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;
using System.Linq;

namespace MultiPage_ELearning_Platform1.Controllers
{
    [ApiController]
    [Route("api/quizzes")]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _service;

        public QuizzesController(IQuizService service)
        {
            _service = service;
        }

        // GET QUIZZES BY COURSE
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            var quizzes = await _service.GetByCourseAsync(courseId);

            if (quizzes == null || !quizzes.Any())
                return NotFound("No quizzes found for this course.");

            return Ok(quizzes);
        }

        // GET QUIZ BY ID
        [HttpGet("details/{quizId}")]
        public async Task<IActionResult> GetById(int quizId)
        {
            var quiz = await _service.GetQuizWithQuestionsAsync(quizId);

            if (quiz == null)
                return NotFound();

            return Ok(quiz);
        }

        // CREATE QUIZ
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuizDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var quiz = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { quizId = quiz.QuizId }, quiz);
        }

        // UPDATE QUIZ
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateQuizDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return Ok("Quiz updated successfully");
        }

        // DELETE QUIZ
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Quiz deleted successfully");
        }
    }
}
