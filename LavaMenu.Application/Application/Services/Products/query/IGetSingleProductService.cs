using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Products.query
{
    public interface IGetSingleProductService
    {
        public Task<Product> GetProductAsync(string productId);
    }
    public class GetSingleProductService : IGetSingleProductService
    {
        private readonly Idb _db;

        public GetSingleProductService(Idb db)
        {
            _db = db;
        }
        public async Task<Product> GetProductAsync(string productId)
        {
            var Result = await _db.Products.FindAsync(productId);
            if(Result == null)
            {
                return null;
            }
            return Result;
        }
    }
}
