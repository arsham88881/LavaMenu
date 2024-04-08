using LavaMenu.Application.Application.Interfaces;
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
        public Task<bool> Excute(string categuryID);
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
        public async Task<bool> Excute(string categuryID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categuryID))
                {
                    return await Task.FromResult(false);
                }

                long ID = Convert.ToInt64(categuryID);

                var item = _db.Categories.Find(ID);

                if (item == null)
                {
                    return await Task.FromResult(false);
                }

                item.IsAvailable = !item.IsAvailable;

                _db.SaveChanges();

                _logger.Log(LogLevel.Information, $"change status successfully for categuryName : {item.CateguryName}");
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"change status Faile ! exception: {ex.Message}");
                return await Task.FromResult(false);

            }

        }
    }
}
