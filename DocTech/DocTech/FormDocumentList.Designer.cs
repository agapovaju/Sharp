namespace DocTech
{
    partial class FormDocumentList
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
            this.listBoxDocuments = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxDocuments
            // 
            this.listBoxDocuments.FormattingEnabled = true;
            this.listBoxDocuments.Location = new System.Drawing.Point(13, 13);
            this.listBoxDocuments.Name = "listBoxDocuments";
            this.listBoxDocuments.Size = new System.Drawing.Size(327, 602);
            this.listBoxDocuments.TabIndex = 0;
            // 
            // FormDocumentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 630);
            this.Controls.Add(this.listBoxDocuments);
            this.Name = "FormDocumentList";
            this.Text = "FormDocumentList";
            this.Load += new System.EventHandler(this.FormDocumentList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDocuments;
    }
}