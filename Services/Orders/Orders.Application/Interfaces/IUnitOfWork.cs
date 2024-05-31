using Orders.Application.Interfaces;

namespace Orders.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        Task<int> CompleteAsync();
    }
}
