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
    public class IndicatorBL
    {

        #region IndicatorFieldBL
        public StatusModel indicatorFeildCreateBL(List<CreateIndicatorFieldVM> Lst)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Indicator_ID", typeof(int));
            dt.Columns.Add("IndicatorDataType_ID", typeof(int));
            dt.Columns.Add("IndicatorFieldName", typeof(string));
            for (int i = 0; i < Lst.Count; i++)
            {
                dt.Rows.Add(Lst[i].Indicator_ID, Lst[i].IndicatorDataType_ID, Lst[i].IndicatorFieldName);
            }
            return IndicatorDL.indicatorFeildCreateDL(dt);
        }
        #endregion
        //Createindicator
        public StatusModel indicatorCreateBL(CreateIndicatorVM m)
        {
            return IndicatorDL.indicatorCreateDL(m);
        }
        //GetAllIndicator
        public List<GetAllIndicatorVM> getAllIndicatorBL()
        {
            return IndicatorDL.getAllIndicatorDL();
        }
        //CreateLinkIndicator
        public StatusModel linkIndicatorCreateBL(CreateLinkIndicatorVM m)
        {
            return IndicatorDL.linkIndicatorCreateDL(m);
        }
         
        public List<IndicatorDataTypeVM> getndicatorDataTypeBL(int IndicatorID)
        {
            return IndicatorDL.getndicatorDataTypeDL(IndicatorID);
        }
    }
}
