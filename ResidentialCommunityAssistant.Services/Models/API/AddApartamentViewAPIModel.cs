namespace ResidentialCommunityAssistant.Services.Models.API
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;
    public class AddApartamentViewAPIModel
    {
        [Required]
        public int AddressId { get; set; }

        [StringLength(ApartamentSignatureMaxLength, MinimumLength = ApartamentSignatureMinLength)]
        public string? Signature { get; set; }

        [Required]
        [Range(ApartamentRangeMinLength, ApartamentRangeMaxLength)]
        public int Number { get; set; }
    }
}
