using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.constConfigure;
using LavaMenu.Application.Common.File;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Categuries.command
{
    public interface IAddCategury
    {
        Task<GlobalResultDTO> Excute(AddCateguryRequestDTO request);
    }
    public class AddCategury : IAddCategury
    {
        private readonly Idb _db;
        private readonly ILogger<AddCategury> _logger;
        private readonly IworkFiles _WorkFile;
        public AddCategury(Idb db, ILogger<AddCategury> logger, IworkFiles workfile)
        {
            _WorkFile = workfile;
            _logger = logger;
            _db = db;
        }
        public async Task<GlobalResultDTO> Excute(AddCateguryRequestDTO request)
        {
            try
            {
                ProductCategury categury;
                categury = new ProductCategury()
                {
                    CateguryName = request.Name
                };
                if (_db.Categories.AsEnumerable().Contains(categury, new CateguryComparer()))
                {
                    return await Task<GlobalResultDTO>.FromResult(
                        new GlobalResultDTO() { IsSuccess = false, Message = "این دسته بندی موجود است", Type = AlertType.Info });
                }
                var loadFileResult = await Task<FileResultDTO>.FromResult(_WorkFile.UploadFile(request.Image));

                categury = new ProductCategury()
                {
                    CateguryName = request.Name,
                    SrcCategury = loadFileResult.FileAddress,
                };
                _db.Categories.Add(categury);
                await _db.SaveChangesAsync();
                return await Task<GlobalResultDTO>.FromResult(
                        new GlobalResultDTO() { IsSuccess = true, Message = "دسته بندی با موفقیت ثبت شد", Type = AlertType.success });


            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error {0}", ex);
                return await Task<GlobalResultDTO>.FromResult(new GlobalResultDTO()
                {
                    IsSuccess = false,
                    Message = "دسته بندی با موفقیت ثبت نشد",
                    Type = AlertType.Error

                });
            }

        }
    }
    internal class CateguryComparer : IEqualityComparer<ProductCategury>
    {
        public bool Equals(ProductCategury? x, ProductCategury? y)
        {
            if (x.CateguryName.Equals(y.CateguryName))
                return true;
            else
                return false;
        }

        public int GetHashCode([DisallowNull] ProductCategury obj)
        {
            return obj.GetHashCode();
        }
    }
}
