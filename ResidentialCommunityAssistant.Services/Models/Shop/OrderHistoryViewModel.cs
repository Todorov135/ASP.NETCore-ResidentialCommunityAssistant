namespace ResidentialCommunityAssistant.Services.Models.Shop
{
    public class OrderHistoryViewModel
    {
        public OrderNumberViewModel OrderNumber { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;
        public IEnumerable<ShoppingCardViewModel> OrderItems { get; set; } = new List<ShoppingCardViewModel>();

    }
}
