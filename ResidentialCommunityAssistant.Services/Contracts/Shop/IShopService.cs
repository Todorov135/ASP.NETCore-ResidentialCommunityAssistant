namespace ResidentialCommunityAssistant.Services.Contracts.Shop
{
    using ResidentialCommunityAssistant.Services.Models.Shop;

    public interface IShopService
    {
        Task<ICollection<ProductViewModel>> GetAllProductsAsync();
    }
}
