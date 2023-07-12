namespace ResidentialCommunityAssistant.Services.Services.Owner
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Owner;
    using ResidentialCommunityAssistant.Services.Models.Owner;
    using System.Collections.Generic;
    using System.Linq;
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
                            .OrderByDescending(d => d.CreatedOn)
                            .Select(t => new CommunityTopicViewModel()
                            {
                                Id = t.Id,
                                Title = t.Title,
                                Description = t.Description,
                                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy"),
                                CreatorName = $"{t.Creator.FirstName} {t.Creator.LastName}",
                                CreatorId = t.CreatorId
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

        /// <summary>
        /// Get all apartaments for specific address - asynchronous.
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>Collection of ApartamentViewModel</returns>
        public async Task<IEnumerable<ApartamentViewModel>> GetAllApartamentsAsync(int? addressId)
        {
            return await this.data.Apartaments.Where(a => a.AddressId == addressId)
                                              .Select(a => new ApartamentViewModel()
                                              {
                                                  Number = a.Number,
                                                  Signature = a.Signature,
                                                  OwnerId = a.OwnerId,
                                                  Owner = $"{a.Owner.FirstName} {a.Owner.LastName}",
                                                  ApartamentId = a.Id,
                                                  AddressId = a.AddressId
                                              })
                                              .OrderBy(s => s.Signature)
                                              .OrderBy(n => n.Number)
                                              .ToListAsync();
        }

        /// <summary>
        /// Add topic in database, for specific address.
        /// </summary>
        /// <param name="communityTopic"></param>
        public async Task AddCommunityTopicAsync(AddCommunityTopicViewModel communityTopic)
        {
            CommunityTopic ct = new CommunityTopic()
            {
                Title = communityTopic.Title,
                Description = communityTopic.Description,
                AddressId = communityTopic.AddressId,
                CreatedOn = DateTime.Now,
                CreatorId = communityTopic.CreatorId
            };

            await this.data.CommunityTopics.AddAsync(ct);
            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Get first community topic by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CommunityTopicViewModel</returns>       
        public async Task<CommunityTopicViewModel?> GetCommunityTopicAsync(int id)
        {
            return await this.data.CommunityTopics
                                  .Where(ct => ct.Id == id)
                                  .Select(ct => new CommunityTopicViewModel()
                                  {
                                      Id = ct.Id,
                                      Title = ct.Title,
                                      Description = ct.Description
                                  })
                                  .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Edit community topic.
        /// </summary>
        /// <param name="communityTopic"></param>        
        public async Task EditCommunityTopic(CommunityTopicViewModel communityTopic)
        {
            var topicToEdit = await this.data.CommunityTopics.FindAsync(communityTopic.Id);

            if (topicToEdit == null)
            {
                return;
            }

            topicToEdit.Title = communityTopic.Title;
            topicToEdit.Description = communityTopic.Description;

            await this.data.SaveChangesAsync();
        }
    }
}
