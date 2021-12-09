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
        #region GetCombo
        //ComboProject
        public static List<ComboProject> getComboProjectDL()
        {
            List<ComboProject> ComboProjectLst = new List<ComboProject>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                ComboProjectLst = conn.Query<ComboProject>("sp_GetProject", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return ComboProjectLst;
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
                    Con.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    //LoginUser
                    ObjParm.Add("@CreatedByUser_ID", m.User_ID);   //LoginUser
                    ObjParm.Add("@Category_ID", m.Category_ID);
                    ObjParm.Add("@ProjectType_ID", m.ProjectType_ID);
                    ObjParm.Add("@DigitalPolicy_ID", m.DigitalPolicy_ID);
                    ObjParm.Add("@City_ID", m.City_ID);
                    ObjParm.Add("@ProjectName", m.ProjectName);
                    ObjParm.Add("@PlannedBudget", m.PlannedBudget);
                    ObjParm.Add("@ApprovedBudget", m.ApprovedBudget);
                    ObjParm.Add("@Funding_Source", m.Funding_Source);
                    ObjParm.Add("@PlannedProcurement", m.PlannedProcurement);
                    ObjParm.Add("@PlannedHR", m.PlannedHR);
                    ObjParm.Add("@CostPerBeneficiary", m.CostPerBeneficiary);
                    ObjParm.Add("@MaleBeneficiary", m.MaleBeneficiary);
                    ObjParm.Add("@FemaleBeneficiary", m.FemaleBeneficiary);
                    ObjParm.Add("@TotalBeneficiary", m.TotalBeneficiary);
                    ObjParm.Add("@Objective", m.Objective);

                    //Risk
                    //ObjParm.Add("@RiskStatus_ID", m.RiskStatus_ID);
                    //ObjParm.Add("@RiskName", m.RiskName);

                    //Schedule
                    ObjParm.Add("@PlannedDate", m.PlannedDate);
                    ObjParm.Add("@StartDate", m.StartDate);
                    ObjParm.Add("@EndDate", m.EndDate);

                    //Procurement
                    ObjParm.Add("@AchievedProcurement", m.AchievedProcurement);
                    ObjParm.Add("@ProcurementPercent", m.ProcurementPercent);
                    ObjParm.Add("@ProcurementDate", DateTime.Now);

                    //StackHolder
                    //ObjParm.Add("@StackholderName", m.StackholderName);
                    //ObjParm.Add("@StackholderDepartment", m.StackholderDepartment);
                    //ObjParm.Add("@StackholderContact", m.StackholderContact);
                    //ObjParm.Add("@StackholderEmail", m.StackholderEmail);

                    //StackHolder
                    ObjParm.Add("@RecruitedHR", m.RecruitedHR);
                    ObjParm.Add("@RecruitedHRPercent", m.RecruitedHRPercent);
                    ObjParm.Add("@RecruitedHRDate", DateTime.Now);

                    //ReleasedBudget
                    ObjParm.Add("@ReleasedBudget", m.ReleasedBudget);
                    ObjParm.Add("@ReleasedDate", DateTime.Now);

                    ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    ObjParm.Add("@Project_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);


                    Con.Execute("sp_ProjectCeate", ObjParm, commandType: CommandType.StoredProcedure);

                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    Project_ID = Convert.ToInt32(ObjParm.Get<Int32>("@Project_ID"));
                    Con.Close();

                    #region NO
                    //RiskMultiEntry
                    //DynamicParameters ObjParmTask = new DynamicParameters();
                    //var _AssignRiskList = m.AssignRiskList.Select(p => new { Project_ID, p.SubProject_ID, p.Batch_ID, p.RiskName, p.RiskStatus_ID, p.CreatedByUser_ID }).ToList();
                    //DataTable dt = new DataTable();
                    //dt = Utility.Conversion.ConvertListToDataTable(_AssignRiskList);
                    //ObjParmTask.AddTable("@RiskTable", "udt_Risk", _AssignRiskList);
                    //ObjParmTask.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    //ObjParmTask.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    //var resultRisk = Con.Query("sp_RiskCreateMulti", dt, commandType: CommandType.StoredProcedure);
                    //status.status = Convert.ToBoolean(ObjParmTask.Get<bool>("@Status"));
                    //status.statusDetail = Convert.ToString(ObjParmTask.Get<string>("@StatusDetails"));

                    //RiskMultiEntry
                    //DynamicParameters ObjParmStackholder = new DynamicParameters();
                    //var _AssignStackholderList = m.AssignStackholderList.Select(p => new { Project_ID, p.SubProject_ID, p.Batch_ID, p.StackholderName, p.StackholderDepartment, p.StackholderContact, p.StackholderEmail, p.CreatedByUser_ID }).ToList();
                    //ObjParmStackholder.AddTable("@StackholderTable", "udt_StackHolder", _AssignStackholderList);
                    //ObjParmStackholder.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    //ObjParmStackholder.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    //var resultStackholder = Con.Query("sp_StackholderCreateMulti", ObjParmTask, commandType: CommandType.StoredProcedure);
                    //status.status = Convert.ToBoolean(ObjParmTask.Get<bool>("@Status"));
                    //status.statusDetail = Convert.ToString(ObjParmTask.Get<string>("@StatusDetails")); 
                    #endregion


                    conn = new SqlConnection(Common.ConnectionString);
                    cmd = new SqlCommand("sp_RiskCreateMulti", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
       
                     var _AssignRiskList = m.AssignRiskList.Select(p => new { Project_ID, p.SubProject_ID, p.Batch_ID, p.RiskName, p.RiskStatus_ID, p.CreatedByUser_ID }).ToList();
                    DataTable dt = Utility.Conversion.ConvertListToDataTable(_AssignRiskList);
                    cmd.Parameters.AddWithValue("@RiskTable", dt).SqlDbType = SqlDbType.Structured;

                    SqlParameter _StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);
                    SqlParameter _StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;


                #region 2
                conn = new SqlConnection(Common.ConnectionString);
                cmd = new SqlCommand("sp_StackholderCreateMulti", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                var _AssignStackholderList = m.AssignStackholderList.Select(p => new { Project_ID, p.SubProject_ID, p.Batch_ID, p.StackholderName, p.StackholderDepartment, p.StackholderContact, p.StackholderEmail, p.CreatedByUser_ID }).ToList();
                DataTable dt2 = Utility.Conversion.ConvertListToDataTable(_AssignStackholderList);
                cmd.Parameters.AddWithValue("@StackholderTable", dt2).SqlDbType = SqlDbType.Structured;

                SqlParameter _StatusParm2 = new SqlParameter("@Status", SqlDbType.Bit);
                _StatusParm2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusParm2);
                SqlParameter _StatusDetailsParm2 = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 100);
                _StatusDetailsParm2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusDetailsParm2);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                status.status = (bool)_StatusParm2.Value;
                status.statusDetail = (string)_StatusDetailsParm2.Value;
                    #endregion
                    conn.Dispose();
                    cmd.Dispose();

                    transactionScope.Complete();
                transactionScope.Dispose();
                }
            }
            catch (Exception ex)
            {
                _Status = false;
                _StatusDetails = ex.Message;

            }
            finally
            {
                
            }
            #endregion
            return status;
        }
        
        #region GetAllProject
        //Project
        public static List<GetAllProjectVM> getProjectDL()
        {
            List<GetAllProjectVM> getAllProjectLst = new List<GetAllProjectVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                getAllProjectLst = conn.Query<GetAllProjectVM>("sp_GetAllProject", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllProjectLst;
            }
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
                        ObjParm.Add("@RecruitedHR", m.RecruitedHR);
                        ObjParm.Add("@RecruitedHRDate", m.RecruitedHRDate);
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
        public static List<GetAllRecruitedHRVM> getRecruitedHRDL()
        {
            List<GetAllRecruitedHRVM> getAllRecruitedHRVMLst = new List<GetAllRecruitedHRVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                getAllRecruitedHRVMLst = conn.Query<GetAllRecruitedHRVM>("sp_GetAllRecruitedHR", commandType: CommandType.StoredProcedure).ToList();
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
                ObjParm.Add("@RecruitedHRDate", m.RecruitedHRDate);
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


    }
}
