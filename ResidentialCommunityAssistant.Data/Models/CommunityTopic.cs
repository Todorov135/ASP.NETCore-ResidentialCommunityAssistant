namespace ResidentialCommunityAssistant.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.GlobalConstants;

    public class CommunityTopic
    {
        /// <summary>
        /// Identity of topic.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Topic`s title.
        /// </summary>
        [Required]
        [StringLength(CommunityTopicTitleMaxLength)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Topic`s description.
        /// </summary>
        [Required]
        [StringLength(CommunityTopicDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Date of creation.
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Topic`s address.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;

        /// <summary>
        /// Topic`s creator
        /// </summary>
        [Required]
        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; } = null!;
        public virtual IdentityUser Creator { get; set; } = null!;
    }
}
