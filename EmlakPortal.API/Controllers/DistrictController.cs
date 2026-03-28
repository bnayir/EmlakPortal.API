using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {


      
            private readonly GenericRepository<District> _repository;

            public DistrictController(GenericRepository<District> repository)
            {
                _repository = repository;
            }

            // Seçilen şehre göre ilçeleri getir (En kritik metot!)
            [HttpGet("by-city/{cityId}")]
            public async Task<IActionResult> GetByCity(int cityId)
            {
                var all = await _repository.GetAllAsync();
                return Ok(all.Where(d => d.CityId == cityId));
            }

            [Authorize(Roles = "Admin")]
            [HttpPost]
            public async Task<IActionResult> PostDistrict(District district)
            {
                await _repository.AddAsync(district);
                return Ok("İlçe eklendi.");
            }
        
    }
}
