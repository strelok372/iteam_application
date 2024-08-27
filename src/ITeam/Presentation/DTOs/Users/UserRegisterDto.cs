using Humanizer;
using System.ComponentModel.DataAnnotations;
using ITeam.Application;


namespace ITeam.Presentation.DTOs.Users
{
    public class UserRegisterDto
    {
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Validate(Application.Validator _validator)
        {

            if (!_validator.ValidateName(Name))
            {
                return "Имя должно содержать только буквы и пробелы.";
            }

            if (!_validator.ValidateEmail(Email))
            {
                return "Некорректный формат электронной почты.";
            }

            if (!_validator.ValidatePassword(Password))
            {
                return "Пароль должен содержать хотя бы одну букву и одну цифру, а так же содержать минимум 8 символов.";
            }
            return null;
        }
     
    }
}
