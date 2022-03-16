using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
        //public StatusModel expenditureCreateViewBL(CreateViewExpenditureBudgetVM m)
        //{
        //    return FinanceManagementDL.expenditureCreateViewDL(m);
        //}
        public StatusModel expenditureCreateViewBL(List<CreateViewExpenditureBudgetVM> Lst)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Project_ID", typeof(int));
            dt.Columns.Add("SubProject_ID", typeof(int));
            dt.Columns.Add("Batch_ID", typeof(int));
            dt.Columns.Add("ExpenditureDate", typeof(DateTime));
            dt.Columns.Add("BudgetHead", typeof(string));
            dt.Columns.Add("ApprovedCost", typeof(int));
            dt.Columns.Add("ExpenditureBudget", typeof(int));
           
            for (int i = 0; i < Lst.Count; i++)
            {
                dt.Rows.Add(Lst[i].Project_ID, Lst[i].SubProject_ID, Lst[i].Batch_ID, Lst[i].ExpenditureDate=DateTime.Now, Lst[i].BudgetHead, Lst[i].ApprovedCost, Lst[i].ExpenditureBudget);
            }
            return FinanceManagementDL.expenditureCreateViewDL(dt);
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
