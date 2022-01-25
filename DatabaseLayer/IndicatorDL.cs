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
    public static class IndicatorDL
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
        //IssuesCreate
        public static StatusModel indicatorCreateDL(CreateIndicatorVM m)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@IndicatorName", m.IndicatorName);
                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute("sp_IndicatorCreate", ObjParm, commandType: CommandType.StoredProcedure);

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
        //GetALLIndicator
        public static List<GetAllIndicatorVM> getAllIndicatorDL()
        {
            List<GetAllIndicatorVM> getAllVMLst = new List<GetAllIndicatorVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                getAllVMLst = conn.Query<GetAllIndicatorVM>("sp_GetAllIndicator", commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return getAllVMLst;
            }
        }

        //IssuesCreate
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

        public static List<IndicatorDataTypeVM> getndicatorDataTypeDL(int IndicatorID)
        {
            List<IndicatorDataTypeVM> DataTypeLst = new List<IndicatorDataTypeVM>();

            using (IDbConnection conn = new SqlConnection(Common.ConnectionString))
            {
                conn.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@IndicatorID", IndicatorID);
                DataTypeLst = conn.Query<IndicatorDataTypeVM>("sp_GetIndicatorFieldBaseOnIndicator", ObjParm, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                conn.Dispose();
                return DataTypeLst;
            }
        }


    }
}
