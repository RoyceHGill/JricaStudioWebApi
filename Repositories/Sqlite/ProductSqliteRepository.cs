using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Entities.Filters;
using JricaStudioWebAPI.Extentions;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using JricaStudioWebAPI.Models.Dtos;
using NuGet.Protocol.Core.Types;
using SQLitePCL;
using JricaStudioWebAPI.Models.Dtos.Admin;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using JricaStudioWebAPI.Models.Dtos.Admin;
using Microsoft.AspNetCore.Http.HttpResults;
using JricaStudioWebAPI.Models.Dtos;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    /// <inheritdoc cref="IProductRepository"/>
    public class ProductSqLiteRepository : IProductRepository
    {
        private readonly JaysLashesDbContext _dbContext;

        public ProductSqLiteRepository(JaysLashesDbContext jaysLashesDbContext)
        {
            _dbContext = jaysLashesDbContext;
        }


        public async Task<Product> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);

                if (product == null)
                {
                    return default;
                }

                var result = _dbContext.Products.Remove(product);

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
        {
            return await _dbContext.ProductCategories.AsNoTracking().ToArrayAsync();
        }

        public async Task<ProductCategory> GetProductCategory(Guid id)
        {
            return await _dbContext.ProductCategories.SingleOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.Products.Include(p => p.ProductCategory).Include(p => p.ImageUpload).AsNoTracking().ToArrayAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            try
            {
                var product = await _dbContext.Products.Include(p => p.ProductCategory).Include(p => p.ImageUpload).SingleOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return product;
                }

                return default;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<IEnumerable<Product>> GetFilteredProducts(ProductFilter productFilter)
        {
            IQueryable<Product> query = _dbContext.Products;

            if (productFilter.Id != Guid.Empty)
            {
                query = query.Where(p => p.Id == productFilter.Id);
            }
            if (productFilter.NamePartial != string.Empty)
            {
                query = query.Where(p => p.Name.Contains(productFilter.NamePartial));
            }
            if (productFilter.DescriptionPartial != string.Empty)
            {
                query = query.Where(p => p.Description.Contains(productFilter.DescriptionPartial));
            }
            if (productFilter.PriceMax != decimal.Zero)
            {
                query = query.Where(p => p.Price <= productFilter.PriceMax);
            }
            if (productFilter.PriceMin != decimal.Zero)
            {
                query = query.Where(p => p.Price >= productFilter.PriceMin);
            }

            var products = await query.AsNoTracking().ToListAsync();

            return products;
        }

        public async Task<Product> UpdateProduct(Guid id, EditProductDto productUpdate)
        {
            try
            {
                var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

                if (product == null)
                {
                    return default;
                }

                product.Name = productUpdate.Name;
                product.Description = productUpdate.Description;
                product.Price = productUpdate.Price;
                product.Quantity = productUpdate.Quantity;
                product.ImageUploadId = productUpdate.ImageUploadId;
                product.ProductCategoryId = productUpdate.ProductCategoryid;

                var result = _dbContext.Update(product);

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Product> UpdateProductQuantity(Guid id, ProductUpdateQuantityDto quantityUpdate)
        {

            var product = await _dbContext.Products.SingleAsync(p => p.Id == id);

            product.Quantity = quantityUpdate.Quantity;

            var result = _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(Guid categoryId)
        {

            return await _dbContext.Products.Where(p => p.ProductCategoryId == categoryId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetRandomProducts(int targetLength)
        {
            var count = _dbContext.Products.Count();

            List<Product> products = new List<Product>();

            List<int> chosenIndexes = new List<int>();

            Random random = new Random();

            while (products.Count < targetLength)
            {
                var index = random.Next(count);
                if (chosenIndexes.Contains(index))
                {
                    continue;
                }
                chosenIndexes.Add(index);

                var product = _dbContext.Products.Include(p => p.ProductCategory).Include(p => p.ImageUpload).Skip(index).FirstOrDefault();

                products.Add(product);
                if (products.Count == count)
                {
                    break;
                }
            }
            return products;
        }

        public async Task<Product?> GetShowcaseProduct()
        {
            try
            {
                var result = await _dbContext.ProductShowcases.Include(ps => ps.Product).ThenInclude(p => p.ProductCategory).SingleOrDefaultAsync();
                if (result == null)
                {
                    return default;
                }
                return result.Product;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<IEnumerable<Product>> SearchProducts(ProductFilterDto filter)
        {
            try
            {
                var query = _dbContext.Products.AsQueryable();

                if (!filter.SearchString.IsNullOrEmpty())
                {
                    query = query.Where(p => p.Name.ToLower().Contains(filter.SearchString.ToLower())
                        || p.Description.ToLower().Contains(filter.SearchString.ToLower()));
                }

                if (filter.ProductCategoryId != Guid.Empty)
                {
                    query = query.Where(p => p.ProductCategoryId == filter.ProductCategoryId);
                }

                return query.ToList();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<ProductCategory> AddProductCategory(AddProductCategoryDto categoryToAdd)
        {
            try
            {
                var existingCategory = _dbContext.ProductCategories.SingleOrDefaultAsync(p => p.Name == categoryToAdd.Name);

                var newProductCategory = new ProductCategory
                {
                    Name = categoryToAdd.Name
                };

                if (await existingCategory != null) { throw new Exception("Conflict"); }

                var result = _dbContext.ProductCategories.Add(newProductCategory);

                await _dbContext.SaveChangesAsync();


                return result.Entity;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<ProductCategory> DeleteProductCategory(Guid id)
        {
            try
            {
                var productCategory = await _dbContext.ProductCategories.SingleOrDefaultAsync(p => p.Id == id);

                var products = _dbContext.Products.Where(p => p.ProductCategoryId == id).AsNoTracking().AsEnumerable();

                if (products.Any())
                {
                    throw new Exception("Category can not be deleted while the category is used.");
                }

                if (productCategory != null)
                {
                    var result = _dbContext.ProductCategories.Remove(productCategory);

                    await _dbContext.SaveChangesAsync();
                }

                return productCategory;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Product> AddProduct(AdminProductToAddDto productToAdd)
        {
            try
            {
                var existingProducts = await _dbContext.Products.SingleOrDefaultAsync(p => p.Name == productToAdd.Name);
                if (existingProducts != null)
                {
                    throw new Exception("Conflict");
                }

                var entity = new Product()
                {
                    Name = productToAdd.Name,
                    Description = productToAdd.Description,
                    Price = productToAdd.Price,
                    Quantity = productToAdd.Quantity,
                    ProductCategoryId = productToAdd.ProductCategoryid,
                    ImageUploadId = productToAdd.ImageUploadId,


                };

                var result = _dbContext.Products.Add(entity);

                await _dbContext.SaveChangesAsync();

                return result.Entity;


            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Product> UpdateProductImageUploadId(Guid id, UploadResultDto imageUpload)
        {
            try
            {
                var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

                if (product == null)
                {
                    return default;
                }

                product.ImageUploadId = imageUpload.Id;

                var result = _dbContext.Products.Update(product);

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Product> UpdateProductShowCase(UpdateProductShowcaseDto showcaseUpdate)
        {
            try
            {
                var productShowcase = await _dbContext.ProductShowcases.SingleOrDefaultAsync();

                if (productShowcase == null)
                {
                    var addResult = _dbContext.ProductShowcases.Add(new ProductShowcase()
                    {
                        ProductId = showcaseUpdate.ProductId,
                    });

                    await _dbContext.SaveChangesAsync();

                    var product = await _dbContext.Products.Include(p => p.ProductCategory).Include(p => p.ImageUpload).SingleOrDefaultAsync(p => p.Id == showcaseUpdate.ProductId);

                    return product;
                }

                productShowcase.ProductId = showcaseUpdate.ProductId;

                var result = _dbContext.ProductShowcases.Update(productShowcase);

                await _dbContext.SaveChangesAsync();

                var updateProduct = await _dbContext.Products.Include(p => p.ImageUpload).Include(p => p.ProductCategory).SingleAsync(p => p.Id == showcaseUpdate.ProductId);

                return updateProduct;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
