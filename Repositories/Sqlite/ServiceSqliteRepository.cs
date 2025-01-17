using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Models.enums;
using JricaStudioWebApi.Data;
using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Extentions;
using JricaStudioWebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;

namespace JricaStudioWebApi.Repositories.Sqlite
{
    /// <inheritdoc cref="IServiceRepository"/>
    public class ServiceSqliteRepository : IServiceRepository
    {
        private readonly JaysLashesDbContext _dbContext;

        public ServiceSqliteRepository(JaysLashesDbContext jaysLashesDbContext)
        {
            _dbContext = jaysLashesDbContext;
        }

        public async Task<Service> GetService(Guid id)
        {
            return await _dbContext.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await _dbContext.Services.Include(s => s.ImageUpload).ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetRandomServices(int requestedServices)
        {
            var count = _dbContext.Services.Count();

            if (count <= requestedServices)
            {
                return _dbContext.Services.Include(s=>s.ImageUpload).ToList();
            }

            List<Service> services = new List<Service>();

            List<int> chosenIdexes = new List<int>();

            Random random = new Random();

            while (services.Count < requestedServices)
            {
                var index = random.Next(0, count);
                if (chosenIdexes.Contains(index))
                {
                    continue;
                }

                chosenIdexes.Add(index);

                var service = _dbContext.Services.Skip(index).Include(s => s.ImageUpload).FirstOrDefault();

                services.Add(service);
                if (services.Count == count)
                {
                    break;
                }
            }
            return services;
        }

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategories()
        {
            var categories = _dbContext.ServiceCategories.ToList();

            return categories;
        }

        public async Task<ServiceCategory> GetServiceCategory(Guid id)
        {
            return await _dbContext.ServiceCategories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Service> AddNewService(AdminServiceToAddDto<IFormFile> dto, Guid id)
        {
            var existingService = _dbContext.ServiceCategories.FirstOrDefault(s => s.Name.Equals(dto.Name));

            if (existingService != null)
            {
                throw new InvalidOperationException("Service Name Conflict");
            }

            var newService = dto.ConvertToEntity(id);

            var result = await _dbContext.Services.AddAsync(newService);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Service> UpdateServiceDetails(Guid id, AdminEditServiceDto dto)
        {
            var service = _dbContext.Services.SingleOrDefault(s => s.Id == id);
            if (service == null)
            {
                return null;
            }

            service.Name = dto.Name;
            service.Description = dto.Description;
            service.ServiceCategoryId = dto.ServiceCategoryId;
            service.Duration = dto.Duration;
            service.Price = dto.Price;

            await _dbContext.SaveChangesAsync();

            return service;
        }

        public async Task<Service> UpdateServiceImageUploadId(Guid id, UploadResultDto uploadResult)
        {
            var service = await _dbContext.Services.SingleOrDefaultAsync(i => i.Id == id);

            if (service != null)
            {
                service.ImageUploadId = uploadResult.Id;
                await _dbContext.SaveChangesAsync();
                return service;
            }

            return null;
        }

        public async Task<Service> DeleteService(Guid id)
        {
            var service = _dbContext.Services.SingleOrDefault(s => s.Id == id);
            var serviceShowcase = _dbContext.ServicesShowcases.Single();

            if (serviceShowcase.ServiceId == id)
            {
                return default;
            }
                
            if (service != null)
            {
                var result = _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            return default;
        }

        public async Task<IEnumerable<Service>> SearchServices(ServiceFilterDto dto)
        {
            var query = _dbContext.Services.AsQueryable();

            if (dto.CategoryId != Guid.Empty)
            {
                query = query.Where(s => s.ServiceCategoryId == dto.CategoryId);
            }

            if (!dto.SearchString.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.ToLower().Contains(dto.SearchString.ToLower()) || s.Name.ToLower().Equals(dto.SearchString.ToLower())
                                            || s.Description.ToLower().Contains(dto.SearchString.ToLower()) || s.Description.ToLower().Equals(dto.SearchString.ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<ServiceCategory> AddServiceCategory(AddServiceCategoryDto dto)
        {
            try
            {
                var existingCategory = await _dbContext.ServiceCategories.SingleOrDefaultAsync(s => s.Name == dto.Name);

                if (existingCategory != null)
                {
                    throw new Exception("Conflict");
                }

                var serviceCategory = new ServiceCategory
                {
                    Name = dto.Name,
                };

                var result = _dbContext.ServiceCategories.Add(serviceCategory);

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<ServiceCategory> DeleteServiceCategory(Guid id)
        {
            try
            {
                var serviceCategory =  await _dbContext.ServiceCategories.SingleOrDefaultAsync(s => s.Id == id);

                var services = _dbContext.Services.Where(sc => sc.ServiceCategoryId == id).AsEnumerable();

                if (services.Any())
                {
                    throw new Exception("Category has services, please remove services or change their category and try again.");
                }

                if (serviceCategory == null)
                {
                    return default;
                }

                var result = _dbContext.Remove(serviceCategory);

                await _dbContext.SaveChangesAsync();

                return result.Entity ;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Service> GetCurrentServiceShowCase()
        {
            try
            {
                var service = _dbContext.ServicesShowcases.Include(ss => ss.Service).Select(ss => ss.Service).SingleOrDefault();

                if (service == null)
                {
                    return default;
                }

                return service;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Service> UpdateServiceShowCase(UpdateServiceShowcaseDto dto)
        {
            try
            {
                var serviceShowCase =  await _dbContext.ServicesShowcases.Include(ss => ss.Service).SingleOrDefaultAsync();

                if (serviceShowCase == null)
                {
                    var addResult = _dbContext.ServicesShowcases.Add(new ServiceShowCase()
                    {
                        ServiceId = dto.ServiceId
                    });
                    await _dbContext.SaveChangesAsync();

                    var addedServiceShowcase = addResult.Entity;

                    var addedShowcaseService = _dbContext.Services.Single(s => s.Id == addedServiceShowcase.ServiceId);

                    return addedShowcaseService;
                }

                serviceShowCase.ServiceId = dto.ServiceId;

                var result = _dbContext.ServicesShowcases.Update(serviceShowCase);

                await _dbContext.SaveChangesAsync();

                var service = await _dbContext.ServicesShowcases.Include(ss => ss.Service).Select(ss => ss.Service).SingleOrDefaultAsync();

                if (service != null)
                {
                    return service;
                }

                return default;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Service> GetPreviouslyOrderedService(Guid userId)
        {
            try
            {
                if (userId == null)
                {
                    return default;
                }
                var appointment = _dbContext.Appointments.Where(a => a.User.Id == userId && a.Status == AppointmentStatus.Complete).AsEnumerable();
                var service = new Service();
                if (appointment.Count() > 0)
                {
                    service = _dbContext.AppointmentServices
                    .Include(a => a.Service)
                    .Include(a => a.Appointment)
                    .Where(a => a.Appointment.UserId == userId && a.Appointment.Status == AppointmentStatus.Complete)
                    .OrderBy(a => a.Created)
                    .LastOrDefault().Service;
                    return service;
                }
                else
                {
                    return default;

                }


            }
            catch (Exception e)
            {
                return default;
            }
        }
    }
}
