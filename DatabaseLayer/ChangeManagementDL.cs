using Dapper;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.ComboModel;

namespace DatabaseLayer
{
    public class ChangeManagementDL
    {
        public static List<ChangeManagement> GetChangeManagementDataDL(int _ProjectID)
        {
            List<ChangeManagement> returnList = new List<ChangeManagement>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ProjectID", _ProjectID);
                returnList = Repose.GetList<ChangeManagement>("sp_GetChangeManagementData", ObjParm); 
            }
            catch (Exception ex)
            {
                throw;
            }
            return returnList;
        }
    }
}
