using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Handlers;
using Orders.Application.Interfaces;
using Orders.Application.Mappers;
using Orders.Application.Validation;
using Orders.Infrastructure.Data;
using Orders.Infrastructure.Messaging;
using Orders.Infrastructure.Repositories;

namespace Orders.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(mass =>
            {
                mass.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddDbContext<OrdersContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //services.AddMassTransitHostedService();
            services.AddTransient<IOrderInvoicePublisher, OrderInvoicePublisher>();
            services.AddTransient<IOrderMailPublisher, OrderMailPublisher>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            #region FluentValidation Configuration

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            #endregion

            #region AutMapper Configuration
            services.AddAutoMapper(typeof(OrderMappingProfile));
            #endregion

            #region MediatR Configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateOrderCommandHandler>());
            services.AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();

            #endregion

            return services;
        }
    }
}
