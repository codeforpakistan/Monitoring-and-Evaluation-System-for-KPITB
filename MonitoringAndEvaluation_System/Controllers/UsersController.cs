﻿using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        UserManagementBL ObjUserMngBL = new UserManagementBL();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM model)
        {
            try
            {
                //model
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                LoginReturnDataVM loginUserDataModel =  ObjUserMngBL.userLoginBL(model);  //Get UserLogin Data
                if (loginUserDataModel != null)
                {
                    Session["LoginUser"] = loginUserDataModel;
                    Session["UserID"] = loginUserDataModel.UserID;
                    Session["RoleID"] = loginUserDataModel.RoleID;
                    Session["Email"] = loginUserDataModel.Email;
                    FormsAuthentication.SetAuthCookie(loginUserDataModel.FullName, false);
                    ModelState.AddModelError(string.Empty, "User Created Successfully");
                    return RedirectToAction("Admin", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credentials");
                    return View(model);
                }
            }
            catch (Exception ex1)
            {
            }
            //return RedirectToAction("UserCreate");
            return RedirectToAction("Login", "Users");

        }


        [HttpGet]
        public ActionResult UserCreate()
        {
            CreateUserVM userVM = new CreateUserVM();
            userVM.comboRoles = ObjUserMngBL.getRoleBL();
            return View(userVM);
        }
        [HttpPost]
        public ActionResult UserCreate(CreateUserVM userVM)
        {
            try
            {
                userVM.comboRoles = ObjUserMngBL.getRoleBL();
                if (ModelState.IsValid == false)
                {
                    return View(userVM);
                }
                StatusModel status = ObjUserMngBL.userCreateBL(userVM);
                    if (status.status)
                    {
                      TempData["Message"] = "Record Saved Successfully.";
                    }
                    else
                    {
                      
                    }
                  
            }
            catch (Exception ex1)
            {
            }
            return RedirectToAction("UserView");
        }
        [HttpGet]
        public ActionResult UserEdit(int UserID)
        {
            EditUserVM getUser = new EditUserVM();
            try
            {
                getUser = new UserManagementBL().getSignleUserBL(UserID);
                getAllRoles();
                getUser.comboRoles = (List<ComboModel.ComboRole>)ViewBag.LstAllRoles;
            }

            catch (Exception)
            {
            }
           
            return View(getUser);
        }
        [HttpPost]
        public ActionResult UserEdit(EditUserVM userEditVM)
        {
            try
            {
                userEditVM.comboRoles = ObjUserMngBL.getRoleBL();
                if (ModelState.IsValid == false)
                {
                    return View(userEditVM);
                }
                StatusModel status = ObjUserMngBL.userEditBL(userEditVM);
                if (status.status)
                {
                    TempData["Message"] = "Record Saved Successfully.";
                }
                else
                {

                }

            }
            catch (Exception ex1)
            {
            }
            return RedirectToAction("UserView");
        }
        public ActionResult UserView()
        {
            @ViewBag.MainTitle = "Category List";
            List<GetAllUserVM> lst = new UserManagementBL().getAllUserBL();
            return View(lst);
        }

        #region CUSTOM_FUNCATION
        private void getAllRoles()
        {
            
            ViewBag.LstAllRoles = ObjUserMngBL.getRoleBL();
        
        }
        #endregion

    }
}