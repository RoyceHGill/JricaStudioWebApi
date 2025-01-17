using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents a Days Business hours in the database. 
    /// </summary>
    public class BusinessHours : BaseModel
    {
        /// <summary>
        /// The Day the business hours belongs to.
        /// </summary>
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// The Time the business opens.
        /// </summary>
        public TimeOnly? OpenTime { get; set; }

        /// <summary>
        /// The Time the business Closes.
        /// </summary>
        public TimeOnly? CloseTime { get; set; }

        /// <summary>
        /// The LocalTimes offset to UTC time.
        /// </summary>
        public TimeSpan LocalTimeOffset { get; set; }

        /// <summary>
        /// Is the business Closed this day every week.
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// The number of hours after the close time the last appointment of the day can run past.
        /// </summary>
        public int AfterHoursGraceRange { get; set; } = 2;
    }
}
