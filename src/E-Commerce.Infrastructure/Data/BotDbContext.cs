using E_Commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data
{
    public class BotDbContext:DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=E-CommerceBotDb;");
        }
    }
}
