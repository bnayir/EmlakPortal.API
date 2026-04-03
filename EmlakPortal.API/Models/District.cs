using EmlakPortal.API.Models;

public class District
{
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }

    public int CityId { get; set; }
    public virtual City City { get; set; }

    public virtual ICollection<Property> Properties { get; set; }
}