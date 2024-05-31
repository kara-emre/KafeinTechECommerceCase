using Invoices.Service;
using Invoices.Service.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddInvoiceWorker();

//builder.Services.AddSingleton<IHostedService, Worker>();

var host = builder.Build();


host.Run();
