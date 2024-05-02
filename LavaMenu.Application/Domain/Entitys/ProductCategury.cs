﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Domain.Entitys
{
    public class ProductCategury
    {
        public int CateguryId { get; set; }
        public string CateguryName { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string SrcCategury {  get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
