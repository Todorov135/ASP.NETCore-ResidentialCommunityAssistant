namespace ResidentialCommunityAssistant.Services.Models.Shop
{    
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImgURL { get; set; } = null!;
                
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
