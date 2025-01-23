using JricaStudioWebAPI.Entities;
using JricaStudioSharedLibrary.Dtos;
using JricaStudioSharedLibrary.Dtos.Admin;

namespace JricaStudioWebAPI.Services.Contracts
{
    public interface IImageAccessService
    {
        Task<UploadResultDto> SaveImage(IFormFile image, string resoursePath);

        Task<string> LoadImage(Guid Id, string resourcePath);

        Task<Dictionary<Guid, string>> LoadServicesImages(IEnumerable<Service> services);

        Task<Dictionary<Guid, string>> LoadProductsImages(IEnumerable<Product> products);

        Task<ImageDeletionResultDto> DeleteImage(Guid id, string resourcePath);

        Task<int> RemoveUnusedImageFiles();

    }
}
