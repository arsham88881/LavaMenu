using LavaMenu.Application.Domain.Entitys;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LavaMenu.WebEndpoint.Models
{
    public class AddProductModel : IProduct
    {
        [Required]
        public string ProductTitle { get; set; }
        public string? ProductDescription { get; set; } = null;
        public int? productPrice { get; set; } = null;

        [Required]
        public IFormFile Img { get; set; }

        [Required]
        public ProductCategury categury { get; set; }

    }
}
