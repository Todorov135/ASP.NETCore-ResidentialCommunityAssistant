namespace ResidentialCommunityAssistant.Services.Models.Owner
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;
    public class ApartamentViewModel
    {
        [Required]
        public int AddressId { get; set; }

        [StringLength(ApartamentSignatureMaxLength, MinimumLength = ApartamentSignatureMinLength)]
        public string? Signature { get; set; }

        [Required]
        [Range(ApartamentRangeMinLength, ApartamentRangeMaxLength)]
        public int Number { get; set; }

        public string? Owner { get; set; }

        public int ApartamentId { get; set; }

    }
}
