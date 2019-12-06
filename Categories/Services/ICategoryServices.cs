using Categories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Categories.Services
{
    public interface ICategoryServices
    {
        Task<CategoryItems> AddCategories(CategoryItems category);

        Task<List<CategoryItems>> GetCategories();
    }
}