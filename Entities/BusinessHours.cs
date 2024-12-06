using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    public class BusinessHours : BaseModel
    {
        public DayOfWeek Day { get; set; }
        public TimeOnly? OpenTime { get; set; }
        public TimeOnly? CloseTime { get; set; }
        public TimeSpan LocalTimeOffset { get; set; }
        public bool IsDisabled { get; set; }
        public int AfterHoursGraceRange { get; set; } = 2;
    }
}
