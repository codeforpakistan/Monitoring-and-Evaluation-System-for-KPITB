using Dapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.StoreProcModel;

namespace DatabaseLayer
{
    public class Dashboard
    {
        public static Dashboardv1 dashboardv1DL()
        {
            IDbConnection Con = null;
            StatusModel status = new StatusModel();
           
            OneLinearVM oneLinearList = new OneLinearVM();
            ADPVM ADPList = new ADPVM();
            ForigenFundedVM FFList = new ForigenFundedVM();
            Dashboardv1 dashboardv1 = new Dashboardv1();
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                using (var gridReader = Con.QueryMultiple("sp_GetDashboardv1OneLinear", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    
                    oneLinearList.oneLinearRow1 = gridReader.Read<OneLinearRow1>().FirstOrDefault();
                    oneLinearList.oneLinearRow2 = gridReader.Read<OneLinearRow2>().FirstOrDefault();
                    oneLinearList.oneLinearRow3 = gridReader.Read<OneLinearRow3>().FirstOrDefault();
                    oneLinearList.oneLinearRow4Project = gridReader.Read<OneLinearRow4Project>().ToList();
                    oneLinearList.oneLinearRow4SubProject = gridReader.Read<OneLinearRow4SubProject>().ToList();
                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                }
                using (var gridReader = Con.QueryMultiple("sp_GetDashboardv1ADP", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    ADPList.totalProject = gridReader.Read<TotalProject>().FirstOrDefault();
                    ADPList.ADPRow1 = gridReader.Read<ADPRow1>().FirstOrDefault();
                    ADPList.ADPRow2 = gridReader.Read<ADPRow2>().FirstOrDefault();
                    ADPList.ADPRow3 = gridReader.Read<ADPRow3>().FirstOrDefault();
                    ADPList.ADPRow4Project = gridReader.Read<ADPRow4Project>().ToList();
                    ADPList.ADPRow4SubProject = gridReader.Read<ADPRow4SubProject>().ToList();
                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                }
                using (var gridReader = Con.QueryMultiple("sp_GetDashboardv1ForeignFunding", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    FFList.forigenFundedRow1 = gridReader.Read<ForigenFundedRow1>().FirstOrDefault();
                    FFList.forigenFundedRow2 = gridReader.Read<ForigenFundedRow2>().FirstOrDefault();
                    FFList.forigenFundedRow3 = gridReader.Read<ForigenFundedRow3>().FirstOrDefault();
                    FFList.forigenFundedRow4Project = gridReader.Read<ForigenFundedRow4Project>().ToList();
                    FFList.forigenFundedRow4SubProject = gridReader.Read<ForigenFundedRow4SubProject>().ToList();
                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                }
               
                dashboardv1.oneLinearVM = oneLinearList;
                dashboardv1.ADPVM = ADPList;
                dashboardv1.forigenFundedVM = FFList;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
            return dashboardv1;
        }

        public static Dashboardv3 dashboardv3DL(int? ProjectTypeID)
        {
            IDbConnection Con = null;
            Dashboardv3  dashboardv3 = new Dashboardv3();
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ProjectTypeID", ProjectTypeID);
                using (var gridReader = Con.QueryMultiple("sp_GetProjectOverAllStatus", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    dashboardv3.dv3ProjectKPIsLst = gridReader.Read<dv3ProjectKPIs>().ToList();
                    dashboardv3.dv3ImpactIndicatorsLst = gridReader.Read<dv3ImpactIndicator>().ToList();
                    dashboardv3.dv3FinanceDetailsLst = gridReader.Read<dv3FinanceDetails>().ToList();
                    dashboardv3.dv3SchedulesLst = gridReader.Read<dv3Schedule>().ToList();
                    dashboardv3.dv3IssuesLst = gridReader.Read<dv3Issues>().ToList();
                } 
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
            return dashboardv3;
        }


    }
}
