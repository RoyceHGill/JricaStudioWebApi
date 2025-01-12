using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IImageUploadRepository
    {
        /// <summary>
        /// Creates and record of the uploaded image in the Database so it can be accessed later. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ImageUpload> AddImageUploadResult(UploadResultDto dto);

        Task<ImageUpload?> GetImageUploadResult(string fileName);
        Task<ImageUpload> GetServiceImageUploadResult(Guid id);
        Task<ImageUpload> GetProductImageUploadResult(Guid id);
        Task<ImageUpload> DeleteImageUploadResult(Guid id);
        Task<IEnumerable<ImageUpload>> GetAll();
    }
}
