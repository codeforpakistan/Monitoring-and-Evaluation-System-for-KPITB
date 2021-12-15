using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class FinanceManagementBL
    {
        #region Finance
        //ReleasedCreateView
        public StatusModel releasedCreateViewBL(CreateViewReleasedBudgetVM m)
        {
            return FinanceManagementDL.releasedCreateViewDL(m);
        }
        //ExpenditureCreateView
        public StatusModel expenditureCreateViewBL(CreateViewExpenditureBudgetVM m)
        {
            return FinanceManagementDL.expenditureCreateViewDL(m);
        }
        //GetAllReleasedBudget
        public List<GetAllReleasedBudgetVM> getAllReleasedBudgetBL()
        {
            return FinanceManagementDL.getAllReleasedBudgetDL();
        }
        //GetSingalProcurement
        public EditProcurementVM getSignleProcurementBL(int AchievedProcurementID)
        {
            EditProcurementVM m = ProjectManagementDL.getSignleProcurementDL(AchievedProcurementID);
            return m;
        }
        #endregion
    }
}
