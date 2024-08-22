namespace ITeam.DataAccess.Models
{
    public class OperationType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OperationUsers> Operations { get; set; }
        
    }
}
