namespace ContractsBase
{
    partial class NewPayment
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
            this.txtBxPayNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDatePay = new System.Windows.Forms.DateTimePicker();
            this.txtBxInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtBxSName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkBxInsDocs = new System.Windows.Forms.CheckBox();
            this.txtBxDateAdd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxFilePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ поручения";
            // 
            // txtBxPayNo
            // 
            this.txtBxPayNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxPayNo.Location = new System.Drawing.Point(120, 12);
            this.txtBxPayNo.Name = "txtBxPayNo";
            this.txtBxPayNo.Size = new System.Drawing.Size(121, 20);
            this.txtBxPayNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата оплаты";
            // 
            // dtpDatePay
            // 
            this.dtpDatePay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDatePay.Location = new System.Drawing.Point(120, 40);
            this.dtpDatePay.Name = "dtpDatePay";
            this.dtpDatePay.Size = new System.Drawing.Size(121, 20);
            this.dtpDatePay.TabIndex = 3;
            // 
            // txtBxInvoice
            // 
            this.txtBxInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxInvoice.Location = new System.Drawing.Point(120, 66);
            this.txtBxInvoice.Name = "txtBxInvoice";
            this.txtBxInvoice.Size = new System.Drawing.Size(121, 20);
            this.txtBxInvoice.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Оплата по счету";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(166, 210);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Добавить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBxSName
            // 
            this.txtBxSName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxSName.Location = new System.Drawing.Point(120, 118);
            this.txtBxSName.Name = "txtBxSName";
            this.txtBxSName.ReadOnly = true;
            this.txtBxSName.Size = new System.Drawing.Size(121, 20);
            this.txtBxSName.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Ответственный";
            // 
            // chkBxInsDocs
            // 
            this.chkBxInsDocs.AutoSize = true;
            this.chkBxInsDocs.Location = new System.Drawing.Point(25, 172);
            this.chkBxInsDocs.Name = "chkBxInsDocs";
            this.chkBxInsDocs.Size = new System.Drawing.Size(193, 17);
            this.chkBxInsDocs.TabIndex = 46;
            this.chkBxInsDocs.Text = "Документ внесен на Госзакупки";
            this.chkBxInsDocs.UseVisualStyleBackColor = true;
            // 
            // txtBxDateAdd
            // 
            this.txtBxDateAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxDateAdd.Location = new System.Drawing.Point(120, 92);
            this.txtBxDateAdd.Name = "txtBxDateAdd";
            this.txtBxDateAdd.ReadOnly = true;
            this.txtBxDateAdd.Size = new System.Drawing.Size(121, 20);
            this.txtBxDateAdd.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Дата внесения";
            // 
            // txtBxFilePath
            // 
            this.txtBxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxFilePath.Location = new System.Drawing.Point(120, 144);
            this.txtBxFilePath.Name = "txtBxFilePath";
            this.txtBxFilePath.Size = new System.Drawing.Size(109, 20);
            this.txtBxFilePath.TabIndex = 50;
            this.txtBxFilePath.TextChanged += new System.EventHandler(this.txtBxFilePath_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Скан. образ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(217, 144);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(24, 23);
            this.btnOpenFile.TabIndex = 51;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // NewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 246);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtBxFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxSName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkBxInsDocs);
            this.Controls.Add(this.txtBxDateAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtBxInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDatePay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxPayNo);
            this.Controls.Add(this.label1);
            this.Name = "NewPayment";
            this.Text = "Новое платежное поручение";
            this.Load += new System.EventHandler(this.NewPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxPayNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDatePay;
        private System.Windows.Forms.TextBox txtBxInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtBxSName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkBxInsDocs;
        private System.Windows.Forms.TextBox txtBxDateAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBxFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}