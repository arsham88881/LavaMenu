using LavaMenu.Application.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Products.Command
{
    public interface IChangeProductStatus
    {
        public Task<bool> ActivationAsync(string productId);
    }
    public class ChangeProductStatus : IChangeProductStatus
    {
        private readonly Idb _db;

        public ChangeProductStatus(Idb db)
        {
            _db = db;
        }
        public async Task<bool> ActivationAsync(string productId)
        {
            if(productId == null)
            {
                return false;
            }
            var TargetProduct = await _db.Products.FindAsync(productId);

            TargetProduct.IsActive = !TargetProduct.IsActive;

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
