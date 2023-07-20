namespace ResidentialCommunityAssistant.Services.Contracts.HomeManager
{
    using ResidentialCommunityAssistant.Services.Models.API;
    using ResidentialCommunityAssistant.Services.Models.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.Owner;

    public interface IHomeManagerService
    {
        Task<int> AddAddressAsync(AddAddressViewModel address);
        Task AddApartamentByApiAsync(AddApartamentViewAPIModel address);
        Task AddApartamentAsync(AddApartamentViewModel apartament);
        Task<ICollection<AddApartamentViewModel>> GetAllApartamentsInSpecificAddressAsync(int addressId);
        Task<ApartamentViewModel?> GetApartamentByIdAsync(int? id);
        Task EditApartament(ApartamentViewModel apartament);
        void RemoveUserFromApartament(int apartamentId);
        Task<string> GetHomeManagerIdAsync(int addressId);
        Task BecomeHomeManagerAsync(string userId, int addressId);
        Task AddUserToApartamentApprovalAsync(string homemanagerId, string userId, int apartamentId);
        Task<IEnumerable<ApproveUserViewModel>> GetListOfUserToApproveToAddressAsync(string userId);
        Task AddHomeOwnerToApartamentAsync(int apartamentId, int addressId, string userId);
        Task<bool> IsThisRequestFromUserExist(string homeManagerOfCurrentAddress, string userId, int apartamentId);
        Task RejectRequestFromUser(int apartamentId, string userId);
    }
}
