using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace AllocateTool.utils
{
    public class ExcelHelper
    {
        private  Excel.Application excelApp = new Excel.Application();

        public  void CloseSwitch(bool switchFlag)
        {
            if (switchFlag)
            {
                excelApp.ScreenUpdating = false;
                excelApp.DisplayAlerts = false;
                excelApp.AskToUpdateLinks = false;
                excelApp.Visible = false;
            }
            else
            {
                excelApp.ScreenUpdating = true;
                excelApp.DisplayAlerts = true;
                excelApp.AskToUpdateLinks = true;
                excelApp.Visible = true;
            }
        }

        public  Workbook OpenWorkBook(string workbookPath)
        {
            Workbook wb = null;
            if (!File.Exists(workbookPath))
            {
                return wb;
            }

            try
            {
                wb = excelApp.Workbooks.Open(workbookPath);
            }
            catch (Exception)
            {

                
            }

            return wb;
            

        }

        public  void CloseWorkBook(Workbook wb,bool saveChange)
        {
            if (saveChange)
            {
                wb.Close(true);
            }
            else
            {
                wb.Close(false);
            }


        }
        public int GetLastLine(Worksheet sht,int columnNum)
        {
            return sht.Cells[sht.Rows.Count, columnNum].End[XlDirection.xlUp].Row;

        }

        public int GetLastColumn(Worksheet sht, int lineNum)
        {
            return sht.Cells[lineNum,sht.Columns.Count].End[XlDirection.xlToRight].Column;

        }
    }
}
