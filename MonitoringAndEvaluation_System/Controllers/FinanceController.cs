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
    public class FinanceController : BaseController
    {
        // GET: Finance
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        FinanceManagementBL ObjFinanceMngBL = new FinanceManagementBL();
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
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                }
                #region COMPARE_BUDGET
                int planned, Achived;
                StatusModel status3 = ObjFinanceMngBL.ComparePlanned_BudgetBL(releasedVM.Project_ID, out planned, out Achived);
                int rr = planned - Achived;
              
                var ss = releasedVM.ReleasedBudget - planned;
                if (releasedVM.ReleasedBudget > rr)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "Released Budget should not be greater than Approved Budget");
                }
                releasedVM.CreatedByUser_ID = LoginUserID; 
                #endregion
                #region INSERTION
                StatusModel status = new FinanceManagementBL().releasedCreateViewBL(releasedVM);
                if (status3.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
                } 
                #endregion
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
            }
            if (ModelState.IsValid) { 
                return RedirectToAction("ReleasedBudgetCreateView");
            }
            else
            {
                ComboProject(releasedVM);
                getAllReleasedBudget();
                return View(releasedVM);
            }
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
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return View(expenditureVM);
                }
                int Released, Expenditure;
                StatusModel status2 = ObjFinanceMngBL.ComparePlanned_BudgetBL(expenditureVM.Project_ID, out Released, out Expenditure);
                int rr = Released - Expenditure;

                var ss = expenditureVM.ExpenditureBudget - Released;
                if (expenditureVM.ExpenditureBudget > rr)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "ExpenditureBudget Budget should not be greater than Released Budget");
                    ComboProject2(expenditureVM);
                    getAllExpenditureBudget();
                    return View(expenditureVM);
                }
                expenditureVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new FinanceManagementBL().expenditureCreateViewBL(expenditureVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
                }
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
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

            releasedVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ////Get ProjectType list
            //releasedVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            //ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            //releasedVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            //ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            //releasedVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
        public void ComboProject2(CreateViewExpenditureBudgetVM expenditureVM)
        {
            expenditureVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ////Get ProjectType list
            //expenditureVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            //ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            //expenditureVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            //ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            //expenditureVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
    }
}