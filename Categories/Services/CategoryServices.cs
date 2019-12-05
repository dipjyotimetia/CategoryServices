using Categories.Models;
using System;
using System.Collections.Generic;

namespace Categories.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly Dictionary<string, CategoryItems> _categoryItems;

        public CategoryServices()
        {
            _categoryItems = new Dictionary<string, CategoryItems>();
        }

        public CategoryItems AddCategories(CategoryItems category)
        {
            if (category == null)
            {
                throw new Exception("Enter all the categories");
            }
            _categoryItems.Add(category.CategoryName, category);
            return category;
        }

        public Dictionary<string, CategoryItems> GetCategories()
        {
            return _categoryItems;
        }
    }
}