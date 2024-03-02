using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.RequestDTO
{
    public record AddCateguryRequestDTO
    {
        public string Name { get; set; } 
        public IFormFile Image { get; set; } 
    }
}
