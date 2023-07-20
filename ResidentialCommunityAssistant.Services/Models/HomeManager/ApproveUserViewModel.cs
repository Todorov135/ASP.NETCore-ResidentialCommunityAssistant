namespace ResidentialCommunityAssistant.Services.Models.HomeManager
{
    public class ApproveUserViewModel
    {
        public string UserName { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public string AddressName { get; set; } = null!;
        public int AddressId { get; set; }

        public string ApartamentSignature { get; set; } = null!;
        public int ApartamentId { get; set; }
    }
}
