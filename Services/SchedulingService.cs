using JricaStudioSharedLibrary.Dtos;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Services.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JricaStudioWebAPI.Services
{
    public class SchedulingService : ISchedulingService
    {

        public IEnumerable<DateTime> GetUnavailableDates( IEnumerable<Appointment> appointments, IEnumerable<BusinessHours> businessHours, IEnumerable<BlockOutDate> blockOutDates, int dateRange, TimeSpan duration )
        {

            if ( !businessHours.Any() )
            {
                return Enumerable.Empty<DateTime>();
            }

            var seeker = DateTime.UtcNow.Date;

            var unavailableDates = new List<DateTime>();

            for ( int i = 0; i < dateRange; i++ )
            {
                if ( CheckBussinessHoursDisabled( seeker, businessHours ) )
                {
                    unavailableDates.Add( seeker );
                    seeker = seeker.AddDays( 1 );
                    continue;
                }

                if ( CheckBlockOutDateConflicts( seeker, duration, blockOutDates ) )
                {
                    unavailableDates.Add( seeker );
                    seeker = seeker.AddDays( 1 );
                    continue;
                }

                for ( int j = 0; j <= 24; j++ )
                {



                    if ( seeker < DateTime.UtcNow )
                    {
                        seeker = seeker.AddHours( 1 );
                        continue;
                    }

                    if ( CheckBusinessHoursConflicts( seeker, duration, businessHours ) )
                    {
                        seeker = seeker.AddHours( 1 );
                        continue;
                    }

                    if ( CheckAppointmentConflicts( seeker, duration, appointments ) )
                    {
                        seeker = seeker.AddHours( 1 );
                        continue;
                    }

                    if ( j == 24 )
                    {
                        unavailableDates.Add( seeker );
                        break;
                    }

                    seeker = seeker.AddDays( 1 ).Date;
                    break;

                }

            }

            if ( unavailableDates.Any() )
            {
                return unavailableDates;
            }

            return Enumerable.Empty<DateTime>();


        }



        public IEnumerable<AppointmentAvailableDto> GetAvailableAppointmentWindowsForADate( DateTime date, TimeSpan duration, IEnumerable<Appointment> existingAppointments, IEnumerable<BusinessHours> businessHours, IEnumerable<BlockOutDate> blockOutDates )
        {
            if ( !businessHours.Any() )
            {
                return Enumerable.Empty<AppointmentAvailableDto>();
            }

            DateTime seeker = date.Add( -businessHours.Single( b => b.Day == date.DayOfWeek ).LocalTimeOffset );



            var listOfAvailableTimes = new List<AppointmentAvailableDto>();

            for ( int j = 0; j < 24; j++ )
            {

                if ( CheckBussinessHoursDisabled( seeker, businessHours ) )
                {
                    seeker = seeker.AddHours( 1 );
                    continue;
                }

                if ( CheckBlockOutDateConflicts( seeker, duration, blockOutDates ) )
                {
                    seeker = seeker.AddHours( 1 );
                    continue;
                }

                if ( seeker < DateTime.UtcNow )
                {
                    seeker = seeker.AddHours( 1 );
                    continue;
                }

                if ( CheckBusinessHoursConflicts( seeker, duration, businessHours ) )
                {
                    seeker = seeker.AddHours( 1 );
                    continue;
                }

                if ( existingAppointments.Any() )
                {
                    if ( CheckAppointmentConflicts( seeker, duration, existingAppointments ) )
                    {
                        seeker = seeker.AddHours( 1 );
                        continue;
                    }
                }

                listOfAvailableTimes.Add( new AppointmentAvailableDto
                {
                    Duration = duration,
                    StartTime = seeker,
                } );
                seeker = seeker.AddHours( 1 );

            }

            if ( listOfAvailableTimes.Any() )
            {
                return listOfAvailableTimes;
            }

            return Enumerable.Empty<AppointmentAvailableDto>();
        }


        public DateTime? GetNextAvailableAppointmentWindow( IEnumerable<BlockOutDate> blockOutDates, IEnumerable<Appointment> appointments, IEnumerable<BusinessHours> businessHours, int dateRange, TimeSpan duration )
        {
            if ( !businessHours.Any() )
            {
                return default;
            }
            DateTime date = DateTime.UtcNow.Date;

            DateTime seeker = date.Add( -businessHours.Single( b => b.Day == date.DayOfWeek ).LocalTimeOffset );
            DateTime nextAppointment = DateTime.MinValue;
            for ( int i = 0; i < dateRange; i++ )
            {



                for ( int j = 0; j < 24; j++ )
                {
                    if ( blockOutDates.Any() )
                    {
                        if ( CheckBlockOutDateConflicts( seeker, duration, blockOutDates ) )
                        {
                            seeker = seeker.AddHours( 1 );
                            continue;
                        }
                    }

                    if ( CheckBussinessHoursDisabled( seeker, businessHours ) )
                    {
                        seeker = seeker.AddHours( 1 );
                        continue;
                    }


                    if ( seeker < DateTime.UtcNow )
                    {
                        seeker = seeker.AddHours( 1 );
                        continue;
                    }

                    if ( CheckBusinessHoursConflicts( seeker, duration, businessHours ) )
                    {
                        seeker = seeker.AddHours( 1 );
                        continue;
                    }

                    if ( appointments.Any() )
                    {
                        if ( CheckAppointmentConflicts( seeker, duration, appointments ) )
                        {
                            seeker = seeker.AddHours( 1 );
                            continue;
                        }
                    }
                    return seeker;
                }
            }

            return default;
        }

        private bool CheckAppointmentConflicts( DateTime startTime, TimeSpan duration, IEnumerable<Appointment> appointments )
        {
            if ( appointments.Any( a => startTime < a.EndTime && a.StartTime < startTime.Add( duration ) ) )
            {
                return true;
            }
            return false;
        }

        private bool CheckBlockOutDateConflicts( DateTime startTime, TimeSpan duration, IEnumerable<BlockOutDate> blockoutDates )
        {
            if ( blockoutDates.Any( b => b.Date == DateOnly.FromDateTime( startTime.ToLocalTime() ) ) )
            {
                return true;
            }
            return false;
        }

        private bool CheckBusinessHoursConflicts( DateTime startTime, TimeSpan duration, IEnumerable<BusinessHours> businessHours )
        {


            var todaysBusinessHours = businessHours.SingleOrDefault( b => b.Day == startTime.Add( duration ).DayOfWeek );

            if ( todaysBusinessHours != null
                && todaysBusinessHours.OpenTime.HasValue
                && todaysBusinessHours.CloseTime.HasValue )
            {
                var gracefullBusinessCloseHours = TimeSpan.FromHours( todaysBusinessHours.AfterHoursGraceRange );
                var todaysDate = DateOnly.FromDateTime( startTime.Add( duration ) );
                var todaysOpenTime = todaysDate.ToDateTime( todaysBusinessHours.OpenTime.Value );
                var todaysCloseTime = todaysDate.ToDateTime( todaysBusinessHours.CloseTime.Value.Add( gracefullBusinessCloseHours ) );


                if ( todaysOpenTime > todaysCloseTime )
                {
                    todaysOpenTime = todaysOpenTime.AddDays( -1 );
                }

                if ( startTime >= todaysOpenTime
                    && startTime.Add( duration ) <= todaysCloseTime )
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckBussinessHoursDisabled( DateTime startTime, IEnumerable<BusinessHours> businessHours )
        {
            startTime = startTime.AddHours( 10 );
            if ( !businessHours.Any( b => b.Day == startTime.DayOfWeek && b.IsDisabled ) )
            {
                return false;
            }
            return true;
        }
    }
}
