using JricaStudioWebApi.Entities.Helpers;
using JricaStudioWebApi.Models.Dtos;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// This represents a product. 
    /// </summary>
    public class Product : BaseModel
    {
        /// <summary>
        /// The Title name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short Description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Cost of purchase.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The number of units that are available.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Represents the Category the product is in.
        /// </summary>
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// Represents the Upload of an image that is used. 
        /// </summary>
        public Guid ImageUploadId { get; set; }

        /// <summary>
        /// The Appointment Products that use this product.
        /// </summary>
        public ICollection<AppointmentProduct> AppointmentProducts { get; set; }

        /// <summary>
        /// The ImageUpload that this product uses.
        /// </summary>
        public ImageUpload ImageUpload { get; set; }

        /// <summary>
        /// The Category this product belongs to.
        /// </summary>
        public ProductCategory ProductCategory { get; set; }
    }
}
