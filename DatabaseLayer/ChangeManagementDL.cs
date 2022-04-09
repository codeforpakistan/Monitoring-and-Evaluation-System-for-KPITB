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
        public static ChangeManagementVM GetChangeManagementDataDL(int _ProjectID)
        {
            ChangeManagementVM returnList = new ChangeManagementVM();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(Common.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ProjectID", _ProjectID);
                using (var gridReader = Con.QueryMultiple("sp_GetChangeManagementData", ObjParm, commandType: CommandType.StoredProcedure))
                {
                    returnList.Change_ManagementProjectList = gridReader.Read<Change_ManagementProject>().ToList();
                    returnList.Change_ManagementScheduleList = gridReader.Read<Change_ManagementSchedule>().ToList();
                    returnList.Change_ManagementPlannedKPIList = gridReader.Read<Change_ManagementPlannedKPI>().ToList();
                    returnList.Change_ManagementPlannedProcurementList = gridReader.Read<Change_ManagementPlannedProcurement>().ToList();
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

        public static StatusModel changeManagementCreateDL(ChangeManagementVM m, int LoginUerID)
        {
            StatusModel status = new StatusModel();
  

            int ChangeManagementID = 0; int ProjectHstoryID = 0; int ScheduleHistoryID = 0; int PlannedKPIsHistoryID = 0; int PlannedProcurementHistoryID = 0;
            try
            {
                string concatDecision = null;
                string concatActionTaken = null;
                StatusModel statusModel = new StatusModel();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    
                    //changeManagementProject
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@MeetingNo", m.MeetingNo);
                    ObjParm.Add("@MeetingDate", m.MeetingDate);
                    ObjParm.Add("@CreatedByUser_ID", LoginUerID);
                 
                    statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagement", ObjParm, "@ChangeManagementID", ref ChangeManagementID);
                     
                    //Project - ProjectHistory
                    for (int i = 0; i < m.Change_ManagementProjectList.Count; i++)
                    {
                        DynamicParameters ObjParm2 = new DynamicParameters();
                        ObjParm2.Add("@Project_ID", m.Change_ManagementProjectList[i].ProjectID);
                        ObjParm2.Add("@PlannedBudget", m.Change_ManagementProjectList[i].ChangeValuePlannedBudget); 
                        ObjParm2.Add("@ApprovedBudget", m.Change_ManagementProjectList[i].ChangeValueApprovedBudget);
                        ObjParm2.Add("@PlannedHR", m.Change_ManagementProjectList[i].ChangeValuePlannedHR);
                        ObjParm2.Add("@CreatedByUser_ID", LoginUerID);
                      
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementProject", ObjParm2, "@ProjectHistoryID", ref ProjectHstoryID);
                       
                        concatDecision = null;
                        concatDecision = "ApprovedBudget:" + m.Change_ManagementProjectList[i].DecisionApprovedBudget;
                        concatDecision += ",PlannedBudget:" + m.Change_ManagementProjectList[i].DecisionPlannedBudget;
                        concatDecision += ",PlannedHR:" + m.Change_ManagementProjectList[i].DecisionPlannedHR;
                        concatActionTaken = null;
                        concatActionTaken = "ApprovedBudget:" + m.Change_ManagementProjectList[i].ActionTakenApprovedBudget;
                        concatActionTaken += ",PlannedBudget:" + m.Change_ManagementProjectList[i].ActionTakenPlannedBudget;
                        concatActionTaken += ",PlannedHR:" + m.Change_ManagementProjectList[i].ActionTakenPlannedHR;

                        DynamicParameters Objcommon = new DynamicParameters();
                        Objcommon.Add("@Decision", concatDecision);
                        Objcommon.Add("@ActionTaken", concatActionTaken);
                        Objcommon.Add("@ChangeManagement_ID", ChangeManagementID);
                        Objcommon.Add("@Project_ID", m.Change_ManagementProjectList[i].ProjectID);
                        Objcommon.Add("@ProjectHistory_ID", ProjectHstoryID);
                        Objcommon.Add("@CreatedByUser_ID", LoginUerID);
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementDetails", Objcommon);

                    }

                    //Schedule - ScheduleHistory
                    for (int i = 0; i < m.Change_ManagementScheduleList.Count; i++)
                    {
                        DynamicParameters ObjParm2 = new DynamicParameters();
                        ObjParm2.Add("@Schedule_ID", m.Change_ManagementScheduleList[i].ScheduleID);
                        ObjParm2.Add("@Project_ID", m.Change_ManagementScheduleList[i].Project_ID);
                        ObjParm2.Add("@SubProject_ID", m.Change_ManagementScheduleList[i].SubProject_ID);
                        ObjParm2.Add("@PlannedDate", Convert.ToDateTime(m.Change_ManagementScheduleList[i].PlannedDateValue));
                        ObjParm2.Add("@StartDate", Convert.ToDateTime(m.Change_ManagementScheduleList[i].StartDateValue));
                        ObjParm2.Add("@EndDate", Convert.ToDateTime(m.Change_ManagementScheduleList[i].EndDateValue));
                        ObjParm2.Add("@CreatedByUser_ID", LoginUerID); 
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementSchedule", ObjParm2, "@ScheduleHistoryID", ref ScheduleHistoryID);
                        
                        concatDecision = null;
                        concatDecision = "PlannedDate:" + m.Change_ManagementScheduleList[i].DecisionPlannedDate;
                        concatDecision += ",StartDate:" + m.Change_ManagementScheduleList[i].DecisionStartDate;
                        concatDecision += ",EndDate:" + m.Change_ManagementScheduleList[i].DecisionEndDate;
                        concatActionTaken = null;
                        concatActionTaken = "PlannedDate:" + m.Change_ManagementScheduleList[i].DecisionPlannedDate;
                        concatActionTaken += ",StartDate:" + m.Change_ManagementScheduleList[i].DecisionStartDate;
                        concatActionTaken += ",EndDate:" + m.Change_ManagementScheduleList[i].DecisionEndDate;

                        DynamicParameters Objcommon = new DynamicParameters();
                        Objcommon.Add("@Decision", concatDecision);
                        Objcommon.Add("@ActionTaken", concatActionTaken);
                        Objcommon.Add("@ChangeManagement_ID", ChangeManagementID);
                        Objcommon.Add("@Project_ID", m.Change_ManagementScheduleList[i].Project_ID);
                        Objcommon.Add("@Schedule_ID", m.Change_ManagementScheduleList[i].ScheduleID);
                        Objcommon.Add("@ScheduleHistory_ID", ScheduleHistoryID);
                        Objcommon.Add("@CreatedByUser_ID", LoginUerID);
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementDetails", Objcommon);
                    }

                    //KPI - KPIHistory
                    for (int i = 0; i < m.Change_ManagementPlannedKPIList.Count; i++)
                    {
                        DynamicParameters ObjParm3 = new DynamicParameters();
                        ObjParm3.Add("@PlannedKPIsID", m.Change_ManagementPlannedKPIList[i].PlannedKPIsID);
                        ObjParm3.Add("@Project_ID", m.Change_ManagementPlannedKPIList[i].Project_ID);
                        ObjParm3.Add("@SubProject_ID", m.Change_ManagementPlannedKPIList[i].SubProject_ID);
                        ObjParm3.Add("@IndicatorDescription", m.Change_ManagementPlannedKPIList[i].IndicatorDescriptionValue);
                        ObjParm3.Add("@Target", m.Change_ManagementPlannedKPIList[i].TargetValue);
                        ObjParm3.Add("@TimeLine", Convert.ToDateTime(m.Change_ManagementPlannedKPIList[i].TimeLineValue));
                        ObjParm3.Add("@CreatedByUser_ID", LoginUerID);
                    
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementKPIs", ObjParm3, "@PlannedKPIsHistoryID", ref PlannedKPIsHistoryID);
                        
                        concatDecision = null;
                        concatDecision = "IndicatorDescription:" + m.Change_ManagementPlannedKPIList[i].DecisionIndicatorDescription;
                        concatDecision += ",Target:" + m.Change_ManagementPlannedKPIList[i].DecisionTarget;
                        concatDecision += ",TimeLine:" + m.Change_ManagementPlannedKPIList[i].DecisionTimeLine;
                        concatActionTaken = null;
                        concatActionTaken = "IndicatorDescription:" + m.Change_ManagementPlannedKPIList[i].DecisionIndicatorDescription;
                        concatActionTaken += ",Target:" + m.Change_ManagementPlannedKPIList[i].DecisionTarget;
                        concatActionTaken += ",TimeLine:" + m.Change_ManagementPlannedKPIList[i].DecisionTimeLine;
                        
                        DynamicParameters Objcommon = new DynamicParameters();
                        Objcommon.Add("@CreatedByUser_ID", LoginUerID);
                        Objcommon.Add("@Decision", concatDecision);
                        Objcommon.Add("@ActionTaken", concatActionTaken);
                        Objcommon.Add("@ChangeManagement_ID", ChangeManagementID);
                        Objcommon.Add("@Project_ID", m.Change_ManagementPlannedKPIList[i].Project_ID);
                        Objcommon.Add("@ProjectPlannedKPIs_ID", m.Change_ManagementPlannedKPIList[i].PlannedKPIsID);
                        Objcommon.Add("@ProjectPlannedKPIsHistory_ID", PlannedKPIsHistoryID);
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementDetails", Objcommon);

                    }

                    //Procurement - ProcurementHistory
                    for (int i = 0; i < m.Change_ManagementPlannedProcurementList.Count; i++)
                    {
                        DynamicParameters ObjParm4 = new DynamicParameters();
                        ObjParm4.Add("@PlannedProcurementID", m.Change_ManagementPlannedProcurementList[i].PlannedProcurementID);
                        ObjParm4.Add("@Project_ID", m.Change_ManagementPlannedProcurementList[i].Project_ID);
                        ObjParm4.Add("@SubProject_ID", m.Change_ManagementPlannedProcurementList[i].SubProject_ID);
                        ObjParm4.Add("@ProcrumetHeader", m.Change_ManagementPlannedProcurementList[i].ProcrumetHeaderValue);
                        ObjParm4.Add("@PlannedProcrumentNo", m.Change_ManagementPlannedProcurementList[i].PlannedProcrumentNoValue);
                        ObjParm4.Add("@PlannedPerCostItem", m.Change_ManagementPlannedProcurementList[i].PlannedPerCostItemValue);
                        ObjParm4.Add("@AchivedCost", m.Change_ManagementPlannedProcurementList[i].AchivedCostValue);
                        ObjParm4.Add("@EntryDate",DateTime.Now);
                        ObjParm4.Add("@CreatedByUser_ID", LoginUerID);
                       
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementProcurement", ObjParm4, "@PlannedProcurementHistoryID", ref PlannedProcurementHistoryID);
                        concatDecision = null;
                        concatDecision = "AchivedCost:" + m.Change_ManagementPlannedProcurementList[i].AchivedCostDescription;
                        concatDecision += ",PlannedPerCostItem:" + m.Change_ManagementPlannedProcurementList[i].PlannedPerCostItemDescription;
                        concatDecision += ",PlannedProcrumentNo:" + m.Change_ManagementPlannedProcurementList[i].PlannedProcrumentNoDescription;
                        concatDecision += ",ProcrumetHeader:" + m.Change_ManagementPlannedProcurementList[i].ProcrumetHeaderDescription;
                        concatActionTaken = null;
                        concatActionTaken = "AchivedCost:" + m.Change_ManagementPlannedProcurementList[i].ActionTakenAchivedCost;
                        concatActionTaken += ",PlannedPerCostItem:" + m.Change_ManagementPlannedProcurementList[i].ActionTakenPlannedPerCostItem;
                        concatActionTaken += ",PlannedProcrumentNo:" + m.Change_ManagementPlannedProcurementList[i].ActionTakenPlannedProcrumentNo;
                        concatActionTaken += ",ProcrumetHeader:" + m.Change_ManagementPlannedProcurementList[i].ActionTakenProcrumetHeader;

                        DynamicParameters Objcommon = new DynamicParameters();
                        Objcommon.Add("@CreatedByUser_ID", LoginUerID);
                        Objcommon.Add("@Decision", concatDecision);
                        Objcommon.Add("@ActionTaken", concatActionTaken);
                        Objcommon.Add("@ChangeManagement_ID", ChangeManagementID);
                        Objcommon.Add("@Project_ID", m.Change_ManagementPlannedProcurementList[i].Project_ID);
                        Objcommon.Add("@PlannedProcurement_ID", m.Change_ManagementPlannedProcurementList[i].PlannedProcurementID);
                        Objcommon.Add("@PlannedProcurementHistory_ID", PlannedProcurementHistoryID);
                        statusModel = Repose.ExcuteNonQueryWithStatusModel("sp_changeManagementDetails", Objcommon);
                    }

                    status.status = true;
                    status.statusDetail = "All Record Saved Succefully.";
                    transactionScope.Complete();
                    transactionScope.Dispose();
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
