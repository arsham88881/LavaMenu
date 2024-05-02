using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Domain.Entitys
{
    
    public class Product 
    {
        public string ProductId { get; set; }

        public string ProductTitle { get; set; }
        public string? ProductDescription { get; set; } = null;
        public int? productPrice { get; set; } = null;
        public bool IsWithDiscount { get; set; } = false;
        public int? DiscountAmountOption { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public string PictureSrc {  get; set; }

        public int CateguryId {  get; set; }
        public virtual ProductCategury categury { get; set; }

    }
}
