namespace ResidentialCommunityAssistant.Services.Models.Shop.ShopManager
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class ProductOverviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImgURL { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
