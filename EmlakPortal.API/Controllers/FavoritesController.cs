using EmlakPortal.API.Data;
using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly GenericRepository<Favorite> _repository;
        private readonly AppDbContext _context; 

        public FavoritesController(GenericRepository<Favorite> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(FavoriteDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var favorite = new Favorite { AppUserId = userId, PropertyId = dto.PropertyId };
            await _repository.AddAsync(favorite);
            return Ok("İlan Favorilerinize Eklendi.");
        }

        [HttpGet("MyFavorites")]
        public async Task<IActionResult> GetMyFavorites()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var myFavorites = await (from f in _context.Favorites
                                     join p in _context.Properties on f.PropertyId equals p.PropertyId
                                     where f.AppUserId == userId
                                     select new
                                     {
                                         FavoriteId = f.FavoriteId,
                                         PropertyId = f.PropertyId,
                                         Title = p.Title,
                                         Price = p.Price,
                                         ImageUrl = p.ImageUrl
                                     }).ToListAsync();

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