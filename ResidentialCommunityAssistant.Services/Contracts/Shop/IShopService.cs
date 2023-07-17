namespace ResidentialCommunityAssistant.Services.Contracts.Shop
{
    using ResidentialCommunityAssistant.Services.Models.Shop.ExtendedUser;
    using ResidentialCommunityAssistant.Services.Models.Shop.ShopManager;

    public interface IShopService
    {
        Task<ICollection<ProductViewModel>> GetAllProductsAsync();
        Task AddProductToShoppingCard(int productId, string userId);
        void RemoveProductToShoppingCard(int productId, string userId);
        Task<IEnumerable<ShoppingCardViewModel>> GetAllProductsInShoppingCardAsync(string userId);
        Task<int> ApprovedOrder(string userId);
        Task<IEnumerable<OrderNumberViewModel>> GetAllOrdersByUserIdAsync(string userId);
        Task<OrderHistoryViewModel> GetShopHistoryDetails(int orderId);

        Task<IEnumerable<ProductOverviewModel>> GetAllProductsForShopManagerAsync();
        Task<EditProductViewModel> GetProductToEditAsync(int productId);
        Task EditProductAsync(EditProductViewModel product);
        Task AddQuantityToProductAsync(AddQuantityProductViewModel product);
        Task AddProductAsync(EditProductViewModel product);
    }
}
