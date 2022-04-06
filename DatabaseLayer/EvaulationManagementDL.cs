using Dapper;
using ModelLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ModelLayer.MainViewModel;

namespace DatabaseLayer
{
    public class EvaulationManagementDL
    {
        public static KPIsANDInsightIndicatorVM InsightIndicatorForEvaulationDL(int _ProjectID)
        {
            KPIsANDInsightIndicatorVM returnList = new KPIsANDInsightIndicatorVM();
            List<InsightIndicatorForEvaulation> ListInsightIndicator = new List<InsightIndicatorForEvaulation>();
            try
            {

                var parameters = new Dictionary<string, object>
                {
                    { "Project_ID", "3021" }
                };
                //DynamicParameters queryArguments = new DynamicParameters();
                //queryArguments.Add(String.Format("p{0}", "@Project_ID"), _ProjectID);


                var EvaulationAndKPIs = Repose.GetMultiple("sp_GetInsightIndicatorForEvaulation1", null, gr => gr.Read<InsightIndicatorForEvaulation>(), gr => gr.Read<KPIsForEvaulation>());
                returnList.ListInsightIndicator = EvaulationAndKPIs.Item1.ToList();
                returnList.ListKPIs = EvaulationAndKPIs.Item2.ToList();
            }
            catch (Exception ex)
            {
                throw;
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
                    DataTable dtKPI = new DataTable();
                    dtKPI.Columns.Add("InsightIndicator_ID", typeof(int));
                    dtKPI.Columns.Add("ProjectKPIsStatus_ID", typeof(int));
                    dtKPI.Columns.Add("Evaluation_ID", typeof(int));
                    dtKPI.Columns.Add("Project_ID", typeof(int));
                    dtKPI.Columns.Add("SubProject_ID", typeof(int));
                    dtKPI.Columns.Add("Batch_ID", typeof(int));
                    dtKPI.Columns.Add("FeedbackType", typeof(string));
                    dtKPI.Columns.Add("InsightIndicatorRemarks", typeof(string));

                    for (int i = 0; i < modelVM.KPIandIndicatorList.ListKPIs.Count; i++)
                    { dtKPI.Rows.Add(modelVM.KPIandIndicatorList.ListKPIs[i]); }

                    DataTable dtIndicator = new DataTable();
                    dtIndicator.Columns.Add("InsightIndicator_ID", typeof(int));
                    dtIndicator.Columns.Add("ProjectKPIsStatus_ID", typeof(int));
                    dtIndicator.Columns.Add("Evaluation_ID", typeof(int));
                    dtIndicator.Columns.Add("Project_ID", typeof(int));
                    dtIndicator.Columns.Add("SubProject_ID", typeof(int));
                    dtIndicator.Columns.Add("Batch_ID", typeof(int));
                    dtIndicator.Columns.Add("FeedbackType", typeof(string));
                    dtIndicator.Columns.Add("InsightIndicatorRemarks", typeof(string));

                    for (int i = 0; i < modelVM.KPIandIndicatorList.ListInsightIndicator.Count; i++)
                    { dtIndicator.Rows.Add(modelVM.KPIandIndicatorList.ListInsightIndicator[i]); }

                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@KPI", dtKPI.AsTableValuedParameter("udt_Evaluation"));
                    ObjParm.Add("@Indicator", dtIndicator.AsTableValuedParameter("udt_Evaluation"));
                    statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_EvaluationCeate", ObjParm);

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
