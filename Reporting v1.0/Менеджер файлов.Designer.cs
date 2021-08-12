namespace Reporting_v1._0
{
    partial class Менеджер_файлов
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.file_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checker = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.word_gen = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CHBready = new System.Windows.Forms.CheckBox();
            this.export = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exgen = new System.Windows.Forms.CheckBox();
            this.stat = new System.Windows.Forms.CheckBox();
            this.detal = new System.Windows.Forms.CheckBox();
            this.img_VTO = new System.Windows.Forms.CheckBox();
            this.tolchik_check = new System.Windows.Forms.CheckBox();
            this.elements_magazine = new System.Windows.Forms.CheckBox();
            this.UZKcheck = new System.Windows.Forms.CheckBox();
            this.VIKcheck = new System.Windows.Forms.CheckBox();
            this.VTOcheck = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pdf_gen = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button6 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.file_number,
            this.file_path,
            this.file_name,
            this.checker});
            this.dataGridView1.Location = new System.Drawing.Point(9, 69);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(788, 520);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // file_number
            // 
            this.file_number.HeaderText = "№";
            this.file_number.MinimumWidth = 6;
            this.file_number.Name = "file_number";
            this.file_number.ReadOnly = true;
            this.file_number.Width = 30;
            // 
            // file_path
            // 
            this.file_path.HeaderText = "Путь до файла";
            this.file_path.MinimumWidth = 6;
            this.file_path.Name = "file_path";
            this.file_path.ReadOnly = true;
            this.file_path.Width = 445;
            // 
            // file_name
            // 
            this.file_name.HeaderText = "Имя файла";
            this.file_name.MinimumWidth = 6;
            this.file_name.Name = "file_name";
            this.file_name.ReadOnly = true;
            this.file_name.Width = 220;
            // 
            // checker
            // 
            this.checker.HeaderText = "";
            this.checker.MinimumWidth = 6;
            this.checker.Name = "checker";
            this.checker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checker.Width = 50;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            ".csv",
            ".xlsm",
            ".xsl",
            ".txt"});
            this.comboBox1.Location = new System.Drawing.Point(94, 10);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Маска поиска";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Вид контроля";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 24);
            this.button2.TabIndex = 6;
            this.button2.Text = "Выбрать путь";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Текущий путь:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(409, 11);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.linkLabel1_MouseClick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1073, 43);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 25);
            this.button3.TabIndex = 9;
            this.button3.Text = "Выгрузить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(811, 42);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 25);
            this.button4.TabIndex = 10;
            this.button4.Text = "Удалить файл";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.export);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(811, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(361, 307);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.word_gen);
            this.groupBox5.Location = new System.Drawing.Point(182, 45);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(174, 193);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Генерация word";
            // 
            // word_gen
            // 
            this.word_gen.AutoSize = true;
            this.word_gen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.word_gen.Location = new System.Drawing.Point(9, 19);
            this.word_gen.Margin = new System.Windows.Forms.Padding(2);
            this.word_gen.Name = "word_gen";
            this.word_gen.Size = new System.Drawing.Size(142, 17);
            this.word_gen.TabIndex = 6;
            this.word_gen.Text = "Генерация отчёта word";
            this.word_gen.UseVisualStyleBackColor = true;
            this.word_gen.CheckedChanged += new System.EventHandler(this.word_gen_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CHBready);
            this.groupBox3.Location = new System.Drawing.Point(182, 242);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(174, 49);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройка детализации";
            // 
            // CHBready
            // 
            this.CHBready.AutoSize = true;
            this.CHBready.Location = new System.Drawing.Point(12, 20);
            this.CHBready.Margin = new System.Windows.Forms.Padding(2);
            this.CHBready.Name = "CHBready";
            this.CHBready.Size = new System.Drawing.Size(81, 17);
            this.CHBready.TabIndex = 6;
            this.CHBready.Text = "ЧБ режим ";
            this.CHBready.UseVisualStyleBackColor = true;
            // 
            // export
            // 
            this.export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.export.Location = new System.Drawing.Point(0, 17);
            this.export.Margin = new System.Windows.Forms.Padding(2);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(153, 25);
            this.export.TabIndex = 12;
            this.export.Text = "Отчёт";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exgen);
            this.groupBox2.Controls.Add(this.stat);
            this.groupBox2.Controls.Add(this.detal);
            this.groupBox2.Controls.Add(this.img_VTO);
            this.groupBox2.Controls.Add(this.tolchik_check);
            this.groupBox2.Controls.Add(this.elements_magazine);
            this.groupBox2.Controls.Add(this.UZKcheck);
            this.groupBox2.Controls.Add(this.VIKcheck);
            this.groupBox2.Controls.Add(this.VTOcheck);
            this.groupBox2.Location = new System.Drawing.Point(4, 45);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(174, 246);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вид контроля";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // exgen
            // 
            this.exgen.AutoSize = true;
            this.exgen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exgen.Location = new System.Drawing.Point(12, 19);
            this.exgen.Margin = new System.Windows.Forms.Padding(2);
            this.exgen.Name = "exgen";
            this.exgen.Size = new System.Drawing.Size(109, 17);
            this.exgen.TabIndex = 15;
            this.exgen.Text = "Генерация Excel";
            this.exgen.UseVisualStyleBackColor = true;
            this.exgen.CheckedChanged += new System.EventHandler(this.exgen_CheckedChanged);
            this.exgen.CheckStateChanged += new System.EventHandler(this.exgen_CheckStateChanged);
            // 
            // stat
            // 
            this.stat.AutoSize = true;
            this.stat.Location = new System.Drawing.Point(12, 193);
            this.stat.Margin = new System.Windows.Forms.Padding(2);
            this.stat.Name = "stat";
            this.stat.Size = new System.Drawing.Size(84, 17);
            this.stat.TabIndex = 14;
            this.stat.Text = "Статистика";
            this.stat.UseVisualStyleBackColor = true;
            // 
            // detal
            // 
            this.detal.AutoSize = true;
            this.detal.Location = new System.Drawing.Point(12, 172);
            this.detal.Margin = new System.Windows.Forms.Padding(2);
            this.detal.Name = "detal";
            this.detal.Size = new System.Drawing.Size(127, 17);
            this.detal.TabIndex = 13;
            this.detal.Text = "Листы детализации";
            this.detal.UseVisualStyleBackColor = true;
            // 
            // img_VTO
            // 
            this.img_VTO.AutoSize = true;
            this.img_VTO.Location = new System.Drawing.Point(12, 150);
            this.img_VTO.Margin = new System.Windows.Forms.Padding(2);
            this.img_VTO.Name = "img_VTO";
            this.img_VTO.Size = new System.Drawing.Size(90, 17);
            this.img_VTO.TabIndex = 5;
            this.img_VTO.Text = "Снимки ВТО";
            this.img_VTO.UseVisualStyleBackColor = true;
            // 
            // tolchik_check
            // 
            this.tolchik_check.AutoSize = true;
            this.tolchik_check.Location = new System.Drawing.Point(12, 128);
            this.tolchik_check.Margin = new System.Windows.Forms.Padding(2);
            this.tolchik_check.Name = "tolchik_check";
            this.tolchik_check.Size = new System.Drawing.Size(109, 17);
            this.tolchik_check.TabIndex = 4;
            this.tolchik_check.Text = "Толщинометрия";
            this.tolchik_check.UseVisualStyleBackColor = true;
            // 
            // elements_magazine
            // 
            this.elements_magazine.AutoSize = true;
            this.elements_magazine.Location = new System.Drawing.Point(12, 40);
            this.elements_magazine.Margin = new System.Windows.Forms.Padding(2);
            this.elements_magazine.Name = "elements_magazine";
            this.elements_magazine.Size = new System.Drawing.Size(124, 17);
            this.elements_magazine.TabIndex = 3;
            this.elements_magazine.Text = "Журнал элементов";
            this.elements_magazine.UseVisualStyleBackColor = true;
            // 
            // UZKcheck
            // 
            this.UZKcheck.AutoSize = true;
            this.UZKcheck.Location = new System.Drawing.Point(12, 106);
            this.UZKcheck.Margin = new System.Windows.Forms.Padding(2);
            this.UZKcheck.Name = "UZKcheck";
            this.UZKcheck.Size = new System.Drawing.Size(48, 17);
            this.UZKcheck.TabIndex = 2;
            this.UZKcheck.Text = "УЗК";
            this.UZKcheck.UseVisualStyleBackColor = true;
            // 
            // VIKcheck
            // 
            this.VIKcheck.AutoSize = true;
            this.VIKcheck.Location = new System.Drawing.Point(12, 84);
            this.VIKcheck.Margin = new System.Windows.Forms.Padding(2);
            this.VIKcheck.Name = "VIKcheck";
            this.VIKcheck.Size = new System.Drawing.Size(48, 17);
            this.VIKcheck.TabIndex = 1;
            this.VIKcheck.Text = "ВИК";
            this.VIKcheck.UseVisualStyleBackColor = true;
            // 
            // VTOcheck
            // 
            this.VTOcheck.AutoSize = true;
            this.VTOcheck.Location = new System.Drawing.Point(12, 62);
            this.VTOcheck.Margin = new System.Windows.Forms.Padding(2);
            this.VTOcheck.Name = "VTOcheck";
            this.VTOcheck.Size = new System.Drawing.Size(48, 17);
            this.VTOcheck.TabIndex = 0;
            this.VTOcheck.Text = "ВТО";
            this.VTOcheck.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pdf_gen);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(811, 403);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(174, 49);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Генерация pdf";
            this.groupBox4.Visible = false;
            // 
            // pdf_gen
            // 
            this.pdf_gen.AutoSize = true;
            this.pdf_gen.Location = new System.Drawing.Point(12, 21);
            this.pdf_gen.Margin = new System.Windows.Forms.Padding(2);
            this.pdf_gen.Name = "pdf_gen";
            this.pdf_gen.Size = new System.Drawing.Size(139, 17);
            this.pdf_gen.TabIndex = 0;
            this.pdf_gen.Text = "Генерация общего pdf";
            this.pdf_gen.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(754, 43);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 22);
            this.button5.TabIndex = 12;
            this.button5.Text = "✔";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(811, 380);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(361, 19);
            this.progressBar1.TabIndex = 13;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1008, 555);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(164, 38);
            this.button6.TabIndex = 14;
            this.button6.Text = "Принудительное завершение Excel";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label26.Location = new System.Drawing.Point(584, 39);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(166, 13);
            this.label26.TabIndex = 60;
            this.label26.Text = "Система формирования отчётов";
            this.label26.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Location = new System.Drawing.Point(584, 51);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(166, 13);
            this.label25.TabIndex = 59;
            this.label25.Text = "Система формирования отчётов";
            this.label25.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(603, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(336, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 91);
            this.label5.TabIndex = 61;
            this.label5.Text = "!";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(808, 568);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Запущеных Excel процессов:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(973, 568);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(944, 42);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 25);
            this.button7.TabIndex = 64;
            this.button7.Text = "TEST";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(944, 5);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(47, 20);
            this.textBox2.TabIndex = 65;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(996, 5);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(47, 20);
            this.textBox3.TabIndex = 66;
            // 
            // Менеджер_файлов
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 604);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Менеджер_файлов";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер_файлов";
            this.Load += new System.EventHandler(this.Менеджер_файлов_Load);
            this.SizeChanged += new System.EventHandler(this.Менеджер_файлов_SizeChanged);
            this.Click += new System.EventHandler(this.Менеджер_файлов_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox elements_magazine;
        private System.Windows.Forms.CheckBox UZKcheck;
        private System.Windows.Forms.CheckBox VIKcheck;
        private System.Windows.Forms.CheckBox VTOcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checker;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox tolchik_check;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox img_VTO;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CHBready;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox detal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox pdf_gen;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox word_gen;
        private System.Windows.Forms.CheckBox stat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox exgen;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}