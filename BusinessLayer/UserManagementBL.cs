
using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using static ModelLayer.ComboModel;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class UserManagementBL
    {

        //Main
        public List<NavParentMenu> getParentMenuBL(int Role_ID)
        {
            return UserManagementDL.getParentMenuDL(Role_ID);
        }

        //Child
        public List<NavChildMenu> getChildMenuBL(int Role_ID)
        {
            return UserManagementDL.getChildMenuDL(Role_ID);
        }

        //SubChild
        public List<NavSubChild> getSubChildMenuBL(int Role_ID)
        {
            return UserManagementDL.getSubChildMenuDL(Role_ID);
        }
        //GetLoginRole
        public List<RoleMapWithNavVM> getRoleVisibleWebPageBL(int Role_ID)
        {
            return UserManagementDL.getRoleVisibleWebPageDL(Role_ID);
        }

        //UserRole
        public List<ComboRole> getRoleBL()
        {
            return UserManagementDL.getRoleDL();
        }

        //UserCreate
        public bool IsEmailExistsBL(string Email)
        {
            return UserManagementDL.IsEmailExistsDL(Email);
        }
        public StatusModel userCreateBL(CreateUserVM m)
        {
            return UserManagementDL.userCreateDL(m);
        }
        public StatusModel userEditBL(EditUserVM m)
        {
            return UserManagementDL.userEditDL(m);
        }
        //GetSingleUser For Edit
        public EditUserVM getSignleUserBL(int UserID)
        {
            EditUserVM m = UserManagementDL.getSignleUserDL(UserID);
            return m;
        }
        //GetAllUser
        public List<GetAllUserVM> getAllUserBL()
        {
            return UserManagementDL.getUserDL();
        }
        //UserLogin
        public LoginReturnDataVM userLoginBL(LoginVM m, LoginAttemptes login)
        {
            return UserManagementDL.userLoginDL(m, login);
        }
        //UserLoginAttempts
        public StatusModel userAttemptBL(LoginAttemptes login)
        {
            
            HttpRequest req = System.Web.HttpContext.Current.Request;
            login.BrowserName = req.Browser.Browser; //Browser
            login.HostName = Dns.GetHostName(); //System_Name
            login.IPv4Address = Dns.GetHostByName(login.HostName).AddressList[0].ToString();// System_IP
            login.MACAddress = GetMACAddress();//MAC_Address
            return UserManagementDL.userAttemptDL(login);
        }
        private string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String MacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (MacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    MacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return MacAddress;
        }


    }
}
