using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class StoreProcModel
    {
        #region Dashboardv1

        #region 1Linear
        public class OneLinearRow1
        {
            public int TotalApprovedBudget { get; set; }
            public int TotalReleasedBudget { get; set; }
            public int PerReleasedBudget { get; set; }
        }
        public class OneLinearRow2
        {
            public int DigitalAccess { get; set; }
            public int DigitalGovernance { get; set; }
            public int DigitalEconomy { get; set; }
            public int DigitalSkills { get; set; }
        }
        public class OneLinearRow3
        {
            public int NOPOVERTY { get; set; }
            public int SDGS2 { get; set; }
        }
        public class OneLinearRow4Project
        {
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
        }
        public class OneLinearRow4SubProject
        {
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
            public int SubProjectID { get; set; }
            public string SubProjectName { get; set; }
        }
        public class OneLinearVM
        {
            public OneLinearVM()
            {
                oneLinearRow1 = new OneLinearRow1();
                oneLinearRow2 = new OneLinearRow2();
                oneLinearRow3 = new OneLinearRow3();
                oneLinearRow4Project = new List<OneLinearRow4Project>();
                oneLinearRow4SubProject = new List<OneLinearRow4SubProject>();
            }
            public OneLinearRow1 oneLinearRow1 { get; set; }
            public OneLinearRow2 oneLinearRow2 { get; set; }
            public OneLinearRow3 oneLinearRow3 { get; set; }
            public List<OneLinearRow4Project> oneLinearRow4Project { get; set; }
            public List<OneLinearRow4SubProject> oneLinearRow4SubProject { get; set; }

        }
        #endregion
        #region ADP
        public class ADPRow1
        {
            public int TotalApprovedBudget { get; set; }
            public int TotalReleasedBudget { get; set; }
            public int PerReleasedBudget { get; set; }
        }
        public class ADPRow2
        {
            public int DigitalAccess { get; set; }
            public int DigitalGovernance { get; set; }
            public int DigitalEconomy { get; set; }
            public int DigitalSkills { get; set; }
        }
        public class ADPRow3
        {
            public int NOPOVERTY { get; set; }
            public int SDGS2 { get; set; }
        }
        public class ADPRow4Project
        {
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
        }
        public class ADPRow4SubProject
        {
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
            public int SubProjectID { get; set; }
            public string SubProjectName { get; set; }
        }

        public class ADPVM
        {
            public ADPVM()
            {
               ADPRow1 = new ADPRow1();
               ADPRow2 = new ADPRow2();
               ADPRow3 = new ADPRow3();
                ADPRow4Project = new List<ADPRow4Project>();
                ADPRow4SubProject = new List<ADPRow4SubProject>();
            }
            public ADPRow1 ADPRow1 { get; set; }
            public ADPRow2 ADPRow2 { get; set; }
            public ADPRow3 ADPRow3 { get; set; }
            public List<ADPRow4Project> ADPRow4Project { get; set; }
            public List<ADPRow4SubProject> ADPRow4SubProject { get; set; }

        }

        #endregion
        #region ForigenFunded
        public class ForigenFundedRow1
        {
            public int TotalApprovedBudget { get; set; }
            public int TotalReleasedBudget { get; set; }
            public int PerReleasedBudget { get; set; }
        }
        public class ForigenFundedRow2
        {
            public int DigitalAccess { get; set; }
            public int DigitalGovernance { get; set; }
            public int DigitalEconomy { get; set; }
            public int DigitalSkills { get; set; }
        }
        public class ForigenFundedRow3
        {
            public int NOPOVERTY { get; set; }
            public int SDGS2 { get; set; }
        }
        public class ForigenFundedRow4Project
        {
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
        }
        public class ForigenFundedRow4SubProject
        {
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
            public int SubProjectID { get; set; }
            public string SubProjectName { get; set; }
        }

        public class ForigenFundedVM
        {
            public ForigenFundedVM()
            {
                forigenFundedRow1 = new ForigenFundedRow1();
                forigenFundedRow2 = new ForigenFundedRow2();
                forigenFundedRow3 = new ForigenFundedRow3();
                forigenFundedRow4Project = new List<ForigenFundedRow4Project>();
                forigenFundedRow4SubProject = new List<ForigenFundedRow4SubProject>();
            }
            public ForigenFundedRow1 forigenFundedRow1 { get; set; }
            public ForigenFundedRow2 forigenFundedRow2 { get; set; }
            public ForigenFundedRow3 forigenFundedRow3 { get; set; }
            public List<ForigenFundedRow4Project> forigenFundedRow4Project { get; set; }
            public List<ForigenFundedRow4SubProject> forigenFundedRow4SubProject { get; set; }

        }

        #endregion
        public class Dashboardv1
        {
            public OneLinearVM oneLinearVM = new OneLinearVM();
            public ADPVM ADPVM = new ADPVM();
            public ForigenFundedVM forigenFundedVM = new ForigenFundedVM();
        }

        #endregion

        #region Dashboardv3
        public class dv3ProjectKPIs
        {
            public int Project_ID { get; set; }
            public int PlannedKPIs_ID { get; set; }
            public string IndicatorDescription { get; set; }
            public int Target { get; set; }
            public int Achived { get; set; }
            public float Percentage { get; set; }
        }
        public class dv3ImpactIndicator
        {
            public string ProjectName { get; set; }
            public string InsightIndicatorName { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public string InsightIndicatorValueText { get; set; }
            public int InsightIntegerValue { get; set; }
            public int BoolValue { get; set; }
            public float FloatValue { get; set; }
        }
        public class dv3ImpactIndicatorMerge
        {
            public string InsightIndicatorName { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public dynamic CommonFiled { get; set; }
        }
        public class dv3FinanceDetails
        {
            public int PlannedBudget { get; set; }
            public int AllocatedBudget { get; set; }
            public int ExpenditureBudget { get; set; }
            public int RemainingBudget { get; set; }
            public int FinancialDetails { get; set; }
        }
        public class dv3Schedule
        {
            public DateTime PlannedDate { get; set; }
            public DateTime ActualDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        public class dv3Issues
        {
            public string IssueDescription { get; set; }
            public string IssueDate { get; set; }
            public string ActionTaken { get; set; }
            public string Remarks { get; set; }
        }

        public class Dashboardv3
        {
            public Dashboardv3()
            {
                dv3ProjectKPIsLst = new List<dv3ProjectKPIs>();
                dv3ImpactIndicatorsLst = new List<dv3ImpactIndicator>();
                dv3ImpactIndicatorMergesLst = new List<dv3ImpactIndicatorMerge>();
                dv3FinanceDetailsLst = new List<dv3FinanceDetails>();
                dv3SchedulesLst = new List<dv3Schedule>();
                dv3IssuesLst = new List<dv3Issues>();

            }
            public List<dv3ProjectKPIs> dv3ProjectKPIsLst { get; set; }
            public List<dv3ImpactIndicator> dv3ImpactIndicatorsLst { get; set; }
            public List<dv3ImpactIndicatorMerge> dv3ImpactIndicatorMergesLst { get; set; }
            public List<dv3FinanceDetails> dv3FinanceDetailsLst { get; set; }
            public List<dv3Schedule> dv3SchedulesLst { get; set; }
            public List<dv3Issues> dv3IssuesLst { get; set; }
        }

        #endregion
    }
}
