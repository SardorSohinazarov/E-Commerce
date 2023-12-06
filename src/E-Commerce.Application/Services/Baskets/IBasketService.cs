using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Baskets
{
    public interface IBasketService
    {
        public ValueTask<Basket> GetBasketAsync(long userTelegramId);
        public ValueTask<Basket> UpdateBasketProductsAsync(Product product, int count, long userTelegramId);
        public ValueTask<Basket> UpdateBasketStatusAsync(int userTelegramId);
        public ValueTask DeleteProductFromName(string name, long id);
    }
}
