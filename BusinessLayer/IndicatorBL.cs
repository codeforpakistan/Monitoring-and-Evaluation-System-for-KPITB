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
    public class IndicatorBL
    {
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
    }
}
