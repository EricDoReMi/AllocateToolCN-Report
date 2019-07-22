namespace AllocateTool.ui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UploadRecordsButton = new System.Windows.Forms.Button();
            this.DBNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UsingDBText = new System.Windows.Forms.TextBox();
            this.SumDBText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStopDate = new System.Windows.Forms.DateTimePicker();
            this.btnSelectMilestoneDb = new System.Windows.Forms.Button();
            this.TxtMilestoneDb = new System.Windows.Forms.TextBox();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.btnShowdataBase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "UsingDB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "SumDB";
            // 
            // UploadRecordsButton
            // 
            this.UploadRecordsButton.ForeColor = System.Drawing.Color.Red;
            this.UploadRecordsButton.Location = new System.Drawing.Point(487, 101);
            this.UploadRecordsButton.Name = "UploadRecordsButton";
            this.UploadRecordsButton.Size = new System.Drawing.Size(108, 30);
            this.UploadRecordsButton.TabIndex = 4;
            this.UploadRecordsButton.Text = "UploadRecords";
            this.UploadRecordsButton.UseVisualStyleBackColor = true;
            this.UploadRecordsButton.Click += new System.EventHandler(this.UploadRecordsButton_Click);
            // 
            // DBNamecomboBox
            // 
            this.DBNamecomboBox.FormattingEnabled = true;
            this.DBNamecomboBox.Location = new System.Drawing.Point(305, 30);
            this.DBNamecomboBox.Name = "DBNamecomboBox";
            this.DBNamecomboBox.Size = new System.Drawing.Size(163, 20);
            this.DBNamecomboBox.TabIndex = 7;
            this.DBNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.DBNamecomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "DBName";
            // 
            // UsingDBText
            // 
            this.UsingDBText.Location = new System.Drawing.Point(30, 107);
            this.UsingDBText.Name = "UsingDBText";
            this.UsingDBText.Size = new System.Drawing.Size(193, 21);
            this.UsingDBText.TabIndex = 10;
            // 
            // SumDBText
            // 
            this.SumDBText.Location = new System.Drawing.Point(254, 107);
            this.SumDBText.Name = "SumDBText";
            this.SumDBText.ReadOnly = true;
            this.SumDBText.Size = new System.Drawing.Size(193, 21);
            this.SumDBText.TabIndex = 11;
            this.SumDBText.Text = "CN-Sum.accdb";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "StopDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "StartDate";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(33, 208);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStartDate.TabIndex = 12;
            this.dateTimePickerStartDate.Value = new System.DateTime(2019, 7, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerStopDate
            // 
            this.dateTimePickerStopDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerStopDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStopDate.Location = new System.Drawing.Point(254, 208);
            this.dateTimePickerStopDate.Name = "dateTimePickerStopDate";
            this.dateTimePickerStopDate.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStopDate.TabIndex = 16;
            this.dateTimePickerStopDate.Value = new System.DateTime(2019, 7, 31, 0, 0, 0, 0);
            // 
            // btnSelectMilestoneDb
            // 
            this.btnSelectMilestoneDb.Location = new System.Drawing.Point(33, 262);
            this.btnSelectMilestoneDb.Name = "btnSelectMilestoneDb";
            this.btnSelectMilestoneDb.Size = new System.Drawing.Size(123, 23);
            this.btnSelectMilestoneDb.TabIndex = 17;
            this.btnSelectMilestoneDb.Text = "SelectMilestoneDb";
            this.btnSelectMilestoneDb.UseVisualStyleBackColor = true;
            this.btnSelectMilestoneDb.Click += new System.EventHandler(this.btnSelectMilestoneDb_Click);
            // 
            // TxtMilestoneDb
            // 
            this.TxtMilestoneDb.Location = new System.Drawing.Point(254, 264);
            this.TxtMilestoneDb.Name = "TxtMilestoneDb";
            this.TxtMilestoneDb.ReadOnly = true;
            this.TxtMilestoneDb.Size = new System.Drawing.Size(345, 21);
            this.TxtMilestoneDb.TabIndex = 18;
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(487, 347);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(108, 23);
            this.btnExportReport.TabIndex = 19;
            this.btnExportReport.Text = "ExportReport";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // btnShowdataBase
            // 
            this.btnShowdataBase.Location = new System.Drawing.Point(29, 30);
            this.btnShowdataBase.Name = "btnShowdataBase";
            this.btnShowdataBase.Size = new System.Drawing.Size(78, 20);
            this.btnShowdataBase.TabIndex = 20;
            this.btnShowdataBase.Text = "查看数据库";
            this.btnShowdataBase.UseVisualStyleBackColor = true;
            this.btnShowdataBase.Click += new System.EventHandler(this.btnShowdataBase_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 416);
            this.Controls.Add(this.btnShowdataBase);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.TxtMilestoneDb);
            this.Controls.Add(this.btnSelectMilestoneDb);
            this.Controls.Add(this.dateTimePickerStopDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.SumDBText);
            this.Controls.Add(this.UsingDBText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DBNamecomboBox);
            this.Controls.Add(this.UploadRecordsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "AllocateTool-CNReport";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UploadRecordsButton;
        private System.Windows.Forms.ComboBox DBNamecomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsingDBText;
        private System.Windows.Forms.TextBox SumDBText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStopDate;
        private System.Windows.Forms.Button btnSelectMilestoneDb;
        private System.Windows.Forms.TextBox TxtMilestoneDb;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Button btnShowdataBase;
    }
}