﻿using ITeam.Presentation.DTOs.Users;

namespace ITeam.Application.Services.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Получить информацию о пользователе по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Информация о пользователе</returns>
        Task<UserDto> GetUserByIdAsync(int userId);

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="dto">Данные для регистрации пользователя</param>
        /// <returns>Зарегистрированный пользователь</returns>
        Task<UserDto> RegisterUserAsync(UserRegisterDto dto);

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="dto">Данные для аутентификации пользователя</param>
        /// <returns>Токен доступа при успешной аутентификации</returns>
        Task<string> AuthenticateUserAsync(UserLoginDto dto);

    
        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="dto">Данные для обновления пользователя</param>
        /// <returns>Обновленный пользователь</returns>
        Task<UserDto> UpdateUserAsync(UserUpdateDto dto);

        /// <summary>
        /// Смена пароля пользователя
        /// </summary>
        /// <param name="dto">Данные для смены пароля</param>
        /// <returns></returns>
        Task ChangePasswordAsync(UserChangePasswordDto dto);

        /// <summary>
        /// Изменение статуса пользователя (например, блокировка)
        /// </summary>
        /// <param name="dto">Данные для обновления статуса пользователя</param>
        /// <returns></returns>
        Task UpdateUserStatusAsync(UserStatusUpdateDto dto);

        /// <summary>
        /// Изменение типа пользователя (например, повышение до администратора)
        /// </summary>
        /// <param name="dto">Данные для обновления типа пользователя</param>
        /// <returns></returns>
        Task UpdateUserTypeAsync(UserTypeUpdateDto dto);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task DeleteUserAsync(int userId);
    }

}
