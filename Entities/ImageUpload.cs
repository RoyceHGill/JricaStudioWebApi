using JricaStudioWebApi.Entities.Helpers;
using NuGet.Protocol.Plugins;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents the upload of an image. 
    /// </summary>
    public class ImageUpload : BaseModel
    {
        /// <summary>
        /// The File name at upload.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The File name as it is stored on the serve.
        /// </summary>
        public string StoredFileName { get; set; }

        /// <summary>
        /// The Type of media being stored.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The Services that use the Image.
        /// </summary>
        public IEnumerable<Service>? Services { get; set; }

        /// <summary>
        /// The Products that use the Image.
        /// </summary>
        public IEnumerable<Product>? Products { get; set; }
    }
}
