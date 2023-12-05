using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicationDbContext _context;

        public CategoryService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async ValueTask<Category> GetCategoryByNameAsync(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);

            if (category == null)
                throw new Exception("Category not found");

            return category;
        }
    }
}
