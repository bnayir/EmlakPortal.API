using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> PostProperty(Property property)
        {
            await _repository.AddAsync(property);
            return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok("İlan başarıyla silindi.");
        }
    }
}
