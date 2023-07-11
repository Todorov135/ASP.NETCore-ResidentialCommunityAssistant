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

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual IEnumerable<OrderProduct> OrdersProducts { get; set; } = new List<OrderProduct>();
    }
}
