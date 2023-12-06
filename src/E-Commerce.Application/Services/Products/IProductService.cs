using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Products
{
    public interface IProductService
    {
        public ValueTask<Product> GetByNameAsync(string name);
        public ValueTask<List<Product>> GetProductsAsync();
        public ValueTask<List<string>> GetProductNamesAsync();
        public ValueTask<List<string>> GetProductNamesByCategoryAsync(string category);
    }
}
