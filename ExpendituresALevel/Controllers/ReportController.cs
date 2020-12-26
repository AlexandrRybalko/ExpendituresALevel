using ExpendituresALevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace ExpendituresALevel.Controllers
{
    public class ReportController : ApiController
    {
        [System.Web.Http.HttpGet]
        public string Test()
        {
            return "test";
        }

        [System.Web.Http.HttpGet]
        public JsonResult AutoCompleteSuggestion()
        {
            var filteredSuggestions = new List<AutoCompleteModel>{
                new AutoCompleteModel { data = "Andorra", value = "AD" },
                new AutoCompleteModel { data = "Zimbabwe", value = "ZZ" }
            };
            var result = new JsonResult();
            result.Data = new { suggestions = filteredSuggestions };

            return result;
        }

        [System.Web.Http.HttpGet]
        public string GetTrafficData(string category)
        {
            if (true)
            {
                if (true)
                {
                    return "ok";
                }

                
            }


        }
    }
}
