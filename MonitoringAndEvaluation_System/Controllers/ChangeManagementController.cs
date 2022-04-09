using BusinessLayer;
using ModelLayer;
using MonitoringAndEvaluation_System.CommonUse;
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
    public class ChangeManagementController : BaseController
    {
        CommonCombo allCombo = new CommonCombo();

        // GET: ChangeManagement
        [HttpGet]
        public ActionResult ChangeMngCreate()
        {
            ChangeManagementVM modelVM = new ChangeManagementVM();
            #region DropDown
            new CommonController().allDropDown(ref allCombo, LoginRoleID, LoginUserID);
            modelVM.comboProjects = allCombo.comboProject;
            modelVM.comboSubProjects = allCombo.comboSubProjects;
            #endregion
            return View(modelVM);
        }

        [HttpPost]
        public ActionResult ChangeMngCreate(ChangeManagementVM ListOfChangeManagementVM)
        {
            try
            {
                ListOfChangeManagementVM.MeetingDate = DateTime.Now;
                ListOfChangeManagementVM.MeetingNo = "";
                StatusModel statusModel = new ChangeManagementBL().changeManagementCreateBL(ListOfChangeManagementVM, LoginUserID);
                if (statusModel.status)
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

            return RedirectToAction("ChangeMngCreate");
        }

    }
}