using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        [HttpGet]
        public ActionResult ExpenditureBudgetCreateView()
        {
            CreateViewExpenditureBudgetVM expenditureVM = new CreateViewExpenditureBudgetVM();
            ComboProject2(expenditureVM);
            //getAllRecruitedHR();
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
            ViewBag.LstAllReleasedBudget = new FinanceManagementBL().getAllReleasedBudgetBL();
        }
        public void ComboProject(CreateViewReleasedBudgetVM releasedVM)
        {
            //Get ProjectType list
            releasedVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID,LoginUserID);
        }
        public void ComboProject2(CreateViewExpenditureBudgetVM expenditureVM)
        {
            //Get ProjectType list
            expenditureVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        }
    }
}