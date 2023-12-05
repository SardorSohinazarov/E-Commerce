using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Choy",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Kabob",
                },
                new Category()
                {
                    Id = 3,
                    Name = "Non",
                },
                new Category()
                {
                    Id = 4,
                    Name = "Shorva",
                },
                new Category()
                {
                    Id = 5,
                    Name = "Lag'mon",
                },
                new Category()
                {
                    Id = 6,
                    Name = "Osh",
                },
                new Category()
                {
                    Id = 7,
                    Name = "Lavash",
                },
                new Category()
                {
                    Id = 8,
                    Name = "Pitsa",
                },
                new Category()
                {
                    Id = 9,
                    Name = "Somsa",
                },
                new Category()
                {
                    Id = 10,
                    Name = "Gazli ichimlik",
                },
                new Category()
                {
                    Id = 11,
                    Name = "Salat",
                },
                new Category()
                {
                    Id = 12,
                    Name = "Meva",
                },
            });
        }
    }
}
