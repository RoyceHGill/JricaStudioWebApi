using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    public class ServiceShowCase : BaseModel
    {
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
