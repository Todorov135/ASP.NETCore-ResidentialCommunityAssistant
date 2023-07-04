namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HomeManagerApproval
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(HomeManager))]
        public string HomeManagerId { get; set; } = null!;
        public ExtendedUser HomeManager { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Apartament))]
        public int ApartamentId { get; set; }
        public Apartament Apartament { get; set; } = null!;

        public bool IsApproved { get; set; }
    }
}
