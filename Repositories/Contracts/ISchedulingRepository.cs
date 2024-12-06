using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos.Admin.BusinessHours;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface ISchedulingRepository
    {
        Task<IEnumerable<Appointment>> GetBookedAppointmentsByDates(DateTime startDate , DateTime endDate);
        //Task<IEnumerable<Appointment>> GetAppointmentsByDate(DateTime date);
        //Task<Appointment> UpdateAppointmentTimes();
        //Task<BlockOutDate> AddBlockOutDate();
        //Task<BlockOutDate> RemoveBlockOutDate();
        //Task<BlockOutDate> UpdateBlockOutDate();
        Task<IEnumerable<BlockOutDate>> GetBlockOutDatesByDates(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BlockOutDate>> GetBlockOutDatesByDates(DateOnly startDate, DateOnly endDate);

        Task<IEnumerable<BlockOutDate>> GetUpcomingBlockOutDates();
        Task<IEnumerable<BlockOutDate>> AddBlockOutDate(BlockOutDateToAddDto dto);
        Task<IEnumerable<BlockOutDate>> DeleteBlockOutDateById(Guid id);

        Task<IEnumerable<BusinessHours>> GetBusinessHours();
        //Task<BusinessHours> UpdateBusinessHours();
        //Task<BusinessHours> RemoveBusinessHours();
        //Task<BusinessHours> AddBusinessHours();
        Task<IEnumerable<BusinessHours>> UpdateBusinessHours(IEnumerable<AdminBusinessHoursDto> dtos);
    }
}
