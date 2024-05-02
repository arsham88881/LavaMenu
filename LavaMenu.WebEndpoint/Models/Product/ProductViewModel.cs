using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LavaMenu.WebEndpoint.Models.Product
{
    public class ProductViewModel
    {
        public string? ProductId { get; set; }

        [Required, MaxLength(20)]
        [Remote("IsAnyProduct","Product",HttpMethod = "Post")]
        public string ProductTitle { get; set; }
        public string? ProductDescription { get; set; } = null;
        [Required]
        public int? productPrice { get; set; } = null;
        public bool IsWithDiscount { get; set; } = false;
        public int? AfterDiscountPrice { get; set; } = null;
        [Required]
        public int CateguryId { get; set; }

        public IFormFile? file { get; set; } = null;
    }
}
