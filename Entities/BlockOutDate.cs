using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents a day the Administrator is unable to operate the business.
    /// </summary>
    public class BlockOutDate : BaseModel
    {
        /// <summary>
        /// The date the business is not operating.
        /// </summary>
        public DateOnly Date { get; set; }
    }
}
