using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents the Showcase Service that Administrator wants to display.
    /// </summary>
    public class ServiceShowCase : BaseModel
    {
        /// <summary>
        /// The ID of the Service.
        /// </summary>
        public Guid ServiceId { get; set; }
        /// <summary>
        /// The Service Object.
        /// </summary>
        public Service Service { get; set; }
    }
}
