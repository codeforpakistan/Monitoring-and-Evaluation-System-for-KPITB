
using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;
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
            getAllProjectKPIsStatus();
            return View(kpisVM);
        }
        [HttpPost]
        public ActionResult ProjectKPIsStatusCreateView(CreateProjectKPIsStatusVM projectKPIsStatusVM, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    goto gotoWithModel;
                }

                //int hdnRemaningHR = Convert.ToInt32(form["hdnRemaningBudget"]);
                //if (projectKPIsStatusVM.ReleasedBudget > hdnRemaningHR)
                //{
                //    ShowMessage(MessageBox.Warning, OperationType.Warning, "Released Budget should not be greater than Approved Budget: " + hdnRemaningHR);
                //    goto gotoWithModel;
                //}
                projectKPIsStatusVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new ProjectKPIsStatusManagementBL().projectKPIsStatusCreateViewBL(projectKPIsStatusVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
                    goto gotoWithModel;
                }

            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
                goto gotoWithModel;
            }
            return RedirectToAction("ProjectKPIsStatusCreateView");

            gotoWithModel:
            ComboProject(projectKPIsStatusVM);
          
            return View(projectKPIsStatusVM);
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

        //Get all KPIs Status
        private void getAllProjectKPIsStatus()
        {
            ViewBag.LstAllProjectKPIsStatus = new ProjectKPIsStatusManagementBL().getAllProjectKPIsStatusBL();
        }
    }
}