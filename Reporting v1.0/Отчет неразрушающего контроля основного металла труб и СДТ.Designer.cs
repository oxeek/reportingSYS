namespace Reporting_v1._0
{
    partial class Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uchastok_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stenka_tolshina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rasp_defect_ot_shva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOD_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOD_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_dlin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_shirina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_glubin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ost_tolsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_otnosit_glubin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recomend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редакторСписковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.del_row = new System.Windows.Forms.Button();
            this.add_row = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 80;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uchastok_number,
            this.element_number,
            this.stenka_tolshina,
            this.defect_number,
            this.defect_type,
            this.rasp_defect_ot_shva,
            this.UOD_start,
            this.UOD_end,
            this.defect_dlin,
            this.defect_shirina,
            this.defect_glubin,
            this.ost_tolsh,
            this.defect_otnosit_glubin,
            this.recomend,
            this.note});
            this.dataGridView1.Location = new System.Drawing.Point(30, 59);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1123, 461);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // uchastok_number
            // 
            this.uchastok_number.HeaderText = "№ диагностируемого участка";
            this.uchastok_number.MinimumWidth = 6;
            this.uchastok_number.Name = "uchastok_number";
            this.uchastok_number.ReadOnly = true;
            this.uchastok_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.uchastok_number.Width = 102;
            // 
            // element_number
            // 
            this.element_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.element_number.HeaderText = "№ элемента п/п";
            this.element_number.MinimumWidth = 6;
            this.element_number.Name = "element_number";
            this.element_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.element_number.Width = 120;
            // 
            // stenka_tolshina
            // 
            this.stenka_tolshina.HeaderText = "Измеренная толщина стенки элемента, мм";
            this.stenka_tolshina.MinimumWidth = 6;
            this.stenka_tolshina.Name = "stenka_tolshina";
            this.stenka_tolshina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stenka_tolshina.Width = 70;
            // 
            // defect_number
            // 
            this.defect_number.HeaderText = "№ дефекта п/п";
            this.defect_number.MinimumWidth = 6;
            this.defect_number.Name = "defect_number";
            this.defect_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.defect_number.Width = 55;
            // 
            // defect_type
            // 
            this.defect_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.defect_type.HeaderText = "Тип дефекта";
            this.defect_type.MinimumWidth = 6;
            this.defect_type.Name = "defect_type";
            this.defect_type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.defect_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.defect_type.Width = 70;
            // 
            // rasp_defect_ot_shva
            // 
            this.rasp_defect_ot_shva.HeaderText = "Расположение дефекта от кольцевого шва, мм";
            this.rasp_defect_ot_shva.MinimumWidth = 6;
            this.rasp_defect_ot_shva.Name = "rasp_defect_ot_shva";
            this.rasp_defect_ot_shva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rasp_defect_ot_shva.Width = 125;
            // 
            // UOD_start
            // 
            this.UOD_start.HeaderText = "Угловая ориентация дефекта (НАЧАЛО), час";
            this.UOD_start.MinimumWidth = 6;
            this.UOD_start.Name = "UOD_start";
            this.UOD_start.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOD_start.Width = 70;
            // 
            // UOD_end
            // 
            this.UOD_end.HeaderText = "Угловая ориентация дефекта (КОНЕЦ), час";
            this.UOD_end.MinimumWidth = 6;
            this.UOD_end.Name = "UOD_end";
            this.UOD_end.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UOD_end.Width = 70;
            // 
            // defect_dlin
            // 
            this.defect_dlin.HeaderText = "Длина дефекта, мм";
            this.defect_dlin.MinimumWidth = 6;
            this.defect_dlin.Name = "defect_dlin";
            this.defect_dlin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.defect_dlin.Width = 55;
            // 
            // defect_shirina
            // 
            this.defect_shirina.HeaderText = "Ширина дефекта, мм";
            this.defect_shirina.MinimumWidth = 6;
            this.defect_shirina.Name = "defect_shirina";
            this.defect_shirina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.defect_shirina.Width = 55;
            // 
            // defect_glubin
            // 
            this.defect_glubin.HeaderText = "Глубина дефекта, мм";
            this.defect_glubin.MinimumWidth = 6;
            this.defect_glubin.Name = "defect_glubin";
            this.defect_glubin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.defect_glubin.Width = 55;
            // 
            // ost_tolsh
            // 
            this.ost_tolsh.HeaderText = "Остаточная толщина дефекта";
            this.ost_tolsh.MinimumWidth = 6;
            this.ost_tolsh.Name = "ost_tolsh";
            this.ost_tolsh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ost_tolsh.Width = 125;
            // 
            // defect_otnosit_glubin
            // 
            this.defect_otnosit_glubin.HeaderText = "Относительная глубина дефекта %";
            this.defect_otnosit_glubin.MinimumWidth = 6;
            this.defect_otnosit_glubin.Name = "defect_otnosit_glubin";
            this.defect_otnosit_glubin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.defect_otnosit_glubin.Width = 90;
            // 
            // recomend
            // 
            this.recomend.HeaderText = "Рекомендации к проведению ДДК в шурфах методами НК";
            this.recomend.MinimumWidth = 6;
            this.recomend.Name = "recomend";
            this.recomend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.recomend.Width = 90;
            // 
            // note
            // 
            this.note.HeaderText = "Примечание";
            this.note.MinimumWidth = 6;
            this.note.Name = "note";
            this.note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.note.Width = 70;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.вставитьЭлементToolStripMenuItem,
            this.редакторСписковToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1153, 24);
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
            // вставитьЭлементToolStripMenuItem
            // 
            this.вставитьЭлементToolStripMenuItem.Name = "вставитьЭлементToolStripMenuItem";
            this.вставитьЭлементToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.вставитьЭлементToolStripMenuItem.Text = "Вставить элемент";
            this.вставитьЭлементToolStripMenuItem.Click += new System.EventHandler(this.вставитьЭлементToolStripMenuItem_Click);
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
            this.del_row.Location = new System.Drawing.Point(128, 25);
            this.del_row.Margin = new System.Windows.Forms.Padding(2);
            this.del_row.Name = "del_row";
            this.del_row.Size = new System.Drawing.Size(115, 24);
            this.del_row.TabIndex = 11;
            this.del_row.Text = "Удалить дефект";
            this.del_row.UseVisualStyleBackColor = true;
            this.del_row.Click += new System.EventHandler(this.del_row_Click);
            // 
            // add_row
            // 
            this.add_row.Location = new System.Drawing.Point(9, 25);
            this.add_row.Margin = new System.Windows.Forms.Padding(2);
            this.add_row.Name = "add_row";
            this.add_row.Size = new System.Drawing.Size(115, 24);
            this.add_row.TabIndex = 10;
            this.add_row.Text = "Добавить дефект";
            this.add_row.UseVisualStyleBackColor = true;
            this.add_row.Click += new System.EventHandler(this.add_row_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(248, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Каскадное удаление";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 531);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.del_row);
            this.Controls.Add(this.add_row);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал неразрушающего контроля основного металла труб и СДТ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_FormClosed);
            this.Load += new System.EventHandler(this.Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_Load);
            this.SizeChanged += new System.EventHandler(this.Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редакторСписковToolStripMenuItem;
        private System.Windows.Forms.Button del_row;
        private System.Windows.Forms.Button add_row;
        private System.Windows.Forms.DataGridViewTextBoxColumn uchastok_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn stenka_tolshina;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn rasp_defect_ot_shva;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOD_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOD_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_dlin;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_shirina;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_glubin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ost_tolsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_otnosit_glubin;
        private System.Windows.Forms.DataGridViewTextBoxColumn recomend;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}