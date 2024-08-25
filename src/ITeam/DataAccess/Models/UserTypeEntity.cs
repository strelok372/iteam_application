namespace ITeam.DataAccess.Models
{
    public class UserTypeEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; }
    }
}
