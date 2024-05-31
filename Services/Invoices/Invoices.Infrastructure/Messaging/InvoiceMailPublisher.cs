using Invoices.Application.Dtos;
using Invoices.Application.Interfaces;
using Invoices.Infrastructure.Helper;
using Mails.Application.Dtos;
using MassTransit; 

namespace Orders.Infrastructure.Messaging
{
    public class InvoiceMailPublisher : IInvoiceMailPublisher
    {
        private readonly IBus _bus;

        public InvoiceMailPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishInvoiceMail(OrderInvoiceDto orderDto)
        {
            await Console.Out.WriteLineAsync("PublishInvoiceMail");
            var mailDto = new MailSendDto
            {
                Subject = "Invoice Ready",
                Body = InvoiceContent.Builder(orderDto),
                Email = orderDto.Email
            };

            await _bus.Publish(mailDto, context =>
            {
                context.SetRoutingKey("MailQueue");
            });
        }
    }
}
