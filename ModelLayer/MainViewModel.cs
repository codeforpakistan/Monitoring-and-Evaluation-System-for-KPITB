using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public class RolePermissionWithRolVM
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public List<RolePermissionVM> LstRolePermission { get; set; }
            public List<ComboRole> comboRole{ get; set; }
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
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "No of Male")]
            public int MaleBeneficiary { get; set; }

            //[Required(ErrorMessage = "Please Enter No of Female")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "No of Female")]
            public int FemaleBeneficiary { get; set; }

            //[Required(ErrorMessage = "Please Enter Total No of Beneficiary")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            [Display(Name = "Total Beneficiary")]
            public int TotalBeneficiary { get; set; }

            //[Required(ErrorMessage = "Please Enter Cost per Beneficiary")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
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
            public DateTime ReleasedDate { get; set; }

            //Recruted-HR
            public int RecruitedHR_ID { get; set; }

            ////[Required(ErrorMessage = "Please Enter Recruited HR")]
            [Range(1, int.MaxValue, ErrorMessage = "0 Value is not Valid")]
            public int RecruitedHR { get; set; }

            public double RecruitedHRPercent { get; set; }
            public System.DateTime RecruitedHRDate { get; set; }


            //Schedule
            public int Schedule_ID { get; set; }
            ////[Required(ErrorMessage = "Please Select Planned Date")]
            [Display(Name = "Planned Date")]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
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
            public List<ComboFundingSource> comboFundingSource{ get; set; }

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
            public string Name { get; set; }
            public string categoryName{ get; set; }
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
        #endregion
        #region RecruitedHR
        public partial class CreateRecruitedHRVM
        {
            public CreateRecruitedHRVM()
            {
                comboProjects = new List<ComboProject>();
            }
            public int RecruitedHRID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
           
            public int RecruitedHR { get; set; }
            public double RecruitedHRPercent { get; set; }
            public System.DateTime RecruitedHRDate { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
        }
        public partial class EditRecruitedHRVM
        {
            public EditRecruitedHRVM()
            {
                comboProjects = new List<ComboProject>();
            }
            public int RecruitedHRID { get; set; }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            public int RecruitedHR { get; set; }
            public double RecruitedHRPercent { get; set; }
            public System.DateTime RecruitedHRDate { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
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
        public partial class CreateViewFinanceVM
        {
            public CreateViewFinanceVM()
            {
                comboProjects = new List<ComboProject>();
            }
            //Common Filed
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            //ReleasedBudget
            public int ReleasedBudgetID { get; set; }
            public System.DateTime ReleasedDate { get; set; }
            public long ReleasedBudget { get; set; }
            public string Remarks { get; set; }
            //Expenditure
            public int ExpenditureBudgetID { get; set; } 
            public System.DateTime ExpenditureDate { get; set; }
            public long ExpenditureBudget { get; set; }
           
            public List<ComboProject> comboProjects { get; set; }
        }
        public partial class GetAllFinanceVM
        {
            public GetAllFinanceVM()
            {
                comboProjects = new List<ComboProject>();
            }
            //Common Filed
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            //ReleasedBudget
            public int ReleasedBudgetID { get; set; }
            public System.DateTime ReleasedDate { get; set; }
            public long ReleasedBudget { get; set; }
            public string Remarks { get; set; }
            //Expenditure
            public int ExpenditureBudgetID { get; set; }
            public System.DateTime ExpenditureDate { get; set; }
            public long ExpenditureBudget { get; set; }

            public List<ComboProject> comboProjects { get; set; }
        }
        #endregion
        #region Procurement
        public partial class CreateProcurementVM
        {
            public CreateProcurementVM()
            {
                comboProjects = new List<ComboProject>();
            }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            public int AchievedProcurementID { get; set; }
            public int AchievedProcurement { get; set; }
            public double ProcurementPercent { get; set; }
            public System.DateTime ProcurementDate{ get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
        }
        public partial class EditProcurementVM
        {
            public EditProcurementVM()
            {
                comboProjects = new List<ComboProject>();
            }
            public int Project_ID { get; set; }
            public int SubProject_ID { get; set; }
            public int Batch_ID { get; set; }
            public int CreatedByUser_ID { get; set; }

            public int AchievedProcurementID { get; set; }
            public int AchievedProcurement { get; set; }
            public double ProcurementPercent { get; set; }
            public System.DateTime ProcurementDate { get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
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
            public System.DateTime ProcurementDate{ get; set; }
            public string Remarks { get; set; }
            public List<ComboProject> comboProjects { get; set; }
        }
        #endregion
    }

}
