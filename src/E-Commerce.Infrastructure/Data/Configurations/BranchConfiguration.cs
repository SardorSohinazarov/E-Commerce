using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Data.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasData(new List<Branch>()
            {
                new Branch {
                    Id = 1,
                    Name = "Kukcha",
                    Longitude = 50,
                    Latitude = 60,
                    Description = "Ajoyib filialimiz"
                },
                new Branch {
                    Id = 2,
                    Name = "Chilonzor",
                    Longitude = 56,
                    Latitude = 61,
                    Description = "Bu ham juda ajoyib filial"
                }
            });
        }
    }
}
