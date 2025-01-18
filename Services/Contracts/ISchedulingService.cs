using JricaStudioSharedLibrary.Dtos;
using JricaStudioWebApi.Entities;

namespace JricaStudioWebApi.Services.Contracts
{
    /// <summary>
    /// Determines Availability of appointments.
    /// </summary>
    public interface ISchedulingService
    {
        /// <summary>
        /// Determines the next available time slot for a proposed appointment.
        /// </summary>
        /// <param name="blockOutDates">Dates the business has chosen to be closed. </param>
        /// <param name="appointments">Existing appointments</param>
        /// <param name="businessHours">The normal operating hours of the business.</param>
        /// <param name="dateRange">The number of days to look into the future.</param>
        /// <param name="duration">The amount of time needed to allocate the new appointment.</param>
        /// <returns>The next available appointment time.</returns>
        DateTime? GetNextAvailableAppointmentWindow(IEnumerable<BlockOutDate> blockOutDates, IEnumerable<Appointment> appointments, IEnumerable<BusinessHours> businessHours, int dateRange, TimeSpan duration);

        /// <summary>
        /// Given a Date determine all available time slots for the appointment.
        /// </summary>
        /// <param name="date">The date to search for available appointments.</param>
        /// <param name="duration">The duration of the proposed appointment.</param>
        /// <param name="existingAppointments">Existing appointments</param>
        /// <param name="businessHours">The normal business hours of business</param>
        /// <param name="blockOutDates">Dates the business has chosen to be closed.</param>
        /// <returns>Collection of available appointment Start times for the date provided.</returns>
        IEnumerable<AppointmentAvailableDto> GetAvailableAppointmentWindowsForADate(DateTime date, TimeSpan duration, IEnumerable<Appointment> existingAppointments, IEnumerable<BusinessHours> businessHours, IEnumerable<BlockOutDate> blockOutDates);

        /// <summary>
        /// Find Dates that have no available time slots for a proposed appointment.
        /// </summary>
        /// <param name="appointments">A collection of existing approved appointments </param>
        /// <param name="businessHours">The business normal operating hours.</param>
        /// <param name="blockOutDates">The dates the business has chosen to close.</param>
        /// <param name="dateRange">The number of day searching forward to search.</param>
        /// <param name="duration">The duration of the appointment.</param>
        /// <returns>A list of days that have not available time slots available for the proposed appointment.</returns>
        public IEnumerable<DateTime> GetUnavailableDates(IEnumerable<Appointment> appointments, IEnumerable<BusinessHours> businessHours, IEnumerable<BlockOutDate> blockOutDates, int dateRange, TimeSpan duration);
    }


}
