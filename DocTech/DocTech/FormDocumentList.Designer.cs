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
            this.listBoxCheckedFiles = new System.Windows.Forms.ListBox();
            this.checkedListBoxDocuments = new System.Windows.Forms.CheckedListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxCheckedFiles
            // 
            this.listBoxCheckedFiles.FormattingEnabled = true;
            this.listBoxCheckedFiles.Location = new System.Drawing.Point(470, 10);
            this.listBoxCheckedFiles.Name = "listBoxCheckedFiles";
            this.listBoxCheckedFiles.Size = new System.Drawing.Size(440, 589);
            this.listBoxCheckedFiles.TabIndex = 1;
            // 
            // checkedListBoxDocuments
            // 
            this.checkedListBoxDocuments.CheckOnClick = true;
            this.checkedListBoxDocuments.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBoxDocuments.FormattingEnabled = true;
            this.checkedListBoxDocuments.Location = new System.Drawing.Point(15, 10);
            this.checkedListBoxDocuments.Name = "checkedListBoxDocuments";
            this.checkedListBoxDocuments.Size = new System.Drawing.Size(440, 589);
            this.checkedListBoxDocuments.TabIndex = 2;
            this.checkedListBoxDocuments.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDocuments_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(920, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // FormDocumentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 611);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.checkedListBoxDocuments);
            this.Controls.Add(this.listBoxCheckedFiles);
            this.Name = "FormDocumentList";
            this.Text = "FormDocumentList";
            this.Load += new System.EventHandler(this.FormDocumentList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCheckedFiles;
        private System.Windows.Forms.CheckedListBox checkedListBoxDocuments;
        private System.Windows.Forms.Button buttonAdd;
    }
}