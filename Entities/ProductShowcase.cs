using JricaStudioWebAPI.Entities.Helpers;

namespace JricaStudioWebAPI.Entities
{
    public class ProductShowcase :BaseModel
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
