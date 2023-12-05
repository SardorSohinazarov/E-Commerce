using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.ProductLists
{
    public interface IProductListService
    {
        ValueTask<ProductList> AddProductListAsync(ProductList productList);
        ValueTask<ProductList> UpdateProductListAsync(int count,long userTelegramId);
    }
}
