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
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpGet]
        public JsonResult AutoCompleteSuggestion(/*string query*/)
        {
            //service.GetAll().Where(x => x.Name.contains(query))

            var filteredSuggestions = new List<AutoCompleteModel>{
                new AutoCompleteModel { data = "Andorra", value = "AD" },
                new AutoCompleteModel { data = "Zimbabwe", value = "ZZ" }
            };
            var result = new JsonResult();
            result.Data = new { suggestions = filteredSuggestions };

            return result;
        }
    }
}