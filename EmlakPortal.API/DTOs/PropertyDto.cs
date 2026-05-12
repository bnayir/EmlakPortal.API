namespace EmlakPortal.API.DTOs
{
    public class PropertyDto
    {
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public int SquareMeter { get; set; }
        public string RoomCount { get; set; }
        public string PropertyType { get; set; }
        public string FloorsCount { get; set; }
        public string FloorLocation { get; set; }
        public string Heating { get; set; }

        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string AppUserId { get; set; } 
    }
}