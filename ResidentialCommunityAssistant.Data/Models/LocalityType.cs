namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants;

    public class LocalityType
    {
        /// <summary>
        /// Identity of locality type.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Type of local place.
        /// </summary>
        [Required]
        [StringLength(LocalityTypeNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
