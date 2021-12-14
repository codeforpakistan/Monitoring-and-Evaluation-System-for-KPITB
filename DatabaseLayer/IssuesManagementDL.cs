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
    public static class IssuesManagementDL
    {
        //IssuesCreate
        public static StatusModel issuesCreateDL(CreateIssueVM m)
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
                ObjParm.Add("@IssueDescription", m.IssueDescription);
                ObjParm.Add("@IssueDate", m.IssueDate);
                ObjParm.Add("@ActionTaken", m.ActionTaken);
                ObjParm.Add("@Remarks", m.Remarks);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_IssueCreate", ObjParm, commandType: CommandType.StoredProcedure);

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

        //GetALLIssues
        public static List<GetAllIssue> getIssueDL()
        {
            List<GetAllIssue> getAllIssuesVMLst = new List<GetAllIssue>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                getAllIssuesVMLst = conn.Query<GetAllIssue>("sp_GetAllIssues", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllIssuesVMLst;
            }
        }
        //GetSingleIssue
        public static EditIssueVM getSignleIssueDL(int IssuesID)
        {
            EditIssueVM model = new EditIssueVM();
            using (IDbConnection Con = new SqlConnection(Common.ConnectionString))
            {
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@IssuesID", IssuesID);
                model = Con.Query<EditIssueVM>("sp_GetSingleIssue", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Con.Close();
                Con.Dispose();
            }
            return model;
        }
        //IssuesEdit
        public static StatusModel issueEditDL(EditIssueVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@IssuesID", m.IssuesID);
                ObjParm.Add("@Project_ID", m.Project_ID);
                ObjParm.Add("@SubProject_ID", m.SubProject_ID);
                ObjParm.Add("@Batch_ID", m.Batch_ID);
                ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);
                ObjParm.Add("@IssueDescription", m.IssueDescription);
                ObjParm.Add("@IssueDate", m.IssueDate);
                ObjParm.Add("@ActionTaken", m.ActionTaken);
                ObjParm.Add("@Remarks", m.Remarks);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_IssueEdit", ObjParm, commandType: CommandType.StoredProcedure);

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
    }
}
