namespace ResidentialCommunityAssistant.Data.Models
{   
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderProduct
    {        
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
