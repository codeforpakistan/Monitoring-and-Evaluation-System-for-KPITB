
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
        public List<GetAllRecruitedHRVM> SearchRecruitedHRByAttributesBL(string ProjectName, string BatchName, string FromDate, string ToDate, int UserID, int RoleID)
        {
            return ProjectManagementDL.SearchRecruitedHRByAttributesDL(ProjectName.Trim(), BatchName.Trim(), FromDate.Trim(), ToDate.Trim(), UserID, RoleID);
        }
        //JSON
        public bool IsProjectNameExistsBL(string _ProjectName)
        {
            return ProjectManagementDL.IsProjectNameExistsDL(_ProjectName.Trim());
        }
        //JSON
        public RemainingValues RemainingValuesBL(int _ProjectID, int? SubProjectID)
        {
            return ProjectManagementDL.RemainingValuesDL(_ProjectID, SubProjectID);
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
        public List<ComboBatch> getComboBoxBatchBL(int Project_ID, int Role_ID, int? SubProjectID)
        {
            return ProjectManagementDL.getComboBoxBatchDL(Project_ID, Role_ID, SubProjectID);
        }
        public List<ComboIndicator> getComboIndicatorBL(int Project_ID, int? SubProjectID, int? Batch_ID)
        {
            return ProjectManagementDL.getComboIndicatorDL(Project_ID, SubProjectID, Batch_ID);
        }
        public List<ComboProcurementHead> getComboProcurementHeadBL(int Project_ID, int? SubProject_ID)
        {
            return ProjectManagementDL.getComboProcurementHeadDL(Project_ID, SubProject_ID);
        }
        public List<ComboPlannedKPIs> getComboPlannedKPIsBL()
        {
            return ProjectManagementDL.getComboPlannedKPIsDL();
        }
        public List<ComboInsightIndicatorDataType> getComboDataTypeBL()
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
        //Get Project SDGS
        public List<ComboSDGS> getSDGSBL()
        {
            return ProjectManagementDL.getSDGSDL();
        }
        //Get ProjectStatus
        public List<ComboProjectStatus> getProjectStatusBL()
        {
            return ProjectManagementDL.getProjectStatusDL();
        }

        public List<ComboRiskStatus> getRiskStatusBL()
        {
            return ProjectManagementDL.getRiskStatusDL();
        }
        //Get RiskMitigation
        public List<ComboRiskMitigation> getRiskMitigationBL()
        {
            return ProjectManagementDL.getRiskMitigationDL();
        }
        //Get TypeOfStakeholder
        public List<ComboTypeOfStakeholder> getTypeOfStakeholderBL()
        {
            return ProjectManagementDL.getTypeOfStakeholderDL();
        }
        #endregion
        #region ProjectCreate
        //ProjectCreate
        public StatusModel projectCreateBL(CreateProjectVM m)
        {
            return ProjectManagementDL.projectCreateDL(m);
        }
        public StatusModel subProjectCreateBL(CreateProjectVM m)
        {
            return ProjectManagementDL.subProjectCreateDL(m);
        }



        #endregion
        #region ProjectView
        //GetAllProject
        public List<GetAllProjectVM> getAllProjectBL(int LoginRoleID, int LoginUserID)
        {
            return ProjectManagementDL.getProjectDL(LoginRoleID,LoginUserID);
        }
        //GetAllProject
        public List<GetAllProjectVM> getAllSubProjectBL(int LoginRoleID, int LoginUserID)
        {
            return ProjectManagementDL.getSubProjectDL(LoginRoleID, LoginUserID);
        }


        public GetProjectDetailsVM getProjectDetailsBL(int ProjectID)
        {
          

           var getData = ProjectManagementDL.getProjectDetailDL(ProjectID);
            if (getData.getProjectDetailsQ5 == null)
            {
                GetProjectDetailsQ5 dd = new GetProjectDetailsQ5();
                dd.ObjectiveName = "";
                getData.getProjectDetailsQ5 = dd;
            }

            getData.getProjectDetailsQ7Lst = new List<GetProjectDetailsQ7>();
            GetProjectDetailsQ7 m = null;
            for (int i = 0; i < getData.getProjectDetailsQ6Lst.Count; i++)
            {
                m = new GetProjectDetailsQ7();
                if (getData.getProjectDetailsQ6Lst[i].InsightIntegerValue != 0)
                {
                    m.InsightIndicatorName = getData.getProjectDetailsQ6Lst[i].InsightIndicatorName;
                    m.InsightIndicatorFieldName = getData.getProjectDetailsQ6Lst[i].InsightIndicatorFieldName;
                    m.CommonFiled = getData.getProjectDetailsQ6Lst[i].InsightIntegerValue;
                    getData.getProjectDetailsQ7Lst.Add(m);
                }
                else if (getData.getProjectDetailsQ6Lst[i].FloatValue != 0)
                {
                    m.InsightIndicatorName = getData.getProjectDetailsQ6Lst[i].InsightIndicatorName;
                    m.InsightIndicatorFieldName = getData.getProjectDetailsQ6Lst[i].InsightIndicatorFieldName;
                    m.CommonFiled = getData.getProjectDetailsQ6Lst[i].FloatValue;
                    getData.getProjectDetailsQ7Lst.Add(m);
                }
                else if (getData.getProjectDetailsQ6Lst[i].BoolValue != 0)
                {
                    m.InsightIndicatorName = getData.getProjectDetailsQ6Lst[i].InsightIndicatorName;
                    m.InsightIndicatorFieldName = getData.getProjectDetailsQ6Lst[i].InsightIndicatorFieldName;
                    m.CommonFiled = getData.getProjectDetailsQ6Lst[i].BoolValue;
                    getData.getProjectDetailsQ7Lst.Add(m) ;
                }
                else
                {
                    //item.CommonFiled = item.IndicatorValueText;
                }
            }

            //Distinct IndicatorName
            var DistinctItems = getData.getProjectDetailsQ7Lst.GroupBy(x => x.InsightIndicatorName).ToList();
            for (int j = 0; j < DistinctItems.Count; j++)
            {
                getData.getIndicatorLst.Add(new InsightIndicatorNames { InsightIndicatorName = DistinctItems[j].Key }); ;
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
