using DatabaseLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.ComboModel;

namespace BusinessLayer
{
    public class ChangeManagementBL
    {
        public List<ChangeManagement> GetChangeManagementDataBL(int _ProjectID)
        {
            return ChangeManagementDL.GetChangeManagementDataDL(_ProjectID);
        }

        }
}
