using Dapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ModelLayer.MainViewModel;

namespace DatabaseLayer
{
    public class RoleManagementDL
    {

        public static ClsUserRole getUserRolePagesByIDDL(int RoleID)
        {
            ClsUserRole mdl = new ClsUserRole();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Role_ID", RoleID);
                using (var multi = Con.QueryMultiple("Users_GetUserRolePagesByID", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    var allWebPages = multi.Read<ClsWebPages>().ToList();
                    mdl.AllWebPages = allWebPages;
                    var Roledata = multi.Read<ClsUserRole>().FirstOrDefault();
                    if (Roledata != null) {
                        mdl.RoleID = Roledata.RoleID;
                        mdl.RoleName = Roledata.RoleName;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Close();
            }
            return mdl;
        }

        public static StatusModel SaveRoleDL(DataTable dt)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@udt_BulkEntry", dt.AsTableValuedParameter("udt_BulkEntry"));

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_RoleMapWithWebPageMulti", ObjParm, commandType: CommandType.StoredProcedure);

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
        public static StatusModel UpdateRoleDL(DataTable dt,int RoleID)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@RoleID", RoleID);
                ObjParm.Add("@udt_BulkEntry", dt.AsTableValuedParameter("udt_BulkEntry"));

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_UpdateRoleMapWithWebPageMulti1", ObjParm, commandType: CommandType.StoredProcedure);

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

        public static StatusModel InsertRoleOnlyDL(ClsUserRole Role, out int RoleID)
        {
            RoleID = 0;
            StatusModel statusmodel = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@RoleName", Role.RoleName);

                ObjParm.Add("@RoleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_roleCreateOnly", ObjParm, commandType: CommandType.StoredProcedure);

                RoleID = Convert.ToInt32(ObjParm.Get<int>("@RoleID"));
                statusmodel.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                statusmodel.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Close();

            }
            return statusmodel;
        }
        public static StatusModel UpdateRoleOnlyDL(ClsUserRole Role)
        {
            StatusModel statusmodel = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@RoleID", Role.RoleID);
                ObjParm.Add("@RoleName", Role.RoleName);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_roleUpdateOnly", ObjParm, commandType: CommandType.StoredProcedure);

                statusmodel.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                statusmodel.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Close();

            }
            return statusmodel;
        }

















        public static StatusModel roleCreateDL(CreateRoleVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {

                using (TransactionScope transactionScope = new TransactionScope())
                {

                    Con = new SqlConnection(Common.ConnectionString);
                    Con.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@RoleName", m.RoleName);

                    ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    ObjParm.Add("@RoleID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    Con.Execute("sp_roleCreate", ObjParm, commandType: CommandType.StoredProcedure);

                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    m.RoleID = Convert.ToInt32(ObjParm.Get<int>("@RoleID"));

                    Con.Close();


                    #region AssignToRoleMap

                    SqlConnection conn = null;
                    SqlCommand cmd = null;
                    conn = new SqlConnection(Common.ConnectionString);
                    cmd = new SqlCommand("sp_RoleIdInsertAfterRoleCreationMulti", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    List<RolePermissionTempVM> _lst = new List<RolePermissionTempVM>();
                    for (int i = 0; i < getRolePermissionDL().Count; i++)
                    {
                        RolePermissionTempVM mm = new RolePermissionTempVM();
                        mm.NavParent_ID = getRolePermissionDL()[i].ParentMenuID;
                        mm.ParentIsVisible = getRolePermissionDL()[i].HasParent;
                        mm.NavChild_ID = getRolePermissionDL()[i].ChildMenuID;
                        mm.ChildIsVisible = getRolePermissionDL()[i].HasChild;
                        mm.NavSubChild_ID = getRolePermissionDL()[i].SubChildMenuID;
                        mm.SubChildIsVisible = getRolePermissionDL()[i].HasSubChild;
                        _lst.Add(mm);
                    }


                    DataTable dt = Utility.Conversion.ConvertListToDataTable(_lst);
                    cmd.Parameters.AddWithValue("@Role_ID", m.RoleID);
                    cmd.Parameters.AddWithValue("@TempTblRoleMap", dt).SqlDbType = SqlDbType.Structured;

                    conn.Open();
                    int isInserted = cmd.ExecuteNonQuery();
                    conn.Close();

                    #endregion
                    transactionScope.Complete();
                    transactionScope.Dispose();
                }

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

        public static StatusModel roleEditDL(EditRoleVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@RoleID", m.RoleID);
                ObjParm.Add("@RoleName", m.RoleName);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_RoleEdit", ObjParm, commandType: CommandType.StoredProcedure);
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
        public static List<GetAllRoleVM> getRoleDL()
        {
            List<GetAllRoleVM> userRoleLst = new List<GetAllRoleVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                userRoleLst = conn.Query<GetAllRoleVM>("sp_GetAllRole", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return userRoleLst;
            }
        }
        //Get SingleRoleByID 
        public static EditRoleVM getSignleRoleDL(int RoleID)
        {
            EditRoleVM model = new EditRoleVM();
            using (IDbConnection Con = new SqlConnection(Common.ConnectionString))
            {
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@RoleID", RoleID);
                model = Con.Query<EditRoleVM>("sp_GetSingleRole", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Con.Close();
                Con.Dispose();
            }
            return model;
        }

        public static List<RolePermissionVM> getRoleBasePermissionComboDL(int RoleID)
        {
            List<RolePermissionVM> PermissionLst = new List<RolePermissionVM>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(Common.ConnectionString);

                cmd = new SqlCommand("sp_getRoleBasePermissionCombo", conn);
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    RolePermissionVM p = new RolePermissionVM();
                    p.ParentMenuID = Convert.ToInt32(dr["NavParentMenuID"]);
                    p.ParentMenuName = Convert.ToString(dr["NavParentMenuTitle"]);
                    p.ChildMenuID = Convert.ToInt32(dr["NavChildMenuID"]);
                    p.ChildMenuName = Convert.ToString(dr["ChildMenuName"]);
                    p.SubChildMenuID = Convert.ToInt32(dr["NavSubChildID"]);
                    p.SubChildName = Convert.ToString(dr["NavSubChildName"]);
                    p.HasParent = Convert.ToBoolean(dr["HasParent"]);
                    p.HasChild = Convert.ToBoolean(dr["HasChild"]);
                    p.HasSubChild = Convert.ToBoolean(dr["HasSubChild"]);
                    PermissionLst.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
            return PermissionLst;
        }

        public static List<RolePermissionVM> getRolePermissionDL()
        {
            List<RolePermissionVM> PermissionLst = new List<RolePermissionVM>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(Common.ConnectionString);
                cmd = new SqlCommand("sp_getRolePermission", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                //DataView view = new DataView(dt);
                //DataTable distinctValues = view.ToTable(true, "NavChildMenu_ID", "ChildMenuName");

                foreach (DataRow dr in dt.Rows)
                {
                    RolePermissionVM p = new RolePermissionVM();
                    p.ParentMenuID = Convert.ToInt32(dr["NavParentMenuID"]);
                    p.ParentMenuName = Convert.ToString(dr["NavParentMenuTitle"]);
                    p.ChildMenuID = Convert.ToInt32(dr["NavChildMenuID"]);
                    p.ChildMenuName = Convert.ToString(dr["ChildMenuName"]);
                    p.SubChildMenuID = Convert.ToInt32(dr["NavSubChildID"]);
                    p.SubChildName = Convert.ToString(dr["NavSubChildName"]);
                    p.HasParent = Convert.ToBoolean(dr["HasParent"]);
                    p.HasChild = Convert.ToBoolean(dr["HasChild"]);
                    p.HasSubChild = Convert.ToBoolean(dr["HasSubChild"]);
                    PermissionLst.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
            return PermissionLst;
        }

        public static StatusModel addUpdateRolePermissionDL(RolePermissionWithRolVM rolePermission)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);

                foreach (var item in rolePermission.LstRolePermission)
                {
                    Con.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@RoleID", rolePermission.RoleID);
                    ObjParm.Add("@NavParent_ID", item.ParentMenuID);
                    ObjParm.Add("@ParentIsVisible", item.HasParent);
                    ObjParm.Add("@NavChild_ID", item.ChildMenuID);
                    ObjParm.Add("@ChildIsVisible", item.HasChild);
                    ObjParm.Add("@NavSubChild_ID", item.SubChildMenuID);
                    ObjParm.Add("@SubChildIsVisible", item.HasSubChild);
                    Con.Execute("sp_AddUdateRolePermssion", ObjParm, commandType: CommandType.StoredProcedure);
                    Con.Close();
                }
                status.status = true;
                status.statusDetail = "Role Permission Successfully Generated.";
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Dispose();
            }
            return status;
        }


    }
}
