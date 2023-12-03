using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Branches
{
    public class BranchService : IBranchService
    {
        private readonly IApplicationDbContext _context;

        public BranchService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Branch> AddBranchAsync(Branch branch)
        {
            var entry = await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();

            return entry.Entity;

        }

        public async ValueTask<Branch> DeleteBranchAsync(int id)
        {
            var storageBranch = await _context.Branches.FirstOrDefaultAsync(x => x.Id == id);
            if (storageBranch != null)
            {
                throw new Exception("Branch not found");
            }

            var entry = _context.Branches.Remove(storageBranch);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<List<Branch>> GetBranchesAsync()
        {
            var branches = await _context.Branches.ToListAsync();

            return branches;
        }

        public async ValueTask<Branch> GetBranchFromNameAsync(string name)
        {
            var branche = await _context.Branches.FirstOrDefaultAsync(x => x.Name == name);

            if (branche == null)
                throw new Exception("Branch not found");

            return branche;
        }
    }
}
