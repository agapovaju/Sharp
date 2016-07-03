namespace ContractsBase
{
    partial class PaymentDetails
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
            this.txtBxDatePay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxDateAdd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkBxInsDocs = new System.Windows.Forms.CheckBox();
            this.txtBxSName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ поручения";
            // 
            // txtBxPayNo
            // 
            this.txtBxPayNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxPayNo.Location = new System.Drawing.Point(111, 12);
            this.txtBxPayNo.Name = "txtBxPayNo";
            this.txtBxPayNo.ReadOnly = true;
            this.txtBxPayNo.Size = new System.Drawing.Size(121, 20);
            this.txtBxPayNo.TabIndex = 1;
            // 
            // txtBxDatePay
            // 
            this.txtBxDatePay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxDatePay.Location = new System.Drawing.Point(111, 38);
            this.txtBxDatePay.Name = "txtBxDatePay";
            this.txtBxDatePay.ReadOnly = true;
            this.txtBxDatePay.Size = new System.Drawing.Size(121, 20);
            this.txtBxDatePay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата оплаты";
            // 
            // txtBxInvoice
            // 
            this.txtBxInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxInvoice.Location = new System.Drawing.Point(111, 90);
            this.txtBxInvoice.Name = "txtBxInvoice";
            this.txtBxInvoice.ReadOnly = true;
            this.txtBxInvoice.Size = new System.Drawing.Size(121, 20);
            this.txtBxInvoice.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Оплата по счету";
            // 
            // txtBxDateAdd
            // 
            this.txtBxDateAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxDateAdd.Location = new System.Drawing.Point(111, 64);
            this.txtBxDateAdd.Name = "txtBxDateAdd";
            this.txtBxDateAdd.ReadOnly = true;
            this.txtBxDateAdd.Size = new System.Drawing.Size(121, 20);
            this.txtBxDateAdd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата внесения";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(157, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkBxInsDocs
            // 
            this.chkBxInsDocs.AutoCheck = false;
            this.chkBxInsDocs.AutoSize = true;
            this.chkBxInsDocs.Location = new System.Drawing.Point(16, 142);
            this.chkBxInsDocs.Name = "chkBxInsDocs";
            this.chkBxInsDocs.Size = new System.Drawing.Size(193, 17);
            this.chkBxInsDocs.TabIndex = 41;
            this.chkBxInsDocs.Text = "Документ внесен на Госзакупки";
            this.chkBxInsDocs.UseVisualStyleBackColor = true;
            this.chkBxInsDocs.CheckedChanged += new System.EventHandler(this.chkBxInsDocs_CheckedChanged);
            // 
            // txtBxSName
            // 
            this.txtBxSName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxSName.Location = new System.Drawing.Point(111, 116);
            this.txtBxSName.Name = "txtBxSName";
            this.txtBxSName.ReadOnly = true;
            this.txtBxSName.Size = new System.Drawing.Size(121, 20);
            this.txtBxSName.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Ответственный";
            // 
            // PaymentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 212);
            this.Controls.Add(this.txtBxSName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkBxInsDocs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBxDateAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBxDatePay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxPayNo);
            this.Controls.Add(this.label1);
            this.Name = "PaymentDetails";
            this.Text = "Платежное поручение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxPayNo;
        private System.Windows.Forms.TextBox txtBxDatePay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxDateAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkBxInsDocs;
        private System.Windows.Forms.TextBox txtBxSName;
        private System.Windows.Forms.Label label5;
    }
}