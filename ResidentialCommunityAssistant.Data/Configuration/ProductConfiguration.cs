namespace ResidentialCommunityAssistant.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ResidentialCommunityAssistant.Data.Models;
    using System;

    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            IEnumerable<Product> products = SeedProducts();

            builder.HasData(products);
        }

        private List<Product> SeedProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Пиратско знаме",
                    Description = "Ако използвате uTorrent, това е знамето за Вас.",
                    ImgURL = "https://shop.flagfactory.bg/image/cache/catalog/products/flags/pirates/pirates_mockups/pirate2_mockup-600x360.png",
                    Price = 10.00M,
                    Quantity = 100
                },
                new Product()
                {
                    Id = 2,
                    Name = "Саянско знаме",
                    Description = "Желаете да завоювате чужди светове?!? Искате жителите да треперя при Вашето присъствие?!? Станете саян!",
                    ImgURL = "https://external-preview.redd.it/xLN_fXFlM6wM84w_VGkRJut0LqNDug4gs-c66_5zZ9o.jpg?auto=webp&s=3dbf10a8efddb301911796c52fadba948206fdbf",
                    Price = 100.00M,
                    Quantity = 100
                },
                new Product()
                {
                    Id = 3,
                    Name = "Planet express знаме",
                    Description = "Покажи на живущите, че си бъдещ доставчик!",
                    ImgURL = "https://e7.pngegg.com/pngimages/407/294/png-clipart-planet-express-ship-bender-t-shirt-professor-farnsworth-bender-television-logo.png",
                    Price = 12.00M,
                    Quantity = 100
                }
            };

            return products;
        }
    }
}
