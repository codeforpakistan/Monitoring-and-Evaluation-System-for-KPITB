using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class ChangeManagementController : BaseController
    {
        // GET: ChangeManagement
        [HttpGet]
        public ActionResult ChangeMngCreate()
        {
            return View(new CreateProjectVM());
        }
    }
}