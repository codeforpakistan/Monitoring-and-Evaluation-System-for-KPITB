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
        public StatusModel ComparePlanned_BudgetBL(int _ProjectID, out int ApprovedBudget, out int ReleasedBudget)
        {
            ApprovedBudget = 0;
            ReleasedBudget = 0;
            return FinanceManagementDL.ComparePlanned_BudgetDL(_ProjectID, out ApprovedBudget, out ReleasedBudget);
        }
        public StatusModel CompareReleased_ExpenditureBL(int _ProjectID, out int ReleasedBudget, out int ExpenditureBudget)
        {
            ReleasedBudget = 0;
            ExpenditureBudget = 0;
            return FinanceManagementDL.CompareReleased_ExpenditureDL(_ProjectID, out ReleasedBudget, out ExpenditureBudget);
        }


        //ReleasedCreateView
        public StatusModel releasedCreateViewBL(CreateViewReleasedBudgetVM m)
        {
            return FinanceManagementDL.releasedCreateViewDL(m);
        }
        //GetSingleReleasedBuget For Edit
        public EditReleasedBudgetVM getSignleReleasedBudgetBL(int ReleasedBudgetID)
        {
            EditReleasedBudgetVM m = FinanceManagementDL.getSignleReleasedBudgetDL(ReleasedBudgetID);
            return m;
        }
        //GetAllReleasedBudget
        public List<GetAllReleasedBudgetVM> getAllReleasedBudgetBL(int LoginRoleID, int LoginUserID)
        {
            return FinanceManagementDL.getAllReleasedBudgetDL(LoginRoleID, LoginUserID);
        }
        //ExpenditureCreateView
        public StatusModel expenditureCreateViewBL(CreateViewExpenditureBudgetVM m)
        {
            return FinanceManagementDL.expenditureCreateViewDL(m);
        }
        //GetAllExpenditureBudget
        public List<GetAllExpenditureBudgetVM> getAllExpenditureBudgetBL(int LoginRoleID, int LoginUserID)
        {
            return FinanceManagementDL.getAllExpenditureBudgetDL(LoginRoleID, LoginUserID);
        }
        //GetSingalProcurement
        public EditProcurementVM getSignleProcurementBL(int AchievedProcurementID)
        {
            EditProcurementVM m = ProjectManagementDL.getSignleProcurementDL(AchievedProcurementID);
            return m;
        }
        //GetAllExpenditureBudget
       
        #endregion
    }
}
