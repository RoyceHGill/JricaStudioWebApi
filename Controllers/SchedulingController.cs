using JricaStudioWebAPI.Models.Dtos;
using JricaStudioWebAPI.Models.Dtos.Admin;
using JricaStudioWebAPI.Attributes;
using JricaStudioWebAPI.Extentions;
using JricaStudioWebAPI.Repositories.Contracts;
using JricaStudioWebAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using JricaStudioWebAPI.Models.Dtos.Admin.BusinessHours;
using JricaStudioWebAPI.Models.Dtos.BusinessHours;

namespace JricaStudioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly ISchedulingService _schedulingService;

        public SchedulingController(IAppointmentRepository AppointmentRepository, ISchedulingRepository schedulingRepository, ISchedulingService schedulingService)
        {
            _appointmentRepository = AppointmentRepository;
            _schedulingRepository = schedulingRepository;
            _schedulingService = schedulingService;
        }

        [HttpGet("GetAvailability/Times")]
        public async Task<ActionResult<IEnumerable<AppointmentAvailableDto>>> GetAvailableAppointments([FromQuery] DateTime date, [FromQuery] TimeSpan duration)
        {
            // Get the appointments from the Database.
            var existingAppointments = await _appointmentRepository.GetBookedAppointmentsByDate(date);

            // Get the business hours from that database.
            var businessHours = await _schedulingRepository.GetBusinessHours();

            var blockOutDates = await _schedulingRepository.GetUpcomingBlockOutDates();

            var availableAppointments = _schedulingService.GetAvailableAppointmentWindowsForADate(date, duration, existingAppointments, businessHours, blockOutDates);

            if (!availableAppointments.Any())
            {
                return NoContent();
            }
            return Ok(availableAppointments);
        }



        [HttpGet("GetUnavailability/Dates")]
        public async Task<ActionResult<IEnumerable<AppointmentUnavailaleDateDto>>> GetUnavailableDates(int dateRange, TimeSpan duration)
        {
            try
            {
                var startDate = DateTime.UtcNow;
                var endDate = DateTime.UtcNow.AddDays(dateRange);

                var appointments = await _schedulingRepository.GetBookedAppointmentsByDates(startDate, endDate);

                var businessHours = await _schedulingRepository.GetBusinessHours();

                var blockOutDates = await _schedulingRepository.GetBlockOutDatesByDates(startDate, endDate);

                var unavailableDates = _schedulingService.GetUnavailableDates(appointments, businessHours, blockOutDates, dateRange, duration);

                if (!unavailableDates.Any())
                {
                    return NoContent();
                }

                var Dtos = new List<AppointmentUnavailaleDateDto>();

                foreach (var item in unavailableDates)
                {
                    Dtos.Add(new AppointmentUnavailaleDateDto
                    {
                        UnavailableDate = item
                    });
                }

                return Ok(Dtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetAvailability/NextTime")]
        public async Task<ActionResult<AppointmentAvailableDto>> GetNextAvailableAppointments([FromQuery] int dateRange, TimeSpan duration)
        {

            var blockoutDatesAll = await _schedulingRepository.GetBlockOutDatesByDates(DateTime.UtcNow, DateTime.UtcNow.AddDays(dateRange));

            var businessHours = await _schedulingRepository.GetBusinessHours();

            var appointments = await _appointmentRepository.GetBookedAppointmentsByRange(DateTime.UtcNow, DateTime.UtcNow.AddDays(dateRange));

            var availableTime = _schedulingService.GetNextAvailableAppointmentWindow(blockoutDatesAll, appointments, businessHours, dateRange, duration);
            if (availableTime == default)
            {
                return NoContent();
            }
            else
            {
                return Ok(new AppointmentAvailableDto()
                {
                    Duration = duration,
                    StartTime = availableTime.GetValueOrDefault()
                });
            }


        }

        [AdministratorKey]
        [HttpGet("AdminBusinessHours")]
        public async Task<ActionResult<IEnumerable<AdminBusinessHoursDto>>> GetAdminBusinessHours()
        {
            try
            {
                var businessHours = await _schedulingRepository.GetBusinessHours();

                if (businessHours == null)
                {
                    return NoContent();
                }

                var dtos = businessHours.ConvertToAdminDtoa();

                return Ok(dtos);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetBusinessHours")]
        public async Task<ActionResult<IEnumerable<BusinessHoursDto>>> GetBusinessHours()
        {
            try
            {
                var businessHours = await _schedulingRepository.GetBusinessHours();

                if (businessHours == null)
                {
                    return NotFound();
                }

                return Ok(businessHours.ConvertToDto());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }





        }

        [AdministratorKey]
        [HttpPut("BusinessHours")]
        public async Task<ActionResult<IEnumerable<AdminBusinessHoursDto>>> PutAdminBusinessHours(IEnumerable<AdminBusinessHoursDto> dtos)
        {
            try
            {
                foreach (var item in dtos)
                {
                    if (item.OpenTime > item.CloseTime)
                    {
                        return BadRequest($"{item.Day}, Close Time must be later then Open Time.");
                    }
                }

                dtos = ConvertTimesToUtc(dtos);

                var businessHours = await _schedulingRepository.UpdateBusinessHours(dtos);

                if (businessHours == null)
                {
                    return NotFound();
                }

                var adminDtos = businessHours.ConvertToAdminDtoa();

                return Ok(adminDtos);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdministratorKey]
        [HttpGet("BlockOutDates")]
        public async Task<ActionResult<IEnumerable<BlockOutDatesAdminDto>>> GetAdminBlockOutDates()
        {
            try
            {
                var blockOutDates = await _schedulingRepository.GetUpcomingBlockOutDates();

                if (blockOutDates == null)
                {
                    return NoContent();
                }

                var dtos = blockOutDates.ConvertToAdminDtos();

                return Ok(dtos);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdministratorKey]
        [HttpPost("BlockOutDates")]
        public async Task<ActionResult<IEnumerable<BlockOutDatesAdminDto>>> PostNewBlockOutDate(BlockOutDateToAddDto dto)
        {
            try
            {
                var blockOutDates = await _schedulingRepository.AddBlockOutDate(dto);

                if (blockOutDates == null)
                {
                    return NoContent();
                }

                var adminDto = blockOutDates.ConvertToAdminDtos();

                return Ok(adminDto);

            }
            catch (ArgumentException ae)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, ae.Message);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdministratorKey]
        [HttpDelete("BlockOutDates/{id:guid}")]
        public async Task<ActionResult<IEnumerable<BlockOutDatesAdminDto>>> DeleteBlockOutDate(Guid id)
        {
            try
            {
                var blockOutDates = await _schedulingRepository.DeleteBlockOutDateById(id);

                if (blockOutDates == null)
                {
                    return NoContent();
                }

                var adminDtos = blockOutDates.ConvertToAdminDtos();
                return Ok(adminDtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        private IEnumerable<AdminBusinessHoursDto> ConvertTimesToUtc(IEnumerable<AdminBusinessHoursDto> businessHoursDtos)
        {
            foreach (var item in businessHoursDtos)
            {
                item.OpenTime = item.OpenTime.Value.Add(-item.LocalTimeOffset);
                item.CloseTime = item.CloseTime.Value.Add(-item.LocalTimeOffset);
            }
            return businessHoursDtos;
        }
    }


}
