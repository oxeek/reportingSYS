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
    public partial class Ведомость_дефектов_основного_металла : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();
        string mainn = Environment.CurrentDirectory;
        public Ведомость_дефектов_основного_металла(Manager manager, TextBox tb)
        {
            value = tb;
            _manager = manager;
            InitializeComponent();
        }

        public void AddToTable(string path)
        {
            List<string> elemsList = new List<string>();
            string[] file = File.ReadAllLines(path);

            for (int i = 0; i < file.Length; i++)
            {
                string[] element = file[i].Split(';');
                elemsList.Add(element[1]);
            }

            elemsList = elemsList.Distinct().ToList();

            for (int i = 0; i < elemsList.Count; i++)
            {
                elems.Items.Add(elemsList[i]);
            }

            
        }

        private void Ведомость_дефектов_основного_металла_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Column1.Visible = false;
                Column2.Visible = false;
                Column3.Visible = false;
                Column4.Visible = false;
                Column5.Visible = false;
                Column6.Visible = false;
                Column7.Visible = false;
                Column8.Visible = false;
                Column9.Visible = false;
                Column10.Visible = false;

                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;

                label3.Visible = false;
                label4.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                groupBox2.Visible = false;

                groupBox1.Width = 128;
                groupBox1.Text = "";
            }

            textBox1.Text = value.Text;
            string path = _manager.folderName + "/Ведомости дефектов основного металла/Маршрут - " + value.Text + ".txt";
            string osobpath = _manager.folderName + "/Неразрушающий контроль/Неразрушающий контроль маршрут - " + value.Text + ".txt";

            if (File.Exists(path))
            {
                AddToTable(path);
            }
            else
            {
                if (!Directory.Exists(_manager.folderName + "/Ведомости дефектов основного металла"))
                {
                    Directory.CreateDirectory(_manager.folderName + "/Ведомости дефектов основного металла");
                }

                using (File.Create(path));

                string[] osobs = File.ReadAllLines(osobpath);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < osobs.Length; i++)
                    {
                        string[] o = osobs[i].Split(';');

                        sw.WriteLine(o[0] + ";" + o[1] + ";" + o[3] + ";" + o[4] + ";" + o[5] + ";" + "?" + ";" + "?" + ";" + o[8] + ";" + o[9] + ";" + o[10] + ";" +
                                     o[3] + ";" + o[4] + ";" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;");
                    }
                    
                }

                AddToTable(path);
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
        private void редакторСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.RedactorOpened = true;
            Редактор re = new Редактор(_manager);
            re.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            OnDataGridViewPaste(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Column1.Visible = false;
                Column2.Visible = false;
                Column3.Visible = false;
                Column4.Visible = false;
                Column5.Visible = false;
                Column6.Visible = false;
                Column7.Visible = false;
                Column8.Visible = false;
                Column9.Visible = false;
                Column10.Visible = false;

                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;

                label3.Visible = false;
                label4.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                groupBox2.Visible = false;

                groupBox1.Width = 128;
                groupBox1.Text = "";
            }
            else
            {
                Column1.Visible = true;
                Column2.Visible = true;
                Column3.Visible = true;
                Column4.Visible = true;
                Column5.Visible = true;
                Column6.Visible = true;
                Column7.Visible = true;
                Column8.Visible = true;
                Column9.Visible = true;
                Column10.Visible = true;

                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;

                label3.Visible = true;
                label4.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                groupBox2.Visible = true;

                groupBox1.Width = 662;
                groupBox1.Text = "Данные окончательного отчета (экспресс-отчета) ТД с применением АДК";
            }
        }

        private void elems_SelectedValueChanged(object sender, EventArgs e)
        {
            string path = _manager.folderName + "/Ведомости дефектов основного металла/Маршрут - " + value.Text + ".txt";
            AddToTable(path);
            dataGridView1.Rows.Clear();
            //elems.Items.Clear();
            string[] file = File.ReadAllLines(path);
            for (int i = 0; i < file.Length; i++)
            {
                string[] element = file[i].Split(';');

                dataGridView1.Rows.Add(element);
                if (element[1] != elems.SelectedItem.ToString())
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Visible = false;
                }

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();

            try { elems.SelectedItem = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox3.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox4.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox5.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox6.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox7.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox8.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox9.Text = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox10.Text = dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }

            try { textBox18.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox17.Text = dataGridView1[11, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox16.Text = dataGridView1[12, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox15.Text = dataGridView1[13, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox14.Text = dataGridView1[14, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox13.Text = dataGridView1[15, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox12.Text = dataGridView1[16, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox11.Text = dataGridView1[17, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }

            try { textBox21.Text = dataGridView1[18, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox20.Text = dataGridView1[19, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox19.Text = dataGridView1[20, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }

            try { textBox22.Text = dataGridView1[21, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox23.Text = dataGridView1[22, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
            try { textBox24.Text = dataGridView1[23, dataGridView1.CurrentRow.Index].Value.ToString(); } catch { }
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


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = _manager.folderName + "/Ведомости дефектов основного металла/Маршрут - " + value.Text + ".txt";
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

        private void save_btn_Click(object sender, EventArgs e)
        {
            try { dataGridView1[1, dataGridView1.CurrentRow.Index].Value = elems.SelectedItem; } catch { }
            try { dataGridView1[2, dataGridView1.CurrentRow.Index].Value = textBox3.Text;  } catch { }
            try { dataGridView1[3, dataGridView1.CurrentRow.Index].Value = textBox4.Text; } catch { }
            try { dataGridView1[4, dataGridView1.CurrentRow.Index].Value = textBox5.Text  ; } catch { }
            try { dataGridView1[5, dataGridView1.CurrentRow.Index].Value = textBox6.Text  ; } catch { }
            try { dataGridView1[6, dataGridView1.CurrentRow.Index].Value = textBox7.Text  ; } catch { }
            try { dataGridView1[7, dataGridView1.CurrentRow.Index].Value = textBox8.Text  ; } catch { }
            try { dataGridView1[8, dataGridView1.CurrentRow.Index].Value = textBox9.Text ; } catch { }
            try { dataGridView1[9, dataGridView1.CurrentRow.Index].Value = textBox10.Text  ; } catch { }

            try { dataGridView1[10, dataGridView1.CurrentRow.Index].Value = textBox18.Text  ; } catch { }
            try { dataGridView1[11, dataGridView1.CurrentRow.Index].Value = textBox17.Text ; } catch { }
            try { dataGridView1[12, dataGridView1.CurrentRow.Index].Value = textBox16.Text  ; } catch { }
            try { dataGridView1[13, dataGridView1.CurrentRow.Index].Value = textBox15.Text  ; } catch { }
            try { dataGridView1[14, dataGridView1.CurrentRow.Index].Value = textBox14.Text  ; } catch { }
            try { dataGridView1[15, dataGridView1.CurrentRow.Index].Value = textBox13.Text  ; } catch { }
            try { dataGridView1[16, dataGridView1.CurrentRow.Index].Value = textBox12.Text  ; } catch { }
            try { dataGridView1[17, dataGridView1.CurrentRow.Index].Value = textBox11.Text ; } catch { }

            try { dataGridView1[18, dataGridView1.CurrentRow.Index].Value = textBox21.Text ; } catch { }
            try { dataGridView1[19, dataGridView1.CurrentRow.Index].Value = textBox20.Text ; } catch { }
            try { dataGridView1[20, dataGridView1.CurrentRow.Index].Value = textBox19.Text ; } catch { }

            try { dataGridView1[21, dataGridView1.CurrentRow.Index].Value = textBox22.Text  ; } catch { }
            try { dataGridView1[22, dataGridView1.CurrentRow.Index].Value = textBox23.Text  ; } catch { }
            try { dataGridView1[23, dataGridView1.CurrentRow.Index].Value = textBox24.Text  ; } catch { }

            Save(_manager.folderName + "/Ведомости дефектов основного металла/Маршрут - " + value.Text + ".txt");
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Save(_manager.folderName + "/Ведомости дефектов основного металла/Маршрут - " + value.Text + ".txt");
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


            Save(_manager.folderName + "/Ведомости дефектов основного металла/Маршрут - " + value.Text + ".txt");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string path = _manager.folderName + "/Ведомости дефектов основного металла/Маршрут - " + value.Text + ".txt";
                Save(path);
            }
            catch
            {
                
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
