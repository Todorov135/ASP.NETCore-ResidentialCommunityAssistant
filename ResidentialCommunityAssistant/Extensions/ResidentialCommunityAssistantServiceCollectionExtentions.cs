namespace ResidentialCommunityAssistant.Extensions
{
    using ResidentialCommunityAssistant.Services.Contracts.Home;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Contracts.Shop;
    using ResidentialCommunityAssistant.Services.Services.Home;
    using ResidentialCommunityAssistant.Services.Services.HomeManager;
    using ResidentialCommunityAssistant.Services.Services.Owner;
    using ResidentialCommunityAssistant.Services.Services.Shop;

    public static class ResidentialCommunityAssistantServiceCollectionExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IHomeManagerService, HomeManagerService>();
            service.AddScoped<IOwnerService, OwnerService>();
            service.AddScoped<IShopService, ShopService>();

            return service;
        }
    }
}
