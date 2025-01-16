using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Entities.Filters;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Models.Dtos;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IProductRepository
    {

        #region Create
        /// <summary>
        /// Create a new Product in the database.
        /// </summary>
        /// <param name="dto">New product details.</param>
        /// <returns>The created product.</returns>
        Task<Product> AddProduct(AdminProductToAddDto dto);
        /// <summary>
        /// Add a new product Category. 
        /// </summary>
        /// <param name="dto">Category Details</param>
        /// <returns>Created category</returns>
        Task<ProductCategory> AddProductCategory(AddProductCategoryDto dto);
        #endregion

        #region Read
        /// <summary>
        /// Receive the specified number of random products, upto the number of total products in the database.
        /// </summary>
        /// <param name="length">number of random products</param>
        /// <returns>Random products upto the number specified.</returns>
        Task<IEnumerable<Product>> GetRandomProducts(int length);

        /// <summary>
        /// Get all products. 
        /// </summary>
        /// <returns>All products details.</returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// Get the product that is the showcase product.
        /// </summary>
        /// <returns>The highlighted product.</returns>
        Task<Product> GetShowcaseProduct();

        /// <summary>
        /// Search products using the filter.
        /// </summary>
        /// <param name="productFilter">Collection of parameters for filtering result.</param>
        /// <returns>Products that have a exact or partial match to the filter objects.</returns>
        Task<IEnumerable<Product>> GetFilteredProducts(ProductFilter productFilter);

        /// <summary>
        /// Get all product Categories.
        /// </summary>
        /// <returns>Product Categories.</returns>
        Task<IEnumerable<ProductCategory>> GetAllProductCategories();

        /// <summary>
        /// Get a product by Id. 
        /// </summary>
        /// <param name="id">A products Id</param>
        /// <returns>The products Details</returns>
        Task<Product> GetProduct(Guid id);

        /// <summary>
        /// Get a specific Product Category
        /// </summary>
        /// <param name="id">Product Category Id</param>
        /// <returns>The product Category details.</returns>
        Task<ProductCategory> GetProductCategory(Guid id);

        /// <summary>
        /// Get all products that have given category
        /// </summary>
        /// <param name="categoryId">ID representing  the Category</param>
        /// <returns>All product with the came category.</returns>
        Task<IEnumerable<Product>> GetProductByCategory(Guid categoryId);
        /// <summary>
        /// Query the database with a filter to get back products that match or partially match your search.
        /// </summary>
        /// <param name="filter">query details</param>
        /// <returns>collection of matching products.</returns>
        Task<IEnumerable<Product>> SearchProducts(ProductFilterDto filter);
        #endregion

        #region Update
        /// <summary>
        /// Change the details of a product.
        /// </summary>
        /// <param name="id">The id for the product you want to change.</param>
        /// <param name="dto">The new details of the product.</param>
        /// <returns>The updated product.</returns>
        Task<Product> UpdateProduct(Guid id, EditProductDto dto);

        /// <summary>
        /// Update the total product Quantity.
        /// </summary>
        /// <param name="Id">Id for the product</param>
        /// <param name="productUpdateQuantityDto">New quantity.</param>
        /// <returns>The updated Product.</returns>
        Task<Product> UpdateProductQuantity(Guid Id, ProductUpdateQuantityDto productUpdateQuantityDto);

        /// <summary>
        /// Update the image upload details for the product.
        /// </summary>
        /// <param name="id">ID of the product you want to change.</param>
        /// <param name="imageUpload">The new Image details.</param>
        /// <returns>The updated product.</returns>
        Task<Product> UpdateProductImageUploadId(Guid id, UploadResultDto imageUpload);

        /// <summary>
        /// Update the product showcase.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Product> UpdateProductShowCase(UpdateProductShowcaseDto dto);
        #endregion

        #region Delete
        /// <summary>
        /// Remove a product from that database.
        /// </summary>
        /// <param name="id">The Id of the product.</param>
        /// <returns>The removed product.</returns>
        Task<Product> DeleteProduct(Guid id);

        /// <summary>
        /// Remove a Category from the database. 
        /// </summary>
        /// <param name="id">The Id of the Category</param>
        /// <returns>The product Category removed.</returns>
        Task<ProductCategory> DeleteProductCategory(Guid id);
        #endregion
        
    }
}
