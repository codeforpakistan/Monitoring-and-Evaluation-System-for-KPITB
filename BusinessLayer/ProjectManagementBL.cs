using Dapper;
using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class ProjectManagementBL
    {

        #region CustomFuncation

        //Get SubProject
        public int checkUmberlaBL(int ProjectID)
        {
            return ProjectManagementDL.checkUmberlaDL(ProjectID);
        }
        //Get SubProject
        public int checkBatchIsZeroBL(int SubProjectID)
        {
            return ProjectManagementDL.checkBatchIsZeroDL(SubProjectID);
        }
        #endregion
        #region GetCombo
        //Get Project
        public List<ComboProject> getComboProjectBL(int LoginRoleID, int LoginUserID)
        {
            return ProjectManagementDL.getComboProjectDL(LoginRoleID, LoginUserID);
        }
        //Get SubProject
        public List<ComboSubProject> getComboSubProjectBL(int Project_ID,int Role_ID)
        {
            return ProjectManagementDL.getComboSubProjectDL(Project_ID, Role_ID);
        }
        //Get Batch
        public List<ComboBatch> getComboBatchBL(int SubProject_ID, int Role_ID)
        {
            return ProjectManagementDL.getComboBatchDL(SubProject_ID, Role_ID);
        }
        public List<ComboBatch> getComboBoxBatchBL(int Project_ID, int Role_ID)
        {
            return ProjectManagementDL.getComboBoxBatchDL(Project_ID, Role_ID);
        }
        public List<ComboIndicatorDataType> getComboDataTypeBL()
        {
            return ProjectManagementDL.getComboDataTypeDL();
        }
        public List<ComboIndicator> getComboIndicatorBL()
        {
            return ProjectManagementDL.getComboIndicatorDL();
        }
        //Get Category
        public List<ComboCategory> getCategoryBL()
        {
            return ProjectManagementDL.getCategoryDL();
        }
        //Get ProjectType
        public List<ComboProjectType> getProjectTypeBL()
        {
            return ProjectManagementDL.getProjectTypeDL();
        }
        //Get DigitalPolicy
        public List<ComboDigitalPolicy> getDigitalPolicyBL()
        {
            return ProjectManagementDL.getDigitalPolicyDL();
        }

        //Get Location / City
        public List<ComboCity> getCityBL()
        {
            return ProjectManagementDL.getCityDL();
        }
        public List<ComboRiskStatus> getRiskStatusBL()
        {
            return ProjectManagementDL.getRiskStatusDL();
        }
        #endregion
        #region ProjectCreate
        //ProjectCreate
        public StatusModel projectCreateBL(CreateProjectVM m)
        {
            return ProjectManagementDL.projectCreateDL(m);
        }


        #endregion
        #region ProjectView
        //GetAllProject
        public List<GetAllProjectVM> getAllProjectBL(int LoginRoleID, int LoginUserID)
        {
            return ProjectManagementDL.getProjectDL(LoginRoleID,LoginUserID);
        }

        public List<ComboFundingSource> getFudingSourceBL()
        {
            return ProjectManagementDL.getFudingSourceDL();
        }

        #endregion
        #region RecruitedCreate
        public StatusModel recruitedCreateBL(CreateRecruitedHRVM m)
        {
            return ProjectManagementDL.recruitedCreateDL(m);
        }
        #endregion
        #region RecruitedView
        //GetAllRecruitedHR
        public List<GetAllRecruitedHRVM> getAllRecruitedHRBL(int LoginRoleID, int LoginUserID)
        {
            return ProjectManagementDL.getRecruitedHRDL(LoginRoleID, LoginUserID);
        }
        //GetSingleRecruitedHR For Edit
        public EditRecruitedHRVM getSignleRecruitedHRBL(int RecruitedHR)
        {
            EditRecruitedHRVM m = ProjectManagementDL.getSignleRecruitedHRDL(RecruitedHR);
            return m;
        }
        //RecruitedHREdit
        public StatusModel recruitedHREditBL(EditRecruitedHRVM m)
        {
            return ProjectManagementDL.recruitedEditDL(m);
        }
        #endregion
        #region Procurement
        //ProcurementCreate
        public StatusModel procurementCreateBL(CreateProcurementVM m)
        {
            return ProjectManagementDL.procurementCreateDL(m);
        }
        //GetAllProcurement
        public List<GetAllProcurementVM> getAllProcurementBL(int LoginRoleID, int LoginUserID)
        {
            return ProjectManagementDL.getProcurementDL(LoginRoleID, LoginUserID);
        }
        //GetSingalProcurement
        public EditProcurementVM getSignleProcurementBL(int AchievedProcurementID)
        {
            EditProcurementVM m = ProjectManagementDL.getSignleProcurementDL(AchievedProcurementID);
            return m;
        }
        //ProcurementEdit
        public StatusModel procurementEditBL(EditProcurementVM m)
        {
            return ProjectManagementDL.procurementEditDL(m);
        }
        #endregion
    }
}
