using Invoices.Application.Dtos;
using MassTransit;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;

namespace Orders.Infrastructure.Messaging
{
    public class OrderInvoicePublisher : IOrderInvoicePublisher
    {
        private readonly IBus _bus;

        public OrderInvoicePublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishOrderInvoice(OrderDto order)
        {
            var invoiceDto = new OrderInvoiceDto
            {
                Products = order.Products.Select(p => new ProductInvoiceDto
                {
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Price = p.Price
                }).ToList(),
                Address = order.Address,
                Email = order.EMail,
                Name = order.Name,
                OrderId = order.OrderId
            };

            await _bus.Publish(invoiceDto, context =>
            {
                context.SetRoutingKey("InvoiceQueue");
            });
        }
    }
}
