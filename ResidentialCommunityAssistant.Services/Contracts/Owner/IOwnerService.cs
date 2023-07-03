namespace ResidentialCommunityAssistant.Services.Contracts.Owner
{   
    using ResidentialCommunityAssistant.Services.Models.Owner;

    public interface IOwnerService
    {
        Task<IEnumerable<CommunityTopicViewModel>> GetAllTopicsForAddressAsync(int addressId);
        Task<IEnumerable<OwnedAddressViewModel>> GetOwnedAddressesAsync(string userId);
        Task<IEnumerable<LocalityTypeViewModel>> GetAllLocalityTypesAsync();
        Task<IEnumerable<LocationTypeViewModel>> GetAllLocationTypesAsync();        
        Task AddAddressToUserAsync(string userId, int addressId);
        bool IsAddressInUsersList(string userId, int addressId);
        Task<IEnumerable<ApartamentViewModel>> GetAllApartamentsAsync(int? addressId);
        Task AddCommunityTopicAsync(AddCommunityTopicViewModel communityTopic);
        Task<CommunityTopicViewModel?> GetCommunityTopicAsync(int id);
        Task EditCommunityTopic(CommunityTopicViewModel communityTopic);
    }
}
