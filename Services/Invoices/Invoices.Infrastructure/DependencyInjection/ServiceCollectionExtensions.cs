using Invoices.Application.Consumers;
using Invoices.Application.Dtos;
using Invoices.Application.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Orders.Infrastructure.Messaging;

namespace Invoices.Service.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInvoiceWorker(this IServiceCollection services)
        {
           
            services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderInvoicesConsumer>(); // Tüketiciyi ekliyoruz

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("InvoiceQueue", ep =>
                    {
                        ep.Bind<OrderInvoiceDto>(); // Gelen mesaj tipini belirtiyoruz
                        ep.ConfigureConsumer<OrderInvoicesConsumer>(context);
                    });
                });
            });

            services.AddTransient<IInvoiceMailPublisher, InvoiceMailPublisher>();

            return services;
        }
    }
}
