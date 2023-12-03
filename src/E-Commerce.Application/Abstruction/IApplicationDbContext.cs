using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Abstruction
{
    public interface IApplicationDbContext
    {
        public DbSet<Client> Clients { get; }
        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
