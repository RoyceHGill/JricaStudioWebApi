using JricaStudioSharedLibrary.Dtos.Admin;
using JricaStudioWebApi.Entities;
using JricaStudioSharedLibrary.Dtos;
using JricaStudioSharedLibrary.Dtos.Admin;
using System.Security.Principal;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IServiceRepository
    {

        #region Create
        /// <summary>
        /// Creates a new service.
        /// </summary>
        /// <param name="dto">new Service Details</param>
        /// <param name="uploadId">The image upload Id</param>
        /// <returns>The created service.</returns>
        Task<Service> AddNewService(AdminServiceToAddDto<IFormFile> dto, Guid uploadId);

        /// <summary>
        /// Create a new Service Category.
        /// </summary>
        /// <param name="dto">New Service Category Details.</param>
        /// <returns>The created Service Category.</returns>
        Task<ServiceCategory> AddServiceCategory(AddServiceCategoryDto dto);
        #endregion

        #region Read
        /// <summary>
        /// Filter Search the Database for Services.
        /// </summary>
        /// <param name="dto">query parameters</param>
        /// <returns>Services that match or partially match filter.</returns>
        Task<IEnumerable<Service>> SearchServices(ServiceFilterDto dto);

        /// <summary>
        /// Get previously ordered Service.
        /// </summary>
        /// <param name="appointmentId">Appointment Id</param>
        /// <returns>A service from a previous order.</returns>
        Task<Service> GetPreviouslyOrderedService(Guid appointmentId);

        /// <summary>
        /// Get a number of random services from the database.
        /// </summary>
        /// <param name="count">number of services requested.</param>
        /// <returns>Returns random services up to the number of services requested.</returns>
        Task<IEnumerable<Service>> GetRandomServices(int count);

        /// <summary>
        /// Get the Current Showcase Service. 
        /// </summary>
        /// <returns>Returns the Show case service.</returns>
        Task<Service> GetCurrentServiceShowCase();

        /// <summary>
        /// Get all Service Categories.
        /// </summary>
        /// <returns>Collection of service categories.</returns>
        Task<IEnumerable<ServiceCategory>> GetServiceCategories();

        /// <summary>
        /// Get a single Service Category.
        /// </summary>
        /// <param name="id">Id of the service Category.</param>
        /// <returns>The service category.</returns>
        Task<ServiceCategory> GetServiceCategory(Guid id);

        /// <summary>
        /// Get all Services.
        /// </summary>
        /// <returns>Returns a collection of services.</returns>
        Task<IEnumerable<Service>> GetAllServices();

        /// <summary>
        /// Get a Single Service
        /// </summary>
        /// <param name="id">Id for the service.</param>
        /// <returns>Service Details.</returns>
        Task<Service> GetService(Guid id);
        #endregion

        #region Update
        /// <summary>
        /// Change the Service show case.
        /// </summary>
        /// <param name="dto">Service detais </param>
        /// <returns>The new service showcase details.</returns>
        Task<Service> UpdateServiceShowCase(UpdateServiceShowcaseDto dto);

        /// <summary>
        /// Change a Service's Details.
        /// </summary>
        /// <param name="id">The Service's ID</param>
        /// <param name="dto">New Service Details.</param>
        /// <returns>The Updated Service Details.</returns>
        Task<Service> UpdateServiceDetails(Guid id, AdminEditServiceDto dto);

        /// <summary>
        /// Change the Image Upload Details for a service.
        /// </summary>
        /// <param name="id">The Service's ID</param>
        /// <param name="imageUpload">New Image Upload details.</param>
        /// <returns>updated Service Details.</returns>
        Task<Service> UpdateServiceImageUploadId(Guid id, UploadResultDto imageUpload);
        #endregion

        #region Delete
        /// <summary>
        /// Remove Service from database.
        /// </summary>
        /// <param name="id">The Service to remove</param>
        /// <returns>The Removed Service's details.</returns>
        Task<Service> DeleteService(Guid id);

        /// <summary>
        /// Remove Service Category from database
        /// </summary>
        /// <param name="id">The Service Category's ID</param>
        /// <returns>The Removed service category's Details.</returns>
        Task<ServiceCategory> DeleteServiceCategory(Guid id);
        #endregion


        


        
        
    }
}
