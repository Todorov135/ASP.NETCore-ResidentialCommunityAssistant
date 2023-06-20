namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants;

    public class LocationType
    {
        /// <summary>
        /// Identity of location type.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Type of road/location where the address is called.
        /// </summary>
        [Required]
        [StringLength(LocationTypeNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
