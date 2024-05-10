using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Customer.queries
{
    public interface IProductsFromCateguryService
    {
        public Task<List<Product>> GetProductsAsync(int CateguryId);
    }
    public class ProductsFromCateguryService : IProductsFromCateguryService
    {
        private readonly Idb _db;

        public ProductsFromCateguryService(Idb db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetProductsAsync(int CateguryId)
        {
            var result = await _db.Categories.Include(p => p.products)
                .SingleOrDefaultAsync(p => p.CateguryId == CateguryId);

            if (result == null)
            {
                return new List<Product> { };
            }

            List<Product> products = result.products.ToList();

            if (products == null)
            {
                products = new List<Product> { };
            }

            return products;
        }
    }
}
