namespace ITeam.DataAccess.Models
{
    public class OperationTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OperationUsersEntity> Operations { get; set; }
        
    }
}
