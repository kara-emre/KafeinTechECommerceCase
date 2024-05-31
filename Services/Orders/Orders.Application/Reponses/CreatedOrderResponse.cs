using Orders.Application.Dtos;
using Orders.Application.Responses;

namespace Orders.Application.Reponses
{
    public class CreatedOrderResponse : BaseResponse
    {
        public OrderDto Order { get; set; } = new OrderDto();

        public decimal Total
        {
            get
            {
                return Order.Products.Sum(x => x.Price * x.Quantity);
            }
        }
    }


}
