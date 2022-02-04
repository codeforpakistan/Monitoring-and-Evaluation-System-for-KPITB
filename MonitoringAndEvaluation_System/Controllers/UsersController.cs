using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Utility;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.NetworkInformation;

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
            

            //.Where(a.LoginDateTime > DateTime.Now.AddMinutes(-30))

            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

       

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM model)
        {
            try
            {
                if (model.Clicked == "Clicked")
                { 
                  LoginAttemptes login = new LoginAttemptes();
                    login.Email = model.Email;
                    login.Password = model.Password;
                    StatusModel s = ObjUserMngBL.userAttemptBL(login);  //Get UserLogin Data
                   if( s.status == false)
                     {
                        ShowMessage(MessageBox.Warning, OperationType.Warning, s.statusDetail);
                        goto errorreturn;
                     }
                }

                //model
                if (ModelState.IsValid == false)
                {
                    goto errorreturn;
                }

                #region LoginAttemps
                LoginReturnDataVM loginUserDataModel = ObjUserMngBL.userLoginBL(model);  //Get UserLogin Data
                #endregion

                
                if (loginUserDataModel != null)
                {
                    Session["LoginUser"] = loginUserDataModel;
                    Session["UserID"] = loginUserDataModel.UserID;
                    Session["RoleID"] = loginUserDataModel.RoleID;
                    Session["Email"] = loginUserDataModel.Email;
                    //FormsAuthentication.SetAuthCookie(loginUserDataModel.FullName, false);
                    return RedirectToAction("Admin", "Dashboard");
                }
                else
                {
                    ShowMessage(MessageBox.Error, OperationType.Error, "Invalid Credentials");
                    goto errorreturn;
                }
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Warning, OperationType.Warning, ex1.Message);
            }

            return RedirectToAction("Login", "Users");
            errorreturn: return View(model);

        }

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
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
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return View(userVM);
                }

                bool isExists = ObjUserMngBL.IsEmailExistsBL(userVM.Email);  //Check DuplicateEmail
                if (isExists)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "Email Already Exists");
                    return View(userVM);
                }
                StatusModel status = ObjUserMngBL.userCreateBL(userVM);
                if (status.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                }
                else
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, "User Not Created");
                }
            }
            catch (Exception ex1)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex1.Message);
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
                    ShowMessage(MessageBox.Success, OperationType.Saved, CommonMsg.SaveSuccessfully);
                    return View(userEditVM);
                }
                StatusModel status = ObjUserMngBL.userEditBL(userEditVM);
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
        #region JSON
        public JsonResult IsEmailExists(string _Email)
        {
            try
            {
                bool isExists = ObjUserMngBL.IsEmailExistsBL(_Email);
                if (isExists)
                {
                    return Json("true");
                }
                else
                {
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
        #endregion
    }
}