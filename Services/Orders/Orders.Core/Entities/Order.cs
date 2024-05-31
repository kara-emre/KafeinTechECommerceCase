namespace Orders.Core.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public string Address { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }  
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
