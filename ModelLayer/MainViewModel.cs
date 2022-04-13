using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ModelLayer.ComboModel;
using static ModelLayer.MainModel;

namespace ModelLayer
{
    public class MainViewModel
    {

        #region USERMODEL

        public partial class CreateUserVM
        {
            public CreateUserVM()
            {
                comboRoles = new List<ComboRole>();
            }
            public int UserID { get; set; }
            [Required(ErrorMessage = "Please Select Role")]
            [Display(Name = "Role")]
            public int Role_ID { get; set; }
            [Required(ErrorMessage = "Please Enter Full name")]
            public string FullName { get; set; }
            [Required(ErrorMessage = "Please Fill Email Address")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email")]
            [Display(Name = "Email Address")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Please Enter Contact No")]
            [StringLength(12, ErrorMessage = "Please Enter Contact without Dashes", MinimumLength = 11)]
            public string ContactNo { get; set; }
            //[Required(ErrorMessage = "Please Fill CNIC No")]
            //[StringLength(13, ErrorMessage = "Please Enter CNIC without Dashes.", MinimumLength = 13)]
            //public string CNICNo { get; set; }
            [NotMapped] // Does not effect with your database
            [Compare("ConfirmPassword")]
            [Required(ErrorMessage = "Password is not match")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must be at least 8 characters and cannot be longer than 12 characters")]
            [StringLength(12, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters and cannot be longer than 12 characters")]
            public string Password { get; set; }
            [NotMapped] // Does not effect with your database
            [Compare("Password")]
            [Required(ErrorMessage = "Confirm Password is not match")]
            public string ConfirmPassword { get; set; }
            public string Photo { get; set; }
            public string Address { get; set; }


            public List<ComboRole> comboRoles { get; set; }

        }
        public partial class EditUserVM
        {
            public EditUserVM()
            {
                comboRoles = new List<ComboRole>();
            }
            public int UserID { get; set; }
            public int Role_ID { get; set; }
            public string FullName { get; set; }

            //[EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }
            public string ContactNo { get; set; }
            //public string CNICNo { get; set; }
            //public string Photo { get; set; }
            public string Address { get; set; }


            public List<ComboRole> comboRoles { get; set; }

        }
        public partial class GetAllUserVM
        {
            public int UserID { get; set; }
            public int ID { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ContactNo { get; set; }
            public string CNICNo { get; set; }
            public string IsActive { get; set; }
            public string Photo { get; set; }
            public string Address { get; set; }
            public int RoleID { get; set; }
            public string RoleName { get; set; }
        }
        public partial class LoginVM
        {

            //Email
            [Required(ErrorMessage = "Please Fill Email Address")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email")]
            public string Email { get; set; }

            //Password
            [Required(ErrorMessage = "Password is not match")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Invalid Password")]
            public string Password { get; set; }

            public string Clicked { get; set; }
        }

        public partial class LoginReturnDataVM
        {
            public int UserID { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public bool isActive { get; set; }
            public string Picture { get; set; }
            public int RoleID { get; set; }
            public string RoleName { get; set; }
        }

        public partial class RoleMapWithNavVM
        {
            public int RoleMapWithNavID { get; set; }
            public int Role_ID { get; set; }
            public int navChild_ID { get; set; }
            public int NavSubChild_ID { get; set; }
            public string NavSubChildName { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public int SubChildSeqNo { get; set; }
            public bool IsVisibleSubChild { get; set; }
            public bool IsVisibleChild { get; set; }
            public bool IsVisibleParent { get; set; }
        }
        #endregion
        #region ROLEMODEL
        public partial class ClsUserRole
        {
            [Key]
            [Display(Name = "Role")]
            public string RoleID { get; set; }
            [StringLength(100)]
            public string RoleName { get; set; }
            public List<ClsWebPages> AllWebPages { get; set; }
        }
        public class ClsWebPages
        {
            public int WebPageID { get; set; }
            public int Parent_ID { get; set; }
            public int PageOrder { get; set; }
            public bool IsVisible { get; set; }
            public string PageTitle { get; set; }
            public string MainTitle { get; set; }
            public int OrderSeq { get; set; }
            public string PageIcon { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public string NormalIcon { get; set; }
            public string ViewName { get; set; }
            public bool IsChecked { get; set; }
            public string Description { get; set; }
            public List<ClsWebPages> Childs { get; set; }
            public string Url { get; set; }
        }



        public partial class CreateRoleVM
        {
            public int RoleID { get; set; }

            [Required(ErrorMessage = "Please Fill RoleName")]
            [Display(Name = "RoleName")]
            public string RoleName { get; set; }
            public bool IsActive { get; set; }

        }
        public partial class EditRoleVM
        {
            public int RoleID { get; set; }

            [Required(ErrorMessage = "Please Fill RoleName")]
            [Display(Name = "RoleName")]
            public string RoleName { get; set; }
            public bool IsActive { get; set; }

        }
        public partial class GetAllRoleVM
        {
            public int RoleID { get; set; }
            public int ID { get; set; }
            public string RoleName { get; set; }
            public bool IsActive { get; set; }
        }
        public class RolePermissionVM
        {
            public int ParentMenuID { get; set; }
            public string ParentMenuName { get; set; }
            public int ChildMenuID { get; set; }
            public string ChildMenuName { get; set; }
            public int SubChildMenuID { get; set; }
            public string SubChildName { get; set; }
            public bool HasParent { get; set; }
            public bool HasChild { get; set; }
            public bool HasSubChild { get; set; }

            public bool IsChecked { get; set; }
            public StatusModel statusModel { get; set; }
        }
        public class RolePermissionTempVM
        {
            public int NavParent_ID { get; set; }
            public bool ParentIsVisible { get; set; }
            public int NavChild_ID { get; set; }
            public bool ChildIsVisible { get; set; }
            public int NavSubChild_ID { get; set; }
            public bool SubChildIsVisible { get; set; }
        }
        public class RolePermissionWithRolVM
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public List<RolePermissionVM> LstRolePermission { get; set; }
            public List<ComboRole> comboRole { get; set; }
        }

        #endregion
        #region PROJECTMODEL
        //CreateProject
        public partial class CreateProjectVM
        {
            public CreateProjectVM()
            {
                comboCategories = new List<ComboCategory>();
                comboProjectTypes = new List<ComboProjectType>();
                comboDigitalPolicies = new List<ComboDigitalPolicy>();
                comboCities = new List<ComboCity>();
                comboSDGS = new List<ComboSDGS>();
                comboProjectStatus = new List<ComboProjectStatus>();
                comboRiskStatus = new List<ComboRiskStatus>();
                comboRiskMitigation = new List<ComboRiskMitigation>();
                comboTypeOfStakeholder = new List<ComboTypeOfStakeholder>();
                //only for sub project
                comboProject = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();

            }

            public int ProjectID { get; set; }

            //for sub Project
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public  string SubProjectName { get; set; }
            [Display(Name = "Category")]
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int Category_ID { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int ProjectType_ID { get; set; }
            public List<int> ProjectTypeArray { get; set; }

            //[Required(ErrorMessage = "Please Select Select Digital Policy")]
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int DigitalPolicy_ID { get; set; }
            public List<int> DigitalPolicyArray { get; set; }

            //[Required(ErrorMessage = "Please Select Select Location")]
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int City_ID { get; set; }
            public List<int> CityArray { get; set; }
            public int SDGS_ID { get; set; }
            public List<int> SDGSArray { get; set; }

            public int ProjectStatus_ID { get; set; }
            public int User_ID { get; set; }
            [Required(ErrorMessage = "Please Enter Project Name")]
            [Display(Name = "Project Name")]
            public string ProjectName { get; set; }
            [Required(ErrorMessage = "Please Enter Planned Budget")]
            [Display(Name = "Planned Budget")]
            public long PlannedBudget { get; set; }

            [Required(ErrorMessage = "Please Enter Approved Budget")]
            [Display(Name = "Approved Budget")]
            public long ApprovedBudget { get; set; }

            //[Required(ErrorMessage = "Please Select Funding Source")]
            [Display(Name = "Funding Source")]
            public string Funding_Source { get; set; }

            public List<int> Funding_SourceArray { get; set; }
            //[Required(ErrorMessage = "Please Enter Planned HR")]
            [Display(Name = "Planned-HR")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            public int PlannedHR { get; set; }
            [Required(ErrorMessage = "Please Enter Project Objective")]
            [Display(Name = "Project Objective")]
            public string ProjectGoal { get; set; }

            //Project Objective multiple add
            public string Objective { get; set; }


            //Project KPIs
            [Display(Name = "Indicator Description")]
            public string IndicatorDescription { get; set; }

            [Display(Name = "Target")]
            public int Target { get; set; }
            [Display(Name = "TimeLine")]
            public System.DateTime TimeLine { get; set; }


            //Procurement
            public string ProcrumetHeader { get; set; }
            //[Required(ErrorMessage = "Please Enter Achieved Procurement")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "No of Planned Procurement")]
            public int PlannedProcrumentNo { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "Planned Per Cost Procurement")]
            public int PlannedPerCostItem { get; set; }
            //[Required(ErrorMessage = "Please Enter Achieved Procurement")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "Achieved Cost")]
            public int AchievedCost { get; set; }




            //ReleasedBudget
            public long ReleasedBudget { get; set; }

            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ReleasedDate { get; set; }

            ////Recruted-HR
            //public int RecruitedHR_ID { get; set; }

            //////[Required(ErrorMessage = "Please Enter Recruited HR")]
            //[Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            //public int RecruitedHR { get; set; }

            //public double RecruitedHRPercent { get; set; }

            //[Required(ErrorMessage = "Select Date")]
            //[DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            //public System.DateTime RecruitedHRDate { get; set; }

            //Schedule
            public int Schedule_ID { get; set; }
            ////[Required(ErrorMessage = "Please Select Planned Date")]
            [Display(Name = "Planned Date")]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]

            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime PlannedDate { get; set; }
            ////[Required(ErrorMessage = "Please Select Start Date")]
            [Display(Name = "Start Date")]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime StartDate { get; set; }

            ////[Required(ErrorMessage = "Please Select End Date")]
            [Display(Name = "End Date")]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime EndDate { get; set; }

            //Risk
            public int RiskID { get; set; }
            //[Required(ErrorMessage = "Please Select Risk Status")]
            public int RiskStatus_ID { get; set; }
            public int RiskMitigation_ID { get; set; }
            public string RiskName { get; set; }

            //Stackholder
            public int Stackholder_ID { get; set; }
            public int TypeOfStakeholder_ID { get; set; }
            public string StackholderDepartment { get; set; }
            public string StackholderContact { get; set; }
            public string StackholderEmail { get; set; }

            public List<ComboCategory> comboCategories { get; set; }
            public List<ComboProjectType> comboProjectTypes { get; set; }
            public List<ComboDigitalPolicy> comboDigitalPolicies { get; set; }
            public List<ComboCity> comboCities { get; set; }
            public List<ComboFundingSource> comboFundingSource { get; set; }
            public List<ComboSDGS> comboSDGS { get; set; }
            public List<ComboProjectStatus> comboProjectStatus { get; set; }
            public List<ComboRiskStatus> comboRiskStatus { get; set; }
            public List<ComboRiskMitigation> comboRiskMitigation { get; set; }
            public List<ComboTypeOfStakeholder> comboTypeOfStakeholder { get; set; }

            public List<ComboProject> comboProject { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ProjectObjective> AssignObjectiveList { get; set; }
            public List<ProjectPlannedKPIs> AssignProjectPlannedKPIsList { get; set; }
            public List<PlannedProcurement> AssignPlannedProcurementList { get; set; }
            public List<Risk> AssignRiskList { get; set; }
            public List<Stackholder> AssignStackholderList { get; set; }
        }
        //GetAllProject
        public partial class GetAllProjectVM
        {
            
            public int ProjectID { get; set; }
            public int SubProjectID { get; set; }
            public int ID { get; set; }
            public int Category_ID { get; set; }
            public int ProjectType_ID { get; set; }
            public int DigitalPolicy_ID { get; set; }
            public int City_ID { get; set; }
            public int User_ID { get; set; }
            public string ProjectName { get; set; }
            public string SubProjectName { get; set; }
            public string categoryName { get; set; }
            public string ProjectTypeName { get; set; }
            public string CityName { get; set; }
            public long PlannedBudget { get; set; }
            public long ApprovedBudget { get; set; }
            public string Funding_Source { get; set; }
            public int PlannedHR { get; set; }
            public string PlannedProcurement { get; set; }
            public int MaleBeneficiary { get; set; }
            public int FemaleBeneficiary { get; set; }
            public int TotalBeneficiary { get; set; }
            public String CostPerBeneficiary { get; set; }
           
        }

        //GetProjectDetails
        public partial class GetProjectDetailsVM
        {
            public GetProjectDetailsVM()
            {
                getProjectDetailsQ6Lst = new List<GetProjectDetailsQ6>();
                getProjectDetailsQ7Lst = new List<GetProjectDetailsQ7>();
                getIndicatorLst = new List<InsightIndicatorNames>();
            }
            public GetProjectDetailsQ1 getProjectDetailsQ1 { get; set; }
            public GetProjectDetailsQ2 getProjectDetailsQ2 { get; set; }
            public GetProjectDetailsQ3 getProjectDetailsQ3 { get; set; }
            public GetProjectDetailsQ4 getProjectDetailsQ4 { get; set; }
            public GetProjectDetailsQ5 getProjectDetailsQ5 { get; set; }
            public List<GetProjectDetailsQ6> getProjectDetailsQ6Lst { get; set; }
            public List<GetProjectDetailsQ7> getProjectDetailsQ7Lst { get; set; }
            public List<InsightIndicatorNames> getIndicatorLst { get; set; }
        }
        public partial class GetProjectDetailsQ1
        {
            public string ProjectType { get; set; }
            public int stackholder { get; set; }
            public int ActiveIssues { get; set; }
            public int ActiveRisks { get; set; }
            public int PlannedHR { get; set; }
            public int RecruitedHR { get; set; }
            public int Funding_Source { get; set; }
        }
        public partial class GetProjectDetailsQ2
        {
            public string FormatedResult { get; set; }
        }
        public partial class GetProjectDetailsQ3
        {
            public int PlannedBudget { get; set; }
            public int AllocatedBudget { get; set; }
            public int ExpenditureBudget { get; set; }
            public int RemainingBudget { get; set; }
            public int FinancialDetails { get; set; }
        }
        public partial class GetProjectDetailsQ4
        {
            public DateTime PlannedDate { get; set; }
            public DateTime ActualDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        public partial class GetProjectDetailsQ5
        {
            public string ObjectiveName { get; set; }
        }
        public partial class GetProjectDetailsQ6
        {
            public string ProjectName { get; set; }
            public string InsightIndicatorName { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public string InsightIndicatorValueText { get; set; }
            public int InsightIntegerValue { get; set; }
            public int BoolValue { get; set; }
            public float FloatValue { get; set; }
           
        }
        public partial class GetProjectDetailsQ7
        {
            public string InsightIndicatorName { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public dynamic CommonFiled { get; set; }
        }
        public partial class InsightIndicatorNames
        {
            public string InsightIndicatorName { get; set; }
        }
        

        #endregion
        #region RecruitedHR
        public partial class CreateRecruitedHRVM
        {
            public CreateRecruitedHRVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            public int RecruitedHRID { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please Select Project")]
            public int Project_ID { get; set; }
            //[Required(ErrorMessage = "Please Select SubProject")]
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
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class EditRecruitedHRVM
        {
            public EditRecruitedHRVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            public int RecruitedHRID { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please Select Project")]
            public int Project_ID { get; set; }
            [Required(ErrorMessage = "Please Select SubProject")]
            public int SubProject_ID { get; set; }
            [Required(ErrorMessage = "Please Select Batch")]
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Select Batch")]
            public int RecruitedHR { get; set; }
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime RecruitedFromHRDate { get; set; }
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime RecruitedToHRDate { get; set; }

            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class GetAllRecruitedHRVM
        {
            public int RecruitedHRID { get; set; }
            public int ID { get; set; }
            public string PositionTitle { get; set; }
            public int Grade { get; set; }
            public int PlannedHR { get; set; }
            public int RecruitedHR { get; set; }
            public DateTime RecruitedFromHRDate { get; set; }
            public DateTime RecruitedToHRDate { get; set; }
            public string Remarks { get; set; }
            
        }
        #endregion
        #region Finance
        public partial class CreateViewReleasedBudgetVM
        {
            public CreateViewReleasedBudgetVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            //Common Filed
            [Range(1, int.MaxValue, ErrorMessage = " Select Project")]
            public int Project_ID { get; set; }

            public int SubProject_ID { get; set; }
            [Range(0, int.MaxValue, ErrorMessage = " Select Batch")]
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            //ReleasedBudget
            public int ReleasedBudgetID { get; set; }

            [Required(ErrorMessage = "Select From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime ReleasedDate { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Enetr Released-Budget")]
            public long ReleasedBudget { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class EditReleasedBudgetVM
        {
            public EditReleasedBudgetVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            //Common Filed
            [Range(1, int.MaxValue, ErrorMessage = "Please Select Project")]
            public int Project_ID { get; set; }

            [Required(ErrorMessage = "Please Select SubProject")]
            public int SubProject_ID { get; set; }
            [Required(ErrorMessage = "Please Select Batch")]
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            //ReleasedBudget
            public int ReleasedBudgetID { get; set; }

            [Required(ErrorMessage = "Select From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime ReleasedFromDate { get; set; }

            [Required(ErrorMessage = "Select To Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime ReleasedToDate { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Enetr Released-Budget")]
            public long ReleasedBudget { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class GetAllReleasedBudgetVM
        {

            //Common Filed
            public int Project_ID { get; set; }
            public int ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            //ReleasedBudget
            public string ProjectName { get; set; }
            public string SubProjectName { get; set; }
            public string BatchName { get; set; }
            public int ReleasedBudgetID { get; set; }
            public DateTime ReleasedFromDate { get; set; }
            public long ReleasedBudget { get; set; }
            public string Remarks { get; set; }

        }
        public partial class CreateViewExpenditureBudgetVM
        {
            public CreateViewExpenditureBudgetVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            //Common Filed
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
            public List<Expenditure_Budget> AssignExpenditureList { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class GetAllExpenditureBudgetVM
        {

            //Common Filed
            public int Project_ID { get; set; }
            public int ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            //Expenditure
            public string ProjectName { get; set; }
            public string SubProjectName { get; set; }
            public string BatchName { get; set; }
            public int ExpenditureBudgetID { get; set; }
            public string BudgetHead { get; set; }
            public long ApprovedCost { get; set; }
            public long ExpenditureBudget { get; set; }
            public DateTime ExpenditureDate { get; set; }
          
           

        }
        #endregion
        #region Procurement
        public partial class CreateProcurementVM
        {
            public CreateProcurementVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
               comboBatch =new  List<ComboBatch>();
                comboProcurementHead = new List<ComboProcurementHead>();
            }
            public int Project_ID { get; set; }
            [Range(0, int.MaxValue, ErrorMessage = "Enter Procurement-Value")]
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int PlannedProcurement_ID { get; set; }
            [Required(ErrorMessage = "Enter From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ProcurementDate { get; set; }
            
            public int AchievedProcurement { get; set; }

            public int ActualCostPerItem { get; set; }
            public int TotalCost { get; set; }
            [Required(ErrorMessage = "Enter From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            //public DateTime EntryDate { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
            public List<ComboProcurementHead> comboProcurementHead { get; set; }
        }
        public partial class EditProcurementVM
        {
            public EditProcurementVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int AchievedProcurementID { get; set; }
            public string ProcurementHeader { get; set; }
            public int AchievedProcurement { get; set; }
            public System.DateTime ProcurementFromDate { get; set; }
            public System.DateTime ProcurementToDate { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class GetAllProcurementVM
        {
            public GetAllProcurementVM()
            {
                comboProjects = new List<ComboProject>();
            }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int PlannedProcurement { get; set; }
            public int AchievedProcurementID { get; set; }
            public int AchievedProcurement { get; set; }
            public double ProcurementPercent { get; set; }
            public System.DateTime ProcurementFromDate { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
        }
        #endregion
        #region Issues
        //CreateIssue
        public partial class CreateIssueVM
        {
            public CreateIssueVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }

            [Range(1, int.MaxValue, ErrorMessage = "Select Project")]
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }

            [Range(0, int.MaxValue, ErrorMessage = "Select Batch")]
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string IssueDescription { get; set; }
            [Required(ErrorMessage = "Select From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime IssueDate { get; set; }

            [Required(ErrorMessage = "Enter ActionTaken")]
            public string ActionTaken { get; set; }
            public string Solution { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        //EditIssue
        public partial class EditIssueVM
        {
            public EditIssueVM()
            {
                comboProjects = new List<ComboProject>();
            }
            public int IssuesID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string IssueDescription { get; set; }
     
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            [DataType(DataType.DateTime)]
            public DateTime IssueDate { get; set; }
            public string ActionTaken { get; set; }
            public string Solution { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
        }
        //GetAllIssue
        public partial class GetAllIssue
        {
            public int IssuesID { get; set; }
            public int ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string IssueDescription { get; set; }
            public DateTime IssueDate { get; set; }
            public string ActionTaken { get; set; }
            public string Solution { get; set; }
            public string Remarks { get; set; }

        }
        #endregion
        #region Project KPIs Status
        //CreateAchievedKPIS
        public partial class CreateProjectKPIsStatusVM
        {
            public CreateProjectKPIsStatusVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
                comboPlannedKPIs = new List<ComboPlannedKPIs>(); 
            }

            
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public KPIsANDInsightIndicatorVM KPIandIndicatorList = new KPIsANDInsightIndicatorVM();

            public int PlannedKPIs_ID { get; set; }

            //Evaluation
            public string EvaluationType { get; set; }
            public string VisistStatus { get; set; }
            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public string VisitDate { get; set; }
            public string Agenda { get; set; }
            public string EvaluationRemarks { get; set; }
            //public int Target { get; set; }

            public int ProjectKPIsAchived { get; set; }
            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime TimeLine { get; set; }
            public string Remarks { get; set; }

            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
            public List<ComboPlannedKPIs> comboPlannedKPIs { get; set; }
        }
        public partial class GetAllProjectKPIsStatusVM
        {

            public int ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ProjectKPIsStatusID { get; set; }
            public int PlannedKPIs_ID { get; set; }
            public string ProjectName { get; set; }
            public string SubProjectName { get; set; }
            public string IndicatorDescription { get; set; }
            public int Target { get; set; }
            public int ProjectKPIsAchived { get; set; }
            public DateTime TimeLine { get; set; }
            public string Remarks { get; set; }
            
        }
        #endregion
        #region InsightIndicator
        //CreateInsightIndicator
        public partial class CreateInsightIndicatorVM
        {
            public CreateInsightIndicatorVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            //Common Field
            [Range(1, int.MaxValue, ErrorMessage = "Please Select Project")]
            public int Project_ID { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Select subProject")]
            public int SubProject_ID { get; set; }
            [Required(ErrorMessage = "Please Select Batch")]
            public int Batch_ID { get; set; }
            [Required(ErrorMessage = "Please Select Indicator")]

            //InsightIndicatorName
            public string InsightIndicatorName { get; set; }

            //InsightIndicatorField
            public int InsightIndicatorDataType_ID { get; set; }
     
            public List<InsightIndicatorField> AssignInsightIndicatorFieldList { get; set; }
            public List<ComboInsightIndicatorDataType> comboInsightIndicatorDataTypes { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class GetAllInsightIndicatorVM
        {
            public int ID { get; set; }
            public int InsightIndicatorID { get; set; }
            public string InsightIndicatorName { get; set; }
            public string InsightIndicatorFieldName { get; set; }
        }
        #endregion
        #region InsightIndicatorValue
        //CreateIndicator
        public partial class CreateIndicatorVM
        {
            public string IndicatorName { get; set; }
        }
        //Get All Indicator
        public partial class CreateLinkIndicatorVM
        {
            public CreateLinkIndicatorVM()
            {
                comboProjects = new List<ComboProject>();
                comboIndicator = new List<ComboIndicator>();
                comboBatch = new List<ComboBatch>();
            }
            public int LinkID { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Select Project")]
            public int Project_ID { get; set; }
            [Required(ErrorMessage = "Please Select Batch")]
            public int Batch_ID { get; set; }
            [Required(ErrorMessage = "Please Select Indicator")]
            public int Indicator_ID { get; set; }


            public List<ComboProject> comboProjects { get; set; }
            public List<ComboIndicator> comboIndicator { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
        }
        public partial class GetAllLinkIndicatorVM
        {
            public int LinkID { get; set; }
            public int ID { get; set; }
            public int Batch_ID { get; set; }
            public int Indicator_ID { get; set; }
            public string ProjectName { get; set; }
            public string BatchName { get; set; }
            public string IndicatorName { get; set; }

        }
        public partial class CreateIndicatorFieldVM
        {
            public CreateIndicatorFieldVM()
            {

                comboIndicator = new List<ComboIndicator>();
                comboInsightIndicatorDataTypes = new List<ComboInsightIndicatorDataType>();
            }
            public int IndicatorFieldID { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please Select Indicator")]
            public int Indicator_ID { get; set; }
            public int IndicatorDataType_ID { get; set; }
            public string IndicatorFieldName { get; set; }

            public List<ComboIndicator> comboIndicator { get; set; }
            public List<ComboInsightIndicatorDataType> comboInsightIndicatorDataTypes { get; set; }

        }
        public partial class CreateInsightIndicatorValueVM
        {
            public CreateInsightIndicatorValueVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboIndicator = new List<ComboIndicator>();
                comboBatch = new List<ComboBatch>();
                dataTypeVMLst = new List<InsightIndicatorDataTypeVM>();
                dataTypeCommonVMLst = new List<InsightIndicatorDataTypeCommonValueVM>();
                dataTypeConveVMLst = new List<InsightIndicatorDataTypeConvertVM>();
            }

            public int IndicatorValueID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int InsightIndicator_ID { get; set; }
            public int InsightIndicatorField_ID { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please Select Indicator")]
            public string InsightIndicatorFieldName { get; set; }

            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboIndicator> comboIndicator { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
            public List<InsightIndicatorDataTypeVM> dataTypeVMLst { get; set; }
            public List<InsightIndicatorDataTypeCommonValueVM> dataTypeCommonVMLst { get; set; }
            public List<InsightIndicatorDataTypeConvertVM> dataTypeConveVMLst { get; set; }
        }
        public partial class GetProjectReport
        {
            public int ProjectID { get; set; }
            public int Category_ID { get; set; }
            public int ProjectType_ID { get; set; }
            public int DigitalPolicy_ID { get; set; }
            public int City_ID { get; set; }
            public int User_ID { get; set; }
            public string ProjectName { get; set; }
            public long PlannedBudget { get; set; }
            public long ApprovedBudget { get; set; }
            public string Funding_Source { get; set; }
            public List<string> Funding_SourceArray { get; set; }
            public int PlannedHR { get; set; }
            public int PlannedProcurement { get; set; }
            public int MaleBeneficiary { get; set; }
            public int FemaleBeneficiary { get; set; }
            public int TotalBeneficiary { get; set; }
            public int CostPerBeneficiary { get; set; }
            public string Objective { get; set; }

            //Procurent
            public string AchievedProcurement_ID { get; set; }
            public int AchievedProcurement { get; set; }
            public double ProcurementPercent { get; set; }
            public string AchievedProcurementDate { get; set; }
            //ReleasedBudget
            public long ReleasedBudget { get; set; }
            public DateTime ReleasedDate { get; set; }
            //Recruted-HR
            public int RecruitedHR_ID { get; set; }
            public int RecruitedHR { get; set; }
            public double RecruitedHRPercent { get; set; }
            public System.DateTime RecruitedHRDate { get; set; }
            //Schedule
            public int Schedule_ID { get; set; }
            public System.DateTime PlannedDate { get; set; }
            public System.DateTime StartDate { get; set; }
            public System.DateTime EndDate { get; set; }
            //Risk
            public int RiskID { get; set; }
            public int RiskStatus_ID { get; set; }
            public string RiskName { get; set; }
            //Stackholder
            public int Stackholder_ID { get; set; }
            public string StackholderName { get; set; }
            public string StackholderDepartment { get; set; }
            public string StackholderContact { get; set; }
            public string StackholderEmail { get; set; }
            //Indicator
            public int InsightIndicatorID { get; set; }
            public string InsightIndicatorName { get; set; }
            //IndicatorField
            public int InsightIndicatorFieldID { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            //IndicatorFieldValue
            public int InsightIndicatorValueID { get; set; }
            public string InsightIndicatorValueText { get; set; }
            public int InsightIndicatorValueInteger { get; set; }
            public bool InsightIndicatorValueBoolean { get; set; }
            public double InsightIndicatorValueFloat { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }

        }

        #endregion
        #region Indicator
       
        public partial class InsightIndicatorDataTypeVM
        {
            public int InsightIndicatorFieldID { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public int InsightIndicatorDataType_ID { get; set; }
 
            public string TEXT { get; set; }
            public int? INTEGER { get; set; }
            public float? FLOAT { get; set; }
            public bool? BOOL { get; set; }
        }
        public partial class InsightIndicatorDataTypeConvertVM
        {
             public int Project_ID { get; set; }
            public int InsightIndicatorFieldID { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public string TEXT { get; set; }
            public int? INTEGER { get; set; }
            public float? FLOAT { get; set; }
            public string BOOLConvert { get; set; }
        }
        public partial class InsightIndicatorDataTypeCommonValueVM
        {
            public int InsightIndicatorFieldID { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public dynamic CommonValue { get; set; }
      
        }


        #endregion
        #region Batch
        //CreateBatch
        public partial class CreateBatchVM
        {
            public CreateBatchVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
            }

            [Range(1, int.MaxValue, ErrorMessage = "Select Project")]
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int BatchID { get; set; }
            public int CreatedByUser_ID { get; set; }
            [Required(ErrorMessage = "Enter Batch Name")]
            public string BatchName { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
        }

        //GetAllBatches
        public partial class GetAllBatchVM
        {
            public string ProjectName { get; set; }
            public string SubProjectName { get; set; }
            public int BatchID { get; set; }
            public int ID { get; set; } 
            public string BatchName { get; set; }
          
        }
        #endregion
        #region COMBOVM
        public partial class ComboIndicatorBatchIndicatorVM
        {
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatches { get; set; }
            public List<ComboProcurementHead> comboProcurementHeads { get; set; }
            public List<ComboIndicator> comboIndicators { get; set; }
            public List<ChangeManagement> ListOfChangeManagements { get; set; }
            public KPIsANDInsightIndicatorVM ListOfInsightIndicatorAndKPIs { get; set; }
            public RemainingValues remainingValues { get; set; }
            public string IsEvaluationForm = null;
            public string IsChangeManagementForm = null;
            public int[] value = new int[5];
            public ComboIndicatorBatchIndicatorVM()
            {
                ListOfChangeManagements = new List<ChangeManagement>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatches = new List<ComboBatch>();
                comboProcurementHeads = new List<ComboProcurementHead>();
                comboIndicators = new List<ComboIndicator>();
                //InsightIndicatorForEvaulationList= new List<InsightIndicatorForEvaulation>();
            }
            public ChangeManagementVM ListOfChangeManagementVM = new ChangeManagementVM();
            
        }
        #endregion
        #region Evaulation
        public partial class InsightIndicatorForEvaulation
        {
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int InsightIndicatorID { get; set; }
            public int InsightIndicatorFieldID { get; set; }
            public string InsightIndicatorFieldName { get; set; }
            public int InsightIndicatorDataType_ID { get; set; }
            public int INTEGER { get; set; }
            public double FLOAT { get; set; }
            public string BOOLConvert { get; set; }
            public string TEXT { get; set; }
        }
        public partial class KPIsForEvaulation
        {
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int PlannedKPIsID { get; set; }
            public string IndicatorDescription { get; set; }
        
            public string Target { get; set; }
            public int ProjectKPIsStatusID { get; set; }
            public int ProjectKPIsAchived { get; set; }
            public string Remarks { get; set; }
        }

        public partial class KPIsANDInsightIndicatorVM
        {
            public KPIsANDInsightIndicatorVM()
            {
                ListInsightIndicator = new List<InsightIndicatorForEvaulation>();
                ListKPIs = new List<KPIsForEvaulation>();
            }
            public List<InsightIndicatorForEvaulation> ListInsightIndicator { get; set; }
            public List<KPIsForEvaulation> ListKPIs { get; set; }
        }

        #endregion
        #region ChangeManagement
        public partial class ProjectHistory
        {
            //for sub Project
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public string SubProjectName { get; set; }
            public string ProjectName { get; set; }
            public long PlannedBudget { get; set; }
            public long ApprovedBudget { get; set; }
            public int PlannedHR { get; set; }
            public string ProjectGoal { get; set; }
        }

        public partial class ObjectiveHistory
        {
            public int Objective_ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public string ObjectiveName { get; set; }
        }
        public partial class PlannedKPIsHistory
        {
            public int PlannedKPIs_ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string IndicatorDescription { get; set; }
            public  long Target { get; set; }
            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime TimeLine { get; set; }
        }
        public partial class PlannedProcurementHistory
        {
            public int PlannedProcurement_ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string ProcrumetHeader { get; set; }
            public long PlannedProcrumentNo { get; set; }
            public long PlannedPerCostItem { get; set; }
            public long AchivedCost { get; set; }
            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime EntryDate { get; set; }
        }
        public partial class ScheduleHistory
        {
            public int Schedule_ID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            
            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime PlannedDate { get; set; }
            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime StartDate { get; set; }
            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime EndDate { get; set; }

        }



        
        public partial class Change_ManagementProject
        {
            public int ProjectID { get; set; }
            public string PlannedBudget { get; set; }
            public long PlannedBudgetValue { get; set; }
            public long ChangeValuePlannedBudget { get; set; }
            public string DecisionPlannedBudget { get; set; }
            public string ActionTakenPlannedBudget { get; set; }
            

            public string ApprovedBudget { get; set; }
            public long ApprovedBudgetValue { get; set; }
            public long ChangeValueApprovedBudget { get; set; }
            public string DecisionApprovedBudget { get; set; }
            public string ActionTakenApprovedBudget { get; set; }

            public string PlannedHR { get; set; }
            public long PlannedHRValue { get; set; }
            public long ChangeValuePlannedHR { get; set; }
            public string DecisionPlannedHR { get; set; }
            public string ActionTakenPlannedHR { get; set; }
        }

        public partial class Change_ManagementSchedule
        {
             public int ScheduleID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public string PlannedDate { get; set; }
            public string PlannedDateValue { get; set; }
            [Required(ErrorMessage = "Enter From Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ChangeValuePlannedDate { get; set; }
            public string DecisionPlannedDate { get; set; }
            public string ActionTakenPlannedDate { get; set; }

            public string StartDate { get; set; }
            public string StartDateValue { get; set; }
            public DateTime ChangeValueStartDate { get; set; }
            public string DecisionStartDate { get; set; }
            public string ActionTakenStartDate { get; set; }

            public string EndDate { get; set; }
            public string EndDateValue { get; set; }
            public DateTime ChangeValueEndDate { get; set; }
            public string DecisionEndDate { get; set; }
            public string ActionTakenEndDate { get; set; }
        }
        public partial class Change_ManagementPlannedKPI
        {

            public int PlannedKPIsID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public string IndicatorDescription { get; set; }
            public string IndicatorDescriptionValue { get; set; }
            public string ChangeValueIndicatorDescription { get; set; }
            public string DecisionIndicatorDescription { get; set; }
            public string ActionTakenIndicatorDescription { get; set; }

            public string Target { get; set; }
            public int TargetValue { get; set; }
            public int ChangeValueTarget { get; set; }
            public string DecisionTarget { get; set; }
            public string ActionTakenTarget { get; set; }

            public string TimeLine { get; set; }
            public string TimeLineValue { get; set; }
            public DateTime ChangeValueTimeLine { get; set; }
            public string DecisionTimeLine { get; set; }
            public string ActionTakenTimeLine { get; set; }
        }

        public partial class Change_ManagementPlannedProcurement
        {
            public int PlannedProcurementID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public string ProcrumetHeader { get; set; }
            public string ProcrumetHeaderValue { get; set; }
            public string ChangeValueProcrumetHeader { get; set; }
            public string ProcrumetHeaderDescription { get; set; }
            public string ActionTakenProcrumetHeader { get; set; }

            public string PlannedProcrumentNo { get; set; }
            public int PlannedProcrumentNoValue { get; set; }
            public int ChangeValuePlannedProcrumentNo { get; set; }
            public string PlannedProcrumentNoDescription { get; set; }
            public string ActionTakenPlannedProcrumentNo { get; set; }


            public string PlannedPerCostItem { get; set; }
            public int PlannedPerCostItemValue { get; set; }
            public int ChangeValuePlannedPerCostItem { get; set; }
            public string PlannedPerCostItemDescription { get; set; }
            public string ActionTakenPlannedPerCostItem { get; set; }


            public string AchivedCost { get; set; }
            public int AchivedCostValue { get; set; }
            public int ChangeValueAchivedCost { get; set; }
            public string AchivedCostDescription { get; set; }
            public string ActionTakenAchivedCost { get; set; }

        }

        public partial class ChangeManagementVM
        {
            public ChangeManagementVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>(); 
                Change_ManagementProjectList = new List<Change_ManagementProject>();
                Change_ManagementScheduleList = new List<Change_ManagementSchedule>();
                Change_ManagementPlannedKPIList = new List<Change_ManagementPlannedKPI>();
                Change_ManagementPlannedProcurementList = new List<Change_ManagementPlannedProcurement>();
            }
             
            public List<Change_ManagementProject> Change_ManagementProjectList { get; set; }
            public List<Change_ManagementSchedule> Change_ManagementScheduleList { get; set; }
            public List<Change_ManagementPlannedKPI> Change_ManagementPlannedKPIList { get; set; }
            public List<Change_ManagementPlannedProcurement> Change_ManagementPlannedProcurementList { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int Project_ID { get; set; }
              
            public int SubProject_ID { get; set; }
            public int ProjectHistory_ID { get; set; }
            public int SubProjectHistory_ID { get; set; }
            public string MeetingNo { get; set; }

            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime MeetingDate { get; set; }
        
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
      
        }
        #endregion
        #region Admin
        //Get All PlannedKPIs For Chart

        public partial class  GetDashboardVM
        {
            public GetDashboardVM()
            {
                getPKPIsChartQ1 = new List<GetPKPIsChart>();
            }
            public List<GetPKPIsChart> getPKPIsChartQ1 { get; set; }
            //public GetProjectDetailsQ2 getProjectDetailsQ2 { get; set; }
            //public GetProjectDetailsQ3 getProjectDetailsQ3 { get; set; }
            //public GetProjectDetailsQ4 getProjectDetailsQ4 { get; set; }
            //public GetProjectDetailsQ5 getProjectDetailsQ5 { get; set; }
            //public List<GetProjectDetailsQ6> getProjectDetailsQ6Lst { get; set; }
            //public List<GetProjectDetailsQ7> getProjectDetailsQ7Lst { get; set; }
            //public List<InsightIndicatorNames> getIndicatorLst { get; set; }
        }
        public partial class GetPKPIsChart
        {
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int PlannedKPIsID { get; set; }
            public string IndicatorDescription { get; set; }
            public int Target { get; set; }
            public int ProjectKPIsStatusID { get; set; }
            public int ProjectKPIsAchived { get; set; }
        }
        #endregion
    }

}
