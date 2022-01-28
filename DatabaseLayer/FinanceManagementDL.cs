using Dapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.MainViewModel;

namespace DatabaseLayer
{
    public class FinanceManagementDL
    {
        #region Finance
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
                ObjParm.Add("@ReleasedFromDate", m.ReleasedFromDate);
                ObjParm.Add("@ReleasedToDate", m.ReleasedToDate);
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
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Project_ID", m.Project_ID);
                ObjParm.Add("@SubProject_ID", m.SubProject_ID);
                ObjParm.Add("@Batch_ID", m.Batch_ID);
                ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);
                ObjParm.Add("@ExpenditureFromDate", m.ExpenditureFromDate);
                ObjParm.Add("@ExpenditureToDate", m.ExpenditureToDate);
                ObjParm.Add("@ExpenditureBudget", m.ExpenditureBudget);
                ObjParm.Add("@Remarks", m.Remarks);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_ExpenditureBudgetCreate", ObjParm, commandType: CommandType.StoredProcedure);

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
                getAllReleasedBudgetVMLst = conn.Query<GetAllReleasedBudgetVM>("sp_GetAllReleasedBudget", ObjParm,commandType: CommandType.StoredProcedure).ToList();
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
        #endregion
    }
}
