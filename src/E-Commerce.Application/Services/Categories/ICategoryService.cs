using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Categories
{
    public interface ICategoryService
    {
        ValueTask<List<Category>> GetAllCategoriesAsync();
        ValueTask<Category> GetCategoryByNameAsync(string name);
    }
}
