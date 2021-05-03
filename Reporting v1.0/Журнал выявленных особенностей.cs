using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporting_v1._0
{
    public partial class Журнал_выявленных_особенностей : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();

        string mainn = Environment.CurrentDirectory;
        public Журнал_выявленных_особенностей(Manager manager, TextBox tb)
        {
            value = tb;
            _manager = manager;
            InitializeComponent();
            defectTypeFromFile();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            
            if(File.Exists(_manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt"))
                TableInit(_manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt");

            else TableInitWithotFile(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt");

            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        void TableInitWithotFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string inpstr;
                string[] str;
                while ((inpstr = sr.ReadLine()) != null)
                {
                        str = inpstr.Split(';');
                        for (int i = 4; i < str.Length; i++) 
                        {
                            str[i] = null;
                        }
                         str[3] = "Особенность не обнаружена";
                         str[2] = "-";
                        str[0] = value.Text;

                        dataGridView1.Rows.Add(str);
                }

            }
            //int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            textBox1.Text = value.Text;
            //textBox2.Text = (num + 1).ToString();
        }
        void TableI(string path) 
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string inpstr;
                string[] str;

                while ((inpstr = sr.ReadLine()) != null)
                {
                    str = inpstr.Split(';');
                    dataGridView1.Rows.Add(str);
                }
               
            }
        }
        void TableInit(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string inpstr;
                string[] str;
                while ((inpstr = sr.ReadLine()) != null)
                {
                    str = inpstr.Split(';');
                    dataGridView1.Rows.Add(str);
                }
                //int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
                textBox1.Text = value.Text;
                //textBox2.Text = (num + 1).ToString();
                ////textBox4.Text = dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString();
            }
        }
        void defectTypeFromFile()
        {
            List<Category> osobennost_types = new List<Category>();
            using (StreamReader sr = new StreamReader(mainn + "/src/Типы особенностей.txt"))
            {
                _manager.TypesReader(sr, osobennost_types);
            }
            foreach (Category cat in osobennost_types)
            {
               _type.Items.Add(cat.GetContent());
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void Журнал_выявленных_особенностей_Load(object sender, EventArgs e)
        {
            note.Width = 65;
            for (int i = 0; i < dataGridView1.Columns.Count; i++) 
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.Programmatic;
        }
        void ReNumber() 
        {
            try
            {
                int str = 1;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[3, i].Value.ToString() == "Особенность не обнаружена")
                    {
                        dataGridView1[2, i].Value = "-";
                    }
                    else
                    {
                        dataGridView1[2, i].Value = str;
                        str++;
                    }
                }
            }
            catch { };
            
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void Журнал_выявленных_особенностей_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            
               
        }

        private void Журнал_выявленных_особенностей_MinimumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Журнал_выявленных_особенностей_MaximumSizeChanged(object sender, EventArgs e)
        {

            
        }
        void TableSaver()
        {
            string path = _manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt";
            if (!File.Exists(path))
            {
                Save(path);
            }
            else
            {
                DialogResult result = MessageBox.Show("Этот маршрут уже есть, перезаписать?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { Save(path); }
                else { }
            }
        }
        void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {                     
                        sw.Write(dataGridView1[j, i].Value + ";");
                    }
                    sw.WriteLine();
                }
            }
        }
        private void add_row_Click(object sender, EventArgs e)
        {
            #region oldcontent
            //bool save = true;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if ((textBox4.Text == dataGridView1[2, i].Value.ToString()) && (textBox2.Text == dataGridView1[1, i].Value.ToString()))
            //    {
            //        save = false;
            //        try
            //        {
            //            dataGridView1[0, i].Value = textBox1.Text;
            //            dataGridView1[1, i].Value = textBox2.Text;
            //            dataGridView1[2, i].Value = textBox4.Text;
            //            dataGridView1[3, i].Value = _type.SelectedItem;
            //            dataGridView1[4, i].Value = textBox3.Text;
            //            dataGridView1[5, i].Value = textBox5.Text;
            //            dataGridView1[6, i].Value = textBox6.Text;
            //            dataGridView1[7, i].Value = textBox10.Text;
            //            dataGridView1[8, i].Value = textBox7.Text;
            //            dataGridView1[9, i].Value = textBox8.Text;
            //            dataGridView1[10, i].Value = textBox11.Text;
            //            dataGridView1[11, i].Value = textBox12.Text;
            //            dataGridView1[12, i].Value = textBox9.Text;

            //        }
            //        catch { }

            //    }
            //}

            //if (save) 
            //{
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if ((textBox2.Text == dataGridView1[1, i].Value.ToString()) && ((Convert.ToInt32(textBox4.Text) - Convert.ToInt32(dataGridView1[2, i].Value.ToString())) == 1))
            //        {
            //            dataGridView1.Rows.Insert(i + 1, textBox1.Text, textBox2.Text, textBox4.Text, _type.SelectedItem,
            //            textBox3.Text, textBox5.Text, textBox6.Text, textBox10.Text, textBox7.Text, textBox8.Text, textBox11.Text, textBox12.Text, textBox9.Text);
            //        }
            //    }


            //}


            //string path = _manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt";
            //if (!File.Exists(path))
            //{
            //    Save(path);
            //}
            //else
            //{
            //    Save(path);
            //}

            //textBox4.Text = null;
            //_type.SelectedItem = null;
            //textBox3.Text = null;
            //textBox5.Text = null;
            //textBox6.Text = null;
            //textBox10.Text = null;
            //textBox7.Text = null;
            //textBox8.Text = null;
            //textBox11.Text = null;
            //textBox12.Text = null;
            //textBox9.Text = null;



            //ReNumber();
            #endregion

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int ro = 0; ro < dataGridView1.Rows.Count; ro++)
            {
                try 
                {
                    if (Convert.ToInt32(textBox2.Text) == Convert.ToInt32(dataGridView1[1, ro].Value.ToString()))// 
                    {
                        rows.Add(dataGridView1.Rows[ro]);
                    }
                } 
                catch { MessageBox.Show("Не хватает данных для добавления!"); }
                
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(textBox2.Text) == Convert.ToInt32(dataGridView1[1, i].Value.ToString()))
                {
                    int def_num = 0;

                    try
                    {
                        if (int.TryParse(dataGridView1[2, i].Value.ToString(), out def_num))
                        {
                            dataGridView1.Rows.Insert(i + rows.Count, textBox1.Text, textBox2.Text, textBox4.Text,
                                                                      _type.SelectedItem, textBox3.Text, textBox5.Text, textBox6.Text,
                                                                      textBox10.Text, textBox7.Text, textBox8.Text, textBox11.Text,
                                                                      textBox12.Text, textBox9.Text);
                            i = i + rows.Count;
                            ReNumber();
                        }
                        else
                        {
                            if (dataGridView1[2, i].Value.ToString() == null)
                            {
                                MessageBox.Show("Необходимо внести значение вручную!");
                                break;
                            }
                            else
                            {
                                dataGridView1[0, i].Value = textBox1.Text;
                                dataGridView1[1, i].Value = textBox2.Text;
                                dataGridView1[2, i].Value = textBox4.Text;
                                dataGridView1[3, i].Value = _type.SelectedItem;
                                dataGridView1[4, i].Value = textBox3.Text;
                                dataGridView1[5, i].Value = textBox5.Text;
                                dataGridView1[6, i].Value = textBox6.Text;
                                dataGridView1[7, i].Value = textBox10.Text;
                                dataGridView1[8, i].Value = textBox7.Text;
                                dataGridView1[9, i].Value = textBox8.Text;
                                dataGridView1[10, i].Value = textBox11.Text;
                                dataGridView1[11, i].Value = textBox12.Text;
                                dataGridView1[12, i].Value = textBox9.Text;

                                ReNumber();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Значение отсутствует!");
                        dataGridView1.Rows[i].Selected = true;
                    }

                }
            }
        }

        private void del_row_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Элемент будет удалён!", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    int index = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.RemoveAt(index);
                }
                ReNumber();
            }
            else { }

        }
       
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TableSaver();
            }
            catch (Exception err)
            {
                MessageBox.Show(Convert.ToString(err));
                MessageBox.Show("Неверно указан путь!");
            }
        }

        private void вставитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            using (StreamWriter sw = new StreamWriter(_manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt"))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {
                        sw.Write(dataGridView1[j, i].Value + ";");


                    }
                    if (i == index)
                    {

                        sw.WriteLine();
                    }
                    sw.WriteLine();
                }
            }


            dataGridView1.Rows.Clear();
            TableI(_manager.folderName + "/ВТО/Маршрут - "+ value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt");

            dataGridView1[0, index+1].Value = value.Text;
            dataGridView1[1, index+1].Value = dataGridView1[1, index].Value;
            //dataGridView1[2, index + 1].Value = "-";
            //dataGridView1[3, index + 1].Value = "Особенность не обнаружена";

            string path = _manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt";
            if (!File.Exists(path))
            {
                Save(path);
            }
            else
            {
                Save(path);
            }
        }

        private void редакторСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.RedactorOpened = true;
            Редактор re = new Редактор(_manager);
            re.Show();
        }

        private void Журнал_выявленных_особенностей_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog table = new OpenFileDialog();
            if (table.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                TableInit(table.FileName);
                _manager.JournalOpened = false;
            }

        }

        private void автозаменаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() == "Особенность не обнаружена ")
            //    {
            //        dataGridView1[2, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[4, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[5, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[6, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[7, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[8, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[9, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[10, dataGridView1.CurrentRow.Index].Value = "-";
            //        dataGridView1[11, dataGridView1.CurrentRow.Index].Value = "-";
            //        osobennost_flag = true;
            //    }
            //    else
            //    {
            //        if (osobennost_flag)
            //        {
            //            osobennost_flag = false;
            //            dataGridView1[2, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[4, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[5, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[6, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[7, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[8, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[9, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[10, dataGridView1.CurrentRow.Index].Value = "";
            //            dataGridView1[11, dataGridView1.CurrentRow.Index].Value = "";
            //        }
            //        else { }

            //    }   
            //}
            //catch { }
            
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_manager.RedactorOpened) 
            {
                defectTypeFromFile();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1[0, dataGridView1.CurrentRow.Index].Value = textBox1.Text;
                dataGridView1[1, dataGridView1.CurrentRow.Index].Value = textBox2.Text;
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value = textBox4.Text;
                dataGridView1[3, dataGridView1.CurrentRow.Index].Value = _type.SelectedItem;
                dataGridView1[4, dataGridView1.CurrentRow.Index].Value = textBox3.Text;
                dataGridView1[5, dataGridView1.CurrentRow.Index].Value = textBox5.Text;
                dataGridView1[6, dataGridView1.CurrentRow.Index].Value = textBox6.Text;
                dataGridView1[7, dataGridView1.CurrentRow.Index].Value = textBox10.Text;
                dataGridView1[8, dataGridView1.CurrentRow.Index].Value = textBox7.Text;
                dataGridView1[9, dataGridView1.CurrentRow.Index].Value = textBox8.Text;
                dataGridView1[10, dataGridView1.CurrentRow.Index].Value = textBox11.Text;
                dataGridView1[11, dataGridView1.CurrentRow.Index].Value = textBox12.Text;
                dataGridView1[12, dataGridView1.CurrentRow.Index].Value = textBox9.Text;

            }
            catch { }

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if ((textBox4.Text == dataGridView1[2, i].Value.ToString()) && (textBox2.Text == dataGridView1[1, i].Value.ToString()))
            //    {
                   

            //    }
            //}
            

            //int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            textBox1.Text = value.Text;
            //textBox2.Text = (num + 1).ToString();
            ReNumber();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox4.Text = null;
            _type.SelectedItem = null;
            textBox3.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox10.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox9.Text = null;

            int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            textBox1.Text = value.Text;
            textBox2.Text = (num + 1).ToString();
        }

        private void Журнал_выявленных_особенностей_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(_manager.folderName + "/backup.txt"))
            {
                File.Delete(_manager.folderName + "/backup.txt");
            }
            try
            {
                string path = _manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt";
                if (!File.Exists(path))
                {
                    Save(path);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Сохранить перед закрытием?", "", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes) { Save(path); }
                    else 
                    {
                        if (result == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неверно указан путь!");
            }
            value.ReadOnly = false;
            value.BackColor = Color.White;
            _manager.JournalOpened = false;
        }

        private void Журнал_выявленных_особенностей_SizeChanged(object sender, EventArgs e)
        {
            note.Width = dataGridView1.Width-1034;
        }

        private void Журнал_выявленных_особенностей_StyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                InputBox.InputBox inputBox = new InputBox.InputBox("Введите критерий отбора!");
                string result = inputBox.GetString();
                if (result == "")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Height = 24;
                    }

                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        try
                        {
                            if (dataGridView1[e.ColumnIndex, i].Value.ToString() == result)
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[i].Height = 2;
                            }
                        }
                        catch { }


                    }
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox4.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                try { _type.SelectedItem = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }

                try 
                {
                    textBox3.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox5.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox6.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox10.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox7.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox8.Text = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox11.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox12.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString();
                    textBox9.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString();
                } 
                catch { }
                
            }
            catch { }

            if (!File.Exists(_manager.folderName + "/backup.txt"))
            {
                using (File.Create(_manager.folderName + "/backup.txt")) ;
            }
            using (StreamWriter sw = new StreamWriter(_manager.folderName + "/backup.txt"))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {
                        sw.Write(dataGridView1[j, i].Value + ";");
                    }
                    sw.WriteLine();
                }
            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (textBox3.Text.Contains('.')) 
                {
                    string[] dt = textBox3.Text.Split('.');
                    textBox3.Text = dt[0] + "," + dt[1];
                    textBox3.SelectionStart = textBox3.Text.Length;
                }

                if (textBox5.Text.Contains('.'))
                {
                    string[] dt = textBox5.Text.Split('.');
                    textBox5.Text = dt[0] + "," + dt[1];
                    textBox5.SelectionStart = textBox5.Text.Length;
                }
                textBox7.Text = Math.Round((Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox3.Text))*1000,1).ToString();

            }   
            catch { }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            string[] elements = File.ReadAllLines(_manager.folderName+ @"/Журнал контроля/Маршрут - "+value.Text+".txt");

            for (int elem = 0; elem < elements.Length; elem++) 
            {
                string[] element = elements[elem].Split(';');

                if (element[1] == textBox2.Text) 
                {
                    try
                    {
                        if (textBox6.Text.Contains('.'))
                        {
                            string[] dt = textBox6.Text.Split('.');
                            textBox6.Text = dt[0] + "," + dt[1];
                            textBox6.SelectionStart = textBox6.Text.Length;
                        }

                        if (textBox10.Text.Contains('.'))
                        {
                            string[] dt = textBox10.Text.Split('.');
                            textBox10.Text = dt[0] + "," + dt[1];
                            textBox10.SelectionStart = textBox10.Text.Length;
                        }

                        
                    }
                    catch { }

                    try 
                    {
                        double d = (Convert.ToDouble(element[3]) * 100)/* - (Convert.ToDouble(element[6]) / 10)*/;
                        double n = Convert.ToDouble(textBox10.Text) - Convert.ToDouble(textBox6.Text);

                        double L = (Math.PI * (d / 2) * n) / 180;


                        L = Math.Round(L, 1) * 10;

                        textBox8.Clear();
                        textBox8.Text = L.ToString();
                    }
                    catch { }
                }
              
            }
           
        }

        private void textBox10_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void _type_TextChanged(object sender, EventArgs e)
        {
            if (_type.SelectedItem.ToString().Contains("Особенность не обнаружена"))
            {
                try
                {
                    textBox3.Text = "-";
                    textBox5.Text = "-";
                    textBox6.Text = "-";
                    textBox10.Text = "-";
                    textBox7.Text = "-";
                    textBox8.Text = "-";
                    textBox11.Text = "-";
                    textBox12.Text = "-";
                    textBox9.Text = "-";
                    textBox4.Text = "-";
                }
                catch { }
            }
            else 
            {
                #region must_ifs
                if (textBox3.Text == "-")
                {
                    textBox3.Text = "";
                }

                if (textBox5.Text == "-")
                {
                    textBox5.Text = "";
                }

                if (textBox6.Text == "-")
                {
                    textBox6.Text = "";
                }

                if (textBox10.Text == "-")
                {
                    textBox10.Text = "";
                }

                if (textBox7.Text == "-")
                {
                    textBox7.Text = "";
                }

                if (textBox8.Text == "-")
                {
                    textBox8.Text = "";
                }

                if (textBox11.Text == "-")
                {
                    textBox11.Text = "";
                }

                if (textBox12.Text == "-")
                {
                    textBox12.Text = "";
                }

                if (textBox9.Text == "-")
                {
                    textBox9.Text = "";
                }

                if (textBox4.Text == "-")
                {
                    textBox4.Text = "";
                }
                #endregion
            }

        }

        private void _type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void отменитьПоследнееДействиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(_manager.folderName + "/backup.txt"))
            {
                try
                {
                    int i = 0;
                    while (i < dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }

                    using (StreamReader sr = new StreamReader(_manager.folderName + "/backup.txt"))
                    {
                        string inpstr;
                        string[] str;
                        while ((inpstr = sr.ReadLine()) != null)
                        {
                            str = inpstr.Split(';');
                            str[0] = value.Text;
                            dataGridView1.Rows.Add(str);
                        }
                    }

                    File.Delete(_manager.folderName + "/backup.txt");
                }
                catch { }
            }


            

            
        }
        public static void OnDataGridViewPaste(object grid, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                PasteTSV((DataGridView)grid);
            }
        }
        public static void PasteTSV(DataGridView grid)
        {
            char[] rowSplitter = { '\r', '\n' };
            char[] columnSplitter = { '\t' };

            //Get the text from clipboard
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

            //Split it into lines
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

            //Get the row and column of selected cell in grid
            int r = grid.SelectedCells[0].RowIndex;
            int c = grid.SelectedCells[0].ColumnIndex;

            //Add rows into grid to fit clipboard lines
            if (grid.Rows.Count < (r + rowsInClipboard.Length))
            {
                grid.Rows.Add(r + rowsInClipboard.Length - grid.Rows.Count);
            }

            //Loop through the lines, split them into cells and place the values in the corresponding cell.
            for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
            {
                //Split row into cell values
                string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);

                //Cycle through cell values
                for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                {

                    //Assign cell value, only if it within columns of the grid
                    if (grid.ColumnCount - 1 >= c + iCol)
                    {
                        DataGridViewCell cell = grid.Rows[r + iRow].Cells[c + iCol];

                        if (!cell.ReadOnly)
                        {
                            cell.Value = valuesInRow[iCol];
                        }
                    }
                }
            }
        }
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            OnDataGridViewPaste(sender, e);
        }
    }
}
