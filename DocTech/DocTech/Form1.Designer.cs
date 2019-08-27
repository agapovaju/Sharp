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
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детальToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.устройстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.заменитьВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFiles.SuspendLayout();
            this.contextMenuStripDetails.SuspendLayout();
            this.contextMenuStripDevices.SuspendLayout();
            this.contextMenuStripSystems.SuspendLayout();
            this.contextMenuStripFile.SuspendLayout();
            this.contextMenuStripDetail.SuspendLayout();
            this.contextMenuStripDevice.SuspendLayout();
            this.contextMenuStripSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewElements
            // 
            this.treeViewElements.Location = new System.Drawing.Point(12, 12);
            this.treeViewElements.Name = "treeViewElements";
            this.treeViewElements.Size = new System.Drawing.Size(345, 485);
            this.treeViewElements.TabIndex = 0;
            this.treeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewElements_AfterSelect);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(429, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(345, 485);
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
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заменитьВToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.Size = new System.Drawing.Size(146, 26);
            // 
            // contextMenuStripDetail
            // 
            this.contextMenuStripDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem2});
            this.contextMenuStripDetail.Name = "contextMenuStripDetail";
            this.contextMenuStripDetail.Size = new System.Drawing.Size(136, 26);
            // 
            // contextMenuStripDevice
            // 
            this.contextMenuStripDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem});
            this.contextMenuStripDevice.Name = "contextMenuStripDevice";
            this.contextMenuStripDevice.Size = new System.Drawing.Size(136, 26);
            // 
            // contextMenuStripSystem
            // 
            this.contextMenuStripSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem1});
            this.contextMenuStripSystem.Name = "contextMenuStripSystem";
            this.contextMenuStripSystem.Size = new System.Drawing.Size(136, 26);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem,
            this.детальToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить...";
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.документыToolStripMenuItem.Text = "Документы";
            this.документыToolStripMenuItem.Click += new System.EventHandler(this.документыToolStripMenuItem_Click);
            // 
            // детальToolStripMenuItem
            // 
            this.детальToolStripMenuItem.Name = "детальToolStripMenuItem";
            this.детальToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.детальToolStripMenuItem.Text = "Детали";
            this.детальToolStripMenuItem.Click += new System.EventHandler(this.детальToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem1
            // 
            this.добавитьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem1,
            this.устройстваToolStripMenuItem});
            this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            this.добавитьToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.добавитьToolStripMenuItem1.Text = "Добавить...";
            // 
            // документыToolStripMenuItem1
            // 
            this.документыToolStripMenuItem1.Name = "документыToolStripMenuItem1";
            this.документыToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.документыToolStripMenuItem1.Text = "Документы";
            // 
            // устройстваToolStripMenuItem
            // 
            this.устройстваToolStripMenuItem.Name = "устройстваToolStripMenuItem";
            this.устройстваToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.устройстваToolStripMenuItem.Text = "Устройства";
            // 
            // добавитьToolStripMenuItem2
            // 
            this.добавитьToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem2});
            this.добавитьToolStripMenuItem2.Name = "добавитьToolStripMenuItem2";
            this.добавитьToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.добавитьToolStripMenuItem2.Text = "Добавить...";
            // 
            // документыToolStripMenuItem2
            // 
            this.документыToolStripMenuItem2.Name = "документыToolStripMenuItem2";
            this.документыToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.документыToolStripMenuItem2.Text = "Документы";
            this.документыToolStripMenuItem2.Click += new System.EventHandler(this.документыToolStripMenuItem2_Click);
            // 
            // заменитьВToolStripMenuItem
            // 
            this.заменитьВToolStripMenuItem.Name = "заменитьВToolStripMenuItem";
            this.заменитьВToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.заменитьВToolStripMenuItem.Text = "Заменить в...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 515);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeViewElements);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripFiles.ResumeLayout(false);
            this.contextMenuStripDetails.ResumeLayout(false);
            this.contextMenuStripDevices.ResumeLayout(false);
            this.contextMenuStripSystems.ResumeLayout(false);
            this.contextMenuStripFile.ResumeLayout(false);
            this.contextMenuStripDetail.ResumeLayout(false);
            this.contextMenuStripDevice.ResumeLayout(false);
            this.contextMenuStripSystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewElements;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFiles;
        private System.Windows.Forms.ToolStripMenuItem добавитьДокументToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem детальToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem устройстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заменитьВToolStripMenuItem;
    }
}

