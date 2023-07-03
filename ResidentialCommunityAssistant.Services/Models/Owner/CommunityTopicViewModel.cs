namespace ResidentialCommunityAssistant.Services.Models.Owner
{
     public class CommunityTopicViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;               
        public string Description { get; set; } = null!;
        public string? CreatedOn { get; set; } 
        public string? CreatorName { get; set; }        
        public string? CreatorId { get; set; }
    }
}
