using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class IndicatorController : BaseController
    {
        // GET: Indicator
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
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
                    getAllIndicator();
                    return View(indicatorVM);
                }
                StatusModel status = new IndicatorBL().indicatorCreateBL(indicatorVM);
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
            getAllIndicator();
            return RedirectToAction("IndicatorCreateView");
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

        }
        [HttpGet]
        public ActionResult LinkIndicator()
        {
            CreateLinkIndicatorVM linkIndicatorVM = new CreateLinkIndicatorVM();
            ComboForLink(linkIndicatorVM);
            return View(linkIndicatorVM);
        }

        [HttpPost]
        public ActionResult LinkIndicator(CreateLinkIndicatorVM linkIndicatorVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {

                    return View(linkIndicatorVM);
                }
                StatusModel status = new IndicatorBL().linkIndicatorCreateBL(linkIndicatorVM);
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
            getAllIndicator();
            return RedirectToAction("LinkIndicator");
        }
        public ActionResult IndicatorFieldValue()
        {
            return View();
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
            linkIndicatorVM.comboIndicator = ObjProjectMngBL.getComboIndicatorBL();
        }
        public void ComboForField(CreateIndicatorFieldVM indicatorFieldVM)
        {
            indicatorFieldVM.comboIndicator = ObjProjectMngBL.getComboIndicatorBL();
            indicatorFieldVM.comboIndicatorDataTypes = ObjProjectMngBL.getComboDataTypeBL();
        }
    }
}