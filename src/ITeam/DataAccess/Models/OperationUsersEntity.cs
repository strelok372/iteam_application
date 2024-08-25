namespace ITeam.DataAccess.Models
{
    public class OperationUsersEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationTypeId { get; set; }
        public decimal Amount { get; set; }
        public int? ProductId { get; set; }
        public DateTime OperationDate { get; set; }

        public UserEntity User { get; set; }
        public OperationTypeEntity OperationType { get; set; }        
    }
}
