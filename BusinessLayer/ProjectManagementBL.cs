
using DatabaseLayer;
using ModelLayer;

using System.Collections.Generic;

using System.Linq;

using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class ProjectManagementBL
    {

        #region CustomFuncation
        //JSON
        public List<GetAllProjectVM> SearchProjectByAttributesBL(string ProjectName, string ProjectType, string Location, int UserID, int RoleID)
        {
            return ProjectManagementDL.SearchProjectByAttributesDL(ProjectName.Trim(), ProjectType.Trim(), Location.Trim(), UserID,  RoleID);
        }
        //JSON
        public bool IsProjectNameExistsBL(string _ProjectName)
        {
            return ProjectManagementDL.IsProjectNameExistsDL(_ProjectName.Trim());
        }
        //JSON
        public RemainingValues RemainingValuesBL(int _ProjectID)
        {
            return ProjectManagementDL.RemainingValuesDL(_ProjectID);
        }
        public StatusModel ComparePlanned_PrucrementBL(int _ProjectID, out int PlannedProcurement, out int AchievedProcurement)
        {
            PlannedProcurement = 0;
            AchievedProcurement = 0;
            return ProjectManagementDL.ComparePlanned_PrucrementDL(_ProjectID, out PlannedProcurement, out AchievedProcurement);
        }

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
        public List<ComboIndicator> getComboIndicatorBL(int Project_ID, int BatchID)
        {
            return ProjectManagementDL.getComboIndicatorDL(Project_ID, BatchID);
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

        
        public GetProjectDetailsVM getProjectDetailsBL(int ProjectID)
        {
            var getData = ProjectManagementDL.getProjectDetailDL(ProjectID);
            getData.getProjectDetailsQ7Lst = new List<GetProjectDetailsQ7>();
            GetProjectDetailsQ7 m = null;
            for (int i = 0; i < getData.getProjectDetailsQ6Lst.Count; i++)
            {
                m = new GetProjectDetailsQ7();
                if (getData.getProjectDetailsQ6Lst[i].IntegerValue != 0)
                {
                    m.IndicatorName = getData.getProjectDetailsQ6Lst[i].IndicatorName;
                    m.IndicatorFieldName = getData.getProjectDetailsQ6Lst[i].IndicatorFieldName;
                    m.CommonFiled = getData.getProjectDetailsQ6Lst[i].IntegerValue;
                    getData.getProjectDetailsQ7Lst.Add(m);
                }
                else if (getData.getProjectDetailsQ6Lst[i].FloatValue != 0)
                {
                    m.IndicatorName = getData.getProjectDetailsQ6Lst[i].IndicatorName;
                    m.IndicatorFieldName = getData.getProjectDetailsQ6Lst[i].IndicatorFieldName;
                    m.CommonFiled = getData.getProjectDetailsQ6Lst[i].FloatValue;
                    getData.getProjectDetailsQ7Lst.Add(m);
                }
                else if (getData.getProjectDetailsQ6Lst[i].BoolValue != 0)
                {
                    m.IndicatorName = getData.getProjectDetailsQ6Lst[i].IndicatorName;
                    m.IndicatorFieldName = getData.getProjectDetailsQ6Lst[i].IndicatorFieldName;
                    m.CommonFiled = getData.getProjectDetailsQ6Lst[i].BoolValue;
                    getData.getProjectDetailsQ7Lst.Add(m) ;
                }
                else
                {
                    //item.CommonFiled = item.IndicatorValueText;
                }
            }

            //Distinct IndicatorName
            var DistinctItems = getData.getProjectDetailsQ7Lst.GroupBy(x => x.IndicatorName).ToList();
            for (int j = 0; j < DistinctItems.Count; j++)
            {
                getData.getIndicatorLst.Add(new IndicatorNames { IndicatorName = DistinctItems[j].Key }); ;
            }

            return getData;
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
