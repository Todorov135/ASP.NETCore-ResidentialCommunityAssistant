namespace ResidentialCommunityAssistant.Services.Models.Home
{  
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;

    public class AddressViewModel
    {
        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        public string CityName { get; set; } = null!;

        [Required]
        [StringLength(AddressNameMaxLength, MinimumLength = AddressNameMinLength)]
        public string AddressName { get; set; } = null!;
               
        [Required]
        [StringLength(AddressNumberMaxLength, MinimumLength = AddressNumberMinLength)]
        public string Number { get; set; } = null!;        
    }
}
