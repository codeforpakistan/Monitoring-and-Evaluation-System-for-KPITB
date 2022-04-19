using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.MainViewModel;
using static ModelLayer.StoreProcModel;

namespace BusinessLayer
{
    public class DashboardManangmentBL
    {
        public Dashboardv3 dashboardv3BL(int? ProjectTypeID)
        {
            Dashboardv3 getData = Dashboard.dashboardv3DL(ProjectTypeID);
            for (int i = 0; i < getData.dv3ImpactIndicatorsLst.Count; i++)
            {
                dv3ImpactIndicatorMerge m = new dv3ImpactIndicatorMerge();
                if (getData.dv3ImpactIndicatorsLst[i].InsightIntegerValue != 0)
                {
                    m.InsightIndicatorName = getData.dv3ImpactIndicatorsLst[i].InsightIndicatorName;
                    m.InsightIndicatorFieldName = getData.dv3ImpactIndicatorsLst[i].InsightIndicatorFieldName;
                    m.CommonFiled = getData.dv3ImpactIndicatorsLst[i].InsightIntegerValue;
                    getData.dv3ImpactIndicatorMergesLst.Add(m);
                }
                else if (getData.dv3ImpactIndicatorsLst[i].FloatValue != 0)
                {
                    m.InsightIndicatorName = getData.dv3ImpactIndicatorsLst[i].InsightIndicatorName;
                    m.InsightIndicatorFieldName = getData.dv3ImpactIndicatorsLst[i].InsightIndicatorFieldName;
                    m.CommonFiled = getData.dv3ImpactIndicatorsLst[i].FloatValue;
                    getData.dv3ImpactIndicatorMergesLst.Add(m);
                }
                else if (getData.dv3ImpactIndicatorsLst[i].BoolValue != 0)
                {
                    m.InsightIndicatorName = getData.dv3ImpactIndicatorsLst[i].InsightIndicatorName;
                    m.InsightIndicatorFieldName = getData.dv3ImpactIndicatorsLst[i].InsightIndicatorFieldName;
                    m.CommonFiled = getData.dv3ImpactIndicatorsLst[i].BoolValue;
                    getData.dv3ImpactIndicatorMergesLst.Add(m);
                }
                else
                {
                    //item.CommonFiled = item.IndicatorValueText;
                }
            }
            return getData;
        }
    }
}
