

 
using MonitoringAndEvaluation_System.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ModelLayer.ComboModel;

namespace MonitoringAndEvaluation_System.CommonUse
{
    public class CommonCode : BaseController
    {
        #region CUSTOM_FUNCTION

        public void allDropDown(List<ComboProject> comboProject, List<ComboSubProject> comboSubProject, List<ComboBatch> comboBatch)
        {
            comboProject = new BusinessLayer.ProjectManagementBL().getComboProjectBL(LoginRoleID, LoginUserID);
            ComboSubProject msp = new ComboSubProject() { SubProjectID = 0, SubProjectName = "Please Select SubProject" };
            comboSubProject.Add(msp); //= ObjProjectMngBL.getComboSubProjectBL(recruitedHRVM.Project_ID,LoginRoleID);
            ComboBatch mb = new ComboBatch() { BatchID = 0, BatchName = "Please Select Batch" };
            comboBatch.Add(mb); //=ObjProjectMngBL.getComboBatchBL(recruitedHRVM.SubProject_ID, LoginRoleID);
        }
        #endregion
    }
}