using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Orders
{
    public interface IOrderService
    {
        ValueTask<Order> AddOrderAsync(Order order);
    }
}
