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
    public class FinanceManagementDL
    {
        
        //ComparePlanned_BudgetDL
        public static StatusModel ComparePlanned_BudgetDL(int _ProjectID, out int ApprovedBudget, out int ReleasedBudget)
        {
            ApprovedBudget = 0;
            ReleasedBudget = 0;

            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@ProjectID", _ProjectID);
                ObjParm.Add("@ApprovedBudget", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ObjParm.Add("@ReleasedBudget", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_CompareApprovedBudget_With_ReleasedBudget", ObjParm, commandType: CommandType.StoredProcedure);

                ApprovedBudget = Convert.ToInt32(ObjParm.Get<int>("@ApprovedBudget"));
                ReleasedBudget = Convert.ToInt32(ObjParm.Get<int>("@ReleasedBudget"));
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
        //ComparePlanned_BudgetDL
        public static StatusModel CompareReleased_ExpenditureDL(int _ProjectID, out int ReleasedBudget, out int ExpenditureBudget)
        {

            ReleasedBudget = 0;
            ExpenditureBudget = 0;

            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@ProjectID", _ProjectID);
                ObjParm.Add("@ReleasedBudget", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ObjParm.Add("@ExpenditureBudget", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_CompareReleasedBudget_With_ExpenditureBudget", ObjParm, commandType: CommandType.StoredProcedure);

                ReleasedBudget = Convert.ToInt32(ObjParm.Get<int>("@ReleasedBudget"));
                ExpenditureBudget = Convert.ToInt32(ObjParm.Get<int>("@ExpenditureBudget"));
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
        public static StatusModel releasedCreateViewDL(CreateViewReleasedBudgetVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Project_ID", m.Project_ID);
                ObjParm.Add("@SubProject_ID", m.SubProject_ID);
                ObjParm.Add("@Batch_ID", m.Batch_ID);
                ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);
                ObjParm.Add("@ReleasedBudget", m.ReleasedBudget);
                ObjParm.Add("@ReleasedDate", m.ReleasedDate);
                ObjParm.Add("@Remarks", m.Remarks);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_ReleasedBudgetCreate", ObjParm, commandType: CommandType.StoredProcedure);

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
        //GetSingleIssue
        public static EditReleasedBudgetVM getSignleReleasedBudgetDL(int ReleasedBudgetID)
        {
            EditReleasedBudgetVM model = new EditReleasedBudgetVM();
            using (IDbConnection Con = new SqlConnection(Common.ConnectionString))
            {
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ReleasedBudgetID", ReleasedBudgetID);
                model = Con.Query<EditReleasedBudgetVM>("sp_GetSingleReleasedBudget", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Con.Close();
                Con.Dispose();
            }
            return model;
        }
        public static StatusModel expenditureCreateViewDL(CreateViewExpenditureBudgetVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;


            SqlConnection conn = null;
            SqlCommand cmd = null;

            int Project_ID = 0;

            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    //Con = new SqlConnection(Common.ConnectionString);
                    //Con.Open();
                    //DynamicParameters ObjParm = new DynamicParameters();
                    ////LoginUser
                    //ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);   //LoginUser
                    //ObjParm.Add("@Project_ID", m.Project_ID);
                    //ObjParm.Add("@SubProject_ID", m.SubProject_ID);
                    //ObjParm.Add("@Batch_ID", m.Batch_ID);
                    
                    //ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    //ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    //ObjParm.Add("@Project_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);


                    //Con.Execute("sp_ProjectCeate", ObjParm, commandType: CommandType.StoredProcedure);

                    //status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    //status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    //Project_ID = Convert.ToInt32(ObjParm.Get<Int32>("@Project_ID"));
                    //Con.Close();

                    #region NO
                    
                    conn = new SqlConnection(Common.ConnectionString);
                    cmd = new SqlCommand("sp_ExpenditureCreateMulti", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var _AssignExpenditureList = m.AssignExpenditureList.Select(p => new {p.Project_ID,p.SubProject_ID, p.Batch_ID,p.ExpenditureDate, p.BudgetHead, p.ApprovedCost,p.ExpenditureBudget, p.CreatedByUser_ID }).ToList();
                    
                    if (_AssignExpenditureList.Count > 0)
                    {
                        DataTable dt = Utility.Conversion.ConvertListToDataTable(_AssignExpenditureList);
                        cmd.Parameters.AddWithValue("@ExpenditureTable", dt).SqlDbType = SqlDbType.Structured;

                        SqlParameter _StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                        _StatusParm.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(_StatusParm);
                        SqlParameter _StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 100);
                        _StatusDetailsParm.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(_StatusDetailsParm);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        status.status = (bool)_StatusParm.Value;
                        status.statusDetail = (string)_StatusDetailsParm.Value;
                    }

                   
                    conn.Dispose();
                    cmd.Dispose();

                    transactionScope.Complete();
                    transactionScope.Dispose();
                }
            }
            catch (Exception ex)
            {
                status.status = false;
                status.statusDetail = ex.Message;

            }
            finally
            {

            }
#endregion
            return status;
        }
        //public static StatusModel expenditureCreateViewDL(DataTable  dt)
        //{

        //    StatusModel status = new StatusModel();
        //    IDbConnection Con = null;
        //    try
        //    {
        //        Con = new SqlConnection(Common.ConnectionString);
        //        Con.Open();

        //        DynamicParameters ObjParm = new DynamicParameters();
        //        ObjParm.Add("@ExpenditureTable", dt.AsTableValuedParameter("udt_ExpenditureBuget"));
        //        ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
        //        ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
        //        Con.Execute("sp_ExpenditureCreateMulti", ObjParm, commandType: CommandType.StoredProcedure);

        //        status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
        //        status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //        Con.Close();
        //    }
        //    return status;


        //    //StatusModel status = new StatusModel();
        //    //IDbConnection Con = null;

        //    //bool _Status = false;
        //    //string _StatusDetails = null;

        //    //SqlConnection conn = null;
        //    //SqlCommand cmd = null;

        //    //int Project_ID = 0;

        //    //try
        //    //{
        //    //    using (TransactionScope transactionScope = new TransactionScope())
        //    //    {
        //    //        //Con = new SqlConnection(Common.ConnectionString);
        //    //        //Con.Open();
        //    //        //DynamicParameters ObjParm = new DynamicParameters();
        //    //        ////LoginUser

        //    //        //ObjParm.Add("@RecruitedHRDate", DateTime.Now);
        //    //        //ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
        //    //        //ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
        //    //        //ObjParm.Add("@Project_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

        //    //        //Con.Execute("sp_ProjectCeate", ObjParm, commandType: CommandType.StoredProcedure);

        //    //        //status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
        //    //        //status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
        //    //        //Project_ID = Convert.ToInt32(ObjParm.Get<Int32>("@Project_ID"));
        //    //        //Con.Close();

        //    //        conn = new SqlConnection(Common.ConnectionString);
        //    //        cmd = new SqlCommand("sp_ExpenditureCreateMulti", conn);
        //    //        cmd.CommandType = CommandType.StoredProcedure;
        //    //        m.ExpenditureDate = DateTime.Now;

        //    //        var _AssignExpenditureList = m.AssignExpenditureList.Select(p => new { Project_ID, p.SubProject_ID, p.Batch_ID,p.ExpenditureDate ,p.BudgetHead, p.ApprovedCost, p.ExpenditureBudget, p.CreatedByUser_ID }).ToList();
        //    //        if (_AssignExpenditureList.Count > 0)
        //    //        {
        //    //            DataTable dt = Utility.Conversion.ConvertListToDataTable(_AssignExpenditureList);
        //    //            cmd.Parameters.AddWithValue("@ExpenditureTable", dt).SqlDbType = SqlDbType.Structured;

        //    //            SqlParameter _StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
        //    //            _StatusParm.Direction = ParameterDirection.Output;
        //    //            cmd.Parameters.Add(_StatusParm);
        //    //            SqlParameter _StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 100);
        //    //            _StatusDetailsParm.Direction = ParameterDirection.Output;
        //    //            cmd.Parameters.Add(_StatusDetailsParm);

        //    //            conn.Open();
        //    //            cmd.ExecuteNonQuery();
        //    //            conn.Close();

        //    //            _Status = (bool)_StatusParm.Value;
        //    //            _StatusDetails = (string)_StatusDetailsParm.Value;
        //    //        }
        //    //        conn.Dispose();
        //    //        cmd.Dispose();

        //    //        transactionScope.Complete();
        //    //        transactionScope.Dispose();
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    _Status = false;
        //    //    _StatusDetails = ex.Message;

        //    //}
        //    //finally
        //    //{

        //    //}
        //   #endregion
        //    //return status;
        //}
        //GetALLFinance
        public static List<GetAllReleasedBudgetVM> getAllReleasedBudgetDL(int LoginRoleID, int LoginUserID)
        {
            List<GetAllReleasedBudgetVM> getAllReleasedBudgetVMLst = new List<GetAllReleasedBudgetVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", LoginRoleID);
                ObjParm.Add("@LoginUserID", LoginUserID);
                getAllReleasedBudgetVMLst = conn.Query<GetAllReleasedBudgetVM>("sp_GetAllReleasedBudget", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllReleasedBudgetVMLst;
            }
        }
        public static List<GetAllExpenditureBudgetVM> getAllExpenditureBudgetDL(int LoginRoleID, int LoginUserID)
        {
            List<GetAllExpenditureBudgetVM> getAllExpenditureBudgetVMLst = new List<GetAllExpenditureBudgetVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", LoginRoleID);
                ObjParm.Add("@LoginUserID", LoginUserID);
                getAllExpenditureBudgetVMLst = conn.Query<GetAllExpenditureBudgetVM>("sp_GetAllExpenditureBudget", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllExpenditureBudgetVMLst;
            }
        }


    }
}
