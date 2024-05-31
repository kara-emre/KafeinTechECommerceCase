using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Orders.Application.Interfaces;
using Orders.Core.Entities;
using Orders.Infrastructure.Data;

namespace Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OrdersContext _context;
        public OrderRepository(OrdersContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            EntityEntry<Order> result = await _context.Orders.AddAsync(order);

            // OrderItem'ları ve ilişkili Product bilgilerini doldurun
            foreach (var orderItem in result.Entity.OrderItems)
            {
                orderItem.Product = await _context.Products.Where(x => x.Id == orderItem.ProductId).FirstAsync();
            }

            return result.Entity;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders.Where(x => x.Id == id).FirstAsync();
        }
    }
}
