using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasData(new List<Product>
            {
                //tea
                new Product()
                {
                    Id = 1,
                    Description = "Qimmat choy",
                    Name = "Turkiya choylari",
                    CategoryId = 1,
                    ImagePath = "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\turkiya-choyi.jpg",
                    Price = 20000
                },
                new Product()
                {
                    Id = 2,
                    Description = "O'rta narxdagi choy",
                    Name = "Xitoy choylari",
                    CategoryId = 1,
                    ImagePath = "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\china-tea.jpg",
                    Price = 10000
                },
                new Product()
                {
                    Id = 3,
                    Description = "Arzon choy",
                    Name = "Hindiston choylari",
                    CategoryId = 1,
                    ImagePath = "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\Indian-tea.jpg",
                    Price = 5000
                },


                 new Product()
                {
                    Id = 4,
                    Description = "Daxshat kabob",
                    Name = "Tovuqli kabob",
                    CategoryId = 2,
                    ImagePath = "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\tovuq-kabob.jpg",
                    Price = 13000
                },
                new Product()
                {
                    Id = 5,
                    Description = "Ajoyib kabob",
                    Name = "Go'shtli kabob",
                    CategoryId = 2,
                    ImagePath = "D:\\Projects\\E-Commerce\\src\\E-Commerce.Bot\\wwwroot\\products\\go'shtli-kabob.jpg",
                    Price = 2
                },
            });
        }
    }
}
