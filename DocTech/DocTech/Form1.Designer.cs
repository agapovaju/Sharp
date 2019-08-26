namespace DocTech
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeViewElements = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStripFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butAddDocToDet = new System.Windows.Forms.Button();
            this.contextMenuStripDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьДетальToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDevices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьУстройствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripSystems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьСистемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripSystem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripFiles.SuspendLayout();
            this.contextMenuStripDetails.SuspendLayout();
            this.contextMenuStripDevices.SuspendLayout();
            this.contextMenuStripSystems.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewElements
            // 
            this.treeViewElements.Location = new System.Drawing.Point(12, 12);
            this.treeViewElements.Name = "treeViewElements";
            this.treeViewElements.Size = new System.Drawing.Size(345, 491);
            this.treeViewElements.TabIndex = 0;
            this.treeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewElements_AfterSelect);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(429, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(571, 433);
            this.listBox1.TabIndex = 1;
            // 
            // contextMenuStripFiles
            // 
            this.contextMenuStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьДокументToolStripMenuItem});
            this.contextMenuStripFiles.Name = "contextMenuStrip1";
            this.contextMenuStripFiles.Size = new System.Drawing.Size(182, 26);
            // 
            // добавитьДокументToolStripMenuItem
            // 
            this.добавитьДокументToolStripMenuItem.Name = "добавитьДокументToolStripMenuItem";
            this.добавитьДокументToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.добавитьДокументToolStripMenuItem.Text = "Добавить документ";
            this.добавитьДокументToolStripMenuItem.Click += new System.EventHandler(this.добавитьДокументToolStripMenuItem_Click);
            // 
            // butAddDocToDet
            // 
            this.butAddDocToDet.Location = new System.Drawing.Point(429, 13);
            this.butAddDocToDet.Name = "butAddDocToDet";
            this.butAddDocToDet.Size = new System.Drawing.Size(186, 23);
            this.butAddDocToDet.TabIndex = 2;
            this.butAddDocToDet.Text = "Добавить документ к детали";
            this.butAddDocToDet.UseVisualStyleBackColor = true;
            this.butAddDocToDet.Click += new System.EventHandler(this.butAddDocToDet_Click);
            // 
            // contextMenuStripDetails
            // 
            this.contextMenuStripDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьДетальToolStripMenuItem});
            this.contextMenuStripDetails.Name = "contextMenuStripDetails";
            this.contextMenuStripDetails.Size = new System.Drawing.Size(166, 26);
            // 
            // добавитьДетальToolStripMenuItem
            // 
            this.добавитьДетальToolStripMenuItem.Name = "добавитьДетальToolStripMenuItem";
            this.добавитьДетальToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.добавитьДетальToolStripMenuItem.Text = "Добавить деталь";
            this.добавитьДетальToolStripMenuItem.Click += new System.EventHandler(this.добавитьДетальToolStripMenuItem_Click);
            // 
            // contextMenuStripDevices
            // 
            this.contextMenuStripDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьУстройствоToolStripMenuItem});
            this.contextMenuStripDevices.Name = "contextMenuStripDevices";
            this.contextMenuStripDevices.Size = new System.Drawing.Size(192, 26);
            // 
            // добавитьУстройствоToolStripMenuItem
            // 
            this.добавитьУстройствоToolStripMenuItem.Name = "добавитьУстройствоToolStripMenuItem";
            this.добавитьУстройствоToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.добавитьУстройствоToolStripMenuItem.Text = "Добавить устройство";
            this.добавитьУстройствоToolStripMenuItem.Click += new System.EventHandler(this.добавитьУстройствоToolStripMenuItem_Click);
            // 
            // contextMenuStripSystems
            // 
            this.contextMenuStripSystems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСистемуToolStripMenuItem});
            this.contextMenuStripSystems.Name = "contextMenuStripSystems";
            this.contextMenuStripSystems.Size = new System.Drawing.Size(175, 26);
            // 
            // добавитьСистемуToolStripMenuItem
            // 
            this.добавитьСистемуToolStripMenuItem.Name = "добавитьСистемуToolStripMenuItem";
            this.добавитьСистемуToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.добавитьСистемуToolStripMenuItem.Text = "Добавить систему";
            this.добавитьСистемуToolStripMenuItem.Click += new System.EventHandler(this.добавитьСистемуToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripDetail
            // 
            this.contextMenuStripDetail.Name = "contextMenuStripDetail";
            this.contextMenuStripDetail.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripDevice
            // 
            this.contextMenuStripDevice.Name = "contextMenuStripDevice";
            this.contextMenuStripDevice.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripSystem
            // 
            this.contextMenuStripSystem.Name = "contextMenuStripSystem";
            this.contextMenuStripSystem.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 515);
            this.Controls.Add(this.butAddDocToDet);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeViewElements);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripFiles.ResumeLayout(false);
            this.contextMenuStripDetails.ResumeLayout(false);
            this.contextMenuStripDevices.ResumeLayout(false);
            this.contextMenuStripSystems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewElements;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFiles;
        private System.Windows.Forms.ToolStripMenuItem добавитьДокументToolStripMenuItem;
        private System.Windows.Forms.Button butAddDocToDet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDetails;
        private System.Windows.Forms.ToolStripMenuItem добавитьДетальToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDevices;
        private System.Windows.Forms.ToolStripMenuItem добавитьУстройствоToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSystems;
        private System.Windows.Forms.ToolStripMenuItem добавитьСистемуToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDetail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDevice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSystem;
    }
}

