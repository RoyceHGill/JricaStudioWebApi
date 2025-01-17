namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// This Represents a Category of service.
    /// </summary>
    public class ServiceCategory
    {
        /// <summary>
        /// The ID of the Service in the database.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Short name of the Category.
        /// </summary>
        public string Name { get; set; }
    }
}
