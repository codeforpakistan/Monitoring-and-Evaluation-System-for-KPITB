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
    public class ProjectKPIsStatusController : BaseController
    {
        // GET: ProjectKPIsStatus
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        [HttpGet]
        public ActionResult ProjectKPIsStatusCreateView()
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
            kpisVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            kpisVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
            kpisVM.comboPlannedKPIs = ObjProjectMngBL.getComboDataTypeBL();
        }
    }
}