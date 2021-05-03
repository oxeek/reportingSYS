namespace Reporting_v1._0
{
    partial class Конвертер_журналов
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CHBready = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.elements = new System.Windows.Forms.CheckBox();
            this.vto_export = new System.Windows.Forms.CheckBox();
            this.uzk_export = new System.Windows.Forms.CheckBox();
            this.vik_export = new System.Windows.Forms.CheckBox();
            this.file_path = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CHBready);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.file_path);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(9, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(525, 156);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор файла для конвертации";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CHBready
            // 
            this.CHBready.AutoSize = true;
            this.CHBready.Checked = true;
            this.CHBready.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHBready.Location = new System.Drawing.Point(311, 60);
            this.CHBready.Margin = new System.Windows.Forms.Padding(2);
            this.CHBready.Name = "CHBready";
            this.CHBready.Size = new System.Drawing.Size(78, 17);
            this.CHBready.TabIndex = 9;
            this.CHBready.Text = "ЧБ режим";
            this.CHBready.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(415, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 18);
            this.label2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(323, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Конвертация";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 113);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 32);
            this.button3.TabIndex = 10;
            this.button3.Text = "Завершение Excel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.elements);
            this.groupBox2.Controls.Add(this.vto_export);
            this.groupBox2.Controls.Add(this.uzk_export);
            this.groupBox2.Controls.Add(this.vik_export);
            this.groupBox2.Location = new System.Drawing.Point(133, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(174, 105);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Журналы для конвертации";
            // 
            // elements
            // 
            this.elements.AutoSize = true;
            this.elements.Location = new System.Drawing.Point(4, 19);
            this.elements.Margin = new System.Windows.Forms.Padding(2);
            this.elements.Name = "elements";
            this.elements.Size = new System.Drawing.Size(124, 17);
            this.elements.TabIndex = 8;
            this.elements.Text = "Журнал элементов";
            this.elements.UseVisualStyleBackColor = true;
            // 
            // vto_export
            // 
            this.vto_export.AutoSize = true;
            this.vto_export.Location = new System.Drawing.Point(4, 40);
            this.vto_export.Margin = new System.Windows.Forms.Padding(2);
            this.vto_export.Name = "vto_export";
            this.vto_export.Size = new System.Drawing.Size(48, 17);
            this.vto_export.TabIndex = 5;
            this.vto_export.Text = "ВТО";
            this.vto_export.UseVisualStyleBackColor = true;
            // 
            // uzk_export
            // 
            this.uzk_export.AutoSize = true;
            this.uzk_export.Location = new System.Drawing.Point(4, 85);
            this.uzk_export.Margin = new System.Windows.Forms.Padding(2);
            this.uzk_export.Name = "uzk_export";
            this.uzk_export.Size = new System.Drawing.Size(48, 17);
            this.uzk_export.TabIndex = 7;
            this.uzk_export.Text = "УЗК";
            this.uzk_export.UseVisualStyleBackColor = true;
            // 
            // vik_export
            // 
            this.vik_export.AutoSize = true;
            this.vik_export.Location = new System.Drawing.Point(4, 62);
            this.vik_export.Margin = new System.Windows.Forms.Padding(2);
            this.vik_export.Name = "vik_export";
            this.vik_export.Size = new System.Drawing.Size(48, 17);
            this.vik_export.TabIndex = 6;
            this.vik_export.Text = "ВИК";
            this.vik_export.UseVisualStyleBackColor = true;
            // 
            // file_path
            // 
            this.file_path.AutoSize = true;
            this.file_path.Location = new System.Drawing.Point(9, 23);
            this.file_path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.file_path.Name = "file_path";
            this.file_path.Size = new System.Drawing.Size(0, 13);
            this.file_path.TabIndex = 4;
            this.file_path.MouseClick += new System.Windows.Forms.MouseEventHandler(this.file_path_MouseClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 41);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Выбрать файл ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 77);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Конвертировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(267, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "Система формирования отчётов";
            this.label5.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label26.Location = new System.Drawing.Point(368, 5);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(166, 13);
            this.label26.TabIndex = 63;
            this.label26.Text = "Система формирования отчётов";
            this.label26.Visible = false;
            // 
            // Конвертер_журналов
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 184);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Конвертер_журналов";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер журналов";
            this.Load += new System.EventHandler(this.Конвертер_журналов_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel file_path;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox vto_export;
        private System.Windows.Forms.CheckBox uzk_export;
        private System.Windows.Forms.CheckBox vik_export;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox elements;
        private System.Windows.Forms.CheckBox CHBready;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label26;
    }
}