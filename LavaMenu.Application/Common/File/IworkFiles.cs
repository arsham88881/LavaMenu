using LavaMenu.Application.Common.ResultDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.File
{
    public interface IworkFiles
    {
        FileResultDTO UploadFile(IFormFile file);
        FileResultDTO EditFile(string address, IFormFile file);

        Task<FileResultDTO> UploadFileAsync(IFormFile file);
        Task<FileResultDTO> EditFileAsnyc(string address, IFormFile file);

        bool DeleteFile(string address);

    }
    public class ImageFiles : IworkFiles
    {
        private readonly ILogger<ImageFiles> _logger;
        private readonly IHostingEnvironment _environment;
        public ImageFiles(ILogger<ImageFiles> logger, IHostingEnvironment environment)
        {
            _environment = environment;
            _logger = logger;
        }
        public bool DeleteFile(string address)
        {
            try
            {
                Directory.Delete(address);
                _logger.Log(LogLevel.Information, $"successful Delete image at time:  {DateTime.UtcNow}");
                return true;
            }
            catch( Exception ex )
            {
                _logger.Log(LogLevel.Error, $"faile Delete image error: {ex} at time:  {DateTime.UtcNow}");
                return false;
            }
        }

        public FileResultDTO EditFile(string address, IFormFile file)
        {
            try
            {

                if (!Directory.Exists(address))
                {
                    throw new DirectoryNotFoundException();
                }
                Directory.Delete(address);

                if (file == null || file.Length == 0)
                {
                    return new FileResultDTO()
                    {
                        FileAddress = null,
                        IsSuccess = false,
                    };
                }
                var fileName = DateTime.Now.Ticks.ToString() + file.FileName;

                string folderLocation = @"images\ProductImages\";
                var oploadFolderRoot = Path.Combine(folderLocation, fileName);

                using (FileStream stream = new FileStream(oploadFolderRoot, FileMode.OpenOrCreate))
                {
                    file.CopyTo(stream);
                }
                _logger.Log(LogLevel.Information, $"successful Edit image => name: {fileName} , time : {DateTime.UtcNow}");

                return new FileResultDTO()
                {
                    FileAddress = oploadFolderRoot,
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"faile Edit image => exception: {ex} , time : {DateTime.UtcNow}");

            }

            return new FileResultDTO()
            {
                FileAddress = null,
                IsSuccess = false,
            };
        }

        public async Task<FileResultDTO> EditFileAsnyc(string address, IFormFile file)
        {
            try
            {

                if (!Directory.Exists(address))
                {
                    throw new DirectoryNotFoundException();
                }
                Directory.Delete(address);

                if (file == null || file.Length == 0)
                {
                    return await Task.FromResult(new FileResultDTO()
                    {
                        FileAddress = null,
                        IsSuccess = false,
                    });
                }
                var fileName = DateTime.Now.Ticks.ToString() + file.FileName;

                string folderLocation = @"images\ProductImages\";
                var oploadFolderRoot = Path.Combine(folderLocation, fileName);

                using (FileStream stream = new FileStream(oploadFolderRoot, FileMode.OpenOrCreate))
                {
                    file.CopyTo(stream);
                }
                _logger.Log(LogLevel.Information, $"successful Edit image => name: {fileName} , time : {DateTime.UtcNow}");

                return await Task.FromResult(new FileResultDTO()
                {
                    FileAddress = oploadFolderRoot,
                    IsSuccess = true,
                });
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"faile Edit image => exception: {ex} , time : {DateTime.UtcNow}");

            }

            return await Task.FromResult(new FileResultDTO()
            {
                FileAddress = null,
                IsSuccess = false,
            });
        }

        public FileResultDTO UploadFile(IFormFile file)
        {
            try
            {
                string folderLocation = @"images\ProductImages\";
                var oploadFolderRoot = Path.Combine(_environment.WebRootPath, folderLocation);
                if (!Directory.Exists(oploadFolderRoot))
                {
                    Directory.CreateDirectory(oploadFolderRoot);
                }

                if (file == null || file.Length == 0)
                {
                    return new FileResultDTO()
                    {
                        FileAddress = null,
                        IsSuccess = false,
                    };
                }

                string FileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(oploadFolderRoot, FileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                _logger.Log(LogLevel.Information, $"successful add image => name: {FileName} , time : {DateTime.UtcNow}");

                return new FileResultDTO()
                {
                    FileAddress = folderLocation + FileName,
                    IsSuccess = true,
                };
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, $"faile add image => exception : {e}, time : {DateTime.UtcNow}");
            }
            return new FileResultDTO()
            {
                FileAddress = null,
                IsSuccess = false,
            };
        }

        public async Task<FileResultDTO> UploadFileAsync(IFormFile file)
        {
            try
            {
                string folderLocation = @"images\ProductImages\";
                var oploadFolderRoot = Path.Combine(_environment.WebRootPath, folderLocation);
                if (!Directory.Exists(oploadFolderRoot))
                {
                    Directory.CreateDirectory(oploadFolderRoot);
                }

                if (file == null || file.Length == 0)
                {
                    return await Task.FromResult(new FileResultDTO()
                    {
                        FileAddress = null,
                        IsSuccess = false,
                    });
                }

                string FileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(oploadFolderRoot, FileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                _logger.Log(LogLevel.Information, $"successful add image => name: {FileName} , time : {DateTime.UtcNow}");

                return await Task.FromResult(new FileResultDTO()
                {
                    FileAddress = folderLocation + FileName,
                    IsSuccess = true,
                });
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, $"faile add image => exception : {e}, time : {DateTime.UtcNow}");
            }
            return await Task.FromResult(new FileResultDTO()
            {
                FileAddress = null,
                IsSuccess = false,
            });
        }
    }
}
