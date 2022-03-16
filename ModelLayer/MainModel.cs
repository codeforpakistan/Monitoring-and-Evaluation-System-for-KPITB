using System;
using System.Collections.Generic;
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
        public partial class Expenditure_Budget
    {
        public int ExpenditureBudgetID { get; set; }
        public int Project_ID { get; set; }
        public int SubProject_ID { get; set; }
        public int Batch_ID { get; set; }
        public System.DateTime ExpenditureDate { get; set; }
        public long ExpenditureBudget { get; set; }
        public string Remarks { get; set; }
        public int User_ID { get; set; }
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
            public string PlannedProcurement { get; set; }
            public int PlannedHR { get; set; }
            public long CostPerBeneficiary { get; set; }
            public int MaleBeneficiary { get; set; }
            public int FemalBeneficiary { get; set; }
            public String TotalBeneficiary { get; set; }
            public string Objective { get; set; }
        }
        public partial class Released_Budget
        {
            public int ReleasedBudgetID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public System.DateTime ReleasedDate { get; set; }
            public long ReleasedBudget { get; set; }
            public string Remarks { get; set; }
            public int User_ID { get; set; }
        }
        public partial class RiskStatus
        {
            public int RiskStatusID { get; set; }
            public string RiskStatusName { get; set; }    
        }
        public partial class Risk
        {
            public int RiskID { get; set; }
            public int RiskStatus_ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public string RiskName { get; set; }
            public string RiskStatus { get; set; }
            public int CreatedByUser_ID { get; set; }
        }
        public partial class RecruitedHR
        {
            public int RecruitedHRID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int User_ID { get; set; }
           // public int RecruitedHR { get; set; }
            public double RecruitedHRPercent { get; set; }
            public System.DateTime RecruitedHRDate { get; set; }
        }
        public partial class Procurement
        {
            public int AchievedProcurementID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int User_ID { get; set; }
            public int AchievedProcurement { get; set; }
            public double ProcurementPercent { get; set; }
            public System.DateTime ProcurementDate_ { get; set; }
        }
        public partial class Schedule
        {
            public int ScheduleID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public System.DateTime PlannedDate{ get; set; }
            public System.DateTime StartDate { get; set; }
            public System.DateTime EndDate { get; set; }
            public int User_ID { get; set; }
        }

        public partial class Stackholder
        {
            public int StackholderID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public string StackholderName { get; set; }
            public string StackholderDepartment { get; set; }
            public string StackholderContact { get; set; }
            public string StackholderEmail { get; set; }
            public int CreatedByUser_ID { get; set; }
        }
    }
}
