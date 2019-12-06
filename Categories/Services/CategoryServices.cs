using Categories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Categories.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly CategoryContext _context;

        public CategoryServices(CategoryContext context)
        {
            _context = context;
        }

        public async Task<CategoryItems> AddCategories(CategoryItems category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<CategoryItems>> GetCategories()
        {
            return await _context.CategoryItems.AsNoTracking().OrderBy(e => e.CategoryId).ToListAsync();
        }
    }
}