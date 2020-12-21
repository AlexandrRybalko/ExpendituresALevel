using AutoMapper;
using BL.BLModels;
using BL.Services;
using ExpendituresALevel.Models;
using ExpendituresALevel.Models.Category;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExpendituresALevel.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        /*public ActionResult MyCategories()
        {
            /*var model = _categoryService.GetById(10);
            var cat = _mapper.Map<CategoryModel>(model);*/
            /*var model = new List<CategoryModel> { new CategoryModel { Id = 1, Title = "ssss" }, 
                new CategoryModel { Id = 2, Title = "ddddd" }, 
                new CategoryModel { Id = 100, Title = "test" } };
                //_mapper.Map<IEnumerable<CategoryModel>>(_categoryService.GetCategories());
            var model = _mapper.Map<CategoryModel>(new CategoryBLModel { Id = 100, Title = "test"});
           /var model = new CategoryModel { Id = 100, Title = "test" };

            return View("/Views/Category/Categories.cshtml");
        }*/

        public ActionResult Categories()
        {
            var blModels = _categoryService.GetCategories();
            var models = _mapper.Map<IEnumerable<CategoryModel>>(blModels);

            return View("/Views/Category/Categories.cshtml", models);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel categoryModel)
        {
            categoryModel.CreatedDate = DateTime.Now;
            categoryModel.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryBLModel>(categoryModel);
                _categoryService.Create(category);

                return Categories();
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _categoryService.DeleteById(id);

            return Categories();
        }

        public ActionResult Edit(int id)
        {
            var model = _categoryService.GetById(id);
            var categoryModel = _mapper.Map<CategoryModel>(model);

            return View(categoryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                category.UpdatedDate = DateTime.Now;
                var blCategory = _mapper.Map<CategoryBLModel>(category);
                _categoryService.Edit(blCategory);

                return Categories();
            }

            return View(category);
        }

        public ActionResult GetTransactionList()
        {
            TransactionModel transaction = new TransactionModel();
            transaction.Title = "test";
            transaction.Value = 500;

            return PartialView("~/Views/Transaction/_TransactionData.cshtml", transaction);
        }
    }
}