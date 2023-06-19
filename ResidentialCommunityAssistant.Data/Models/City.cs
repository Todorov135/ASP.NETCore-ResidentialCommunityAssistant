namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants;

    public class City
    {
        /// <summary>
        /// Identity of city.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [Required]
        [StringLength(CityNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// City post code.
        /// </summary>
        [StringLength(CityPostCodeMaxLength)]
        public string? PostCode { get; set; } 

    }
}
