namespace ResidentialCommunityAssistant.Services.Models.Home
{  
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;

    public class AddressViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Град")]
        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        public string CityName { get; set; } = null!;

        [Display(Name = "Адрес")]
        [Required]
        [StringLength(AddressNameMaxLength, MinimumLength = AddressNameMinLength)]
        public string AddressName { get; set; } = null!;

        [Display(Name = "Номер")]
        [Required]
        [StringLength(AddressNumberMaxLength, MinimumLength = AddressNumberMinLength)]
        public string Number { get; set; } = null!;        
    }
}
