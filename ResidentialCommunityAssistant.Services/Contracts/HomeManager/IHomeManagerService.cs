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
        void RemoveUserFromAddress(int apartamentId);
    }
}
