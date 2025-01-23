using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using JricaStudioSharedLibrary.Dtos;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    /// <inheritdoc cref="IImageUploadRepository"/>
    public class ImageUploadSqliteRepository : IImageUploadRepository
    {
        private readonly JaysLashesDbContext _dbContext;
        public ImageUploadSqliteRepository(JaysLashesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ImageUpload> AddImageUploadResult(UploadResultDto dto)
        {
            if (_dbContext.ImageUploads.Any(i => i.FileName.Equals(dto.Filename)))
            {
                return await _dbContext.ImageUploads.FirstAsync(i => i.FileName.Equals(dto.Filename));
            }

            var result = _dbContext.ImageUploads.Add(new ImageUpload()
            {
                ContentType = dto.ContentType,
                FileName = dto.Filename,
                StoredFileName = dto.StoredFileName
            });

            await _dbContext.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<ImageUpload> DeleteImageUploadResult(Guid id)
        {
            var imageUpload = _dbContext.ImageUploads.SingleOrDefault(i => i.Id == id);

            var result = _dbContext.ImageUploads.Remove(imageUpload);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<ImageUpload>> GetAll()
        {
            return await _dbContext.ImageUploads.Include(i => i.Services).Include(i => i.Products).ToListAsync();
        }

        public async Task<ImageUpload?> GetImageUploadResult(string fileName)
        {
            return await _dbContext.ImageUploads.FirstOrDefaultAsync(i => i.FileName == fileName);
        }

        public async Task<ImageUpload> GetServiceImageUploadResult(Guid id)
        {
            var service = await _dbContext.Services.Include(s => s.ImageUpload).SingleAsync(i => i.Id == id);
            return service.ImageUpload;
        }

        public async Task<ImageUpload> GetProductImageUploadResult(Guid id)
        {
            var product = await _dbContext.Products.Include(s => s.ImageUpload).SingleAsync(i => i.Id == id);
            return product.ImageUpload;
        }

    }
}
