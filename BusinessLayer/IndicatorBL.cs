﻿using DatabaseLayer;
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
        //GetAllLinkIndicator
        public List<GetAllLinkIndicatorVM> getALLLinkIndicatorBL()
        {
            return IndicatorDL.getALLLinkIndicatorDL();
        }
        public List<IndicatorDataTypeVM> getndicatorDataTypeBL(int IndicatorID)
        {
            return IndicatorDL.getndicatorDataTypeDL(IndicatorID);
        }

        #region IndicatorFieldValueBL
        public StatusModel indicatorFieldValueCreateBL(CreateIndicatorValueVM m)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IndicatorField_ID", typeof(int));
            dt.Columns.Add("IndicatorValueText", typeof(string));
            dt.Columns.Add("IndicatorValueInteger", typeof(int));
            dt.Columns.Add("IndicatorValueFloat", typeof(float));
            dt.Columns.Add("IndicatorValueBoolean", typeof(string));
            for (int i = 0; i < m.dataTypeVMLst.Count; i++)
            {
                dt.Rows.Add(m.dataTypeVMLst[i].IndicatorFieldID,m.dataTypeVMLst[i].TEXT, m.dataTypeVMLst[i].INTEGER, m.dataTypeVMLst[i].FLOAT, m.dataTypeVMLst[i].BOOL);
            }
            return IndicatorDL.indicatorFieldValueCreateDL(dt, m);
        }
        #endregion

    }
}
