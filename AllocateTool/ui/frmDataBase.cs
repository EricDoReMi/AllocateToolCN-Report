using AllocateTool.control;
using AllocateTool.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllocateTool.ui
{
    public partial class frmDataBase : Form
    {

        TransferDataControl tsfDataCon = new TransferDataControl();

        public frmDataBase()
        {
            InitializeComponent();
        }

        private void frmDataBase_Load(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Today;
            DateTime stopDate = startDate.AddDays(1);
            dateTimePickerStartDate.Value = startDate;
            dateTimePickerStopDate.Value = stopDate;
         
            LoadFormData(startDate,stopDate);
        }

        private void LoadFormData(DateTime startDate, DateTime stopDate)
        {
            if (DateTime.Compare(startDate, stopDate) > 0)
            {
                MessageBox.Show("StartDate应小于StopDate");
                return;
            }

            List<RecordSum> recordSumList = tsfDataCon.FindRecordSumListByDate(startDate, stopDate,this.Tag.ToString());
            if (recordSumList.Count > 0)
            {
                dgvDataBase.DataSource = recordSumList;
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(dateTimePickerStartDate.Text);
            DateTime stopDate = Convert.ToDateTime(dateTimePickerStopDate.Text);

            LoadFormData(startDate, stopDate);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(dateTimePickerStartDate.Text);
            DateTime stopDate = Convert.ToDateTime(dateTimePickerStopDate.Text);
            if (DateTime.Compare(startDate, stopDate) > 0)
            {
                MessageBox.Show("StartDate应小于StopDate");
                return;
            }

            List<RecordSum> recordSumList = tsfDataCon.FindRecordSumListByDate(startDate, stopDate, this.Tag.ToString());

            string outputPath = @".\resultDatas\";

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            using (StreamWriter sw = new StreamWriter(outputPath + startDate.ToString
                 ("yyyyMMdd")+"_"+ stopDate.ToString
                 ("yyyyMMdd") + ".csv", false, Encoding.Default))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Id,Subject,StationCode,ASNLink,Branch,DBName,MailIncomeDate");

                sw.WriteLine(sb.ToString());

                for (int i = 0; i < recordSumList.Count; i++)
                {
                    RecordSum recordSum = recordSumList[i];

                    string subjectStr = recordSum.M_subject.ToUpper().Trim();

                       
                        
                    StringBuilder sbTmp = new StringBuilder();
                    sbTmp.Append("\"" + recordSum.M_id + "\"");
                    sbTmp.Append(",");

                    sbTmp.Append("\"" + subjectStr + "\"");
                    sbTmp.Append(",");

                    sbTmp.Append("\"" + recordSum.M_requestID + "\"");
                    sbTmp.Append(",");

                    sbTmp.Append("\"" + recordSum.M_importance + "\"");
                    sbTmp.Append(",");

                    sbTmp.Append("\"" + recordSum.M_Branch + "\"");
                    sbTmp.Append(",");

                    sbTmp.Append("\"" + recordSum.M_dbName + "\"");
                    sbTmp.Append(",");

                    sbTmp.Append("\"" + recordSum.M_mailincometime.ToString() + "\"");
                    

                    sw.WriteLine(sbTmp.ToString());


                        
                    }

                MessageBox.Show("导出成功了");

                
            }
        }
    }
}
