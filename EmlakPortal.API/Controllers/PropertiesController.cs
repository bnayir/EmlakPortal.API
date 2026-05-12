using AutoMapper;
using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EmlakPortal.API.Models.Property;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyRepository _repository;
        private readonly IMapper _mapper;

        public PropertiesController(PropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await _repository.GetPropertiesWithDetailsAsync();
            var dtoList = _mapper.Map<List<PropertyDto>>(properties);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var properties = await _repository.GetPropertiesWithDetailsAsync();
            var property = properties.FirstOrDefault(p => p.PropertyId == id);

            if (property == null) return NotFound("İlan bulunamadı.");

            var dto = _mapper.Map<PropertyDto>(property);
            return Ok(dto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostProperty(PropertyCreateDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var property = _mapper.Map<Property>(dto);
            property.AppUserId = userId;
            property.Status = PropertyStatus.Approved;
            property.IsActive = true;
            property.CreatedDate = DateTime.Now;

            await _repository.AddAsync(property);
            return Ok(new { message = "İlan başarıyla eklendi.", propertyId = property.PropertyId });
        }

        [Authorize]
        [HttpGet("MyProperties")]
        public async Task<IActionResult> GetMyProperties()
        {
            var properties = await _repository.GetAllWithDetailsAsync();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var myProperties = properties
                .Where(p => p.AppUserId == userId && p.Status == PropertyStatus.Approved)
                .Select(p => new
                {
                    p.PropertyId,
                    p.Title,
                    p.Price,       
                    p.ImageUrl,    
                    p.CreatedDate, 
                    StatusName = p.Status.ToString(),
                    p.PropertyType,
                    CityName = p.City != null ? p.City.CityName : "Bilinmiyor",
                    CategoryName = p.Category != null ? p.Category.CategoryName : "Kategorisiz"
                });

            return Ok(myProperties);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchProperties([FromQuery] FilterDto filter)
        {
            var properties = await _repository.GetAllAsync();
            var query = properties.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                query = query.Where(p => p.Title.Contains(filter.Keyword) ||
                                          p.Description.Contains(filter.Keyword));
            }

            if (filter.CityId.HasValue)
                query = query.Where(p => p.CityId == filter.CityId.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

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

            var result = _mapper.Map<List<PropertyDto>>(query.ToList());

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

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (property.AppUserId != userId)
            {
                return Unauthorized("Sadece kendi ilanlarınızı silebilirsiniz!");
            }

            await _repository.DeleteAsync(id);
            return Ok("İlan başarıyla silindi.");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateProperty(PropertyUpdateDto dto)
        {
            var property = await _repository.GetByIdAsync(dto.PropertyId);
            if (property == null)
                return NotFound("İlan bulunamadı.");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (property.AppUserId != userId)
                return Unauthorized("Sadece kendi ilanlarınızı güncelleyebilirsiniz!");

            _mapper.Map(dto, property);
            await _repository.UpdateAsync(property);

            return Ok("İlan başarıyla güncellendi.");
        }

        [Authorize]
        [HttpPost("UploadImage/{id}")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Lütfen bir resim seçiniz.");

            var property = await _repository.GetByIdAsync(id);
            if (property == null) return NotFound("İlan bulunamadı.");

            var extension = Path.GetExtension(file.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);

            using (var stream = new FileStream(location, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            property.ImageUrl = "/images/" + newImageName;
            await _repository.UpdateAsync(property);

            return Ok(new { Message = "Resim başarıyla yüklendi", ImageUrl = property.ImageUrl });
        }
    }
}