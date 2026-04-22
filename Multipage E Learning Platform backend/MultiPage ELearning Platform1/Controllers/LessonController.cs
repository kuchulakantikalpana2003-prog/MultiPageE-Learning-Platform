using Microsoft.AspNetCore.Mvc;
using MultiPage_ELearning_Platform1.DTOs.LessonDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;
using System.Linq;

namespace MultiPage_ELearning_Platform1.Controllers
{
    [ApiController]
    [Route("api")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonsController(ILessonService service)
        {
            _service = service;
        }

        // GET LESSONS BY COURSE
        [HttpGet("courses/{courseId}/lessons")]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            var lessons = await _service.GetByCourseAsync(courseId);

            if (lessons == null || !lessons.Any())
                return NotFound("No lessons found for this course.");

            return Ok(lessons);
        }

        // GET LESSON BY ID ✅ FIXED
        [HttpGet("lessons/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lesson = await _service.GetByIdAsync(id);

            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }

        // CREATE LESSON
        [HttpPost("lessons")]
        public async Task<IActionResult> Create([FromBody] CreateLessonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lesson = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = lesson.LessonId }, lesson);
        }

        // UPDATE LESSON ✅ FIXED
        [HttpPut("lessons/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLessonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return Ok("Lesson updated successfully");
        }

        // DELETE LESSON
        [HttpDelete("lessons/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Lesson deleted successfully");
        }
    }
}