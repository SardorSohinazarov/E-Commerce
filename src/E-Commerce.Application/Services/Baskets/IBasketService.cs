using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Baskets
{
    public interface IBasketService
    {
        public ValueTask<Basket> GetBasketAsync(int userTelegramId);
        public ValueTask<Basket> UpdateBasketProductsAsync(Product product,int count, int userTelegramId);
        public ValueTask<Basket> UpdateBasketStatusAsync(int userTelegramId);
    }
}
