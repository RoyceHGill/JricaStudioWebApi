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
        /// Remove the product from the appointment. Delete the record of the appointment product from the database. 
        /// </summary>
        /// <param name="appointmentProductId">GUID appointment product record's ID</param>
        /// <returns>The list of appointment products for an appointment after changes.</returns>
        Task<IEnumerable<AppointmentProduct>> DeleteAppointmentProduct(Guid appointmentProductId);
        /// <summary>
        /// Remove the service from the appointment. Delete the record of the appointment service from the database. 
        /// </summary>
        /// <param name="appointmentServiceId">GUID appointment service record's ID</param>
        /// <returns>The list of appointment services for an appointment after changes.</returns>
        Task<IEnumerable<AppointmentService>> DeleteAppointmentService(Guid appointmentServiceId);

        /// <summary>
        /// Creates an appointment for the user.
        /// </summary>
        /// <param name="appointmentToAdd">Object responsible for transferring information to create an appointment in the database</param>
        /// <returns>The Created Appointment</returns>
        Task<Appointment> AddAppointment(AppointmentToAddDto appointmentToAdd);

        /// <summary>
        /// Used by the administrator of the site to create appointments. 
        /// </summary>
        /// <param name="appointmentToAdd">Appointment Details</param>
        /// <returns>The Created appointment</returns>
        Task<Appointment> AddAppointment(AppointmentAdminToAddDto appointmentToAdd);

        /// <summary>
        /// Get appointment details for the ID provided
        /// </summary>
        /// <param name="appointmentId">GUID ID for Appointment</param>
        /// <returns>The requested appointment Details</returns>
        Task<Appointment> GetAppointment(Guid appointmentId);

        /// <summary>
        /// Gets the administrator's version of the appointment details, only used in authorized requests.
        /// </summary>
        /// <param name="appointmentId">GUID ID for Appointment.</param>
        /// <returns>The requested appointment details.</returns>
        Task<Appointment> GetAdminAppointment(Guid appointmentId);

        /// <summary>
        /// Get the Information necessary for Appointment Indemnity page this includes some User information.
        /// </summary>
        /// <param name="appointmentId">GUID ID for Appointment.</param>
        /// <returns>The requested appointment details.</returns>
        Task<Appointment> GetAppointmentIndemnity(Guid appointmentId);

        /// <summary>
        /// Get the information necessary for the Appointment finalization page for the client. 
        /// </summary>
        /// <param name="appointmentId">GUID ID for Appointment.</param>
        /// <returns>Appointment details and User details needed for finalization page on client. </returns>
        Task<Appointment> GetAppointmentFinalization(Guid appointmentId);

        /// <summary>
        /// Get a collection of appointments with the status of awaiting approval signifying that the appointment is a request from a user.
        /// </summary>
        /// <returns>A collection of appointments with the status of awaiting approval. </returns>
        Task<IEnumerable<Appointment>> GetAppointmentRequests();

        /// <summary>
        /// Get a collection of appointments with the status of Confirmed signifying that the appointment is approved and time is allocated.
        /// </summary>
        /// <returns>A collection of appointments with the status of Confirmed.</returns>
        Task<IEnumerable<Appointment>> GetUpcomingAppointments();

        /// <summary>
        /// Query the database with a filter. Used for searching for appointments by an administrator.
        /// </summary>
        /// <param name="filter">collection of parameters seeking a match in the database.</param>
        /// <returns>All appointment with data that is a partial match in the database.</returns>
        Task<IEnumerable<Appointment>> GetAppointments(AdminAppointmentSearchFilterDto filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="indemnityDto"></param>
        /// <returns></returns>
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
