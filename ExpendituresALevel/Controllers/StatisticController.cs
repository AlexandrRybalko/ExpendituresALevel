using AutoMapper;
using BL.Services;
using ExpendituresALevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpendituresALevel.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public StatisticController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpGet]
        public JsonResult AutoCompleteSuggestion(string query)
        {
            var categories = _categoryService.GetCategories().Where(x => x.Title.Contains(query)).ToList();
            var filteredSuggestions = _mapper.Map<IEnumerable<AutoCompleteModel>>(categories);
            var result = new JsonResult();
            result.Data = new { suggestions = filteredSuggestions };

            return Json(new { suggestions = filteredSuggestions }, JsonRequestBehavior.AllowGet) ;
        }
    }
}