namespace ResidentialCommunityAssistant.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homeowner
    {
        /// <summary>
        /// Identity of homeowner.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Identity of user.
        /// </summary>
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public virtual IdentityUser User { get; set; } = null!;

        /// <summary>
        /// List of addresses, owned by user.
        /// </summary>
        public virtual IEnumerable<Address> Addresses { get; set; } = new List<Address>();
    }
}