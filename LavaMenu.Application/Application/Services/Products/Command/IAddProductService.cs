using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.constConfigure;
using LavaMenu.Application.Common.File;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.Application.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Products.Command
{
    public interface IAddProductService
    {
        public Task<GlobalResultDTO> PostSingleProdut(AddProductRequestDTO model);
    }
    public class AddProductService : IAddProductService
    {
        private readonly IworkFiles _WorkFile;
        private readonly Idb _db;
        public AddProductService(IworkFiles workFile, Idb db)
        {
            _WorkFile = workFile;
            _db = db;
        }
        public async Task<GlobalResultDTO> PostSingleProdut(AddProductRequestDTO model)
        {
            var imageUploadResult  = await _WorkFile.UploadFileAsync(model.Image,UploadFolderRoot.ProductFolderRoot);
            var categury = _db.Categories.Find(model.CateguryId);
            if (!imageUploadResult.IsSuccess || categury == null)
            {
                return new GlobalResultDTO()
                {
                    IsSuccess = false,
                    Message = "محصول با موفقیت ثبت نشد",
                    Type = AlertType.Error
                };
            }

            Product newProduct = new Product()
            {
                ProductId = Guid.NewGuid().ToString(),
                ProductTitle = model.ProductTitle,
                ProductDescription = model.ProductDescription,
                productPrice = model.productPrice,
                IsWithDiscount = model.IsWithDiscount,
                DiscountAmountOption = model.AfterDiscountPrice,
                IsActive = true,
                PictureSrc = imageUploadResult.FileAddress??"not found",
                CateguryId = model.CateguryId,
                categury = categury
            };
            await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();

            return new GlobalResultDTO()
            {
                IsSuccess = true,
                Message = "محصول با موفقیت ثبت شد"
            };

        }
    }
}
