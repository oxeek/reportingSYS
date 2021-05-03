namespace Reporting_v1._0
{
    partial class Отчет_контроля_кольцевых_сварных_соединений
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
            this.uchastok_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kss_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elem_number_do_shva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elem_number_posle_shva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ugl_orient_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ugl_orient_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GHD_dlina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GHD_visota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numbers_diapason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recomend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_row = new System.Windows.Forms.Button();
            this.add_row = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьПоследнееДействиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редакторСписковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._type = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.visible = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 15;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uchastok_number,
            this.kss_number,
            this.elem_number_do_shva,
            this.elem_number_posle_shva,
            this.defect_number,
            this.defect_type,
            this.ugl_orient_start,
            this.ugl_orient_end,
            this.GHD_dlina,
            this.GHD_visota,
            this.numbers_diapason,
            this.nd,
            this.recomend,
            this.note});
            this.dataGridView1.Location = new System.Drawing.Point(6, 155);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1096, 403);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // uchastok_number
            // 
            this.uchastok_number.HeaderText = "";
            this.uchastok_number.MinimumWidth = 6;
            this.uchastok_number.Name = "uchastok_number";
            this.uchastok_number.ReadOnly = true;
            this.uchastok_number.Width = 51;
            // 
            // kss_number
            // 
            this.kss_number.HeaderText = "";
            this.kss_number.MinimumWidth = 6;
            this.kss_number.Name = "kss_number";
            this.kss_number.Width = 62;
            // 
            // elem_number_do_shva
            // 
            this.elem_number_do_shva.HeaderText = "";
            this.elem_number_do_shva.MinimumWidth = 6;
            this.elem_number_do_shva.Name = "elem_number_do_shva";
            this.elem_number_do_shva.Width = 71;
            // 
            // elem_number_posle_shva
            // 
            this.elem_number_posle_shva.HeaderText = "";
            this.elem_number_posle_shva.MinimumWidth = 6;
            this.elem_number_posle_shva.Name = "elem_number_posle_shva";
            this.elem_number_posle_shva.Width = 83;
            // 
            // defect_number
            // 
            this.defect_number.HeaderText = "";
            this.defect_number.MinimumWidth = 6;
            this.defect_number.Name = "defect_number";
            this.defect_number.Width = 92;
            // 
            // defect_type
            // 
            this.defect_type.HeaderText = "";
            this.defect_type.MinimumWidth = 6;
            this.defect_type.Name = "defect_type";
            this.defect_type.Width = 72;
            // 
            // ugl_orient_start
            // 
            this.ugl_orient_start.HeaderText = "";
            this.ugl_orient_start.MinimumWidth = 6;
            this.ugl_orient_start.Name = "ugl_orient_start";
            this.ugl_orient_start.Width = 84;
            // 
            // ugl_orient_end
            // 
            this.ugl_orient_end.HeaderText = "";
            this.ugl_orient_end.MinimumWidth = 6;
            this.ugl_orient_end.Name = "ugl_orient_end";
            this.ugl_orient_end.Width = 74;
            // 
            // GHD_dlina
            // 
            this.GHD_dlina.HeaderText = "";
            this.GHD_dlina.MinimumWidth = 6;
            this.GHD_dlina.Name = "GHD_dlina";
            this.GHD_dlina.Width = 88;
            // 
            // GHD_visota
            // 
            this.GHD_visota.HeaderText = "";
            this.GHD_visota.MinimumWidth = 6;
            this.GHD_visota.Name = "GHD_visota";
            this.GHD_visota.Width = 86;
            // 
            // numbers_diapason
            // 
            this.numbers_diapason.HeaderText = "";
            this.numbers_diapason.MinimumWidth = 6;
            this.numbers_diapason.Name = "numbers_diapason";
            this.numbers_diapason.Width = 105;
            // 
            // nd
            // 
            this.nd.HeaderText = "";
            this.nd.MinimumWidth = 6;
            this.nd.Name = "nd";
            this.nd.Width = 70;
            // 
            // recomend
            // 
            this.recomend.HeaderText = "";
            this.recomend.MinimumWidth = 6;
            this.recomend.Name = "recomend";
            this.recomend.Width = 75;
            // 
            // note
            // 
            this.note.HeaderText = "";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.Width = 70;
            // 
            // del_row
            // 
            this.del_row.Location = new System.Drawing.Point(146, 22);
            this.del_row.Margin = new System.Windows.Forms.Padding(2);
            this.del_row.Name = "del_row";
            this.del_row.Size = new System.Drawing.Size(131, 24);
            this.del_row.TabIndex = 9;
            this.del_row.Text = "Удалить особенность";
            this.del_row.UseVisualStyleBackColor = true;
            this.del_row.Click += new System.EventHandler(this.del_row_Click);
            // 
            // add_row
            // 
            this.add_row.Location = new System.Drawing.Point(9, 22);
            this.add_row.Margin = new System.Windows.Forms.Padding(2);
            this.add_row.Name = "add_row";
            this.add_row.Size = new System.Drawing.Size(132, 24);
            this.add_row.TabIndex = 8;
            this.add_row.Text = "Добавить особенность";
            this.add_row.UseVisualStyleBackColor = true;
            this.add_row.Click += new System.EventHandler(this.add_row_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.вставитьЭлементToolStripMenuItem,
            this.отменитьПоследнееДействиеToolStripMenuItem,
            this.редакторСписковToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1111, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Visible = false;
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // вставитьЭлементToolStripMenuItem
            // 
            this.вставитьЭлементToolStripMenuItem.Name = "вставитьЭлементToolStripMenuItem";
            this.вставитьЭлементToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.вставитьЭлементToolStripMenuItem.Text = "Вставить элемент";
            this.вставитьЭлементToolStripMenuItem.Click += new System.EventHandler(this.вставитьЭлементToolStripMenuItem_Click);
            // 
            // отменитьПоследнееДействиеToolStripMenuItem
            // 
            this.отменитьПоследнееДействиеToolStripMenuItem.Name = "отменитьПоследнееДействиеToolStripMenuItem";
            this.отменитьПоследнееДействиеToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.отменитьПоследнееДействиеToolStripMenuItem.Text = "Отменить последнее действие";
            this.отменитьПоследнееДействиеToolStripMenuItem.Click += new System.EventHandler(this.отменитьПоследнееДействиеToolStripMenuItem_Click);
            // 
            // редакторСписковToolStripMenuItem
            // 
            this.редакторСписковToolStripMenuItem.Name = "редакторСписковToolStripMenuItem";
            this.редакторСписковToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.редакторСписковToolStripMenuItem.Text = "Редактор списков";
            this.редакторСписковToolStripMenuItem.Click += new System.EventHandler(this.редакторСписковToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this._type);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(6, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1096, 104);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(941, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 52);
            this.label14.TabIndex = 45;
            this.label14.Text = "Рекомендации \r\nк проведению\r\nДДК в шурфах\r\nметодами НК";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(871, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 39);
            this.label13.TabIndex = 44;
            this.label13.Text = "Соответствие \r\nтребованиям \r\nНД";
            // 
            // textBox13
            // 
            this.textBox13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox13.Location = new System.Drawing.Point(944, 80);
            this.textBox13.Margin = new System.Windows.Forms.Padding(2);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(78, 22);
            this.textBox13.TabIndex = 43;
            // 
            // textBox12
            // 
            this.textBox12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox12.Location = new System.Drawing.Point(873, 80);
            this.textBox12.Margin = new System.Windows.Forms.Padding(2);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(67, 22);
            this.textBox12.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(593, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 26);
            this.label8.TabIndex = 41;
            this.label8.Text = "Геометрические характеристики \r\n                    дефектов";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBox11
            // 
            this.textBox11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox11.Location = new System.Drawing.Point(767, 80);
            this.textBox11.Margin = new System.Windows.Forms.Padding(2);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(102, 21);
            this.textBox11.TabIndex = 40;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox10.Location = new System.Drawing.Point(518, 80);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(72, 21);
            this.textBox10.TabIndex = 39;
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(518, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 52);
            this.label10.TabIndex = 23;
            this.label10.Text = "    Угловая \r\n ориентация\r\n    дефекта\r\n(КОНЕЦ),час\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(46, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDoubleClick);
            // 
            // _type
            // 
            this._type.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._type.DropDownWidth = 250;
            this._type.FormattingEnabled = true;
            this._type.Location = new System.Drawing.Point(362, 80);
            this._type.Margin = new System.Windows.Forms.Padding(2);
            this._type.Name = "_type";
            this._type.Size = new System.Drawing.Size(69, 21);
            this._type.TabIndex = 10;
            this._type.SelectedIndexChanged += new System.EventHandler(this._type_SelectedIndexChanged);
            this._type.TextChanged += new System.EventHandler(this._type_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(55, 80);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 21);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox3.Location = new System.Drawing.Point(271, 80);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(88, 21);
            this.textBox3.TabIndex = 8;
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(116, 80);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 21);
            this.textBox4.TabIndex = 9;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(1025, 80);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(67, 22);
            this.textBox9.TabIndex = 34;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox8.Location = new System.Drawing.Point(680, 80);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(84, 21);
            this.textBox8.TabIndex = 33;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox7.Location = new System.Drawing.Point(593, 80);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(84, 21);
            this.textBox7.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "     № \r\nучастка";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox6.Location = new System.Drawing.Point(436, 80);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(78, 21);
            this.textBox6.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "     № \r\nКСС п/п";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(188, 80);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(79, 21);
            this.textBox5.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 39);
            this.label3.TabIndex = 15;
            this.label3.Text = "  № элемента \r\nпосле сварного \r\n        шва";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 39);
            this.label4.TabIndex = 16;
            this.label4.Text = "№ элемента \r\nдо сварного \r\n      шва";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 26);
            this.label7.TabIndex = 18;
            this.label7.Text = "№ дефекта\r\n     п/п";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Тип дефекта";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1023, 23);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Примечание";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "Ширина, \r\n   мм";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(771, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 26);
            this.label9.TabIndex = 24;
            this.label9.Text = "Диапазон номеров \r\nкадров (при ВИК)";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(672, 50);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 26);
            this.label12.TabIndex = 21;
            this.label12.Text = "Высота (глубина), \r\n             мм ";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 65);
            this.label11.TabIndex = 22;
            this.label11.Text = "    Угловая \r\n ориентация\r\n    дефекта\r\n(НАЧАЛО),час\r\n             ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 24);
            this.button1.TabIndex = 43;
            this.button1.Text = "Сохранить особенность";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // visible
            // 
            this.visible.AutoSize = true;
            this.visible.Location = new System.Drawing.Point(778, 29);
            this.visible.Name = "visible";
            this.visible.Size = new System.Drawing.Size(320, 17);
            this.visible.TabIndex = 44;
            this.visible.Text = "Скрыть столбцы с номерами элементов до сварного шва";
            this.visible.UseVisualStyleBackColor = true;
            this.visible.CheckedChanged += new System.EventHandler(this.visible_CheckedChanged);
            // 
            // Отчет_контроля_кольцевых_сварных_соединений
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 572);
            this.Controls.Add(this.visible);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.del_row);
            this.Controls.Add(this.add_row);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Отчет_контроля_кольцевых_сварных_соединений";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал ВИК";
            this.MinimumSizeChanged += new System.EventHandler(this.Отчет_контроля_кольцевых_сварных_соединений_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Отчет_контроля_кольцевых_сварных_соединений_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Отчет_контроля_кольцевых_сварных_соединений_FormClosed);
            this.Load += new System.EventHandler(this.Отчет_контроля_кольцевых_сварных_соединений_Load);
            this.SizeChanged += new System.EventHandler(this.Отчет_контроля_кольцевых_сварных_соединений_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button del_row;
        private System.Windows.Forms.Button add_row;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редакторСписковToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox _type;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn uchastok_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn kss_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn elem_number_do_shva;
        private System.Windows.Forms.DataGridViewTextBoxColumn elem_number_posle_shva;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ugl_orient_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn ugl_orient_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn GHD_dlina;
        private System.Windows.Forms.DataGridViewTextBoxColumn GHD_visota;
        private System.Windows.Forms.DataGridViewTextBoxColumn numbers_diapason;
        private System.Windows.Forms.DataGridViewTextBoxColumn nd;
        private System.Windows.Forms.DataGridViewTextBoxColumn recomend;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.CheckBox visible;
        private System.Windows.Forms.ToolStripMenuItem отменитьПоследнееДействиеToolStripMenuItem;
    }
}