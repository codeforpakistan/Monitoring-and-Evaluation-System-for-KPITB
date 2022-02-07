﻿using BusinessLayer;
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
    public class ProjectController : BaseController
    {
        // GET: Project
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        FinanceManagementBL ObjFinanceMngBL = new FinanceManagementBL();
        #region Project

        [HttpGet]
        public ActionResult ProjectCreate()
        {
            CreateProjectVM projectVM = new CreateProjectVM();

            Combo(projectVM);
            return View(projectVM);
        }
        [HttpPost]
        public ActionResult ProjectCreate(CreateProjectVM ProjectVM, HttpPostedFileBase fileInput)
        {
            try
            {

                #region SingleValues

                ProjectVM.Category_ID = Convert.ToInt32(Request.Form["txtCategory_ID"]);
                ProjectVM.ProjectType_ID = Convert.ToInt32(Request.Form["txtProjectType_ID"]);
                ProjectVM.DigitalPolicy_ID = Convert.ToInt32(Request.Form["txtDigitalPolicy_ID"]);
                ProjectVM.City_ID = Convert.ToInt32(Request.Form["txtCity_ID"]);
                ProjectVM.ProjectName = Convert.ToString(Request.Form["txtProjectName"]);
                ProjectVM.MaleBeneficiary = Convert.ToInt32(Request.Form["txtMaleBeneficiary"]);
                ProjectVM.FemaleBeneficiary = Convert.ToInt32(Request.Form["txtFemaleBeneficiary"]);
                ProjectVM.TotalBeneficiary = Convert.ToInt32(Request.Form["txtTotalBeneficiary"]);
                ProjectVM.CostPerBeneficiary = Convert.ToInt32(Request.Form["txtCostPerBeneficiary"]);
                ProjectVM.Objective = Convert.ToString(Request.Form["txtObjective"]);
                ProjectVM.PlannedDate = Convert.ToDateTime(Request.Form["txtPlannedDate"]);
                ProjectVM.StartDate = Convert.ToDateTime(Request.Form["txtStartDate"]);
                ProjectVM.EndDate = Convert.ToDateTime(Request.Form["txtEndDate"]);
                ProjectVM.PlannedHR = Convert.ToInt32(Request.Form["txtPlannedHR"]);
                ProjectVM.RecruitedHR = Convert.ToInt32(Request.Form["txtRecruitedHR"]);
                ProjectVM.RecruitedHRPercent = Convert.ToDouble(Request.Form["txtRecruitedHRPercent"]);
                ProjectVM.PlannedBudget = Convert.ToInt32(Request.Form["txtPlannedBudget"]);
                ProjectVM.ApprovedBudget = Convert.ToInt32(Request.Form["txtApprovedBudget"]);
                ProjectVM.ReleasedBudget = Convert.ToInt32(Request.Form["txtReleasedBudget"]);
                ProjectVM.PlannedProcurement = Convert.ToInt32(Request.Form["txtPlannedProcurement"]);
                ProjectVM.Headers = Convert.ToString(Request.Form["txtHeaders"]);
                ProjectVM.AchievedProcurement = Convert.ToInt32(Request.Form["txtAchievedProcurement"]);
                ProjectVM.ProcurementPercent = Convert.ToDouble(Request.Form["txtProcurementPercent"]);
                ProjectVM.User_ID = LoginUserID;//Convert.ToInt32(Session["LoginUserID"]);
                #endregion
                #region FundingArray
                string aaa = Convert.ToString(Request.Form["FundingSourceArray"]);
                ProjectVM.Funding_Source = string.Join(",", aaa);
                #endregion
                #region Risk
                //From Risk GridView
                List<Risk> _lstRisk = new List<Risk>();
                string[] _RiskRows = Request.Form["_RiskRows"].Split(',');
                for (int i = 0; i < _RiskRows.Length; i++)
                {
                    if (_RiskRows[0].Trim() != "")
                    {
                        Risk m = new Risk();
                        string[] ItemArray = _RiskRows[i].Split('|');
                        m.RiskName = Convert.ToString(ItemArray[1]);
                        m.RiskStatus_ID = Convert.ToInt32(ItemArray[2]);
                        m.CreatedByUser_ID = LoginUserID;
                        _lstRisk.Add(m);
                    }
                }
                ProjectVM.AssignRiskList = _lstRisk;
                #endregion
                #region Stackholder
                //From Risk GridView
                List<Stackholder> _lstStackholder = new List<Stackholder>();
                string[] _StackholderRows = Request.Form["_StackholderRows"].Split(',');
                for (int i = 0; i < _StackholderRows.Length; i++)
                {
                    if (_StackholderRows[0].Trim() != "")
                    {
                        Stackholder mm = new Stackholder();
                        string[] ItemArray = _StackholderRows[i].Split('|');
                        mm.StackholderName = Convert.ToString(ItemArray[1]);
                        mm.StackholderDepartment = Convert.ToString(ItemArray[2]);
                        mm.StackholderContact = Convert.ToString(ItemArray[3]);
                        mm.StackholderEmail = Convert.ToString(ItemArray[4]);
                        mm.CreatedByUser_ID = LoginUserID;
                        _lstStackholder.Add(mm);
                    }
                }
                ProjectVM.AssignStackholderList = _lstStackholder;
                #endregion

                bool isExists = ObjProjectMngBL.IsProjectNameExistsBL(ProjectVM.ProjectName);  //ProjectName Check
                if (isExists)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "Project Name Already Exists !");
                    return View("~/Views/Project/ProjectCreate.cshtml", ProjectVM);
                }

                // ModelState.Remove("RiskStatus_ID");
                //if (ModelState.IsValid == false)
                //{
                //    Combo(ProjectVM);
                //   return View(ProjectVM);
                //}
                StatusModel status = ObjProjectMngBL.projectCreateBL(ProjectVM);
                if (status.status)
                {
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
            //return View("ProjectView");
            //return View("~/Views/Project/ProjectView.cshtml", new ProjectManagementBL().getAllProjectBL());
        }

        [HttpGet]
        public ActionResult ProjectView()
        {
            @ViewBag.MainTitle = "Project List";
            List<GetAllProjectVM> lst = new ProjectManagementBL().getAllProjectBL(LoginRoleID, LoginUserID);
            return View(lst);
        }

        [HttpGet]
        public ActionResult ProjectDetails(string ProjectID)
        {
            GetProjectDetailsVM data = new ProjectManagementBL().getProjectDetailsBL(Convert.ToInt32(Utility.Encryption.DecryptURL(ProjectID)));

            return View(data);
        }
        #endregion
        #region RecruitedHR
        [HttpGet]
        public ActionResult RecruitedHRCreate()
        {
            CreateRecruitedHRVM recruitedHRVM = new CreateRecruitedHRVM();
            ComboProject(recruitedHRVM);
            
            getAllRecruitedHR();
            return View(recruitedHRVM);

        }
        [HttpPost]
        public ActionResult RecruitedHRCreate(CreateRecruitedHRVM recruitedHRVM, FormCollection form)
        {
            try
            {
                List<ComboBatch> cb = ObjProjectMngBL.getComboBatchBL(recruitedHRVM.Project_ID, LoginRoleID);
                

                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    goto gotoWithModel;
                }

               string hdnRemaningHR = form["hdnRemaningHR"];

                if (recruitedHRVM.RecruitedHR > Convert.ToInt32(hdnRemaningHR))
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "Recruited-HR should not be greater than Planned-HR:  " + Convert.ToInt32(hdnRemaningHR));
                    goto gotoWithModel;
                }

                recruitedHRVM.CreatedByUser_ID=LoginUserID;
                StatusModel status = new ProjectManagementBL().recruitedCreateBL(recruitedHRVM);
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
            return RedirectToAction("RecruitedHRCreate");

            gotoWithModel:
            getAllRecruitedHR();
            ComboProject(recruitedHRVM);
            return View(recruitedHRVM);
        }

        [HttpGet]
        public ActionResult RecruitedHREdit(string RecruitedHRID)
        {
            EditRecruitedHRVM getRecruitedHR = new EditRecruitedHRVM();
            try
            {
                getRecruitedHR = new ProjectManagementBL().getSignleRecruitedHRBL(Convert.ToInt32(Utility.Encryption.DecryptURL(RecruitedHRID)));
                ComboProjectEdit(getRecruitedHR);
            }
            catch (Exception)
            {
            }

            return View(getRecruitedHR);
        }
        [HttpPost]
        public ActionResult RecruitedHREdit(EditRecruitedHRVM editRecruitedHRVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return View(editRecruitedHRVM);
                }
                editRecruitedHRVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new ProjectManagementBL().recruitedHREditBL(editRecruitedHRVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Updated, CommonMsg.UpdateSuccessfully);
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
            getProject();
            return RedirectToAction("RecruitedHRCreate");
        }
        #endregion

        [HttpGet]
        public ActionResult ProcurementCreateView()
        {
            CreateProcurementVM procurementVM = new CreateProcurementVM();
      
            ComboProjectProc(procurementVM);
            getAllProcurement();
            return View(procurementVM);
        }
        [HttpPost]
        public ActionResult ProcurementCreateView(CreateProcurementVM procurementVM, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    
                    goto gotoWithModel; 
                }
                if (procurementVM.NoOfProcurement > Convert.ToInt32(form["hdnRemainingProcurement"]))
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "Procurement should not be greater than Planned Procurement: " + form["hdnRemainingProcurement"]);
                    goto gotoWithModel;
                }
                procurementVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new ProjectManagementBL().procurementCreateBL(procurementVM);
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
            return RedirectToAction("ProcurementCreateView");

            gotoWithModel:
            ComboProjectProc(procurementVM);
            getAllProcurement();
            return View(procurementVM);
        }
        [HttpGet]
        public ActionResult ProcurementEdit(string AchievedProcurementID)
        {
            EditProcurementVM getProcurement = new EditProcurementVM();

            try
            {
                getProcurement = new ProjectManagementBL().getSignleProcurementBL(Convert.ToInt32(Utility.Encryption.DecryptURL(AchievedProcurementID)));
                ComboProjectProcEdit(getProcurement);
            }
            catch (Exception)
            {
            }

            return View(getProcurement);
        }
        [HttpPost]
        public ActionResult ProcurementEdit(EditProcurementVM editProcurementVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return View(editProcurementVM);
                }
                getProject();
                editProcurementVM.comboProjects = (List<ComboModel.ComboProject>)ViewBag.LstAllProject;
                editProcurementVM.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
                StatusModel status = new ProjectManagementBL().procurementEditBL(editProcurementVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Updated, CommonMsg.UpdateSuccessfully);
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
            getProject();
            return RedirectToAction("ProcurementCreateView");
        }
        public ActionResult NO()
        {
            return View();
        }

       

        public void Combo(CreateProjectVM projectVM)
        {
            //Get Category list
            projectVM.comboCategories = ObjProjectMngBL.getCategoryBL();
            //Get ProjectType list
            projectVM.comboProjectTypes = ObjProjectMngBL.getProjectTypeBL();
            //Get DigitalPolicy list
            projectVM.comboDigitalPolicies = ObjProjectMngBL.getDigitalPolicyBL();
            //Get Location/ City list
            projectVM.comboCities = ObjProjectMngBL.getCityBL();
            //Get Location/ City list
            projectVM.comboRiskStatus = ObjProjectMngBL.getRiskStatusBL();
            projectVM.comboFundingSource = ObjProjectMngBL.getFudingSourceBL();
        }
        public void ComboProject(CreateRecruitedHRVM recruitedHRVM)
        {
            //Get ProjectType list
            recruitedHRVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            recruitedHRVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            recruitedHRVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }

        #region ComboForCreateAndEdit
        public void ComboForRecruitedHR(CreateRecruitedHRVM recruitedHRVM)
        {
            recruitedHRVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        }
        public void ComboProjectEdit(EditRecruitedHRVM recruitedHRVM)
        {
            recruitedHRVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        }
        public void ComboProjectProc(CreateProcurementVM procurementVM)
        {
            procurementVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            procurementVM.comboBatch.Add(mb);

        }
        public void ComboProjectProcEdit(EditProcurementVM procurementEditVM)
        {
            procurementEditVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        }
        #endregion
        #region GetComo_Ignnor
        //public void ComboProjectEdit(EditRecruitedHRVM recruitedHRVM)
        //{
        //    //Get ProjectType list
        //    recruitedHRVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        //    ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
        //    recruitedHRVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
        //    ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
        //    recruitedHRVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        //}
        //public void ComboProjectProc(CreateProcurementVM procurementVM)
        //{
        //    //Get ProjectType list
        //    procurementVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        //    ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
        //    procurementVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
        //    ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
        //    procurementVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);

        //}
        //public void ComboProjectProcEdit(EditProcurementVM procurementEditVM)
        //{
        //    //Get ProjectType list
        //    procurementEditVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        //    ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
        //    procurementEditVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
        //    ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
        //    procurementEditVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);

        //}
        #endregion
        #region View List
        private void getAllRecruitedHR()
        {
            ViewBag.LstAllRecruitedHR = new ProjectManagementBL().getAllRecruitedHRBL(LoginRoleID, LoginUserID);
        }
        private void getAllProcurement()
        {
            ViewBag.LstAllProcurement = new ProjectManagementBL().getAllProcurementBL(LoginRoleID, LoginUserID);
        }
        private void getAllFinance()
        {
            ViewBag.LstAllFinance = new ProjectManagementBL().getAllRecruitedHRBL(LoginRoleID, LoginUserID);
        }
        private void getProject()
        {
            ViewBag.LstAllProject = new ProjectManagementBL().getComboProjectBL(LoginRoleID, LoginUserID);
        }
        #endregion
        #region CoboBoxes
        

   

        #endregion
        #region JSON

        [HttpGet]
        public JsonResult IsProjectNamelExists(string _ProjectName)
        {
            try
            {
                bool isExists = ObjProjectMngBL.IsProjectNameExistsBL(_ProjectName);
                if (isExists)
                {
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                } 
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
                return Json("false", JsonRequestBehavior.AllowGet);
            } 
        }

        [HttpPost]
        public JsonResult SearchProject(string ProjectName, string ProjectType, string Location)
        {
            try
            {
                List<GetAllProjectVM> resultList = ObjProjectMngBL.SearchProjectByAttributesBL(ProjectName, ProjectType, Location,LoginUserID,LoginRoleID);
                return Json(resultList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }


        //[HttpPost]
        //public JsonResult ProjectCheckUmbrella(int ProjectID)
        //{
        //    int val = ObjProjectMngBL.checkUmberlaBL(ProjectID);
        //    return Json(val, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult ProjectCheckUmbrella(int ProjectID)
        {
            try
            {
                int[] value = new int[5];
                int val = ObjProjectMngBL.checkUmberlaBL(ProjectID);
                value[0] = val; 
                //StatusModel status = ObjProjectMngBL.ComparePlannedHR_RecruitedHRBL(ProjectID, out value[1], out value[2]);
                StatusModel status2 = ObjProjectMngBL.ComparePlanned_PrucrementBL(ProjectID, out value[3], out value[4]);
                return Json(value, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CheckBatchIsZero(int SubProjectID)
        {
            int val = ObjProjectMngBL.checkBatchIsZeroBL(SubProjectID);
            return Json(val, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult ComparePlannedHR_RecruitedHR(int _ProjectID)
        //{
        //    try
        //    {
        //        int[] value = new int[2];
        //        StatusModel status = ObjProjectMngBL.ComparePlannedHR_RecruitedHRBL(_ProjectID, out value[0], out value[1]);
        //        if (status.status)
        //        {
        //            return Json(value, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            value[0] = 0;
        //            value[1] = 0;
        //            return Json(value, JsonRequestBehavior.AllowGet);

        //        }
        //    }
        //    catch (Exception ex1)
        //    {
        //        ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
        //        return Json("false", JsonRequestBehavior.AllowGet);
        //    }
        //}


        #endregion
        #region CUSTOMFUNCATION

       
        #endregion

    }
}
