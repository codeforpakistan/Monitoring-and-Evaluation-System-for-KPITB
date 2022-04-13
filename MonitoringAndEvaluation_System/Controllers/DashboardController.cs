
using BusinessLayer;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;
using static ModelLayer.StoreProcModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class DashboardController : BaseController
    {
        UserManagementBL ObjuserMngBL = new UserManagementBL();
        // GET: Dashboard
        public ActionResult Admin()
        {
            Dashboardv1 Dashboardv1Charts = Dashboard.dashboardv1DL();
            return View(Dashboardv1Charts);
        }




        public ActionResult Menus()
        {
            #region NEW

            ClsUserRole cls = new RoleManagementBL().getUserRolePagesByIDBL(LoginRoleID);
            cls.AllWebPages= cls.AllWebPages.Where(x => x.IsChecked == true).ToList();
            Session["WebPagesMenu"] = cls;
            #endregion
            #region OLD
            //List<NavParentMenu> ParentLst = new List<NavParentMenu>(); //Parent
            //List<NavChildMenu> ChildLst = new List<NavChildMenu>(); //Child
            //List<NavSubChild> SubChildLst = new List<NavSubChild>(); //SubChild
            //try
            //{

            //    LoginReturnDataVM loginUserDataModel = (LoginReturnDataVM)Session["LoginUser"];// Session["LoginUserData"];
            //                                                                                   //ClsUsers user = (ClsUsers)HttpContext.Current.Session["LoginUserData"];

            //    ParentLst = ObjuserMngBL.getParentMenuBL(loginUserDataModel.RoleID); //Parent
            //    Session["NavMenus"] = ParentLst;

            //    ChildLst = ObjuserMngBL.getChildMenuBL(loginUserDataModel.RoleID); //Child
            //    Session["NavChildMenus"] = ChildLst;

            //    SubChildLst = ObjuserMngBL.getSubChildMenuBL(loginUserDataModel.RoleID); //SubChild  GetAll
            //    Session["NavSubChildMenus"] = SubChildLst;


            //}
            //catch (Exception ex)
            //{

            //} 
            #endregion
            return PartialView("SideBar");
        }



    }
}