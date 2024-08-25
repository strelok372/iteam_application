namespace ITeam.DataAccess.Models
{
    public class UserEntity
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime DateRegistration { get; set; }
        public int UserTypeId { get; set; }
        public UserTypeEntity UserType { get; set; }    
        public decimal Balance { get; set; }
        public int UserStatusId { get; set; }
        public UserStatusEntity UserStatus{ get; set; }

        public ICollection<OperationUsersEntity> Operations { get; set; }
    }
}
