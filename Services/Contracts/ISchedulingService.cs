using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Entities;

namespace JricaStudioWebApi.Services.Contracts
{
    public interface ISchedulingService
    {
        DateTime? GetNextAvailableAppointmentWindow(IEnumerable<BlockOutDate> blockOutDates, IEnumerable<Appointment> appointments, IEnumerable<BusinessHours> businessHours, int dateRange, TimeSpan duration);

        IEnumerable<AppointmentAvailableDto> GetAvailableAppointmentWindowsForADate(DateTime date, TimeSpan duration, IEnumerable<Appointment> existingAppointments, IEnumerable<BusinessHours> businessHours, IEnumerable<BlockOutDate> blockOutDates);


        public IEnumerable<DateTime> GetUnavailableDates(IEnumerable<Appointment> appointments, IEnumerable<BusinessHours> businessHours, IEnumerable<BlockOutDate> blockOutDates, int dateRange, TimeSpan duration);
    }


}
