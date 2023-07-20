namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HomeManagerApproval
    {
        [Key]
        public int Id { get; set; }
        public string? HomeManagerId { get; set; }

        [ForeignKey(nameof(HomeOwner))]
        public string? HomeOwnerId { get; set; } 
        public ExtendedUser? HomeOwner { get; set; } 

        
        [ForeignKey(nameof(Apartament))]
        public int ApartamentId { get; set; }
        public Apartament Apartament { get; set; } = null!;
    }
}
