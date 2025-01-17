namespace JricaStudioWebApi.Entities.Filters
{
    /// <summary>
    /// Query builder for services to search against database.
    /// </summary>
    public class ServiceFilter
    {
        public Guid? Id { get; set; }
        public string? NamePartial { get; set; }
        public string? DescriptionPartial { get; set; }
        public decimal? PriceMax { get; set; }
        public decimal? PriceMin { get; set; }
    }
}
