using BL.Services;
using ExpendituresALevel.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpendituresALevel.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        public ActionResult MyCategories()
        {
            //List<CategoryBl> models = _categoryService.GetMyCategories();
            CategoryModel model = new CategoryModel 
            { 
                Id = 1, 
                Title = "test" 
            };

            return View("/Views/Category/MyCategories.cshtml", model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}