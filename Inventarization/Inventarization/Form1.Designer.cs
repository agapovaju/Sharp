namespace Inventarization
{
    partial class inventarization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inventarization));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView_services = new System.Windows.Forms.DataGridView();
            this.label_sp_val = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_os_val = new System.Windows.Forms.Label();
            this.label_gpu = new System.Windows.Forms.Label();
            this.label_gpu_val = new System.Windows.Forms.Label();
            this.label_os = new System.Windows.Forms.Label();
            this.label_cpu_val = new System.Windows.Forms.Label();
            this.label_ram_val = new System.Windows.Forms.Label();
            this.label_ram = new System.Windows.Forms.Label();
            this.label_cpu = new System.Windows.Forms.Label();
            this.label_status_val = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.listbox_comp_list = new System.Windows.Forms.ListBox();
            this.label_comp_list = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_report = new System.Windows.Forms.Button();
            this.dataGridView_comps_information = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текущийКомпьютерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеКомпьютерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетОбОшибкахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.какПользоватьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.label_curr_comp = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.listbox_offline_comps = new System.Windows.Forms.ListBox();
            this.label_offline_comps = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_services)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comps_information)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1396, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.dataGridView_services);
            this.tabPage1.Controls.Add(this.label_sp_val);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label_os_val);
            this.tabPage1.Controls.Add(this.label_gpu);
            this.tabPage1.Controls.Add(this.label_gpu_val);
            this.tabPage1.Controls.Add(this.label_os);
            this.tabPage1.Controls.Add(this.label_cpu_val);
            this.tabPage1.Controls.Add(this.label_ram_val);
            this.tabPage1.Controls.Add(this.label_ram);
            this.tabPage1.Controls.Add(this.label_cpu);
            this.tabPage1.Controls.Add(this.label_status_val);
            this.tabPage1.Controls.Add(this.label_status);
            this.tabPage1.Controls.Add(this.listbox_comp_list);
            this.tabPage1.Controls.Add(this.label_comp_list);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1388, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(249, 192);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 270);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView_services
            // 
            this.dataGridView_services.AllowUserToAddRows = false;
            this.dataGridView_services.AllowUserToDeleteRows = false;
            this.dataGridView_services.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_services.Location = new System.Drawing.Point(580, 24);
            this.dataGridView_services.Name = "dataGridView_services";
            this.dataGridView_services.ReadOnly = true;
            this.dataGridView_services.Size = new System.Drawing.Size(782, 524);
            this.dataGridView_services.TabIndex = 6;
            // 
            // label_sp_val
            // 
            this.label_sp_val.AutoSize = true;
            this.label_sp_val.Location = new System.Drawing.Point(253, 88);
            this.label_sp_val.Name = "label_sp_val";
            this.label_sp_val.Size = new System.Drawing.Size(0, 13);
            this.label_sp_val.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "SP:";
            // 
            // label_os_val
            // 
            this.label_os_val.AutoSize = true;
            this.label_os_val.Location = new System.Drawing.Point(253, 72);
            this.label_os_val.Name = "label_os_val";
            this.label_os_val.Size = new System.Drawing.Size(0, 13);
            this.label_os_val.TabIndex = 5;
            // 
            // label_gpu
            // 
            this.label_gpu.AutoSize = true;
            this.label_gpu.Location = new System.Drawing.Point(210, 56);
            this.label_gpu.Name = "label_gpu";
            this.label_gpu.Size = new System.Drawing.Size(33, 13);
            this.label_gpu.TabIndex = 5;
            this.label_gpu.Text = "GPU:";
            // 
            // label_gpu_val
            // 
            this.label_gpu_val.AutoSize = true;
            this.label_gpu_val.Location = new System.Drawing.Point(253, 56);
            this.label_gpu_val.Name = "label_gpu_val";
            this.label_gpu_val.Size = new System.Drawing.Size(0, 13);
            this.label_gpu_val.TabIndex = 5;
            // 
            // label_os
            // 
            this.label_os.AutoSize = true;
            this.label_os.Location = new System.Drawing.Point(210, 72);
            this.label_os.Name = "label_os";
            this.label_os.Size = new System.Drawing.Size(25, 13);
            this.label_os.TabIndex = 5;
            this.label_os.Text = "OS:";
            // 
            // label_cpu_val
            // 
            this.label_cpu_val.AutoSize = true;
            this.label_cpu_val.Location = new System.Drawing.Point(253, 24);
            this.label_cpu_val.Name = "label_cpu_val";
            this.label_cpu_val.Size = new System.Drawing.Size(0, 13);
            this.label_cpu_val.TabIndex = 4;
            // 
            // label_ram_val
            // 
            this.label_ram_val.AutoSize = true;
            this.label_ram_val.Location = new System.Drawing.Point(253, 40);
            this.label_ram_val.Name = "label_ram_val";
            this.label_ram_val.Size = new System.Drawing.Size(0, 13);
            this.label_ram_val.TabIndex = 5;
            // 
            // label_ram
            // 
            this.label_ram.AutoSize = true;
            this.label_ram.Location = new System.Drawing.Point(210, 40);
            this.label_ram.Name = "label_ram";
            this.label_ram.Size = new System.Drawing.Size(34, 13);
            this.label_ram.TabIndex = 5;
            this.label_ram.Text = "RAM:";
            // 
            // label_cpu
            // 
            this.label_cpu.AutoSize = true;
            this.label_cpu.Location = new System.Drawing.Point(210, 24);
            this.label_cpu.Name = "label_cpu";
            this.label_cpu.Size = new System.Drawing.Size(32, 13);
            this.label_cpu.TabIndex = 4;
            this.label_cpu.Text = "CPU:";
            // 
            // label_status_val
            // 
            this.label_status_val.AutoSize = true;
            this.label_status_val.Location = new System.Drawing.Point(253, 3);
            this.label_status_val.Name = "label_status_val";
            this.label_status_val.Size = new System.Drawing.Size(0, 13);
            this.label_status_val.TabIndex = 3;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(203, 3);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(44, 13);
            this.label_status.TabIndex = 2;
            this.label_status.Text = "Статус:";
            // 
            // listbox_comp_list
            // 
            this.listbox_comp_list.FormattingEnabled = true;
            this.listbox_comp_list.Location = new System.Drawing.Point(4, 24);
            this.listbox_comp_list.Name = "listbox_comp_list";
            this.listbox_comp_list.Size = new System.Drawing.Size(200, 524);
            this.listbox_comp_list.TabIndex = 1;
            this.listbox_comp_list.SelectedIndexChanged += new System.EventHandler(this.listbox_comp_list_SelectedIndexChanged_1);
            // 
            // label_comp_list
            // 
            this.label_comp_list.AutoSize = true;
            this.label_comp_list.Location = new System.Drawing.Point(6, 3);
            this.label_comp_list.Name = "label_comp_list";
            this.label_comp_list.Size = new System.Drawing.Size(116, 13);
            this.label_comp_list.TabIndex = 0;
            this.label_comp_list.Text = "Список компьютеров";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label_offline_comps);
            this.tabPage2.Controls.Add(this.listbox_offline_comps);
            this.tabPage2.Controls.Add(this.button_report);
            this.tabPage2.Controls.Add(this.dataGridView_comps_information);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1388, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "All comps information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_report
            // 
            this.button_report.Location = new System.Drawing.Point(7, 7);
            this.button_report.Name = "button_report";
            this.button_report.Size = new System.Drawing.Size(130, 23);
            this.button_report.TabIndex = 1;
            this.button_report.Text = "Сформировать отчет";
            this.button_report.UseVisualStyleBackColor = true;
            this.button_report.Click += new System.EventHandler(this.button_report_Click);
            // 
            // dataGridView_comps_information
            // 
            this.dataGridView_comps_information.AllowUserToAddRows = false;
            this.dataGridView_comps_information.AllowUserToDeleteRows = false;
            this.dataGridView_comps_information.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_comps_information.Location = new System.Drawing.Point(0, 36);
            this.dataGridView_comps_information.Name = "dataGridView_comps_information";
            this.dataGridView_comps_information.ReadOnly = true;
            this.dataGridView_comps_information.Size = new System.Drawing.Size(1143, 525);
            this.dataGridView_comps_information.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1414, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.отчетОбОшибкахToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текущийКомпьютерToolStripMenuItem,
            this.всеКомпьютерыToolStripMenuItem});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // текущийКомпьютерToolStripMenuItem
            // 
            this.текущийКомпьютерToolStripMenuItem.Name = "текущийКомпьютерToolStripMenuItem";
            this.текущийКомпьютерToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.текущийКомпьютерToolStripMenuItem.Text = "Текущий компьютер";
            this.текущийКомпьютерToolStripMenuItem.Click += new System.EventHandler(this.текущийКомпьютерToolStripMenuItem_Click);
            // 
            // всеКомпьютерыToolStripMenuItem
            // 
            this.всеКомпьютерыToolStripMenuItem.Name = "всеКомпьютерыToolStripMenuItem";
            this.всеКомпьютерыToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.всеКомпьютерыToolStripMenuItem.Text = "Все компьютеры";
            this.всеКомпьютерыToolStripMenuItem.Click += new System.EventHandler(this.всеКомпьютерыToolStripMenuItem_Click);
            // 
            // отчетОбОшибкахToolStripMenuItem
            // 
            this.отчетОбОшибкахToolStripMenuItem.Name = "отчетОбОшибкахToolStripMenuItem";
            this.отчетОбОшибкахToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.отчетОбОшибкахToolStripMenuItem.Text = "Отчет об ошибках";
            this.отчетОбОшибкахToolStripMenuItem.Click += new System.EventHandler(this.отчетОбОшибкахToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.какПользоватьсяToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // какПользоватьсяToolStripMenuItem
            // 
            this.какПользоватьсяToolStripMenuItem.Name = "какПользоватьсяToolStripMenuItem";
            this.какПользоватьсяToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.какПользоватьсяToolStripMenuItem.Text = "Как пользоваться";
            this.какПользоватьсяToolStripMenuItem.Click += new System.EventHandler(this.какПользоватьсяToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(12, 624);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(1206, 23);
            this.progress_bar.TabIndex = 2;
            // 
            // label_curr_comp
            // 
            this.label_curr_comp.AutoSize = true;
            this.label_curr_comp.Location = new System.Drawing.Point(1224, 628);
            this.label_curr_comp.Name = "label_curr_comp";
            this.label_curr_comp.Size = new System.Drawing.Size(0, 13);
            this.label_curr_comp.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listbox_offline_comps
            // 
            this.listbox_offline_comps.FormattingEnabled = true;
            this.listbox_offline_comps.Location = new System.Drawing.Point(1152, 36);
            this.listbox_offline_comps.Name = "listbox_offline_comps";
            this.listbox_offline_comps.Size = new System.Drawing.Size(232, 524);
            this.listbox_offline_comps.TabIndex = 2;
            // 
            // label_offline_comps
            // 
            this.label_offline_comps.AutoSize = true;
            this.label_offline_comps.Location = new System.Drawing.Point(1152, 16);
            this.label_offline_comps.Name = "label_offline_comps";
            this.label_offline_comps.Size = new System.Drawing.Size(140, 13);
            this.label_offline_comps.TabIndex = 3;
            this.label_offline_comps.Text = "Компьютеры в офф-лайне";
            // 
            // inventarization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 662);
            this.Controls.Add(this.label_curr_comp);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "inventarization";
            this.Text = "Инвентаризация";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_services)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comps_information)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listbox_comp_list;
        private System.Windows.Forms.Label label_comp_list;
        private System.Windows.Forms.Label label_status_val;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текущийКомпьютерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеКомпьютерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_services;
        private System.Windows.Forms.Label label_sp_val;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_os_val;
        private System.Windows.Forms.Label label_gpu;
        private System.Windows.Forms.Label label_gpu_val;
        private System.Windows.Forms.Label label_os;
        private System.Windows.Forms.Label label_cpu_val;
        private System.Windows.Forms.Label label_ram_val;
        private System.Windows.Forms.Label label_ram;
        private System.Windows.Forms.Label label_cpu;
        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Label label_curr_comp;
        private System.Windows.Forms.Button button_report;
        private System.Windows.Forms.DataGridView dataGridView_comps_information;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem отчетОбОшибкахToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem какПользоватьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listbox_offline_comps;
        private System.Windows.Forms.Label label_offline_comps;
    }
}

