namespace ResidentialCommunityAssistant.Services.Models.Shop
{
    public class ShoppingCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string ImgURL { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal PricePerQuantity { get; set; }

        public decimal TotalForProduct
        {
            get
            {
                return Math.Round((this.Quantity * this.PricePerQuantity),2);
            }
        } 

    }
}
