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
    public class BatchManagementDL
    {
        public static StatusModel batchCreateViewDL(CreateBatchVM m)
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
                ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);
                ObjParm.Add("@BatchName", m.BatchName);
              
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_batchCreate", ObjParm, commandType: CommandType.StoredProcedure);

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
