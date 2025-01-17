using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents a Product Category.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// The Id in the database.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Name of the Category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The collection of products that belong to this category.
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
    }

}
