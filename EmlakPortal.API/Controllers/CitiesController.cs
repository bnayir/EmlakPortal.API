using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EmlakPortal.API.DTOs.CreateDTO;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly GenericRepository<City> _repository;

        public CitiesController(GenericRepository<City> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _repository.GetAllAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var city = await _repository.GetById(id);
            if (city == null) return NotFound("Şehir bulunamadı.");
            return Ok(city);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostCity(CityCreateDto dto)
        {
            var city = new City
            {
                CityName = dto.CityName
            };

            await _repository.AddAsync(city);
            return Ok("Şehir başarıyla eklendi.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, City city)
        {
            if (id != city.CityId) return BadRequest("ID uyuşmuyor.");

            await _repository.UpdateAsync(city);
            return Ok("Şehir bilgisi güncellendi.");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _repository.GetById(id);
            if (city == null) return NotFound("Silinecek şehir bulunamadı.");

            await _repository.DeleteAsync(id);
            return Ok("Şehir ve ilgili tanımlamalar silindi.");
        }
    }
}