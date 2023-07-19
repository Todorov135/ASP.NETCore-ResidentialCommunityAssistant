namespace ResidentialCommunityAssistant.Services.Models.Shop.ShopManager
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;

    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на артикул")]
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength =ProductNameMinLength)]
        public string Name { get; set; } = null!;

        [Display(Name = "Описание")]
        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Display(Name = "Линк към снимка")]
        [Required]
        [StringLength(ProductImgURLMaxLength, MinimumLength = ProductImgURLMinLength)]
        public string ImgURL { get; set; } = null!;

        [Display(Name = "Количество")]
        [Required]
        [Range(ProductQuantityMinRange, ProductQuantityMaxRange)]
        public int Quantity { get; set; }

        [Display(Name = "Цена за единична бройка")]
        [Required]
        [Range(typeof(decimal), ProductPriceRangeMinRange, ProductPriceRangeMaxRange)]
        public decimal Price { get; set; }
    }
}
