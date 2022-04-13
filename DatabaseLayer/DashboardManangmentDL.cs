using Dapper;
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
   public class DashboardManangmentDL
    {
        public static List<GetPKPIsChart> getDashboardDL()
        {
            List<GetPKPIsChart> getDashboardVM = new List<GetPKPIsChart>();
            using (IDbConnection connection = new SqlConnection(Common.ConnectionString))
            {
                connection.Open();
                DynamicParameters ObjParm = new DynamicParameters();   
                using (var multi = connection.QueryMultiple("sp_GetDashboard", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    getDashboardVM = multi.Read<GetPKPIsChart>().ToList();
                    //getProjectDetailsVM.getProjectDetailsQ2 = multi.Read<GetProjectDetailsQ2>().FirstOrDefault();
                    //getProjectDetailsVM.getProjectDetailsQ3 = multi.Read<GetProjectDetailsQ3>().FirstOrDefault();
                    //getProjectDetailsVM.getProjectDetailsQ4 = multi.Read<GetProjectDetailsQ4>().FirstOrDefault();
                    //getProjectDetailsVM.getProjectDetailsQ5 = multi.Read<GetProjectDetailsQ5>().FirstOrDefault();
                    //getProjectDetailsVM.getProjectDetailsQ6Lst = multi.Read<GetProjectDetailsQ6>().ToList();
                    //getProjectDetailsVM.getProjectDetailsQ7 = multi.Read<GetProjectDetailsQ7>().FirstOrDefault();
                }
            }
            return getDashboardVM;
        }
    }
}
