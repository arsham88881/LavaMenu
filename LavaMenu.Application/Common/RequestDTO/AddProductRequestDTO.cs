using LavaMenu.Application.Domain.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.RequestDTO
{
    public record AddProductRequestDTO : IProduct
    {
        public string ProductTitle { get; set; }
        public string? ProductDescription { get; set; }
        public int? productPrice { get; set; }
        public ProductCategury categury { get; set; }
        public IFormFile Image { get; set; }

    }
}
