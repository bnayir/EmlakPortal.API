namespace EmlakPortal.API.DTOs
{
    public class FilterDto
    {
        public int? CityId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SortBy { get; set; }
        public string? Keyword { get; set; }

    }
}
