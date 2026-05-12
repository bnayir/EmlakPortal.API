using EmlakPortal.API.Data; // AppDbContext'in olduğu yer
using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ToListAsync() için ŞART
using System.Linq;
using System.Threading.Tasks;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly GenericRepository<District> _repository;

        public DistrictsController(AppDbContext context, GenericRepository<District> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("GetByCity/{cityId}")]
        public async Task<IActionResult> GetByCity(int cityId)
        {
            var districts = await _context.District
    .Where(d => d.CityId == cityId)
    .Select(d => new DistrictDto
    {
        DistrictId = d.DistrictId,
        DistrictName = d.DistrictName,
        CityId = d.CityId
    })
    .ToListAsync();
            return Ok(districts);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostDistrict(DistrictDto dto)
        {
            var district = new District { DistrictName = dto.DistrictName, CityId = dto.CityId };
            await _repository.AddAsync(district);
            return Ok("İlçe başarıyla eklendi.");
        }
    }
}