using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    public class ProductShowcase :BaseModel
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
