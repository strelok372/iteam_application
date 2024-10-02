namespace ITeam.Presentation.DTOs.Users
{
    public class AdminUpdateUserDto
    {
        public string? Name { get; set; } 
        public string? Email { get; set; }  
        public int? UserTypeId { get; set; }  
        public int? UserStatusId { get; set; }
    }
}
