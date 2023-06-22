namespace ResidentialCommunityAssistant.Services.Models.Owner
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;
    public class AddAddressViewModel
    {
        [Display(Name = "Тип на населеното място")]
        [Required]
        public int CityLocalityId { get; set; }
        public IEnumerable<LocalityTypeViewModel> LocalityTypeViews { get; set; } = new List<LocalityTypeViewModel>();

        [Display(Name = "Град")]
        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        public string CityName { get; set; } = null!;

        [Display(Name = "Тип на локацията")]
        [Required]
        public int LocationTypeId { get; set; }
        public IEnumerable<LocationTypeViewModel> LocationTypeViews { get; set; } = new List<LocationTypeViewModel>();

        [Display(Name = "Улица")]
        [Required]
        [StringLength(AddressNameMaxLength, MinimumLength = AddressNameMinLength)]
        public string Name { get; set; } = null!;

        [Display(Name = "Номер")]
        [Required]
        [StringLength(AddressNumberMaxLength, MinimumLength = AddressNumberMinLength)]
        public string Number { get; set; } = null!;

        

               

    }
}
