using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Baskets
{
    public class BasketService : IBasketService
    {
        private readonly IApplicationDbContext _context;

        public BasketService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Basket> GetBasketAsync(int userTelegramId)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(x => x.ClientTelegramId == userTelegramId);

            if (basket == null)
                throw new Exception("Basket not found");

            return basket;
        }

        public async ValueTask<Basket> UpdateBasketProductsAsync(Product product, int count, int userTelegramId)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(x => x.ClientTelegramId == userTelegramId);

            if (basket == null)
                throw new Exception("Basket not found");

            var productWithCount = new Tuple<int, Product>(count,product);
            basket.Products.Add(productWithCount);
            var entry = _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Basket> UpdateBasketStatusAsync(int userTelegramId)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(x => x.ClientTelegramId == userTelegramId);

            if (basket == null)
                throw new Exception("Basket not found");

            basket.IsActive = false;
            var entry = _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
