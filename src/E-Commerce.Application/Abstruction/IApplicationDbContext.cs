using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Abstruction
{
    public interface IApplicationDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
