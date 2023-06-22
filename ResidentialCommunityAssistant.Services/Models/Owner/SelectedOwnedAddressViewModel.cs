namespace ResidentialCommunityAssistant.Services.Models.Owner
{
    
    public class SelectedOwnedAddressViewModel
    {
        public int SelectedAddressId { get; set; }
        public IEnumerable<OwnedAddressViewModel> OwnedAddresses { get; set; } = new List<OwnedAddressViewModel>();
    }
}
