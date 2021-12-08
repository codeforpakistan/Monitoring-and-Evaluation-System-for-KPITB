using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class IssuesController : Controller
    {
        // GET: Issues
        public ActionResult IssuesCreate()
        {
            return View();
        }
    }
}