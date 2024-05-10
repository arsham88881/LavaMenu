using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.constConfigure;
using LavaMenu.Application.Common.ResultDTO;

namespace LavaMenu.Application.Application.Services.Categuries.command
{
    public interface IAddProductToCategury
    {
        Task<GlobalResultDTO> AddAsync(List<string> ProductIds, string SubCateguryId);
    }
    public class AddProductToCategury : IAddProductToCategury
    {
        private readonly Idb _db;

        public AddProductToCategury(Idb db)
        {
            _db = db;
        }

        public async Task<GlobalResultDTO> AddAsync(List<string> ProductIds, string SubCateguryId)
        {
            int CateguryId = Convert.ToInt32(SubCateguryId);

            foreach (string ProductId in ProductIds)
            {
                var product = await _db.Products.FindAsync(ProductId);
                if (product == null)
                {
                    return new GlobalResultDTO
                    {
                        IsSuccess = false,
                        Message = "عملیات ناموفق",
                        Type = AlertType.Error
                    };
                }
                product.CateguryId = CateguryId;
                await _db.SaveChangesAsync();
            }
            return new GlobalResultDTO
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Type = AlertType.success
            };
        }
    }
}
