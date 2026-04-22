using Microsoft.AspNetCore.Mvc;
using MultiPage_ELearning_Platform1.DTOs.CourseDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;

namespace MultiPage_ELearning_Platform1.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        // GET ALL COURSES
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _service.GetAllAsync();
            return Ok(courses);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _service.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // CREATE COURSE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseDto dto)   // ✅ FIXED
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = course.CourseId }, course);
        }

        // UPDATE COURSE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseDto dto)   // ✅ FIXED
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return Ok("Course updated successfully");
        }

        // DELETE COURSE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Course deleted successfully");
        }
    }
}