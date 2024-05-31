using Invoices.Service.Consumers;
using Mails.Service;
using MassTransit;

namespace Invoices.Service.Extansions
{
    public static class WorkerExtensions
    {
        public static IServiceCollection AddMailWorker(this IServiceCollection services)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("MailQueue", ep =>
                {
                    ep.Consumer<OrderMailConsumer>();
                });
            });

            services.AddSingleton(bus);
            services.AddSingleton<IHostedService, Worker>();

            return services;
        }
    }
}
