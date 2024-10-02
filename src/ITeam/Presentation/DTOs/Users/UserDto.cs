namespace ITeam.Presentation.DTOs.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime DateRegistration { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
        public decimal Balance { get; set; }
    }
}
