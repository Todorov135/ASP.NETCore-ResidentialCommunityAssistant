namespace ResidentialCommunityAssistant.Services.Contracts.Home
{
    using ResidentialCommunityAssistant.Services.Models.Home;

    public interface IHomeService
    {
        Task<AddressViewModel?> GetAddressAsync(string cityName, string addressName, string number);
    }
}
