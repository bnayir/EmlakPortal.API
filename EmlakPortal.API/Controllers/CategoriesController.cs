using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
            private readonly GenericRepository<Category> _repository;

            public CategoriesController(GenericRepository<Category> repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<IActionResult> GetCategories() => Ok(await _repository.GetAllAsync());

            [HttpGet("{id}")]
            public async Task<IActionResult> GetCategory(int id) => Ok(await _repository.GetById(id));

            [Authorize] 
            [HttpPost]
            public async Task<IActionResult> PostCategory(Category category)
            {
                await _repository.AddAsync(category);
                return Ok("Kategori eklendi.");
            }

            [Authorize]
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCategory(int id)
            {
                await _repository.DeleteAsync(id);
                return Ok("Kategori silindi.");
            }
        }
    }


