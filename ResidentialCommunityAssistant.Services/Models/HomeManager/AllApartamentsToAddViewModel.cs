namespace ResidentialCommunityAssistant.Services.Models.HomeManager
{
    using System.ComponentModel.DataAnnotations;

    public class AllApartamentsToAddViewModel
    {
        [Required]
        public int AddressId { get; set; }
        public AddApartamentViewModel? CurrentApartamentToAdd { get; set; }
        public ICollection<AddApartamentViewModel> AllAddedApartaments { get; set; } = new List<AddApartamentViewModel>();
    }
}
