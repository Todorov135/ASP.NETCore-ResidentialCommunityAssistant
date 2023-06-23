namespace ResidentialCommunityAssistant.Services.Services.Home
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Services.Contracts.Home;
    using ResidentialCommunityAssistant.Services.Models.Home;
    using System.Threading.Tasks;

    public class HomeService : IHomeService
    {
        private readonly CommunityAssistantDBContext data;
        public HomeService(CommunityAssistantDBContext data)
        {
            this.data = data;
        }
        /// <summary>
        /// Search address in database.
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="addressName"></param>
        /// <param name="number"></param>
        /// <returns>AddressViewModel if finds criteria or null if not.</returns>
        public async Task<AddressViewModel?> GetAddressAsync(string cityName, string addressName, string number)
        {
            return await this.data.Addresses
                                  .Where(a => a.City.Name.ToLower() == cityName.ToLower() && a.Name.ToLower() == addressName.ToLower() && a.Number == number.ToLower())
                                  .Select(a => new AddressViewModel()
                                  {
                                      Id = a.Id,
                                      CityName = a.City.Name,
                                      AddressName = a.Name,
                                      Number = a.Number
                                  })
                                  .FirstOrDefaultAsync();
        }

        public async Task<AddressViewModel?> GetAddressByIdAsync(int addressId)
        {
            return await this.data.Addresses
                                  .Where(a => a.Id == addressId)
                                  .Select(a => new AddressViewModel()
                                  {
                                      Id = a.Id,
                                      CityName = a.City.Name,
                                      AddressName = a.Name,
                                      Number = a.Number
                                  })
                                  .FirstOrDefaultAsync();
        }
    }
}
