namespace ResidentialCommunityAssistant.Services.Services.Owner
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.Owner;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class OwnerService : IOwnerService
    {
        private readonly CommunityAssistantDBContext data;

        public OwnerService(CommunityAssistantDBContext data)
        {
            this.data = data;
        }

        /// <summary>
        /// Get all locality types.
        /// </summary>        
        /// <returns>Collection of LocalityTypeViewModel</returns>
        public async Task<IEnumerable<LocalityTypeViewModel>> GetAllLocalityTypesAsync()
        {
            return await this.data.LocalityTypes
                .Select(l => new LocalityTypeViewModel()
                 {
                     Id = l.Id,
                     Name = l.Name
                 })
                 .ToListAsync(); 
        }

        /// <summary>
        /// Get all location types.
        /// </summary>       
        /// <returns>Collection of LocationTypeViewModel</returns>
        public async Task<IEnumerable<LocationTypeViewModel>> GetAllLocationTypesAsync()
        {
            return await this.data.LocationTypes
                                  .Select(l => new LocationTypeViewModel()
                                   {
                                      Id = l.Id,
                                      Name = l.Name
                                   })
                                   .ToListAsync();
        }

        /// <summary>
        /// Get all topics for wanted address.
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>Collection of CommunityTopicViewModel</returns>
        public async Task<IEnumerable<CommunityTopicViewModel>> GetAllTopicsForAddressAsync(int addressId)
        {
            return await this.data.CommunityTopics
                            .Where(a => a.AddressId == addressId)
                            .Select(t => new CommunityTopicViewModel()
                            {
                                Id = t.Id,
                                Title = t.Title,
                                Description = t.Description,
                                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy"),
                                CreatorName = t.Creator.UserName
                            })
                            .ToListAsync();
                                                               
        }

        /// <summary>
        /// Returns all address, owned by given user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OwnedAddressViewModel>> GetOwnedAddressesAsync(string userId)
        {
            return await this.data.UsersAddresses
                            .Where(u => u.UserId == userId)
                            .Select(a => new OwnedAddressViewModel()
                            {
                                Id = a.AddressId,
                                AddressFullName = $"{a.Address.City.LocalityType.Name} {a.Address.City.Name}, {a.Address.LocationType.Name} {a.Address.Name} {a.Address.Number}"
                            })
                            .ToListAsync();
        }

        /// <summary>
        /// Create and add address to database linked to user.
        /// </summary>
        /// <returns></returns>       
        public async Task AddAddressAsync(AddAddressViewModel address)
        {
            var addressToAdd = new Address()
            {
                CityId = await GetCityIdByNameAsync(address),
                LocationTypeId = address.LocationTypeId,
                Name = address.Name,
                Number = address.Number                
            };

            await this.data.Addresses.AddAsync(addressToAdd);
            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Search city by name in database and return it`s id. If database don`t have, create and return new onew.
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>int</returns>
        private async Task<int> GetCityIdByNameAsync(AddAddressViewModel address)
        {
            string normalizeCityName = address.CityName.ToLower();

            bool isCityExist = await this.data.Cities.AnyAsync(c => c.Name.ToLower() == normalizeCityName);
            if (isCityExist)
            {
                return await this.data
                                 .Cities
                                 .Where(c => c.Name.ToLower() == normalizeCityName)
                                 .Select(c => c.Id)
                                 .FirstOrDefaultAsync();
            }
            else
            {
                City newCity = new City()
                {
                    LocalityTypeId = address.CityLocalityId,
                    Name = address.CityName,
                    PostCode = address.PostCode
                };

                await this.data.Cities.AddAsync(newCity);
                await this.data.SaveChangesAsync();

                return newCity.Id;
            }
        }

        /// <summary>
        /// Bind user and address.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
       
        public async Task AddAddressToUserAsync(string userId, int addressId)
        {
            UserAddress ua = new UserAddress()
            {
                AddressId = addressId,
                UserId = userId
            };

            await this.data.UsersAddresses.AddAsync(ua);
            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Check current address is in user`s list.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        
        public bool IsAddressInUsersList(string userId, int addressId)
        {
            return this.data.UsersAddresses.Where(u => u.UserId == userId).Any(a => a.AddressId == addressId);
        }
    }
}
