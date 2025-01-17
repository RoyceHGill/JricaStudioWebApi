
using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Repositories.Contracts;
using JricaStudioWebApi.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using JricaStudioWebApi.Models.Constants;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;
using System.Collections.Immutable;
using System.Net;
using System.Runtime.CompilerServices;

namespace JricaStudioWebApi.Services
{
    /// <inheritdoc cref="IImageAccessService"/>
    public class ImageAccessService : IImageAccessService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageUploadRepository _imageUploadRepository;


        public ImageAccessService(IWebHostEnvironment webHostEnvironment, IImageUploadRepository uploadRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _imageUploadRepository = uploadRepository;

        }

        public async Task<ImageDeletionResultDto> DeleteImage(Guid id, string resourcePath)
        {
            int recordsAffected = 0;

            try
            {
                var imageUpload = await _imageUploadRepository.GetServiceImageUploadResult(id);
                var uploadResult = new UploadResultDto
                {
                    ContentType = imageUpload.ContentType,
                    StoredFileName = imageUpload.StoredFileName,
                    Filename = imageUpload.FileName,
                    Id = id
                };
                var path = Path.Combine("./wwwroot" + resourcePath, uploadResult.StoredFileName);

                File.Delete(path);
                recordsAffected++;

                var deletionResult = await _imageUploadRepository.DeleteImageUploadResult(uploadResult.Id);
                recordsAffected++;

                return new ImageDeletionResultDto
                {
                    RecordsAffected = recordsAffected,
                    DeletedUpload = uploadResult,
                    ErrorMessage = "None"
                };

            }
            catch (Exception e)
            {
                return new ImageDeletionResultDto
                {
                    RecordsAffected = recordsAffected,
                    DeletedUpload = default,
                    ErrorMessage = "None"
                };
                throw;
            }
        }

        public async Task<string> LoadImage(Guid id, string resourcePath)
        {
            try
            {

                ImageUpload uploadResult = new();
                if (resourcePath == FileResources.serviceImageFilePath)
                {
                    uploadResult = await _imageUploadRepository.GetServiceImageUploadResult(id);

                }
                if (resourcePath == FileResources.productImageFilePath)
                {
                    uploadResult = await _imageUploadRepository.GetProductImageUploadResult(id);

                }

                var path = Path.Combine("./wwwroot" + resourcePath, uploadResult.StoredFileName);

                string imageDataAsString;

                using (var memoryStream = new MemoryStream())
                {
                    using (var fileStream = File.OpenRead(path))
                    {

                        fileStream.CopyTo(memoryStream);

                        var data = memoryStream.ToArray();
                        imageDataAsString = $"data:{uploadResult.ContentType};base64,{Convert.ToBase64String(data)}";
                        fileStream.Close();
                    }
                    memoryStream.Close();
                }
                return imageDataAsString;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Dictionary<Guid, string>> LoadServicesImages(IEnumerable<Service> services)
        {
            var imageData = new Dictionary<Guid, string>();

            foreach (var service in services)
            {
                try
                {

                    if (imageData.Keys.Contains(service.Id))
                    {
                        continue;
                    }
                    var path = Path.Combine("./wwwroot" + FileResources.serviceImageFilePath, service.ImageUpload.StoredFileName);

                    string imageDataAsString;

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var fileStream = File.OpenRead(path))
                        {

                            await fileStream.CopyToAsync(memoryStream);
                            var data = memoryStream.ToArray();
                            imageDataAsString = $"data:{service.ImageUpload.ContentType};base64,{Convert.ToBase64String(data)}";
                            imageData.Add(service.Id, imageDataAsString);
                            fileStream.Flush();
                            fileStream.Close();
                        }
                        memoryStream.Flush();
                        memoryStream.Close();

                    }

                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return imageData;
        }

        public async Task<Dictionary<Guid, string>> LoadProductsImages(IEnumerable<Product> products)
        {
            var imageData = new Dictionary<Guid, string>();

            foreach (var product in products)
            {
                try
                {
                    var path = Path.Combine("./wwwroot" + FileResources.productImageFilePath, product.ImageUpload.StoredFileName);

                    string imageDataAsString;

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var fileStream = File.OpenRead(path))
                        {

                            await fileStream.CopyToAsync(memoryStream);
                            var data = memoryStream.ToArray();
                            imageDataAsString = $"data:{product.ImageUpload.ContentType};base64,{Convert.ToBase64String(data)}";
                            imageData.Add(product.Id, imageDataAsString);
                            fileStream.Flush();
                            fileStream.Close();
                        }
                        memoryStream.Flush();
                        memoryStream.Close();

                    }

                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return imageData;
        }

        public async Task<int> RemoveUnusedImageFiles()
        {
            try
            {
                var imageUploads = await _imageUploadRepository.GetAll();

                if (imageUploads == null || imageUploads.Count() == 0)
                {
                    return 0;
                }

                int count = 0;
                foreach (var item in imageUploads)
                {
                    if ((item.Services.Count() <= 0 || item.Services == null)
                        &&
                        (item.Products.Count() <= 0 || item.Products == null))
                    {
                        var path = FindImageFileLocation(item.StoredFileName);

                        if (path == string.Empty)
                        {
                            throw new Exception($"Unable to find image: {item.StoredFileName}");
                        }

                        var resourceUri = Path.Combine(path, item.StoredFileName);

                        File.Delete(resourceUri);
                        count++;

                        await _imageUploadRepository.DeleteImageUploadResult(item.Id);
                        count++;
                    }
                }

                return count;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static string ToPath(string folderName) => folderName switch
        {
            "ServiceImages" => FileResources.serviceImageFilePath,
            "ProductImages" => FileResources.productImageFilePath,
            _ => throw new ArgumentOutOfRangeException(folderName, "Not and acceptable Resource Folder")
        };

        public string FindImageFileLocation(string fileName)
        {
            string baseFolder = "./wwwroot";



            DirectoryInfo servicesDirectory = new DirectoryInfo(baseFolder + FileResources.serviceImageFilePath);

            if (servicesDirectory.EnumerateFiles().Any(f => f.Name == fileName))
            {
                return Path.Combine(baseFolder + ToPath("ServiceImages"));
            }

            DirectoryInfo productsDirectory = new DirectoryInfo(baseFolder + FileResources.productImageFilePath);

            if (productsDirectory.EnumerateFiles().Any(f => f.Name == fileName))
            {
                return Path.Combine(baseFolder + ToPath("ProductImages"));
            }

            return string.Empty;
        }

        public async Task<UploadResultDto> SaveImage(IFormFile image, string resoursePath)
        {
            try
            {
                var result = await _imageUploadRepository.GetImageUploadResult(image.FileName);

                if (result != null)
                {
                    DirectoryInfo directory = new DirectoryInfo("./wwwroot" + resoursePath);

                    if (directory.EnumerateFiles().Any(f => f.Name.Equals(result.StoredFileName)))
                    {
                        return new UploadResultDto()
                        {
                            Filename = result.FileName,
                            ContentType = result.ContentType,
                            StoredFileName = result.StoredFileName,
                            Id = result.Id,
                        };
                    }
                }

                var uploadResult = new UploadResultDto();
                string uniqeFileName;
                var filenameAtUpload = image.FileName;
                uploadResult.Filename = filenameAtUpload;
                var FileNameForDisplay = WebUtility.HtmlEncode(filenameAtUpload);

                uniqeFileName = Path.GetRandomFileName();
#if DEBUG
                var filePath = Path.Combine("./wwwroot" + resoursePath, uniqeFileName);
#else
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, resoursePath, uniqeFileName);
#endif



                await using FileStream fileStream = new(filePath, FileMode.Create);
                await image.CopyToAsync(fileStream);

                uploadResult.StoredFileName = uniqeFileName;
                uploadResult.ContentType = image.ContentType;

                var entity = await _imageUploadRepository.AddImageUploadResult(uploadResult);

                uploadResult.Id = entity.Id;

                return uploadResult;
            }
            catch (Exception)
            {
                return default;
            }

        }

    }
}
