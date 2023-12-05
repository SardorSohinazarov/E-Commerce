using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Products
{
    public interface IProductService
    {
        public ValueTask<Product> GetByNameAsync(string name);
        public ValueTask<List<Product>> GetProductsAsync();
    }
}
