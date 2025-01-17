using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// This Represents a Highlighted Product. 
    /// </summary>
    public class ProductShowcase : BaseModel
    {
        /// <summary>
        /// This represents the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// This is the product that is the products Showcase.
        /// </summary>
        public Product Product { get; set; }

    }
}
