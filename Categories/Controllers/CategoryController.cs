using Categories.Models;
using Categories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Categories.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoryController : Controller
    {
        ILoggerFactory _loggerFactory;
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services,ILoggerFactory loggerFactory)
        {
            _services = services;
            _loggerFactory = loggerFactory;
        }

        // POST api/values
        [HttpPost]
        [Route("AddCategories")]
        public ActionResult<CategoryItems> PostCategories(CategoryItems category)
        {
            var logger = _loggerFactory.CreateLogger("PostCategory");

            var categories = _services.AddCategories(category);

            if (categories == null)
            {
                logger.LogInformation("Category Not Found");
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