﻿namespace ResidentialCommunityAssistant.Services.Models.Shop.ShopManager
{
    using System.ComponentModel.DataAnnotations;
    using static ResidentialCommunityAssistant.Data.Common.GlobalConstants;
    public class AddQuantityProductViewModel
    {
        public EditProductViewModel CurrentProduct { get; set; } = null!;

        [Required]
        [Range(1, ProductQuantityMaxRange)]
        public int QuantityToAdd { get; set; }
    }
}
