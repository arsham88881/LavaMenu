﻿using LavaMenu.Application.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Categuries.command
{
    public interface IChangeCateguryStatus
    {
        public Task<bool> Excute(long categuryID);
    }
    public class ChangeCateguryStatus : IChangeCateguryStatus
    {
        private readonly Idb _db;
        private readonly ILogger<ChangeCateguryStatus> _logger;
        public ChangeCateguryStatus(Idb db, ILogger<ChangeCateguryStatus> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> Excute(long categuryID)
        {

            try
            {
                var item = _db.Categories.Where(p => p.CateguryId == categuryID).FirstOrDefault();
                if (item != null)
                {
                    item.IsAvailable = !item.IsAvailable;

                    _logger.Log(LogLevel.Information, $"change status successfully for categuryName : {item.CateguryName}");
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"change status Faile ! exception: {ex.Message}");
                return await Task.FromResult(false);

            }


            throw new NotImplementedException();
        }
    }
}