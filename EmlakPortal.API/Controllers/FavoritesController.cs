using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly GenericRepository<Favorite> _repository;

        public FavoritesController(GenericRepository<Favorite> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(FavoriteDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var favorite = new Favorite { AppUserId= userId, PropertyId = dto.PropertyId };
            await _repository.AddAsync(favorite);
            return Ok("İlan Favorilerinize Eklendi.");

        }

        [HttpGet("MyFavorites")]
        public async Task<IActionResult> GetMyFavorites()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var allFavorites = await _repository.GetAllAsync();
            var myFavorites =allFavorites.Where(f=> f.AppUserId == userId)
                                         .Select(f=> new { f.FavoriteId, f.PropertyId})
                                         .ToList();
            return Ok(myFavorites);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok("İlan Favorilerinizden Çıkarıldı.");
        }



    }
}
