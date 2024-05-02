using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Products.query
{
    public interface IGetAllProduct
    {
        public Task<List<Product>> GetAllAsync();
    }
    public class GetAllProduct : IGetAllProduct
    {
        private readonly Idb _db;
        public GetAllProduct(Idb db)
        {
            _db = db;
        }
        async Task<List<Product>> IGetAllProduct.GetAllAsync()
        {
            var response = await _db.Products.Include(p => p.categury).ToListAsync();

            return response;
        }
    }
}
