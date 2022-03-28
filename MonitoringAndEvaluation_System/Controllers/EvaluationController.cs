using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class EvaluationController : BaseController
    {
        // GET: Evaluation
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        public ActionResult EvaluationCreate()
        {
            CreateProjectKPIsStatusVM kpisVM = new CreateProjectKPIsStatusVM();
            ComboProject(kpisVM);
            return View(kpisVM);
            
        }

        //Custom Function
        public void ComboProject(CreateProjectKPIsStatusVM kpisVM)
        {
            //kpisVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            //ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            //kpisVM.comboBatch.Add(mb);
            //Combo Project
            kpisVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);

            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            kpisVM.comboBatch.Add(mb);
            //Combo Indicator
            ComboPlannedKPIs mi = new ComboPlannedKPIs() { PlannedKPIsID = 0, IndicatorDescription = "Please Select Indicator" };
            kpisVM.comboPlannedKPIs.Add(mi);
            kpisVM.comboPlannedKPIs = ObjProjectMngBL.getComboPlannedKPIsBL();
        }
    }
}