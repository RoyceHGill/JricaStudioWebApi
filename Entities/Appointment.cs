using JricaStudioWebApi.Entities.Helpers;
using JricaStudioWebApi.Models.enums;
using NuGet.Packaging.Signing;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents an appointment in the system, including its details, associated user, 
    /// products, services, and status.
    /// </summary>
    public class Appointment : BaseModel
    {
        /// <summary>
        /// The unique identifier of the user associated with the appointment.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The start time of the appointment. Nullable.
        /// </summary>
        public DateTime? StartTime { get; set; } = null;

        /// <summary>
        /// The end time of the appointment. Nullable.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The user associated with the appointment.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Indicates whether the user has had eyelash extensions before.
        /// </summary>
        public bool HasHadEyelashExtentions { get; set; } = false;

        /// <summary>
        /// Indicator of whether the sample set for the appointment is complete.
        /// </summary>
        public bool IsSampleSetComplete { get; set; } = false;

        /// <summary>
        /// Indicator of whether the deposit for the appointment has been paid.
        /// </summary>
        public bool IsDepositPaid { get; set; } = false;

        /// <summary>
        /// The date and time when the sample set was completed. Nullable.
        /// </summary>
        public DateTime? SampleSetCompleted { get; set; }

        /// <summary>
        /// The collection of products associated with the appointment.
        /// </summary>
        public ICollection<AppointmentProduct>? AppointmentProducts { get; set; }

        /// <summary>
        /// The collection of services associated with the appointment.
        /// </summary>
        public ICollection<AppointmentService>? AppointmentServices { get; set; }

        /// <summary>
        /// The status of the appointment.
        /// The default value is <see cref="AppointmentStatus.NotFinalized"/>.
        /// </summary>
        public AppointmentStatus Status { get; set; } = AppointmentStatus.NotFinalized;
    }
}
