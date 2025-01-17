using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// This Represents a Service.
    /// </summary>
    public class Service : BaseModel
    {
        /// <summary>
        /// This is the Id of the Service
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The short title of the Service.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the Service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The amount of time the service requires to complete.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The amount of Currency required for the products to be performed.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Represents the Category the Service belongs to.
        /// </summary>
        public Guid ServiceCategoryId { get; set; }

        /// <summary>
        /// Represents the Image Upload the Service used to display an image.
        /// </summary>
        public Guid ImageUploadId { get; set; }

        /// <summary>
        /// The image Upload details.
        /// </summary>
        public ImageUpload ImageUpload { get; set; }

        /// <summary>
        /// The Appointment Services that use this Service. 
        /// </summary>
        public ICollection<AppointmentService> AppointmentServices { get; set; }

    }
}
