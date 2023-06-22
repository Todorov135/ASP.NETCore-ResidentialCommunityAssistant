namespace ResidentialCommunityAssistant.Services.Models.Owner
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;
    public class CityViewModel
    {
        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        public string Name { get; set; } = null!;        

        [StringLength(CityPostCodeMaxLength, MinimumLength = CityPostCodeMinLength)]
        public string? PostCode { get; set; }

        public IEnumerable<LocalityTypeViewModel> LocalityTypes { get; set; } = new List<LocalityTypeViewModel>();
    }
}
