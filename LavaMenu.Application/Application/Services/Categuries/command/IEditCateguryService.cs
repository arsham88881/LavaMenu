using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Common.constConfigure;
using LavaMenu.Application.Common.File;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using Microsoft.Extensions.Logging;

namespace LavaMenu.Application.Application.Services.Categuries.command
{
    public interface IEditCateguryService
    {
        public Task<GlobalResultDTO> excute(string ID, CateguryRequestDTO request);
    }
    public class EditCateguryService : IEditCateguryService
    {
        private readonly IworkFiles _workFile;
        private readonly Idb _db;
        private readonly ILogger<EditCateguryService> _logger;
        public EditCateguryService(IworkFiles workFiles, Idb db, ILogger<EditCateguryService> logger)
        {
            _workFile = workFiles;
            _db = db;
            _logger = logger;
        }
        public async Task<GlobalResultDTO> excute(string ID, CateguryRequestDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ID))
                {
                    _logger.Log(LogLevel.Error, $"Edit categury Faile ! exception");
                    return await Task.FromResult(new GlobalResultDTO()
                    {
                        IsSuccess = false,
                        Message = "serverException",
                        Type = AlertType.Error,
                    });
                }

                int Id = Convert.ToInt32(ID);

                var item = _db.Categories.Find(Id);

                if (item == null)
                {
                    _logger.Log(LogLevel.Error, $"Edit categury Faile ! exception");
                    return await Task.FromResult(new GlobalResultDTO()
                    {
                        IsSuccess = false,
                        Message = "serverException",
                        Type = AlertType.Error,
                    });
                }
                if (request.Image == null)
                {
                    item.CateguryName = request.Name;
                }
                else
                {
                    item.CateguryName = request.Name;

                    var newFilePath = _workFile.EditFile(item.SrcCategury, request.Image,UploadFolderRoot.CateguryFolderRoot);

                    item.SrcCategury = newFilePath.FileAddress;
                }

                _db.SaveChanges();

                _logger.Log(LogLevel.Information, $"Edit categury successfully");

                return await Task.FromResult(new GlobalResultDTO()
                {
                    IsSuccess = true,
                    Message = "تغییرات با موفقیت ثبت شد",
                    Type = AlertType.success,
                });
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"change status Faile ! exception: {ex.Message}");
                return await Task.FromResult(new GlobalResultDTO()
                {
                    IsSuccess = false,
                    Message = "serverException",
                    Type = AlertType.Error,
                });

            }

        }
    }
}
