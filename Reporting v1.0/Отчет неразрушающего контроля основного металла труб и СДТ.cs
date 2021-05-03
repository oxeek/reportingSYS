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
using Excel = Microsoft.Office.Interop.Excel;
namespace Reporting_v1._0
{
    public partial class Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();

        string mainn = Environment.CurrentDirectory;
        public Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ(Manager manager, TextBox tb)
        {
            value = tb;
            _manager = manager;
            InitializeComponent();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (File.Exists(_manager.folderName + @"/Неразрушающий контроль" + "/Неразрушающий контроль маршрут - " + value.Text + ".txt"))
            {
                TableInit(_manager.folderName + @"/Неразрушающий контроль" + "/Неразрушающий контроль маршрут - " + value.Text + ".txt");

                string[] fl = File.ReadAllLines(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt");
                List<string> wall = new List<string>();

                for (int w = 0; w < fl.Length; w++) 
                {
                    try
                    {
                        if (fl[w].Split(';')[6].Length < 1)
                        {
                            wall.Add(fl[w].Split(';')[1] + "_-");
                        }
                        else
                        {
                            wall.Add(fl[w].Split(';')[1] + "_" + fl[w].Split(';')[6]);
                        }
                    }
                    catch
                    {
                    }

                    
                }

                for (int r = 0; r < dataGridView1.Rows.Count; r++) 
                {
                    for (int wl = 0; wl < wall.Count; wl++) 
                    {
                        string[] h = wall[wl].Split('_');
                        if (dataGridView1[1, r].Value.ToString() == h[0])
                        {
                            dataGridView1[2, r].Value = h[1];
                        }
                    }
                    
                }
                //foreach (string wl in wall) 
                //{
                //    MessageBox.Show(wl);
                //}

                
            }
            else 
            {
                TableInitWithotFile(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt");
                ReNumber();
            }

            InitMathAndWhiteSpace();
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
                    str[2] = str[6];
                    for (int i = 3; i < str.Length; i++)
                    {
                        str[i] = "-";
                        if (i == 4) 
                        {
                            str[i] = "Дефектов не обнаружено";
                        }
                    }

                    dataGridView1.Rows.Add(str);
                }
            }
        }

        void ReNumber()
        {
            try
            {
                int str = 1;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[4, i].Value.ToString().Contains("Дефектов не обнаружено"))
                    {
                        dataGridView1[3, i].Value = "-";
                    }
                    else
                    {
                        dataGridView1[3, i].Value = str;
                        str++;
                    }
                }
            }
            catch { };

        }
        void TableInit(string path)
        {
            string[] allLines = File.ReadAllLines(_manager.folderName+ @"/Журнал контроля/Маршрут - "+value.Text+".txt");
            List<string> wall = new List<string>();
            string[] lastLine = allLines[allLines.Length - 1].Split(';');

            for (int w = 0; w < allLines.Length; w++) 
            {
                try
                {
                    string[] data = allLines[w].Split(';');
                    wall.Add(data[6]);
                }
                catch
                {
                }

                
            }
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

            if (Convert.ToInt32(lastLine[1]) > Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value)) 
            {
                int counter = Convert.ToInt32(lastLine[1]) - Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value);
                int num = Convert.ToInt32(dataGridView1[1, dataGridView1.Rows.Count - 1].Value)+1;
                for (int i = 0; i < counter; i++) 
                {
                    string s = dataGridView1[0, dataGridView1.Rows.Count - 1].Value + ";" + num + ";" + "-;" + "-;" +
                                      "Дефектов не обнаружено"+";" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" ;
                    string[] str = s.Split(';');
                    dataGridView1.Rows.Add(str);
                    num++;
                }
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++) //ADD STENKU
            {
                for (int wl = 0; wl < wall.Count; wl++) 
                {
                    if (dataGridView1[1,i].Value.ToString() == (wl + 1).ToString( )&& dataGridView1[2,i].Value.ToString()=="")
                    {
                        dataGridView1[2,i].Value = wall[wl];
                    }
                }
            }
            Save(path);

            ReNumber();
        }
        //void defectTypeFromFile()
        //{
        //    List<Category> defect_types = new List<Category>();
        //    using (StreamReader sr = new StreamReader(@"C:\Users\" + Environment.UserName + "/Desktop/Система Формирования Отчётов/src/Типы дефектов.txt"))
        //    {
        //        _manager.TypesReader(sr, defect_types);
        //    }
        //    foreach (Category cat in defect_types)
        //    {
        //        defect_type.Items.Add(cat.GetContent());
        //    }

        //}
        void ElementNumberImport(string path)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                string inpstr;
                string[] str;
                while ((inpstr = sr.ReadLine()) != null)
                {
                    str = inpstr.Split(';');
                    for (int i = 2; i < str.Length - 2;i++) 
                    {
                        str[i] = null;
                    }
                    dataGridView1.Rows.Add(str);
                }
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
        private void Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_Load(object sender, EventArgs e)
        {
            note.Width = 70;

            


        }

        void InitMathAndWhiteSpace() 
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value.ToString().Contains("."))
                    {
                        string[] row = dataGridView1[j, i].Value.ToString().Split('.');
                        dataGridView1[j, i].Value = row[0] + "," + row[1];
                    }
                }

                try 
                {
                    dataGridView1[8, i].Value = Math.Round(Convert.ToDouble(dataGridView1[8, i].Value), 0).ToString();
                    dataGridView1[9, i].Value = Math.Round(Convert.ToDouble(dataGridView1[9, i].Value), 0).ToString();
                } 
                catch { }

                try
                {
                    dataGridView1[5, i].Value = (Convert.ToDouble(dataGridView1[5, i].Value)*1000).ToString();
                    dataGridView1[6, i].Value = Math.Round(Convert.ToDouble(dataGridView1[6, i].Value)/15,2).ToString();
                    dataGridView1[7, i].Value = Math.Round(Convert.ToDouble(dataGridView1[7, i].Value) / 15, 2).ToString();
                }
                catch { }
            }

            string[] mar = File.ReadAllLines(_manager.folderName + @"/Журнал контроля/Маршрут - " + value.Text + ".txt");

            for (int i = 0; i < dataGridView1.Rows.Count; i++) 
            {
                for (int j = 0; j < mar.Length; j++) 
                {
                    if (dataGridView1[1, i].Value.ToString() == mar[j].Split(';')[1] && dataGridView1[10, i].Value.ToString() != "-") 
                    {
                        //11 = mar-6 / 10 * 100 
                        try 
                        {
                            dataGridView1[12, i].Value = Math.Round((Convert.ToDouble(dataGridView1[10, i].Value) / Convert.ToDouble(mar[j].Split(';')[6]))*100,1).ToString();
                        } 
                        catch
                        {
                            //MessageBox.Show(e.Message);
                        }
                    }
                }
                
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value.ToString() == "")
                    {
                        dataGridView1[j, i].Value = "-";
                    }
                }
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1[0, dataGridView1.RowCount - 1].Value = dataGridView1[0, 0].Value;
        }

        void CopyFile(string sourcefn, string destinfn)
        {
            FileInfo fn = new FileInfo(sourcefn);
            fn.CopyTo(destinfn, true);
        }

       
        private void выгрузитьtestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter(_manager.folderName + "/log.txt", true);
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {
                        if ((dataGridView1[4, i].Value == null) && (dataGridView1[3, i].Value == null))
                        {
                            continue;
                        }
                        sw.Write(dataGridView1[j, i].Value+";");
                    }
                    sw.WriteLine();
                }
            }
            sw.Close();
        
        }

      

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void составитьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            //EXCEL BLOCK
            string path = _manager.folderName + "/Отчёт.xlsm";
            string currentSheet = "ВИК";

            CopyFile(mainn + @"\patterns\test.xlsm", _manager.folderName + "/Отчёт.xlsm");

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open
                (
                    path,
                    Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing
                );

            Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
            //

            

            using (StreamReader sr = new StreamReader(_manager.folderName + "/log.txt"))
            {
                string[] lines = File.ReadAllLines(_manager.folderName + "/log.txt");
                List<string> fixedLines = new List<string>();
                for (int i = 0; i < lines.Length; i++) 
                {
                    if (lines[i] != "") 
                    {
                        fixedLines.Add(lines[i]);
                    }
                }
                for (int i = 0;i<lines.Length; i++)
                {
                    try
                    {
                       
                        string[] std = fixedLines[i].Split(';');
                        
                        {
                            int j = 0;
                            excelWorksheet.Cells[i + 3, j + 1] = std[0];
                            excelWorksheet.Cells[i + 3, j + 2] = std[1];
                            excelWorksheet.Cells[i + 3, j + 3] = std[2];
                            excelWorksheet.Cells[i + 3, j + 4] = std[3];
                            excelWorksheet.Cells[i + 3, j + 5] = std[4];
                            excelWorksheet.Cells[i + 3, j + 6] = std[5];
                            excelWorksheet.Cells[i + 3, j + 7] = std[6];
                            excelWorksheet.Cells[i + 3, j + 8] = std[7];
                            excelWorksheet.Cells[i + 3, j + 9] = std[8];
                            excelWorksheet.Cells[i + 3, j + 10] = std[9];
                            excelWorksheet.Cells[i + 3, j + 11] = std[10];
                            excelWorksheet.Cells[i + 3, j + 12] = std[11];
                            excelWorksheet.Cells[i + 3, j + 13] = std[12];
                            excelWorksheet.Cells[i + 3, j + 14] = std[13];
                        }
                       
                    }

                    catch { }
                        
                        
                        
                }

                
            }

        }

        private void вставитьЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Неразрушающий контроль" + "/Неразрушающий контроль маршрут - " + value.Text + ".txt"))
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
            TableInit(_manager.folderName + @"/Неразрушающий контроль" + "/Неразрушающий контроль маршрут - " + value.Text + ".txt");
        }

        private void редакторСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Редактор re = new Редактор(_manager);
            re.Show();
        }

        private void add_row_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, dataGridView1.RowCount - 1].Value = dataGridView1[0, 0].Value;


            string path = _manager.folderName + @"/Неразрушающий контроль" + "/Неразрушающий контроль маршрут - " + value.Text + ".txt";
            if (!File.Exists(path))
            {
                Save(path);
            }
            else
            {
                Save(path);
            }
            ReNumber();
        }

        private void del_row_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Элемент будет удалён!", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (checkBox1.Checked)
                {
                    int index = dataGridView1.CurrentRow.Index;
                    string def = dataGridView1[4, index].Value.ToString();
                    dataGridView1.Rows.RemoveAt(index);

                    if (dataGridView1.Rows.Count != 0) 
                    {
                        
                        for (int i = 0; i <= dataGridView1.Rows.Count+1; i++) 
                        {
                            try
                            {
                                if (dataGridView1[4, i].Value.ToString() == def)
                                {
                                    dataGridView1.Rows.RemoveAt(i);
                                }
                            }
                            catch
                            { }
                        }
                    }
                }
                else 
                {
                    if (dataGridView1.Rows.Count != 0)
                    {
                        int index = dataGridView1.CurrentRow.Index;
                        dataGridView1.Rows.RemoveAt(index);
                    }
                }
                

                ReNumber();
            }
            else { }
        }
        void TableSaver()
        {
            string path = _manager.folderName + @"/Неразрушающий контроль" + "/Неразрушающий контроль маршрут - " + value.Text + ".txt";
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

        

        private void Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string path = _manager.folderName + @"/Неразрушающий контроль" + "/Неразрушающий контроль маршрут - " + value.Text + ".txt";
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

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ_SizeChanged(object sender, EventArgs e)
        {
            note.Width = dataGridView1.Width - 1070;
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
                        try
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
                        catch { }
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
        }

        private void отменитьПоследнееДействиеToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
