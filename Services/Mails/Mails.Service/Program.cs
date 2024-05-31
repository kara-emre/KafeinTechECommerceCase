using Invoices.Service.Extansions;
using Mails.Service;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();


builder.Services.AddMailWorker();

var host = builder.Build();

host.Run();
