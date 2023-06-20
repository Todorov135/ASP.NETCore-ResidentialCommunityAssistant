namespace ResidentialCommunityAssistant.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserAddress
    {
        [Required]
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

 
    }
}
