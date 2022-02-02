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
    public class BatchManagementBL
    {
        public StatusModel batchCreateBL(CreateBatchVM m)
        {
            return BatchManagementDL.batchCreateViewDL(m);
        }
        public List<GetAllBatchVM> getAllBatchBL(int LoginRoleID, int LoginUserID)
        {
            return BatchManagementDL.getALLBatcheDL(LoginRoleID, LoginUserID);
        }
    }
}
