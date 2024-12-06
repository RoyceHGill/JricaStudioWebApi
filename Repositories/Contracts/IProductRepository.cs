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
        Task<IEnumerable<Product>> GetRandomProducts(int length);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetShowcaseProduct();
        Task<IEnumerable<Product>> GetFilteredProducts(ProductFilter productFilter);
        Task<IEnumerable<ProductCategory>> GetAllProductCategories();
        Task<Product> GetProduct(Guid id);
        Task<ProductCategory> GetProductCategory(Guid id);
        Task<IEnumerable<Product>> GetProductByCategory(Guid categoryId);
        Task<Product> AddProduct(AdminProductToAddDto dto);
        Task<Product> DeleteProduct(Guid id);
        Task<Product> UpdateProduct(Guid id, EditProductDto dto);
        Task<Product> UpdateProductQuantity(Guid Id, ProductUpdateQuantityDto productUpdateQuantityDto);
        Task<IEnumerable<Product>> SearchProducts(ProductFilterDto filter);
        Task<ProductCategory> AddProductCategory(AddProductCategoryDto dto);
        Task<ProductCategory> DeleteProductCategory(Guid id);

        Task<Product> UpdateProductImageUploadId(Guid id, UploadResultDto imageUpload);
        Task<Product> UpdateProductShowCase(UpdateProductShowcaseDto dto);

    }
}
