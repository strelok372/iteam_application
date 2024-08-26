using ITeam.Application;
using ITeam.Application.Services.Exceptions;
using ITeam.Application.Services.Exceptions.NotFoundException;
using ITeam.Application.Services.Users;
using ITeam.Presentation.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITeam.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Validator _validator;

        public UserController(IUserService userService, Validator validator) { 
            _userService = userService;
            _validator = validator;
        }
              


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("AuthorizeId/{userId}")]
        //[Authorize]
        public async Task<ActionResult<UserDto>> GetUserAsync(int userId)
        {
            try
            {
                return Ok(await _userService.GetUserByIdAsync(userId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _userService.GetUserByIdAsync(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUserAsync([FromBody] UserRegisterDto dto)
        {
            try
            {
                if (!_validator.ValidateName(dto.Name))
                {
                    return BadRequest("Имя должно содержать только буквы и пробелы.");
                }

                if (!_validator.ValidateEmail(dto.Email))
                {
                    return BadRequest("Некорректный формат электронной почты.");
                }

                if (!_validator.ValidatePassword(dto.Password))
                {
                    return BadRequest("Пароль должен содержать хотя бы одну букву и одну цифру, а так же содержать минимум 8 символов.");
                }
                var user = await _userService.RegisterUserAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] UserLoginDto dto)
        {
            try
            {
                var token = await _userService.AuthenticateUserAsync(dto);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPatch("change-password")]
        //[Authorize]
        public async Task<ActionResult> ChangePasswordAsync(int userId, [FromBody] UserChangePasswordDto dto)
        {
            try
            {
                await _userService.ChangePasswordAsync(userId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userId}")]
        //[Authorize]
        public async Task<ActionResult> UpdateUserAsync(int userId, [FromBody] UserUpdateDto dto)
        {
            try
            {
                await _userService.UpdateUserAsync(userId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("type")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateUserTypeAsync([FromBody] UserTypeUpdateDto dto)
        {
            try
            {
                await _userService.UpdateUserTypeAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("status")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateUserStatusAsync([FromBody] UserStatusUpdateDto dto)
        {
            try
            {
                await _userService.UpdateUserStatusAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("admin")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateUserByAdminAsync(int userId, [FromBody] AdminUpdateUserDto adminUpdateDto)
        {
            try
            {
                await _userService.UpdateUserByAdminAsync(userId, adminUpdateDto);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserAsync(int userId)
        {
            try
            {
                await _userService.DeleteUserAsync(userId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
