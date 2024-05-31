using Orders.Core.Entities;

namespace Orders.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
    }
}
