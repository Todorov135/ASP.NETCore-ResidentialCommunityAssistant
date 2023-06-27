namespace ResidentialCommunityAssistant.Services.Contracts.HomeManager
{
    using ResidentialCommunityAssistant.Services.Models.HomeManager;

    public interface IHomeManagerService
    {
        Task<int> AddAddressAsync(AddAddressViewModel address);
        Task AddApartamentAsync(AddApartamentViewModel apartament);
        Task<ICollection<AddApartamentViewModel>> GetAllApartamentsInSpecificAddressAsync(int addressId);
    }
}
