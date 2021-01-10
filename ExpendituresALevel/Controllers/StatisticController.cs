using AutoMapper;
using BL.Services;
using ExpendituresALevel.Filters;
using ExpendituresALevel.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpendituresALevel.Controllers
{
    [Authorize(Roles = "user")]
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

            return Json(new { suggestions = filteredSuggestions }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNumberOfTransactionsByDay(int categoryId)
        {
            var transactions = _categoryService.GetById(categoryId).Transactions.Where(x => x.UserId == User.Identity.GetUserId());
            int[] statistics = new int[] {
                transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Monday).Count(),
                transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Tuesday).Count(),
                transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Wednesday).Count(),
                transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Thursday).Count(),
                transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Friday).Count(),
                transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Saturday).Count(),
                transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Sunday).Count()};

            var result = Json(new { result = statistics }, JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}
