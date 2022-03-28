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
        public List<InsightIndicatorDataTypeCommonValueVM> getIndicatorInsertedFieldBaseOnIndicatorBL(int Project_ID,int InsightIndicatorID)
        {
            List <InsightIndicatorDataTypeConvertVM> lst = InsightIndicatorDL.getIndicatorInsertedFieldBaseOnIndicatorDL(Project_ID,InsightIndicatorID);
            List<InsightIndicatorDataTypeCommonValueVM> mLst = new List<InsightIndicatorDataTypeCommonValueVM>();
            InsightIndicatorDataTypeCommonValueVM m = new InsightIndicatorDataTypeCommonValueVM();
     
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].TEXT != null)
                {
                    mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].TEXT });
                }
                else if (lst[i].INTEGER != null)
                { 
                    mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].INTEGER });
                }
                else if (lst[i].FLOAT != null)
                { 
                    mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].FLOAT });
                }
                else if (lst[i].BOOLConvert != null)
                {
                    mLst.Add(new InsightIndicatorDataTypeCommonValueVM() { InsightIndicatorFieldID = lst[i].InsightIndicatorFieldID, InsightIndicatorFieldName = lst[i].InsightIndicatorFieldName, CommonValue = lst[i].BOOLConvert });
                }
            }
            return mLst;
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
