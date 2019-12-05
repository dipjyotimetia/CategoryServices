using Categories.Models;
using Categories.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Categories.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        // POST api/values
        [HttpPost]
        [Route("AddCategories")]
        public ActionResult<CategoryItems> PostCategories(CategoryItems category)
        {
            var categories = _services.AddCategories(category);

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // GET api/values/5
        [HttpGet]
        [Route("GetCategories")]
        public ActionResult<Dictionary<string, CategoryItems>> GetCategoryItems()
        {
            var categories = _services.GetCategories();

            if (categories.Count == 0)
            {
                return NotFound();
            }
            return categories;
        }
    }
}