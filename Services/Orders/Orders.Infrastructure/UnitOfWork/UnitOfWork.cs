using Orders.Application.Interfaces;
using Orders.Infrastructure.Data;

namespace Orders.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrdersContext _context;
        public IOrderRepository Orders { get; }

        public UnitOfWork(OrdersContext context, IOrderRepository orders)
        {
            _context = context;
            Orders = orders;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        } 

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
