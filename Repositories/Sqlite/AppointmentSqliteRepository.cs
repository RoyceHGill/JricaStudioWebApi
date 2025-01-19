using JricaStudioWebAPI.Models.Dtos;
using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using JricaStudioWebAPI.Models.enums;
using JricaStudioWebAPI.Models.Dtos.Admin;
using JricaStudioWebAPI.Services.Contracts;
using JricaStudioWebAPI.Extentions;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    public class AppointmentSqliteRepository : IAppointmentRepository
    {
        private readonly JaysLashesDbContext _jaysLashesDbContext;
        private readonly IStringEncryptionService _encryptionService;

        public AppointmentSqliteRepository(JaysLashesDbContext jaysLashesDbContext, IStringEncryptionService encryptionService)
        {
            _jaysLashesDbContext = jaysLashesDbContext;
            _encryptionService = encryptionService;
        }

        public async Task<AppointmentProduct> AddProduct(AppointmentProductToAddDto addDto)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.Include(a => a.AppointmentProducts).SingleOrDefaultAsync(a => a.Id == addDto.AppointmentId) ?? throw new Exception( "No Appointment found" );

                if (appointment.Status >= AppointmentStatus.AwaitingApproval)
                {
                    throw new Exception("Can not add Product to Submitted Appointment");
                }

                if (!appointment.AppointmentProducts.Any(p => p.ProductId == addDto.ProductId))
                {
                    if (_jaysLashesDbContext.Products.Any(p => p.Id == addDto.ProductId))
                    {
                        var appointmentProduct = new AppointmentProduct()
                        {
                            ProductId = addDto.ProductId,
                            AppointmentId = addDto.AppointmentId,
                            Quantity = addDto.Quantity,
                        };

                        var result = await _jaysLashesDbContext.AppointmentProducts.AddAsync(appointmentProduct);
                        await _jaysLashesDbContext.SaveChangesAsync();

                        return await _jaysLashesDbContext.AppointmentProducts.Include(a => a.Product).SingleAsync(s => s.Id == result.Entity.Id);
                    }
                }
                else
                {
                    var appointmentProduct = appointment.AppointmentProducts.SingleOrDefault(p => p.ProductId == addDto.ProductId);

                    if (appointmentProduct != null)
                    {
                        appointmentProduct.Quantity = addDto.Quantity + appointmentProduct.Quantity;
                        var result = _jaysLashesDbContext.AppointmentProducts.Update(appointmentProduct);
                        await _jaysLashesDbContext.SaveChangesAsync();
                        return await _jaysLashesDbContext.AppointmentProducts.Include(a => a.Product).SingleAsync(a => a.Id == result.Entity.Id);
                    }
                }

                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<AppointmentService> AddService(AppointmentServiceToAddDto addDto)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.SingleOrDefaultAsync(a => a.Id == addDto.AppointmentId) ?? throw new Exception( "No Appointment found" );

                if (appointment.Status >= AppointmentStatus.AwaitingApproval)
                {
                    throw new Exception("Can not add Service to Submitted Appointment");
                }

                var service = await _jaysLashesDbContext.Services.Include(s => s.ImageUpload).SingleOrDefaultAsync(s => s.Id == addDto.ServiceId);

                if (service != null)
                {
                    var appointmentService = new AppointmentService()
                    {
                        ServiceId = addDto.ServiceId,
                        AppointmentId = addDto.AppointmentId
                    };

                    var result = await _jaysLashesDbContext.AppointmentServices.AddAsync(appointmentService);

                    await _jaysLashesDbContext.SaveChangesAsync();
                    return await _jaysLashesDbContext.AppointmentServices.Include(a => a.Service).ThenInclude(s => s.ImageUpload).SingleAsync(a => a.Id == result.Entity.Id);

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AppointmentProduct> AdminAddProduct(AppointmentProductToAddDto addDto)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.Include(a => a.AppointmentProducts).SingleOrDefaultAsync(a => a.Id == addDto.AppointmentId) ?? throw new Exception( "No Appointment found" );

                if (!appointment.AppointmentProducts.Any(p => p.ProductId == addDto.ProductId))
                {
                    if (_jaysLashesDbContext.Products.Any(p => p.Id == addDto.ProductId))
                    {
                        var appointmentProduct = new AppointmentProduct()
                        {
                            ProductId = addDto.ProductId,
                            AppointmentId = addDto.AppointmentId,
                            Quantity = addDto.Quantity,
                        };

                        var result = await _jaysLashesDbContext.AppointmentProducts.AddAsync(appointmentProduct);
                        await _jaysLashesDbContext.SaveChangesAsync();
                        return await _jaysLashesDbContext.AppointmentProducts.Include(a => a.Product).SingleAsync(a => a.Id == result.Entity.Id);
                    }
                }
                else
                {
                    var appointmentProduct = appointment.AppointmentProducts.SingleOrDefault(p => p.ProductId == addDto.ProductId);

                    if (appointmentProduct != null)
                    {
                        appointmentProduct.Quantity = addDto.Quantity + appointmentProduct.Quantity;
                        var result = _jaysLashesDbContext.AppointmentProducts.Update(appointmentProduct);
                        await _jaysLashesDbContext.SaveChangesAsync();
                        return await _jaysLashesDbContext.AppointmentProducts.Include(a => a.Product).SingleAsync(a => a.Id == result.Entity.Id);
                    }
                }

                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AppointmentService> AdminAddService(AppointmentServiceToAddDto addDto)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.SingleOrDefaultAsync(a => a.Id == addDto.AppointmentId) ?? throw new Exception( "No Appointment found" );

                var service = await _jaysLashesDbContext.Services.SingleOrDefaultAsync(s => s.Id == addDto.ServiceId);

                if (service != null)
                {
                    var appointmentService = new AppointmentService()
                    {
                        ServiceId = addDto.ServiceId,
                        AppointmentId = addDto.AppointmentId
                    };

                    var result = await _jaysLashesDbContext.AppointmentServices.AddAsync(appointmentService);
                    await _jaysLashesDbContext.SaveChangesAsync();
                    return await _jaysLashesDbContext.AppointmentServices.Include(a => a.Service).SingleAsync(a => a.Id == result.Entity.Id);

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AppointmentProduct> GetProduct(Guid id)
        {
            return await _jaysLashesDbContext.AppointmentProducts.Where(ap => ap.Id == id).Include(ap => ap.Product).Include(ap => ap.Appointment).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<AppointmentProduct>> GetProducts(Guid id)
        {
            return await _jaysLashesDbContext.AppointmentProducts.Include(ap => ap.Product).ThenInclude(p => p.ImageUpload).Include(ap => ap.Appointment).Where(ap => ap.AppointmentId == id).AsNoTracking().ToListAsync();
        }

        public async Task<AppointmentService> GetService(Guid id)
        {
            return await _jaysLashesDbContext.AppointmentServices.AsNoTracking().Include(s => s.Service).Include(s => s.Appointment).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<AppointmentService>> GetServices(Guid id)
        {
            return await _jaysLashesDbContext.AppointmentServices.Where(s => s.AppointmentId == id).Include(s => s.Service).ThenInclude(s => s.ImageUpload).Include(s => s.Appointment).AsNoTracking().AsNoTracking().ToListAsync();
        }

        public async Task<AppointmentProduct> UpdateProductQty(Guid id, AppointmentProductQuantityUpdateDto qtyDto)
        {
            var appointmentProduct = await _jaysLashesDbContext.AppointmentProducts.Include(ap => ap.Product).SingleOrDefaultAsync(ap => ap.Id == id);

            if (appointmentProduct == null)
            {
                return null;
            }

            appointmentProduct.Quantity = qtyDto.Quantity;
            await _jaysLashesDbContext.SaveChangesAsync();

            var result = await _jaysLashesDbContext.AppointmentProducts.Include(ap => ap.Product).SingleOrDefaultAsync(ap => ap.Id == id);

            return result;
        }

        public Task<AppointmentService> UpdateServiceQty(Guid id, AppointmentServiceUpdateQuantityDto qtyDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppointmentProduct>> DeleteAppointmentProduct(Guid appointmentProductId)
        {
            var appointmentProduct = await _jaysLashesDbContext.AppointmentProducts
                .Include(p => p.Product)
                .SingleOrDefaultAsync(p => p.Id == appointmentProductId);

            if (appointmentProduct == null)
            {
                return null;
            }

            var resultProduct = _jaysLashesDbContext.AppointmentProducts.Remove(appointmentProduct);

            await _jaysLashesDbContext.SaveChangesAsync();
            return _jaysLashesDbContext.AppointmentProducts.Include(a => a.Appointment).Include(a => a.Product).Where(a => a.AppointmentId == appointmentProduct.AppointmentId).AsEnumerable();
        }

        public async Task<IEnumerable<AppointmentService>> DeleteAppointmentService(Guid appointmentServiceId)
        {
            var appointmentService = await _jaysLashesDbContext.AppointmentServices
                .Include(s => s.Service)
                .SingleOrDefaultAsync(s => s.Id == appointmentServiceId);

            if (appointmentService == null)
            {
                return null;
            }

            var resultService = _jaysLashesDbContext.AppointmentServices.Remove(appointmentService);

            await _jaysLashesDbContext.SaveChangesAsync();
            return _jaysLashesDbContext.AppointmentServices.Where(a => a.AppointmentId == appointmentService.AppointmentId).Include(a => a.Service).AsEnumerable();
        }


        public async Task<Appointment> UpdateAppointmentIndemnityQuestions(Guid id, UpdateAppointmentIndemnityDto indemnityDto)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.SingleOrDefaultAsync(a => a.Id == id);

                if (appointment == null)
                {
                    return appointment;
                }

                appointment.HasHadEyelashExtentions = indemnityDto.HasHadEyelashExtentions;
                appointment.IsSampleSetComplete = indemnityDto.IsSampleSetComplete;
                appointment.SampleSetCompleted = indemnityDto.SampleSetCompleted;

                await _jaysLashesDbContext.SaveChangesAsync();

                return appointment;
            }
            catch (Exception e)
            {
                throw new Exception($"An Error has occurred during update: {e.Message}");
            }
        }

        public async Task<Appointment?> UpdateAppointmentTimes(Guid id, UpdateAppointmentTimesDto timesDto)
        {
            var appointment = await _jaysLashesDbContext.Appointments
                .Include(a => a.AppointmentProducts)
                .ThenInclude(ap => ap.Product).ThenInclude(p => p.ImageUpload)
                .Include(a => a.AppointmentServices)
                .ThenInclude(appS => appS.Service).ThenInclude(p => p.ImageUpload)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return default;
            }

            appointment.StartTime = timesDto.StartTime;
            appointment.EndTime = timesDto.EndTime;

            await _jaysLashesDbContext.SaveChangesAsync();

            return appointment;
        }

        public async Task<Appointment?> UpdateAppointmentStatus(Guid id, AppointmentStatus status)
        {
            var appointment = await _jaysLashesDbContext.Appointments.SingleOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return appointment;
            }

            appointment.Status = status;

            await _jaysLashesDbContext.SaveChangesAsync();

            return appointment;
        }

        public async Task<Appointment> UpdateAppointmentStatusSubmission(Guid id)
        {
            var appointment = await _jaysLashesDbContext.Appointments.SingleOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return appointment;
            }

            appointment.Status = AppointmentStatus.AwaitingApproval;

            await _jaysLashesDbContext.SaveChangesAsync();

            return appointment;
        }


        public async Task<Appointment> GetAppointment(Guid appointmentId)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.Where(a => a.Id == appointmentId)
                    .AsNoTracking()
                    .Include(a => a.AppointmentProducts).ThenInclude(ap => ap.Product).ThenInclude(p => p.ImageUpload)
                    .AsSplitQuery()
                    .Include(a => a.AppointmentServices).ThenInclude(ap => ap.Service).ThenInclude(s => s.ImageUpload)
                    .SingleOrDefaultAsync();

                return appointment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Appointment> GetAppointmentIndemnity(Guid appointmentId)
        {
            var appointment = await _jaysLashesDbContext.Appointments.AsNoTracking().SingleOrDefaultAsync(a => a.Id == appointmentId);

            return appointment;
        }

        public async Task<Guid> GetAppointmentId(Guid userId)
        {
            var appointment = await _jaysLashesDbContext.Appointments.Where(a => a.UserId == userId).Select(a => new { a.Id }).SingleOrDefaultAsync();

            return appointment.Id;
        }

        public async Task<bool> GetAppointmentExists(Guid id)
        {
            return await _jaysLashesDbContext.Appointments.AnyAsync(a => a.Id == id);
        }

        public async Task<Appointment?> GetAppointmentFinalization(Guid appointmentId)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.Where(a => a.Id == appointmentId)
                            .AsNoTracking()
                            .Include(a => a.AppointmentProducts).ThenInclude(ap => ap.Product).ThenInclude(p => p.ImageUpload)
                            .AsSplitQuery()
                            .Include(a => a.AppointmentServices).ThenInclude(ap => ap.Service).ThenInclude(s => s.ImageUpload)
                            .Include(a => a.User)
                            .SingleOrDefaultAsync();


                appointment.User = await DecryptUser(appointment.User);



                return appointment;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Appointment>> GetUpcomingAppointments()
        {
            var appointments = _jaysLashesDbContext.Appointments.Where(a => a.Status == AppointmentStatus.Confirmed)
                .AsNoTracking()
                .Include(a => a.User)
                .AsEnumerable();

            appointments = await DecryptUsers(appointments);

            return appointments;
        }

        public async Task<IEnumerable<Appointment>?> GetAppointments(AdminAppointmentSearchFilterDto filter)
        {
            var allAppointments = new List<Appointment>();
            if (filter.Status == null && filter.SearchString == null)
            {
                allAppointments = _jaysLashesDbContext.Appointments
                    .Include(a => a.User)
                    .Include(a => a.AppointmentServices).ThenInclude(s => s.Service)
                    .Include(a => a.AppointmentProducts).ThenInclude(p => p.Product)
                    .ToList();

                var decryptedAllAppointments = new List<Appointment>();
                foreach (var appointment in allAppointments)
                {
                    appointment.User = await DecryptUser(appointment.User);
                    decryptedAllAppointments.Add(appointment);
                }
                return decryptedAllAppointments;

            }
            if (filter.SearchString == null)
            {
                var allAppointmentsWithStatus = _jaysLashesDbContext.Appointments.Where(a => a.Status == filter.Status).AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.AppointmentProducts).ThenInclude(p => p.Product)
                .Include(a => a.AppointmentServices).ThenInclude(s => s.Service)
                .ToList();
                var decryptedAppointmentsNoSearchString = new List<Appointment>();
                foreach (var appointment in allAppointmentsWithStatus)
                {
                    appointment.User = await DecryptUser(appointment.User);
                    decryptedAppointmentsNoSearchString.Add(appointment);
                }
                return decryptedAppointmentsNoSearchString;
            }

            allAppointments = _jaysLashesDbContext.Appointments.Where(a => a.Status == filter.Status).AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.AppointmentProducts).ThenInclude(p => p.Product)
                .Include(a => a.AppointmentServices).ThenInclude(s => s.Service)
                .ToList();

            var decryptedAllAppointmentsWithStatus = new List<Appointment>();
            foreach (var appointment in allAppointments)
            {
                appointment.User = await DecryptUser(appointment.User);
                decryptedAllAppointmentsWithStatus.Add(appointment);
            }

            var appointments = decryptedAllAppointmentsWithStatus
                .Where(a =>
                    a.User.FirstName.Contains( filter.SearchString, StringComparison.CurrentCultureIgnoreCase ) || a.User.FirstName.Equals(filter.SearchString.ToLower())
                    || a.User.LastName.Contains(filter.SearchString, StringComparison.CurrentCultureIgnoreCase) || a.User.LastName.Equals(filter.SearchString.ToLower())
                    || a.User.Email.Contains(filter.SearchString, StringComparison.CurrentCultureIgnoreCase) || a.User.Email.Equals(filter.SearchString, StringComparison.CurrentCultureIgnoreCase)
                    || a.User.Phone.Equals(filter.SearchString))
                .Where(a => a.Status == filter.Status)
                .AsEnumerable();

            if (appointments == null)
            {
                return default;
            }


            return appointments;
        }

        public async Task<Appointment> GetAdminAppointment(Guid appointmentId)
        {
            try
            {
                var appointment = await _jaysLashesDbContext.Appointments.Where(a => a.Id == appointmentId)
                    .AsNoTracking().Include(a => a.User)
                    .Include(a => a.AppointmentProducts).ThenInclude(ap => ap.Product).ThenInclude(p => p.ImageUpload)
                    .AsSplitQuery()
                    .Include(a => a.AppointmentServices).ThenInclude(ap => ap.Service).ThenInclude(s => s.ImageUpload)
                    .SingleOrDefaultAsync();

                appointment.User = await DecryptUser(appointment.User);

                return appointment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentRequests()
        {
            var appointments = _jaysLashesDbContext.Appointments.Where(a => a.Status == AppointmentStatus.AwaitingApproval)
                .AsNoTracking()
                .Include(a => a.User)
                .AsEnumerable();


            appointments = await DecryptUsers(appointments);

            return appointments;
        }


        private async Task<List<Appointment>> DecryptUsers(IEnumerable<Appointment> appointments)
        {
            var decryptedAppointments = new List<Appointment>();

            foreach (var appointment in appointments)
            {
                appointment.User = await DecryptUser(appointment.User);

                decryptedAppointments.Add(appointment);
            }

            return decryptedAppointments;
        }

        private async Task<User> DecryptUser(User user)
        {
            try
            {
                if (user.FirstName != null)
                {
                    user.FirstName = await _encryptionService.DecryptString(user.FirstName);
                }
                if (user.LastName != null)
                {
                    user.LastName = await _encryptionService.DecryptString(user.LastName);
                }
                if (user.Email != null)
                {
                    user.Email = await _encryptionService.DecryptString(user.Email);
                }
                if (user.Phone != null)
                {
                    user.Phone = await _encryptionService.DecryptString(user.Phone);
                }

                return user;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e);
            }

        }

        public async Task<Appointment> UpdateAppointmentUser(Guid id, UpdateAppointmentUserDto dto)
        {
            var appointment = await _jaysLashesDbContext.Appointments.SingleOrDefaultAsync(a => a.Id == id);

            if (appointment != null)
            {
                appointment.UserId = dto.Id;
                await _jaysLashesDbContext.SaveChangesAsync();
            }


            return appointment;
        }

        public async Task<Appointment> AddAppointment(AppointmentToAddDto appointmentToAddDto)
        {
            try
            {

                var appointment = new Appointment()
                {
                    Id = appointmentToAddDto.Id,
                    UserId = appointmentToAddDto.UserId
                };

                var result = await _jaysLashesDbContext.AddAsync(appointment);
                await _jaysLashesDbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e);
            }
        }

        public async Task<Appointment> AddAppointment(AppointmentAdminToAddDto appointmentToAddDto)
        {
            try
            {
                var appointment = appointmentToAddDto.ConvertToEntity();

                var result = await _jaysLashesDbContext.AddAsync(appointment);
                await _jaysLashesDbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e);
            }
        }

        public async Task<Appointment> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto dto)
        {
            try
            {
                var appointment = _jaysLashesDbContext.Appointments.SingleOrDefault(a => a.Id == appointmentId);

                if (appointment == null)
                {
                    return default;
                }

                if (dto.StartTime > dto.EndTime)
                {
                    throw new ArgumentException("Start Time must be before Ending time");
                }


                appointment.StartTime = dto.StartTime;
                appointment.EndTime = dto.EndTime;
                appointment.IsDepositPaid = dto.IsDepositPaid;
                appointment.IsSampleSetComplete = dto.IsSampleSetComplete;
                appointment.HasHadEyelashExtentions = dto.HasHadEyelashExtentions;
                appointment.Status = dto.Status;

                var result = _jaysLashesDbContext.Appointments.Update(appointment);

                await _jaysLashesDbContext.SaveChangesAsync();

                return result.Entity;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Appointment>> GetBookedAppointmentsByDate(DateTime date)
        {
            return await _jaysLashesDbContext.Appointments.Where(a => a.EndTime.Value.Date == date.ToLocalTime().Date && a.Status >= AppointmentStatus.Confirmed).AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<Appointment>> GetBookedAppointmentsByRange(DateTime startDate, DateTime endDate)
        {
            return await _jaysLashesDbContext.Appointments.Where(a =>
            a.StartTime.Value.Date > startDate.Date
            && a.StartTime.Value.Date < endDate.Date
            && a.Status >= AppointmentStatus.Confirmed)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
