using DatabaseLayer;
using ModelLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class ChangeManagementBL
    {
        public ChangeManagementVM GetChangeManagementDataBL(int _ProjectID)
        {
            return ChangeManagementDL.GetChangeManagementDataDL(_ProjectID);
        }

        //CreateIssues
        public StatusModel changeManagementCreateBL(ChangeManagementVM m, int LoginUerID)
        {

            #region EXTRA

            //List<Change_ManagementProject> LProject = new List<Change_ManagementProject>();
            //Change_ManagementProject mdl = new Change_ManagementProject();
            //for (int i = 0; i < m.Change_ManagementProjectList.Where(w => w.ApprovedBudget == "ApprovedBudget").Count(); i++)
            //{
            //    mdl.ProjectID = m.Change_ManagementProjectList[i].ProjectID;
            //    mdl.ApprovedBudgetValue = m.Change_ManagementProjectList[i].ApprovedBudgetValue;
            //    mdl.PlannedBudgetValue = m.Change_ManagementProjectList[i].PlannedBudgetValue;
            //    mdl.PlannedHRValue = m.Change_ManagementProjectList[i].PlannedHRValue;
            //    mdl.DecisionApprovedBudget = m.Change_ManagementProjectList[i].DecisionApprovedBudget;
            //    mdl.DecisionPlannedBudget = m.Change_ManagementProjectList[i].DecisionPlannedBudget;
            //    mdl.DecisionPlannedHR = m.Change_ManagementProjectList[i].DecisionPlannedHR;
            //    mdl.ActionTakenApprovedBudget = m.Change_ManagementProjectList[i].ActionTakenApprovedBudget;
            //    mdl.ActionTakenPlannedBudget = m.Change_ManagementProjectList[i].ActionTakenPlannedBudget;
            //    mdl.ActionTakenPlannedHR = m.Change_ManagementProjectList[i].ActionTakenPlannedHR;
            //    LProject.Add(mdl);
            //}
            //m.Change_ManagementProjectList = LProject;


            //List<Change_ManagementSchedule> LSchedule = new List<Change_ManagementSchedule>();
            //Change_ManagementSchedule mdlSch = new Change_ManagementSchedule();
            //for (int i = 0; i < m.Change_ManagementScheduleList.Where(w => w.PlannedDate == "PlannedDate").Count(); i++)
            //{
            //    mdlSch.Project_ID = m.Change_ManagementScheduleList[i].Project_ID;
            //    mdlSch.SubProject_ID = m.Change_ManagementScheduleList[i].SubProject_ID;
            //    mdlSch.PlannedDateValue = m.Change_ManagementScheduleList[i].PlannedDateValue;
            //    mdlSch.StartDateValue = m.Change_ManagementScheduleList[i].StartDateValue;
            //    mdlSch.EndDateValue = m.Change_ManagementScheduleList[i].EndDateValue;
            //    mdlSch.DecisionPlannedDate = m.Change_ManagementScheduleList[i].DecisionPlannedDate;
            //    mdlSch.DecisionStartDate = m.Change_ManagementScheduleList[i].DecisionStartDate;
            //    mdlSch.DecisionEndDate = m.Change_ManagementScheduleList[i].DecisionEndDate;
            //    mdlSch.ActionTakenPlannedDate = m.Change_ManagementScheduleList[i].ActionTakenPlannedDate;
            //    mdlSch.ActionTakenStartDate = m.Change_ManagementScheduleList[i].ActionTakenStartDate;
            //    mdlSch.ActionTakenEndDate = m.Change_ManagementScheduleList[i].ActionTakenEndDate;
            //    LSchedule.Add(mdlSch);
            //}
            //m.Change_ManagementScheduleList = LSchedule;


            //List<Change_ManagementPlannedKPI> LKPIs = new List<Change_ManagementPlannedKPI>();
            //Change_ManagementPlannedKPI mdlKPIs = new Change_ManagementPlannedKPI();
            //for (int i = 0; i < m.Change_ManagementPlannedKPIList.Where(w => w.IndicatorDescription == "IndicatorDescription").Count(); i++)
            //{
            //    mdlKPIs.Project_ID = m.Change_ManagementPlannedKPIList[i].Project_ID;
            //    mdlKPIs.SubProject_ID = m.Change_ManagementPlannedKPIList[i].SubProject_ID;
            //    mdlKPIs.ChangeValueIndicatorDescription = m.Change_ManagementPlannedKPIList[i].ChangeValueIndicatorDescription;
            //    mdlKPIs.ChangeValueTarget = m.Change_ManagementPlannedKPIList[i].ChangeValueTarget;
            //    mdlKPIs.ChangeValueTimeLine = m.Change_ManagementPlannedKPIList[i].ChangeValueTimeLine;
            //    mdlKPIs.DecisionIndicatorDescription = m.Change_ManagementPlannedKPIList[i].DecisionIndicatorDescription;
            //    mdlKPIs.DecisionTarget = m.Change_ManagementPlannedKPIList[i].DecisionTarget;
            //    mdlKPIs.DecisionTimeLine = m.Change_ManagementPlannedKPIList[i].DecisionTimeLine;
            //    mdlKPIs.ActionTakenIndicatorDescription = m.Change_ManagementPlannedKPIList[i].ActionTakenIndicatorDescription;
            //    mdlKPIs.ActionTakenTarget = m.Change_ManagementPlannedKPIList[i].ActionTakenTarget;
            //    mdlKPIs.ActionTakenTimeLine = m.Change_ManagementPlannedKPIList[i].ActionTakenTimeLine;
            //    LKPIs.Add(mdlKPIs);
            //}
            //m.Change_ManagementPlannedKPIList = LKPIs;


            //List<Change_ManagementPlannedProcurement> LProcurement = new List<Change_ManagementPlannedProcurement>();
            //Change_ManagementPlannedProcurement mdlProcurement = new Change_ManagementPlannedProcurement();
            //for (int i = 0; i < m.Change_ManagementPlannedProcurementList.Where(w => w.ProcrumetHeader == "ProcrumetHeader").Count(); i++)
            //{
            //    mdlProcurement.Project_ID = m.Change_ManagementPlannedProcurementList[i].Project_ID;
            //    mdlProcurement.SubProject_ID = m.Change_ManagementPlannedProcurementList[i].SubProject_ID;
            //    mdlProcurement.ChangeValueProcrumetHeader = m.Change_ManagementPlannedProcurementList[i].ChangeValueProcrumetHeader;
            //    mdlProcurement.ChangeValuePlannedProcrumentNo = m.Change_ManagementPlannedProcurementList[i].ChangeValuePlannedProcrumentNo;
            //    mdlProcurement.ChangeValuePlannedPerCostItem = m.Change_ManagementPlannedProcurementList[i].ChangeValuePlannedPerCostItem;
            //    mdlProcurement.ChangeValueAchivedCost = m.Change_ManagementPlannedProcurementList[i].ChangeValueAchivedCost;
            //    mdlProcurement.AchivedCostDescription = m.Change_ManagementPlannedProcurementList[i].AchivedCostDescription;
            //    mdlProcurement.PlannedPerCostItemDescription = m.Change_ManagementPlannedProcurementList[i].PlannedPerCostItemDescription;
            //    mdlProcurement.PlannedProcrumentNoDescription = m.Change_ManagementPlannedProcurementList[i].PlannedProcrumentNoDescription;
            //    mdlProcurement.ProcrumetHeaderDescription = m.Change_ManagementPlannedProcurementList[i].ProcrumetHeaderDescription;
            //    mdlProcurement.ActionTakenAchivedCost = m.Change_ManagementPlannedProcurementList[i].ActionTakenAchivedCost;
            //    mdlProcurement.ActionTakenPlannedPerCostItem = m.Change_ManagementPlannedProcurementList[i].ActionTakenPlannedPerCostItem;
            //    mdlProcurement.ActionTakenPlannedProcrumentNo = m.Change_ManagementPlannedProcurementList[i].ActionTakenPlannedProcrumentNo;
            //    mdlProcurement.ActionTakenProcrumetHeader = m.Change_ManagementPlannedProcurementList[i].ActionTakenProcrumetHeader;
            //    LProcurement.Add(mdlProcurement);
            //}
            //m.Change_ManagementPlannedProcurementList = LProcurement; 

            #endregion

            return ChangeManagementDL.changeManagementCreateDL(m, LoginUerID);
        }
    }
}
