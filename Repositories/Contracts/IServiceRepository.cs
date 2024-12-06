using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;
using System.Security.Principal;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IServiceRepository
    {
        Task<Service> GetCurrentServiceShowCase();
        Task<Service> UpdateServiceShowCase(UpdateServiceShowcaseDto dto);
        Task<IEnumerable<Service>> GetRandomServices(int count);

        Task<IEnumerable<ServiceCategory>> GetServiceCategories();

        Task<ServiceCategory> GetServiceCategory(Guid id);

        Task<IEnumerable<Service>> GetAllServices();

        Task<Service> GetService(Guid id);

        Task<Service> CreateNewService(AdminServiceToAddDto<IFormFile> dto, Guid uploadId);

        Task<Service> UpdateServiceDetails(Guid id, AdminEditServiceDto dto);

        Task<Service> UpdateServiceImageUploadId(Guid id, UploadResultDto imageUpload);

        Task<Service> DeleteService(Guid id);

        Task<IEnumerable<Service>> QueryServices(ServiceFilterDto dto);

        Task<ServiceCategory> AddServiceCategory(AddServiceCategoryDto dto);
        Task<ServiceCategory> DeleteServiceCategory(Guid id);
        Task<Service> GetPreviouslyOrderedService(Guid appointmentId);
    }
}
