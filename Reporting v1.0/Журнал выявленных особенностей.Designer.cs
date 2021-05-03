namespace Reporting_v1._0
{
    partial class Журнал_выявленных_особенностей
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
            this.area_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elem_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.osobennost_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.osobennost_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ot_nachala_elem_to_osobennost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ot_nachala_elem_to_END_osobennost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ugl_orient_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ugl_orient_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.osob_dlina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.osob_shir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photo_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recomend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьСтрокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьПоследнееДействиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редакторСписковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.del_row = new System.Windows.Forms.Button();
            this.add_row = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
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
            this.area_number,
            this.elem_number,
            this.osobennost_number,
            this.osobennost_type,
            this.ot_nachala_elem_to_osobennost,
            this.ot_nachala_elem_to_END_osobennost,
            this.ugl_orient_start,
            this.ugl_orient_end,
            this.osob_dlina,
            this.osob_shir,
            this.photo_number,
            this.recomend,
            this.note});
            this.dataGridView1.Location = new System.Drawing.Point(9, 173);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1094, 407);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // area_number
            // 
            this.area_number.HeaderText = "";
            this.area_number.MinimumWidth = 6;
            this.area_number.Name = "area_number";
            this.area_number.Width = 48;
            // 
            // elem_number
            // 
            this.elem_number.HeaderText = "";
            this.elem_number.MinimumWidth = 6;
            this.elem_number.Name = "elem_number";
            this.elem_number.Width = 61;
            // 
            // osobennost_number
            // 
            this.osobennost_number.HeaderText = "";
            this.osobennost_number.MinimumWidth = 6;
            this.osobennost_number.Name = "osobennost_number";
            this.osobennost_number.Width = 72;
            // 
            // osobennost_type
            // 
            this.osobennost_type.HeaderText = "";
            this.osobennost_type.MinimumWidth = 6;
            this.osobennost_type.Name = "osobennost_type";
            this.osobennost_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.osobennost_type.Width = 83;
            // 
            // ot_nachala_elem_to_osobennost
            // 
            this.ot_nachala_elem_to_osobennost.HeaderText = "";
            this.ot_nachala_elem_to_osobennost.MinimumWidth = 6;
            this.ot_nachala_elem_to_osobennost.Name = "ot_nachala_elem_to_osobennost";
            this.ot_nachala_elem_to_osobennost.Width = 93;
            // 
            // ot_nachala_elem_to_END_osobennost
            // 
            this.ot_nachala_elem_to_END_osobennost.HeaderText = "";
            this.ot_nachala_elem_to_END_osobennost.MinimumWidth = 6;
            this.ot_nachala_elem_to_END_osobennost.Name = "ot_nachala_elem_to_END_osobennost";
            this.ot_nachala_elem_to_END_osobennost.Width = 145;
            // 
            // ugl_orient_start
            // 
            this.ugl_orient_start.HeaderText = "";
            this.ugl_orient_start.MinimumWidth = 6;
            this.ugl_orient_start.Name = "ugl_orient_start";
            this.ugl_orient_start.Width = 101;
            // 
            // ugl_orient_end
            // 
            this.ugl_orient_end.HeaderText = "";
            this.ugl_orient_end.MinimumWidth = 6;
            this.ugl_orient_end.Name = "ugl_orient_end";
            this.ugl_orient_end.Width = 95;
            // 
            // osob_dlina
            // 
            this.osob_dlina.HeaderText = "";
            this.osob_dlina.MinimumWidth = 6;
            this.osob_dlina.Name = "osob_dlina";
            this.osob_dlina.Width = 80;
            // 
            // osob_shir
            // 
            this.osob_shir.HeaderText = "";
            this.osob_shir.MinimumWidth = 6;
            this.osob_shir.Name = "osob_shir";
            this.osob_shir.Width = 82;
            // 
            // photo_number
            // 
            this.photo_number.HeaderText = "";
            this.photo_number.MinimumWidth = 6;
            this.photo_number.Name = "photo_number";
            this.photo_number.Width = 83;
            // 
            // recomend
            // 
            this.recomend.HeaderText = "";
            this.recomend.MinimumWidth = 6;
            this.recomend.Name = "recomend";
            this.recomend.Width = 79;
            // 
            // note
            // 
            this.note.HeaderText = "";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.Width = 76;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.вставитьСтрокуToolStripMenuItem,
            this.отменитьПоследнееДействиеToolStripMenuItem,
            this.редакторСписковToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1112, 24);
            this.menuStrip1.TabIndex = 1;
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
            // вставитьСтрокуToolStripMenuItem
            // 
            this.вставитьСтрокуToolStripMenuItem.Name = "вставитьСтрокуToolStripMenuItem";
            this.вставитьСтрокуToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.вставитьСтрокуToolStripMenuItem.Text = "Вставить особенность";
            this.вставитьСтрокуToolStripMenuItem.Click += new System.EventHandler(this.вставитьСтрокуToolStripMenuItem_Click);
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
            // del_row
            // 
            this.del_row.Location = new System.Drawing.Point(149, 34);
            this.del_row.Margin = new System.Windows.Forms.Padding(2);
            this.del_row.Name = "del_row";
            this.del_row.Size = new System.Drawing.Size(128, 24);
            this.del_row.TabIndex = 7;
            this.del_row.Text = "Удалить особенность";
            this.del_row.UseVisualStyleBackColor = true;
            this.del_row.Click += new System.EventHandler(this.del_row_Click);
            // 
            // add_row
            // 
            this.add_row.Location = new System.Drawing.Point(9, 34);
            this.add_row.Margin = new System.Windows.Forms.Padding(2);
            this.add_row.Name = "add_row";
            this.add_row.Size = new System.Drawing.Size(136, 24);
            this.add_row.TabIndex = 6;
            this.add_row.Text = "Добавить особенность";
            this.add_row.UseVisualStyleBackColor = true;
            this.add_row.Click += new System.EventHandler(this.add_row_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox12);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1094, 104);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(946, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Рекомендации";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(951, 80);
            this.textBox12.Margin = new System.Windows.Forms.Padding(2);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(73, 22);
            this.textBox12.TabIndex = 41;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(867, 80);
            this.textBox11.Margin = new System.Windows.Forms.Padding(2);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(80, 21);
            this.textBox11.TabIndex = 40;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(610, 80);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(92, 21);
            this.textBox10.TabIndex = 39;
            this.textBox10.TextAlignChanged += new System.EventHandler(this.textBox10_TextAlignChanged);
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(598, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 65);
            this.label10.TabIndex = 23;
            this.label10.Text = "         Угловая \r\n      ориентация\r\n          дефекта\r\n     (КОНЕЦ),град\r\n      " +
    "       \r\n";
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
            this._type.DropDownWidth = 250;
            this._type.FormattingEnabled = true;
            this._type.Location = new System.Drawing.Point(188, 80);
            this._type.Margin = new System.Windows.Forms.Padding(2);
            this._type.Name = "_type";
            this._type.Size = new System.Drawing.Size(80, 21);
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
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(272, 80);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(88, 21);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(116, 80);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 21);
            this.textBox4.TabIndex = 9;
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(1028, 80);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(60, 22);
            this.textBox9.TabIndex = 34;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(783, 80);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(80, 21);
            this.textBox8.TabIndex = 33;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(706, 80);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(74, 21);
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
            this.textBox6.Location = new System.Drawing.Point(508, 80);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(98, 21);
            this.textBox6.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 39);
            this.label2.TabIndex = 14;
            this.label2.Text = "     № \r\nэлемента\r\n    п/п";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(364, 80);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(141, 21);
            this.textBox5.TabIndex = 30;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "       Тип\r\nособенности";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 39);
            this.label4.TabIndex = 16;
            this.label4.Text = "        № \r\nособенности \r\n       п/п";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 65);
            this.label7.TabIndex = 18;
            this.label7.Text = "    Расстояние  \r\n     от начала \r\n      элемента \r\nдо особенности,\r\n            " +
    "  м";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 52);
            this.label6.TabIndex = 19;
            this.label6.Text = "         Расстояние  \r\n  от начала элемента       \r\nдо конца особенности,\r\n      " +
    "            м\r\n";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1025, 37);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Примечание";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(706, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 52);
            this.label5.TabIndex = 20;
            this.label5.Text = "Измеренная \r\n      длина \r\nособенности,\r\n         мм";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(868, 19);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 39);
            this.label9.TabIndex = 24;
            this.label9.Text = "      № фото \r\n  выявленных\r\n особенностей";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(788, 15);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 52);
            this.label12.TabIndex = 21;
            this.label12.Text = "Измеренная \r\n    ширина \r\nособенности ,\r\n        мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(499, 8);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 78);
            this.label11.TabIndex = 22;
            this.label11.Text = "         Угловая \r\n      ориентация\r\n          дефекта\r\n     (НАЧАЛО),град\r\n\r\n   " +
    "          ";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 24);
            this.button1.TabIndex = 42;
            this.button1.Text = "Сохранить особенность";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Журнал_выявленных_особенностей
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 590);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.del_row);
            this.Controls.Add(this.add_row);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Журнал_выявленных_особенностей";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал_выявленных_особенностей";
            this.MaximizedBoundsChanged += new System.EventHandler(this.Журнал_выявленных_особенностей_MaximizedBoundsChanged);
            this.MaximumSizeChanged += new System.EventHandler(this.Журнал_выявленных_особенностей_MaximumSizeChanged);
            this.MinimumSizeChanged += new System.EventHandler(this.Журнал_выявленных_особенностей_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Журнал_выявленных_особенностей_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Журнал_выявленных_особенностей_FormClosed);
            this.Load += new System.EventHandler(this.Журнал_выявленных_особенностей_Load);
            this.SizeChanged += new System.EventHandler(this.Журнал_выявленных_особенностей_SizeChanged);
            this.StyleChanged += new System.EventHandler(this.Журнал_выявленных_особенностей_StyleChanged);
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button del_row;
        private System.Windows.Forms.Button add_row;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьСтрокуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редакторСписковToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox _type;
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
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn elem_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn osobennost_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn osobennost_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ot_nachala_elem_to_osobennost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ot_nachala_elem_to_END_osobennost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ugl_orient_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn ugl_orient_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn osob_dlina;
        private System.Windows.Forms.DataGridViewTextBoxColumn osob_shir;
        private System.Windows.Forms.DataGridViewTextBoxColumn photo_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn recomend;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.ToolStripMenuItem отменитьПоследнееДействиеToolStripMenuItem;
    }
}