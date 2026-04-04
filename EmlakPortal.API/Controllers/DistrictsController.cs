using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models; 
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly GenericRepository<District> _repository;

        public DistrictsController(GenericRepository<District> repository)
        {
            _repository = repository;
        }

        [HttpGet("by-city/{cityId}")]
        public async Task<IActionResult> GetByCity(int cityId)
        {
            var all = await _repository.GetAllAsync();

            var result = all.Where(d => d.CityId == cityId)
                            .Select(d => new DistrictDto
                            {
                                DistrictId = d.DistrictId,
                                DistrictName = d.DistrictName,
                                CityId = d.CityId
                            }).ToList();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostDistrict(DistrictDto dto)
        {
var district=new District { DistrictName = dto.DistrictName, CityId=dto.CityId };
            await _repository.AddAsync(district);
            return Ok("İlçe başarıyla eklendi.");
        }
    }
}