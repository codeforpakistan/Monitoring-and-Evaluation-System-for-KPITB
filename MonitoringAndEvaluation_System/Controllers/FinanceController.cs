﻿using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class FinanceController : BaseController
    {
        // GET: Finance
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        [HttpGet]
        public ActionResult ReleasedBudgetCreateView()
        {
            CreateViewReleasedBudgetVM releasedVM = new CreateViewReleasedBudgetVM();
            ComboProject(releasedVM);
            getAllReleasedBudget();
            return View(releasedVM);

        }
        [HttpPost]
        public ActionResult ReleasedBudgetCreateView(CreateViewReleasedBudgetVM releasedVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(releasedVM);
                }

                releasedVM.CreatedByUser_ID =LoginUserID; ;
                StatusModel status = new FinanceManagementBL().releasedCreateViewBL(releasedVM);
                if (status.status)
                {
                    TempData["Message"] = "Record Saved Successfully.";
                }
                else
                {
                    TempData["Message"] = status.statusDetail;
                }
            }
            catch (Exception ex1)
            {
                TempData["Message"] = "Exeption: " + ex1.Message;
            }
            //getProject();
            return RedirectToAction("ReleasedBudgetCreateView");
        }

        //ReleasedBudgetEdit
        [HttpGet]
        public ActionResult ReleasedBudgetEdit(int ReleasedBudgetID)
        {
            EditReleasedBudgetVM getReleasedBudget = new EditReleasedBudgetVM();

            try
            {

                getReleasedBudget = new FinanceManagementBL().getSignleReleasedBudgetBL(ReleasedBudgetID);
                // getAllIssue();
                ComboReleasedBudgetEdit(getReleasedBudget);
               

            }
            catch (Exception)
            {
            }

            return View(getReleasedBudget);
        }

        [HttpGet]
        public ActionResult ExpenditureBudgetCreateView()
        {
            CreateViewExpenditureBudgetVM expenditureVM = new CreateViewExpenditureBudgetVM();
            ComboProject2(expenditureVM);
            getAllExpenditureBudget();
            return View(expenditureVM);
           
        }
        [HttpPost]
        public ActionResult ExpenditureBudgetCreateView(CreateViewExpenditureBudgetVM expenditureVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(expenditureVM);
                }

                expenditureVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new FinanceManagementBL().expenditureCreateViewBL(expenditureVM);
                if (status.status)
                {
                    TempData["Message"] = "Record Saved Successfully.";
                }
                else
                {
                    TempData["Message"] = status.statusDetail;
                }
            }
            catch (Exception ex1)
            {
                TempData["Message"] = "Exeption: " + ex1.Message;
            }
            //getProject();
            return RedirectToAction("ExpenditureBudgetCreateView");
        }



        //Custom Function
        private void getAllReleasedBudget()
        {
            ViewBag.LstAllReleasedBudget = new FinanceManagementBL().getAllReleasedBudgetBL(LoginRoleID,LoginUserID);
        }
        private void getAllExpenditureBudget()
        {
            ViewBag.LstAllExpenditureBudget = new FinanceManagementBL().getAllExpenditureBudgetBL(LoginRoleID, LoginUserID);
        }
        public void ComboProject(CreateViewReleasedBudgetVM releasedVM)
        {
            //Get ProjectType list
            releasedVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            releasedVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            releasedVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
        public void ComboProject2(CreateViewExpenditureBudgetVM expenditureVM)
        {
            //Get ProjectType list
            expenditureVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            expenditureVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            expenditureVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
        public void ComboReleasedBudgetEdit(EditReleasedBudgetVM getReleasedBudgetVM)
        {
            //Get ProjectType list
            getReleasedBudgetVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            getReleasedBudgetVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            getReleasedBudgetVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
    }
}