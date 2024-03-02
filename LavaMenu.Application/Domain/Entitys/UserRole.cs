using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Domain.Entitys
{
    public class UserRole
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public long UserId { get; set; }

    }
}
