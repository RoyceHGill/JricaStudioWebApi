using JricaStudioWebAPI.Entities.Helpers;

namespace JricaStudioWebAPI.Entities
{
    public class BlockOutDate : BaseModel
    {
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
