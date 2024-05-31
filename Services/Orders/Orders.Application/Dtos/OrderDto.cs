using System.Text.Json.Serialization;

namespace Orders.Application.Dtos
{
    public class OrderDto
    {
        public int UserId { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string EMail { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public List<ProductDto> Products { get; set; } = new();
    }
}
