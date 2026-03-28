using Microsoft.AspNetCore.Identity;
namespace EmlakPortal.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
       
        public virtual ICollection<Property> Properties { get; set; }
    }
}
