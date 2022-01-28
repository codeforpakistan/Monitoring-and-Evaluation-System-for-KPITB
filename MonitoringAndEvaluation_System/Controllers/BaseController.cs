using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
          Log("OnActionExecuted", filterContext.RouteData);
        }
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }

        public void ShowMessage(MessageBox MessageType, OperationType opertaion, string Message)
        {
            TempData["Opertaion"] = opertaion;
            TempData["Message"] = Message;
            switch (MessageType)
            {
                case MessageBox.Success: //Green
                    TempData["CssClass"] = "alert alert-success alert-dismissible";
                    TempData["CssIcon"] = "icon fa fa-check";
                    break;
                case MessageBox.Error:  //Red
                    TempData["CssClass"] = "alert alert-danger alert-dismissible";
                    TempData["CssIcon"] = "icon fa fa-ban";
                    break;
                case MessageBox.Warning:   //Yellow
                    TempData["CssClass"] = "alert alert-warning alert-dismissible";
                    TempData["CssIcon"] = "icon fa fa-warning";
                    break;
                case MessageBox.Info: //Gray
                    TempData["CssClass"] = "alert alert-warning alert-dismissible";
                    TempData["CssIcon"] = "icon fa fa-warning";
                    break;
                default:
                    TempData["CssClass"] = "alert alert-info alert-dismissible";
                    TempData["CssIcon"] = "icon fa fa-info";
                    break;
            }
        }

        public enum OperationType
        {
            Saved = 1,
            Updated = 2,
            Error = 3,
            Warning = 4,
            Deleted = 5
        }
        public enum MessageBox
        {
            Success = 1,
            Error = 2,
            Warning = 3,
             Info = 4
        }


       

    }
}