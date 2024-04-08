using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.constConfigure;
using LavaMenu.Application.Common.File;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Categuries.query
{
    public interface IGetSingleCategury
    {
        public Task<GlobalResultDTO<ProductCategury>> Excute(string RequestID);
    }
    public class GetSingleCategury : IGetSingleCategury
    {
        private readonly Idb _db;
        private readonly ILogger<GetSingleCategury> _logger;

        public GetSingleCategury(Idb db, ILogger<GetSingleCategury> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<GlobalResultDTO<ProductCategury>> Excute(string RequestID)
        {
            var
                Id = Convert.ToInt64(RequestID);
            var findedCategury = await _db.Categories.FindAsync(Id);
            if (findedCategury == null)
            {
                _logger.Log(LogLevel.Error, "not found single categury");
                return await Task.FromResult(new GlobalResultDTO<ProductCategury>()
                {
                    IsSuccess = false,
                    Type = AlertType.Error,
                    Message = "یافت نشد!",
                    Value = null,
                });

            }

            _logger.Log(LogLevel.Information, "fined single categury sussfully");
            return await Task.FromResult(new GlobalResultDTO<ProductCategury>()
            {
                IsSuccess = true,
                Type = AlertType.success,
                Message = ".یافته شد",
                Value = findedCategury,
            });

        }
    }
}
