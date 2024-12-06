using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.enums;
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IAppointmentRepository
    {
        Task<AppointmentProduct> AddProduct(AppointmentProductToAddDto addDto);
        Task<AppointmentService> AddService(AppointmentServiceToAddDto addDto);

        Task<AppointmentProduct> AdminAddProduct(AppointmentProductToAddDto addDto);
        Task<AppointmentService> AdminAddService(AppointmentServiceToAddDto addDto);

        Task<AppointmentProduct> UpdateProductQty(Guid id, AppointmentProductQuantityUpdateDto qtyDto);
        Task<AppointmentService> UpdateServiceQty(Guid id, AppointmentServiceUpdateQuantityDto qtyDto);

        Task<AppointmentService> GetService(Guid Id);
        Task<AppointmentProduct> GetProduct(Guid Id);

        Task<IEnumerable<AppointmentProduct>> GetProducts(Guid Id);
        Task<IEnumerable<AppointmentService>> GetServices(Guid Id);

        Task<IEnumerable<AppointmentProduct>> DeleteAppointmentProduct(Guid appointmentProductId);
        Task<IEnumerable<AppointmentService>> DeleteAppointmentService(Guid appointmentServiceId);

        Task<Appointment> AddAppointment(AppointmentToAddDto appointmentToAdd);
        Task<Appointment> AddAppointment(AppointmentAdminToAddDto appointmentToAdd);

        Task<bool> GetAppointmentExists(Guid id);
        Task<Appointment> GetAppointment(Guid appointmentId);
        Task<Appointment> GetAdminAppointment(Guid appointmentId);

        Task<Appointment> GetAppointmentIndemnity(Guid appointmentId);
        Task<Appointment> GetAppointmentFinalization(Guid appointmentId);
        Task<IEnumerable<Appointment>> GetAppointmentRequests();
        Task<IEnumerable<Appointment>> GetUpcomingAppointments();
        Task<IEnumerable<Appointment>> GetAppointments(AdminAppointmentSearchFilterDto filter);

        Task<Guid> GetAppointmentId(Guid userId);
        Task<Appointment> UpdateAppointmentIndemnityQuestions(Guid id, UpdateAppointmentIndemnityDto indemnityDto);
        Task<Appointment> UpdateAppointmentTimes(Guid id, UpdateAppointmentTimesDto timesDto);
        Task<Appointment> UpdateAppointmentStatus(Guid id, AppointmentStatus status);
        Task<Appointment> UpdateAppointmentStatusSubmission(Guid id);
        Task<Appointment> UpdateAppointmentUser(Guid id, UpdateAppointmentUserDto dto);
        Task<Appointment> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto dto);

        Task<IEnumerable<Appointment>> GetBookedAppointmentsByDate(DateTime date);
        Task<IEnumerable<Appointment>> GetBookedAppointmentsByRange(DateTime startdate, DateTime endDate);

    }
}
