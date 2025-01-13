using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IImageUploadRepository
    {
        /// <summary>
        /// Creates and record of the uploaded image in the Database so it can be accessed later. 
        /// </summary>
        /// <param name="uploadDto">Data Transfer Object</param>
        /// <returns>returns the Data Base Entity</returns>
        Task<ImageUpload> AddImageUploadResult(UploadResultDto uploadDto);
        /// <summary>
        /// Given the filename for the image your to get the Upload result record. 
        /// </summary>
        /// <param name="fileName">The File name with extension</param>
        /// <returns>Returns a record of an image Upload from the Database</returns>
        Task<ImageUpload?> GetImageUploadResult(string fileName);
        /// <summary>
        /// Given the id for a Service, get the upload result record.
        /// </summary>
        /// <param name="serviceId">AService Id</param>
        /// <returns>Returns a record of an image upload from the database</returns>
        Task<ImageUpload> GetServiceImageUploadResult(Guid serviceId);
        /// <summary>
        /// Given the ID for a product, get the upload result record.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>returns a record of an image upload from the database</returns>
        Task<ImageUpload> GetProductImageUploadResult(Guid productId);
        /// <summary>
        /// Given the Id for an upload result, have the Upload result removed from the database.
        /// </summary>
        /// <param name="uploadId">GGuid representing the upload result</param>
        /// <returns>Returns a copy of the affected record</returns>
        Task<ImageUpload> DeleteImageUploadResult(Guid uploadId);
        /// <summary>
        /// Retrieve all upload results from the database.
        /// </summary>
        /// <returns>Collection of all upload result records from the database.</returns>
        Task<IEnumerable<ImageUpload>> GetAll();
    }
}
