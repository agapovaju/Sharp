﻿namespace DocTech
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
            this.заменитьВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСвязьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетДокументацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детальToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСвязьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.деталиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетДокументацииToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripSystem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.устройстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСвязьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.устройстваToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетДокументацииToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.документToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детальToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.устройствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.системуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЭлементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.деталиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.устройстваToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.системыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStripFiles.SuspendLayout();
            this.contextMenuStripDetails.SuspendLayout();
            this.contextMenuStripDevices.SuspendLayout();
            this.contextMenuStripSystems.SuspendLayout();
            this.contextMenuStripFile.SuspendLayout();
            this.contextMenuStripDetail.SuspendLayout();
            this.contextMenuStripDevice.SuspendLayout();
            this.contextMenuStripSystem.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewElements
            // 
            this.treeViewElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewElements.Location = new System.Drawing.Point(9, 47);
            this.treeViewElements.Name = "treeViewElements";
            this.treeViewElements.Size = new System.Drawing.Size(500, 465);
            this.treeViewElements.TabIndex = 0;
            this.treeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewElements_AfterSelect);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(544, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(500, 469);
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
            this.заменитьВToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.скачатьToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.Size = new System.Drawing.Size(128, 70);
            // 
            // заменитьВToolStripMenuItem
            // 
            this.заменитьВToolStripMenuItem.Name = "заменитьВToolStripMenuItem";
            this.заменитьВToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.заменитьВToolStripMenuItem.Text = "Заменить";
            this.заменитьВToolStripMenuItem.Click += new System.EventHandler(this.заменитьВToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // скачатьToolStripMenuItem
            // 
            this.скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            this.скачатьToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.скачатьToolStripMenuItem.Text = "Скачать";
            this.скачатьToolStripMenuItem.Click += new System.EventHandler(this.скачатьToolStripMenuItem_Click);
            // 
            // contextMenuStripDetail
            // 
            this.contextMenuStripDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem2,
            this.удалитьСвязьToolStripMenuItem,
            this.пакетДокументацииToolStripMenuItem});
            this.contextMenuStripDetail.Name = "contextMenuStripDetail";
            this.contextMenuStripDetail.Size = new System.Drawing.Size(189, 70);
            // 
            // добавитьToolStripMenuItem2
            // 
            this.добавитьToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem2});
            this.добавитьToolStripMenuItem2.Name = "добавитьToolStripMenuItem2";
            this.добавитьToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
            this.добавитьToolStripMenuItem2.Text = "Добавить связь...";
            // 
            // документыToolStripMenuItem2
            // 
            this.документыToolStripMenuItem2.Name = "документыToolStripMenuItem2";
            this.документыToolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem2.Text = "Документы";
            this.документыToolStripMenuItem2.Click += new System.EventHandler(this.документыToolStripMenuItem2_Click);
            // 
            // удалитьСвязьToolStripMenuItem
            // 
            this.удалитьСвязьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem4});
            this.удалитьСвязьToolStripMenuItem.Name = "удалитьСвязьToolStripMenuItem";
            this.удалитьСвязьToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.удалитьСвязьToolStripMenuItem.Text = "Удалить связь...";
            // 
            // документыToolStripMenuItem4
            // 
            this.документыToolStripMenuItem4.Name = "документыToolStripMenuItem4";
            this.документыToolStripMenuItem4.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem4.Text = "Документы";
            this.документыToolStripMenuItem4.Click += new System.EventHandler(this.документыToolStripMenuItem4_Click);
            // 
            // пакетДокументацииToolStripMenuItem
            // 
            this.пакетДокументацииToolStripMenuItem.Name = "пакетДокументацииToolStripMenuItem";
            this.пакетДокументацииToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.пакетДокументацииToolStripMenuItem.Text = "Пакет документации";
            this.пакетДокументацииToolStripMenuItem.Click += new System.EventHandler(this.пакетДокументацииToolStripMenuItem_Click);
            // 
            // contextMenuStripDevice
            // 
            this.contextMenuStripDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьСвязьToolStripMenuItem1,
            this.пакетДокументацииToolStripMenuItem1});
            this.contextMenuStripDevice.Name = "contextMenuStripDevice";
            this.contextMenuStripDevice.Size = new System.Drawing.Size(189, 70);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem,
            this.детальToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить связь...";
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem.Text = "Документы";
            this.документыToolStripMenuItem.Click += new System.EventHandler(this.документыToolStripMenuItem_Click);
            // 
            // детальToolStripMenuItem
            // 
            this.детальToolStripMenuItem.Name = "детальToolStripMenuItem";
            this.детальToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.детальToolStripMenuItem.Text = "Детали";
            this.детальToolStripMenuItem.Click += new System.EventHandler(this.детальToolStripMenuItem_Click);
            // 
            // удалитьСвязьToolStripMenuItem1
            // 
            this.удалитьСвязьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem5,
            this.деталиToolStripMenuItem1});
            this.удалитьСвязьToolStripMenuItem1.Name = "удалитьСвязьToolStripMenuItem1";
            this.удалитьСвязьToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.удалитьСвязьToolStripMenuItem1.Text = "Удалить связь...";
            // 
            // документыToolStripMenuItem5
            // 
            this.документыToolStripMenuItem5.Name = "документыToolStripMenuItem5";
            this.документыToolStripMenuItem5.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem5.Text = "Документы";
            this.документыToolStripMenuItem5.Click += new System.EventHandler(this.документыToolStripMenuItem5_Click);
            // 
            // деталиToolStripMenuItem1
            // 
            this.деталиToolStripMenuItem1.Name = "деталиToolStripMenuItem1";
            this.деталиToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.деталиToolStripMenuItem1.Text = "Детали";
            this.деталиToolStripMenuItem1.Click += new System.EventHandler(this.деталиToolStripMenuItem1_Click);
            // 
            // пакетДокументацииToolStripMenuItem1
            // 
            this.пакетДокументацииToolStripMenuItem1.Name = "пакетДокументацииToolStripMenuItem1";
            this.пакетДокументацииToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.пакетДокументацииToolStripMenuItem1.Text = "Пакет документации";
            this.пакетДокументацииToolStripMenuItem1.Click += new System.EventHandler(this.пакетДокументацииToolStripMenuItem1_Click);
            // 
            // contextMenuStripSystem
            // 
            this.contextMenuStripSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem1,
            this.удалитьСвязьToolStripMenuItem2,
            this.пакетДокументацииToolStripMenuItem2});
            this.contextMenuStripSystem.Name = "contextMenuStripSystem";
            this.contextMenuStripSystem.Size = new System.Drawing.Size(189, 70);
            // 
            // добавитьToolStripMenuItem1
            // 
            this.добавитьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem1,
            this.устройстваToolStripMenuItem});
            this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            this.добавитьToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.добавитьToolStripMenuItem1.Text = "Добавить связь...";
            // 
            // документыToolStripMenuItem1
            // 
            this.документыToolStripMenuItem1.Name = "документыToolStripMenuItem1";
            this.документыToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem1.Text = "Документы";
            this.документыToolStripMenuItem1.Click += new System.EventHandler(this.документыToolStripMenuItem1_Click);
            // 
            // устройстваToolStripMenuItem
            // 
            this.устройстваToolStripMenuItem.Name = "устройстваToolStripMenuItem";
            this.устройстваToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.устройстваToolStripMenuItem.Text = "Устройства";
            this.устройстваToolStripMenuItem.Click += new System.EventHandler(this.устройстваToolStripMenuItem_Click);
            // 
            // удалитьСвязьToolStripMenuItem2
            // 
            this.удалитьСвязьToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem6,
            this.устройстваToolStripMenuItem2});
            this.удалитьСвязьToolStripMenuItem2.Name = "удалитьСвязьToolStripMenuItem2";
            this.удалитьСвязьToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
            this.удалитьСвязьToolStripMenuItem2.Text = "Удалить связь...";
            // 
            // документыToolStripMenuItem6
            // 
            this.документыToolStripMenuItem6.Name = "документыToolStripMenuItem6";
            this.документыToolStripMenuItem6.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem6.Text = "Документы";
            this.документыToolStripMenuItem6.Click += new System.EventHandler(this.документыToolStripMenuItem6_Click);
            // 
            // устройстваToolStripMenuItem2
            // 
            this.устройстваToolStripMenuItem2.Name = "устройстваToolStripMenuItem2";
            this.устройстваToolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
            this.устройстваToolStripMenuItem2.Text = "Устройства";
            this.устройстваToolStripMenuItem2.Click += new System.EventHandler(this.устройстваToolStripMenuItem2_Click);
            // 
            // пакетДокументацииToolStripMenuItem2
            // 
            this.пакетДокументацииToolStripMenuItem2.Name = "пакетДокументацииToolStripMenuItem2";
            this.пакетДокументацииToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
            this.пакетДокументацииToolStripMenuItem2.Text = "Пакет документации";
            this.пакетДокументацииToolStripMenuItem2.Click += new System.EventHandler(this.пакетДокументацииToolStripMenuItem2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сервисToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem3,
            this.удалитьЭлементыToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // добавитьToolStripMenuItem3
            // 
            this.добавитьToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документToolStripMenuItem,
            this.детальToolStripMenuItem1,
            this.устройствоToolStripMenuItem,
            this.системуToolStripMenuItem});
            this.добавитьToolStripMenuItem3.Name = "добавитьToolStripMenuItem3";
            this.добавитьToolStripMenuItem3.Size = new System.Drawing.Size(135, 22);
            this.добавитьToolStripMenuItem3.Text = "Добавить...";
            // 
            // документToolStripMenuItem
            // 
            this.документToolStripMenuItem.Name = "документToolStripMenuItem";
            this.документToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.документToolStripMenuItem.Text = "Документ";
            this.документToolStripMenuItem.Click += new System.EventHandler(this.документToolStripMenuItem_Click);
            // 
            // детальToolStripMenuItem1
            // 
            this.детальToolStripMenuItem1.Name = "детальToolStripMenuItem1";
            this.детальToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.детальToolStripMenuItem1.Text = "Деталь";
            this.детальToolStripMenuItem1.Click += new System.EventHandler(this.детальToolStripMenuItem1_Click);
            // 
            // устройствоToolStripMenuItem
            // 
            this.устройствоToolStripMenuItem.Name = "устройствоToolStripMenuItem";
            this.устройствоToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.устройствоToolStripMenuItem.Text = "Устройство";
            this.устройствоToolStripMenuItem.Click += new System.EventHandler(this.устройствоToolStripMenuItem_Click);
            // 
            // системуToolStripMenuItem
            // 
            this.системуToolStripMenuItem.Name = "системуToolStripMenuItem";
            this.системуToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.системуToolStripMenuItem.Text = "Систему";
            this.системуToolStripMenuItem.Click += new System.EventHandler(this.системуToolStripMenuItem_Click);
            // 
            // удалитьЭлементыToolStripMenuItem
            // 
            this.удалитьЭлементыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документыToolStripMenuItem3,
            this.деталиToolStripMenuItem,
            this.устройстваToolStripMenuItem1,
            this.системыToolStripMenuItem});
            this.удалитьЭлементыToolStripMenuItem.Name = "удалитьЭлементыToolStripMenuItem";
            this.удалитьЭлементыToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.удалитьЭлементыToolStripMenuItem.Text = "Удалить...";
            this.удалитьЭлементыToolStripMenuItem.Click += new System.EventHandler(this.удалитьДокументыToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem3
            // 
            this.документыToolStripMenuItem3.Name = "документыToolStripMenuItem3";
            this.документыToolStripMenuItem3.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem3.Text = "Документы";
            this.документыToolStripMenuItem3.Click += new System.EventHandler(this.документыToolStripMenuItem3_Click);
            // 
            // деталиToolStripMenuItem
            // 
            this.деталиToolStripMenuItem.Name = "деталиToolStripMenuItem";
            this.деталиToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.деталиToolStripMenuItem.Text = "Детали";
            this.деталиToolStripMenuItem.Click += new System.EventHandler(this.деталиToolStripMenuItem_Click);
            // 
            // устройстваToolStripMenuItem1
            // 
            this.устройстваToolStripMenuItem1.Name = "устройстваToolStripMenuItem1";
            this.устройстваToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.устройстваToolStripMenuItem1.Text = "Устройства";
            this.устройстваToolStripMenuItem1.Click += new System.EventHandler(this.устройстваToolStripMenuItem1_Click);
            // 
            // системыToolStripMenuItem
            // 
            this.системыToolStripMenuItem.Name = "системыToolStripMenuItem";
            this.системыToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.системыToolStripMenuItem.Text = "Системы";
            this.системыToolStripMenuItem.Click += new System.EventHandler(this.системыToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Список элементов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "В составе:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 530);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeViewElements);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DocTech";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripFiles.ResumeLayout(false);
            this.contextMenuStripDetails.ResumeLayout(false);
            this.contextMenuStripDevices.ResumeLayout(false);
            this.contextMenuStripSystems.ResumeLayout(false);
            this.contextMenuStripFile.ResumeLayout(false);
            this.contextMenuStripDetail.ResumeLayout(false);
            this.contextMenuStripDevice.ResumeLayout(false);
            this.contextMenuStripSystem.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЭлементыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem деталиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem устройстваToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem системыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem документToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem детальToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem устройствоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem системуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСвязьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem удалитьСвязьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem деталиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьСвязьToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem устройстваToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem пакетДокументацииToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem скачатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пакетДокументацииToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem пакетДокументацииToolStripMenuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

