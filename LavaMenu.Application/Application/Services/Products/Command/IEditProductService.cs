using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.constConfigure;
using LavaMenu.Application.Common.File;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.AspNetCore.Http;

namespace LavaMenu.Application.Application.Services.Products.Command
{
    public interface IEditProductService
    {
        public Task<GlobalResultDTO> EditProductAsync(Product model, IFormFile newFile = null);
    }
    public class EditProductService : IEditProductService
    {
        private readonly Idb _db;
        private readonly IworkFiles _workFiles;

        public EditProductService(IworkFiles workFiles, Idb db)
        {
            _workFiles = workFiles;
            _db = db;
        }

        public async Task<GlobalResultDTO> EditProductAsync(Product model, IFormFile newFile = null)
        {
            if (model == null) throw new ArgumentNullException("model");

            var OldProduct = await _db.Products.FindAsync(model.ProductId);
            if (OldProduct == null)
            {
                return new GlobalResultDTO()
                {
                    IsSuccess = false,
                    Type = AlertType.Error,
                    Message = "تغییرات ناموفق"
                };
            }
            if (newFile != null)
            {
                var changeImageresult = await _workFiles.EditFileAsnyc(OldProduct.PictureSrc, newFile, UploadFolderRoot.ProductFolderRoot);

                OldProduct.CateguryId = model.CateguryId;
                OldProduct.ProductTitle = model.ProductTitle;
                OldProduct.productPrice = model.productPrice;
                OldProduct.PictureSrc = ((changeImageresult.IsSuccess) ? changeImageresult.FileAddress : "");
                OldProduct.ProductDescription = model.ProductDescription;
                OldProduct.IsWithDiscount = model.IsWithDiscount;
                OldProduct.DiscountAmountOption = model.DiscountAmountOption;

                await _db.SaveChangesAsync();

                return new GlobalResultDTO()
                {
                    IsSuccess = true,
                    Type = AlertType.success,
                    Message = "تغییرات با موفقیت ثبت شد"
                };
            }
            else
            {
                OldProduct.CateguryId = model.CateguryId;
                OldProduct.ProductTitle = model.ProductTitle;
                OldProduct.productPrice = model.productPrice;
                OldProduct.ProductDescription = model.ProductDescription;
                OldProduct.IsWithDiscount = model.IsWithDiscount;
                OldProduct.DiscountAmountOption = model.DiscountAmountOption; //price after discount

                await _db.SaveChangesAsync();

                return new GlobalResultDTO()
                {
                    IsSuccess = true,
                    Type = AlertType.success,
                    Message = "تغییرات با موفقیت ثبت شد"
                };
            }
        }
    }
}
