
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
    public class EvaluationController : BaseController
    {
        CommonCombo allCombo = new CommonCombo();
        // GET: Evaluation
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        [HttpGet]
        public ActionResult EvaluationCreate()
        {
            CreateProjectKPIsStatusVM kpisVM = new CreateProjectKPIsStatusVM();
            ComboProject(kpisVM);
            return View(kpisVM);
        }

        [HttpPost]
        public ActionResult EvaluationCreate(CreateProjectKPIsStatusVM modelVM)
        {
            StatusModel  status = new EvaulationManagementBL().InsertEvaulationBL(modelVM);
            if (status.status)
            { ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully); }
            else { ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.OperationNotperform);  }
            
            return View(modelVM);
        }

        //Custom Function
        public void ComboProject(CreateProjectKPIsStatusVM kpisVM)
        {

            #region DropDown
            new CommonController().allDropDown(ref allCombo, LoginRoleID, LoginUserID);
            kpisVM.comboProjects = allCombo.comboProject;
            kpisVM.comboSubProjects = allCombo.comboSubProjects;
            kpisVM.comboBatch = allCombo.comboBatch;
            #endregion

            //Combo Indicator
            ComboPlannedKPIs mi = new ComboPlannedKPIs() { PlannedKPIsID = 0, IndicatorDescription = "Please Select Indicator" };
            kpisVM.comboPlannedKPIs.Add(mi);
            kpisVM.comboPlannedKPIs = ObjProjectMngBL.getComboPlannedKPIsBL();
        }
    }
}