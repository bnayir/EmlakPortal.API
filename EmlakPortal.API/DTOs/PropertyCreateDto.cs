namespace EmlakPortal.API.DTOs
{
    public class PropertyCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Sayısal (Zorunlu) Alanlar
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int CategoryId { get; set; }
        public int SquareMeter { get; set; }

        // Metin (Zorunlu) Alanlar
        public string RoomCount { get; set; }
        public string PropertyType { get; set; }
        public string FloorsCount { get; set; }
        public string FloorLocation { get; set; }
        public string Heating { get; set; }
        public string ImageUrl { get; set; }
    }
}