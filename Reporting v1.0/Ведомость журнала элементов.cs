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
    public partial class Ведомость_журнала_элементов : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();
        string mainn = Environment.CurrentDirectory;
        public Ведомость_журнала_элементов(Manager manager, TextBox tb)
        {
            value = tb;
            _manager = manager;
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try { dataGridView1[1, dataGridView1.CurrentRow.Index].Value = textBox2.Text ; } catch { }
            try { dataGridView1[2, dataGridView1.CurrentRow.Index].Value = _type1.SelectedItem.ToString(); } catch { }
            try { dataGridView1[3, dataGridView1.CurrentRow.Index].Value = textBox4.Text; } catch { }
            try { dataGridView1[4, dataGridView1.CurrentRow.Index].Value = textBox5.Text; } catch { }
            try { dataGridView1[5, dataGridView1.CurrentRow.Index].Value = textBox6.Text; } catch { }
            try { dataGridView1[6, dataGridView1.CurrentRow.Index].Value = _con1.SelectedItem.ToString(); } catch { }
            try { dataGridView1[7, dataGridView1.CurrentRow.Index].Value = textBox8.Text; } catch { }
            try { dataGridView1[8, dataGridView1.CurrentRow.Index].Value = textBox9.Text; } catch { }
            try { dataGridView1[9, dataGridView1.CurrentRow.Index].Value = _type2.SelectedItem.ToString(); } catch { }
            try { dataGridView1[10, dataGridView1.CurrentRow.Index].Value = textBox15.Text; } catch { }
            try { dataGridView1[11, dataGridView1.CurrentRow.Index].Value = textBox14.Text; } catch { }
            try { dataGridView1[12, dataGridView1.CurrentRow.Index].Value = textBox13.Text; } catch { }
            try { dataGridView1[13, dataGridView1.CurrentRow.Index].Value = _con2.SelectedItem.ToString(); } catch { }
            try { dataGridView1[14, dataGridView1.CurrentRow.Index].Value = textBox11.Text; } catch { }
            try { dataGridView1[15, dataGridView1.CurrentRow.Index].Value = textBox10.Text; } catch { }
            try { dataGridView1[16, dataGridView1.CurrentRow.Index].Value = textBox17.Text; } catch { }
        }

        void elementTypeFromFile(ComboBox cbm, string path)
        {
            cbm.Items.Clear();
            List<Category> elem_types = new List<Category>();
            using (StreamReader sr = new StreamReader(path))
            {
                _manager.TypesReader(sr, elem_types);
            }
            foreach (Category cat in elem_types)
            {
                cbm.Items.Add(cat.GetContent());
            }
        }
        void contructionFromFile(ComboBox cbm, string path)
        {
            //element_construct.Items.Clear();
            cbm.Items.Clear();
            List<Category> con_types = new List<Category>();
            using (StreamReader sr = new StreamReader(path))
            {
                _manager.TypesReader(sr, con_types);
            }
            foreach (Category cat in con_types)
            {
                cbm.Items.Add(cat.GetContent());
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
        private void Ведомость_журнала_элементов_Load(object sender, EventArgs e)
        {
            elementTypeFromFile(_type1, mainn + @"/src/Типы элементов.txt");
            elementTypeFromFile(_type2, mainn + @"/src/Типы элементов.txt");
            contructionFromFile(_con1, mainn + "/src/Конструкция элементов.txt");
            contructionFromFile(_con2, mainn + "/src/Конструкция элементов.txt");

            textBox1.Text = value.Text;
            string path = _manager.folderName + "/Ведомости журнала элементов/Маршрут - " + value.Text + ".txt";

            if (File.Exists(path))
            {
                string[] file = File.ReadAllLines(path);

                for (int i = 0; i < file.Length; i++)
                {
                    string[] element = file[i].Split(';');
                    dataGridView1.Rows.Add(element);
                }
            }
            else
            {
                if (!Directory.Exists(_manager.folderName + "/Ведомости журнала элементов"))
                {
                    Directory.CreateDirectory(_manager.folderName + "/Ведомости журнала элементов");
                }

                using (File.Create(path)) ;
                string[] elements = File.ReadAllLines(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + value.Text + ".txt");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        string[] element = elements[i].Split(';');

                        for (int j = 0; j <= 9; j++)
                        {
                            if (j != 4)
                            {
                                sw.Write(element[j]+";");
                            }
                        }
                        for (int j = 2; j <= 9; j++)
                        {
                            if (j != 4)
                            {
                                sw.Write(element[j] + ";");
                            }
                        }

                        sw.Write("-;");
                        sw.WriteLine();
                    }
                }
                
                string[] file = File.ReadAllLines(path);

                for (int i = 0; i < file.Length; i++)
                {
                    string[] element = file[i].Split(';');
                    dataGridView1.Rows.Add(element);
                }
            }
        }

        private void Ведомость_журнала_элементов_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string path = _manager.folderName + "/Ведомости журнала элементов/Маршрут - " + value.Text + ".txt";
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
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Clear();
            //textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            //textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            //textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            //textBox16.Clear();
            textBox17.Clear();
            try { textBox2.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { _type1.SelectedItem = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox4.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox5.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox6.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { _con1.SelectedItem = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox8.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox9.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { _type2.SelectedItem = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox15.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox14.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox13.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { _con2.SelectedItem = dataGridView1[13, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox11.Text = dataGridView1[14, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox10.Text = dataGridView1[15, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox17.Text = dataGridView1[16, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] row = new string[]
                {
                    textBox1.Text,
                    textBox2.Text,
                    _type1.SelectedItem.ToString(),
                    textBox4.Text,
                    textBox5.Text,
                    textBox6.Text,
                    _con1.SelectedItem.ToString(),
                    textBox8.Text,
                    textBox9.Text,
                    _type2.SelectedItem.ToString(),
                    textBox15.Text,
                    textBox14.Text,
                    textBox13.Text,
                    _con2.SelectedItem.ToString(),
                    textBox11.Text,
                    textBox10.Text,
                    textBox17.Text
                };
                dataGridView1.Rows.Insert(dataGridView1.CurrentRow.Index + 1, row);
                ReNumber();
            }
            catch
            {
                string[] row = new string[]
                {
                    textBox1.Text,
                    textBox2.Text,
                    _type1.SelectedItem.ToString(),
                    textBox4.Text,
                    textBox5.Text,
                    textBox6.Text,
                    _con1.SelectedItem.ToString(),
                    textBox8.Text,
                    textBox9.Text,
                    "-",
                    textBox15.Text,
                    textBox14.Text,
                    textBox13.Text,
                    "-",
                    textBox11.Text,
                    textBox10.Text,
                    textBox17.Text
                };
                dataGridView1.Rows.Insert(dataGridView1.CurrentRow.Index + 1, row);
                ReNumber();
            }

            
        }
        void ReNumber()
        {
            int str = 1;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[1, i].Value = str;
                str++;
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
            }
            else { }

            ReNumber();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = _manager.folderName + "/Ведомости журнала элементов/Маршрут - " + value.Text + ".txt";
                if (File.Exists(path))
                {
                    DialogResult result = MessageBox.Show("Сохранить?", "", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        Save(path);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неверно указан путь!");
            }
        }

        private void редакторСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.RedactorOpened = true;
            Редактор re = new Редактор(_manager);
            re.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridView1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                textBox17.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Left);

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                textBox2.Visible = false;
                _type1.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                _con1.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;

                groupBox1.Text = "";
                groupBox1.Width = 65;

                groupBox2.Location = new Point(72,69);

                dataGridView1.Width = 596;
                this.Width = 626;
            }
            else
            {
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.Columns[7].Visible = true;
                dataGridView1.Columns[8].Visible = true;
                textBox2.Visible = true;
                _type1.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                _con1.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;

                groupBox1.Text = "Данные окончательного отчета (экспресс-отчета) ТД с применением АДК";
                groupBox1.Width = 584;

                groupBox2.Location = new Point(592, 69);

                dataGridView1.Width = 1116;
                this.Width = 1146;

                dataGridView1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                textBox17.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            }
        }

        private void Ведомость_журнала_элементов_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Width > 1146)
                {
                    Column17.Width = textBox17.Width + 6;
                }

                
            }
            catch
            {
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Clear();
            //textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            //textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            //textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            //textBox16.Clear();
            textBox17.Clear();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string path = _manager.folderName + "/Ведомости журнала элементов/Маршрут - " + value.Text + ".txt";
                Save(path);
            }
            catch
            {
                
            }
        }
    }
}
