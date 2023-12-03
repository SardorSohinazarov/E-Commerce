using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data
{
    public class BotDbContext:DbContext, IApplicationDbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<Client> Clients { get; set; }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
            => await base.SaveChangesAsync(cancellationToken);
    }
}
