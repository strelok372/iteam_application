using ITeam.Application.Services.Exceptions;
using ITeam.Application.Services.Exceptions.NotFoundException;
using ITeam.Application.Services.Users;
using ITeam.Presentation.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITeam.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;
                
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("{userId}")]
        [Authorize]
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

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUserAsync([FromBody] UserRegisterDto dto)
        {
            try
            {
                var user = await _userService.RegisterUserAsync(dto);
                return CreatedAtAction(nameof(GetUserAsync), new { userId = user.Id }, user);
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
        [Authorize]
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
        [Authorize]
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

        [HttpPatch("{userId}/type")]
        [Authorize(Roles = "Admin")]
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

        [HttpPatch("{userId}/type")]
        [Authorize(Roles = "Admin")]
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
        
        [HttpPut("{userId}")]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
