namespace ResidentialCommunityAssistant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderCache
    {
        [Key]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ExtendedUser User { get; set; } = null!;

        [Key]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

    }
}
