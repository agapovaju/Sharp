namespace ContractsBase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvConts = new System.Windows.Forms.DataGridView();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBxDate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAllContractors = new System.Windows.Forms.Button();
            this.txtBxContractor = new System.Windows.Forms.TextBox();
            this.txtBxContract = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnContractors = new System.Windows.Forms.Button();
            this.groupBoxSummary = new System.Windows.Forms.GroupBox();
            this.dtpDocsEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDocsStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDocsOk = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.NewContract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConts
            // 
            this.dgvConts.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Ivory;
            this.dgvConts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvConts.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvConts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConts.Location = new System.Drawing.Point(12, 130);
            this.dgvConts.Name = "dgvConts";
            this.dgvConts.ReadOnly = true;
            this.dgvConts.Size = new System.Drawing.Size(612, 235);
            this.dgvConts.TabIndex = 0;
            this.dgvConts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConts_CellDoubleClick);
            this.dgvConts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvConts_DataBindingComplete);
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Checked = false;
            this.dtpDateStart.CustomFormat = "dd.MM.yyyy";
            this.dtpDateStart.Location = new System.Drawing.Point(34, 64);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.ShowCheckBox = true;
            this.dtpDateStart.Size = new System.Drawing.Size(117, 20);
            this.dtpDateStart.TabIndex = 3;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Checked = false;
            this.dtpDateEnd.CustomFormat = "dd.MM.yyyy";
            this.dtpDateEnd.Location = new System.Drawing.Point(182, 64);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.ShowCheckBox = true;
            this.dtpDateEnd.Size = new System.Drawing.Size(117, 20);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Дата:";
            // 
            // cmbBxDate
            // 
            this.cmbBxDate.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbBxDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBxDate.FormattingEnabled = true;
            this.cmbBxDate.Items.AddRange(new object[] {
            "по всем датам",
            "заключения",
            "окончания"});
            this.cmbBxDate.Location = new System.Drawing.Point(57, 26);
            this.cmbBxDate.Name = "cmbBxDate";
            this.cmbBxDate.Size = new System.Drawing.Size(101, 21);
            this.cmbBxDate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "с";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "по";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBxDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateEnd);
            this.groupBox1.Controls.Add(this.dtpDateStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(448, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск по датам";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAllContractors);
            this.groupBox2.Controls.Add(this.txtBxContractor);
            this.groupBox2.Controls.Add(this.txtBxContract);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 100);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фильтры";
            // 
            // btnAllContractors
            // 
            this.btnAllContractors.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAllContractors.Location = new System.Drawing.Point(336, 26);
            this.btnAllContractors.Name = "btnAllContractors";
            this.btnAllContractors.Size = new System.Drawing.Size(21, 20);
            this.btnAllContractors.TabIndex = 22;
            this.btnAllContractors.Text = "...";
            this.btnAllContractors.UseVisualStyleBackColor = true;
            this.btnAllContractors.Click += new System.EventHandler(this.btnAllContractors_Click);
            // 
            // txtBxContractor
            // 
            this.txtBxContractor.Location = new System.Drawing.Point(89, 26);
            this.txtBxContractor.Name = "txtBxContractor";
            this.txtBxContractor.Size = new System.Drawing.Size(251, 20);
            this.txtBxContractor.TabIndex = 23;
            // 
            // txtBxContract
            // 
            this.txtBxContract.Location = new System.Drawing.Point(90, 63);
            this.txtBxContract.Name = "txtBxContract";
            this.txtBxContract.Size = new System.Drawing.Size(267, 20);
            this.txtBxContract.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Контрагент:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Номер";
            // 
            // btnContractors
            // 
            this.btnContractors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContractors.Image = global::ContractsBase.Properties.Resources.contractors32;
            this.btnContractors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContractors.Location = new System.Drawing.Point(630, 173);
            this.btnContractors.Name = "btnContractors";
            this.btnContractors.Size = new System.Drawing.Size(133, 37);
            this.btnContractors.TabIndex = 15;
            this.btnContractors.Text = "Контрагенты";
            this.btnContractors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContractors.UseVisualStyleBackColor = true;
            this.btnContractors.Click += new System.EventHandler(this.btnContractors_Click);
            // 
            // groupBoxSummary
            // 
            this.groupBoxSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSummary.Controls.Add(this.dtpDocsEnd);
            this.groupBoxSummary.Controls.Add(this.label7);
            this.groupBoxSummary.Controls.Add(this.dtpDocsStart);
            this.groupBoxSummary.Controls.Add(this.label5);
            this.groupBoxSummary.Controls.Add(this.btnDocsOk);
            this.groupBoxSummary.Location = new System.Drawing.Point(636, 227);
            this.groupBoxSummary.Name = "groupBoxSummary";
            this.groupBoxSummary.Size = new System.Drawing.Size(127, 118);
            this.groupBoxSummary.TabIndex = 20;
            this.groupBoxSummary.TabStop = false;
            this.groupBoxSummary.Text = "Сводка по документам";
            // 
            // dtpDocsEnd
            // 
            this.dtpDocsEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDocsEnd.Checked = false;
            this.dtpDocsEnd.CustomFormat = "dd.MM.yyyy";
            this.dtpDocsEnd.Location = new System.Drawing.Point(22, 58);
            this.dtpDocsEnd.Name = "dtpDocsEnd";
            this.dtpDocsEnd.ShowCheckBox = true;
            this.dtpDocsEnd.Size = new System.Drawing.Size(98, 20);
            this.dtpDocsEnd.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "по";
            // 
            // dtpDocsStart
            // 
            this.dtpDocsStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDocsStart.Checked = false;
            this.dtpDocsStart.CustomFormat = "dd.MM.yyyy";
            this.dtpDocsStart.Location = new System.Drawing.Point(22, 32);
            this.dtpDocsStart.Name = "dtpDocsStart";
            this.dtpDocsStart.ShowCheckBox = true;
            this.dtpDocsStart.Size = new System.Drawing.Size(98, 20);
            this.dtpDocsStart.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "с";
            // 
            // btnDocsOk
            // 
            this.btnDocsOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocsOk.Location = new System.Drawing.Point(31, 84);
            this.btnDocsOk.Name = "btnDocsOk";
            this.btnDocsOk.Size = new System.Drawing.Size(75, 23);
            this.btnDocsOk.TabIndex = 0;
            this.btnDocsOk.Text = "Ок";
            this.btnDocsOk.UseVisualStyleBackColor = true;
            this.btnDocsOk.Click += new System.EventHandler(this.btnDocsOk_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::ContractsBase.Properties.Resources.clearfilter16;
            this.btnClear.Location = new System.Drawing.Point(392, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(35, 35);
            this.btnClear.TabIndex = 0;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::ContractsBase.Properties.Resources.search16;
            this.btnSearch.Location = new System.Drawing.Point(392, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 35);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // NewContract
            // 
            this.NewContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewContract.Image = global::ContractsBase.Properties.Resources.cont32;
            this.NewContract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewContract.Location = new System.Drawing.Point(630, 130);
            this.NewContract.Name = "NewContract";
            this.NewContract.Size = new System.Drawing.Size(133, 37);
            this.NewContract.TabIndex = 14;
            this.NewContract.Text = "Новый договор";
            this.NewContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewContract.UseVisualStyleBackColor = true;
            this.NewContract.Click += new System.EventHandler(this.NewContract_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 377);
            this.Controls.Add(this.groupBoxSummary);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnContractors);
            this.Controls.Add(this.NewContract);
            this.Controls.Add(this.dgvConts);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АСКИД";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxSummary.ResumeLayout(false);
            this.groupBoxSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConts;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBxDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button NewContract;
        private System.Windows.Forms.Button btnContractors;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAllContractors;
        private System.Windows.Forms.TextBox txtBxContractor;
        private System.Windows.Forms.TextBox txtBxContract;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBoxSummary;
        private System.Windows.Forms.DateTimePicker dtpDocsEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDocsStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDocsOk;
    }
}

