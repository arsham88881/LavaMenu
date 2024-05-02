using Microsoft.AspNetCore.Http;

namespace LavaMenu.Application.Common.RequestDTO
{
    public record AddProductRequestDTO
    {
        public string ProductTitle { get; set; }
        public string? ProductDescription { get; set; } = null;
        public int? productPrice { get; set; } = null;
        public bool IsWithDiscount { get; set; } = false;
        public int? AfterDiscountPrice { get; set; } = null;
        public int CateguryId { get; set; }
        public IFormFile Image { get; set; }

    }
}
