namespace ResidentialCommunityAssistant.Services.Services.Owner
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.Owner;
    using System.Collections.Generic;
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
            return await this.data.LocationTypes
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
    }
}
