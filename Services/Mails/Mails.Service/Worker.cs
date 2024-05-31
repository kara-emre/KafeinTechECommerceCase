using MassTransit;

namespace Mails.Service
{
    public class Worker : BackgroundService
    {
        private readonly IBusControl _bus;

        public Worker(IBusControl bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.StartAsync(stoppingToken);
            stoppingToken.Register(() => _bus.StopAsync(CancellationToken.None).GetAwaiter().GetResult());
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _bus.StopAsync(cancellationToken);
            await base.StopAsync(cancellationToken);
        }
    }
}
