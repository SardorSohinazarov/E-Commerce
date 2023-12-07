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

                //kabob
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
                    Price = 15000
                },


                //non
                 new Product()
                {
                    Id = 6,
                    Description = "Juda shirin va mazali",
                    Name = "Qo'qon Patir",
                    CategoryId = 3,
                    ImagePath = "https://api.online-bozor.uz/uploads/images/ff80818144829954794c12d7",
                    Price = 10000
                },
                new Product()
                {
                    Id = 7,
                    Description = "Juda shirin va mazali",
                    Name = "Buxanka",
                    CategoryId = 3,
                    ImagePath = "https://storage.kun.uz/source/1/ssEjJUu1uNZtl84wFUwb11XwDH3wT1l0.jpg",
                    Price = 2800
                },

                //shorva
                 new Product()
                {
                    Id = 8,
                    Description = "Juda shirin va mazali",
                    Name = "Tovuq shorva",
                    CategoryId = 4,
                    ImagePath = "https://i2.wp.com/attuale.ru/wp-content/uploads/2018/02/50270956-391b-4308-b21d-882911a30634_original.jpg",
                    Price = 18000
                },
                new Product()
                {
                    Id = 9,
                    Description = "Juda shirin va mazali",
                    Name = "Noxat shorva",
                    CategoryId = 4,
                    ImagePath = "https://www.ferganatourism.uz/d/bd72b97a.jpg",
                    Price = 16000
                },
                
                //lag'mon
                new Product()
                {
                    Id = 10,
                    Description = "Juda shirin va mazali",
                    Name = "Qovurma lag'mon",
                    CategoryId = 5,
                    ImagePath = "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg",
                    Price = 14000
                },

                //osh
                new Product()
                {
                    Id = 11,
                    Description = "Juda shirin va mazali",
                    Name = "Choyxona palov",
                    CategoryId = 6,
                    ImagePath = "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg",
                    Price = 25000
                },
                new Product()
                {
                    Id = 12,
                    Description = "Juda shirin va mazali",
                    Name = "To'y oshi",
                    CategoryId = 6,
                    ImagePath = "https://pazanda.com/wp-content/uploads/2017/02/img_4051.jpg",
                    Price = 25000
                },
            });
        }
    }
}
