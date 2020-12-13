using AutoMapper;
using BL.BLModels;
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
        private readonly IMapper _mapper;

        public CategoryController()
        {
            _categoryService = new CategoryService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryBLModel, CategoryModel>();
                cfg.CreateMap<CategoryBLModel, CategoryModel>().ReverseMap();
            });
        }
        public ActionResult MyCategories()
        {
            //List<CategoryBl> models = _categoryService.GetMyCategories();
            var models = _mapper.Map<IEnumerable<CategoryModel>>(_categoryService.GetCategories());
            var model = _mapper.Map<CategoryModel>(_categoryService.GetById(5));

            return View("/Views/Category/MyCategories.cshtml", model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}