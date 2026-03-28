using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            return Ok(properties);
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
        public async Task<IActionResult> PostProperty(Property property)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            property.AppUserId = userId; 

            await _repository.AddAsync(property);
            return Ok("İlan başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok("İlan başarıyla silindi.");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, Property property)
        {
            if (id != property.PropertyId)
            {
                return BadRequest("Girilen ID ile ilan ID'si uyuşmuyor.");
            }

            await _repository.UpdateAsync(property);
            return Ok("İlan başarıyla güncellendi.");
        }

        [Authorize]
        [HttpGet("MyProperties")]
        [HttpGet]
        public async Task<IActionResult> GetMyProperties()
        {

            var properties = await _repository.GetAllWithDetailsAsync();

            var approvedList = properties.Where(p => p.Status == PropertyStatus.Approved).Select(p => new {
                p.PropertyId,
                p.Title,
                StatusName = p.Status.ToString()
            });

            return Ok(approvedList);
        }
    }
}
