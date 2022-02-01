﻿using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class IssuesController : BaseController
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
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return View(issueVM);
                }

                issueVM.CreatedByUser_ID = LoginUserID;
                StatusModel status = new IssuesManagementBL().issueCreateBL(issueVM);
                if (status.status)
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
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    issueVM = new IssuesManagementBL().getSignleIssueBL(issueVM.IssuesID);
                    getAllIssue();
                    return View(issueVM);
                }
                getProjectEdit(issueVM);
                issueVM.comboProjects = (List<ComboModel.ComboProject>)ViewBag.LstAllIssues;
                issueVM.CreatedByUser_ID = Convert.ToInt32(Session["LoginUserID"]);
                StatusModel status = new IssuesManagementBL().issueEditBL(issueVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Updated, CommonMsg.UpdateSuccessfully);
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
            getAllIssue();
            return RedirectToAction("IssueCreateView");
        }

        private void getProjectEdit(EditIssueVM issuesEditVM)
        {
            issuesEditVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        }


        //Custom Function
        public void getProject(CreateIssueVM issuesVM)
        {
            //Get ProjectType list
            issuesVM.comboProjects = ObjProjectMngBL.getComboProjectBL(LoginRoleID, LoginUserID);
        }
        
        private void getAllIssue()
        {
            ViewBag.LstAllIssues = new IssuesManagementBL().getAllIssueBL();
        }

    }
}