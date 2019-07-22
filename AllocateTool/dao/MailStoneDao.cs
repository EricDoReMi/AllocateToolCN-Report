using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using AllocateTool.utils;
using Microsoft.Office.Interop.Excel;

namespace AllocateTool.dao
{
    /// <summary>
    /// 用于MailStoneDao的Excel
    /// </summary>
    public class MailStoneDao:ExcelDao
    {
        //ExcelHelper excHelper = new ExcelHelper();

        public Dictionary<string, HashSet<string>> FindMailRequestDic(string wbPath,out string msgReturn)
        {
            Dictionary<string, HashSet<string>> dicSht = null;
            System.Data.DataTable table = null;
            #region ExcelHelper的例子
            //Workbook wb = excHelper.OpenWorkBook(wbPath);
            //if (wb == null)
            //{
            //    msgReturn = "打开:"+ Path.GetFileNameWithoutExtension(wbPath)+"失败了";
            //    return dicSht;
            //}

            //Worksheet sht=wb.Sheets[1];

            //int lastLine = excHelper.GetLastLine(sht,1);
            //if (lastLine > 1)
            //{
            //    dicSht = new Dictionary<string, List<string>>();
            //    Range shtRange =sht.Range[sht.Cells[2, 1], sht.Cells[lastLine, 2]];
            //    msgReturn = "Ok";

            //    for (int i = 1; i <=lastLine; i++)
            //    {
            //        string keyStr = shtRange[i, 2].Value.Trim();
            //        string valueStr = shtRange[i, 1].Value.Trim();

            //        if (keyStr != "" && valueStr!="")
            //        {
            //            if (dicSht.ContainsKey(keyStr))
            //            {

            //                dicSht[keyStr].Add(valueStr);

            //            }
            //            else
            //            {
            //                List<string> shipmentList = new List<string>();
            //                shipmentList.Add(valueStr);
            //                dicSht.Add(keyStr, shipmentList);
            //            }
            //        }


            //    }



            //}
            //else {
            //    msgReturn = "表格没数据："+Path.GetFileNameWithoutExtension(wbPath);
            //}
            //excHelper.CloseWorkBook(wb, false);


            #endregion

            #region OledbExcel的例子
            try
            {
                OleDbConnection con = Begin(wbPath);
                string sql = "SELECT ShipmentReference,ConsolReference FROM [DBDatas$]";
                table = SelectToDataTable(con, sql);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Close();
            }

            if (table!=null && table.Rows.Count > 0)
            {
               dicSht = new Dictionary<string, HashSet<string>>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string keyStr = table.Rows[i]["ConsolReference"].ToString().Trim();
                    string valueStr = table.Rows[i]["ShipmentReference"].ToString().Trim();

                    if (keyStr != "" && valueStr != "")
                    {
                        if (dicSht.ContainsKey(keyStr))
                        {

                            dicSht[keyStr].Add(valueStr);

                        }
                        else
                        {
                            HashSet<string> shipmentSet = new HashSet<string>();
                            shipmentSet.Add(valueStr);
                            dicSht.Add(keyStr, shipmentSet);
                        }
                    }
                }

            }

  
            #endregion

            msgReturn = "";
            return dicSht; 
        }
    }
}
