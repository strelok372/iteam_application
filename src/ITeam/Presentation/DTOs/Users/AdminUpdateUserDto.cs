namespace ITeam.Presentation.DTOs.Users
{
    public class AdminUpdateUserDto
    {
        public int UserId { get; set; }  
        public string? Name { get; set; } 
        public string? Email { get; set; }  
        public int? UserTypeId { get; set; }  
        public int? UserStatusId { get; set; }
    }
}
