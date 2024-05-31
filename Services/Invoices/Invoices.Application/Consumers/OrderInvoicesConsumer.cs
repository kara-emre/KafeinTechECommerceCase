using Invoices.Application.Dtos;
using Invoices.Application.Interfaces;
using MassTransit;

namespace Invoices.Application.Consumers
{
    public class OrderInvoicesConsumer : IConsumer<OrderInvoiceDto>
    {
        IInvoiceMailPublisher _mailPublisher;
 
        public OrderInvoicesConsumer(IInvoiceMailPublisher mailPublisher)
        {
            _mailPublisher = mailPublisher;
        }

        public OrderInvoicesConsumer()
        {
            // İhtiyaç duyulursa burada başka başlangıç ayarları yapılabilir
        }

        public Task Consume(ConsumeContext<OrderInvoiceDto> context)
        {
            var order = context.Message;
            if (order != null)
            {  
                _mailPublisher.PublishInvoiceMail(order);
            }
            return Task.CompletedTask;
        }

     
    }
}
