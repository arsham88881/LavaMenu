using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Domain.Entitys
{
    public class User
    {
        public long UserId { get; set; }
        public string? UserName { get; set; } = null;

        public string UserPhoneNumber { get; set; }

        public UserRole Role { get; set; }

    }

   
}
