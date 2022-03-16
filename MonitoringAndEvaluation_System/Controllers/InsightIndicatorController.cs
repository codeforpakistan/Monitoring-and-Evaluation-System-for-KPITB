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
    public class InsightIndicatorController : BaseController
    {
        // GET: Indicator
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        IndicatorBL ObjIndicatorMngBL = new IndicatorBL();
        //InsightIndicatorCreate
        [HttpGet]
        public ActionResult InsightIndicatorCreate()
        {
            CreateInsightIndicatorVM insightIndicatorVM = new CreateInsightIndicatorVM();
            ComboForInsightIndicator(insightIndicatorVM);
            return View(insightIndicatorVM);
        }

        #region Insight Indicator

        #endregion
        //IndicatorCreate
        [HttpGet]
        public ActionResult IndicatorCreateView()
        {
            CreateIndicatorVM indicatorVM = new CreateIndicatorVM();
            getAllIndicator();
            return View(indicatorVM);
        }
        [HttpPost]
        public ActionResult IndicatorCreateView(CreateIndicatorVM indicatorVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    goto gotoWithModel;
                }
                bool isExists = new IndicatorBL().IsIndicatorNameExistsBL(indicatorVM.IndicatorName);  //Check DuplicateIndicatorName
                if (isExists)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "IndicatorName Already Exists");
                    goto gotoWithModel;
                }
                StatusModel status = new IndicatorBL().indicatorCreateBL(indicatorVM);
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
            return RedirectToAction("IndicatorCreateView");
            gotoWithModel:
            getAllIndicator();
            return View(indicatorVM);

        }
        [HttpGet]
        public ActionResult IndicatorFieldCreate()
        {
            CreateIndicatorFieldVM fieldIndicatorVM = new CreateIndicatorFieldVM();
            ComboForField(fieldIndicatorVM);
            return View(fieldIndicatorVM);

        }

        [HttpPost]
        public ActionResult IndicatorFieldCreate(CreateIndicatorFieldVM model)
        {
            try
            {
                List<CreateIndicatorFieldVM> fieldIndicatorLst = new List<CreateIndicatorFieldVM>();
                string[] _IndicatorFields = Request.Form["_IndicatorFields"].Split(',');
                for (int i = 0; i < _IndicatorFields.Length; i++)
                {
                    if (_IndicatorFields[0].Trim() != "")
                    {
                        string[] ItemArray = _IndicatorFields[i].Split('|');
                        fieldIndicatorLst.Add(new CreateIndicatorFieldVM()
                        {
                            Indicator_ID = Convert.ToInt32(ItemArray[1]),
                            IndicatorDataType_ID = Convert.ToInt32(ItemArray[2]),
                            IndicatorFieldName = Convert.ToString(ItemArray[3])
                        });
                    }
                }
                StatusModel status = new IndicatorBL().indicatorFeildCreateBL(fieldIndicatorLst);
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

        }
        [HttpGet]
        public ActionResult LinkIndicator()
        {
            CreateLinkIndicatorVM linkIndicatorVM = new CreateLinkIndicatorVM();
            ComboForLink(linkIndicatorVM);
            getAllLinkIndicator();
            return View(linkIndicatorVM);
        }

        [HttpPost]
        public ActionResult LinkIndicator(CreateLinkIndicatorVM linkIndicatorVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    goto gotoWithModel;
                }
                StatusModel status = new IndicatorBL().linkIndicatorCreateBL(linkIndicatorVM);
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
            return RedirectToAction("LinkIndicator");

            gotoWithModel:
            getAllIndicator();
            return View(linkIndicatorVM);

        }

        [HttpGet]
        public ActionResult IndicatorFieldValue()
        {
            CreateIndicatorValueVM indicatorValueVM = new CreateIndicatorValueVM();
            ComboForValue(indicatorValueVM);
            return View(indicatorValueVM);
        }

        [HttpPost]
        public ActionResult IndicatorFieldValue(CreateIndicatorValueVM valueVM)
        {
            try
            {
                 

                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return RedirectToAction("IndicatorFieldValue");
                }
                StatusModel status = new IndicatorBL().indicatorFieldValueCreateBL(valueVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                    return RedirectToAction("IndicatorFieldValue");
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
                    return View(valueVM);
                }
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
            }
            //getAllIndicator();
            ComboForValue(valueVM);
            return View(valueVM);
        }

        //Custom Function
        private void getAllIndicator()
        {
            ViewBag.LstAllIndicators = new IndicatorBL().getAllIndicatorBL();
        }
        public void ComboForLink(CreateLinkIndicatorVM linkIndicatorVM)
        {
            //Get ProjectType list
            linkIndicatorVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            linkIndicatorVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
            
        }
        public void ComboForValue(CreateIndicatorValueVM IndicatorValueVM)
        {
            //Combo Project
            IndicatorValueVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            //Combo Batch
            //ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            //IndicatorValueVM.comboBatch.Add(mb); 
            ////Combo Indicator
            //ComboIndicator mi = new ComboIndicator() { IndicatorID = 0, IndicatorName = "Please Select Indicator" };
            //IndicatorValueVM.comboIndicator.Add(mi);
            //IndicatorValueVM.comboIndicator = ObjProjectMngBL.getComboIndicatorBL();
        }
        public void ComboForField(CreateIndicatorFieldVM indicatorFieldVM)
        {
            indicatorFieldVM.comboIndicator = ObjProjectMngBL.getComboIndicatorBL();
            indicatorFieldVM.comboInsightIndicatorDataTypes = ObjProjectMngBL.getComboDataTypeBL();
        }

        //Combo For InsightIndicator 
        public void ComboForInsightIndicator(CreateInsightIndicatorVM insightIndicatorVM)
        {
            //Get ProjectType list
            insightIndicatorVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            insightIndicatorVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
            insightIndicatorVM.comboInsightIndicatorDataTypes = ObjProjectMngBL.getComboDataTypeBL();
        }
        #region ComboSetting


        private void getAllLinkIndicator()
        {
            ViewBag.LstAllLinkIndicator = new IndicatorBL().getALLLinkIndicatorBL();
        }
        #endregion
        #region Json
      #endregion
    }
}