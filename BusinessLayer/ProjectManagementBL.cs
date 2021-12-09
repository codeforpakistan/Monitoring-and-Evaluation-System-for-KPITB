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
        #region GetCombo
        //Get Project
        public List<ComboProject> getComboProjectBL()
        {
            return ProjectManagementDL.getComboProjectDL();
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
        public List<GetAllProjectVM> getAllProjectBL()
        {
            return ProjectManagementDL.getProjectDL();
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
        //GetAllProject
        public List<GetAllRecruitedHRVM> getAllRecruitedHRBL()
        {
            return ProjectManagementDL.getRecruitedHRDL();
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
    }
}
