namespace ResidentialCommunityAssistant.Services.Models.Shop.ShopManager
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;

    public class EditProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength =ProductNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ProductImgURLMaxLength, MinimumLength = ProductImgURLMinLength)]
        public string ImgURL { get; set; } = null!;

        [Required]
        [Range(ProductQuantityMinRange, ProductQuantityMaxRange)]
        public int Quantity { get; set; }

        [Required]
        [Range(typeof(decimal), ProductPriceRangeMinRange, ProductPriceRangeMaxRange)]
        public decimal Price { get; set; }
    }
}
