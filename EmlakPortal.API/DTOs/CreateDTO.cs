namespace EmlakPortal.API.DTOs
{
    public class CreateDTO
    { 
        public class CategoryCreateDto
        { 
            public string CategoryName {  get; set; }
            public bool Status { get; set; }
        }

        public class CityCreateDto
        {
            public string CityName { get; set; }
        }

        public class DistrictCreateDto
        {
            public string DistrictName { get; set; }
            public int CityId { get; set; }
        }

        public class PropertyCreateDto
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }

        }


    }
}
