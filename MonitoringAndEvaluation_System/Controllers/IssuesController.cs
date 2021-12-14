using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class IssuesController : Controller
    {
        // GET: Issues
        ProjectManagementBL ObjProjectMngBL = new ProjectManagementBL();
        //IssueCreate
        [HttpGet]
        public ActionResult IssueCreateView()
        {
            CreateIssueVM issueVM = new CreateIssueVM();
            getProject(issueVM);
            getAllIssue();
            return View(issueVM);
        }
        [HttpPost]
        public ActionResult IssueCreateView(CreateIssueVM issueVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    getAllIssue();
                    return View(issueVM);
                }

                issueVM.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
                StatusModel status = new IssuesManagementBL().issueCreateBL(issueVM);
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
            getAllIssue();
            return RedirectToAction("IssueCreateView");
        }
        //IssueEdit
        [HttpGet]
        public ActionResult IssueEdit(int IssuesID)
        {
            EditIssueVM getIssues = new EditIssueVM();

            try
            {

                getIssues = new IssuesManagementBL().getSignleIssueBL(IssuesID);
                getAllIssue();
                getProjectEdit(getIssues);

            }
            catch (Exception)
            {
            }

            return View(getIssues);
        }
        [HttpPost]
        public ActionResult IssueEdit(EditIssueVM issueVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(issueVM);
                }
                getProjectEdit(issueVM);
                issueVM.comboProjects = (List<ComboModel.ComboProject>)ViewBag.LstAllIssues;
                issueVM.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
                StatusModel status = new IssuesManagementBL().issueEditBL(issueVM);
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
            getAllIssue();
            return RedirectToAction("IssueCreateView");
        }

        private void getProjectEdit(EditIssueVM issuesEditVM)
        {
            issuesEditVM.comboProjects = ObjProjectMngBL.getComboProjectBL();
        }


        //Custom Function
        public void getProject(CreateIssueVM issuesVM)
        {
            //Get ProjectType list
            issuesVM.comboProjects = ObjProjectMngBL.getComboProjectBL();
        }
        
        private void getAllIssue()
        {
            ViewBag.LstAllIssues = new IssuesManagementBL().getAllIssueBL();
        }

    }
}