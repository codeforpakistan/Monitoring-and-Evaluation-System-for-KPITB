using Dapper;
using ModelLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utility;
using static ModelLayer.ComboModel;
using static ModelLayer.MainModel;
using static ModelLayer.MainViewModel;

namespace DatabaseLayer
{
    public class ProjectManagementDL
    {

        #region CustomFuncation
        public static int checkUmberlaDL(int ProjectID)
        {
            try
            {
                int value = 0;
                using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
                {
                    conn.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@ProjectID", ProjectID);
                    value = conn.Query<int>("sp_CheckUmberla", ObjParm, commandType: CommandType.StoredProcedure).First(); ;
                    conn.Close();
                    conn.Dispose();
                    return Convert.ToInt32(value);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static List<GetAllProjectVM> SearchProjectByAttributesDL(string ProjectName, string ProjectType, string Location, int UserID, int RoleID)
        {
            List<GetAllProjectVM> getAllProjectLst = new List<GetAllProjectVM>();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", RoleID);
                ObjParm.Add("@LoginUserID", UserID);
                ObjParm.Add("@ProjectName", ProjectName = ProjectName == "" ? null : ProjectName);
                ObjParm.Add("@ProjectType", ProjectType = ProjectType == "" ? null : ProjectType);
                ObjParm.Add("@Location", Location = Location == "" ? null : Location);
                getAllProjectLst = Con.Query<GetAllProjectVM>("sp_SearchProjectByAttributes", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                Con.Close();
                Con.Dispose();
                return getAllProjectLst;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Close();
            }
            return getAllProjectLst;
        }
        public static List<GetAllRecruitedHRVM> SearchRecruitedHRByAttributesDL(string ProjectName, string BatchName, string FromDate, string ToDate, int UserID, int RoleID)
        {
            List<GetAllRecruitedHRVM> getAllRecruitedHRLst = new List<GetAllRecruitedHRVM>();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", RoleID);
                ObjParm.Add("@LoginUserID", UserID);
                ObjParm.Add("@ProjectName", ProjectName = ProjectName == "" ? null : ProjectName);
                ObjParm.Add("@BatchName", BatchName = BatchName == "" ? null : BatchName);
                ObjParm.Add("@FromDate", FromDate = FromDate == "" ? null : FromDate);
                ObjParm.Add("@ToDate", ToDate = ToDate == "" ? null : ToDate);
                getAllRecruitedHRLst = Con.Query<GetAllRecruitedHRVM>("sp_SearchRecruitedHRByAttributes", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                Con.Close();
                Con.Dispose();
                return getAllRecruitedHRLst;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Con.Close();
            }
            return getAllRecruitedHRLst;
        }

        public static bool IsProjectNameExistsDL(string _ProjectName)
        {
            bool isTrue = false;
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@ProjectName", _ProjectName);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_IsProjectNameExists", ObjParm, commandType: CommandType.StoredProcedure);

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
        public static RemainingValues RemainingValuesDL(int _ProjectID,int? SubProjectID)
        {
            RemainingValues remainingValues = new RemainingValues();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ProjectID", _ProjectID);
                ObjParm.Add("@SubProjectID", SubProjectID);
                remainingValues = Con.Query<RemainingValues>("sp_RemainingValues", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }
            return remainingValues;
        }
        public static StatusModel ComparePlanned_PrucrementDL(int _ProjectID, out int PlannedProcurement, out int AchievedProcurement)
        {
            PlannedProcurement = 0;
            AchievedProcurement = 0;

            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@ProjectID", _ProjectID);
                ObjParm.Add("@PlannedProcurement", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ObjParm.Add("@AchievedProcurement", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_ComparePlannedHR_With_PrucrementHR", ObjParm, commandType: CommandType.StoredProcedure);

                PlannedProcurement = Convert.ToInt32(ObjParm.Get<int>("@PlannedProcurement"));
                AchievedProcurement = Convert.ToInt32(ObjParm.Get<int>("@AchievedProcurement"));
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
        public static int checkBatchIsZeroDL(int SubProjectID)
        {
            try
            {
                int value = 0;
                using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
                {
                    conn.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@SubProject_ID", SubProjectID);
                    value = conn.Query<int>("sp_CheckUmberla", ObjParm, commandType: CommandType.StoredProcedure).First(); ;
                    conn.Close();
                    conn.Dispose();
                    return Convert.ToInt32(value);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
        #region GetCombo
        //ComboProject
        public static List<ComboProject> getComboProjectDL(int LoginRoleID, int LoginUserID)
        {
            List<ComboProject> ComboProjectLst = new List<ComboProject>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", LoginRoleID);
                ObjParm.Add("@LoginUserID", LoginUserID);
                ComboProjectLst = conn.Query<ComboProject>("sp_GetProject", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboProjectLst;
            }
        }
        //ComboSubProject
        public static List<ComboSubProject> getComboSubProjectDL(int Project_ID, int Role_ID)
        {
            List<ComboSubProject> ComboLst = new List<ComboSubProject>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Project_ID", Project_ID);
                ObjParm.Add("@Role_ID", Role_ID);
                ComboLst = conn.Query<ComboSubProject>("sp_GetSubProjectBaseOnProject", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboLst;
            }
        }
        //ComboBatch
        public static List<ComboBatch> getComboBatchDL(int Project_ID, int Role_ID)
        {
            //List<ComboBatch> ComboLst = new List<ComboBatch>();

            //using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            //{
            //    conn.Open();
            //    DynamicParameters ObjParm = new DynamicParameters();
            //    ObjParm.Add("@SubProject_ID", SubProject_ID);
            //    ObjParm.Add("@Role_ID", Role_ID);
            //    ComboLst = conn.Query<ComboBatch>("sp_GetBatchBaseOnSubProject", ObjParm, commandType: CommandType.StoredProcedure).ToList();
            //    conn.Close();
            //    conn.Dispose();
            //    return ComboLst;
            //}
            List<ComboBatch> ComboLst = new List<ComboBatch>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Project_ID", Project_ID);
                ObjParm.Add("@Role_ID", Role_ID);
                ComboLst = conn.Query<ComboBatch>("sp_GetBatchBaseOnProject", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboLst;
            }
        }


        public static List<ComboIndicator> getComboIndicatorDL(int Project_ID, int BatchID)
        {
            List<ComboIndicator> ComboLst = new List<ComboIndicator>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Project_ID", Project_ID);
                ObjParm.Add("@Batch_ID", BatchID);
                ComboLst = conn.Query<ComboIndicator>("sp_GetIndicatorBaseOnBatch", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboLst;
            }
        }
        public static List<ComboProcurementHead> getComboProcurementHeadDL(int Project_ID, int SubProject_ID)
        {
            List<ComboProcurementHead> ComboLst = new List<ComboProcurementHead>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Project_ID", Project_ID);
                ObjParm.Add("@SubProject_ID", SubProject_ID);
                ComboLst = conn.Query<ComboProcurementHead>("sp_GetProcurementHeadBaseOnProject", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboLst;
            }
        }

        public static List<ComboBatch> getComboBoxBatchDL(int Project_ID, int Role_ID, int? SubProjectID)
        {
            List<ComboBatch> ComboLst = new List<ComboBatch>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Project_ID", Project_ID);
                ObjParm.Add("@Role_ID", Role_ID);
                ObjParm.Add("@SubProject_ID", SubProjectID);
                ComboLst = conn.Query<ComboBatch>("sp_GetBatchBaseOnProject", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboLst;
            }
        }
        //ComboIndicatorDataType
        public static List<ComboInsightIndicatorDataType> getComboDataTypeDL()
        {
            List<ComboInsightIndicatorDataType> ComboLst = new List<ComboInsightIndicatorDataType>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ComboLst = conn.Query<ComboInsightIndicatorDataType>("sp_GetInsightIndicatorDataType", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboLst;
            }
        }
        //ComboIndicator
        public static List<ComboIndicator> getComboIndicatorDL()
        {
            List<ComboIndicator> ComboLst = new List<ComboIndicator>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ComboLst = conn.Query<ComboIndicator>("sp_GetIndicator", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboLst;
            }
        }

        //FundingSource
        public static List<ComboFundingSource> getFudingSourceDL()
        {
            List<ComboFundingSource> fundingSourceLst = new List<ComboFundingSource>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                fundingSourceLst = conn.Query<ComboFundingSource>("sp_GetAllFundingSource", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return fundingSourceLst;
            }
        }

        //Category
        public static List<ComboCategory> getCategoryDL()
        {
            List<ComboCategory> categoryLst = new List<ComboCategory>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                categoryLst = conn.Query<ComboCategory>("sp_GetAllCategory", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return categoryLst;
            }
        }

        //ProjectType
        public static List<ComboProjectType> getProjectTypeDL()
        {
            List<ComboProjectType> ProjectTypeLst = new List<ComboProjectType>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                ProjectTypeLst = conn.Query<ComboProjectType>("sp_GetAllProjectType", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ProjectTypeLst;
            }
        }

        //DigitalPolicy
        public static List<ComboDigitalPolicy> getDigitalPolicyDL()
        {
            List<ComboDigitalPolicy> DigitalPolicyLst = new List<ComboDigitalPolicy>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DigitalPolicyLst = conn.Query<ComboDigitalPolicy>("sp_GetAllDigitalPolicy", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return DigitalPolicyLst;
            }
        }

        //Location City
        public static List<ComboCity> getCityDL()
        {
            List<ComboCity> CityLst = new List<ComboCity>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                CityLst = conn.Query<ComboCity>("sp_GetAllCity", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return CityLst;
            }
        }

        //Project SDGS
        public static List<ComboSDGS> getSDGSDL()
        {
            List<ComboSDGS> SDGSLst = new List<ComboSDGS>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                SDGSLst = conn.Query<ComboSDGS>("sp_GetAllSDGS", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return SDGSLst;
            }
        }
        //ProjectStuatus
        public static List<ComboProjectStatus> getProjectStatusDL()
        {
            List<ComboProjectStatus> ProjectStatusLst = new List<ComboProjectStatus>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                ProjectStatusLst = conn.Query<ComboProjectStatus>("sp_GetAllProjectStatus", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ProjectStatusLst;
            }
        }
        //RiskkStatus
        public static List<ComboRiskStatus> getRiskStatusDL()
        {
            List<ComboRiskStatus> RiskStatusLst = new List<ComboRiskStatus>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                RiskStatusLst = conn.Query<ComboRiskStatus>("sp_GetAllRiskStatus", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return RiskStatusLst;
            }
        }
        //RiskMitigation
        public static List<ComboRiskMitigation> getRiskMitigationDL()
        {
            List<ComboRiskMitigation> RiskMitigationLst = new List<ComboRiskMitigation>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                RiskMitigationLst = conn.Query<ComboRiskMitigation>("sp_GetAllRiskMitigation", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return RiskMitigationLst;
            }
        }
        public static List<ComboTypeOfStakeholder> getTypeOfStakeholderDL()
        {
            List<ComboTypeOfStakeholder> TypeOfStakeholderLst = new List<ComboTypeOfStakeholder>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                TypeOfStakeholderLst = conn.Query<ComboTypeOfStakeholder>("sp_GetAllTypeOfStakeholder", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return TypeOfStakeholderLst;
            }
        }
        #endregion
        #region ProjectCreate
        public static StatusModel projectCreateDL(CreateProjectVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;

            bool _Status = false;
            string _StatusDetails = null;

            SqlConnection conn = null;
            SqlCommand cmd = null;

            int Project_ID = 0;

            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    Con = new SqlConnection(Common.ConnectionString);

                    DynamicParameters ObjParm = new DynamicParameters();
                    //LoginUser
                    ObjParm.Add("@CreatedByUser_ID", m.User_ID);   //LoginUser
                    ObjParm.Add("@Category_ID", m.Category_ID);
                    ObjParm.Add("@ProjectGoal", m.ProjectGoal);
                    ObjParm.Add("@ProjectName", m.ProjectName);
                    ObjParm.Add("@PlannedBudget", m.PlannedBudget);
                    ObjParm.Add("@ApprovedBudget", m.ApprovedBudget);
                    ObjParm.Add("@PlannedHR", m.PlannedHR);

                    //Schedule
                    ObjParm.Add("@PlannedDate", m.PlannedDate);
                    ObjParm.Add("@StartDate", m.StartDate);
                    ObjParm.Add("@EndDate", m.EndDate);

                    //ReleasedBudget
                    ObjParm.Add("@ReleasedBudget", m.ReleasedBudget);
                    ObjParm.Add("@ReleasedDate", DateTime.Now);

                    ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    ObjParm.Add("@Project_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    Con = new SqlConnection(Common.ConnectionString);
                    Con.Open();
                    Con.Execute("sp_ProjectCeate", ObjParm, commandType: CommandType.StoredProcedure);
                    Con.Close();
                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    Project_ID = Convert.ToInt32(ObjParm.Get<Int32>("@Project_ID"));

                    var _AssignRiskList = m.AssignRiskList.Select(p => new { Project_ID, p.SubProject_ID, p.Batch_ID, p.RiskMitigation_ID, p.RiskName, p.RiskStatus_ID, p.CreatedByUser_ID }).ToList();
                    if (_AssignRiskList.Count > 0)
                    {
                        DataTable dt = Utility.Conversion.ConvertListToDataTable(_AssignRiskList);

                        DynamicParameters ObjParm22 = new DynamicParameters();
                        ObjParm22.Add("@RiskTable", dt.AsTableValuedParameter("udt_Risk"));
                        ObjParm22.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                        ObjParm22.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                        Con = new SqlConnection(Common.ConnectionString);
                        Con.Open();
                        Con.Execute("sp_RiskCreateMulti", ObjParm22, commandType: CommandType.StoredProcedure);
                        Con.Close();
                        status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                        status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    }

                    #region Region2

                    var _AssignStackholderList = m.AssignStackholderList.Select(p => new { Project_ID, p.SubProject_ID, p.Batch_ID, p.StackholderName, p.StackholderDepartment, p.StackholderContact, p.StackholderEmail, p.CreatedByUser_ID }).ToList();
                    DataTable ddt = new DataTable();
                    if (_AssignStackholderList.Count > 0)
                    {
                        ddt = Utility.Conversion.ConvertListToDataTable(_AssignStackholderList);
                    }
                    DynamicParameters ObjParm222 = new DynamicParameters();
                    ObjParm222.Add("@StackholderTable", ddt.AsTableValuedParameter("udt_StackHolder"));
                    ObjParm222.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    ObjParm222.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    Con = new SqlConnection(Common.ConnectionString);
                    Con.Open();
                    Con.Execute("sp_StackholderCreateMulti", ObjParm222, commandType: CommandType.StoredProcedure);
                    Con.Close();
                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    #endregion
                    #region Region3
                    DynamicParameters ObjParm3 = new DynamicParameters();

                    var _dtObjective = m.AssignObjectiveList.Select(p => new { Project_ID, p.SubProject_ID, p.ObjectiveName }).ToList();
                    DataTable dtObjective = Utility.Conversion.ConvertListToDataTable(_dtObjective);

                    DataTable dtCity = new DataTable();
                    dtCity.Columns.Add("Project_ID", typeof(int));
                    dtCity.Columns.Add("City_ID", typeof(int));
                    for (int i = 0; i < m.CityArray.Count; i++)
                    { dtCity.Rows.Add(Project_ID, m.CityArray[i]); }

                    DataTable dtFundingSource = new DataTable();
                    dtFundingSource.Columns.Add("Project_ID", typeof(int));
                    dtFundingSource.Columns.Add("FundingSource_ID", typeof(int));
                    for (int i = 0; i < m.Funding_SourceArray.Count; i++)
                    { dtFundingSource.Rows.Add(Project_ID, m.Funding_SourceArray[i]); }

                    DataTable dtProjectWithPolicy = new DataTable();
                    dtProjectWithPolicy.Columns.Add("Project_ID", typeof(int));
                    dtProjectWithPolicy.Columns.Add("DigitalPolicy_ID", typeof(int));
                    for (int i = 0; i < m.DigitalPolicyArray.Count; i++)
                    { dtProjectWithPolicy.Rows.Add(Project_ID, m.DigitalPolicyArray[i]); }

                    DataTable dtProjectWithProjectType = new DataTable();
                    dtProjectWithProjectType.Columns.Add("Project_ID", typeof(int));
                    dtProjectWithProjectType.Columns.Add("ProjectType_ID", typeof(int));
                    for (int i = 0; i < m.ProjectTypeArray.Count; i++)
                    { dtProjectWithProjectType.Rows.Add(Project_ID, m.ProjectTypeArray[i]); }

                    DataTable dtProjectWithSDGS = new DataTable();
                    dtProjectWithSDGS.Columns.Add("Project_ID", typeof(int));
                    dtProjectWithSDGS.Columns.Add("SDGS_ID", typeof(int));
                    for (int i = 0; i < m.SDGSArray.Count; i++)
                    { dtProjectWithSDGS.Rows.Add(Project_ID, m.SDGSArray[i]); }

                    ObjParm3.Add("@ProjectWithCityTable", dtCity.AsTableValuedParameter("udt_ProjectWithCity "));
                    ObjParm3.Add("@ProjectWIthFundingSourceTable", dtFundingSource.AsTableValuedParameter("udt_ProjectWIthFundingSource"));
                    ObjParm3.Add("@ProjectWithPolicyTable", dtProjectWithPolicy.AsTableValuedParameter("udt_ProjectWithPolicy"));
                    ObjParm3.Add("@ProjectWithProjectTypeTable", dtFundingSource.AsTableValuedParameter("udt_ProjectWithProjectType"));
                    ObjParm3.Add("@ProjectWithSDGSTable", dtFundingSource.AsTableValuedParameter("udt_ProjectWithSDGS"));

                    ObjParm3.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    ObjParm3.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    Con = new SqlConnection(Common.ConnectionString);
                    Con.Open();
                    Con.Execute("sp_ProjectBulkEntry", ObjParm3, commandType: CommandType.StoredProcedure);
                    Con.Close();
                    status.status = Convert.ToBoolean(ObjParm3.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm3.Get<string>("@StatusDetails"));

                    #endregion

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
        #region GetAllProject
        //Project
        public static List<GetAllProjectVM> getProjectDL(int LoginRoleID, int LoginUserID)
        {
            List<GetAllProjectVM> getAllProjectLst = new List<GetAllProjectVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", LoginRoleID);
                ObjParm.Add("@LoginUserID", LoginUserID);
                getAllProjectLst = conn.Query<GetAllProjectVM>("sp_GetAllProject", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllProjectLst;
            }
        }

        //ProjectDetail
        public static GetProjectDetailsVM getProjectDetailDL(int ProjectID)
        {
            GetProjectDetailsVM getProjectDetailsVM = new GetProjectDetailsVM();
            using (IDbConnection connection = new SqlConnection(Common.ConnectionString))
            {
                connection.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Project_ID", ProjectID);
                using (var multi = connection.QueryMultiple("sp_GetProjectDetails", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    getProjectDetailsVM.getProjectDetailsQ1 = multi.Read<GetProjectDetailsQ1>().FirstOrDefault();
                    getProjectDetailsVM.getProjectDetailsQ2 = multi.Read<GetProjectDetailsQ2>().FirstOrDefault();
                    getProjectDetailsVM.getProjectDetailsQ3 = multi.Read<GetProjectDetailsQ3>().FirstOrDefault();
                    getProjectDetailsVM.getProjectDetailsQ4 = multi.Read<GetProjectDetailsQ4>().FirstOrDefault();
                    getProjectDetailsVM.getProjectDetailsQ5 = multi.Read<GetProjectDetailsQ5>().FirstOrDefault();
                    getProjectDetailsVM.getProjectDetailsQ6Lst = multi.Read<GetProjectDetailsQ6>().ToList();
                    // getProjectDetailsVM.getProjectDetailsQ7 = multi.Read<GetProjectDetailsQ7>().FirstOrDefault();


                }
            }
            return getProjectDetailsVM;
        }

        #endregion

        #region RecruitedHR
        //RecruitedHRCreate
        public static StatusModel recruitedCreateDL(CreateRecruitedHRVM m)
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
                ObjParm.Add("@PositionTitle", m.PositionTitle);
                ObjParm.Add("@Grade", m.Grade);
                ObjParm.Add("@RecruitedHR", m.RecruitedHR);
                ObjParm.Add("@RecruitedFromHRDate", m.RecruitedFromHRDate);
                ObjParm.Add("@RecruitedToHRDate", m.RecruitedToHRDate);
                ObjParm.Add("@Remarks", m.Remarks);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_recruiteHRCreate", ObjParm, commandType: CommandType.StoredProcedure);

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

        //GetALLRecruitedHR
        public static List<GetAllRecruitedHRVM> getRecruitedHRDL(int LoginRoleID, int LoginUserID)
        {
            List<GetAllRecruitedHRVM> getAllRecruitedHRVMLst = new List<GetAllRecruitedHRVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", LoginRoleID);
                ObjParm.Add("@LoginUserID", LoginUserID);
                getAllRecruitedHRVMLst = conn.Query<GetAllRecruitedHRVM>("sp_GetAllRecruitedHR", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllRecruitedHRVMLst;
            }
        }

        //GetSingleRecruitedHR
        public static EditRecruitedHRVM getSignleRecruitedHRDL(int RecruitedHRID)
        {
            EditRecruitedHRVM model = new EditRecruitedHRVM();
            using (IDbConnection Con = new SqlConnection(Common.ConnectionString))
            {
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@RecruitedHRID", RecruitedHRID);
                model = Con.Query<EditRecruitedHRVM>("sp_GetSingleRecruitedHR", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Con.Close();
                Con.Dispose();
            }
            return model;
        }
        //UserEdit
        public static StatusModel recruitedEditDL(EditRecruitedHRVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@RecruitedHRID", m.RecruitedHRID);
                ObjParm.Add("@Project_ID", m.Project_ID);
                ObjParm.Add("@SubProject_ID", m.SubProject_ID);
                ObjParm.Add("@Batch_ID", m.Batch_ID);
                ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);
                ObjParm.Add("@RecruitedHR", m.RecruitedHR);
                ObjParm.Add("@RecruitedFromHRDate", m.RecruitedFromHRDate);
                ObjParm.Add("@RecruitedToHRDate", m.RecruitedToHRDate);
                ObjParm.Add("@Remarks", m.Remarks);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_recruiteHREdit", ObjParm, commandType: CommandType.StoredProcedure);

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
        #endregion
        #region Procurement
        //RecruitedHRCreate
        public static StatusModel procurementCreateDL(CreateProcurementVM m)
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
                //ObjParm.Add("@Batch_ID", m.Batch_ID);
                ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);
                ObjParm.Add("@PlannedProcurement_ID", m.PlannedProcurement_ID);
                ObjParm.Add("@ProcurementDate", m.ProcurementDate);
                ObjParm.Add("@AchievedProcurement", m.AchievedProcurement);
                ObjParm.Add("@ActualCostPerItem", m.ActualCostPerItem);
                ObjParm.Add("@TotalCost", m.TotalCost);
                ObjParm.Add("@Remarks", m.Remarks);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_ProcurementCreate", ObjParm, commandType: CommandType.StoredProcedure);

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
        //GetALLprocurement
        public static List<GetAllProcurementVM> getProcurementDL(int LoginRoleID, int LoginUserID)
        {
            List<GetAllProcurementVM> getAllProcurementVMLst = new List<GetAllProcurementVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", LoginRoleID);
                ObjParm.Add("@LoginUserID", LoginUserID);
                getAllProcurementVMLst = conn.Query<GetAllProcurementVM>("sp_GetAllProcurement", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllProcurementVMLst;
            }
        }
        //GetSingleProcurement
        public static EditProcurementVM getSignleProcurementDL(int AchievedProcurementID)
        {
            EditProcurementVM model = new EditProcurementVM();
            using (IDbConnection Con = new SqlConnection(Common.ConnectionString))
            {
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@AchievedProcurementID", AchievedProcurementID);
                model = Con.Query<EditProcurementVM>("sp_GetSingleProcurement", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Con.Close();
                Con.Dispose();
            }
            return model;
        }
        public static StatusModel procurementEditDL(EditProcurementVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@AchievedProcurementID", m.AchievedProcurementID);
                ObjParm.Add("@Project_ID", m.Project_ID);
                ObjParm.Add("@SubProject_ID", m.SubProject_ID);
                ObjParm.Add("@Batch_ID", m.Batch_ID);
                ObjParm.Add("@CreatedByUser_ID", m.CreatedByUser_ID);
                ObjParm.Add("@ProcurementHeader", m.ProcurementHeader);
                ObjParm.Add("@AchievedProcurement", m.AchievedProcurement);
                ObjParm.Add("@ProcurementFromDate", m.ProcurementFromDate);
                ObjParm.Add("@ProcurementToDate", m.ProcurementToDate);
                ObjParm.Add("@Remarks", m.Remarks);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_ProcurementEdit", ObjParm, commandType: CommandType.StoredProcedure);

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
        #endregion

    }
}
