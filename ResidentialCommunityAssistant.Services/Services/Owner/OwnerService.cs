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
        public async Task<IEnumerable<CommunityTopicViewModel>> GetAllTopicsForAddress(int addressId)
        {
            var address = await this.data.Addresses.Where(a => a.Id == addressId).FirstOrDefaultAsync();
            if (address == null)
            {
                return null;
            }
            var topics = address.CommunityTopics.Select(t => new CommunityTopicViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy"),
                CreatorName =t.Creator.UserName
            });

            return topics;                                                     
                                                               
        }
    }
}
