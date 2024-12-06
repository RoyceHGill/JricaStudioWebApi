namespace JricaStudioWebApi.Entities.Filters
{
    public class ProductFilter
    {
        public Guid Id { get; set; }
        public string? NamePartial { get; set; }
        public string? DescriptionPartial { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
    }
}
