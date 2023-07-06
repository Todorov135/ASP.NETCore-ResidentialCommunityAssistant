namespace ResidentialCommunityAssistant.Services.Services.Shop
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Shop;
    using ResidentialCommunityAssistant.Services.Models.Shop;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShopService : IShopService
    {
        private readonly CommunityAssistantDBContext data;

        public ShopService(CommunityAssistantDBContext data)
        {
            this.data = data;
        }        

        public async Task<ICollection<ProductViewModel>> GetAllProductsAsync()
        {
            return await this.data.Products
                                  .Select(p => new ProductViewModel()
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Description = p.Description,
                                      ImgURL = p.ImgURL,
                                      Price = p.Price,
                                      Quantity = p.Quantity
                                  })
                                  .ToListAsync();
        }
    }
}
