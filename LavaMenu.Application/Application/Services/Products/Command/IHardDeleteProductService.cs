using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Products.Command
{
    public interface IHardDeleteProductService
    {
        public Task<bool> DeleteProductAsync(string ProductId);
    }
    public class HardDeleteProductService : IHardDeleteProductService
    {
        private readonly Idb _db;
        private readonly IworkFiles _workFile;
        public HardDeleteProductService(Idb db, IworkFiles workFile)
        {
            _db = db;
            _workFile = workFile;
        }

        public async Task<bool> DeleteProductAsync(string ProductId)
        {
            var Product = await _db.Products.FindAsync(ProductId);
            if (Product != null)
            {
                var resultFile = _workFile.DeleteFile(Product.PictureSrc);
                if (!resultFile) { return false; }
                _db.Products.Remove(Product);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
