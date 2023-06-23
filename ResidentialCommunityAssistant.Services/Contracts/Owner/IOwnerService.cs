namespace ResidentialCommunityAssistant.Services.Contracts.Owner
{
    using ResidentialCommunityAssistant.Services.Models.Owner;

    public interface IOwnerService
    {
        Task<IEnumerable<CommunityTopicViewModel>> GetAllTopicsForAddressAsync(int addressId);
        Task<IEnumerable<OwnedAddressViewModel>> GetOwnedAddressesAsync(string userId);
        Task<IEnumerable<LocalityTypeViewModel>> GetAllLocalityTypesAsync();
        Task<IEnumerable<LocationTypeViewModel>> GetAllLocationTypesAsync();
        Task AddAddressAsync(AddAddressViewModel address);
        Task AddAddressToUserAsync(string userId, int addressId);
        bool IsAddressInUsersList(string userId, int addressId);
    }
}
