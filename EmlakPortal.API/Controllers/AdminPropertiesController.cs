using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static EmlakPortal.API.Models.Property;

namespace EmlakPortal.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminPropertiesController : ControllerBase
    {
        
    
         
        
            private readonly PropertyRepository _repository;

            public AdminPropertiesController(PropertyRepository repository)
            {
                _repository = repository;
            }

            // 1. Tüm ilanları (sahibi fark etmeksizin) detaylı listele
            [HttpGet("all-list")]
            public async Task<IActionResult> GetAllPropertiesForAdmin()
            {
                var properties = await _repository.GetAllWithDetailsAsync();
                return Ok(properties);
            }

            // 2. Sistemsel bir ilanı zorla sil (Admin yetkisiyle)
            [HttpDelete("force-delete/{id}")]
            public async Task<IActionResult> ForceDelete(int id)
            {
                await _repository.DeleteAsync(id);
                return Ok("İlan yönetici tarafından sistemden kaldırıldı.");
            }

            // 3. İstatistik Getir (Vize için çok havalı bir metot)
            [HttpGet("stats")]
            public async Task<IActionResult> GetStats()
            {
                var properties = await _repository.GetAllAsync();
                return Ok(new
                {
                    TotalProperties = properties.Count,
                    TotalPrice = properties.Sum(p => p.Price),
                    LastUpdate = DateTime.Now
                });
            }
        // 1. Onay bekleyen tüm ilanları getir
        [HttpGet("pending-list")]
        public async Task<IActionResult> GetPendingProperties()
        {
            var properties = await _repository.GetAllAsync();
            return Ok(properties.Where(p => p.Status == PropertyStatus.Pending));
        }

        // 2. İlanı Onayla
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var property = await _repository.GetById(id);
            if (property == null) return NotFound();

            property.Status = PropertyStatus.Approved;
            await _repository.UpdateAsync(property);
            return Ok($"{id} numaralı ilan onaylandı ve yayına alındı.");
        }

        // 3. İlanı Reddet
        [HttpPost("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var property = await _repository.GetById(id);
            if (property == null) return NotFound();

            property.Status = PropertyStatus.Rejected;
            await _repository.UpdateAsync(property);
            return Ok($"{id} numaralı ilan reddedildi.");
        }
    }
    }


