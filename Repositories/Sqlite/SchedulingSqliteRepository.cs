
using JricaStudioWebAPI.Models.Dtos.Admin;
using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using JricaStudioWebAPI.Models.Dtos.Admin.BusinessHours;
using NuGet.Protocol;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    /// <inheritdoc cref="ISchedulingRepository"/>
    public class SchedulingSqLiteRepository : ISchedulingRepository
    {
        private readonly JaysLashesDbContext _jaysLashesDbContext;

        public SchedulingSqLiteRepository( JaysLashesDbContext jaysLashesDbContext )
        {
            _jaysLashesDbContext = jaysLashesDbContext;
        }

        public async Task<IEnumerable<Appointment>> GetBookedAppointmentsByDates( DateTime startDate, DateTime endDate )
        {
            return await _jaysLashesDbContext.Appointments.Where( a => a.StartTime >= startDate && a.StartTime <= endDate && a.IsDepositPaid ).ToListAsync();
        }
        public async Task<IEnumerable<BlockOutDate>> GetBlockOutDatesByDates( DateTime startDate, DateTime endDate )
        {
            var startDateOnly = DateOnly.FromDateTime( startDate );
            var endDateOnly = DateOnly.FromDateTime( endDate );
            return await _jaysLashesDbContext.BlockOutDates.Where( b => b.Date >= startDateOnly && b.Date <= endDateOnly ).ToListAsync();
        }
        public async Task<IEnumerable<BlockOutDate>> GetBlockOutDatesByDates( DateOnly startDate, DateOnly endDate )
        {
            return await _jaysLashesDbContext.BlockOutDates.Where( b => b.Date >= startDate && b.Date <= endDate ).ToListAsync();
        }

        public async Task<IEnumerable<BusinessHours>> GetBusinessHours()
        {
            return await _jaysLashesDbContext.BusinessHours.ToListAsync();
        }



        public async Task<IEnumerable<BusinessHours>> UpdateBusinessHours( IEnumerable<AdminBusinessHoursDto> businessHoursUpdate )
        {
            try
            {
                var businessHours = _jaysLashesDbContext.BusinessHours.AsEnumerable();

                if ( !businessHours.Any() )
                {
                    var newBusinessHoursCollection = new List<BusinessHours>();

                    foreach ( var dto in businessHoursUpdate )
                    {
                        var newBusinessHours = new BusinessHours()
                        {
                            AfterHoursGraceRange = dto.AfterHoursGraceRange,
                            CloseTime = dto.CloseTime,
                            OpenTime = dto.OpenTime,
                            Day = dto.Day,
                            IsDisabled = dto.IsDisabled,
                            LocalTimeOffset = dto.LocalTimeOffset,
                        };

                        var result = _jaysLashesDbContext.BusinessHours.Add( newBusinessHours );

                        await _jaysLashesDbContext.SaveChangesAsync();


                        newBusinessHoursCollection.Add( result.Entity );
                    }

                    return newBusinessHoursCollection;
                }

                var updatedBusinessHours = new List<BusinessHours>();
                foreach ( var itemDto in businessHoursUpdate )
                {
                    var entity = businessHours.SingleOrDefault( b => b.Id == itemDto.Id );
                    if ( entity != null )
                    {
                        entity.IsDisabled = itemDto.IsDisabled;
                        entity.AfterHoursGraceRange = itemDto.AfterHoursGraceRange;
                        entity.OpenTime = itemDto.OpenTime;
                        entity.CloseTime = itemDto.CloseTime;
                        entity.LocalTimeOffset = itemDto.LocalTimeOffset;

                        var result = _jaysLashesDbContext.BusinessHours.Update( entity );

                        updatedBusinessHours.Add( result.Entity );
                    }
                }
                await _jaysLashesDbContext.SaveChangesAsync();
                return updatedBusinessHours;
            }
            catch ( Exception e )
            {

                throw;
            }
        }

        public async Task<IEnumerable<BlockOutDate>> GetUpcomingBlockOutDates()
        {
            try
            {
                var todaysDate = DateOnly.FromDateTime( DateTime.UtcNow );
                var blockOutDates = await _jaysLashesDbContext.BlockOutDates.Where( b => b.Date >= todaysDate ).ToListAsync();

                if ( blockOutDates == null )
                {
                    return default;
                }

                return blockOutDates;
            }
            catch ( Exception e )
            {

                throw;
            }
        }

        public async Task<IEnumerable<BlockOutDate>> AddBlockOutDate( BlockOutDateToAddDto blockOutDate )
        {
            try
            {
                var todaysDate = DateOnly.FromDateTime( DateTime.Today );


                if ( blockOutDate.Date < todaysDate )
                {
                    throw new ArgumentException( "Block out date has to be a future date." );
                }
                var blockoutDate = await _jaysLashesDbContext.BlockOutDates.SingleOrDefaultAsync( b => b.Date == blockOutDate.Date );

                if ( blockoutDate != null )
                {
                    throw new ArgumentException( "Date already Blocked out" );
                }

                var result = _jaysLashesDbContext.BlockOutDates.Add( new BlockOutDate
                {
                    Date = blockOutDate.Date,
                } );

                await _jaysLashesDbContext.SaveChangesAsync();

                return _jaysLashesDbContext.BlockOutDates.Where( b => b.Date >= todaysDate ).AsEnumerable();

            }
            catch ( Exception e )
            {

                throw;
            }
        }

        public async Task<IEnumerable<BlockOutDate>> DeleteBlockOutDateById( Guid id )
        {
            try
            {
                var blockOutDate = await _jaysLashesDbContext.BlockOutDates.SingleOrDefaultAsync( b => b.Id == id );
                var todaysDate = DateOnly.FromDateTime( DateTime.Today );

                if ( blockOutDate == null )
                {
                    return default;
                }

                var result = _jaysLashesDbContext.BlockOutDates.Remove( blockOutDate );

                await _jaysLashesDbContext.SaveChangesAsync();

                return _jaysLashesDbContext.BlockOutDates.Where( b => b.Date <= todaysDate ).AsEnumerable();
            }
            catch ( Exception e )
            {

                throw;
            }
        }
    }
}
