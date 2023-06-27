namespace ResidentialCommunityAssistant.Services.Models.HomeManager
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;

    public class AddApartamentViewModel
    {
        [Required]
        public int AddressId { get; set; }

        [StringLength(ApartamentSignatureMaxLength, MinimumLength = ApartamentSignatureMinLength)]
        public string? Signature { get; set; }
        
        [Required]
        [Range(ApartamentRangeMinLength, ApartamentRangeMaxLength)]
        public int Number { get; set; }
                
        public string? OwnerId { get; set; }
             
           
    }
}
