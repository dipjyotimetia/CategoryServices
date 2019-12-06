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

        public CategoryController(ICategoryServices services, ILogger<CategoryController> logger)
        {
            _services = services;
            _logger = logger;
        }

        // POST api/values
        [HttpPost]
        [Route("AddCategories")]
        public async Task<IActionResult> AddCategories([FromBody]CategoryItems category)
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

        // POST api/values
        [HttpPut]
        [Route("UpdateCategories")]
        public async Task<IActionResult> UpdateCategories([FromBody]CategoryItems category)
        {
            _logger.LogInformation($"CategoryController ->");

            var categories = await _services.UpdateCategories(category);

            if (categories == null)
            {
                _logger.LogInformation("Category Not Updated");
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

        [HttpDelete]
        [Route("DeleteCategories")]
        public async Task<IActionResult> DeleteCategoryItems([FromBody]CategoryItems category)
        {
            var categories = await _services.DeleteCategories(category);
            return Ok(categories);
        }
    }
}