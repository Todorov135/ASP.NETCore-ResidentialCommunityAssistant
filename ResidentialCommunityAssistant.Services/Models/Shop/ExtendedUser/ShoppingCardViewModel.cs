namespace ResidentialCommunityAssistant.Services.Models.Shop.ExtendedUser
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
                return Math.Round(Quantity * PricePerQuantity, 2);
            }
        }

    }
}
