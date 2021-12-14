using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static ModelLayer.MainViewModel;

namespace MonitoringAndEvaluation_System.Controllers
{
    public class BaseController : Controller
    {
        public int LoginRoleID { get; set; }
        public int LoginUserID { get; set; }
        public string LoginEmail { get; set; }
        public string LoginFullName { get; set; }
        public string LoginMobileNo { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = Convert.ToString(filterContext.RouteData.Values["controller"]);
            string actionName = Convert.ToString(filterContext.RouteData.Values["action"]);
            string methodType = Convert.ToString(filterContext.HttpContext.Request.HttpMethod);

            object[] attributes = filterContext.ActionDescriptor.GetCustomAttributes(true);
            if (attributes.Any(a => a is AllowAnonymousAttribute))
                return;

            HttpSessionStateBase session = filterContext.HttpContext.Session;
            ////If the browser session or authentication session has expired...
            LoginReturnDataVM u = (LoginReturnDataVM) Session["LoginUser"];

            #region Session Permissions
            if (session.IsNewSession || u == null)
            {
                //For round-trip requests,
                filterContext.Result = new RedirectToRouteResult(
                                                                                                            new RouteValueDictionary {
                                                                                                                                                                    { "Controller", "Users" },
                                                                                                                                                                    { "Action", "Login" }
                                                                                                                                                              });
            }
            else
            {
                LoginUserID = Convert.ToInt32(u.UserID);
                LoginRoleID = Convert.ToInt32(u.RoleID);
                LoginEmail = Convert.ToString(u.Email);
                LoginFullName = Convert.ToString(u.FullName);
            }
            #endregion

            #region CheckPermissions
            #endregion

            base.OnActionExecuting(filterContext);
        }
    }
}