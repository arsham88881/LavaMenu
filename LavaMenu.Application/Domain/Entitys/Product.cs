using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Domain.Entitys
{
    public interface IProduct //use this for model binding in web endpoint
    {
        string ProductTitle { get; set; }
        string? ProductDescription { get; set; } 

        int? productPrice { get; set; } 

        public ProductCategury categury { get; set; }

    }
    public class Product : IProduct
    {
        public long ProductId { get; set; }

        public string ProductTitle { get; set; }
        public string? ProductDescription { get; set; } = null;

        public int? productPrice { get; set; } = null;

        public bool IsWithDiscount { get; set; } = false;

        public int? DiscountAmountOption { get; set; } = null;

        public string PictureSrc {  get; set; }

        public ProductCategury categury { get; set; }

    }
}
