namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual ExtendedUser User { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public bool IsPurchased { get; set; }
    }
}
