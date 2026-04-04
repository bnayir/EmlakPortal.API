namespace EmlakPortal.API.DTOs
{
    public class PropertyDto
    {
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }

    }
}
