namespace ITeam.DataAccess.Models
{
    public class UserStatusEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; }
    }
}
