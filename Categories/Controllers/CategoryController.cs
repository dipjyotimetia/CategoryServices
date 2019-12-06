using Categories.Models;
using Categories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Categories.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoryController : Controller
    {
        ILogger _logger;
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services,ILogger<CategoryController> logger)
        {
            _services = services;
            _logger = logger;
        }

        // POST api/values
        [HttpPost]
        [Route("AddCategories")]
        public async Task<IActionResult> PostCategories([FromBody]CategoryItems category)
        {
            _logger.LogInformation($"CategoryController ->");

            var categories = await _services.AddCategories(category);

            if (categories == null)
            {
                _logger.LogInformation("Category Not Found");
                return NotFound();
            }
            return Ok(categories);
        }

       
        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategoryItems()
        {
            var category = await _services.GetCategories();

            if (category.Count == 0)
            {
                _logger.LogInformation("Category Not Found");
                return NotFound();
            }

            return Ok(category);
        }
    }
}