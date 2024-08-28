namespace ITeam.DataAccess.Models
{
    public class UserPurchaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OperationId {  get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
