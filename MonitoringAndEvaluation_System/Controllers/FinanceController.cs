
using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;
using static ModelLayer.ComboModel;
using static ModelLayer.MainModel;
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
        public ActionResult ReleasedBudgetCreateView(CreateViewReleasedBudgetVM releasedVM, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    goto gotoWithModel;
                }

                int hdnRemaningHR = Convert.ToInt32(form["hdnRemaningBudget"]);
                if (releasedVM.ReleasedBudget > hdnRemaningHR)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "Released Budget should not be greater than Approved Budget: " + hdnRemaningHR);
                    goto gotoWithModel;
                }
                releasedVM.CreatedByUser_ID = LoginUserID; 
                StatusModel status = new FinanceManagementBL().releasedCreateViewBL(releasedVM);
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
            return RedirectToAction("ReleasedBudgetCreateView");

            gotoWithModel:
            ComboProject(releasedVM);
            getAllReleasedBudget();
            return View(releasedVM);
        }
        [HttpGet]
        public ActionResult ExpenditureBudgetCreateView()
        {
            CreateViewExpenditureBudgetVM expenditureVM = new CreateViewExpenditureBudgetVM();
            expenditureVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            expenditureVM.comboBatch.Add(mb);
            getAllExpenditureBudget();
            return View(expenditureVM);
           
        }
        [HttpPost]
        public ActionResult ExpenditureBudgetCreateView(CreateViewExpenditureBudgetVM expenditureVM, HttpPostedFileBase fileInput)
        {
            try
            {
                #region ExpenditureBudget
                expenditureVM.Project_ID = Convert.ToInt32(Request.Form["txtProject_ID"]);
                //expenditureVM.SubProject_ID = Convert.ToInt32(Request.Form["txtSubProject_ID"]);
                expenditureVM.Batch_ID = Convert.ToInt32(Request.Form["txtBatch_ID"]);
                #region Expenditure
                //From Risk GridView
                List<Expenditure_Budget> _lstExpenditure_Budget = new List<Expenditure_Budget>();
                string[] _ExpenditureRows = Request.Form["_ExpenditureRows"].Split(',');
                for (int i = 0; i < _ExpenditureRows.Length; i++)
                {
                    if (_ExpenditureRows[0].Trim() != "")
                    {
                        Expenditure_Budget mm = new Expenditure_Budget();
                        string[] ItemArray = _ExpenditureRows[i].Split('|');
                        mm.BudgetHead = Convert.ToString(ItemArray[1]);
                        mm.ApprovedCost = Convert.ToInt32(ItemArray[2]);
                        mm.ExpenditureBudget = Convert.ToInt32(ItemArray[3]);
                        // mm.ExpenditureDate = Convert.ToString(ItemArray[4]);
                        mm.CreatedByUser_ID = LoginUserID;
                        mm.Project_ID= Convert.ToInt32(Request.Form["txtProject_ID"]);
                        mm.Batch_ID= Convert.ToInt32(Request.Form["txtBatch_ID"]);
                        mm.ExpenditureDate = DateTime.Now;


                        _lstExpenditure_Budget.Add(mm);
                    }
                }
                expenditureVM.AssignExpenditureList=_lstExpenditure_Budget;

                #endregion


                StatusModel status = ObjFinanceMngBL.expenditureCreateViewBL(expenditureVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
                    return Json("false");
                }
                expenditureVM.AssignExpenditureList = _lstExpenditure_Budget;
                #endregion

            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
                return Json("false");
            }
            return Json("true");
            //return View("ProjectView");
            //return View("~/Views/Project/ProjectView.cshtml", new ProjectManagementBL().getAllProjectBL());

        }

        #region CustomFunction
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
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            releasedVM.comboBatch.Add(mb); 
        }
        #endregion
       
        
        
    }
}