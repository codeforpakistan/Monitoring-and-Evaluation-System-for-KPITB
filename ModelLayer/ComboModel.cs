using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ComboModel
    {
        #region CommonCombo
        public class CommonCombo
        {
            public List<ComboProject> comboProject = new List<ComboProject>();
            public List<ComboSubProject> comboSubProjects = new List<ComboSubProject>();
            public List<ComboBatch> comboBatch = new List<ComboBatch>();
        }
        #endregion

        #region ComboRole
        public partial class ComboRole
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
        }
        #endregion

        #region ComboCategory
        public partial class ComboCategory
        {
            public int CategoryID { get; set; }
            public string categoryName { get; set; }
        }
        #endregion

        #region ComboProjectType
        public partial class ComboProjectType
        {
            public int ProjectTypeID { get; set; }
            public string ProjectTypeName { get; set; }
        }
        #endregion
        #region Project Status
        public partial class ComboProjectStatus
        {
            public int ProjectStatusID { get; set; }
            public string ProjectStatusName { get; set; }
        }
        #endregion
        #region ComboCity
        public partial class ComboCity
        {
            public int CityID { get; set; }
            public string CityName { get; set; }
        }
        #endregion

        #region SDGS
        public partial class ComboSDGS
        {
            public int SDGSID { get; set; }
            public string SDGSName { get; set; }
        }
        #endregion
        #region ComboDigitalPolicy
        public partial class ComboDigitalPolicy
        {
            public int DigitalPolicyID { get; set; }
            public string DigitalPolicyName { get; set; }
        }
        #endregion

        #region RiskStatus/Mitigation
        public partial class ComboRiskStatus
        {
            public int RiskStatusID { get; set; }
            public string RiskStatusName { get; set; }
        }
        public partial class ComboRiskMitigation
        {
            public int RiskMitigationID { get; set; }
            public string RiskMitigationName { get; set; }
        }

        #endregion

        #region FundingSource
        public partial class ComboFundingSource
        {
            public int FundingSourceID { get; set; }
            public string FundingSourceName { get; set; }
        }
        #endregion
        #region TypeOfStakeholder
        public partial class ComboTypeOfStakeholder
        {
            public int TypeOfStakeholderID { get; set; }
            public string TypeOfStakeholderName { get; set; }
        }

        #endregion
        #region Project
        public partial class ComboProject
        {
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
        }
        public partial class ComboSubProject
        {
            public int SubProjectID { get; set; }
            public string SubProjectName { get; set; }
        }
        public partial class ComboBatch
        {
            public int BatchID { get; set; }
            public string BatchName { get; set; }
        }
        public partial class ComboPlannedKPIs
        {
            public int PlannedKPIsID { get; set; }
            public string IndicatorDescription { get; set; }
            public int Target { get; set; }
            public System.DateTime TimeLine { get; set; }

        }
        public partial class ComboIndicator
        {
            public int InsightIndicatorID { get; set; }
            public string InsightIndicatorName { get; set; }
        }

        public partial class ChangeManagement
        {
            public int ProjectID { get; set; }
            public string ItemName { get; set; }

            public string CurrentValue { get; set; }
            public string ChangeValue { get; set; }
            public string Decision { get; set; }
            public string ActionTaken { get; set; }

            public string PlannedBudget { get; set; }
            public int PlannedBudgetValue { get; set; }
            public string ApprovedBudget { get; set; }
            public int ApprovedBudgetValue { get; set; }
            public string PlannedHR { get; set; }
            public int PlannedHRValue { get; set; }
        }

        public partial class ComboProcurementHead
        {
            public int PlannedProcurementID { get; set; }
            public string ProcrumetHeader { get; set; }
            public int PlannedPerCostItem { get; set; }

        }

        public partial class RemainingValues
        {
            public int RemainingPlannedHR { get; set; }
            public int RemainingProcurement { get; set; }
            public int RemainingBudget { get; set; }
            public int ApprovedBudget { get; set; }
            public int ReleasedBudget { get; set; }

        }
        public partial class ComboInsightIndicatorDataType
        {
            public int InsightIndicatorDataTypeID { get; set; }
            public string InsightIndicatorDataType { get; set; }
        }
        #endregion


    }
}
