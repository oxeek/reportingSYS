using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Reporting_v1._0
{
    public partial class Диагностируемый_участок : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();

        string mainn = Environment.CurrentDirectory;
        public Диагностируемый_участок(Manager manager, TextBox tb)
        {

            value = tb;
            _manager = manager;
            InitializeComponent();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            elementTypeFromFile();
            contructionFromFile();
            diametersFromFile();
            plotFromFile();

            if (File.Exists(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt"))
            {
                TableInit(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt");
            }
            
            

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                
        }
        void TableSaver() 
        {
            string path = _manager.folderName + "/Журнал контроля/" +"Маршрут - "+value.Text+".txt";
            if (!File.Exists(path))
            {
                Save(path);
            }
            else 
            {
                DialogResult result = MessageBox.Show("Этот маршрут уже есть, перезаписать?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { Save(path); }
                else{}
            }
        }

        void TableSaverWithoutNotification() 
        {
            string path = _manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt";
            Save(path);
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
        void TableInit(string path) 
        {

            using (StreamReader sr = new StreamReader(path))
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

            if (dataGridView1.Rows.Count == 0)
            {
                textBox1.Text = value.Text;
                textBox2.Text = "1";
            }
            else 
            {
                try
                {
                    int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
                    textBox1.Text = value.Text;
                    textBox2.Text = (num + 1).ToString();
                }
                catch
                {
                }
            }
            

        }
        void elementTypeFromFile()
        {
            _type.Items.Clear();
            List<Category> elem_types = new List<Category>();
            using (StreamReader sr = new StreamReader(mainn + @"/src/Типы элементов.txt"))
            {
                _manager.TypesReader(sr, elem_types);
            }
            foreach (Category cat in elem_types)
            {
                _type.Items.Add(cat.GetContent());
            }
        }
        void contructionFromFile()
        {
            //element_construct.Items.Clear();
            _construct.Items.Clear();
            List<Category> con_types = new List<Category>();
            using (StreamReader sr = new StreamReader(mainn + "/src/Конструкция элементов.txt"))
            {
                _manager.TypesReader(sr, con_types);
            }
            foreach (Category cat in con_types)
            {
                _construct.Items.Add(cat.GetContent());
            }
        }

        void plotFromFile()
        {
            //ploskost.Items.Clear();
            plosk.Items.Clear();
            List<Category> plot_types = new List<Category>();
            using (StreamReader sr = new StreamReader(mainn + "/src/Плоскость расположения.txt"))
            {
                _manager.TypesReader(sr, plot_types);
            }
            foreach (Category cat in plot_types)
            {
                plosk.Items.Add(cat.GetContent());
            }
        }

        void diametersFromFile() 
        {
            diameters.Items.Clear();
            List<Category> diameters_types = new List<Category>();
            using (StreamReader sr = new StreamReader(mainn + "/src/Наружные диаметры.txt"))
            {
                _manager.TypesReader(sr, diameters_types);
            }
            foreach (Category cat in diameters_types)
            {
                diameters.Items.Add(cat.GetContent());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void saver_Tick(object sender, EventArgs e)
        {
            //TableSaver();
            //TODO File saver 
        }

        private void загрузитьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog table = new OpenFileDialog();
            if (table.ShowDialog() == DialogResult.OK) 
            {
                dataGridView1.Rows.Clear();
                TableInit(table.FileName);
            }

        }

        private void Диагностируемый_участок_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            
            
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

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

        private void Диагностируемый_участок_Load(object sender, EventArgs e)
        {
            textBox14.Text = MarshrutLenght(dataGridView1).ToString();

            bool le = false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[1, i].Value.ToString() == textBox2.Text)
                {
                    le = true;
                }
            }

            if (!le)
            {
                try
                {
                    double len = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        len += Convert.ToDouble(dataGridView1[5, i].Value);
                    }
                    len += Convert.ToDouble(dataGridView1[4, 0].Value);


                    textBox3.Text = len.ToString();
                }
                catch
                { }

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

        private double MarshrutLenght(DataGridView dg) 
        {
            double lenght = 0;
            try 
            {
              
                for (int i = 0; i < dg.RowCount; i++)
                {
                    if (i == 0)
                    {
                        lenght += Convert.ToDouble(dg[4, 0].Value);
                    }

                    lenght += Convert.ToDouble(dg[5, i].Value);
                }
            } 
            catch { }

            double ss = 0;
            
            try
            {
                ss = 2 * Math.PI * lenght * ((Convert.ToDouble(dg[3, 0].Value)/2)/100);
                ss = Math.Round(ss,2);
                textBox15.Text = ss.ToString();
            }
            catch { }

            return lenght;
        } //+

        private void удалениеПустыхСтрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void add_row_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, 0].Value = value.Text;
            dataGridView1[1, dataGridView1.RowCount - 1].Value = (dataGridView1.RowCount).ToString();
            dataGridView1[0, dataGridView1.RowCount - 1].Value = dataGridView1[0, 0].Value;


           

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
            }
            else { }
            
            string path = _manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt";

            if (!File.Exists(path))
            {
                Save(path);
            }
            else
            {
                Save(path);
            }

            textBox14.Text = MarshrutLenght(dataGridView1).ToString();
        }

        private void вставитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
           
            using (StreamWriter sw = new StreamWriter(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt")) 
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {
                        sw.Write(dataGridView1[j, i].Value + ";");
                        
                        
                    }
                    if (i == index)
                    {

                        sw.WriteLine(value.Text+";"+" "+";");
                    }
                    sw.WriteLine();
                }
            }


            dataGridView1.Rows.Clear();
            TableInit(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt");

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
        void refreshLists() 
        {
            elementTypeFromFile();
            contructionFromFile();
            plotFromFile();
        }
        private void редакторСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.RedactorOpened = true;
            Редактор rd = new Редактор(_manager);
            rd.ShowDialog();
            

        }

        private void Диагностируемый_участок_Activated(object sender, EventArgs e)
        {
            
        }

        private void Диагностируемый_участок_Enter(object sender, EventArgs e)
        {
       
        }

        private void Диагностируемый_участок_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void автозаполнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
                
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_manager.RedactorOpened) 
            {
                refreshLists();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            textBox14.Text = MarshrutLenght(dataGridView1).ToString();

            string path = _manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt";
            try
            {
                Save(path);
            }
            catch
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void _construct_Enter(object sender, EventArgs e)
        {
           
        }

        private void _construct_Leave(object sender, EventArgs e)
        {

        }

        private void _construct_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void _construct_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                _type.SelectedItem == "" ||
                diameters.SelectedItem == "" ||
                textBox3.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == "" ||
                _construct.SelectedItem == "" ||
                textBox7.Text == "" ||
                textBox8.Text == "" ||
                plosk.SelectedItem == "" ||
                textBox9.Text == "" ||
                textBox10.Text == "" ||
                textBox11.Text == "" ||
                textBox12.Text == "" ||
                textBox13.Text == "" ||
                textBox16.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else 
            {
                if (_type.ToString().ToLower().Contains("отвод"))
                {
                    if (textBox9.Text == "-")
                    {
                        MessageBox.Show("Не все данные отвода заполнены!");
                    }
                }
                else 
                {
                    if (_type.ToString().ToLower().Contains("тройник") || _type.ToString().ToLower().Contains("переход")) 
                    {
                        if (textBox11.Text == "-")
                        {
                            MessageBox.Show("Не все данные тройника заполнены!");
                        }
                    }
                }

                if (!_type.ToString().ToLower().Contains("отвод") && !_type.ToString().ToLower().Contains("тройник") && !_type.ToString().ToLower().Contains("переход")) 
                {
                    bool save = true;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (textBox2.Text == dataGridView1[1, i].Value.ToString())
                        {
                            save = false;
                            try
                            {
                                dataGridView1[0, i].Value = textBox1.Text;
                                dataGridView1[1, i].Value = textBox2.Text;
                                dataGridView1[2, i].Value = _type.SelectedItem;
                                dataGridView1[3, i].Value = diameters.SelectedItem;
                                dataGridView1[4, i].Value = textBox3.Text;
                                dataGridView1[5, i].Value = textBox5.Text;
                                dataGridView1[6, i].Value = textBox6.Text;
                                dataGridView1[7, i].Value = _construct.SelectedItem;
                                dataGridView1[8, i].Value = textBox7.Text;
                                dataGridView1[9, i].Value = textBox8.Text;
                                dataGridView1[10, i].Value = plosk.SelectedItem;
                                dataGridView1[11, i].Value = textBox9.Text;
                                dataGridView1[12, i].Value = textBox10.Text;
                                dataGridView1[13, i].Value = textBox11.Text;
                                dataGridView1[14, i].Value = textBox12.Text;
                                dataGridView1[15, i].Value = textBox13.Text;
                                dataGridView1[16, i].Value = textBox16.Text;

                                //try { textBox11.Text = dataGridView1[13, 0].Value.ToString(); } catch { }


                            }
                            catch { }

                        }
                    }
                    if (save)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = textBox1.Text;
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = textBox2.Text;
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = _type.SelectedItem;
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = diameters.SelectedItem;
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = textBox3.Text;
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = textBox5.Text;
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = textBox6.Text;
                        dataGridView1[7, dataGridView1.Rows.Count - 1].Value = _construct.SelectedItem; ;
                        dataGridView1[8, dataGridView1.Rows.Count - 1].Value = textBox7.Text;
                        dataGridView1[9, dataGridView1.Rows.Count - 1].Value = textBox8.Text;
                        dataGridView1[10, dataGridView1.Rows.Count - 1].Value = plosk.SelectedItem;
                        dataGridView1[11, dataGridView1.Rows.Count - 1].Value = textBox9.Text;
                        dataGridView1[12, dataGridView1.Rows.Count - 1].Value = textBox10.Text;
                        dataGridView1[13, dataGridView1.Rows.Count - 1].Value = textBox11.Text;
                        dataGridView1[14, dataGridView1.Rows.Count - 1].Value = textBox12.Text;
                        dataGridView1[15, dataGridView1.Rows.Count - 1].Value = textBox13.Text;
                        dataGridView1[16, dataGridView1.Rows.Count - 1].Value = textBox16.Text;


                        try
                        {
                            if (dataGridView1[4, dataGridView1.Rows.Count - 1].Value.ToString().Contains('.'))
                            {
                                string[] dt = dataGridView1[4, dataGridView1.Rows.Count - 1].Value.ToString().Split('.');
                                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dt[0] + ',' + dt[1];
                            }

                            if (dataGridView1[4, dataGridView1.Rows.Count - 2].Value.ToString().Contains('.'))
                            {
                                string[] dt = dataGridView1[4, dataGridView1.Rows.Count - 2].Value.ToString().Split('.');
                                dataGridView1[4, dataGridView1.Rows.Count - 2].Value = dt[0] + ',' + dt[1];
                            }
                            dataGridView1[5, dataGridView1.Rows.Count - 2].Value = Convert.ToDouble(dataGridView1[4, dataGridView1.Rows.Count - 1].Value) -
                                                                                   Convert.ToDouble(dataGridView1[4, dataGridView1.Rows.Count - 2].Value);

                        }
                        catch
                        { }

                        int pre = Convert.ToInt32(textBox2.Text) - 1;



                        if (textBox9.Text != "-")
                        {
                            using (File.Create(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + textBox1.Text + "_" + pre +
                                "_" + textBox2.Text + "_" + _type.SelectedItem + " " + textBox9.Text + ".txt")) ;
                        }
                        else
                        {
                            using (File.Create(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + textBox1.Text + "_" + pre +
                                "_" + textBox2.Text + "_" + _type.SelectedItem + ".txt")) ;
                        }

                        Thread.Sleep(10);
                        textBox14.Text = MarshrutLenght(dataGridView1).ToString();

                    }
                }

                




                string path = _manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt";

                if (!File.Exists(path))
                {
                    Save(path);
                }
                else
                {
                    Save(path);
                }

                if (File.Exists(_manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt"))
                {
                    using (StreamWriter sw = new StreamWriter(_manager.folderName + "/ВТО/Маршрут - " + value.Text + "/Выявленные особенности маршрут - " + value.Text + ".txt", true))
                    {
                        sw.WriteLine(dataGridView1[0, dataGridView1.Rows.Count - 1].Value + ";"
                                    + dataGridView1[1, dataGridView1.Rows.Count - 1].Value + ";"
                                    + "-")/*dataGridView1[2, dataGridView1.Rows.Count - 1].Value)*/;
                    }

                }

                textBox1.Text = null;
                textBox2.Text = null;
                _type.SelectedItem = null;
                diameters.SelectedItem = null;
                textBox3.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                _construct.SelectedItem = null;
                textBox7.Text = null;
                textBox8.Text = null;
                plosk.SelectedItem = null;
                textBox9.Text = null;
                textBox10.Text = null;
                textBox11.Text = null;
                textBox12.Text = null;
                textBox13.Text = null;
                textBox16.Text = null;

                int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
                textBox1.Text = value.Text;
                textBox2.Text = (num + 1).ToString();
            }
            
        }

        private void _type_Leave(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
         
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                _type.SelectedItem == "" ||
                diameters.SelectedItem == "" ||
                textBox3.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == "" ||
                _construct.SelectedItem == "" ||
                textBox7.Text == "" ||
                textBox8.Text == "" ||
                plosk.SelectedItem == "" ||
                textBox9.Text == "" ||
                textBox10.Text == "" ||
                textBox11.Text == "" ||
                textBox12.Text == "" ||
                textBox13.Text == "" ||
                textBox16.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else 
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (textBox2.Text == dataGridView1[1, i].Value.ToString())
                    {
                        try
                        {
                            string[] files = Directory.GetFiles(_manager.folderName + @"/Толщинометрия/Маршрут - " + value.Text);

                            for (int f = 0; f < files.Length; f++)
                            {
                                string file = Path.GetFileNameWithoutExtension(files[f]);

                                int pre = Convert.ToInt32(dataGridView1[1, i].Value) - 1;

                                if (file.ToString().Contains(value.Text + "_" + pre +
                                                       "_" + dataGridView1[1, i].Value + "_" + dataGridView1[2, i].Value))
                                {
                                    string path;
                                    if (textBox9.Text != "-")
                                    {
                                        path = _manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + textBox1.Text + "_" + pre +
                                            "_" + textBox2.Text + "_" + _type.SelectedItem + " " + textBox9.Text + ".txt";
                                    }
                                    else
                                    {
                                        path = _manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + textBox1.Text + "_" + pre +
                                            "_" + textBox2.Text + "_" + _type.SelectedItem + ".txt";
                                    }
                                    File.Move(files[f], path);
                                }
                            }

                            dataGridView1[0, i].Selected = true;
                            Thread.Sleep(10);
                            dataGridView1[0, i].Selected = false;

                            dataGridView1[0, i].Value = textBox1.Text;
                            dataGridView1[1, i].Value = textBox2.Text;
                            dataGridView1[2, i].Value = _type.SelectedItem;
                            dataGridView1[3, i].Value = diameters.SelectedItem;
                            dataGridView1[4, i].Value = textBox3.Text;
                            dataGridView1[5, i].Value = textBox5.Text;
                            dataGridView1[6, i].Value = textBox6.Text;
                            dataGridView1[7, i].Value = _construct.SelectedItem; ;
                            dataGridView1[8, i].Value = textBox7.Text;
                            dataGridView1[9, i].Value = textBox8.Text;
                            dataGridView1[10, i].Value = plosk.SelectedItem;
                            dataGridView1[11, i].Value = textBox9.Text;
                            dataGridView1[12, i].Value = textBox10.Text;
                            dataGridView1[13, i].Value = textBox11.Text;
                            dataGridView1[14, i].Value = textBox12.Text;
                            dataGridView1[15, i].Value = textBox13.Text;
                            dataGridView1[16, i].Value = textBox16.Text;



                            string p = _manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt";

                            if (!File.Exists(p))
                            {
                                Save(p);
                            }
                            else
                            {
                                Save(p);
                            }
                        }
                        catch { }

                    }
                }

                textBox14.Text = MarshrutLenght(dataGridView1).ToString();
            }



        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            _type.SelectedItem = null;
            diameters.SelectedItem = null;
            textBox3.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            _construct.SelectedItem = null;
            textBox7.Text = null;
            textBox8.Text = null;
            plosk.SelectedItem = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            textBox16.Text = null;

            int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString());
            textBox1.Text = value.Text;
            textBox2.Text = (num + 1).ToString();
        }

        private void Диагностируемый_участок_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(_manager.folderName + "/backup.txt"))
            {
                File.Delete(_manager.folderName + "/backup.txt");
            }
            try
            {
                string path = _manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt";
                if (!File.Exists(path))
                {
                    Save(path);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Сохранить перед закрытием?", "", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes) 
                    {
                        Save(path);                      
                    }
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

            _manager.JournalOpened = false;
            value.ReadOnly = false;
            value.BackColor = Color.White;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2) 
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try 
            {
                try { textBox2.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
                
                try { _type.SelectedItem = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
                try { diameters.SelectedItem = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
                textBox3.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox5.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox6.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                try { _construct.SelectedItem = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
                textBox7.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox8.Text = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString();
                try { plosk.SelectedItem = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
                textBox9.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox10.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox11.Text = dataGridView1[13, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox12.Text = dataGridView1[14, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox13.Text = dataGridView1[15, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox16.Text = dataGridView1[16, dataGridView1.CurrentRow.Index].Value.ToString();
            }

            try
            {
                if (dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString() != "")
                {
                    textBox3.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                }
            }
            catch
            { }


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
            //catch{ }
        }

        private void _type_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_type.SelectedItem.ToString().Contains("Отвод"))
                {
                    if (_type.SelectedItem.ToString().Contains("Труба"))
                    {
                        textBox8.Text = "-";
                        textBox9.Text = "-";
                        textBox10.Text = "-";
                        textBox11.Text = "-";
                        textBox12.Text = "-";
                        textBox13.Text = "-";
                        textBox16.Text = "-";
                    }
                    else 
                    {
                        textBox9.Text = "-";
                        textBox10.Text = "-";
                        textBox11.Text = "-";
                        textBox12.Text = "-";
                        textBox13.Text = "-";
                        textBox16.Text = "-";
                    }
                }
                else
                {
                    if (textBox8.Text == "-") 
                    {
                        textBox8.Clear();
                    }
                    if (textBox9.Text == "-")
                    {
                        textBox9.Clear();
                    }
                    if (textBox10.Text == "-")
                    {
                        textBox10.Clear();
                    }
                    if (textBox11.Text == "-")
                    {
                        textBox11.Clear();
                    }
                    if (textBox12.Text == "-")
                    {
                        textBox12.Clear();
                    }
                    if (textBox13.Text == "-")
                    {
                        textBox13.Clear();
                    }
                    if (textBox16.Text == "-")
                    {
                        textBox16.Clear();
                    }

                }
            }
            catch { }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Contains('.'))
            {
                string[] dt = textBox5.Text.Split('.');
                textBox5.Text = dt[0] + "," + dt[1];
                textBox5.SelectionStart = textBox5.Text.Length;
            }

            bool le = false;
            for (int i = 0; i < dataGridView1.RowCount; i++) 
            {
                if (dataGridView1[1, i].Value.ToString() == textBox2.Text) 
                {
                    le = true;
                }
            }

            if (!le) 
            {
                try
                {
                    double len = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        len += Convert.ToDouble(dataGridView1[5, i].Value);
                    }
                    len += Convert.ToDouble(dataGridView1[4, 0].Value);


                    textBox3.Text = len.ToString();
                }
                catch
                { }

            }

            //MessageBox.Show(dataGridView1[5, 0]);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string[] current_marshrut = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + value.Text + ".txt");
            current_marshrut[9] = textBox14.Text;
            current_marshrut[16] = textBox15.Text;

            using (StreamWriter sw = new StreamWriter(_manager.folderName + "/Маршруты/Маршрут - " + value.Text + ".txt"))
            {
                foreach (string s in current_marshrut)
                {
                    sw.WriteLine(s);
                }

                //sw.WriteLine(textBox15.Text);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (diameters.SelectedItem.ToString().Contains('.'))
            {
                string[] dt = diameters.SelectedItem.ToString().Split('.');
                diameters.SelectedItem = dt[0] + "," + dt[1];
                //diameters.SelectionStart = diameters.SelectedItem.Length;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
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

        public void LenConfiguration(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                try
                {
                    dgv[5, i + 1].Value = Convert.ToDouble(dgv[5, i].Value);
                }
                catch
                {
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Диагностируемый_участок_SizeChanged(object sender, EventArgs e)
        {
            Column1.Width = textBox16.Width + 3;
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            OnDataGridViewPaste(sender, e);
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(_manager.folderName + "/Маршруты/Площадь - " + value.Text + ".txt",textBox15.Text);
            }
            catch
            {
            }
        }

        private void _construct_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_type.SelectedItem.ToString().ToLower().Contains("труба") && !_construct.SelectedItem.ToString().ToLower().Contains("труба"))
                {
                    MessageBox.Show("Несоответсвие типов. Невозможно добавить этот элемент с выбранной конструкцией!");
                    _construct.SelectedText = "";
                    _type.Focus();
                }
            }
            catch { }
        }

        private void _construct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
