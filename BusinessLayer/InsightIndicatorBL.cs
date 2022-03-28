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
    public class InsightIndicatorBL
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
            return InsightIndicatorDL.indicatorFeildCreateDL(dt);
        }
        #endregion

        //JSON
        public bool IsIndicatorNameExistsBL(string _IndicatorName)
        {
            return InsightIndicatorDL.IsIndicatorNameExistsDL(_IndicatorName.Trim());
        }
        //Createindicator
        public StatusModel insightIndicatorCreateBL(CreateInsightIndicatorVM m)
        {
            return InsightIndicatorDL.insightIndicatorCreateDL(m);
        }
        //GetAllIndicator
        public List<GetAllInsightIndicatorVM> getAllInsightIndicatorBL(int LoginRoleID, int LoginUserID)
        {
            return InsightIndicatorDL.getAllInsightIndicatorDL(LoginRoleID, LoginUserID);
        }
        //CreateLinkIndicator
        public StatusModel linkIndicatorCreateBL(CreateLinkIndicatorVM m)
        {
            return InsightIndicatorDL.linkIndicatorCreateDL(m);
        }
        //GetAllLinkIndicator
        public List<GetAllLinkIndicatorVM> getALLLinkIndicatorBL()
        {
            return InsightIndicatorDL.getALLLinkIndicatorDL();
        }
        public List<InsightIndicatorDataTypeVM> getndicatorDataTypeBL(int InsightIndicatorID)
        {
            return InsightIndicatorDL.getndicatorDataTypeDL(InsightIndicatorID);
        }
        public List<InsightIndicatorDataTypeCommonValueVM> getIndicatorInsertedFieldBaseOnIndicatorBL( int InsightIndicatorID)
        {
            try
            {

          
            List <InsightIndicatorDataTypeConvertVM> lst = InsightIndicatorDL.getIndicatorInsertedFieldBaseOnIndicatorDL(InsightIndicatorID);
            List<InsightIndicatorDataTypeCommonValueVM> mLst = new List<InsightIndicatorDataTypeCommonValueVM>();
            InsightIndicatorDataTypeCommonValueVM m = new InsightIndicatorDataTypeCommonValueVM();
          
                #region NEW
                //INTEGER_SUM
                var SumValue = lst.GroupBy(x => new { x.InsightIndicatorFieldName }).Select(x => {
                                                                                                                                                                        var ret = x.First();
                                                                                                                                                                        ret.INTEGER = x.Sum(xt => xt.INTEGER);
                                                                                                                                                                        return ret;
                                                                                                                                                                    }).ToList();

                for (int i = 0; i < SumValue.Count; i++)
                {
                    if (SumValue != null)
                    {
                        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = SumValue[i].InsightIndicatorFieldID, InsightIndicatorFieldName = SumValue[i].InsightIndicatorFieldName, CommonValue = SumValue[i].INTEGER });
                    }
                }

                //FLOAT_SUM
                var FloatValue = lst.Where(w => w.FLOAT != null).GroupBy(x => new { x.InsightIndicatorFieldName }).Select(x => {
                    var ret = x.First();
                    ret.FLOAT = x.Sum(ft => ft.FLOAT);
                    return ret;
                }).ToList();

                for (int i = 0; i < FloatValue.Count; i++)
                {
                    if (FloatValue != null)
                    {
                        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = FloatValue[i].InsightIndicatorFieldID, InsightIndicatorFieldName = FloatValue[i].InsightIndicatorFieldName, CommonValue = FloatValue[i].FLOAT });
                    }
                }

                //BOOL_COUNT
                var BoolValue = lst.Where(w => w.BOOLConvert == "YES" && w.BOOLConvert != null).ToList();
                var numSpecialBooks = lst.Count(n => n.BOOLConvert == "YES");
                for (int i = 0; i < BoolValue.Count; i++)
                {
                    mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = BoolValue[i].InsightIndicatorFieldID, InsightIndicatorFieldName = BoolValue[i].InsightIndicatorFieldName, CommonValue = BoolValue.Count });
                }


                //TEXT
                var TextValue = lst.Where(w => w.TEXT != null).GroupBy(x => new { x.InsightIndicatorFieldName }).ToList();

          
                foreach (var item in TextValue)
                {
                    foreach (var subitem in item)
                    {
                        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = subitem.InsightIndicatorFieldID, InsightIndicatorFieldName = subitem.InsightIndicatorFieldName, CommonValue = subitem.TEXT });
                    }
                }



                #endregion
                #region OLD

                //for (int i = 0; i < lst.Count; i++)
                //{
                //    if (lst[i].TEXT != null)
                //    {
                //        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].TEXT });
                //    }
                //    else if (lst[i].INTEGER != null)
                //    {

                //        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].INTEGER });
                //    }
                //    else if (lst[i].FLOAT != null)
                //    {
                //        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].FLOAT });
                //    }
                //    else if (lst[i].BOOLConvert != null)
                //    {
                //        mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].BOOLConvert });
                //    }
                //} 
                #endregion
                return mLst;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        #region IndicatorFieldValueBL
        public StatusModel InsightIndicatorFieldValueCreateBL(CreateInsightIndicatorValueVM m)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("InsightIndicatorField_ID", typeof(int));
            dt.Columns.Add("InsightIndicatorValueText", typeof(string));
            dt.Columns.Add("InsightIndicatorValueInteger", typeof(int));
            dt.Columns.Add("InsightIndicatorValueFloat", typeof(float));
            dt.Columns.Add("InsightIndicatorValueBoolean", typeof(bool));

    
            for (int i = 0; i < m.dataTypeVMLst.Count; i++)
            {
                dt.Rows.Add(m.dataTypeVMLst[i].InsightIndicatorFieldID, m.dataTypeVMLst[i].TEXT, m.dataTypeVMLst[i].INTEGER, m.dataTypeVMLst[i].FLOAT, m.dataTypeVMLst[i].BOOL);
            }
           
            return InsightIndicatorDL.InsightIndicatorFieldValueCreateDL(dt, m);
        }
        #endregion

    }
}
