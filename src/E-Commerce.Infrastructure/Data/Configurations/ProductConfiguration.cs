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
                    ImagePath = "https://idsb.tmgrup.com.tr/ly/uploads/images/2022/05/15/205578.jpg",
                    Price = 20000
                },
                new Product()
                {
                    Id = 2,
                    Description = "O'rta narxdagi choy",
                    Name = "Xitoy choylari",
                    CategoryId = 1,
                    ImagePath = "https://domf5oio6qrcr.cloudfront.net/medialibrary/8468/Tea.jpg",
                    Price = 10000
                },
                new Product()
                {
                    Id = 3,
                    Description = "Arzon choy",
                    Name = "Hindiston choylari",
                    CategoryId = 1,
                    ImagePath = "https://realfood.tesco.com/media/images/178-Chaispicedtea-H-efb63a82-e983-4d3c-9e3d-cb799a6f0418-0-472x310.jpg",
                    Price = 5000
                },


                 new Product()
                {
                    Id = 4,
                    Description = "Daxshat kabob",
                    Name = "Tovuqli kabob",
                    CategoryId = 2,
                    ImagePath = "https://1.bp.blogspot.com/-xRoG8l4BZK8/XfasALaj1QI/AAAAAAAAPVI/RImASf05UKAvC7uwZsXsl9vERmS2W7zCwCNcBGAsYHQ/s1600/Chicken%2BKabob.JPG",
                    Price = 13000
                },
                new Product()
                {
                    Id = 5,
                    Description = "Ajoyib kabob",
                    Name = "Go'shtli kabob",
                    CategoryId = 2,
                    ImagePath = "https://foodiesterminal.com/wp-content/uploads/2019/11/chicken-angara-kabab-2-679x1024.jpg",
                    Price = 2
                },
            });
        }
    }
}
