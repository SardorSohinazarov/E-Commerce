﻿using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data
{
    public class BotDbContext : DbContext, IApplicationDbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<Client> Clients { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<Category> Categories { get; set; }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
            => await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
