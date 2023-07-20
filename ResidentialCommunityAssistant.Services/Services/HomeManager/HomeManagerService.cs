namespace ResidentialCommunityAssistant.Services.Services.HomeManager
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.API;
    using ResidentialCommunityAssistant.Services.Models.HomeManager;
    using ResidentialCommunityAssistant.Services.Models.Owner;
    using System.Collections.Generic;

    public class HomeManagerService : IHomeManagerService
    {
        private readonly CommunityAssistantDBContext data;        

        public HomeManagerService(CommunityAssistantDBContext data)
        {
            this.data = data;
        }

        /// <summary>
        /// Create and add address to database linked to user.
        /// </summary>
        /// <returns></returns>       
        public async Task<int> AddAddressAsync(AddAddressViewModel address)
        {
            Address? chekForExistingAddress = await this.data.Addresses
                                                             .Where(a => a.City.Name.ToLower() == address.CityName.ToLower()
                                                                      && a.Name.ToLower() == address.Name.ToLower()
                                                                      && a.Number.ToLower() == address.Number.ToLower())
                                                             .FirstOrDefaultAsync();
            if (chekForExistingAddress != null)
            {
                return 0;
            }
            var addressToAdd = new Address()
            {
                CityId = await GetCityIdByNameAsync(address),
                LocationTypeId = address.LocationTypeId,
                Name = address.Name,
                Number = address.Number
            };

            await this.data.Addresses.AddAsync(addressToAdd);
            await this.data.SaveChangesAsync();

            return addressToAdd.Id;
        }

        public async Task AddApartamentByApiAsync(AddApartamentViewAPIModel apartament)
        {
            Apartament apartamentToAdd = new Apartament()
            {
                AddressId = apartament.AddressId,
                Number = apartament.Number,
                Signature = apartament.Signature
            };

            await this.data.Apartaments.AddAsync(apartamentToAdd);
            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Add apartament to database.
        /// </summary>
        /// <param name="apartament"></param>        
        public async Task AddApartamentAsync(AddApartamentViewModel apartament)
        {
            Apartament apartamentToAdd = new Apartament()
            {
                AddressId = apartament.AddressId,
                Number = apartament.Number,
                OwnerId = apartament.OwnerId,
                Signature = apartament.Signature
            };

            await this.data.Apartaments.AddAsync(apartamentToAdd);
            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Edit existing apartament.
        /// </summary>
        /// <param name="apartament"></param>        
        public async Task EditApartament(ApartamentViewModel apartament)
        {
            Apartament apartamentToEdit = await this.data.Apartaments.FindAsync(apartament.ApartamentId);
            if (apartamentToEdit == null)
            {
                return;
            }

            apartamentToEdit.Number = apartament.Number;
            apartamentToEdit.Signature = apartament.Signature;

            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Get all apartaments for address by Id - asynchronous.
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>

        public async Task<ICollection<AddApartamentViewModel>> GetAllApartamentsInSpecificAddressAsync(int addressId)
        {
            return await this.data.Apartaments
                                  .Where(a => a.AddressId == addressId)
                                  .Select(ap => new AddApartamentViewModel()
                                  {    
                                      Id = ap.Id,                                  
                                      Number = ap.Number,
                                      Signature = ap.Signature,
                                      OwnerId = ap.OwnerId
                                  })
                                  .OrderBy(a => a.Signature)
                                  .ThenBy(n => n.Number)
                                  .ToListAsync();
        }

        /// <summary>
        /// Get apartament by Id - asynchronous.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ApartamentViewModel</returns>
        public async Task<ApartamentViewModel?> GetApartamentByIdAsync(int? id)
        {
            return await this.data.Apartaments
                                  .Where(a => a.Id == id)
                                  .Select(a => new ApartamentViewModel()
                                  {
                                      AddressId = a.AddressId,
                                      ApartamentId = a.Id,
                                      Number = a.Number,
                                      Owner = $"{a.Owner.FirstName} {a.Owner.LastName}",
                                      Signature = a.Signature
                                  })
                                  .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Remove apartament owner from address.
        /// </summary>
        /// <param name="apartamentId"></param>
        /// <param name="addressId"></param>
        public void RemoveUserFromApartament(int apartamentId)
        {
            Apartament? apartament = this.data.Apartaments.Where(a => a.Id == apartamentId).FirstOrDefault();
            if (apartament == null)
            {
                return;
            }
            apartament.Owner = null;
            apartament.OwnerId = null;
           
            this.data.SaveChanges();
        }

        /// <summary>
        /// Get id of homemanager by address id.
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>string</returns>
        public async Task<string> GetHomeManagerIdAsync(int addressId)
        {
            var ua = await this.data.UsersAddresses.Where(a => a.AddressId == addressId && a.IsUserHomeManager == true).FirstOrDefaultAsync();
            if (ua == null)
            {
                return string.Empty;
            }
            string homemanagerId = ua.UserId;          

            return homemanagerId;
        }

        /// <summary>
        /// Set given user to homemanager by addressId.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        public async Task BecomeHomeManagerAsync(string userId, int addressId)
        {
            UserAddress? ua = await this.data.UsersAddresses
                                             .Where(u => u.UserId == userId && u.AddressId == addressId)
                                             .FirstOrDefaultAsync();
            if (ua == null)
            {
                return;
            }

            ua.IsUserHomeManager = true;

            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Add user in list to be approved from homemanager.
        /// </summary>
        /// <param name="homemanagerId"></param>
        /// <param name="userId"></param>
        /// <param name="apartamentId"></param>
        public async Task AddUserToApartamentApprovalAsync(string homemanagerId, string userId, int apartamentId)
        {
            if (string.IsNullOrEmpty(homemanagerId) 
                || string.IsNullOrEmpty(userId)
                || apartamentId == 0)
            {
                return;
            }
            HomeManagerApproval hma = new HomeManagerApproval()
            {
                HomeManagerId = homemanagerId,
                HomeOwnerId = userId,
                ApartamentId = apartamentId
            };

            await this.data.HomeManagersApprovals.AddAsync(hma);
            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Get all request form user to be approved by homemanager for specific address.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Collection of ApproveUserViewModel</returns>
        public async Task<IEnumerable<ApproveUserViewModel>> GetListOfUserToApproveToAddressAsync(string userId)
        {
            return await this.data.HomeManagersApprovals
                                  .Where(u => u.HomeManagerId == userId && u.Apartament.Owner == null)
                                  .Select(hma => new ApproveUserViewModel()
                                  {
                                      AddressName = $"{hma.Apartament.Address.City.LocalityType.Name} {hma.Apartament.Address.City.Name}, {hma.Apartament.Address.LocationType.Name} {hma.Apartament.Address.Name} {hma.Apartament.Address.Number}",
                                      AddressId = hma.Apartament.Address.Id,
                                      UserName = $"{hma.HomeOwner.FirstName} {hma.HomeOwner.LastName}",
                                      UserId = hma.HomeOwner.Id,
                                      ApartamentSignature = $"{hma.Apartament.Signature} - {hma.Apartament.Number}",
                                      ApartamentId = hma.ApartamentId
                                  })
                                  .ToListAsync();
        }

        /// <summary>
        /// Add user to apartament.
        /// </summary>
        /// <param name="apartamentId"></param>
        /// <param name="userId"></param>
        public async Task AddHomeOwnerToApartamentAsync(int apartamentId, int addressId, string userId)
        {
            Apartament? apartament = await this.data.Apartaments.Where(a => a.Id == apartamentId).FirstOrDefaultAsync();
            var isHomeManagerApprovalRemoved = await RemoveRequestFromHomeManagerApproval(apartamentId, userId);
            
            if (apartament == null || !isHomeManagerApprovalRemoved)
            {
                return;
            }

            apartament.OwnerId = userId;
            UserAddress ua = new UserAddress()
            {
                AddressId = addressId,
                UserId = userId
            };
            await this.data.UsersAddresses.AddAsync(ua);

            await this.data.SaveChangesAsync();
        }

        /// <summary>
        /// Chek for existing request.
        /// </summary>
        /// <param name="homeManagerOfCurrentAddress"></param>
        /// <param name="userId"></param>
        /// <param name="apartamentId"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsThisRequestFromUserExist(string homeManagerOfCurrentAddress, string userId, int apartamentId)
        {
            return await this.data.HomeManagersApprovals
                                  .AnyAsync(hmo => hmo.HomeManagerId == homeManagerOfCurrentAddress
                                                   && hmo.HomeOwnerId == userId
                                                   && hmo.ApartamentId == apartamentId);
        }

        public async Task RejectRequestFromUser(int apartamentId, string userId)
        {
            var isRequestRemoved = await RemoveRequestFromHomeManagerApproval(apartamentId, userId);

            if (!isRequestRemoved)
            {
                return;
            }

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
        /// Get request from HomeManagerApprove in database and reset it.
        /// </summary>
        /// <param name="apartamentId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        private async Task<bool> RemoveRequestFromHomeManagerApproval(int apartamentId, string userId)
        {
            HomeManagerApproval? hma = await this.data.HomeManagersApprovals
                                                      .Where(u => u.HomeOwnerId == userId && u.ApartamentId == apartamentId)
                                                      .FirstOrDefaultAsync();

            if (hma == null)
            {
                return false;
            }
            hma.HomeOwner = null;
            hma.HomeOwnerId = null;
            hma.HomeManagerId = null;

            return true;
        }
    }
}
