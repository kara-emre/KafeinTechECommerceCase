using Mails.Application.Dtos;
using MassTransit;
using Newtonsoft.Json;

namespace Invoices.Service.Consumers
{
    public class OrderMailConsumer : IConsumer<MailSendDto>
    {
        public OrderMailConsumer()
        {

        }

        public Task Consume(ConsumeContext<MailSendDto> context)
        {
            var mailDetail = context.Message;
            if (mailDetail != null)
            {
                //Mail gönderme işlemleri buradan sonra yapılabilir 
                Console.Out.WriteLineAsync($"Subject : {mailDetail.Subject}");
                Console.Out.WriteLineAsync($"E-Mail : {mailDetail.Email}");
                Console.Out.WriteLineAsync($"Body : {mailDetail.Body}"); 
            }
            return Task.CompletedTask;
        }
    }
}
