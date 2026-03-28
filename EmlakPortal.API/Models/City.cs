namespace EmlakPortal.API.Models
{
    
        public class City
        {
            public int CityId { get; set; }
            public string CityName { get; set; }

            public virtual ICollection<Property> Properties { get; set; }

        public virtual ICollection<District> Districts { get; set; }

    }
    
}

