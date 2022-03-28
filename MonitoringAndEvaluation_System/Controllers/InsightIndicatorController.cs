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
    public class InsightIndicatorController : BaseController
    {
        // GET: Indicator
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        InsightIndicatorBL ObjInsightIndicatorMngBL = new InsightIndicatorBL();
        //InsightIndicatorCreate

        #region Insight Indicator
        [HttpGet]
        public ActionResult InsightIndicatorCreate()
        {
            CreateInsightIndicatorVM insightIndicatorVM = new CreateInsightIndicatorVM();
            ComboForInsightIndicator(insightIndicatorVM);
            return View(insightIndicatorVM);
        }

        [HttpPost]
        public ActionResult InsightIndicatorCreate(CreateInsightIndicatorVM insightIndicatorVM)
        {
            try
            {
                #region InsightIndicator
                insightIndicatorVM.Project_ID = Convert.ToInt32(Request.Form["txtProject_ID"]);
                insightIndicatorVM.SubProject_ID = Convert.ToInt32(Request.Form["txtSubProject_ID"]);
                insightIndicatorVM.Batch_ID = Convert.ToInt32(Request.Form["txtBatch_ID"]);
                insightIndicatorVM.InsightIndicatorName = Convert.ToString(Request.Form["txtInsightIndicatorName"]);
                #region Expenditure
                //From Risk GridView
                List<InsightIndicatorField> _lstInsightIndicatorField = new List<InsightIndicatorField>();
                string[] InsightIndicatorFieldRows = Request.Form["_InsightIndicatorFieldRows"].Split(',');
                for (int i = 0; i < InsightIndicatorFieldRows.Length; i++)
                {
                    if (InsightIndicatorFieldRows[0].Trim() != "")
                    {
                        InsightIndicatorField mm = new InsightIndicatorField();
                        string[] ItemArray = InsightIndicatorFieldRows[i].Split('|');
                        mm.InsightIndicatorFieldName = Convert.ToString(ItemArray[1]);
                        mm.InsightIndicatorDataType_ID = Convert.ToInt32(ItemArray[2]);
                        _lstInsightIndicatorField.Add(mm);
                    }
                }
                insightIndicatorVM.AssignInsightIndicatorFieldList = _lstInsightIndicatorField;

                #endregion


                StatusModel status = ObjInsightIndicatorMngBL.insightIndicatorCreateBL(insightIndicatorVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
                    return Json("false");
                }

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

        [HttpGet]
        public ActionResult InsightIndicatorView()
        {
            @ViewBag.MainTitle = "Insight Indicator List";
            List<GetAllInsightIndicatorVM> lst = new InsightIndicatorBL().getAllInsightIndicatorBL(LoginRoleID, LoginUserID);
            return View(lst);
        }

        #endregion



        //[HttpGet]
        //public ActionResult IndicatorFieldCreate()
        //{
        //    CreateIndicatorFieldVM fieldIndicatorVM = new CreateIndicatorFieldVM();
        //    ComboForField(fieldIndicatorVM);
        //    return View(fieldIndicatorVM);

        //}

        //[HttpPost]
        //public ActionResult IndicatorFieldCreate(CreateIndicatorFieldVM model)
        //{
        //    try
        //    {
        //        List<CreateIndicatorFieldVM> fieldIndicatorLst = new List<CreateIndicatorFieldVM>();
        //        string[] _IndicatorFields = Request.Form["_IndicatorFields"].Split(',');
        //        for (int i = 0; i < _IndicatorFields.Length; i++)
        //        {
        //            if (_IndicatorFields[0].Trim() != "")
        //            {
        //                string[] ItemArray = _IndicatorFields[i].Split('|');
        //                fieldIndicatorLst.Add(new CreateIndicatorFieldVM()
        //                {
        //                    Indicator_ID = Convert.ToInt32(ItemArray[1]),
        //                    IndicatorDataType_ID = Convert.ToInt32(ItemArray[2]),
        //                    IndicatorFieldName = Convert.ToString(ItemArray[3])
        //                });
        //            }
        //        }
        //        StatusModel status = new InsightIndicatorBL().indicatorFeildCreateBL(fieldIndicatorLst);
        //        if (status.status)
        //        {
        //            //TempData["Message"] = status.statusDetail;
        //            //TempData.Keep("Message");
        //            ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
        //        }
        //        else
        //        {
        //            ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
        //            return Json("false");
        //        }

        //    }
        //    catch (Exception ex1)
        //    {
        //        ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
        //        return Json("false");
        //    }
        //    return Json("true");

        //}
        //[HttpGet]
        //public ActionResult LinkIndicator()
        //{
        //    CreateLinkIndicatorVM linkIndicatorVM = new CreateLinkIndicatorVM();
        //    ComboForLink(linkIndicatorVM);
        //    getAllLinkIndicator();
        //    return View(linkIndicatorVM);
        //}

        //[HttpPost]
        //public ActionResult LinkIndicator(CreateLinkIndicatorVM linkIndicatorVM)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid == false)
        //        {
        //            ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
        //            goto gotoWithModel;
        //        }
        //        StatusModel status = new InsightIndicatorBL().linkIndicatorCreateBL(linkIndicatorVM);
        //        if (status.status)
        //        {
        //            ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
        //        }
        //        else
        //        {
        //            ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);
        //            goto gotoWithModel;
        //        }
        //    }
        //    catch (Exception ex1)
        //    {
        //        ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
        //        goto gotoWithModel;
        //    }
        //    return RedirectToAction("LinkIndicator");

        //    gotoWithModel:
        //    getAllInsightIndicator();
        //    return View(linkIndicatorVM);

        //}

        [HttpGet]
        public ActionResult InsightIndicatorFieldValue()
        {
            CreateInsightIndicatorValueVM indicatorValueVM = new CreateInsightIndicatorValueVM();
            ComboForValue(indicatorValueVM);
            return View(indicatorValueVM);
        }

        [HttpPost]
        public ActionResult InsightIndicatorFieldValue(CreateInsightIndicatorValueVM valueVM)
        {
            try
            {
                 

                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return RedirectToAction("InsightIndicatorFieldValue");
                }
                StatusModel status = new InsightIndicatorBL().InsightIndicatorFieldValueCreateBL(valueVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                    return RedirectToAction("InsightIndicatorFieldValue");
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
        //private void getAllInsightIndicator()
        //{
        //    ViewBag.LstAllInsightIndicators = new InsightIndicatorBL().getAllInsightIndicatorBL();
        //}
        //public void ComboForLink(CreateLinkIndicatorVM linkIndicatorVM)
        //{
        //    //Get ProjectType list
        //    linkIndicatorVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        //    ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
        //    linkIndicatorVM.comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
            
        //}
        public void ComboForValue(CreateInsightIndicatorValueVM insightIndicatorValueVM)
        {
            //Combo Project
            insightIndicatorValueVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
           
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            insightIndicatorValueVM.comboBatch.Add(mb);
            //Combo Indicator
            ComboIndicator mi = new ComboIndicator() { InsightIndicatorID = 0, InsightIndicatorName = "Please Select Indicator" };
            insightIndicatorValueVM.comboIndicator.Add(mi);
            insightIndicatorValueVM.comboIndicator = ObjProjectMngBL.getComboIndicatorBL();
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
            ViewBag.LstAllLinkIndicator = new InsightIndicatorBL().getALLLinkIndicatorBL();
        }
        #endregion
        #region Json
      #endregion
    }
}