using Dapper;
using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DatabaseLayer.UserManagementDL;
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
        public LoginReturnDataVM userLoginBL(LoginVM m)
        {
            return UserManagementDL.userLoginDL(m);
        }
    }
}
