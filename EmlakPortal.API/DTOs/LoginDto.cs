using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.API.DTOs
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDto : ControllerBase
    {

            public string UserName { get; set; }
            public string Password { get; set; }
        
    }

    
}
