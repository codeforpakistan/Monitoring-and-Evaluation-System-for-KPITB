
using BusinessLayer;
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
    public class RoleController : BaseController
    {

        [HttpGet]
        public ActionResult CreateRole()
        {
            ClsUserRole cls = new RoleManagementBL().getUserRolePagesByIDBL(0);
            return View(cls);
        }

        [HttpPost]
        public ActionResult SaveRole(List<ClsWebPages> activies, ClsUserRole role)
        {
            StatusModel statusModel = new StatusModel();
            try
            {
                 statusModel = new RoleManagementBL().SaveRoleBL(activies, role, LoginUserID);
                if (statusModel.status)
                {
                    ShowMessage(MessageBox.Success, OperationType.Saved, statusModel.statusDetail);
                }
                else
                {
                    ShowMessage(MessageBox.Error, OperationType.Error, statusModel.statusDetail);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageBox.Error, OperationType.Error, ex.Message);
            }
            return Json(statusModel, JsonRequestBehavior.AllowGet);
        }












        [HttpGet]
        public ActionResult RoleCreateView()
        {
            CreateRoleVM roleVM = new CreateRoleVM();
            getAllRoles();
            TempData["Message"] = null;
            return View(roleVM);
        }
        [HttpPost]
        public ActionResult RoleCreateView(CreateRoleVM roleVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    ShowMessage(MessageBox.Warning, OperationType.Warning, CommonMsg.Fill_Fields);
                    return View(roleVM);
                }

                StatusModel status = new RoleManagementBL().roleCreateBL(roleVM);
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
            getAllRoles();
            return RedirectToAction("RoleCreateView");
        }


        [HttpGet]
        public ActionResult RoleEdit(string RoleID)
        {

            ClsUserRole cls = new ClsUserRole();
            try
            {
                cls = new RoleManagementBL().getUserRolePagesByIDBL(Convert.ToInt32(Utility.Encryption.DecryptURL(RoleID)));
            }
            catch (Exception ex)
            {
            }
            return View(cls);
        }
        [HttpPost]
        public ActionResult RoleEdit(List<ClsWebPages> activies, ClsUserRole role)
        {
            StatusModel statusModel = new StatusModel();
            try
            {
                role .RoleID =Utility.Encryption.DecryptURL(role.RoleID);
                statusModel = new RoleManagementBL().UpdateRoleBL(activies, role);
                if (statusModel.status)
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
            return Json(statusModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RolePermission()
        {
            try
            {
                List<RolePermissionVM> LISTRolePermission = new RoleManagementBL().getRolePermissionBL();
                RolePermissionWithRolVM LISTRolePermissionWithRole = new RolePermissionWithRolVM();
                LISTRolePermissionWithRole.LstRolePermission = LISTRolePermission;
                return View(LISTRolePermissionWithRole);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetRoleBasePermissionCombo(int RoleID)
        {
            try
            {
                List<RolePermissionVM> LISTRolePermission = new RoleManagementBL().getRoleBasePermissionComboBL(RoleID);  //Get from Database
                RolePermissionWithRolVM LISTRolePermissionWithRole = new RolePermissionWithRolVM();

                LISTRolePermissionWithRole.comboRole = new UserManagementBL() .getRoleBL();  //RoleCombo
                LISTRolePermissionWithRole.LstRolePermission = LISTRolePermission;   //Role List
                return View("~/Views/Role/RolePermissions.cshtml", LISTRolePermissionWithRole);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult RolePermissions()
        {
            try
            {
                List<RolePermissionVM> LISTRolePermission = new RoleManagementBL().getRolePermissionBL();  //Get from Database
                RolePermissionWithRolVM LISTRolePermissionWithRole = new RolePermissionWithRolVM();

                LISTRolePermissionWithRole.comboRole = new UserManagementBL().getRoleBL();  //RoleCombo
                LISTRolePermissionWithRole.LstRolePermission = LISTRolePermission;   //Role List
                return View(LISTRolePermissionWithRole);
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult RolePermissions(RolePermissionWithRolVM permissionWithRolVM, FormCollection icollections)
        {
            //string[] deletedrows = Convert.ToString(icollections["RolePermissionVM"]).Split(',');
            string[] D1 = Convert.ToString(icollections["LstRolePermission[1].ChildMenuID"]).Split(',');
            string[] D2 = Convert.ToString(icollections["LstRolePermission[2].IsChecked"]).Split(',');
            string[] D3 = Convert.ToString(icollections["LstRolePermission[1002].SubChildMenuID"]).Split(',');
            string[] D4 = Convert.ToString(icollections["LstRolePermission[2].IsChecked"]).Split(',');
            string[] D5 = Convert.ToString(icollections["LstRolePermission[innerloop].HasSubChild"]).Split(',');
            //LstRolePermission = null


            try
            {
                #region StatusCode
                RolePermissionVM m1 = new RolePermissionVM{
                    SubChildMenuID = 1001, HasSubChild = true,
                    ChildMenuID = 101, HasChild  = false,
                    ParentMenuID = 1, HasParent  = false
                };
                List<RolePermissionVM> lstM = new List<RolePermissionVM>();
                lstM.Add(m1);
                permissionWithRolVM.LstRolePermission = lstM;
                permissionWithRolVM.RoleID = 3;
                #endregion

                //var a = permissionWithRolVM.LstRolePermission.Where(w => w.HasSubChild == true).ToList();
                //List<RolePermissionVM> result = permissionWithRolVM.LstRolePermission.Select(i =>
                //{
                //    if (i.HasSubChild == true)
                //    {
                //        i.HasChild = true;
                //        i.HasParent = true;
                //    }

                //    return i;
                //}).ToList();
                StatusModel statusModel = new RoleManagementBL().addUpdateRolePermissionBL(permissionWithRolVM);


                List<RolePermissionVM> LISTRolePermission = new RoleManagementBL().getRolePermissionBL();
                RolePermissionWithRolVM LISTRolePermissionWithRole = new RolePermissionWithRolVM();
                LISTRolePermissionWithRole.LstRolePermission = LISTRolePermission;
                return RedirectToAction("RolePermissions");
            }
            catch (Exception ex)
            {
                return View();
            }
        }



        #region CUSTOM_FUNCATION
        private void getAllRoles()
        {
            ViewBag.LstAllRoles = new  RoleManagementBL().getAllroleBL();
       }
        #endregion
    }
}