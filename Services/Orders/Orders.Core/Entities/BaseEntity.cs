namespace Orders.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; } 
        public DateTime CreatedTime { get; set; }
        public bool SoftDelete { get; set; }
    }
}
