using Microsoft.AspNetCore.Mvc;
using MultiPage_ELearning_Platform1.DTOs.UserDTOs;
using MultiPage_ELearning_Platform1.Services.Interfaces;

namespace MultiPage_ELearning_Platform1.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // =========================
        // REGISTER USER
        // =========================
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            // ✅ Validation check
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _service.RegisterAsync(dto);

            // ✅ Return 201 Created
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        // =========================
        // GET USER BY ID
        // =========================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // ✅ Validation
            if (id <= 0)
                return BadRequest("Invalid user ID");

            var user = await _service.GetByIdAsync(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // =========================
        // UPDATE USER
        // =========================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            // ✅ Validation
            if (id <= 0)
                return BadRequest("Invalid user ID");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound("User not found");

            return Ok("User updated successfully");
        }
    }
}