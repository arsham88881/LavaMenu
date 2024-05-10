using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Categuries.command
{
    public interface ISoftDeleteCateguryService
    {
        public Task<bool> DeleteCateguriesAsync(string CateguryId);
    }
    public class SoftDeleteCateguryService : ISoftDeleteCateguryService
    {
        private readonly Idb _db;
        private readonly IworkFiles _workfile;
        public SoftDeleteCateguryService(Idb db, IworkFiles workfile)
        {
            _db = db;
            _workfile = workfile;
        }

        public async Task<bool> DeleteCateguriesAsync(string CateguryId)
        {
            int id = Convert.ToInt32(CateguryId);
            var Categury = await _db.Categories.FindAsync(id);
            if (Categury == null)
            {
                return false;
            }
            var resultFile = _workfile.DeleteFile(Categury.SrcCategury);
            if (!resultFile) { return false; }
            _db.Categories.Remove(Categury);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
