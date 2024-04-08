using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.RequestDTO
{
    public class CateguryRequestDTO
    {
        public string Name { get; set; }
        
        public IFormFile? Image { get; set; } = null;
    }
}
