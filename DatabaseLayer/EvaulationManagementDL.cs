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
using static ModelLayer.MainViewModel;

namespace DatabaseLayer
{
    public class EvaulationManagementDL
    {
        public static KPIsANDInsightIndicatorVM InsightIndicatorForEvaulationDL(int _ProjectID, int?  SubProject_ID, int? Batch_ID)
        {
            IDbConnection Con = null;
            KPIsANDInsightIndicatorVM returnList = new KPIsANDInsightIndicatorVM();
            List<InsightIndicatorForEvaulation> ListInsightIndicator = new List<InsightIndicatorForEvaulation>();
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Project_ID", _ProjectID);
                ObjParm.Add("@SubProject_ID", SubProject_ID);
                ObjParm.Add("@Batch_ID", Batch_ID);
                using (var gridReader = Con.QueryMultiple("sp_GetInsightIndicatorForEvaulation", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    returnList.ListInsightIndicator = gridReader.Read<InsightIndicatorForEvaulation>().ToList();
                    returnList.ListKPIs = gridReader.Read<KPIsForEvaulation>().ToList();
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
            return returnList;
        }
            
        public static StatusModel InsertEvaulationDL(CreateProjectKPIsStatusVM modelVM)
        {
            StatusModel statusModel = new StatusModel();                                                 
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    #region MyRegion

                    //DataTable dtKPI = new DataTable();
                    ////dtKPI.Columns.Add("InsightIndicator_ID", typeof(int));
                    //dtKPI.Columns.Add("ProjectKPIsStatus_ID", typeof(int));
                    //dtKPI.Columns.Add("EvaluationID", typeof(int));
                    //dtKPI.Columns.Add("Project_ID", typeof(int));
                    //dtKPI.Columns.Add("SubProject_ID", typeof(int));
                    //dtKPI.Columns.Add("Batch_ID", typeof(string));
                    //dtKPI.Columns.Add("FeedbackType", typeof(string));
                    //dtKPI.Columns.Add("InsightIndicatorRemarks", typeof(string));

                    //for (int i = 0; i < modelVM.ListKPIs.Count; i++)
                    //{
                    //    dtKPI.Rows.Add(modelVM.ListKPIs[i].ProjectKPIsStatusID, modelVM.ListKPIs[i].PlannedKPIsID,
                    //                                    0, modelVM.ListKPIs[i].Project_ID, modelVM.ListKPIs[i].SubProject_ID, modelVM.ListKPIs[i].Batch_ID,
                    //                                    modelVM.ListKPIs[i].Feedback, modelVM.ListKPIs[i].Remarks);
                    //}

                    //DataTable dtIndicator = new DataTable();
                    //dtIndicator.Columns.Add("InsightIndicator_ID", typeof(int));
                    //dtIndicator.Columns.Add("Evaluation_ID", typeof(int));
                    //dtIndicator.Columns.Add("Project_ID", typeof(int));
                    //dtIndicator.Columns.Add("SubProject_ID", typeof(string));
                    //dtIndicator.Columns.Add("Batch_ID", typeof(int));
                    //dtIndicator.Columns.Add("FeedbackType", typeof(int));
                    //dtIndicator.Columns.Add("Remarks", typeof(int));

                    //for (int i = 0; i < modelVM.ListInsightIndicator.Count; i++)
                    //{
                    //    dtIndicator.Rows.Add(modelVM.ListInsightIndicator[i].InsightIndicatorID, 0, modelVM.ListInsightIndicator[i].Project_ID,
                    //                                              modelVM.ListInsightIndicator[i].SubProject_ID, modelVM.ListInsightIndicator[i].Batch_ID,
                    //                                              modelVM.ListInsightIndicator[i].Feedback, modelVM.ListInsightIndicator[i].Remarks);
                    //} 
                    #endregion

                  

                    DynamicParameters ObjParm2 = new DynamicParameters();
                    //LoginUser
                    //ObjParm2.Add("@KPI", dtKPI.AsTableValuedParameter("udt_Evaluation"));
                    //ObjParm2.Add("@Indicator", dtIndicator.AsTableValuedParameter("udt_Evaluation"));
                    ObjParm2.Add("@Project_ID", modelVM.Project_ID);   //LoginUser
                    ObjParm2.Add("@SubProject_ID", modelVM.SubProject_ID);
                    ObjParm2.Add("@Batch_ID", modelVM.Batch_ID);
                    ObjParm2.Add("@EvaluationType", modelVM.EvaluationType);
                    ObjParm2.Add("@VisistStatus", modelVM.VisistStatus);
                    ObjParm2.Add("@VisitDate", modelVM.VisitDate);
                    ObjParm2.Add("@Agenda", modelVM.Agenda);
                    ObjParm2.Add("@EvaluationRemarks", modelVM.EvaluationRemarks);
                    statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_EvaluationCeate", ObjParm2);

                    transactionScope.Complete();
                    transactionScope.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return statusModel;
           
        }





    }
}
