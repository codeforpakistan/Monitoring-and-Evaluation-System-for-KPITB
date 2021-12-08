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
    public class ProjectController : Controller
    {
        // GET: Project
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        [HttpGet]
        public ActionResult ProjectCreate()
        {
            CreateProjectVM projectVM = new CreateProjectVM();



            Combo(projectVM);
            return View(projectVM);
        }
        [HttpPost]
        public ActionResult ProjectCreate(CreateProjectVM ProjectVM , FormCollection formCollection)
        {
            try
            {
                //if (ModelState.IsValid == false)
                //{
                //    return View(ProjectVM);
                //}

                #region SingleValues
                ProjectVM.Category_ID = Convert.ToInt32( Request.Form["txtCategory_ID"]);
                ProjectVM.ProjectType_ID = Convert.ToInt32( Request.Form["txtProjectType_ID"]);
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
                ProjectVM.User_ID = Convert.ToInt32(Session["LoginUserID"]);
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
                        m.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
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
                        mm.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
                        _lstStackholder.Add(mm);
                    }
                }
                ProjectVM.AssignStackholderList = _lstStackholder;
                    #endregion
                

                StatusModel status = ObjProjectMngBL.projectCreateBL(ProjectVM);
                if (status.status)
                {
                    TempData["Message"] = status.statusDetail;
                    ModelState.AddModelError("OK",status.statusDetail);
                }
                else
                {
                    TempData["Message"] = status.statusDetail;
                }

            }
            catch (Exception ex1)
            {
            }
            //return View("ProjectView", new ProjectManagementBL().getAllProjectBL());
            return View("~/Views/Project/ProjectView.cshtml", new ProjectManagementBL().getAllProjectBL());
        }

        [HttpGet]
        public ActionResult ProjectView()
        {
            @ViewBag.MainTitle = "Project List";
            List<GetAllProjectVM> lst = new ProjectManagementBL().getAllProjectBL();
            return View(lst);
        }
        public ActionResult RecruitedHRCreate()
        {
            return View();
        }
        public ActionResult ProcurementCreate()
        {
            return View();
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
        #endregion
    }
}