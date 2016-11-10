using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailySheet.Web.Controllers
{
    [RoutePrefix("DailySheets")]
    public class DailySheetsController : Controller
    {
        // GET: DailySheets
        [Route]
        [Route("{id:int}")]
        [Route("{checkIn:DateTime}")]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}