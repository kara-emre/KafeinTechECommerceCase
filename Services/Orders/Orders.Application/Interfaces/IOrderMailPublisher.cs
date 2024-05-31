using Orders.Application.Dtos;

namespace Orders.Application.Interfaces
{
    public interface IOrderMailPublisher
    {
        Task PublishOrderRecivedMail(OrderDto orderDto);
    }
}
