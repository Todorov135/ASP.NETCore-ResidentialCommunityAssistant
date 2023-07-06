namespace ResidentialCommunityAssistant.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ProductImgURLMaxLength)]
        public string ImgURL { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Precision(5,2)]
        public decimal Price { get; set; }
    }
}
