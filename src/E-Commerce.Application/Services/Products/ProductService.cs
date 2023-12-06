using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Products
{
    public class ProductService:IProductService
    {
        private readonly IApplicationDbContext _context;

        public ProductService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Product> GetByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == name);

            if (product == null)
                throw new Exception("Product Not Found");

            return product;
        }
        
        public async ValueTask<List<Product>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
        
        public async ValueTask<List<string>> GetProductNamesAsync()
        {
            var products = await _context.Products.Select(x => x.Name).ToListAsync();

            return products;
        }
        
        public async ValueTask<List<string>> GetProductNamesByCategoryAsync(string category)
        {
            var products = await _context.Products.Where(x => x.Category.Name == category).Select(x => x.Name).ToListAsync();

            return products;
        }
    }
}
