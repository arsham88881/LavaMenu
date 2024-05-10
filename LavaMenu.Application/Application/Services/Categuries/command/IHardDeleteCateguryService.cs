using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.File;
using Microsoft.EntityFrameworkCore;

namespace LavaMenu.Application.Application.Services.Categuries.command
{
    public interface IHardDeleteCateguryService
    {
        public Task<bool> DeleteCateguryAsync(string categuryId);
    }
    public class HardDeleteCateguryService : IHardDeleteCateguryService
    {
        private readonly Idb _db;
        private readonly IworkFiles _workFile;
        public HardDeleteCateguryService(Idb db, IworkFiles workFile)
        {
            _db = db;
            _workFile = workFile;
        }

        public async Task<bool> DeleteCateguryAsync(string categuryId)
        {
            int id = Convert.ToInt32(categuryId);

            var Categury = await _db.Categories.FindAsync(id);
            var ChildProducts = await _db.Categories
                .Include(p => p.products)
                .SingleOrDefaultAsync(p => p.CateguryId == id);
            if (Categury != null)
            {
                _db.Categories.Remove(Categury);
                var resultFile =  _workFile.DeleteFile(Categury.SrcCategury);
                if(!resultFile)
                {
                    return false;
                }
                foreach(var item in ChildProducts.products)
                {
                    _workFile.DeleteFile(item.PictureSrc);
                }
                _db.Products.RemoveRange(ChildProducts.products);
                
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
