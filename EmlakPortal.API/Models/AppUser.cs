using Microsoft.AspNetCore.Identity;
namespace EmlakPortal.Api.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
