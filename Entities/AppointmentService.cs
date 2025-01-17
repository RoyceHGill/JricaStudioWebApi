using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents a service on an appointment.
    /// </summary>
    public class AppointmentService : BaseModel
    {
        /// <summary>
        /// Represents the Appointment the service is on
        /// </summary>
        public Guid AppointmentId { get; set; }

        /// <summary>
        /// Represents the Service on the appointment.
        /// </summary>
        public Guid ServiceId { get; set; }

        /// <summary>
        /// The appointment's Details
        /// </summary>
        public Appointment Appointment { get; set; }

        /// <summary>
        /// The Service's Details.
        /// </summary>
        public Service Service { get; set; }

    }
}
