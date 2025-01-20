using JricaStudioWebAPI.Models.Dtos.Admin;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Models.Dtos.Admin.BusinessHours;

namespace JricaStudioWebAPI.Repositories.Contracts
{
    public interface ISchedulingRepository
    {

        #region Create
        Task<IEnumerable<BlockOutDate>> AddBlockOutDate(BlockOutDateToAddDto dto);

        #endregion

        #region Read

        /// <summary>
        /// Get all booked appointments between two dates. booked appointments are appointments are appointments that are Confirmed or higher in the progress.
        /// </summary>
        /// <param name="startDate">earliest date</param>
        /// <param name="endDate">latest date</param>
        /// <returns>All appointments that are confirmed and are upcoming.</returns>
        Task<IEnumerable<Appointment>> GetBookedAppointmentsByDates(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets all Block out dates between two dates.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end data.</param>
        /// <returns>Block out dates that are unable to be booked.</returns>
        Task<IEnumerable<BlockOutDate>> GetBlockOutDatesByDates(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Get all block out dates that are ahead in time. 
        /// </summary>
        /// <returns>Only future block out dates.</returns>
        Task<IEnumerable<BlockOutDate>> GetUpcomingBlockOutDates();

        /// <summary>
        /// Get a Collection of business hours.
        /// </summary>
        /// <returns>Seven Business hour object one for each day of the week.</returns>
        Task<IEnumerable<BusinessHours>> GetBusinessHours();

        #endregion

        #region Update
        /// <summary>
        /// Change the Business hours.
        /// </summary>
        /// <param name="dtos">Collections of 7 Business hour object one for each day of the week.</param>
        /// <returns> The updated business hours.</returns>
        Task<IEnumerable<BusinessHours>> UpdateBusinessHours(IEnumerable<AdminBusinessHoursDto> dtos);

        #endregion

        #region Delete
        /// <summary>
        /// Remove a single block out date. 
        /// </summary>
        /// <param name="id">The Id of the block out date entity.</param>
        /// <returns>The successfully removed block out date.</returns>
        Task<IEnumerable<BlockOutDate>> DeleteBlockOutDateById(Guid id);

        #endregion



    }
}
