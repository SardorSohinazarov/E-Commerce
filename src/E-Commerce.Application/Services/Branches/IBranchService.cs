using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Branches
{
    public interface IBranchService
    {
        ValueTask<Branch> AddBranchAsync(Branch branch);
        ValueTask<List<Branch>> GetBranchesAsync();
        ValueTask<Branch> DeleteBranchAsync(int id);
        ValueTask<Branch> GetBranchFromNameAsync(string name);
    }
}
