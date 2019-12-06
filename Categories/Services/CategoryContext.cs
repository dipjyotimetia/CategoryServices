using Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace Categories.Services
{
    public class CategoryContext :DbContext
    {
        public CategoryContext(DbContextOptions options) : base(options) { }

        public DbSet<CategoryItems> CategoryItems { get; set; }
    }
}
