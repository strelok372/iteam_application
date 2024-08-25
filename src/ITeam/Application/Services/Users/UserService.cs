using ITeam.Application.Services.Exceptions.NotFoundException;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories;
using ITeam.DataAccess.Repositories.Users;
using ITeam.Presentation.DTOs.Users;

namespace ITeam.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IHasher _hasher;

        public UserService(IUsersRepository userRepository, IHasher hasher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
        }

        public async Task<UserDto> RegisterUserAsync(UserRegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var user = new UserEntity
            {
                Email = _hasher.Hash(dto.Email),
                Name = _hasher.Hash(dto.Name),
                Password = _hasher.Hash(dto.Password),
                DateRegistration = DateTime.UtcNow,
                UserTypeId = 1,
                UserStatusId = 1, // Default user status ID
                Balance = 0m
            };

            await _userRepository.AddUserAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Email = dto.Email, // Do not expose hashed email
                Name = dto.Name, // Do not expose hashed name
                DateRegistration = user.DateRegistration,
                UserType = (await _userRepository.GetUserTypeByIdAsync(user.UserTypeId))?.Name ?? "Unknown",
                UserStatus = (await _userRepository.GetUserStatusByIdAsync(user.UserStatusId))?.Name ?? "Unknown",
                Balance = user.Balance
            };
        }
        public async Task<string> AuthenticateUserAsync(UserLoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !_hasher.Verify(dto.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            // Generate and return JWT token or any other authentication token here
            return "GeneratedAuthToken";
        }
        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email, // Be careful with exposing sensitive information
                Name = user.Name,
                DateRegistration = user.DateRegistration,
                UserType = (await _userRepository.GetUserTypeByIdAsync(user.UserTypeId))?.Name ?? "Unknown",
                UserStatus = (await _userRepository.GetUserStatusByIdAsync(user.UserStatusId))?.Name ?? "Unknown",
                Balance = user.Balance
            };
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var userType = await _userRepository.GetUserTypeByIdAsync(user.UserTypeId);
                var userStatus = await _userRepository.GetUserStatusByIdAsync(user.UserStatusId);
                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email, // Expose original email for context
                    Name = user.Name, // Expose original name for context
                    DateRegistration = user.DateRegistration,
                    UserType = userType?.Name ?? "Unknown",
                    UserStatus = userStatus?.Name ?? "Unknown",
                    Balance = user.Balance
                });
            }

            return userDtos;
        }
        public async Task UpdateUserAsync(int userId, UserUpdateDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            if (dto.Email != null)
            {
                user.Email = _hasher.Hash(dto.Email); 
            }

            if (dto.Name != null)
            {
                user.Name = _hasher.Hash(dto.Name); 
            }

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            await _userRepository.DeleteUserAsync(user);
        }
        public async Task ChangePasswordAsync(int userId, UserChangePasswordDto dto)
        {
            // Найти пользователя по ID
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            // Проверка текущего пароля
            if (!_hasher.Verify(dto.CurrentPassword, user.Password))
            {
                throw new UnauthorizedAccessException("Current password is incorrect.");
            }

            // Хэширование и обновление пароля
            user.Password = _hasher.Hash(dto.NewPassword);
            await _userRepository.UpdateUserAsync(user);
        }
        public async Task UpdateUserStatusAsync(UserStatusUpdateDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(dto.UserId);
            if (user == null)
                throw new UserNotFoundException(dto.UserId);

            var status = await _userRepository.GetUserStatusByIdAsync(dto.UserStatusId);
            if (status == null)
                throw new UserStatusNotFoundException(dto.UserStatusId);

            user.UserStatusId = dto.UserStatusId;
            await _userRepository.UpdateUserAsync(user);
        }
        public async Task UpdateUserTypeAsync(UserTypeUpdateDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(dto.UserId);
            if (user == null)
                throw new UserNotFoundException(dto.UserId);

            var status = await _userRepository.GetUserTypeByIdAsync(dto.UserTypeId);
            if (status == null)
                throw new UserTypeNotFoundException(dto.UserTypeId);

            user.UserStatusId = dto.UserTypeId;
            await _userRepository.UpdateUserAsync(user);
        }
        public async Task UpdateUserByAdminAsync(int userId, AdminUpdateUserDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            if (dto.UserTypeId.HasValue)
            {
                var userTypeDto = new UserTypeUpdateDto
                {
                    UserId = userId,
                    UserTypeId = dto.UserTypeId.Value
                };
                await UpdateUserTypeAsync(userTypeDto);
            }
            if (dto.UserStatusId.HasValue)
            {
                var userStatusDto = new UserStatusUpdateDto
                {
                    UserId = userId,
                    UserStatusId = dto.UserStatusId.Value
                };
                await UpdateUserStatusAsync(userStatusDto);
            }

            if (!string.IsNullOrEmpty(dto.Email) || !string.IsNullOrEmpty(dto.Name))
            {
                var userUpdateDto = new UserUpdateDto
                {
                    Email = dto.Email,
                    Name = dto.Name
                };
                await UpdateUserAsync(userId,userUpdateDto);

            }

            await _userRepository.UpdateUserAsync(user);
        }

    }
}
