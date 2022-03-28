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
    public static class InsightIndicatorDL
    {
        #region IndicatorFieldDL
        public static StatusModel indicatorFeildCreateDL(DataTable dt)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@objIndicatorField", dt.AsTableValuedParameter("udt_IndicatorField"));
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_sp_IndicatorFieldCeateMulti", ObjParm, commandType: CommandType.StoredProcedure);

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
        public static bool IsIndicatorNameExistsDL(string _IndicatorName)
        {
            bool isTrue = false;
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@IndicatorName", _IndicatorName);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_IsIndicatorNameExists", ObjParm, commandType: CommandType.StoredProcedure);

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
        //IndicatorCreate
        public static StatusModel insightIndicatorCreateDL(CreateInsightIndicatorVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;


            SqlConnection conn = null;
            SqlCommand cmd = null;

            int InsightIndicator_ID = 0;

            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    Con = new SqlConnection(Common.ConnectionString);
                    Con.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    //LoginUser
                 
                    ObjParm.Add("@Project_ID", m.Project_ID);
                    ObjParm.Add("@SubProject_ID", m.SubProject_ID);
                    ObjParm.Add("@Batch_ID", m.Batch_ID);
                    ObjParm.Add("@InsightIndicatorName", m.InsightIndicatorName);
                    ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                    ObjParm.Add("@InsightIndicator_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);


                    Con.Execute("sp_InsightIndicatorCreate", ObjParm, commandType: CommandType.StoredProcedure);

                    status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                    status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
                    InsightIndicator_ID = Convert.ToInt32(ObjParm.Get<Int32>("@InsightIndicator_ID"));
                    Con.Close();

                    #region NO

                    conn = new SqlConnection(Common.ConnectionString);
                    cmd = new SqlCommand("sp_InsightIndicatorFieldCeateMulti", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var _AssignInsightIndicatorFieldList = m.AssignInsightIndicatorFieldList.Select(p => new { InsightIndicator_ID, p.InsightIndicatorDataType_ID,p.InsightIndicatorFieldName }).ToList();

                    if (_AssignInsightIndicatorFieldList.Count > 0)
                    {
                        DataTable dt = Utility.Conversion.ConvertListToDataTable(_AssignInsightIndicatorFieldList);
                        cmd.Parameters.AddWithValue("@InsightIndicatorFieldTable", dt).SqlDbType = SqlDbType.Structured;

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
        //GetALLIndicator
       
        public static List<GetAllInsightIndicatorVM> getAllInsightIndicatorDL(int LoginRoleID, int LoginUserID)
        {
            List<GetAllInsightIndicatorVM> getAllVMLst = new List<GetAllInsightIndicatorVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@LoginRoleID", LoginRoleID);
                ObjParm.Add("@LoginUserID", LoginUserID);
                getAllVMLst = conn.Query<GetAllInsightIndicatorVM>("sp_GetAllInsightIndicator", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllVMLst;
            }
        }
        //LinkIndicatorCreate
        public static StatusModel linkIndicatorCreateDL(CreateLinkIndicatorVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Project_ID", m.Project_ID);
                ObjParm.Add("@Batch_ID", m.Batch_ID);
                ObjParm.Add("@Indicator_ID", m.Indicator_ID);

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_LinkIndicatorCreate", ObjParm, commandType: CommandType.StoredProcedure);

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
        //GetALLLinkIndicator
        public static List<GetAllLinkIndicatorVM> getALLLinkIndicatorDL()
        {
            List<GetAllLinkIndicatorVM> getVMLst = new List<GetAllLinkIndicatorVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                getVMLst = conn.Query<GetAllLinkIndicatorVM>("sp_GetAllLinkIndicator", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getVMLst;
            }
        }

        #region indicatorFieldValueCreateBL
        public static StatusModel InsightIndicatorFieldValueCreateDL(DataTable dt, CreateInsightIndicatorValueVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                m.FromDate = DateTime.Now;
                m.ToDate = DateTime.Now;
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@objIFV", dt.AsTableValuedParameter("udt_IndicatorFieldValue"));
                ObjParm.Add("@Project_ID", m.Project_ID);
                ObjParm.Add("@FromDate", m.FromDate);
                ObjParm.Add("@ToDate", m.ToDate);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_sp_IndicatorFieldValueCeateMulti", ObjParm, commandType: CommandType.StoredProcedure);

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
        //public static List<ComboIndicator> getComboIndicatorDL(int Project_ID, int BatchID)
        //{
        //    List<ComboIndicator> ComboLst = new List<ComboIndicator>();

        //    using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
        //    {
        //        conn.Open();
        //        DynamicParameters ObjParm = new DynamicParameters();
        //        ObjParm.Add("@Project_ID", Project_ID);
        //        ObjParm.Add("@Batch_ID", BatchID);
        //        ComboLst = conn.Query<ComboIndicator>("sp_GetIndicatorBaseOnBatch", ObjParm, commandType: CommandType.StoredProcedure).ToList();
        //        conn.Close();
        //        conn.Dispose();
        //        return ComboLst;
        //    }
        //}

        public static List<InsightIndicatorDataTypeVM> getndicatorDataTypeDL(int InsightIndicatorID)
        {
            List<InsightIndicatorDataTypeVM> DataTypeLst = new List<InsightIndicatorDataTypeVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@InsightIndicatorID", InsightIndicatorID);
                DataTypeLst = conn.Query<InsightIndicatorDataTypeVM>("sp_GetIndicatorFieldBaseOnIndicator", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return DataTypeLst;
            }
        }
        public static List<InsightIndicatorDataTypeConvertVM> getIndicatorInsertedFieldBaseOnIndicatorDL( int InsightIndicatorID)
        {
            List<InsightIndicatorDataTypeConvertVM> DataTypeLst = new List<InsightIndicatorDataTypeConvertVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@InsightIndicatorID", InsightIndicatorID);
                DataTypeLst = conn.Query<InsightIndicatorDataTypeConvertVM>("sp_GetIndicatorInsertedFieldBaseOnIndicator", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return DataTypeLst;
            }
        }

    }
}
