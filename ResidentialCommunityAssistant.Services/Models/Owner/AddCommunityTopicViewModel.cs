namespace ResidentialCommunityAssistant.Services.Models.Owner
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;
    public class AddCommunityTopicViewModel
    {
        [Required]
        [StringLength(CommunityTopicTitleMaxLength, MinimumLength = CommunityTopicTitleMinLength)]
        [Display(Name = "Тема")]
        public string Title { get; set; } = null!;
               
        [Required]
        [StringLength(CommunityTopicDescriptionMaxLength, MinimumLength = CommunityTopicDescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;
        
        public int AddressId { get; set; }
        
        public string? CreatorId { get; set; }         
    }
}
