namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.GlobalConstants;

    public class Address
    {
        /// <summary>
        /// Identity of Address.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Address name.
        /// </summary>
        [Required]
        [StringLength(AddressNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Address number.
        /// </summary>
        [Required]
        [StringLength(AddressNumberMaxLength)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// Type of location.
        /// </summary>
        [Required]
        [ForeignKey(nameof(LocationType))]
        public int LocationTypeId { get; set; }
        public virtual LocationType LocationType { get; set; } = null!;

        /// <summary>
        /// Address in city.
        /// </summary>
        [Required]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public virtual City City { get; set; } = null!;

        /// <summary>
        /// Collection of homeowners in current address.
        /// </summary>
        public virtual IEnumerable<UserAddress> Homeowners { get; set; } = new List<UserAddress>();

        /// <summary>
        /// Collection of topics in current address.
        /// </summary>
        public virtual IEnumerable<CommunityTopic> CommunityTopics { get; set; } = new List<CommunityTopic>();
    }
}
