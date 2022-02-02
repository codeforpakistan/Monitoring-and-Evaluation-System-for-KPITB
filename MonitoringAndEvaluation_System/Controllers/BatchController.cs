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
    public class BatchController :BaseController
    {
        // GET: Issues
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        //IssueCreate
        [HttpGet]
        public ActionResult BatchCreateView()
        {
            CreateBatchVM batchVM = new CreateBatchVM();
            ComboProject(batchVM);
            getAllBatch();
            
            return View(batchVM);
        }
        [HttpPost]
        public ActionResult BatchCreateView(CreateBatchVM batchVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    //getAllIssue();
                    return View(batchVM);
                }

                batchVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new BatchManagementBL().batchCreateBL(batchVM);
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
          
            return RedirectToAction("BatchCreateView");
        }

        private void getAllBatch()
        {
            ViewBag.LstAllBatch = new BatchManagementBL().getAllBatchBL(LoginRoleID, LoginUserID);
        }
        public void ComboProject(CreateBatchVM batchVM)
        {
            //Get ProjectType list
            batchVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            batchVM.comboSubProjects.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
           
        }
    }
}