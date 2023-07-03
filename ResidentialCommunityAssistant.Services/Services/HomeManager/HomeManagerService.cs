namespace ResidentialCommunityAssistant.Services.Services.HomeManager
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
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
        public void RemoveUserFromAddress(int apartamentId)
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
    }
}
