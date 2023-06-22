namespace ResidentialCommunityAssistant.Services.Models.Owner
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;
    public class LocationTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(LocalityTypeNameMaxLength, MinimumLength = LocalityTypeNameMinLength)]
        public string Name { get; set; } = null!;

    }
}
