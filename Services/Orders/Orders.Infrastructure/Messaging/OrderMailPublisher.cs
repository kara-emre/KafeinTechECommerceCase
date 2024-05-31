using Invoices.Application.Interfaces;
using Mails.Application.Dtos;
using MassTransit;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;

namespace Orders.Infrastructure.Messaging
{
    public class OrderMailPublisher : IOrderMailPublisher
    {
        private readonly IBus _bus; 

        public OrderMailPublisher(IBus bus)
        {
            _bus = bus; 
        }

        public async Task PublishOrderRecivedMail(OrderDto orderDto)
        {
            var mailDto = new MailSendDto
            {
                Subject = "Order Received",
                Body = Helper.OrderContent.Create(orderDto),
                Email = orderDto.EMail
            };

            await _bus.Publish(mailDto, context =>
            {
                context.SetRoutingKey("MailQueue");
            });
        }
    }
}
