namespace EmlakPortal.API.DTOs
{
    public class CityDto
    {

        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<DistrictDto> Districts { get; set; }
    }
}
