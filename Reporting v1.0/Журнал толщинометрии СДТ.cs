using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Reporting_v1._0
{
    public partial class Журнал_толщинометрии_СДТ : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();
        string[] files;
        public Журнал_толщинометрии_СДТ(Manager manager, TextBox tb)
        {
            value = tb;
            _manager = manager;

            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Rows.Add();
            }

            dataGridView1.Rows[0].HeaderCell.Value = "I";
            dataGridView1.Rows[3].HeaderCell.Value = "II";
            dataGridView1.Rows[6].HeaderCell.Value = "III";

            files = Directory.GetFiles(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text);

            for (int f = 0; f < files.Length; f++) 
            {
                if (files[f] == "Изделия.txt") 
                {
                    break;
                }
                else files[f] = Path.GetFileNameWithoutExtension(files[f]);

            }
             
            for (int i = 0; i < files.Length; i++) 
            {
                if (!files[i].Contains("Труба")) 
                {
                    comboBox1.Items.Add(files[i]);
                }
                
            }

        }

        private void Журнал_толщинометрии_СДТ_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Журнал_толщинометрии_СДТ_FormClosing(object sender, FormClosingEventArgs e)
        {
            value.ReadOnly = false;
            value.BackColor = Color.White;
            _manager.JournalOpened = false;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            #region oldcontent
            //if (comboBox1.SelectedItem != null) 
            //{
            //    string[] strings = File.ReadAllLines(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + comboBox1.SelectedItem);

            //    if (strings.Length > 0)
            //    {
            //        textBox6.Clear();
            //        dataGridView1.Rows.Clear();
            //        string recomend="";
            //        string[] firstString = strings[0].Split('_');

            //        textBox1.Text = firstString[0];
            //        textBox2.Text = firstString[1];
            //        textBox3.Text = firstString[2];
            //        textBox4.Text = firstString[3];
            //        textBox5.Text = firstString[4];


            //        for (int i = 1; i < 10; i++)
            //        {
            //            string[] data = strings[i].Split(';');
            //            dataGridView1.Rows.Add(data);
            //        }

            //        for (int k = 10; k < strings.Length; k++) 
            //        {
            //            recomend += strings[k]+"\n";
            //        }
            //        textBox6.Text = recomend;


            //        try
            //        {
            //            dataGridView1.Rows[0].HeaderCell.Value = "I";
            //            dataGridView1.Rows[3].HeaderCell.Value = "II";
            //            dataGridView1.Rows[6].HeaderCell.Value = "III";
            //        }
            //        catch { }
            //    }

            //    else 
            //    {
            //        textBox6.Clear();
            //        textBox5.Clear();
            //        dataGridView1.Rows.Clear();

            //        for (int i = 0; i < 9; i++)
            //        {
            //            dataGridView1.Rows.Add();
            //        }

            //        dataGridView1.Rows[0].HeaderCell.Value = "I";
            //        dataGridView1.Rows[3].HeaderCell.Value = "II";
            //        dataGridView1.Rows[6].HeaderCell.Value = "III";

            //        string comb = comboBox1.SelectedItem.ToString();
            //        string[] first_elem = comb.Split('_');

            //        textBox1.Text = first_elem[2];
            //        textBox2.Text = first_elem[0];
            //        textBox3.Text = first_elem[1];
            //        textBox4.Text = first_elem[2];
            //    }

            //}   
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + comboBox1.SelectedItem+".txt"))
                {
                    string firstSt = textBox1.Text + "_" + textBox2.Text + "_" + textBox3.Text + "_" +
                                     textBox4.Text + "_" + textBox5.Text + "_" + comboBox1.SelectedItem;
                    sw.WriteLine(firstSt); // FIRST STRING

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            try
                            {
                                sw.Write(dataGridView1[j, i].Value.ToString() + ";");
                            }
                            catch 
                            {
                                sw.Write("-" + ";");
                            }
                             // GRID
                        }
                        sw.WriteLine();
                    }

                    sw.WriteLine(textBox6.Text); // RECOMENDs
                    
                    
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string[] strings = File.ReadAllLines(_manager.folderName + @"/Толщинометрия/"+"Маршрут - "+value.Text+"/" + comboBox1.SelectedItem+".txt");

                if (strings.Length > 0)
                {
                    textBox6.Clear();
                    dataGridView1.Rows.Clear();
                    string recomend = "";
                    string[] firstString = strings[0].Split('_');

                    textBox1.Text = firstString[0];
                    textBox2.Text = firstString[1];
                    textBox3.Text = firstString[2];
                    textBox4.Text = firstString[3];
                    textBox5.Text = firstString[4];


                    for (int i = 1; i < 10; i++)
                    {
                        string[] data = strings[i].Split(';');
                        dataGridView1.Rows.Add(data);
                    }

                    for (int k = 10; k < strings.Length; k++)
                    {
                        recomend += strings[k] + "\n";
                    }
                    textBox6.Text = recomend;


                    try
                    {
                        dataGridView1.Rows[0].HeaderCell.Value = "I";
                        dataGridView1.Rows[3].HeaderCell.Value = "II";
                        dataGridView1.Rows[6].HeaderCell.Value = "III";
                    }
                    catch { }
                }

                else
                {
                    textBox6.Clear();
                    textBox5.Clear();
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < 9; i++)
                    {
                        dataGridView1.Rows.Add();
                    }

                    dataGridView1.Rows[0].HeaderCell.Value = "I";
                    dataGridView1.Rows[3].HeaderCell.Value = "II";
                    dataGridView1.Rows[6].HeaderCell.Value = "III";

                    string comb = comboBox1.SelectedItem.ToString();
                    string[] first_elem = comb.Split('_');

                    textBox1.Text = first_elem[2];
                    textBox2.Text = first_elem[0];
                    textBox3.Text = first_elem[1];
                    textBox4.Text = first_elem[2];
                }
            }
            comboBox1.SelectionLength = 0;
            dataGridView1.Focus();
        }

        private void outp_Click(object sender, EventArgs e)
        {
            bool check = true;
            for (int q = 0; q < dataGridView1.Rows.Count; q++) 
            {
                for (int w = 0; w < dataGridView1.Columns.Count; w++) 
                {
                    try
                    {
                        if (dataGridView1[w, q].Value.ToString().Contains('.'))
                        {
                            string[] dt = dataGridView1[w, q].Value.ToString().Split('.');
                            string dtNew = dt[0] + "," + dt[1];
                            dataGridView1[w, q].Value = dtNew;
                        }
                    }
                    catch 
                    {
                        dataGridView1[w, q].Selected = true;
                        check = false;
                    }
                    
                }
            }

            if (!check)
            {
                MessageBox.Show("Таблица не заполнена!");
            }
            else 
            {
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                string[] file = File.ReadAllLines(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt");
                double minValue = Convert.ToDouble(dataGridView1[0, 0].Value.ToString());

                for (int r = 0; r < dataGridView1.Rows.Count; r++)
                {
                    for (int c = 0; c < dataGridView1.Columns.Count; c++)
                    {
                        if (Convert.ToDouble(dataGridView1[c, r].Value.ToString()) < minValue)
                        {
                            minValue = Convert.ToDouble(dataGridView1[c, r].Value.ToString());
                        }
                    }
                }

                for (int i = 0; i < file.Length; i++)
                {
                    string[] pces = file[i].Split(';');

                    if (textBox2.Text == pces[0] && textBox1.Text == pces[1])
                    {

                        pces[6] = minValue.ToString();

                        string svStr = "";
                        for (int p = 0; p < pces.Length; p++)
                        {
                            svStr += pces[p] + ";";
                        }
                        file[i] = svStr;
                    }
                }

                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt"))
                {
                    for (int f = 0; f < file.Length; f++)
                    {
                        sw.WriteLine(file[f]);
                    }
                }

                if (comboBox1.SelectedItem != null)
                {
                    using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + comboBox1.SelectedItem + ".txt"))
                    {
                        try
                        {
                            string firstSt = textBox1.Text + "_" + textBox2.Text + "_" + textBox3.Text + "_" +
                                         textBox4.Text + "_" + textBox5.Text + "_" + comboBox1.SelectedItem;
                            sw.WriteLine(firstSt); // FIRST STRING

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {
                                    sw.Write(dataGridView1[j, i].Value.ToString() + ";"); // GRID
                                }
                                sw.WriteLine();
                            }

                            sw.WriteLine(textBox6.Text); // RECOMENDs
                        }
                        catch
                        {
                            MessageBox.Show("Не все поля заполнены!");
                        }

                    }
                }
            }

            MessageBox.Show("Данные выгружены!");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double n = Convert.ToDouble(dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentRow.Index].Value);
                n = Math.Round(n, 1);
                if (n % 1 == 0)
                {
                    dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentRow.Index].Value = n.ToString() + ",0";
                }
                else
                    dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentRow.Index].Value = n.ToString();
            }
            catch
            {
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + value.Text + "/" + comboBox1.SelectedItem + ".txt"))
                {
                    string firstSt = textBox1.Text + "_" + textBox2.Text + "_" + textBox3.Text + "_" +
                                     textBox4.Text + "_" + textBox5.Text + "_" + comboBox1.SelectedItem;
                    sw.WriteLine(firstSt); // FIRST STRING

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            try
                            {
                                sw.Write(dataGridView1[j, i].Value.ToString() + ";");
                            }
                            catch
                            {
                                sw.Write("-" + ";");
                            }
                            // GRID
                        }
                        sw.WriteLine();
                    }

                    sw.WriteLine(textBox6.Text); // RECOMENDs


                }
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

        private void Журнал_толщинометрии_СДТ_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
