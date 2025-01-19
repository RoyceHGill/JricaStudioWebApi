using JricaStudioWebAPI.Entities.Helpers;

namespace JricaStudioWebAPI.Entities
{
    public class ServiceShowCase : BaseModel
    {
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
