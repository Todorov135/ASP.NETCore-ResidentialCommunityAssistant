namespace ResidentialCommunityAssistant.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants;
    public class ExtendedUser : IdentityUser
    {        
        /// <summary>
        /// Add first name to IdentityUser.
        /// </summary>
        [Required]
        [StringLength(ExtendedUserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Add last name to IdentityUser.
        /// </summary>
        [Required]
        [StringLength(ExtendedUserLastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}
