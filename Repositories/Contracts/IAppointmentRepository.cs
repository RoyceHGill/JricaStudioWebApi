using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.enums;
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;

namespace JricaStudioWebApi.Repositories.Contracts
{
    /// <summary>
    /// Data storage Interface, responsible for servicing the application with data related to appointments. 
    /// </summary>
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Adds a record to the AppointmentProduct table that represents many to many relationship between a products and an appointments. 
        /// Request is subject to User Restrictive Access.
        /// </summary>
        /// <param name="addDto">Container with both product and appointment details needed to create database relationship and record of the appointment.</param>
        /// <returns>The newly created record from the database.</returns>
        Task<AppointmentProduct> AddProductToAppointment(AppointmentProductToAddDto addDto);

        /// <summary>
        /// Add a record the AppointmentService table in the database, this represents a many to many relationship between services and appointments.
        /// </summary>
        /// <param name="addDto">A container with information responsible for creating the database relationship.</param>
        /// <returns>The newly create record from the database.</returns>
        Task<AppointmentService> AddServiceToAppointment(AppointmentServiceToAddDto addDto);

        /// <summary>
        /// Adds a record to the AppointmentProduct table that represents many to many relationship between a products and an appointments.
        /// Only implemented by Authorized Request.

        /// </summary>
        /// <param name="addDto">Container with both product and appointment details needed to create database relationship and record of the appointment.</param>
        /// <returns>The newly created record from the database.</returns>
        Task<AppointmentProduct> AdminAddProduct(AppointmentProductToAddDto addDto);

        /// <summary>
        /// Add a record the AppointmentService table in the database, this represents a many to many relationship between services and appointments.
        /// Only implemented by Authorized Request.
        /// </summary>
        /// <param name="addDto">A container with information responsible for creating the database relationship.</param>
        /// <returns>The newly create record from the database.</returns>
        Task<AppointmentService> AdminAddService(AppointmentServiceToAddDto addDto);


        /// <summary>
        /// Alter the Quantity attribute for the entity an entity in the database.
        /// </summary>
        /// <param name="appointmentProductId">Identifier Representing the Appointment Product Entity in the Database.</param>
        /// <param name="qtyDto">Container with the updated information</param>
        /// <returns>The updated Entity</returns>
        Task<AppointmentProduct> UpdateProductQty(Guid appointmentProductId, AppointmentProductQuantityUpdateDto qtyDto);

        /// <summary>
        /// Get all appointment products with a relationship with the give appointment's Id.
        /// </summary>
        /// <param name="appointmentId">GUID Appointment Identifier</param>
        /// <returns>Collection of products on the appointment</returns>
        Task<IEnumerable<AppointmentProduct>> GetProducts(Guid appointmentId);
        /// <summary>
        /// Get all appointment Services with a relationship with the given appointment's Id. 
        /// </summary>
        /// <param name="appoitmentId">GUID Appointment Identifier</param>
        /// <returns>Collection of services on the appointment</</returns>
        Task<IEnumerable<AppointmentService>> GetServices(Guid appoitmentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentProductId"></param>
        /// <returns></returns>
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
