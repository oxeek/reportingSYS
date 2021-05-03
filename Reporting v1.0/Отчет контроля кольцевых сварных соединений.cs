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
    public partial class Отчет_контроля_кольцевых_сварных_соединений : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();

        string mainn = Environment.CurrentDirectory;
        public Отчет_контроля_кольцевых_сварных_соединений(Manager manager, TextBox tb)
        {
            value = tb;
            _manager = manager;
            InitializeComponent();
            defectTypeFromFile();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (File.Exists(_manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt"))
            {
                TableInit(_manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt");
            }
            else TableInitWithotFile(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt");
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
                    for (int i = 2; i < str.Length; i++)
                    {
                        str[i] = "-";
                    }
                    
                    dataGridView1.Rows.Add(str);
                }

            }
            //int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            //textBox1.Text = value.Text;
            //textBox2.Text = (num + 1).ToString();

            ReNumerate();
            //int numerate = Convert.ToInt32(dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString());
            //textBox4.Text = (numerate + 2).ToString();
            //textBox5.Text = (numerate + 3).ToString();

            Save(_manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt");
           
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
            }
            //int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            textBox1.Text = value.Text;
            //textBox2.Text = (num + 1).ToString();

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[2, i].Value.ToString() == null)
                    {
                        ReNumerate();
                    }
                }

                //int numerate = Convert.ToInt32(dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString());
                //textBox4.Text = (numerate + 2).ToString();
                //textBox5.Text = (numerate + 3).ToString();
            }
            catch { }
            
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

        void ReNumerate() 
        {
            int num = 1;
            for (int i = 0; i < dataGridView1.Rows.Count;i++) 
            {
                dataGridView1[2, i].Value = num;
                dataGridView1[3, i].Value = num + 1;
                num += 1;

                dataGridView1[4, i].Value = "-";
                dataGridView1[5, i].Value = "Дефекты не обнаружены";
            }  
        }
        void defectTypeFromFile() 
        {
            List<Category> defect_types = new List<Category>();
            using (StreamReader sr = new StreamReader(mainn + "/src/Типы дефектов.txt")) 
            {
                _manager.TypesReader(sr,defect_types);
            }
            foreach (Category cat in defect_types) 
            {
                _type.Items.Add(cat.GetContent());
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Отчет_контроля_кольцевых_сварных_соединений_Load(object sender, EventArgs e)
        {
            note.Width = 74;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.Programmatic;

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void Отчет_контроля_кольцевых_сварных_соединений_MinimumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        void ReNumber()
        {
            int str = 1;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[5, i].Value.ToString() == "Дефекты не обнаружены")
                {
                    dataGridView1[4, i].Value = "-";
                }
                else
                {
                    dataGridView1[4, i].Value = str;
                    str++;
                }
            }
        }
        private void add_row_Click(object sender, EventArgs e)
        {
            #region oldcontent
            //bool save = true;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    try 
            //    {
            //        if ((textBox2.Text == dataGridView1[1, i].Value.ToString()) && ((Convert.ToInt32(textBox3.Text) - Convert.ToInt32(dataGridView1[4, i].Value.ToString())) == 1))
            //        {
            //            save = false;
            //            dataGridView1.Rows.Insert(i + 1, textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox3.Text, _type.SelectedItem,
            //            textBox6.Text, textBox10.Text, textBox7.Text, textBox8.Text, textBox11.Text,textBox12,textBox13, textBox9.Text);

            //        }
            //    }
            //    catch { }

            //}
            //if (save) 
            //{
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if ((textBox4.Text == dataGridView1[2, i].Value.ToString()) && (textBox2.Text == dataGridView1[1, i].Value.ToString()))
            //        {
            //            try
            //            {
            //                dataGridView1[0, i].Value = textBox1.Text;
            //                dataGridView1[1, i].Value = textBox2.Text;
            //                dataGridView1[2, i].Value = textBox4.Text;
            //                dataGridView1[3, i].Value = textBox5.Text;
            //                dataGridView1[4, i].Value = textBox3.Text;
            //                dataGridView1[5, i].Value = _type.SelectedItem;
            //                dataGridView1[6, i].Value = textBox6.Text;
            //                dataGridView1[7, i].Value = textBox10.Text;
            //                dataGridView1[8, i].Value = textBox7.Text;
            //                dataGridView1[9, i].Value = textBox8.Text;
            //                dataGridView1[10, i].Value = textBox11.Text;
            //                dataGridView1[11, i].Value = textBox12.Text;
            //                dataGridView1[12, i].Value = textBox13.Text;
            //                dataGridView1[13, i].Value = textBox9.Text;

            //            }
            //            catch { }

            //        }
            //    }
            //}


            //string path = _manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt";
            //if (!File.Exists(path))
            //{
            //    Save(path);
            //}
            //else
            //{
            //    Save(path);
            //}


            //textBox4.Text = null;
            //textBox5.Text = null;
            //textBox3.Text = null;
            //_type.SelectedItem = null;
            //textBox6.Text = null;
            //textBox10.Text = null;
            //textBox7.Text = null;
            //textBox8.Text = null;
            //textBox11.Text = null;
            //textBox12.Text = null;
            //textBox13.Text = null;
            //textBox9.Text = null;

            //int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            //textBox1.Text = value.Text;
            //textBox2.Text = (num + 1).ToString();


            //ReNumber();
            #endregion
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int ro = 0; ro < dataGridView1.Rows.Count; ro++)
            {
                try
                {
                    if (Convert.ToInt32(textBox4.Text) == Convert.ToInt32(dataGridView1[2, ro].Value.ToString()))// 
                    {
                        rows.Add(dataGridView1.Rows[ro]);
                    }
                }
                catch
                {

                }

                
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(textBox4.Text) == Convert.ToInt32(dataGridView1[2, i].Value.ToString()))
                {
                    int def_num = 0;

                    try
                    {
                        if (int.TryParse(dataGridView1[4, i].Value.ToString(), out def_num))
                        {
                            dataGridView1.Rows.Insert(i + rows.Count, textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text,
                                                                      textBox3.Text, _type.SelectedItem, textBox6.Text, textBox10.Text,
                                                                      textBox7.Text, textBox8.Text, textBox11.Text, textBox12.Text,
                                                                      textBox13.Text, textBox9.Text);
                            i = i + rows.Count;
                            ReNumber();
                        }
                        else
                        {
                            if (dataGridView1[4, i].Value.ToString() == null)
                            {
                                MessageBox.Show("Необходимо внести значение вручную!");
                                break;
                            }
                            else
                            {
                                dataGridView1[0, i].Value = textBox1.Text;
                                dataGridView1[1, i].Value = textBox2.Text;
                                dataGridView1[2, i].Value = textBox4.Text;
                                dataGridView1[3, i].Value = textBox5.Text;
                                dataGridView1[4, i].Value = textBox3.Text;
                                dataGridView1[5, i].Value = _type.SelectedItem;
                                dataGridView1[6, i].Value = textBox6.Text;
                                dataGridView1[7, i].Value = textBox10.Text;
                                dataGridView1[8, i].Value = textBox7.Text;
                                dataGridView1[9, i].Value = textBox8.Text;
                                dataGridView1[10, i].Value = textBox11.Text;
                                dataGridView1[11, i].Value = textBox12.Text;
                                dataGridView1[12, i].Value = textBox13.Text;
                                dataGridView1[13, i].Value = textBox9.Text;

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

        private void вставитьЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt"))
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
            TableI(_manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt");

            dataGridView1[0, index + 1].Value = value.Text;
            dataGridView1[1, index + 1].Value = dataGridView1[1, index].Value;
            //dataGridView1[2, index + 1].Value = dataGridView1[2, index].Value;
            //dataGridView1[3, index + 1].Value = dataGridView1[3, index].Value;
            //dataGridView1[4, index + 1].Value = "-";
            //dataGridView1[5, index + 1].Value = "Дефекты не обнаружены";



            string path = _manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt";
            if (!File.Exists(path))
            {
                Save(path);
            }
            else
            {
                Save(path);
            }
        }

        private void Отчет_контроля_кольцевых_сварных_соединений_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(_manager.folderName + "/backup.txt"))
            {
                File.Delete(_manager.folderName + "/backup.txt");
            }
            try
            {
                string path = _manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt";
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
            catch (Exception err)
            {
                MessageBox.Show(Convert.ToString(err));
                MessageBox.Show("Неверно указан путь!");
            }
            value.ReadOnly = false;
            value.BackColor = Color.White;
            _manager.JournalOpened = false;
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            #region oldcontent
            //textBox6.Text = null;
            //textBox10.Text = null;
            //textBox7.Text = null;
            //textBox8.Text = null;
            //textBox11.Text = null;
            //textBox12.Text = null;
            //textBox13.Text = null;
            //textBox9.Text = null;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if ((textBox2.Text == dataGridView1[1, i].Value.ToString()) && (textBox3.Text == dataGridView1[4, i].Value.ToString()))
            //    {
            //        try
            //        {
            //            textBox4.Text = dataGridView1[2,i].Value.ToString();
            //            textBox5.Text = dataGridView1[3, i].Value.ToString();
            //            textBox3.Text = dataGridView1[4, i].Value.ToString();
            //            _type.SelectedItem = dataGridView1[5, i].Value.ToString();
            //            textBox6.Text = dataGridView1[6, i].Value.ToString();
            //            textBox10.Text = dataGridView1[7, i].Value.ToString();
            //            textBox7.Text = dataGridView1[8, i].Value.ToString();
            //            textBox8.Text = dataGridView1[9, i].Value.ToString();
            //            textBox11.Text = dataGridView1[10, i].Value.ToString();
            //            textBox12.Text = dataGridView1[11, i].Value.ToString();
            //            textBox13.Text = dataGridView1[12, i].Value.ToString();
            //            textBox9.Text = dataGridView1[13, i].Value.ToString();

            //        }
            //        catch { }

            //    }
            //}
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1[0, dataGridView1.CurrentRow.Index].Value = textBox1.Text;
                dataGridView1[1, dataGridView1.CurrentRow.Index].Value = textBox2.Text;
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value = textBox4.Text;
                dataGridView1[3, dataGridView1.CurrentRow.Index].Value = textBox5.Text;
                dataGridView1[4, dataGridView1.CurrentRow.Index].Value = textBox3.Text;
                dataGridView1[5, dataGridView1.CurrentRow.Index].Value = _type.SelectedItem;
                dataGridView1[6, dataGridView1.CurrentRow.Index].Value = textBox6.Text;
                dataGridView1[7, dataGridView1.CurrentRow.Index].Value = textBox10.Text;
                dataGridView1[8, dataGridView1.CurrentRow.Index].Value = textBox7.Text;
                dataGridView1[9, dataGridView1.CurrentRow.Index].Value = textBox8.Text;
                dataGridView1[10, dataGridView1.CurrentRow.Index].Value = textBox11.Text;
                dataGridView1[11, dataGridView1.CurrentRow.Index].Value = textBox12.Text;
                dataGridView1[12, dataGridView1.CurrentRow.Index].Value = textBox13.Text;
                dataGridView1[13, dataGridView1.CurrentRow.Index].Value = textBox9.Text;

            }
            catch { }

            ReNumber();

            #region oldcontent
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if ((textBox2.Text == dataGridView1[1, i].Value.ToString()) && (textBox3.Text == dataGridView1[4, i].Value.ToString()))
            //    {
                    

            //    }
            //}
            
            #endregion


        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox3.Text = null;
            _type.SelectedItem = null;
            textBox6.Text = null;
            textBox10.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            textBox9.Text = null;

            //int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            //textBox1.Text = value.Text;
           // textBox2.Text = (num + 1).ToString();

             // int numerate = Convert.ToInt32(dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString());
            //textBox4.Text = (numerate + 2).ToString();
            //extBox5.Text = (numerate + 3).ToString();
        }
        void TableSaver()
        {
            string path = _manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt";
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

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog table = new OpenFileDialog();
            if (table.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                TableInit(table.FileName);
            }

        }

        private void редакторСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.RedactorOpened = true;
            Редактор re = new Редактор(_manager);
            re.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        bool wfix = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_manager.RedactorOpened)
            {
                defectTypeFromFile();
            }

            if (visible.Checked)
            {
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                if (!wfix) 
                {
                    groupBox1.Width = groupBox1.Width - 153;
                }
                wfix = true;
            }
            else 
            {
                wfix = false;
                groupBox1.Width = 1096;

                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[3].Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
        }

        private void Отчет_контроля_кольцевых_сварных_соединений_SizeChanged(object sender, EventArgs e)
        {
            note.Width = textBox9.Width + 3;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            InputBox.InputBox inputBox = new InputBox.InputBox("Введите критерий отбора!");
            string result = inputBox.GetString();

            if (result.Contains('.'))
            {
                string[] dt = result.Split('.');
                result = dt[0] + "," + dt[1];
            }

            if (result == "")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 24;
                }

            }
            else
            {
                if (result.Contains("<") || result.Contains(">") || result.Contains("="))
                {
                    if (result.Contains("<"))
                    {
                        string[] number = result.Split('<');
                        double num = Convert.ToDouble(number[1]);

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            //MessageBox.Show("!");
                            if (dataGridView1[e.ColumnIndex, i].Value.ToString().Contains("-"))
                            {
                                dataGridView1.Rows[i].Height = 2;
                            }
                            string num1 = dataGridView1[e.ColumnIndex, i].Value.ToString();

                            if (num1.Contains('.'))
                            {
                                string[] dt = num1.Split('.');
                                num1 = dt[0] + "," + dt[1];
                            }
                            try
                            {

                                if (Convert.ToDouble(num1) > num)
                                {
                                    dataGridView1.Rows[i].Height = 2;
                                }
                            }
                            catch { }

                        }

                    }

                    if (result.Contains(">"))
                    {
                        string[] number = result.Split('>');
                        double num = Convert.ToDouble(number[1]);

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1[e.ColumnIndex, i].Value.ToString().Contains("-"))
                            {
                                dataGridView1.Rows[i].Height = 2;
                            }
                            //MessageBox.Show("!");
                            string num1 = dataGridView1[e.ColumnIndex, i].Value.ToString();

                            if (num1.Contains('.'))
                            {
                                string[] dt = num1.Split('.');
                                num1 = dt[0] + "," + dt[1];
                            }
                            try
                            {

                                if (Convert.ToDouble(num1) < num)
                                {

                                    dataGridView1.Rows[i].Height = 2;
                                }
                            }
                            catch { }

                        }

                    }

                    if (result.Contains("="))
                    {
                        string[] number = result.Split('=');
                        double num = Convert.ToDouble(number[1]);

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1[e.ColumnIndex, i].Value.ToString().Contains("-"))
                            {
                                dataGridView1.Rows[i].Height = 2;
                            }
                            //MessageBox.Show("!");
                            string num1 = dataGridView1[e.ColumnIndex, i].Value.ToString();

                            if (num1.Contains('.'))
                            {
                                string[] dt = num1.Split('.');
                                num1 = dt[0] + "," + dt[1];
                            }
                            try
                            {

                                if (Convert.ToDouble(num1) != num)
                                {

                                    dataGridView1.Rows[i].Height = 2;
                                }
                            }
                            catch { }

                        }

                    }

                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        try
                        {
                            if (dataGridView1[e.ColumnIndex, i].Value.ToString().Contains(result))
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
            //if (e.ColumnIndex == 5)
            //{
            //    InputBox.InputBox inputBox = new InputBox.InputBox("Введите критерий отбора!");
            //    string result = inputBox.GetString();
            //    if (result == "")
            //    {
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {
            //            dataGridView1.Rows[i].Height = 24;
            //        }

            //    }
            //    else
            //    {
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {
            //            try
            //            {
            //                if (dataGridView1[e.ColumnIndex, i].Value.ToString() == result)
            //                {

            //                }
            //                else
            //                {
            //                    dataGridView1.Rows[i].Height = 2;
            //                }
            //            }
            //            catch { }


            //        }
            //    }
            //}
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                textBox1.Text = value.Text;
                textBox2.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox4.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox5.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox3.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                try { _type.SelectedItem = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
                textBox6.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox10.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox7.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox8.Text = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox11.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox12.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox13.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox9.Text = dataGridView1[13, dataGridView1.CurrentRow.Index].Value.ToString();

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

        private void _type_TextChanged(object sender, EventArgs e)
        {
            if (_type.SelectedItem.ToString().Contains("Дефекты не обнаружены"))
            {
                try
                {
                    textBox3.Text = "-";
                    textBox6.Text = "-";
                    textBox10.Text = "-";
                    textBox7.Text = "-";
                    textBox8.Text = "-";
                    textBox11.Text = "-";
                    textBox12.Text = "-";
                    textBox13.Text = "-";
                    textBox9.Text = "-";
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

                if (textBox13.Text == "-")
                {
                    textBox13.Text = "";
                }
                #endregion
            }
        }

        private void _type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string[] elements = File.ReadAllLines(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt");

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

                        textBox7.Clear();
                        textBox7.Text = L.ToString();
                    }
                    catch { }
                }

            }
        }

        private void visible_CheckedChanged(object sender, EventArgs e)
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string path = _manager.folderName + @"/ВИК/Маршрут - " + value.Text + @"/Маршрут - " + value.Text + ".txt";
                Save(path);
            }
            catch
            {
            }

            try
            {
                textBox2.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox4.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox5.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox3.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                try { _type.SelectedItem = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
                textBox6.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox10.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox7.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox8.Text = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox11.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox12.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox13.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox9.Text = dataGridView1[13, dataGridView1.CurrentRow.Index].Value.ToString();

            }
            catch { }

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Отчет_контроля_кольцевых_сварных_соединений_FormClosed(object sender, FormClosedEventArgs e)
        {
            _manager.JournalOpened = false;
        }
    }
}
