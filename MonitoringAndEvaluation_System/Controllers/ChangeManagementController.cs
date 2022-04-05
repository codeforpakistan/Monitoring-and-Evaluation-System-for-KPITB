using MonitoringAndEvaluation_System.CommonUse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class ChangeManagementController : BaseController
    {
        CommonCombo allCombo = new CommonCombo();

        // GET: ChangeManagement
        [HttpGet]
        public ActionResult ChangeMngCreate()
        {
            CreateProjectVM modelVM = new CreateProjectVM();
            #region DropDown
            new CommonController().allDropDown(ref allCombo, LoginRoleID, LoginUserID);
            modelVM.comboProject = allCombo.comboProject;
            modelVM.comboSubProjects = allCombo.comboSubProjects;
            #endregion
            return View(modelVM);
        }
    }
}