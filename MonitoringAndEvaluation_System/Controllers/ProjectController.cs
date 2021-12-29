using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.ComboModel;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: Project
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
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
                ProjectVM.DigitalPolicy_ID = Convert.ToInt32( Request.Form["txtDigitalPolicy_ID"]);
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
                ProjectVM.AchievedProcurement = Convert.ToInt32(Request.Form["txtAchievedProcurement"]);
                ProjectVM.ProcurementPercent = Convert.ToDouble(Request.Form["txtProcurementPercent"]);
                ProjectVM.User_ID = LoginUserID;//Convert.ToInt32(Session["LoginUserID"]);
                #endregion
                #region FundingArray
                string aaa = Convert.ToString(Request.Form["FundingSourceArray"]);
                ProjectVM.Funding_Source =  string.Join(",", aaa);
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

               // ModelState.Remove("RiskStatus_ID");
                //if (ModelState.IsValid == false)
                //{
                //    Combo(ProjectVM);
                //   return View(ProjectVM);
                //}
                StatusModel status = ObjProjectMngBL.projectCreateBL(ProjectVM);
                if (status.status)
                {
                    TempData["Message"] = status.statusDetail;
                    TempData.Keep("Message");
                    //ModelState.AddModelError("OK",status.statusDetail);
                }
                else
                {
                    TempData["Message"] = status.statusDetail;
                    return Json("false");
                }

            }
            catch (Exception ex1)
            {
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
            List<GetAllProjectVM> lst = new ProjectManagementBL().getAllProjectBL(LoginRoleID,LoginUserID);
            return View(lst);
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
        public ActionResult RecruitedHRCreate(CreateRecruitedHRVM recruitedHRVM)
        {
            try
            {
                List<ComboBatch> cb = ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
                //int valBatch = ObjProjectMngBL.checkUmberlaBL(recruitedHRVM.Project_ID);
                //if (cb.Count() < 1)
                //{
                //    recruitedHRVM.Batch_ID = 0;
                //}

                //int val = ObjProjectMngBL.checkUmberlaBL(recruitedHRVM.Project_ID);
                //if(val != 1) //Non-Umbrella
                //{
                //    recruitedHRVM.SubProject_ID = 0;
                //    recruitedHRVM.Batch_ID = 0;
                //}
                if (ModelState.IsValid == false)
                {
                    ComboProject(recruitedHRVM);
                    getAllRecruitedHR();
                    return View(recruitedHRVM);
                }

                recruitedHRVM.CreatedByUser_ID=LoginUserID;
                StatusModel status = new ProjectManagementBL().recruitedCreateBL(recruitedHRVM);
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
            ComboProject(recruitedHRVM);
            getAllRecruitedHR();
            return RedirectToAction("RecruitedHRCreate");
        }

        [HttpGet]
        public ActionResult RecruitedHREdit(int RecruitedHRID)
        {
            EditRecruitedHRVM getRecruitedHR = new EditRecruitedHRVM();
            try
            {

                getRecruitedHR = new ProjectManagementBL().getSignleRecruitedHRBL(RecruitedHRID);
                getProject();
                getRecruitedHR.comboProjects = (List<ComboModel.ComboProject>)ViewBag.LstAllProject;
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
                    return View(editRecruitedHRVM);
                }
                getProject();
                editRecruitedHRVM.comboProjects = (List<ComboModel.ComboProject>)ViewBag.LstAllProject;
                editRecruitedHRVM.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
                StatusModel status = new ProjectManagementBL().recruitedHREditBL(editRecruitedHRVM);
                if (status.status)
                {
                    TempData["Message"] = "Record Updeted Successfully.";
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
        public ActionResult ProcurementCreateView(CreateProcurementVM procurementVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(procurementVM);
                }

                procurementVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new ProjectManagementBL().procurementCreateBL(procurementVM);
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
            return RedirectToAction("ProcurementCreateView");
            //return View();
        }
        [HttpGet]
        public ActionResult ProcurementEdit(int AchievedProcurementID)
        {
            EditProcurementVM getProcurement = new EditProcurementVM();

            try
            {

                getProcurement = new ProjectManagementBL().getSignleProcurementBL(AchievedProcurementID);
                getProject();
                getProcurement.comboProjects = (List<ComboModel.ComboProject>)ViewBag.LstAllProject;
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
                    return View(editProcurementVM);
                }
                getProject();
                editProcurementVM.comboProjects = (List<ComboModel.ComboProject>)ViewBag.LstAllProject;
                editProcurementVM.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
                StatusModel status = new ProjectManagementBL().procurementEditBL(editProcurementVM);
                if (status.status)
                {
                    TempData["Message"] = "Record Updeted Successfully.";
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
            getProject();
            return RedirectToAction("ProcurementCreateView");
        }
        public ActionResult NO()
        {
            return View();
        }

        #region CustomFuncation

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
            recruitedHRVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID,LoginUserID);
            ComboSubProject  msp= new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            recruitedHRVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            recruitedHRVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
        public void ComboProjectProc(CreateProcurementVM procurementVM)
        {
            //Get ProjectType list
            procurementVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            procurementVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            procurementVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);

        }
        private void getAllRecruitedHR()
        {
            ViewBag.LstAllRecruitedHR = new ProjectManagementBL().getAllRecruitedHRBL(LoginRoleID, LoginUserID);
        }
        private void getAllProcurement()
        {
            ViewBag.LstAllProcurement = new ProjectManagementBL().getAllProcurementBL(LoginRoleID,LoginUserID);
        }
        private void getAllFinance()
        {
            ViewBag.LstAllFinance = new ProjectManagementBL().getAllRecruitedHRBL(LoginRoleID, LoginUserID);
        }
        private void getProject()
        {
            ViewBag.LstAllProject = new ProjectManagementBL().getComboProjectBL(LoginRoleID, LoginUserID);
        }

        [HttpPost]
        public JsonResult ClickSubProjectCombo(int SubProject_ID)
        {
            List<ComboBatch> cb = ObjProjectMngBL.getComboBatchBL(SubProject_ID, LoginRoleID);
            if(cb.Count() < 1)
            {
                return Json(cb, JsonRequestBehavior.AllowGet);
            }
            cb.Insert(0, new ComboBatch { BatchID = 0, BatchName = "Please Select Batch" });
            return Json(cb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ClickProjectCombo(int Project_ID)
        {
            List <ComboSubProject>   cb = ObjProjectMngBL.getComboSubProjectBL(Project_ID, LoginRoleID);
            cb.Insert(0, new ComboSubProject {SubProjectID = 0, SubProjectName = "Please Select SubProject" });
            return Json(cb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ProjectCheckUmbrella(int ProjectID)
        {
            int val = ObjProjectMngBL.checkUmberlaBL(ProjectID);
            return Json(val, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CheckBatchIsZero(int SubProjectID)
        { 
            int val = ObjProjectMngBL.checkBatchIsZeroBL(SubProjectID);
            return Json(val, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}