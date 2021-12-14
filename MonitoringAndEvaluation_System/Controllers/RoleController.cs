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
    public class RoleController : Controller
    {

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
                    return View(roleVM);
                }

                StatusModel status = new RoleManagementBL().roleCreateBL(roleVM);
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
            getAllRoles();
            return RedirectToAction("RoleCreateView");
        }


        [HttpGet]
        public ActionResult RoleEdit(int RoleID)
        {
            EditRoleVM getRole = new EditRoleVM();
            try
            {
                 getRole = new RoleManagementBL().getSignleRoleBL(RoleID);
            }
            catch (Exception)
            {
            }

            return View(getRole);
        }
        [HttpPost]
        public ActionResult RoleEdit(EditRoleVM editRoleVM)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(editRoleVM);
                }

                StatusModel status = new RoleManagementBL().roleEditBL(editRoleVM);
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
            getAllRoles();
            return RedirectToAction("RoleCreateView");
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
        public ActionResult RolePermissions(RolePermissionWithRolVM permissionWithRolVM)
        {
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