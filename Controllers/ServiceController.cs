using JricaStudioSharedLibrary.Dtos;
using JricaStudioWebAPI.Extentions;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using JricaStudioSharedLibrary.Dtos.Admin;
using JricaStudioWebAPI.Attributes;
using JricaStudioSharedLibrary.Dtos;
using JricaStudioSharedLibrary.Constants;
using JricaStudioWebAPI.Services.Contracts;
using JricaStudioSharedLibrary.Dtos.Admin;

namespace JricaStudioWebAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IImageAccessService _imageAccessService;

        public ServiceController( IServiceRepository serviceRepository, IImageAccessService imageAccess )
        {
            _serviceRepository = serviceRepository;
            _imageAccessService = imageAccess;
        }

        [AdministratorKey]
        [HttpPatch]
        public async Task<ActionResult<ImageUpdateResultDto>> PatchServiceImage( [FromForm] Guid id, IFormFile imageFile )
        {
            try
            {
                var service = await _serviceRepository.GetService( id );

                if ( service == null )
                {
                    return NotFound();
                }

                var uploadResult = await _imageAccessService.SaveImage( imageFile, FileResources.serviceImageFilePath );


                var updatedService = await _serviceRepository.UpdateServiceImageUploadId( id, uploadResult );

                if ( updatedService == null )
                {
                    return BadRequest();
                }

                var affectedrecords = await _imageAccessService.RemoveUnusedImageFiles();

                return Ok( new ImageUpdateResultDto
                {
                    UploadedImageResult = uploadResult
                } );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [AdministratorKey]
        [HttpPut( "{id:guid}" )]
        public async Task<ActionResult<ServiceEditResultDto>> PutService( Guid id, AdminEditServiceDto editServiceDTO )
        {
            try
            {
                var result = await _serviceRepository.UpdateServiceDetails( id, editServiceDTO );
                if ( result == null )
                {
                    return NotFound( "could not find Service." );
                }

                return Ok( result.ConvertToEditDto() );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [AdministratorKey]
        [HttpPost]
        public async Task<ActionResult<UploadResultDto>> PostNewService( [FromForm] AdminServiceToAddDto<IFormFile> serviceToAdd )
        {
            try
            {
                var existingServices = await _serviceRepository.GetAllServices();
                if ( existingServices.Any( s => s.Name.Equals( serviceToAdd.Name ) ) )
                {
                    return Conflict();
                }

                var result = await _imageAccessService.SaveImage( serviceToAdd.ImageFile, FileResources.serviceImageFilePath );

                if ( result == default )
                {
                    return StatusCode( StatusCodes.Status415UnsupportedMediaType, "There was a Problem processing the image file" );
                }

                var newService = await _serviceRepository.AddNewService( serviceToAdd, result.Id );

                if ( newService == null )
                {
                    return StatusCode( StatusCodes.Status500InternalServerError, "Service not created." );
                }



                return Ok( result );
            }
            catch ( InvalidOperationException ieo )
            {
                return StatusCode( StatusCodes.Status409Conflict, ieo.Message );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }


        // Get Service By Id
        [HttpGet( "{id:guid}" )]
        public async Task<ActionResult<ServiceDto>> GetById( Guid id )
        {
            try
            {
                var service = await _serviceRepository.GetService( id );

                if ( service == null )
                {
                    return NotFound();
                }

                var category = await _serviceRepository.GetServiceCategory( service.ServiceCategoryId );

                if ( category == null )
                {
                    return StatusCode( StatusCodes.Status503ServiceUnavailable );
                }

                var imageData = await _imageAccessService.LoadImage( service.Id, FileResources.serviceImageFilePath );

                var serviceDto = service.ConvertToDto( category, imageData );

                return Ok( serviceDto );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [HttpGet( "serviceShowcase" )]
        public async Task<ActionResult<ServiceDto>> GetServiceShowCase()
        {
            try
            {
                var service = await _serviceRepository.GetCurrentServiceShowCase();

                if ( service == null )
                {
                    return NoContent();
                }

                var category = await _serviceRepository.GetServiceCategory( service.ServiceCategoryId );

                var imageDate = await _imageAccessService.LoadImage( service.Id, FileResources.serviceImageFilePath );

                var dto = service.ConvertToDto( category, imageDate );

                return Ok( dto );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }

        }

        [AdministratorKey]
        [HttpPut( "serviceShowcase" )]
        public async Task<ActionResult<ServiceDto>> PutServiceShowCase( UpdateServiceShowcaseDto showcaseUpdate )
        {
            var service = await _serviceRepository.UpdateServiceShowCase( showcaseUpdate );

            if ( service == null )
            {
                return BadRequest( showcaseUpdate );
            }

            var category = await _serviceRepository.GetServiceCategory( service.ServiceCategoryId );

            var imageDate = await _imageAccessService.LoadImage( service.Id, FileResources.serviceImageFilePath );

            var serviceDto = service.ConvertToDto( category, imageDate );

            return Ok( serviceDto );
        }

        [HttpGet( "All" )]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAll()
        {
            try
            {
                var services = await _serviceRepository.GetAllServices();

                if ( services == null )
                {
                    return NotFound();
                }

                var categories = await _serviceRepository.GetServiceCategories();

                var imageData = await _imageAccessService.LoadServicesImages( services );

                var serviceDtos = services.ConvertToDto( categories, imageData );

                if ( serviceDtos == null )
                {
                    return StatusCode( StatusCodes.Status503ServiceUnavailable );
                }



                return Ok( serviceDtos );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [HttpGet( "GetRandom/{requestedServices:int}" )]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetRandom( int requestedServices )
        {
            try
            {
                var services = await _serviceRepository.GetRandomServices( requestedServices );

                if ( services == null )
                {
                    return NotFound();
                }

                var imageData = await _imageAccessService.LoadServicesImages( services );


                var servicesCategorys = await _serviceRepository.GetServiceCategories();

                return Ok( services.ConvertToDto( servicesCategorys, imageData ) );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [HttpGet( "Categories" )]
        public async Task<ActionResult<IEnumerable<AdminServiceCategoryDto>>> GetCategories()
        {
            var categoies = await _serviceRepository.GetServiceCategories();

            return Ok( categoies.ConvetToDtos() );
        }

        [AdministratorKey]
        [HttpGet( "Admin" )]
        public async Task<ActionResult<IEnumerable<ServiceAdminPageDto>>> GetAdministratorServices()
        {
            try
            {
                var services = await _serviceRepository.GetAllServices();

                if ( services == null )
                {
                    return NoContent();
                }

                var dtos = services.ConvertToAdminDtos();

                return Ok( dtos );

            }
            catch ( Exception )
            {

                throw;
            }
        }

        [AdministratorKey]
        [HttpDelete( "{id:guid}" )]
        public async Task<ActionResult<ServiceDto>> DeleteService( Guid id )
        {

            try
            {
                var service = await _serviceRepository.DeleteService( id );

                if ( service == default )
                {
                    return NotFound( "Service not found." );
                }

                var dto = service.ConvertToDto();

                return Ok( dto );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [AdministratorKey]
        [HttpPost( "Search" )]
        public async Task<ActionResult<IEnumerable<ServiceAdminPageDto>>> SearchServices( ServiceFilterDto serviceFilter )
        {
            try
            {
                var services = await _serviceRepository.SearchServices( serviceFilter );

                if ( services == null )
                {
                    return NoContent();
                }

                var dtos = services.ConvertToAdminDtos();

                return Ok( services );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [AdministratorKey]
        [HttpPost( "Category" )]
        public async Task<ActionResult<AdminServiceCategoryDto>> PostCategory( [FromBody] AddServiceCategoryDto categoryToAdd )
        {
            try
            {
                var result = await _serviceRepository.AddServiceCategory( categoryToAdd );

                if ( result == null )
                {
                    return BadRequest();
                }

                var categoryDto = result.ConvertToDo();

                return Ok( categoryDto );
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [AdministratorKey]
        [HttpDelete( "Category/{id:guid}" )]
        public async Task<ActionResult<AdminServiceCategoryDto>> DeleteServiceCategory( Guid id )
        {
            try
            {
                var serviceCategory = await _serviceRepository.DeleteServiceCategory( id );

                if ( serviceCategory == null )
                {
                    return NotFound();
                }

                var categoryDto = serviceCategory.ConvertToDo();

                return categoryDto;
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [HttpGet( "previouslyOrdered/{userId:guid}" )]
        public async Task<ActionResult<PreviousServiceDto>> GetPreviouslyOrderedService( Guid userId )
        {
            try
            {
                var service = await _serviceRepository.GetPreviouslyOrderedService( userId );

                if ( service == null )
                {
                    return NoContent();
                }

                var dto = service.ConvertToPreviousServiceDto();

                return dto;
            }
            catch ( Exception e )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }
    }
}
