using Categories.Models;
using System.Collections.Generic;

namespace Categories.Services
{
    public interface ICategoryServices
    {
        CategoryItems AddCategories(CategoryItems category);

        Dictionary<string, CategoryItems> GetCategories();
    }
}