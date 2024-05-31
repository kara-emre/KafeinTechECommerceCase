using MediatR;
using Orders.Application.Reponses;
using System.Text.Json.Serialization;

namespace Orders.Application.Commands
{
    public class CreateOrderCommand : IRequest<CreatedOrderResponse>
    {
        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public string Address { get; set; } = string.Empty;

        [JsonIgnore]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public string EMail { get; set; } = string.Empty;

        public List<OrderProduct> Products { get; set; } = new();
    }
}

  
