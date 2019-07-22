using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllocateTool.control;
using Microsoft.VisualBasic;


namespace AllocateTool.ui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        TransferDataControl tsfDataCon = new TransferDataControl();

        /// <summary>
        /// 更新records表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadRecordsButton_Click(object sender, EventArgs e)
        {
            if (this.UsingDBText.Text.Length > 0 && this.SumDBText.Text.Length > 0)
            {

                try
                {
                    tsfDataCon.TransferRecordDataBases(this.SumDBText.Text, this.UsingDBText.Text);
                    MessageBox.Show("UploadRecords Sucess!");

                }
                catch (Exception)
                {
                    MessageBox.Show("UploadRecords Failed,Please contact OETeam!");
                    throw;
                }
                    

                
            }
            else
            {
                MessageBox.Show("Please Select DataBases");
            }
            
        }

        /// <summary>
        /// 更新emps表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void UploadEmpsButton_Click(object sender, EventArgs e)
        //{
        //    if (this.UsingDBText.Text.Length > 0 && this.SumDBText.Text.Length > 0)
        //    {
        //        try
        //        {
        //            tsfDataCon.TransferEmpDataBases(this.SumDBText.Text, this.UsingDBText.Text);
        //            MessageBox.Show("UploadEmps Sucess!");
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("UploadEmps Failed,Please contact OETeam!");
        //            throw;
        //        }
               
                    
               
                    
                
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Select DataBases");
        //    }
        //}

        /// <summary>
        /// 更新senderlist表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void UploadSenderListButton_Click(object sender, EventArgs e)
        //{
        //    if (this.UsingDBText.Text.Length > 0 && this.SumDBText.Text.Length > 0)
        //    {

        //        try
        //        {
        //                    tsfDataCon.TransferSenderListDataBases(this.SumDBText.Text, this.UsingDBText.Text);
        //            MessageBox.Show("UploadSenderList Sucess!");
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("UploadSenderList Failed,Please contact OETeam!");
        //            throw;
        //        }
                  
               
                   
               
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Select DataBases");
        //    }
        //}

        /// <summary>
        /// 主窗口加载时的设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //添加DBName下拉选择框
            InitDBNamecomboBox();
        }

        /// <summary>
        /// 初始化DBNamecomboBox
        /// </summary>
        private void InitDBNamecomboBox()
        {
            //this.DBNamecomboBox.Items.Add("NCN_BILLING");
            this.DBNamecomboBox.Items.Add("NCN_CON");
            this.DBNamecomboBox.Items.Add("NCN_SEC");
            this.DBNamecomboBox.Items.Add("NCN_SELF_ENRICHMENT");
            this.DBNamecomboBox.Items.Add("NCN_SHI");
            //this.DBNamecomboBox.Items.Add("SCN_CON");
            this.DBNamecomboBox.Items.Add("SCN_SEC");

        }

        /// <summary>
        /// DBNamecomboBox选择框变化时,更改UsingDBText和SumDBText的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbName = DBNamecomboBox.SelectedItem.ToString();
            switch (dbName)
            {
                case "NCN_BILLING":
                    UsingDBText.Text = "NCN_BILLING.accdb";
                    
                    break;
                case "NCN_CON":
                    UsingDBText.Text = "NCN_CONdb.accdb";
                   
                    break;
                case "NCN_SEC":
                    UsingDBText.Text = "NCN_SECdb.accdb";
                    
                    break;
                case "NCN_SELF_ENRICHMENT":
                    UsingDBText.Text = "NCN_SELF_Enrichment.accdb";
                    
                    break;
                case "NCN_SHI":
                    UsingDBText.Text = "NCN_SHIdb.accdb";
                    
                    break;
                case "SCN_CON":
                    UsingDBText.Text = "SCN_CONdb.accdb";
                    
                    break;
                case "SCN_SEC":
                    UsingDBText.Text = "SCN_SECdb.accdb";
                    
                    break;
            }


        }

        

        /// <summary>
        /// 选择MilestoneDb的Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectMilestoneDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "请选择要打开的MilestoneDb";
            opd.Multiselect = false;
            opd.InitialDirectory = @"C:\";
            opd.Filter = "所有的文件|*.*";
            opd.ShowDialog();

            string myPath = opd.FileName;

            if (myPath == "")
            {
                return;
            }

            TxtMilestoneDb.Text = myPath;
        }

        //导出Report
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (!File.Exists(TxtMilestoneDb.Text))
            {
                MessageBox.Show("请选择MailStoneDB");
                return;
            }

            DateTime startDate = Convert.ToDateTime(dateTimePickerStartDate.Text);
            DateTime stopDate = Convert.ToDateTime(dateTimePickerStopDate.Text);
            if (DateTime.Compare(startDate, stopDate) > 0)
            {
                MessageBox.Show("StartDate应小于StopDate");
                return;
            }
            try
            {
                tsfDataCon.GetReport(this.SumDBText.Text,startDate, stopDate, TxtMilestoneDb.Text);
                MessageBox.Show("导出完成了");
            }
            catch (Exception)
            {
                MessageBox.Show("Genarate Report Failed,Please contact OETeam!");
                throw;
            }
            
        }

        private void btnShowdataBase_Click(object sender, EventArgs e)
        {
            Form formDataBase = new frmDataBase();
            formDataBase.Tag = SumDBText.Text;
            formDataBase.ShowDialog();

        }
    }
}
