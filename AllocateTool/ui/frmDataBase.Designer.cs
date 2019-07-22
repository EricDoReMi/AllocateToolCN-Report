namespace AllocateTool.ui
{
    partial class frmDataBase
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
            this.dateTimePickerStopDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsnLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailIncomeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "startDateTime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "endDateTime";
            // 
            // dateTimePickerStopDate
            // 
            this.dateTimePickerStopDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerStopDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStopDate.Location = new System.Drawing.Point(416, 12);
            this.dateTimePickerStopDate.Name = "dateTimePickerStopDate";
            this.dateTimePickerStopDate.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStopDate.TabIndex = 18;
            this.dateTimePickerStopDate.Value = new System.DateTime(2019, 7, 31, 0, 0, 0, 0);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(146, 15);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStartDate.TabIndex = 17;
            this.dateTimePickerStartDate.Value = new System.DateTime(2019, 7, 1, 0, 0, 0, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(671, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(822, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvDataBase
            // 
            this.dgvDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.subject,
            this.StationCode,
            this.AsnLink,
            this.Branch,
            this.DBName,
            this.MailIncomeDate});
            this.dgvDataBase.Location = new System.Drawing.Point(31, 42);
            this.dgvDataBase.Name = "dgvDataBase";
            this.dgvDataBase.RowTemplate.Height = 23;
            this.dgvDataBase.Size = new System.Drawing.Size(866, 619);
            this.dgvDataBase.TabIndex = 21;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "M_id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // subject
            // 
            this.subject.DataPropertyName = "M_subject";
            this.subject.HeaderText = "subject";
            this.subject.Name = "subject";
            this.subject.ReadOnly = true;
            // 
            // StationCode
            // 
            this.StationCode.DataPropertyName = "M_requestID";
            this.StationCode.HeaderText = "StationCode";
            this.StationCode.Name = "StationCode";
            this.StationCode.ReadOnly = true;
            // 
            // AsnLink
            // 
            this.AsnLink.DataPropertyName = "M_importance";
            this.AsnLink.HeaderText = "AsnLink";
            this.AsnLink.Name = "AsnLink";
            this.AsnLink.ReadOnly = true;
            // 
            // Branch
            // 
            this.Branch.DataPropertyName = "M_Branch";
            this.Branch.HeaderText = "Branch";
            this.Branch.Name = "Branch";
            this.Branch.ReadOnly = true;
            // 
            // DBName
            // 
            this.DBName.DataPropertyName = "M_dbName";
            this.DBName.HeaderText = "DBName";
            this.DBName.Name = "DBName";
            this.DBName.ReadOnly = true;
            // 
            // MailIncomeDate
            // 
            this.MailIncomeDate.DataPropertyName = "M_mailincometime";
            this.MailIncomeDate.HeaderText = "MailIncomeDate";
            this.MailIncomeDate.Name = "MailIncomeDate";
            this.MailIncomeDate.ReadOnly = true;
            // 
            // frmDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 702);
            this.Controls.Add(this.dgvDataBase);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePickerStopDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDataBase";
            this.Text = "AllocateTool-CNReport-查看Report";
            this.Load += new System.EventHandler(this.frmDataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStopDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsnLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailIncomeDate;
    }
}