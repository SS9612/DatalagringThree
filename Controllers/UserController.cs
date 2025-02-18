using Buisness.Services;
using Buisness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ConsoleApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegistrationForm form)
        {
            if (form == null || string.IsNullOrWhiteSpace(form.Firstname) || string.IsNullOrWhiteSpace(form.Lastname) || string.IsNullOrWhiteSpace(form.Email))
            {
                return BadRequest("Invalid user data.");
            }

            await _userService.CreateUserAsync(form);
            return CreatedAtAction(nameof(GetUserById), new { id = form.Email }, form);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || string.IsNullOrWhiteSpace(updatedUser.Firstname) || string.IsNullOrWhiteSpace(updatedUser.Lastname) || string.IsNullOrWhiteSpace(updatedUser.Email))
            {
                return BadRequest("Invalid user data.");
            }

            updatedUser.Id = id;
            var success = await _userService.UpdateUserAsync(updatedUser);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return Ok("User updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return Ok("User deleted successfully!");
        }
    }
}
