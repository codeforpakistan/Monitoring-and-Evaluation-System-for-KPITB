using DatabaseLayer;
using ModelLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.ComboModel;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class ChangeManagementBL
    {
        public List<ChangeManagement> GetChangeManagementDataBL(int _ProjectID)
        {
            return ChangeManagementDL.GetChangeManagementDataDL(_ProjectID);
        }

        //CreateIssues
        public StatusModel changeManagementCreateBL(ChangeManagementVM m)
        {
            return ChangeManagementDL.changeManagementCreateDL(m);
        }

    }
}
