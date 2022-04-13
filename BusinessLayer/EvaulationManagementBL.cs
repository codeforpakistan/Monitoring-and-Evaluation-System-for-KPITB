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
    public class EvaulationManagementBL
    {
        public KPIsANDInsightIndicatorVM InsightIndicatorForEvaulationBL(int _ProjectID, int? SubProject_ID, int? Batch_ID)
        {
            KPIsANDInsightIndicatorVM returnList = new KPIsANDInsightIndicatorVM();
            returnList = EvaulationManagementDL.InsightIndicatorForEvaulationDL(_ProjectID, SubProject_ID, Batch_ID);

            //List<InsightIndicatorDataTypeCommonValueVM> mLst = new List<InsightIndicatorDataTypeCommonValueVM>();
            //InsightIndicatorDataTypeCommonValueVM m = new InsightIndicatorDataTypeCommonValueVM();

            //#region CommonValue
            ////INTEGER_SUM
            //var SumValue = returnList.GroupBy(x => new { x.InsightIndicatorFieldName }).Select(x => {
            //    var ret = x.First();
            //    ret.INTEGER = x.Sum(xt => xt.INTEGER);
            //    return ret;
            //}).ToList();

            //for (int i = 0; i < SumValue.Count; i++)
            //{
            //    if (SumValue != null)
            //    {
            //        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = SumValue[i].InsightIndicatorFieldID, InsightIndicatorFieldName = SumValue[i].InsightIndicatorFieldName, CommonValue = SumValue[i].INTEGER });
            //    }
            //}

            ////FLOAT_SUM
            //var FloatValue = returnList.Where(w => w.FLOAT != null ||  w.FLOAT != 0).GroupBy(x => new { x.InsightIndicatorFieldName }).Select(x => {
            //    var ret = x.First();
            //    ret.FLOAT = x.Sum(ft => ft.FLOAT);
            //    return ret;
            //}).ToList();

            //for (int i = 0; i < FloatValue.Count; i++)
            //{
            //    if (FloatValue != null)
            //    {
            //        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = FloatValue[i].InsightIndicatorFieldID, InsightIndicatorFieldName = FloatValue[i].InsightIndicatorFieldName, CommonValue = FloatValue[i].FLOAT });
            //    }
            //}

            ////BOOL_COUNT
            //var BoolValue = returnList.Where(w => w.BOOLConvert == "YES" && w.BOOLConvert != null).ToList();
            //var numSpecialBooks = returnList.Count(n => n.BOOLConvert == "YES");
            //for (int i = 0; i < BoolValue.Count; i++)
            //{
            //    mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = BoolValue[i].InsightIndicatorFieldID, InsightIndicatorFieldName = BoolValue[i].InsightIndicatorFieldName, CommonValue = BoolValue.Count });
            //}

            ////TEXT
            //var TextValue = returnList.Where(w => w.TEXT != null).GroupBy(x => new { x.InsightIndicatorFieldName }).ToList();
            //foreach (var item in TextValue)
            //{
            //    foreach (var subitem in item)
            //    {
            //        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = subitem.InsightIndicatorFieldID, InsightIndicatorFieldName = subitem.InsightIndicatorFieldName, CommonValue = subitem.TEXT });
            //    }
            //}

            //#endregion




            return returnList;
        }
        public StatusModel  InsertEvaulationBL(CreateProjectKPIsStatusVM modelVM)
        {
            return  EvaulationManagementDL.InsertEvaulationDL(modelVM);
        }


    }
}
