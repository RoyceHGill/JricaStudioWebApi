namespace JricaStudioWebApi.Entities.Filters
{
    public class ServiceFilter
    {
        public Guid? Id { get; set; }
        public string? NamePartial { get; set; }
        public string? DescriptionPartial { get; set; }
        public decimal? PriceMax { get; set; }
        public decimal? PriceMin { get; set; }
    }
}
