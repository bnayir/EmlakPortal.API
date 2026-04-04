using EmlakPortal.API.Data;
using EmlakPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmlakPortal.API.Repositories
{
    public class PropertyRepository : GenericRepository<Property>
    {
        private readonly AppDbContext _context; 

        public PropertyRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        } 

        public async Task<List<Property>> GetAllWithDetailsAsync()
        {
            return await _context.Properties
                .Include(p => p.Category) 
                .Include(p => p.AppUser)  
                .ToListAsync();
        }

        public async Task<List<Property>> GetPropertiesWithDetailsAsync()
        {
            return await _context.Set<Property>()
                                 .Include(x => x.Category)
                                 .Include(x => x.City)
                                 .ToListAsync();
        }
    }
}