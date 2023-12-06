using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _context;

        public OrderService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Order> AddOrderAsync(Order order)
        {
            var entry = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
