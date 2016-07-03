namespace ContractsBase
{
    partial class Contractors
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvContractors = new System.Windows.Forms.DataGridView();
            this.btnNewContractor = new System.Windows.Forms.Button();
            this.btnAddToCont = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxFindName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContractors
            // 
            this.dgvContractors.AllowUserToAddRows = false;
            this.dgvContractors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContractors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContractors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvContractors.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvContractors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContractors.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContractors.Location = new System.Drawing.Point(12, 108);
            this.dgvContractors.Name = "dgvContractors";
            this.dgvContractors.ReadOnly = true;
            this.dgvContractors.Size = new System.Drawing.Size(457, 377);
            this.dgvContractors.TabIndex = 0;
            this.dgvContractors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContractors_CellClick);
            this.dgvContractors.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContractors_CellMouseDoubleClick);
            // 
            // btnNewContractor
            // 
            this.btnNewContractor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewContractor.Location = new System.Drawing.Point(15, 12);
            this.btnNewContractor.Name = "btnNewContractor";
            this.btnNewContractor.Size = new System.Drawing.Size(86, 38);
            this.btnNewContractor.TabIndex = 1;
            this.btnNewContractor.Text = "Новый контрагент";
            this.btnNewContractor.UseVisualStyleBackColor = true;
            this.btnNewContractor.Click += new System.EventHandler(this.btnNewContractor_Click);
            // 
            // btnAddToCont
            // 
            this.btnAddToCont.Location = new System.Drawing.Point(383, 12);
            this.btnAddToCont.Name = "btnAddToCont";
            this.btnAddToCont.Size = new System.Drawing.Size(86, 38);
            this.btnAddToCont.TabIndex = 2;
            this.btnAddToCont.Text = "Выбрать контрагентов";
            this.btnAddToCont.UseVisualStyleBackColor = true;
            this.btnAddToCont.Click += new System.EventHandler(this.btnAddToCont_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Организация/ФИО";
            // 
            // txtBxFindName
            // 
            this.txtBxFindName.Location = new System.Drawing.Point(124, 72);
            this.txtBxFindName.Name = "txtBxFindName";
            this.txtBxFindName.Size = new System.Drawing.Size(345, 20);
            this.txtBxFindName.TabIndex = 4;
            this.txtBxFindName.TextChanged += new System.EventHandler(this.txtBxFindName_TextChanged);
            // 
            // Contractors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 497);
            this.Controls.Add(this.txtBxFindName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddToCont);
            this.Controls.Add(this.btnNewContractor);
            this.Controls.Add(this.dgvContractors);
            this.Name = "Contractors";
            this.Text = "Контрагенты";
            this.Load += new System.EventHandler(this.Contractors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContractors;
        private System.Windows.Forms.Button btnNewContractor;
        private System.Windows.Forms.Button btnAddToCont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxFindName;
    }
}