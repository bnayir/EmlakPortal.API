using EmlakPortal.API.Models;

public class District
{
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }

    // Hangi şehre bağlı?
    public int CityId { get; set; }
    public virtual City City { get; set; }

    // Bu ilçedeki ilanlar
    public virtual ICollection<Property> Properties { get; set; }
}