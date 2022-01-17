using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class IndicatorController : Controller
    {
        // GET: Indicator
        public ActionResult IndicatorCreateView()
        {
            return View();
        }
        public ActionResult IndicatorFieldCreate()
        {
            return View();
        }
        public ActionResult IndicatorLink()
        {
            return View();
        }
        public ActionResult IndicatorFieldValue()
        {
            return View();
        }
    }
}