namespace GOiCHS
{
    partial class Form1
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
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.qLabel = new System.Windows.Forms.Label();
            this.aLabel = new System.Windows.Forms.Label();
            this.aButton = new System.Windows.Forms.Button();
            this.skipBttn = new System.Windows.Forms.Button();
            this.qLabelContent = new System.Windows.Forms.Label();
            this.testTypeCBox = new System.Windows.Forms.ComboBox();
            this.depCBox = new System.Windows.Forms.ComboBox();
            this.titleCbox = new System.Windows.Forms.ComboBox();
            this.checkTypeCBox = new System.Windows.Forms.ComboBox();
            this.surnameTBox = new System.Windows.Forms.TextBox();
            this.nameTBox = new System.Windows.Forms.TextBox();
            this.patronymicTBox = new System.Windows.Forms.TextBox();
            this.testTypeLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.patronymicLabel = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.checkTypeLabel = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлСВопросамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлСОтчетомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(701, 25);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(129, 20);
            this.aTextBox.TabIndex = 1;
            this.aTextBox.Visible = false;
            // 
            // qLabel
            // 
            this.qLabel.AutoSize = true;
            this.qLabel.Location = new System.Drawing.Point(12, 32);
            this.qLabel.Name = "qLabel";
            this.qLabel.Size = new System.Drawing.Size(44, 13);
            this.qLabel.TabIndex = 2;
            this.qLabel.Text = "Вопрос";
            this.qLabel.Visible = false;
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(701, 9);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(37, 13);
            this.aLabel.TabIndex = 3;
            this.aLabel.Text = "Ответ";
            this.aLabel.Visible = false;
            // 
            // aButton
            // 
            this.aButton.Location = new System.Drawing.Point(701, 52);
            this.aButton.Name = "aButton";
            this.aButton.Size = new System.Drawing.Size(75, 23);
            this.aButton.TabIndex = 4;
            this.aButton.Text = "Ответить";
            this.aButton.UseVisualStyleBackColor = true;
            this.aButton.Visible = false;
            this.aButton.Click += new System.EventHandler(this.aButton_Click);
            // 
            // skipBttn
            // 
            this.skipBttn.Location = new System.Drawing.Point(837, 23);
            this.skipBttn.Name = "skipBttn";
            this.skipBttn.Size = new System.Drawing.Size(75, 23);
            this.skipBttn.TabIndex = 5;
            this.skipBttn.Text = "Пропустить";
            this.skipBttn.UseVisualStyleBackColor = true;
            this.skipBttn.Visible = false;
            this.skipBttn.Click += new System.EventHandler(this.skipBttn_Click);
            // 
            // qLabelContent
            // 
            this.qLabelContent.Location = new System.Drawing.Point(12, 24);
            this.qLabelContent.Name = "qLabelContent";
            this.qLabelContent.Size = new System.Drawing.Size(673, 196);
            this.qLabelContent.TabIndex = 6;
            // 
            // testTypeCBox
            // 
            this.testTypeCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testTypeCBox.FormattingEnabled = true;
            this.testTypeCBox.Location = new System.Drawing.Point(12, 48);
            this.testTypeCBox.Name = "testTypeCBox";
            this.testTypeCBox.Size = new System.Drawing.Size(435, 21);
            this.testTypeCBox.TabIndex = 7;
            // 
            // depCBox
            // 
            this.depCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depCBox.FormattingEnabled = true;
            this.depCBox.Location = new System.Drawing.Point(12, 223);
            this.depCBox.Name = "depCBox";
            this.depCBox.Size = new System.Drawing.Size(435, 21);
            this.depCBox.TabIndex = 11;
            // 
            // titleCbox
            // 
            this.titleCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.titleCbox.FormattingEnabled = true;
            this.titleCbox.Location = new System.Drawing.Point(12, 268);
            this.titleCbox.Name = "titleCbox";
            this.titleCbox.Size = new System.Drawing.Size(435, 21);
            this.titleCbox.TabIndex = 12;
            // 
            // checkTypeCBox
            // 
            this.checkTypeCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkTypeCBox.DropDownWidth = 429;
            this.checkTypeCBox.FormattingEnabled = true;
            this.checkTypeCBox.Location = new System.Drawing.Point(12, 313);
            this.checkTypeCBox.Name = "checkTypeCBox";
            this.checkTypeCBox.Size = new System.Drawing.Size(435, 21);
            this.checkTypeCBox.TabIndex = 13;
            // 
            // surnameTBox
            // 
            this.surnameTBox.Location = new System.Drawing.Point(12, 93);
            this.surnameTBox.Name = "surnameTBox";
            this.surnameTBox.Size = new System.Drawing.Size(435, 20);
            this.surnameTBox.TabIndex = 8;
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(12, 138);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(435, 20);
            this.nameTBox.TabIndex = 9;
            // 
            // patronymicTBox
            // 
            this.patronymicTBox.Location = new System.Drawing.Point(12, 183);
            this.patronymicTBox.Name = "patronymicTBox";
            this.patronymicTBox.Size = new System.Drawing.Size(435, 20);
            this.patronymicTBox.TabIndex = 10;
            // 
            // testTypeLabel
            // 
            this.testTypeLabel.AutoSize = true;
            this.testTypeLabel.Location = new System.Drawing.Point(12, 33);
            this.testTypeLabel.Name = "testTypeLabel";
            this.testTypeLabel.Size = new System.Drawing.Size(71, 13);
            this.testTypeLabel.TabIndex = 14;
            this.testTypeLabel.Text = "Выбор теста";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(12, 78);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(56, 13);
            this.surnameLabel.TabIndex = 15;
            this.surnameLabel.Text = "Фамилия";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 123);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 13);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "Имя";
            // 
            // patronymicLabel
            // 
            this.patronymicLabel.AutoSize = true;
            this.patronymicLabel.Location = new System.Drawing.Point(12, 163);
            this.patronymicLabel.Name = "patronymicLabel";
            this.patronymicLabel.Size = new System.Drawing.Size(54, 13);
            this.patronymicLabel.TabIndex = 17;
            this.patronymicLabel.Text = "Отчество";
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(12, 208);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(151, 13);
            this.departmentLabel.TabIndex = 18;
            this.departmentLabel.Text = "Структурное подразделение";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 253);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(65, 13);
            this.titleLabel.TabIndex = 19;
            this.titleLabel.Text = "Должность";
            // 
            // checkTypeLabel
            // 
            this.checkTypeLabel.AutoSize = true;
            this.checkTypeLabel.Location = new System.Drawing.Point(12, 298);
            this.checkTypeLabel.Name = "checkTypeLabel";
            this.checkTypeLabel.Size = new System.Drawing.Size(77, 13);
            this.checkTypeLabel.TabIndex = 20;
            this.checkTypeLabel.Text = "Тип проверки";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(187, 338);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(77, 23);
            this.startBtn.TabIndex = 21;
            this.startBtn.Text = "Начать тест";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(701, 82);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(242, 140);
            this.pBox.TabIndex = 22;
            this.pBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сервисToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлСВопросамиToolStripMenuItem,
            this.открытьФайлСОтчетомToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // открытьФайлСВопросамиToolStripMenuItem
            // 
            this.открытьФайлСВопросамиToolStripMenuItem.Name = "открытьФайлСВопросамиToolStripMenuItem";
            this.открытьФайлСВопросамиToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.открытьФайлСВопросамиToolStripMenuItem.Text = "Открыть файл с вопросами";
            this.открытьФайлСВопросамиToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлСВопросамиToolStripMenuItem_Click);
            // 
            // открытьФайлСОтчетомToolStripMenuItem
            // 
            this.открытьФайлСОтчетомToolStripMenuItem.Name = "открытьФайлСОтчетомToolStripMenuItem";
            this.открытьФайлСОтчетомToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.открытьФайлСОтчетомToolStripMenuItem.Text = "Открыть файл с отчетом";
            this.открытьФайлСОтчетомToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлСОтчетомToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 400);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.checkTypeLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.patronymicLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.testTypeLabel);
            this.Controls.Add(this.patronymicTBox);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.surnameTBox);
            this.Controls.Add(this.checkTypeCBox);
            this.Controls.Add(this.titleCbox);
            this.Controls.Add(this.depCBox);
            this.Controls.Add(this.testTypeCBox);
            this.Controls.Add(this.qLabelContent);
            this.Controls.Add(this.skipBttn);
            this.Controls.Add(this.aButton);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.qLabel);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Тестирование";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.Label qLabel;
        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.Button aButton;
        private System.Windows.Forms.Button skipBttn;
        private System.Windows.Forms.Label qLabelContent;
        private System.Windows.Forms.ComboBox testTypeCBox;
        private System.Windows.Forms.ComboBox depCBox;
        private System.Windows.Forms.ComboBox titleCbox;
        private System.Windows.Forms.ComboBox checkTypeCBox;
        private System.Windows.Forms.TextBox surnameTBox;
        private System.Windows.Forms.TextBox nameTBox;
        private System.Windows.Forms.TextBox patronymicTBox;
        private System.Windows.Forms.Label testTypeLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label patronymicLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label checkTypeLabel;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлСВопросамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлСОтчетомToolStripMenuItem;
    }
}

