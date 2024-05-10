using LavaMenu.Application.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Products.query
{
    public interface IGetProductWithNullCateguryService
    {
        public Task<List<ProductDTO>> GetListAsync();
    }
    public class GetProductWithNullCateguryService : IGetProductWithNullCateguryService
    {
        private readonly Idb _db;

        public GetProductWithNullCateguryService(Idb db)
        {
            _db = db;
        }

        public async Task<List<ProductDTO>> GetListAsync()
        {
            List<ProductDTO> ResultList = await _db.Products.Where(p => p.CateguryId == null)
                .Select(p => new ProductDTO { Id = p.ProductId, Name = p.ProductTitle, PictureSrc = p.PictureSrc })
                .ToListAsync();

            return ResultList;
        }
    }
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PictureSrc { get; set; }
    }
}
