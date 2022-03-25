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
        public List<GetAllInsightIndicatorVM> getAllInsightIndicatorBL()
        {
            return InsightIndicatorDL.getAllInsightIndicatorDL();
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
        public List<IndicatorDataTypeVM> getndicatorDataTypeBL(int IndicatorID)
        {
            return InsightIndicatorDL.getndicatorDataTypeDL(IndicatorID);
        }
        public List<IndicatorDataTypeCommonValueVM> getIndicatorInsertedFieldBaseOnIndicatorBL(int Project_ID,int IndicatorID)
        {
            List <IndicatorDataTypeConvertVM> lst = InsightIndicatorDL.getIndicatorInsertedFieldBaseOnIndicatorDL(Project_ID,IndicatorID);
            List<IndicatorDataTypeCommonValueVM> mLst = new List<IndicatorDataTypeCommonValueVM>();
            IndicatorDataTypeCommonValueVM m = new IndicatorDataTypeCommonValueVM();
     
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].TEXT != null)
                {
                    mLst.Add(new IndicatorDataTypeCommonValueVM() { IndicatorFieldID = lst[i].IndicatorFieldID, IndicatorFieldName = lst[i].IndicatorFieldName, CommonValue = lst[i].TEXT });
                }
                else if (lst[i].INTEGER != null)
                { 
                    mLst.Add(new IndicatorDataTypeCommonValueVM() { IndicatorFieldID = lst[i].IndicatorFieldID, IndicatorFieldName = lst[i].IndicatorFieldName, CommonValue = lst[i].INTEGER });
                }
                else if (lst[i].FLOAT != null)
                { 
                    mLst.Add(new IndicatorDataTypeCommonValueVM() { IndicatorFieldID = lst[i].IndicatorFieldID, IndicatorFieldName = lst[i].IndicatorFieldName, CommonValue = lst[i].FLOAT });
                }
                else if (lst[i].BOOLConvert != null)
                {
                    mLst.Add(new IndicatorDataTypeCommonValueVM() { IndicatorFieldID = lst[i].IndicatorFieldID, IndicatorFieldName = lst[i].IndicatorFieldName, CommonValue = lst[i].BOOLConvert });
                }
            }
            return mLst;
        }

        #region IndicatorFieldValueBL
        public StatusModel indicatorFieldValueCreateBL(CreateIndicatorValueVM m)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IndicatorField_ID", typeof(int));
            dt.Columns.Add("IndicatorValueText", typeof(string));
            dt.Columns.Add("IndicatorValueInteger", typeof(int));
            dt.Columns.Add("IndicatorValueFloat", typeof(float));
            dt.Columns.Add("IndicatorValueBoolean", typeof(bool));

    
            for (int i = 0; i < m.dataTypeVMLst.Count; i++)
            {
                dt.Rows.Add(m.dataTypeVMLst[i].IndicatorFieldID,m.dataTypeVMLst[i].TEXT, m.dataTypeVMLst[i].INTEGER, m.dataTypeVMLst[i].FLOAT, m.dataTypeVMLst[i].BOOL);
            }
           
            return InsightIndicatorDL.indicatorFieldValueCreateDL(dt, m);
        }
        #endregion

    }
}
