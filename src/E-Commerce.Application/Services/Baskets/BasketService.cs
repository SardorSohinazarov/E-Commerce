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

        public async ValueTask DeleteProductFromName(string name, long id)
        {
            var basket = _context.Baskets.Include(x => x.Products).ThenInclude(x => x.Product).FirstOrDefault(x => x.ClientTelegramId == id);
            var product = basket.Products.FirstOrDefault(x => x.Product.Name == name);
            basket.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async ValueTask<Basket> GetBasketAsync(long userTelegramId)
        {
            var basket = await _context.Baskets.Include(x => x.Products).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.ClientTelegramId == userTelegramId);

            if (basket == null)
                throw new Exception("Basket not found");

            return basket;
        }

        public async ValueTask<Basket> UpdateBasketProductsAsync(Product product, int count, long userTelegramId)
        {
            var basket = await _context.Baskets.Include(x => x.Products).FirstOrDefaultAsync(x => x.ClientTelegramId == userTelegramId);

            if (basket == null)
                throw new Exception("Basket not found");

            var productWithCount = new ProductList()
            {
                Count = count,
                ProductId = product.Id,
            };
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

            var entry = _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
