
using Microsoft.AspNetCore.Mvc;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Extentions;
using JricaStudioWebApi.Repositories.Contracts;
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Attributes;
using JricaStudioWebApi.Services.Contracts;
using JricaStudioWebApi.Models.Constants;
using JricaStudioWebApi.Entities;

namespace JricaStudioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IImageAccessService _imageAccessService;

        public ProductsController(IProductRepository repository, IImageAccessService imageAccess)
        {
            _repository = repository;
            _imageAccessService = imageAccess;

        }

        // Remove Product
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AdminProductDto>> Delete(Guid id)
        {
            try
            {
                var result = await _repository.DeleteProduct(id);

                if (result == null)
                {
                    return NotFound();
                }

                var dto = result.ConvertToAdminDto();

                return Ok(dto);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            try
            {
                var product = await _repository.GetProduct(id);

                var categories = await _repository.GetAllProductCategories();

                if (product == null)
                {
                    return BadRequest();
                }

                var imageData = await _imageAccessService.LoadImage(product.Id, FileResources.productImageFilePath);

                var productDto = product.ConvertToDto(imageData);

                return Ok(productDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            try
            {
                var products = await _repository.GetProducts();
                if (products == null)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }

                var categories = await _repository.GetAllProductCategories();
                if (categories == null)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }

                var productIdImageData = await _imageAccessService.LoadProductsImages(products);

                var productsdto = products.ConvertToDtos(productIdImageData);

                return Ok(productsdto);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetRandom/{range:int}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetRandom(int range)
        {
            try
            {
                var products = await _repository.GetRandomProducts(range);

                var categories = await _repository.GetAllProductCategories();

                var imageData = await _imageAccessService.LoadProductsImages(products);

                var productsDto = products.ConvertToDtos(imageData);

                return Ok(productsDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetShowcaseProduct")]
        public async Task<ActionResult<ProductDto>> GetShowcaseProduct()
        {
            try
            {
                var result = await _repository.GetShowcaseProduct();

                if (result == null)
                {
                    return NotFound();
                }

                var imageData = await _imageAccessService.LoadImage(result.Id, FileResources.productImageFilePath);

                var dto = result.ConvertToDto(imageData);

                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<AdminProductCategoryDto>>> GetCategories()
        {
            try
            {
                var categories = await _repository.GetAllProductCategories();

                if (categories == null)
                {
                    return NoContent();
                }

                var dtos = categories.ConvertToAdminDtos();

                return Ok(dtos);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                throw;
            }
        }

        [AdminKey]
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<AdminProductDto>>> SearchProducts(ProductFilterDto filter)
        {
            try
            {
                var products = await _repository.SearchProducts(filter);

                if (products == null)
                {
                    return NoContent();
                }

                var dtos = products.ConvertToAdminDtos();

                return Ok(dtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPost("Category")]
        public async Task<ActionResult<AdminProductCategoryDto>> PostCategory(AddProductCategoryDto newCategory)
        {
            try
            {
                var result = await _repository.AddProductCategory(newCategory);

                if (result == null)
                {
                    return BadRequest();
                }

                var dto = result.ConvertToAdminDto();

                return Ok(dto);

            }
            catch (Exception e)
            {
                if (e.Message.ToLower().Equals("conflict"))
                {
                    return Conflict();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpDelete("Category/{id:guid}")]
        public async Task<ActionResult<AdminProductCategoryDto>> DeleteCategory(Guid id)
        {
            try
            {
                var result = await _repository.DeleteProductCategory(id);

                if (result == null)
                {
                    return NotFound();
                }

                var dto = result.ConvertToAdminDto();

                return Ok(dto);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPost("ImageUpload")]
        public async Task<ActionResult<UploadResultDto>> UploadImage(IFormFile file)
        {
            try
            {
                var uploadResult = await _imageAccessService.SaveImage(file, FileResources.productImageFilePath);

                if (uploadResult == null)
                {
                    throw new Exception("There was an issue uploading the image");
                }

                return Ok(uploadResult);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                throw;
            }
        }

        [AdminKey]
        [HttpPost]
        public async Task<ActionResult<AdminProductDto>> PostProduct([FromBody] AdminProductToAddDto dto)
        {
            try
            {
                var product = await _repository.AddProduct(dto);

                if (product == null)
                {
                    return BadRequest();
                }

                var adminDto = product.ConvertToAdminDto();

                return adminDto;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AdminProductDto>> PutProduct(Guid id, EditProductDto dto)
        {
            try
            {
                var product = await _repository.UpdateProduct(id, dto);

                if (product == null)
                {
                    return NotFound();
                }

                var adminDto = product.ConvertToAdminDto();

                return Ok(adminDto);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPatch]
        public async Task<ActionResult<ImageUpdateResultDto>> PatchProductImage([FromForm] Guid id, IFormFile imageFile)
        {
            try
            {
                var service = await _repository.GetProduct(id);

                if (service == null)
                {
                    return NotFound();
                }

                var uploadResult = await _imageAccessService.SaveImage(imageFile, FileResources.productImageFilePath);


                var updatedService = await _repository.UpdateProductImageUploadId(id, uploadResult);

                if (updatedService == null)
                {
                    return BadRequest();
                }

                var affectedrecords = await _imageAccessService.RemoveUnusedImageFiles();

                return Ok(new ImageUpdateResultDto
                {
                    UploadedImageResult = uploadResult
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPut("productShowcase")]
        public async Task<ActionResult<ProductDto>> PutServiceShowCase(UpdateProductShowcaseDto dto)
        {
            Product product = await _repository.UpdateProductShowCase(dto);

            if (product == null)
            {
                return BadRequest(dto);
            }

            var category = await _repository.GetProductCategory(product.ProductCategoryId);

            var imageData = await _imageAccessService.LoadImage(product.Id, FileResources.productImageFilePath);

            var productDto = product.ConvertToDto(imageData);

            return Ok(productDto);
        }
    }
}
