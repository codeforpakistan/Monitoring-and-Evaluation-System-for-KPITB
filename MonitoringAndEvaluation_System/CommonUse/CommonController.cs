using BusinessLayer;
using ModelLayer;
using MonitoringAndEvaluation_System.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.CommonUse
{
    //INDICATOR
    public partial class CommonController : BaseController
    {

        [HttpPost]
        public JsonResult ClickIndicatorComboBox( int InsightIndicatorID)
        {
            CreateInsightIndicatorValueVM m = new CreateInsightIndicatorValueVM();

            m.dataTypeVMLst = new InsightIndicatorBL().getndicatorDataTypeBL(InsightIndicatorID);
            m.dataTypeCommonVMLst = new InsightIndicatorBL().getIndicatorInsertedFieldBaseOnIndicatorBL(InsightIndicatorID);
            return Json(m, JsonRequestBehavior.AllowGet);
        }
     
        [HttpPost]
        public JsonResult IsIndicatorNameExists(string _IndicatorName)
        {
            try
            {
                bool isExists = new InsightIndicatorBL().IsIndicatorNameExistsBL(_IndicatorName);
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
       
         
    }
    //PROJECT
    public partial class CommonController
    {
        [HttpPost]
        public JsonResult ClickSubProjectCombo(int SubProject_ID)
        {
            List<ComboBatch> cb = new ProjectManagementBL().getComboBatchBL(SubProject_ID, LoginRoleID);
            if (cb.Count() < 1)
            {
                return Json(cb, JsonRequestBehavior.AllowGet);
            }
            cb.Insert(0, new ComboBatch { BatchID = 0, BatchName = "Please Select Batch" });
            return Json(cb, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ClickProjectComboBox(int ProjectID, int? SubProjectID, int? Batch_ID)
        {
            ComboIndicatorBatchIndicatorVM batchIndicatorVM = new ComboIndicatorBatchIndicatorVM();
            //SubProject

            batchIndicatorVM.comboSubProjects = new ProjectManagementBL().getComboSubProjectBL(ProjectID, LoginRoleID);
            batchIndicatorVM.comboSubProjects.Insert(0, new ComboSubProject { SubProjectID = 0, SubProjectName = "Please Select Sub Project" });
            //Batch
            batchIndicatorVM.comboBatches = new ProjectManagementBL().getComboBoxBatchBL(ProjectID, LoginRoleID, SubProjectID);
            batchIndicatorVM.comboBatches.Insert(0, new ComboBatch { BatchID = 0, BatchName = "Please Select Batch" });

            //Indicator
            batchIndicatorVM.comboIndicators = new ProjectManagementBL().getComboIndicatorBL(ProjectID, SubProjectID, Batch_ID);
            batchIndicatorVM.comboIndicators.Insert(0, new ComboIndicator { InsightIndicatorID = 0, InsightIndicatorName = "Please Select Indicator" });

            batchIndicatorVM.comboProcurementHeads = new ProjectManagementBL().getComboProcurementHeadBL(Convert.ToInt32(ProjectID),0);
            batchIndicatorVM.comboProcurementHeads.Insert(0, new ComboProcurementHead { PlannedProcurementID = 0, ProcrumetHeader = "Please Select Procurement Head" });

            batchIndicatorVM.remainingValues = new ProjectManagementBL().RemainingValuesBL(ProjectID, SubProjectID);
            return Json(batchIndicatorVM, JsonRequestBehavior.AllowGet);
        }
         
        [HttpPost]
        public JsonResult ClickBatchComboBox(string Project_ID, string Batch_ID)
        {
            List<ComboIndicator> cb = new ProjectManagementBL().getComboIndicatorBL(Convert.ToInt32(Project_ID),null, Convert.ToInt32(Batch_ID));// Batch, LoginRoleID);
            cb.Insert(0, new ComboIndicator { InsightIndicatorID = 0, InsightIndicatorName = "Please Select Indicator" });
            return Json(cb, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ClickProjectCombo(int Project_ID)
        {
            List<ComboSubProject> cb = new ProjectManagementBL().getComboSubProjectBL(Project_ID, LoginRoleID);
            cb.Insert(0, new ComboSubProject { SubProjectID = 0, SubProjectName = "Please Select SubProject" });
            return Json(cb, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult IsProjectNamelExists(string _ProjectName)
        {
            try
            {
                bool isExists = new ProjectManagementBL().IsProjectNameExistsBL(_ProjectName);
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
                List<GetAllProjectVM> resultList = new ProjectManagementBL().SearchProjectByAttributesBL(ProjectName, ProjectType, Location, LoginUserID, LoginRoleID);
                return Json(resultList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ProjectCheckUmbrella(int ProjectID)
        {
            try
            {
                int[] value = new int[5];
                int val = new ProjectManagementBL().checkUmberlaBL(ProjectID); // Project Umberla OR NonUmberla
                value[0] = val;
//CHANGER                StatusModel status = new ProjectManagementBL().ComparePlannedHR_RecruitedHRBL(ProjectID, out value[1], out value[2]);
                StatusModel status2 = new ProjectManagementBL().ComparePlanned_PrucrementBL(ProjectID, out value[3], out value[4]);
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
            int val = new ProjectManagementBL().checkBatchIsZeroBL(SubProjectID);
            return Json(val, JsonRequestBehavior.AllowGet);
        }
    }


    //USERS
    public partial class CommonController
    {
        public JsonResult IsEmailExists(string _Email)
        {
            try
            {
                bool isExists = new UserManagementBL().IsEmailExistsBL(_Email);
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


        #region CUSTOM_FUNCTION
        
         public void allDropDown(ref CommonCombo combo, int LoginRoleID, int LoginUserID)//out List<ComboProject> comboProject, out List<ComboSubProject> comboSubProject, out List<ComboBatch> comboBatch)
        {
            combo.comboProject = new ProjectManagementBL().getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            combo.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            combo.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
        #endregion
    }
}