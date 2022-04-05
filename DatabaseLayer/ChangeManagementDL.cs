using Dapper;
using ModelLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;


namespace DatabaseLayer
{
    public class ChangeManagementDL
    {
        public static List<ChangeManagement> GetChangeManagementDataDL(int _ProjectID)
        {
            List<ChangeManagement> returnList = new List<ChangeManagement>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ProjectID", _ProjectID);
                returnList = Repose.GetList<ChangeManagement>("sp_GetChangeManagementData", ObjParm); 
            }
            catch (Exception ex)
            {
                throw;
            }
            return returnList;
        }

        public static StatusModel changeManagementCreateDL(ChangeManagementVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;

          
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    Con = new SqlConnection(Common.ConnectionString);

                    DynamicParameters ObjParm = new DynamicParameters();
                    //LoginUser
                    ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);   //LoginUser
                    ObjParm.Add("@Project_ID", m.Project_ID);
                    ObjParm.Add("@ProjectName", m.ProjectName);
                    ObjParm.Add("@ProjectGoal", m.ProjectGoal);
                    ObjParm.Add("@PlannedBudget", m.PlannedBudget);
                    ObjParm.Add("@ApprovedBudget", m.ApprovedBudget);
                    ObjParm.Add("@PlannedHR", m.PlannedHR);
                    //Schedule
                    ObjParm.Add("@PlannedDate", m.PlannedDate);
                    ObjParm.Add("@StartDate", m.StartDate);
                    ObjParm.Add("@EndDate", m.EndDate);

                    //ReleasedBudget
                  

                    ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    ObjParm.Add("@SubProject_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    Con = new SqlConnection(Common.ConnectionString);
                    Con.Open();
                    Con.Execute("sp_SubProjectCeate", ObjParm, commandType: CommandType.StoredProcedure);
                    Con.Close();

                    //status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    //status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    //SubProject_ID = Convert.ToInt32(ObjParm.Get<Int32>("@SubProject_ID"));

                    //var _AssignRiskList = m.AssignRiskList.Select(p => new { p.Project_ID, SubProject_ID, p.Batch_ID, p.RiskName, p.RiskMitigation_ID, p.RiskStatus_ID, p.CreatedByUser_ID }).ToList();
                    //if (_AssignRiskList.Count > 0)
                    //{
                    //    DataTable dt = Utility.Conversion.ConvertListToDataTable(_AssignRiskList);

                    //    DynamicParameters ObjParm22 = new DynamicParameters();
                    //    ObjParm22.Add("@RiskTable", dt.AsTableValuedParameter("udt_Risk"));
                    //    ObjParm22.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    //    ObjParm22.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    //    Con = new SqlConnection(Common.ConnectionString);
                    //    Con.Open();
                    //    Con.Execute("sp_RiskCreateMulti", ObjParm22, commandType: CommandType.StoredProcedure);
                    //    Con.Close();
                    //    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    //    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    //}
                    //#region Region1
                    //var _AssignKPIsList = m.AssignProjectPlannedKPIsList.Select(p => new { p.Project_ID, SubProject_ID, p.IndicatorDescription, p.Target }).ToList();
                    //if (_AssignKPIsList.Count > 0)
                    //{
                    //    DataTable dt = Utility.Conversion.ConvertListToDataTable(_AssignKPIsList);

                    //    DynamicParameters ObjParm22 = new DynamicParameters();
                    //    ObjParm22.Add("@PlannedKPIsTable", dt.AsTableValuedParameter("udt_PlannedKPIs"));
                    //    ObjParm22.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    //    ObjParm22.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    //    Con = new SqlConnection(Common.ConnectionString);
                    //    Con.Open();
                    //    Con.Execute("sp_PlannedKPIsCreateMulti", ObjParm22, commandType: CommandType.StoredProcedure);
                    //    Con.Close();
                    //    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    //    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    //}
                    //#endregion
                    //#region Region2

                    //var _AssignStackholderList = m.AssignStackholderList.Select(p => new { p.Project_ID, SubProject_ID, p.Batch_ID, p.StackholderDepartment, p.TypeOfStakeholder_ID, p.StackholderContact, p.StackholderEmail, p.CreatedByUser_ID }).ToList();
                    //DataTable ddt = new DataTable();
                    //if (_AssignStackholderList.Count > 0)
                    //{
                    //    ddt = Utility.Conversion.ConvertListToDataTable(_AssignStackholderList);
                    //}
                    //DynamicParameters ObjParm222 = new DynamicParameters();
                    //ObjParm222.Add("@StackholderTable", ddt.AsTableValuedParameter("udt_StackHolder"));
                    //ObjParm222.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    //ObjParm222.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    //Con = new SqlConnection(Common.ConnectionString);
                    //Con.Open();
                    //Con.Execute("sp_StackholderCreateMulti", ObjParm222, commandType: CommandType.StoredProcedure);
                    //Con.Close();
                    //status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    //status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    //#endregion
                    //#region Region3
                    //DynamicParameters ObjParm3 = new DynamicParameters();

                    //var _dtObjective = m.AssignObjectiveList.Select(p => new { p.Project_ID, SubProject_ID, p.ObjectiveName }).ToList();
                    //DataTable dtObjective = Utility.Conversion.ConvertListToDataTable(_dtObjective);

                    //DataTable dtCity = new DataTable();
                    //dtCity.Columns.Add("Project_ID", typeof(int));
                    //dtCity.Columns.Add("City_ID", typeof(int));
                    //for (int i = 0; i < m.CityArray.Count; i++)
                    //{ dtCity.Rows.Add(SubProject_ID, m.CityArray[i]); }

                    //DataTable dtFundingSource = new DataTable();
                    //dtFundingSource.Columns.Add("Project_ID", typeof(int));
                    //dtFundingSource.Columns.Add("FundingSource_ID", typeof(int));
                    //for (int i = 0; i < m.Funding_SourceArray.Count; i++)
                    //{ dtFundingSource.Rows.Add(SubProject_ID, m.Funding_SourceArray[i]); }

                    //DataTable dtProjectWithPolicy = new DataTable();
                    //dtProjectWithPolicy.Columns.Add("Project_ID", typeof(int));
                    //dtProjectWithPolicy.Columns.Add("DigitalPolicy_ID", typeof(int));
                    //for (int i = 0; i < m.DigitalPolicyArray.Count; i++)
                    //{ dtProjectWithPolicy.Rows.Add(SubProject_ID, m.DigitalPolicyArray[i]); }

                    //DataTable dtProjectWithProjectType = new DataTable();
                    //dtProjectWithProjectType.Columns.Add("Project_ID", typeof(int));
                    //dtProjectWithProjectType.Columns.Add("ProjectType_ID", typeof(int));
                    //for (int i = 0; i < m.ProjectTypeArray.Count; i++)
                    //{ dtProjectWithProjectType.Rows.Add(SubProject_ID, m.ProjectTypeArray[i]); }

                    //DataTable dtProjectWithSDGS = new DataTable();
                    //dtProjectWithSDGS.Columns.Add("Project_ID", typeof(int));
                    //dtProjectWithSDGS.Columns.Add("SDGS_ID", typeof(int));
                    //for (int i = 0; i < m.SDGSArray.Count; i++)
                    //{ dtProjectWithSDGS.Rows.Add(SubProject_ID, m.SDGSArray[i]); }

                    //ObjParm3.Add("@ProjectWithCityTable", dtCity.AsTableValuedParameter("udt_ProjectWithCity "));
                    //ObjParm3.Add("@ProjectWIthFundingSourceTable", dtFundingSource.AsTableValuedParameter("udt_ProjectWIthFundingSource"));
                    //ObjParm3.Add("@ProjectWithPolicyTable", dtProjectWithPolicy.AsTableValuedParameter("udt_ProjectWithPolicy"));
                    //ObjParm3.Add("@ProjectWithProjectTypeTable", dtFundingSource.AsTableValuedParameter("udt_ProjectWithProjectType"));
                    //ObjParm3.Add("@ProjectWithSDGSTable", dtFundingSource.AsTableValuedParameter("udt_ProjectWithSDGS"));

                    //ObjParm3.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    //ObjParm3.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    //Con = new SqlConnection(Common.ConnectionString);
                    //Con.Open();
                    //Con.Execute("sp_ProjectBulkEntry", ObjParm3, commandType: CommandType.StoredProcedure);
                    //Con.Close();
                    //status.status = Convert.ToBoolean(ObjParm3.Get<bool>("@Status"));
                    //status.statusDetail = Convert.ToString(ObjParm3.Get<string>("@StatusDetails"));

                    //transactionScope.Complete();
                    //transactionScope.Dispose();
                    //#endregion

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

            return status;
        }
    }
}
