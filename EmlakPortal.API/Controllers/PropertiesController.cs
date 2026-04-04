using EmlakPortal.API.DTOs; // DTO klasörün
using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EmlakPortal.API.Models.Property;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyRepository _repository;

        public PropertiesController(PropertyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await _repository.GetAllAsync();
            var result = properties.Select(p => new {
                p.PropertyId,
                p.Title,
                p.Price,
                p.Description
            }).ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await _repository.GetById(id);
            if (property == null) return NotFound("İlan bulunamadı.");
            return Ok(property);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostProperty(PropertyDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var property = new Property
            {
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                AppUserId = userId,

            };
            await _repository.AddAsync(property);
            return Ok("İlan başarıyla eklendi.");
        }

        

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, Property property)
        {
            if (id != property.PropertyId) return BadRequest("ID uyuşmuyor.");
            await _repository.UpdateAsync(property);
            return Ok("İlan başarıyla güncellendi.");
        }

        [Authorize]
        [HttpGet("MyProperties")]
        public async Task<IActionResult> GetMyProperties()
        {
            var properties = await _repository.GetAllWithDetailsAsync();

            var approvedList = properties.Where(p => p.Status == PropertyStatus.Approved).Select(p => new
            {
                p.PropertyId,
                p.Title,
                StatusName = p.Status.ToString()
            });

            return Ok(approvedList);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchProperties([FromQuery] FilterDto filter)
        {
            var properties = await _repository.GetAllAsync();
            var query = properties.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                query = query.Where(p => p.Title.Contains(filter.Keyword)||
                                          p.Description.Contains(filter.Keyword));
            }

            if (filter.CityId.HasValue)
                query = query.Where(p => p.CityId == filter.CityId.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price == filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price == filter.MaxPrice.Value);

            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                query = filter.SortBy.ToLower() switch
                {
                    "price_asc" => query.OrderBy(p => p.Price),
                    "price_desc" => query.OrderByDescending(p => p.Price),
                    "newest" => query.OrderByDescending(p => p.PropertyId),
                    _ => query
                };
            }

            var result = query.Select(p => new
            {
                p.PropertyId,
                p.Title,
                p.Price,
                p.CityId,
                p.CategoryId,
            }).ToList();

            if (!result.Any()) return NotFound("İlan Bulunamadı.");
            return Ok(result);
        }

        [Authorize] 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _repository.GetByIdAsync(id);
            if (property == null)
            {
                return NotFound("Böyle bir ilan bulunamadı.");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (property.AppUserId != userId)
            {
                return Unauthorized("Sadece kendi ilanlarınızı silebilirsiniz!");
            }

            await _repository.DeleteAsync(id);

            return Ok("İlan başarıyla silindi.");
        }
    }
}