using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class MainModel
    {

        #region NAV
        public partial class NavParentMenu
        {
            public int NavParentMenuID { get; set; }
            public string NavParentMenuTitle { get; set; }
            public int SeqNo { get; set; }
        }

        public partial class NavChildMenu
        {
            public int NavParentMenu_ID { get; set; }
            public int NavChildMenuID { get; set; }
            public string ChildMenuName { get; set; }
            public int ChildSeqNo { get; set; }
            public string Controller { get; set; }
        
        }
        public partial class NavSubChild
        {
            public int NavChild_ID { get; set; }
            public int NavSubChildID { get; set; }
            public string NavSubChildName { get; set; }
            public int SubChildSeqNo { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
        }
        #endregion


        public partial class User
        {
            public int UserID { get; set; }
            public int Role_ID { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string ContactNo { get; set; }
            public string CNICNo { get; set; }
            public string Password { get; set; }
            public string Photo { get; set; }
            public bool IsActive { get; set; }
            public string Address { get; set; }
        }
        public partial class Role
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
        }
        public partial class Category
        {
            public int CategoryID { get; set; }
            public string categoryName { get; set; }
        }
        public partial class City
        {
            public int CityID { get; set; }
            public string CityName { get; set; }
        }
        public partial class DigitalPolicy
        {
            public int DigitalPolicyID { get; set; }
            public string DigitalPolicyName { get; set; }
        }
        public partial class SDGS
        {
            public int SDGSID { get; set; }
            public string SDGSName { get; set; }
        }
        public partial class ProjectStatus
        {
            public int ProjectStatusID { get; set; }
            public string ProjectStatusName { get; set; }
        }
        public partial class ProjectObjective
        {
            public int ObjectiveID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }

            public string ObjectiveName { get; set; }
            public int CreatedByUser_ID { get; set; }
        }
        public partial class ProjectPlannedKPIs
        {
            //Project KPIs\
            public int ProjectPlannedKPIsID { get; set; }
            public string IndicatorDescription { get; set; }
            public int Target { get; set; }
            public System.DateTime TimeLine { get; set; }
        }
        public partial class ProjectKPIsStatus
        {
            //Project KPIs\
            public int ProjectKPIsStatusID { get; set; }
            public int ProjectPlannedKPIs_ID { get; set; }
            public int Target { get; set; }
            public int ProjectKPIsAchived { get; set; }
            public System.DateTime TimeLine { get; set; }
            public string Remarks { get; set; }
        }
        public partial class Schedule
        {
            public int ScheduleID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public System.DateTime PlannedDate { get; set; }
            public System.DateTime StartDate { get; set; }
            public System.DateTime EndDate { get; set; }
            public int User_ID { get; set; }
        }
        public partial class PlannedProcurement
        {
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            public int ProcurementID { get; set; }
            public string ProcrumetHeader { get; set; }
            public int PlannedProcrumentNo { get; set; }
            public int PlannedPerCostItem { get; set; }
            public int AchivedCost { get; set; }

        }
        public partial class Risk
        {
            public int RiskID { get; set; }
            public int RiskStatus_ID { get; set; }
            public int RiskMitigation_ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public string RiskName { get; set; }
            public string RiskStatus { get; set; }
            public int CreatedByUser_ID { get; set; }
        }
        public partial class Stackholder
        {

            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            public int StackholderID { get; set; }
            public int TypeOfStakeholder_ID { get; set; }
            
            public string StackholderName { get; set; }
            public string StackholderDepartment { get; set; }
            public string StackholderContact { get; set; }
            public string StackholderEmail { get; set; }

        }

        
        public partial class ProjectType
        {
            public int ProjectTypeID { get; set; }
            public string ProjectTypeName { get; set; }
        }
        public partial class Project
        {
            public int ProjectID { get; set; }
            public int Category_ID { get; set; }
            public int ProjectType_ID { get; set; }
            public int DigitalPolicy_ID { get; set; }
            public int City_ID { get; set; }
            public int User_ID { get; set; }
            public string Name { get; set; }
            public long PlannedBudget { get; set; }
            public long ApprovedBudget { get; set; }
            public string Funding_Source { get; set; }
            public int PlannedHR { get; set; }
            public string ProjectGoal { get; set; }
        }
        public partial class Released_Budget
        {
            
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ReleasedBudgetID { get; set; }
            public long ReleasedBudget { get; set; }
            public System.DateTime ReleasedDate { get; set; }
            public string Remarks { get; set; }
           
        }
        public partial class RiskStatus
        {
            public int RiskStatusID { get; set; }
            public string RiskStatusName { get; set; }    
        }
        public partial class RiskMitigation
        {
            public int RiskMitigationID { get; set; }
            public string RiskMitigationName { get; set; }
        }

        public partial class Expenditure_Budget
        {
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            //Expenditure
            public int ExpenditureBudgetID { get; set; }
            [Required(ErrorMessage = "Select To Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ExpenditureDate { get; set; }
            public string BudgetHead { get; set; }
            public long ApprovedCost { get; set; }
            public long ExpenditureBudget { get; set; }
        }
        public partial class Issues
        {
            public int IssuesID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string IssueDescription { get; set; }
            public DateTime IssuesDate { get; set; }
            public string ActionTaken { get; set; }
            public string Solution { get; set; }
            public string Remarks { get; set; }
        }
        public partial class Recruited_HR
        {
            public int RecruitedHRID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            [Required(ErrorMessage = "Please Select Batch")]
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string PositionTitle { get; set; }
            public int Grade { get; set; }
            public int RecruitedHR { get; set; }
            [Required(ErrorMessage = "Enter From Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime RecruitedFromHRDate { get; set; }
            [Required(ErrorMessage = "Enter To Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime RecruitedToHRDate { get; set; }
            public string Remarks { get; set; }

        }

        public partial class AchievedProcurements
        {
            public int Project_ID { get; set; }
            //[Required(ErrorMessage = "Please Select SubProject")]
            public int SubProject_ID { get; set; }
            [Range(0, int.MaxValue, ErrorMessage = " Select Batch")]
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int PlannedProcurement_ID { get; set; }
            public int ApproveCostPerItem { get; set; }

            [Required(ErrorMessage = "Enter From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ProcurementDate { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Enter Procurement-Value")]
            public int AchievedProcurement { get; set; }

            public int ActualCostPerItem { get; set; }
            public int TotalCost { get; set; }
            [Required(ErrorMessage = "Enter From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime EntryDate { get; set; }
            public string Remarks { get; set; }
        }
        public partial class InsightIndicatorField
        {
            public int InsightIndicator_ID { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public int InsightIndicatorDataType_ID { get; set; }
          

        }


    }
}
