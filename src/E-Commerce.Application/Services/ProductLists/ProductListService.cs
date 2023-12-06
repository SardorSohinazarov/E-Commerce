using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.ProductLists
{
    public class ProductListService : IProductListService
    {
        private readonly IApplicationDbContext _context;

        public ProductListService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<ProductList> AddProductListAsync(ProductList productList)
        {
            var entry = await _context.ProductLists.AddAsync(productList);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<ProductList> UpdateProductListAsync(int count, long userTelegramId)
        {
            var productList = await _context.ProductLists.FirstOrDefaultAsync(x => x.UserTelegramId == userTelegramId && x.Count == null);

            if (productList == null)
                throw new Exception("ProductList not found");

            productList.Count = count;
            await _context.SaveChangesAsync();
            var entry = _context.ProductLists.Update(productList);

            return entry.Entity;
        }
    }
}
