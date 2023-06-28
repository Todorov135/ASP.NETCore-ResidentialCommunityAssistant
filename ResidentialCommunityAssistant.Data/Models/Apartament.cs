namespace ResidentialCommunityAssistant.Data.Models
{    
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants;

    public class Apartament
    {
        /// <summary>
        /// Identity of Apartament.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represent specific namening of apartament.
        /// </summary>
        [StringLength(ApartamentSignatureMaxLength)]
        public string? Signature { get; set; }

        /// <summary>
        /// Number of apartament.
        /// </summary>
        [Required]  
        public int Number { get; set; }
                
        /// <summary>
        /// Owner of apartament.
        /// </summary>
        public string? OwnerId { get; set; }
        public virtual ExtendedUser? Owner { get; set; }

        /// <summary>
        /// Apartament`s building.
        /// </summary>
        [Required]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;

    }
}
