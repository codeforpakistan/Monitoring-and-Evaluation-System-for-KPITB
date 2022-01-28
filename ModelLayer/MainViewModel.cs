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

            //[EmailAddress(ErrorMessage = "Invalid Email Address")]

            //Email
            [Required(ErrorMessage = "Please Fill Email Address")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email")]
            [Display(Name = "Email Address")]
            public string Email { get; set; }


            [Required(ErrorMessage = "Please Enter Contact No")]
            [StringLength(12, ErrorMessage = "Please Enter Contact without Dashes", MinimumLength = 11)]
            public string ContactNo { get; set; }

            [Required(ErrorMessage = "Please Fill CNIC No")]
            [StringLength(13, ErrorMessage = "Please Enter CNIC without Dashes.", MinimumLength = 13)]
            public string CNICNo { get; set; }

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
            public string CNICNo { get; set; }
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
                comboRiskStatus = new List<ComboRiskStatus>();
            }

            public int ProjectID { get; set; }

            [Display(Name = "Category")]
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int Category_ID { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int ProjectType_ID { get; set; }
            //[Required(ErrorMessage = "Please Select Select Digital Policy")]
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int DigitalPolicy_ID { get; set; }

            //[Required(ErrorMessage = "Please Select Select Location")]
            [Range(1, int.MaxValue, ErrorMessage = "Please Select")]
            public int City_ID { get; set; }

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

            public List<string> Funding_SourceArray { get; set; }

            //[Required(ErrorMessage = "Please Enter Planned HR")]
            [Display(Name = "Planned-HR")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            public int PlannedHR { get; set; }

            //[Required(ErrorMessage = "Please Enter Planned Procurement")]
            [Display(Name = "Planned Procurement")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            public int PlannedProcurement { get; set; }

            //[Required(ErrorMessage = "Please Enter No of Male")]
            [Range(0, int.MaxValue, ErrorMessage = "Value is not Valid")]
            [Display(Name = "No of Male")]
            public int MaleBeneficiary { get; set; }

            //[Required(ErrorMessage = "Please Enter No of Female")]
            [Range(0, int.MaxValue, ErrorMessage = "Value is not Valid")]
            [Display(Name = "No of Female")]
            public int FemaleBeneficiary { get; set; }

            //[Required(ErrorMessage = "Please Enter Total No of Beneficiary")]
            [Range(0, int.MaxValue, ErrorMessage = "Value is not Valid")]
            [Display(Name = "Total Beneficiary")]
            public int TotalBeneficiary { get; set; }

            //[Required(ErrorMessage = "Please Enter Cost per Beneficiary")]
            [Range(0, int.MaxValue, ErrorMessage = "Value is not Valid")]
            [Display(Name = "Cost Per Beneficiary")]
            public int CostPerBeneficiary { get; set; }

            [Required(ErrorMessage = "Please Enter Project Objective")]
            [Display(Name = "Project Objective")]
            public string Objective { get; set; }

            //Procurent
            public string AchievedProcurement_ID { get; set; }

            //[Required(ErrorMessage = "Please Enter Achieved Procurement")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "Achieved Procurement")]
            public int AchievedProcurement { get; set; }

            //[Required(ErrorMessage = "Please Enter Achieved Procurement %")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "Procurement %")]
            public double ProcurementPercent { get; set; }

            public string AchievedProcurementDate { get; set; }

            //ReleasedBudget
            public long ReleasedBudget { get; set; }

            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ReleasedDate { get; set; }

            //Recruted-HR
            public int RecruitedHR_ID { get; set; }

            ////[Required(ErrorMessage = "Please Enter Recruited HR")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            public int RecruitedHR { get; set; }

            public double RecruitedHRPercent { get; set; }

            [Required(ErrorMessage = "Select Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public System.DateTime RecruitedHRDate { get; set; }

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
            public string RiskName { get; set; }

            //Stackholder
            public int Stackholder_ID { get; set; }
            public string StackholderName { get; set; }
            public string StackholderDepartment { get; set; }
            public string StackholderContact { get; set; }
            public string StackholderEmail { get; set; }

            public List<ComboCategory> comboCategories { get; set; }
            public List<ComboProjectType> comboProjectTypes { get; set; }
            public List<ComboDigitalPolicy> comboDigitalPolicies { get; set; }
            public List<ComboCity> comboCities { get; set; }
            public List<ComboRiskStatus> comboRiskStatus { get; set; }
            public List<ComboFundingSource> comboFundingSource { get; set; }

            public List<Risk> AssignRiskList { get; set; }
            public List<Stackholder> AssignStackholderList { get; set; }
        }
        //GetAllProject
        public partial class GetAllProjectVM
        {

            public int ProjectID { get; set; }
            public int ID { get; set; }
            public int Category_ID { get; set; }
            public int ProjectType_ID { get; set; }
            public int DigitalPolicy_ID { get; set; }
            public int City_ID { get; set; }
            public int User_ID { get; set; }
            public string ProjectName { get; set; }
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
                getIndicatorLst = new List<IndicatorNames>();
            }
            public GetProjectDetailsQ1 getProjectDetailsQ1 { get; set; }
            public GetProjectDetailsQ2 getProjectDetailsQ2 { get; set; }
            public GetProjectDetailsQ3 getProjectDetailsQ3 { get; set; }
            public GetProjectDetailsQ4 getProjectDetailsQ4 { get; set; }
            public GetProjectDetailsQ5 getProjectDetailsQ5 { get; set; }
            public List<GetProjectDetailsQ6> getProjectDetailsQ6Lst { get; set; }
            public List<GetProjectDetailsQ7> getProjectDetailsQ7Lst { get; set; }
            public List<IndicatorNames> getIndicatorLst { get; set; }
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
            public string Objective { get; set; }
        }
        public partial class GetProjectDetailsQ6
        {
            public string ProjectName { get; set; }
            public string IndicatorName { get; set; }
            public string IndicatorFieldName { get; set; }
            public string IndicatorValueText { get; set; }
            public int IntegerValue { get; set; }
            public int BoolValue { get; set; }
            public float FloatValue { get; set; }
           
        }
        public partial class GetProjectDetailsQ7
        {
            public string IndicatorName { get; set; }
            public string IndicatorFieldName { get; set; }
            public dynamic CommonFiled { get; set; }
        }
        public partial class IndicatorNames
        {
            public string IndicatorName { get; set; }
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
            [Required(ErrorMessage = "Please Select SubProject")]
            public int SubProject_ID { get; set; }
            [Required(ErrorMessage = "Please Select Batch")]
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please Enter Value")]
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
            public int PlannedHR { get; set; }
            public int RecruitedHR { get; set; }
            public double RecruitedHRPercent { get; set; }
            public string Remarks { get; set; }
            public System.DateTime RecruitedHRDate { get; set; }
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
            public System.DateTime ReleasedDate { get; set; }
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
            public DateTime ExpenditureFromDate { get; set; }
            public DateTime ExpenditureToDate { get; set; }
            public long ExpenditureBudget { get; set; }
            public string Remarks { get; set; }
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
            public DateTime ExpenditureFromDate { get; set; }
            public DateTime ExpenditureToDate { get; set; }
            public long ExpenditureBudget { get; set; }
            public string Remarks { get; set; }

        }
        #endregion
        #region Procurement
        public partial class CreateProcurementVM
        {
            public CreateProcurementVM()
            {
                comboProjects = new List<ComboProject>();
                comboSubProjects = new List<ComboSubProject>();
                comboBatch = new List<ComboBatch>();
            }
            [Range(1, int.MaxValue, ErrorMessage = "Please Ener Procurement-Value")]
            public int NoOfProcurement { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please Select Project")]
            public int Project_ID { get; set; }

            //[Required(ErrorMessage = "Please Select SubProject")]
            public int SubProject_ID { get; set; }

            public int Batch_ID { get; set; }

            public int CreatedByUser_ID { get; set; }

            [Required(ErrorMessage = "Enter From Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ProcurementFromDate { get; set; }

            [Required(ErrorMessage = "Enter To Date")]
            [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
            public DateTime ProcurementToDate { get; set; }

            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
            public List<ComboSubProject> comboSubProjects { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
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
            public int AchievedProcurement { get; set; }
            public double ProcurementPercent { get; set; }
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
            public System.DateTime ProcurementDate { get; set; }
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

            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string IssueDescription { get; set; }
            public DateTime IssueDate { get; set; }
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
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Issue Date")]
            public System.DateTime IssueDate { get; set; }
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
        #region Project KPIS
        //CreateIndicator
        public partial class CreateIndicatorVM
        {
            public string IndicatorName { get; set; }
        }
        //Get All Indicator
        public partial class GetAllIndicatorVM
        {
            public int ID { get; set; }
            public int IndicatorID { get; set; }
            public string IndicatorName { get; set; }
        }
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
        public partial class CreateIndicatorFieldVM
        {
            public CreateIndicatorFieldVM()
            {
                
                comboIndicator = new List<ComboIndicator>();
                comboIndicatorDataTypes= new List<ComboIndicatorDataType>();
            }
            public int IndicatorFieldID { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please Select Indicator")]
            public int Indicator_ID { get; set; }
            public int IndicatorDataType_ID { get; set; }
            public string IndicatorFieldName { get; set; }

            public List<ComboIndicator> comboIndicator { get; set; }
            public List<ComboIndicatorDataType> comboIndicatorDataTypes { get; set; }

        }
        public partial class CreateIndicatorValueVM
        {
            public CreateIndicatorValueVM()
            {
                comboProjects = new List<ComboProject>();
                comboIndicator = new List<ComboIndicator>();
                comboBatch = new List<ComboBatch>();
                dataTypeVMLst = new List<IndicatorDataTypeVM>();
            }

            public int IndicatorValueID { get; set; }
            public int Project_ID { get; set; }
            public int Batch_ID { get; set; }
            public int Indicator_ID { get; set; }
            public int IndicatorField_ID { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Please Select Indicator")]
            public string IndicatorFieldName { get; set; }

            public List<ComboProject> comboProjects { get; set; }
            public List<ComboIndicator> comboIndicator { get; set; }
            public List<ComboBatch> comboBatch { get; set; }
            public List<IndicatorDataTypeVM> dataTypeVMLst { get; set; }

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
            public int IndicatorID { get; set; }
            public string IndicatorName { get; set; }
            //IndicatorField
            public int IndicatorFieldID { get; set; }
            public string IndicatorFieldName { get; set; }
            //IndicatorFieldValue
            public int IndicatorValueID { get; set; }
            public string IndicatorValueText { get; set; }
            public int IndicatorValueInteger { get; set; }
            public bool IndicatorValueBoolean { get; set; }
            public double IndicatorValueFloat { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }

        }

        #endregion
        #region Indicator
        public partial class IndicatorDataTypeVM
        {
            public int IndicatorFieldID { get; set; }
            public string IndicatorFieldName { get; set; }
            public int IndicatorDataType_ID { get; set; }
 
            public string TEXT { get; set; }
            public int INTEGER { get; set; }
            public float FLOAT { get; set; }
            public string BOOL { get; set; }
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
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int BatchID { get; set; }
            public int CreatedByUser_ID { get; set; }
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

    }

}
