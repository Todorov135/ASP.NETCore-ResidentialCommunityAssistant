namespace ResidentialCommunityAssistant.Extensions
{
    using ResidentialCommunityAssistant.Services.Contracts.Home;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Services.Home;
    using ResidentialCommunityAssistant.Services.Services.Owner;

    public static class ResidentialCommunityAssistantServiceCollectionExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IOwnerService, OwnerService>();

            return service;
        }
    }
}
