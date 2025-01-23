using JricaStudioWebAPI.Entities.Helpers;
using JricaStudioSharedLibrary.Dtos;

namespace JricaStudioWebAPI.Entities
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid ImageUploadId { get; set; }
        public ICollection<AppointmentProduct> AppointmentProducts { get; set; }
        public ImageUpload ImageUpload { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
