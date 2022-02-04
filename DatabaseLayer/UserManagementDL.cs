using Dapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.ComboModel;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;

namespace DatabaseLayer
{
    public static class UserManagementDL
    {
        //Main
        public static List<NavParentMenu> getParentMenuDL(int Role_ID)
        {
            List<NavParentMenu> NavParentLst = new List<NavParentMenu>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Role_ID", Role_ID);
                NavParentLst = conn.Query<NavParentMenu>("sp_GetAllNavParentMenu", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return NavParentLst;
            }
        }

        //Child
        public static List<NavChildMenu> getChildMenuDL(int Role_ID)
        {
            List<NavChildMenu> NavChildLst = new List<NavChildMenu>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Role_ID", Role_ID);
                NavChildLst = conn.Query<NavChildMenu>("sp_GetAllNavChildMenu", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return NavChildLst;
            }
        }

        //SubChild
        public static List<NavSubChild> getSubChildMenuDL(int Role_ID)
        {
            List<NavSubChild> NavSubLst = new List<NavSubChild>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Role_ID", Role_ID);
                NavSubLst = conn.Query<NavSubChild>("sp_GetAllNavSubChild",ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return NavSubLst;
            }
        }
        //User Role
        public static List<ComboRole> getRoleDL()
        {
            List<ComboRole> userRoleLst = new List<ComboRole>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                userRoleLst = conn.Query<ComboRole>("sp_GetAllUserRole", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return userRoleLst;
            }
        }
        public static LoginReturnDataVM userLoginDL(LoginVM m)
        {
            LoginReturnDataVM model = new LoginReturnDataVM();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Email", m.Email);
                ObjParm.Add("@Password", m.Password);
                model = Con.Query<LoginReturnDataVM>("sp_GetLoginData", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }
            return model;
        }

        public static StatusModel userAttemptDL(LoginAttemptes m)
        {
            LoginAttemptes model = new LoginAttemptes();
            StatusModel statusModel = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Email", m.Email);
                ObjParm.Add("@Password", m.Password);
                ObjParm.Add("@LoginCount", m.LoginCount);
                ObjParm.Add("@MACAddress", m.MACAddress);
                ObjParm.Add("@IPv4Address", m.IPv4Address);
                ObjParm.Add("@HostName", m.HostName);
                ObjParm.Add("@BrowserName", m.BrowserName);
                //ObjParm.Add("@EntryDateTime", m.EntryDateTime);
                //ObjParm.Add("@LoginDateTime", m.LoginDateTime);
                //ObjParm.Add("@NextLoginDateTime", m.NextLoginDateTime);
                //ObjParm.Add("@User_ID", m.User_ID);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);

                Con.Execute("usp_CheckLogin", ObjParm, commandType: CommandType.StoredProcedure);
                statusModel.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                statusModel.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }
            return statusModel;
        }

        public static bool IsEmailExistsDL(string Email)
        {
            bool isTrue = false;
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Email", Email);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_IsEmailExists", ObjParm, commandType: CommandType.StoredProcedure);

                status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                isTrue = status.status;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Close();
            }
            return isTrue;
        }

        public static StatusModel userCreateDL(CreateUserVM m)
            {
                StatusModel status = new StatusModel();
                IDbConnection Con = null;
                try
                {
                    Con = new SqlConnection(Common.ConnectionString);
                    Con.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                        
                        ObjParm.Add("@Role_ID", m.Role_ID);
                        ObjParm.Add("@FullName", m.FullName);
                        ObjParm.Add("@Email", m.Email);
                        ObjParm.Add("@ContactNo", m.ContactNo);
                        ObjParm.Add("@Password", Utility.Encryption.EncryptUser(m.Password));
                        //ObjParm.Add("@CNICNo", m.CNICNo);
                        //ObjParm.Add("@Photo", m.Photo);
                        ObjParm.Add("@ADDRESS", m.Address);
                        
                        ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                        ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                       Con.Execute("sp_userCreate", ObjParm, commandType: CommandType.StoredProcedure);

                       status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                       status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    Con.Close();
                }
            return status;
        }

        //UserEdit
        public static StatusModel userEditDL(EditUserVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@UserID", m.UserID);
                ObjParm.Add("@Role_ID", m.Role_ID);
                ObjParm.Add("@FullName", m.FullName);
                ObjParm.Add("@Email", m.Email);
                ObjParm.Add("@ContactNo", m.ContactNo);
                //ObjParm.Add("@Password", m.Password);
                //ObjParm.Add("@CNICNo", m.CNICNo);
                //ObjParm.Add("@Photo", m.Photo);
                ObjParm.Add("@ADDRESS", m.Address);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_userEdit", ObjParm, commandType: CommandType.StoredProcedure);

                status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Close();
            }
            return status;
        }
        public static EditUserVM getSignleUserDL(int UserID)
        {
            EditUserVM model = new EditUserVM();
            using (IDbConnection Con = new SqlConnection(Common.ConnectionString))
            {
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@UserID", UserID);
                model = Con.Query<EditUserVM>("sp_GetSingleUser", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Con.Close();
                Con.Dispose();
            }
            return model;
        }
        public static List<GetAllUserVM> getUserDL()
        {
            List<GetAllUserVM> userAllLst = new List<GetAllUserVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                userAllLst = conn.Query<GetAllUserVM>("sp_GetAllUser", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return userAllLst;
            }
        }

        public static List<RoleMapWithNavVM> getRoleVisibleWebPageDL(int Role_ID)
        {
            List<RoleMapWithNavVM> model = new List<RoleMapWithNavVM>();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Role_ID", Role_ID);
                model = Con.Query<RoleMapWithNavVM>("sp_GetRoleVisibleWebPage", ObjParm, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }
            return model;
        }

     
    }
}
