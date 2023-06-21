namespace ResidentialCommunityAssistant.Extensions
{
    using ResidentialCommunityAssistant.Services.Contracts.Home;
    using ResidentialCommunityAssistant.Services.Services.Home;

    public static class ResidentialCommunityAssistantServiceCollectionExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {
            service.AddScoped<IHomeService, HomeService>();

            return service;
        }
    }
}
