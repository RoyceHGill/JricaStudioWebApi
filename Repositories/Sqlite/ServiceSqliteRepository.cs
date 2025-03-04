using JricaStudioSharedLibrary.Dtos.Admin;
using JricaStudioSharedLibrary.enums;
using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Extentions;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using JricaStudioSharedLibrary.Dtos;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    /// <inheritdoc cref="IServiceRepository"/>
    public class ServiceSqLiteRepository : IServiceRepository
    {
        private readonly JaysLashesDbContext _dbContext;

        public ServiceSqLiteRepository( JaysLashesDbContext jaysLashesDbContext )
        {
            _dbContext = jaysLashesDbContext;
        }

        public async Task<Service?> GetService( Guid id )
        {
            return await _dbContext.Services.FirstOrDefaultAsync( s => s.Id == id );
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await _dbContext.Services.Include( s => s.ImageUpload ).ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetRandomServices( int requestedServices )
        {
            var totalServicesCount = _dbContext.Services.Count();

            if ( totalServicesCount <= requestedServices )
            {
                return await _dbContext.Services.Include( s => s.ImageUpload ).ToListAsync();
            }

            var services = new List<Service>();

            var chosenIdexes = new List<int>();

            var random = new Random();

            while ( services.Count < requestedServices )
            {
                var index = random.Next( 0, totalServicesCount );
                if ( chosenIdexes.Contains( index ) )
                {
                    continue;
                }

                chosenIdexes.Add( index );

                var service = _dbContext.Services.Skip( index ).Include( s => s.ImageUpload ).First();

                services.Add( service );
                if ( services.Count == totalServicesCount )
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

        public async Task<ServiceCategory> GetServiceCategory( Guid id )
        {
            return await _dbContext.ServiceCategories.FirstOrDefaultAsync( c => c.Id == id );
        }

        public async Task<Service?> AddNewService( AdminServiceToAddDto<IFormFile> serviceToAdd, Guid id )
        {
            var existingService = _dbContext.ServiceCategories.FirstOrDefault( s => s.Name.Equals( serviceToAdd.Name ) );

            if ( existingService != null )
            {
                throw new InvalidOperationException( "Service Name Conflict" );
            }

            var newService = serviceToAdd.ConvertToEntity( id );

            var result = await _dbContext.Services.AddAsync( newService );
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Service> UpdateServiceDetails( Guid id, AdminEditServiceDto serviceUpdate )
        {
            var service = _dbContext.Services.SingleOrDefault( s => s.Id == id );
            if ( service == null )
            {
                return null;
            }

            service.Name = serviceUpdate.Name;
            service.Description = serviceUpdate.Description;
            service.ServiceCategoryId = serviceUpdate.ServiceCategoryId;
            service.Duration = serviceUpdate.Duration;
            service.Price = serviceUpdate.Price;

            await _dbContext.SaveChangesAsync();

            return service;
        }

        public async Task<Service> UpdateServiceImageUploadId( Guid id, UploadResultDto uploadResult )
        {
            var service = await _dbContext.Services.SingleOrDefaultAsync( i => i.Id == id );

            if ( service != null )
            {
                service.ImageUploadId = uploadResult.Id;
                await _dbContext.SaveChangesAsync();
                return service;
            }

            return null;
        }

        public async Task<Service> DeleteService( Guid id )
        {
            var service = _dbContext.Services.SingleOrDefault( s => s.Id == id );
            var serviceShowcase = _dbContext.ServicesShowcases.Single();

            if ( serviceShowcase.ServiceId == id )
            {
                return default;
            }

            if ( service != null )
            {
                var result = _dbContext.Services.Remove( service );
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            return default;
        }

        public async Task<IEnumerable<Service>> SearchServices( ServiceFilterDto serviceFilter )
        {
            var query = _dbContext.Services.AsQueryable();

            if ( serviceFilter.CategoryId != Guid.Empty )
            {
                query = query.Where( s => s.ServiceCategoryId == serviceFilter.CategoryId );
            }

            if ( !serviceFilter.SearchString.IsNullOrEmpty() )
            {
                query = query.Where( s => s.Name.Contains( serviceFilter.SearchString, StringComparison.CurrentCultureIgnoreCase ) || s.Name.ToLower().Equals( serviceFilter.SearchString.ToLower() )
                                            || s.Description.Contains( serviceFilter.SearchString, StringComparison.CurrentCultureIgnoreCase ) || s.Description.ToLower().Equals( serviceFilter.SearchString.ToLower() ) );
            }

            return await query.ToListAsync();
        }

        public async Task<ServiceCategory> AddServiceCategory( AddServiceCategoryDto categoryToAdd )
        {
            try
            {
                var existingCategory = await _dbContext.ServiceCategories.SingleOrDefaultAsync( s => s.Name == categoryToAdd.Name );

                if ( existingCategory != null )
                {
                    throw new Exception( "Conflict" );
                }

                var serviceCategory = new ServiceCategory
                {
                    Name = categoryToAdd.Name,
                };

                var result = _dbContext.ServiceCategories.Add( serviceCategory );

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch ( Exception e )
            {

                throw;
            }
        }

        public async Task<ServiceCategory> DeleteServiceCategory( Guid id )
        {
            try
            {
                var serviceCategory = await _dbContext.ServiceCategories.SingleOrDefaultAsync( s => s.Id == id );

                var services = _dbContext.Services.Where( sc => sc.ServiceCategoryId == id ).AsEnumerable();

                if ( services.Any() )
                {
                    throw new Exception( "Category has services, please remove services or change their category and try again." );
                }

                if ( serviceCategory == null )
                {
                    return default;
                }

                var result = _dbContext.Remove( serviceCategory );

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch ( Exception e )
            {

                throw;
            }
        }

        public async Task<Service> GetCurrentServiceShowCase()
        {
            try
            {
                var services = _dbContext.ServicesShowcases.Include( ss => ss.Service ).Select( ss => ss.Service ).ToList();

                if ( services.Count == 0 )
                {
                    return default;
                }

                var service = services.MaxBy( s => s.Created );

                return service!;
            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<Service> UpdateServiceShowCase( UpdateServiceShowcaseDto ShowcaseUpdate )
        {
            try
            {
                var serviceShowCase = await _dbContext.ServicesShowcases.Include( ss => ss.Service ).SingleOrDefaultAsync();

                if ( serviceShowCase == null )
                {
                    var addResult = _dbContext.ServicesShowcases.Add( new ServiceShowCase()
                    {
                        ServiceId = ShowcaseUpdate.ServiceId
                    } );
                    await _dbContext.SaveChangesAsync();

                    var addedServiceShowcase = addResult.Entity;

                    var addedShowcaseService = _dbContext.Services.Single( s => s.Id == addedServiceShowcase.ServiceId );

                    return addedShowcaseService;
                }

                serviceShowCase.ServiceId = ShowcaseUpdate.ServiceId;

                var result = _dbContext.ServicesShowcases.Update( serviceShowCase );

                await _dbContext.SaveChangesAsync();

                var service = await _dbContext.ServicesShowcases.Include( ss => ss.Service ).Select( ss => ss.Service ).SingleOrDefaultAsync();

                if ( service != null )
                {
                    return service;
                }

                return default;
            }
            catch ( Exception e )
            {

                throw;
            }
        }

        public async Task<Service> GetPreviouslyOrderedService( Guid userId )
        {
            try
            {
                if ( userId == default )
                {
                    return default;
                }
                var appointment = _dbContext.Appointments.Where( a => a.User.Id == userId && a.Status == AppointmentStatus.Complete ).AsEnumerable();
                var service = new Service();
                if ( appointment.Any() )
                {
                    service = _dbContext.AppointmentServices
                    .Include( a => a.Service )
                    .Include( a => a.Appointment )
                    .Where( a => a.Appointment.UserId == userId && a.Appointment.Status == AppointmentStatus.Complete )
                    .OrderBy( a => a.Created )
                    .LastOrDefault().Service;
                    return service;
                }
                else
                {
                    return default;

                }


            }
            catch ( Exception e )
            {
                return default;
            }
        }
    }
}
