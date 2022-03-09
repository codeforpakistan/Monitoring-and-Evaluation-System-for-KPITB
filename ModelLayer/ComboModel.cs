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
        public partial class ComboIndicator
        {
            public int IndicatorID { get; set; }
            public string IndicatorName { get; set; }
        }

        public partial class RemainingValues
        {
            public int RemainingPlannedHR { get; set; }
            public int RemainingProcurement { get; set; }
            public int RemainingBudget { get; set; }
            public int ApprovedBudget { get; set; }
            public int ReleasedBudget { get; set; }

        }
        public partial class ComboIndicatorDataType
        {
            public int IndicatorDataTypeID { get; set; }
            public string IndicatorDataType { get; set; }
        }
        #endregion


    }
}
