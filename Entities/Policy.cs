using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// This represents a policy of the bussiness.
    /// </summary>
    public class Policy : BaseModel
    {
        /// <summary>
        /// The short Title of the Policy.
        /// </summary>
        public string PolicyTitle { get; set; }

        /// <summary>
        /// The Body of the article. 
        /// </summary>
        public string PolicyArticle { get; set; }
    }
}
