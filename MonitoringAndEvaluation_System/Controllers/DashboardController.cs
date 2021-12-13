using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class DashboardController : Controller
    {
        UserManagementBL ObjuserMngBL = new UserManagementBL();
        // GET: Dashboard
        public ActionResult Admin()
        {
            return View();
        }






        public ActionResult Menus()
        {

            List<NavParentMenu> ParentLst = new List<NavParentMenu>(); //Parent
            List<NavChildMenu> ChildLst = new List<NavChildMenu>(); //Child
            List<NavSubChild> SubChildLst = new List<NavSubChild>(); //SubChild
            try
            {

                LoginReturnDataVM loginUserDataModel = (LoginReturnDataVM)Session["LoginUserData"];
                //ClsUsers user = (ClsUsers)HttpContext.Current.Session["LoginUserData"];
               
                ParentLst = ObjuserMngBL.getParentMenuBL(loginUserDataModel.RoleID); //Parent
                Session["NavMenus"] = ParentLst;

                ChildLst = ObjuserMngBL.getChildMenuBL(loginUserDataModel.RoleID); //Child
                Session["NavChildMenus"] = ChildLst;

                SubChildLst = ObjuserMngBL.getSubChildMenuBL(loginUserDataModel.RoleID); //SubChild  GetAll
                Session["NavSubChildMenus"] = SubChildLst;
               

            }
            catch (Exception ex)
            {

            }
            return PartialView("SideBar");
        }



    }
}