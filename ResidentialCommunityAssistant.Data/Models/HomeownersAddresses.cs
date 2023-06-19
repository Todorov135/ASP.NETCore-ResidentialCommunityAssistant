namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HomeownersAddresses
    {
        [Required]
        [ForeignKey(nameof(Homeowner))]
        public int HomeownerId { get; set; }
        public Homeowner Homeowner { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
    }
}
