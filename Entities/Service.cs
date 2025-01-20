using JricaStudioWebAPI.Entities.Helpers;

namespace JricaStudioWebAPI.Entities
{
    public class Service : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public Guid ImageUploadId { get; set; }
        public ImageUpload ImageUpload { get; set; }

        public ICollection<AppointmentService> AppointmentServices { get; set; }

    }
}
