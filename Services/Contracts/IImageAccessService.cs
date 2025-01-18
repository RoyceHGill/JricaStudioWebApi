using JricaStudioWebApi.Entities;
using JricaStudioSharedLibrary.Dtos;
using JricaStudioSharedLibrary.Dtos.Admin;

namespace JricaStudioWebApi.Services.Contracts
{
    /// <summary>
    /// A service Responsible for managing the uploads of images to the server. 
    /// </summary>
    public interface IImageAccessService
    {
        /// <summary>
        /// Save an image to the server.
        /// </summary>
        /// <param name="image">File Data.</param>
        /// <param name="resoursePath">Where is the image being saved.</param>
        /// <returns>Upload Details.</returns>
        Task<UploadResultDto> SaveImage(IFormFile image, string resoursePath);

        /// <summary>
        /// Load and image from the server.
        /// </summary>
        /// <param name="Id">The image upload Id. </param>
        /// <param name="resourcePath">Where to find the Image </param>
        /// <returns>The Image data.</returns>
        Task<string> LoadImage(Guid Id, string resourcePath);

        /// <summary>
        /// Load a collection of image data for a collection of services.
        /// </summary>
        /// <param name="services">A collection of service to fine images for.</param>
        /// <returns>Dictionary of Service ID and the Image data that belongs to each.</returns>
        Task<Dictionary<Guid, string>> LoadServicesImages(IEnumerable<Service> services);

        /// <summary>
        /// Load a collection of image data for a collection of products.
        /// </summary>
        /// <param name="products">A collection of products to fine images for.</param>
        /// <returns>Dictionary of Product IDs as keys and the Image data that belongs to each.</returns>
        Task<Dictionary<Guid, string>> LoadProductsImages(IEnumerable<Product> products);

        /// <summary>
        /// Remove an image from the server. 
        /// </summary>
        /// <param name="id">The Image upload Id</param>
        /// <param name="resourcePath">Where to find the image.</param>
        /// <returns>The result of the request.</returns>
        Task<ImageDeletionResultDto> DeleteImage(Guid id, string resourcePath);

        /// <summary>
        /// Removes Image files that are not being used by any image upload records.
        /// </summary>
        /// <returns>number of affects records</returns>
        Task<int> RemoveUnusedImageFiles();

    }
}
