using Orders.Application.Dtos;

namespace Orders.Application.Interfaces
{
    public interface IOrderInvoicePublisher
    {
        Task PublishOrderInvoice(OrderDto order);
    }
}
