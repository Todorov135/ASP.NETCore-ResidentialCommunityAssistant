namespace ResidentialCommunityAssistant.Services.Contracts.Owner
{
    using ResidentialCommunityAssistant.Services.Models.Owner;

    public interface IOwnerService
    {
        Task<IEnumerable<CommunityTopicViewModel>> GetAllTopicsForAddress(int addressId);
    }
}
