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
        public ActionResult ExpenditureBudgetCreateView(CreateViewExpenditureBudgetVM model)
        {
            try
            {
                List<CreateViewExpenditureBudgetVM> expenditureLst = new List<CreateViewExpenditureBudgetVM>();
                string[] _ExpenditureLst = Request.Form["_ExpenditureLst"].Split(',');
                for (int i = 0; i < _ExpenditureLst.Length; i++)
                {
                    if (_ExpenditureLst[0].Trim() != "")
                    {
                        string[] ItemArray = _ExpenditureLst[i].Split('|');
                        expenditureLst.Add(new CreateViewExpenditureBudgetVM()
                        {
                            Project_ID = Convert.ToInt32(ItemArray[1]),
                            SubProject_ID = Convert.ToInt32(ItemArray[2]),
                            Batch_ID = Convert.ToInt32(ItemArray[3]),
                            ExpenditureDate = Convert.ToDateTime(ItemArray[4]),
                            BudgetHead = Convert.ToString(ItemArray[5]),
                            ApprovedCost = Convert.ToInt32(ItemArray[6]),
                            ExpenditureBudget = Convert.ToInt32(ItemArray[7])
                        });
                    }
                }
                StatusModel status = new FinanceManagementBL().expenditureCreateViewBL(expenditureLst);
                if (status.status)
                {
                    //TempData["Message"] = status.statusDetail;
                    //TempData.Keep("Message");
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
                    return Json("false");
                }

            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
                return Json("false");
            }
            return Json("true");



            //    #region SingleValues

            //    //expenditureVM.ExpenditureDate = Convert.ToDateTime(Request.Form["txtCategory_ID"]);
            //    expenditureVM.CreatedByUser_ID = LoginUserID;//Convert.ToInt32(Session["LoginUserID"]);
            //    #endregion

            //    #region Expenditure
            //    //From Expenditure GridView
            //    List<Expenditure_Budget> _lstExpenditure = new List<Expenditure_Budget>();
            //    string[] _ExpenditureRows = Request.Form["_ExpenditureRows"].Split(',');
            //    for (int i = 0; i < _ExpenditureRows.Length; i++)
            //    {
            //        if (_ExpenditureRows[0].Trim() != "")
            //        {
            //            Expenditure_Budget m = new Expenditure_Budget();
            //            string[] ItemArray = _ExpenditureRows[i].Split('|');
            //            m.BudgetHead = Convert.ToString(ItemArray[1]);
            //            m.ApprovedCost = Convert.ToInt32(ItemArray[2]);
            //            m.ExpenditureBudget = Convert.ToInt32(ItemArray[3]);
            //            m.CreatedByUser_ID = LoginUserID;
            //            _lstExpenditure.Add(m);
            //        }
            //    }
            //    expenditureVM.AssignExpenditureList = _lstExpenditure;
            //    #endregion




            //    // ModelState.Remove("RiskStatus_ID");
            //    //if (ModelState.IsValid == false)
            //    //{
            //    //    Combo(ProjectVM);
            //    //   return View(ProjectVM);
            //    List<CreateIndicatorFieldVM> fieldIndicatorLst = new List<CreateIndicatorFieldVM>();
            //    //}

            //    StatusModel status = new FinanceManagementBL().expenditureCreateViewBL(lstExpenditure);
            //    if (status.status)
            //    {
            //        ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
            //    }
            //    else
            //    {
            //        ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
            //        return Json("false");
            //    }

            //}
            //catch (Exception ex1)
            //{
            //    ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
            //    return Json("false");
            //}
            //return Json("true");
            ////return View("ProjectView");
            ////return View("~/Views/Project/ProjectView.cshtml", new ProjectManagementBL().getAllProjectBL());

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
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            releasedVM.comboBatch.Add(mb); 
        }
        
    }
}