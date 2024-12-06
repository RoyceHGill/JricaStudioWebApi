using JricaStudioWebApi.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IImageUploadRepository
    {
        Task<ImageUpload> AddImageUploadResult(UploadResultDto dto);
        Task<ImageUpload?> GetImageUploadResult(string fileName);
        Task<ImageUpload> GetServiceImageUploadResult(Guid id);
        Task<ImageUpload> GetProductImageUploadResult(Guid id);
        Task<ImageUpload> UpdateImageUploadResult(Guid id, UploadResultDto dto);
        Task<ImageUpload> DeleteImageUploadResult(Guid id);
        Task<IEnumerable<ImageUpload>> GetAll();
    }
}
