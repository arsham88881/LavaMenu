using LavaMenu.Application.Common.ResultDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;

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
                var AddressFolderRoot = Path.Combine(_environment.WebRootPath, address);

                var existance = System.IO.File.Exists(AddressFolderRoot);
                if (!existance)
                {
                    throw new DirectoryNotFoundException();
                }
                System.IO.File.Delete(AddressFolderRoot);
                
                _logger.Log(LogLevel.Information, $"successful Delete image at time:  {DateTime.UtcNow}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"faile Delete image error: {ex} at time:  {DateTime.UtcNow}");
                return false;
            }
        }

        public FileResultDTO EditFile(string address, IFormFile file)
        {
            try
            {
                var AddressFolderRoot = Path.Combine(_environment.WebRootPath, address);

                var existance = System.IO.File.Exists(AddressFolderRoot);
                if (!existance)
                {
                    throw new DirectoryNotFoundException();
                }
                System.IO.File.Delete(AddressFolderRoot);

                if (file == null || file.Length == 0)
                {
                    return new FileResultDTO()
                    {
                        FileAddress = null,
                        IsSuccess = false,
                    };
                }

                var result = UploadFile(file);

                _logger.Log(LogLevel.Information, $"successful add image => name: {file.FileName} , time : {DateTime.UtcNow}");

                return result;
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
                var AddressFolderRoot = Path.Combine(_environment.WebRootPath, address);

                var existance = System.IO.File.Exists(AddressFolderRoot);
                if (!existance)
                {
                    throw new DirectoryNotFoundException();
                }
                System.IO.File.Delete(AddressFolderRoot);

                if (file == null || file.Length == 0)
                {
                    return await Task.FromResult(new FileResultDTO()
                    {
                        FileAddress = null,
                        IsSuccess = false,
                    });
                }
                var result = UploadFileAsync(file);

                _logger.Log(LogLevel.Information, $"successful Edit image => name: {file.FileName} , time : {DateTime.UtcNow}");

                return await result;


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
                if (file != null)
                {
                    string folderLocation = @"images\ProductImages\";
                    var uploadFolderRoot = Path.Combine(_environment.WebRootPath, folderLocation);
                    if (!Directory.Exists(uploadFolderRoot))
                    {
                        Directory.CreateDirectory(uploadFolderRoot);
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
                    var filePath = Path.Combine(uploadFolderRoot, FileName);

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
