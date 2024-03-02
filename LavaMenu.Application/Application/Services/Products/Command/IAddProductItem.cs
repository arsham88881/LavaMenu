using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.File;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Products.Command
{
    public interface IAddProductItem
    {
        Task<GlobalResultDTO> Excute(AddProductRequestDTO request);
    }
    public class AddProductItem : IAddProductItem
    {
        private readonly ILogger<AddProductItem> _logger;
        private readonly Idb _db;
        private readonly IworkFiles _fileWork;
        public AddProductItem(ILogger<AddProductItem> logger, Idb db, IworkFiles FileWork)
        {
            _logger = logger;
            _db = db;
            _fileWork = FileWork;
        }
        public async Task<GlobalResultDTO> Excute(AddProductRequestDTO request)
        {

            try
            {
                Product obj;
                obj = new Product()
                {
                    categury = request.categury,
                    ProductTitle = request.ProductTitle
                };
                if (_db.Products.Contains(obj, new productComaparer()))
                {
                    return await Task<GlobalResultDTO>.FromResult(new GlobalResultDTO()
                    {
                        IsSuccess = false,
                        Message = "این محصول قبلا وارد شده است"
                    });
                }
                var UploadFileResult = await Task<FileResultDTO>.FromResult(_fileWork.UploadFile(request.Image));

                if (UploadFileResult.IsSuccess)
                {
                    var objcategury = await Task<ProductCategury>.FromResult(_db.Categories.FirstOrDefault(item => item.CateguryId == request.categury.CateguryId));
                    obj = new Product()
                    {
                        ProductTitle = request.ProductTitle,
                        ProductDescription = request.ProductDescription,
                        categury = objcategury,
                        productPrice = request.productPrice,
                        PictureSrc = UploadFileResult.FileAddress
                    };
                    _db.Products.Add(obj);
                    await _db.SaveChangesAsync();
                }
                return await Task<GlobalResultDTO>.FromResult(new GlobalResultDTO()
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت ثبت شد"
                });
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error {0}", ex);
                return await Task<GlobalResultDTO>.FromResult(new GlobalResultDTO()
                {
                    IsSuccess = false,
                    Message = "محصول با موفقیت ثبت نشد خطای ثبت"
                });

            }

        }
    }
    internal class productComaparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (x.categury.CateguryId.Equals(y.categury.CateguryId) && x.ProductTitle.Equals(y.ProductTitle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.GetHashCode();
        }
    }
}
