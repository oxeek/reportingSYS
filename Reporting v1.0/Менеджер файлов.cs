using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Image = System.Drawing.Image;
using System.Text.RegularExpressions;
using SautinSoft;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Spire.Doc;
using Spire.Doc.Documents;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;
using Section = Spire.Doc.Section;
using Paragraph = Spire.Doc.Documents.Paragraph;
using Spire.Doc.Formatting;
using System.Runtime.InteropServices;
using System.Threading;

namespace Reporting_v1._0
{
    public partial class Менеджер_файлов : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();
        DateTimePicker _start = new DateTimePicker();
        DateTimePicker _end = new DateTimePicker();

        string mainn = Environment.CurrentDirectory;
        public Менеджер_файлов(Manager manager, TextBox box, DateTimePicker start, DateTimePicker end)
        {
            _start = start;
            _end = end;
            _manager = manager;
            value = box;
            InitializeComponent();
            comboBox1.SelectedItem = ".csv";
            
        }
        private void Менеджер_файлов_Load(object sender, EventArgs e)
        {
            //timer2.Stop();

            try
            {
                if (File.Exists(_manager.folderName + @"/Маршруты/Поиск.txt"))
                {
                    dataGridView1.Rows.Clear();
                    string[] info = File.ReadAllLines(_manager.folderName + @"/Маршруты/Поиск.txt");
                    string path = info[0];
                    string pattern = info[1];

                    _manager.FindingPath = path;
                    linkLabel1.Text = path;

                    string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);

                    for (int i = 0; i < files.Length; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, i].Value = i + 1;
                        dataGridView1[1, i].Value = files[i];
                        dataGridView1[2, i].Value = Path.GetFileName(files[i]);
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Ранее используемые файлы не найдены. Возможно изменился путь. Отсортируйте файлы ещё раз!");
            }
            
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[3].Value = false;
            }
            file_path.Width = dataGridView1.Width - 323;
        }

        void processCountRefresh(string name) 
        {
            int processes_count = 0;
            Process[] processes = Process.GetProcessesByName(name); // Получим все процессы Google Chrome

            foreach (Process process in processes) // В цикле их переберём
            {
                processes_count++;
            }
            label7.Text = processes_count.ToString();
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }
        void Searching() 
        {
            dataGridView1.Rows.Clear();

            string searchingPattern = "*" + textBox1.Text + "*" + comboBox1.SelectedItem;
            string[] files = Directory.GetFiles(_manager.FindingPath, searchingPattern, SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = i + 1;
                dataGridView1[1, i].Value = files[i];
                dataGridView1[2, i].Value = Path.GetFileName(files[i]);
            }

            using (File.Create(_manager.folderName + @"/Маршруты/Поиск.txt")) ;
            using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Поиск.txt"))
            {
                sw.WriteLine(_manager.FindingPath);
                sw.WriteLine(searchingPattern);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_manager.FindingPath != null)
            {
                Searching();
            }
            else MessageBox.Show("Путь не выбран!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            if (fdb.ShowDialog() == DialogResult.OK) 
            {
                _manager.FindingPath = fdb.SelectedPath;
                linkLabel1.Text = _manager.FindingPath;
                if (File.Exists(_manager.folderName + @"/Маршруты/Поиск.txt")) { File.Delete(_manager.folderName + @"/Маршруты/Поиск.txt"); }
            }
        }

        
        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("explorer.exe", _manager.FindingPath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_manager.FindingPath == null)
            {
                MessageBox.Show("Путь не выбран!");
            }
            else
            {

                if (comboBox1.SelectedItem.ToString() == ".csv") 
                {
                    for (int fff = 0; fff < dataGridView1.Rows.Count; fff++) 
                    {
                        try 
                        {
                            if ((bool)dataGridView1[3, fff].Value)
                            {
                                string[] fileName = dataGridView1[2, fff].Value.ToString().Split('-');
                                string[] first = fileName[0].Split('_');
                                int number = Convert.ToInt32(first[0]);

                                if (File.Exists(_manager.folderName + @"/Неразрушающий контроль" + @"/Неразрушающий контроль маршрут - " + number + ".txt"))
                                {
                                    File.Delete(_manager.folderName + @"/Неразрушающий контроль" + @"/Неразрушающий контроль маршрут - " + number + ".txt");
                                }

                            }
                        } 
                        catch { }
                        
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        if ((bool)dataGridView1[3, i].Value)
                        {
                            string[] fileName = dataGridView1[2, i].Value.ToString().Split('-');
                            string[] first = fileName[0].Split('_');
                            int number = Convert.ToInt32(first[0]);
                            int elem_num = Convert.ToInt32(first[1]) + 1;
                            string path = _manager.folderName + @"/Неразрушающий контроль" + @"/Неразрушающий контроль маршрут - " + number + ".txt";
                            if (!File.Exists(path))
                            {
                                using (File.Create(path)) ;

                                using (StreamWriter sw = new StreamWriter(path, true))
                                {
                                    string[] file = File.ReadAllLines(dataGridView1[1, i].Value.ToString(), Encoding.Default);
                                    for (int k = 0; k < file.Length; k++)
                                    {
                                        string[] csv = file[k].Split(';');
                                        sw.WriteLine(number + ";" + elem_num + ";" + ";" + csv[1] + ";" + csv[2] + ";" + csv[3] + ";" /*+ csv[4] + ";"*/
                                                                 + csv[5] + ";" + csv[6] + ";" + csv[7] + ";"  + csv[8] + ";" +  csv[9] + ";" + ";");
                                    }
                                }
                            }

                            else
                            {
                                using (StreamWriter sw = new StreamWriter(path, true))
                                {
                                    string[] file = File.ReadAllLines(dataGridView1[1, i].Value.ToString(), Encoding.Default);
                                    for (int k = 0; k < file.Length; k++)
                                    {
                                        string[] csv = file[k].Split(';');
                                        //sw.WriteLine(number + ";" + elem_num + ";" + ";" + csv[1] + ";" + csv[2] + ";" + csv[3] + ";" + csv[4] + ";"
                                        //                         + csv[5] + ";" + csv[6] + ";"+ csv[7] + ";" + csv[8] + ";" + ";" /*ДОБАВЛЕНО НОВОЕ*/  + csv[9]);
                                        sw.WriteLine(number + ";" + elem_num + ";" + ";" + csv[1] + ";" + csv[2] + ";" + csv[3] + ";" /*+ csv[4] + ";"*/
                                                                 + csv[5] + ";" + csv[6] + ";" + csv[7] + ";" + csv[8] + ";" /*ДОБАВЛЕНО НОВОЕ*/ + csv[9] + ";" + ";");
                                    }
                                }
                            }

                            string[] _filesPath = Directory.GetFiles(_manager.folderName+ "/Неразрушающий контроль");
                            List<string> _fileWithoutPath = new List<string>();

                            for (int pp = 0; pp < _filesPath.Length; pp++)
                            {
                                _fileWithoutPath.Add(Path.GetFileName(_filesPath[pp]));
                            }

                            for (int p = 0; p < _filesPath.Length; p++)
                            {
                                List<string> correctly = new List<string>();
                                string[] control = File.ReadAllLines(_manager.folderName + @"/Неразрушающий контроль/" + _fileWithoutPath[p]);

                                try
                                {
                                    //VSATAVKA V NACHALO
                                    if (Convert.ToInt32(control[0].Split(';')[1]) > 1)
                                    {
                                        int currentValue = Convert.ToInt32(control[0].Split(';')[1]);
                                        for (int start = currentValue; start > 1; start--)
                                        {
                                            int num = currentValue - start + 1;
                                            correctly.Add(Convert.ToInt32(control[0].Split(';')[0]).ToString() + ";" + num + ";" + "-;" + "-;" +
                                                          "Дефектов не обнаружено" + ";" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" +/*NEW*/ "-;" );
                                        }
                                    }


                                    //VSTAVKA V SEREDINU
                                    for (int ii = 1; ii < control.Length; ii++)
                                    {
                                        string[] currentString = control[ii].Split(';');
                                        string[] anotherString = control[ii - 1].Split(';');

                                        

                                        int counter = Convert.ToInt32(currentString[1]) - Convert.ToInt32(anotherString[1]);
                                        if (counter > 1)
                                        {
                                            correctly.Add(control[ii - 1]);
                                            int num = Convert.ToInt32(anotherString[1]) + 1;
                                            for (int c = counter; c > 1; c--)
                                            {
                                                correctly.Add(Convert.ToInt32(currentString[0]).ToString() + ";" + num + ";" + "-;" + "-;" +
                                                              "Дефектов не обнаружено" + ";" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" + "-;" +/*NEW*/ "-;" );
                                                num++;
                                            }
                                        }
                                        else
                                        {

                                            correctly.Add(control[ii - 1]);
                                        }


                                    }

                                    using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Неразрушающий контроль/" + _fileWithoutPath[p]))
                                    {

                                        foreach (string str in correctly)
                                        {
                                            sw.WriteLine(str);
                                        }
                                        sw.WriteLine(control[control.Length - 1]);
                                    }
                                }
                                catch { }


                            }
                        }
                        else
                        {
                           
                        }
                       
                    }

                    


                    
                }
                if (comboBox1.SelectedItem.ToString() == ".txt") 
                {
                    
                   //ХЗ
                }
            }
            
        }

        void Print(Excel.Worksheet sheet, int estr) 
        {
            var _with1 = sheet.PageSetup;
            _with1.PrintArea = "$A$1:$L$" + estr;
            _with1.PaperSize = Excel.XlPaperSize.xlPaperA4;
            _with1.Orientation = Excel.XlPageOrientation.xlPortrait;
            _with1.FitToPagesWide = 2;
            _with1.FitToPagesTall = 2;
            _with1.ScaleWithDocHeaderFooter = true;
        }

        void CopyFile(string sourcefn, string destinfn)
        {
            
            FileInfo fn = new FileInfo(sourcefn);
            fn.CopyTo(destinfn, true);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> remover = new List<DataGridViewRow>();
            DialogResult result = MessageBox.Show("Файл будет удалён из списка!", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                #region old_content
                //if (dataGridView1.Rows.Count != 0)
                //{
                //    int index = dataGridView1.CurrentRow.Index;
                //    dataGridView1.Rows.RemoveAt(index);
                //}
                #endregion
                for (int row =0; row<dataGridView1.Rows.Count; row++)
                {

                    if ((bool)dataGridView1[3,row].Value == true)
                    {
                        remover.Add(dataGridView1.Rows[row]);
                    }
                }
            }
            else { }

            if (remover.Count > 0) 
            {
                foreach (DataGridViewRow row in remover) 
                {
                    dataGridView1.Rows.Remove(row);
                }

            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            string file = dataGridView1[1, index].Value.ToString();

            string[] peaces = file.Split('\\');
            string path="";
            for (int i = 0; i < peaces.Length - 1; i++) 
            {
                path += peaces[i] + "\\";
            }

            Process.Start("explorer.exe",path);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Менеджер_файлов_SizeChanged(object sender, EventArgs e)
        {
            file_path.Width = dataGridView1.Width - 323; 
        }
        List<string> ReadAllFiles(string dirPath)
        {
            List<string> data = new List<string>();
            for (int i = 0; i < 999; i++)
            {
                if (File.Exists(dirPath + i + ".txt"))
                {
                    using (StreamReader sr = new StreamReader(dirPath + i + ".txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            data.Add(sr.ReadLine());
                        }
                    }
                }
            }
            return data;
        }
        private Image CreateImageWithRectangle()
        {
            Image img = new Bitmap(1000, 500);

            using (Graphics gr = Graphics.FromImage(img))
            {
                Color color = Color.FromArgb(250 / 100 * 25, 217, 43, 43);
                gr.DrawRectangle(new Pen(Color.DarkBlue, 2), 0, 0, 1000, 500);

                SolidBrush br = new SolidBrush(color);

                gr.FillRectangle(br,0,0,100,100);


            }

            return img;
        }
        
        void ImageBlackGenerator(Label label25, Label label26, Color cococo) 
        {
            List<string> allELS = new List<string>();
            List<string> allVTOS = new List<string>();
            List<string> allVIKS = new List<string>();
            List<string> allMA = new List<string>();

            for (int i = 0; i < 999; i++)
            {

                if (Directory.Exists(_manager.folderName + @"/ВТО/Маршрут - " + i))
                {
                    List<string> data = ReadAllFiles(_manager.folderName + @"/ВТО/Маршрут - " + i + "/Выявленные особенности маршрут - ");
                    foreach (string dt in data)
                    {
                        allVTOS.Add(dt);
                    }
                }

            }

            if (Directory.Exists(_manager.folderName + @"/Журнал контроля"))
            {
                for (int i = 0; i < 999; i++)
                {
                    if (File.Exists(_manager.folderName + @"/Журнал контроля/Маршрут - " + i + ".txt"))
                    {
                        using (StreamReader sr = new StreamReader(_manager.folderName + @"/Журнал контроля/Маршрут - " + i + ".txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                allELS.Add(sr.ReadLine());
                            }
                        }
                    }
                }
            }

            if (Directory.Exists(_manager.folderName + @"/Неразрушающий контроль"))
            {
                for (int i = 0; i < 999; i++)
                {
                    if (File.Exists(_manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt"))
                    {
                        using (StreamReader sr = new StreamReader(_manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                allMA.Add(sr.ReadLine());
                            }
                        }
                    }
                }
            }

          

            string[] colors = File.ReadAllLines(mainn + "/src/Цвета МА.txt");
            string[] colors_vto = File.ReadAllLines(mainn + "/src/Цвета ВТО.txt");

            void shema2Gen(string picPath, string path_2, string[] el, int x2, int y2, int x3, int y3, int xleft, int yright, int xright)
            {
                Image image = Image.FromFile(picPath + path_2);
                using (Graphics gr = Graphics.FromImage(image))
                {
                    int x1 = 350;
                    int y1 = 247;



                    int count = 0;

                    gr.DrawString(el[2], label5.Font, new SolidBrush(cococo), 10, 10);

                    //left zone
                    gr.DrawString(allELS[0].Split(';')[4], label25.Font, new SolidBrush(cococo), xleft+10, yright);
                    gr.DrawString(allELS[0].Split(';')[1], label25.Font, new SolidBrush(cococo), xleft+10, yright - 23);

                    int last_element = 0;
                    int weight_element = 0;
                    int left_part_weight = 0;
                    for (int a = 0; a < allELS.Count; a++)
                    {
                        if (el[0] == allELS[a].Split(';')[0])
                        {
                            if (last_element < Convert.ToInt32(allELS[a].Split(';')[1]))
                            {
                                last_element = Convert.ToInt32(allELS[a].Split(';')[1]);
                            }

                            try
                            {
                                weight_element += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }
                        }

                        if (el[0] == allELS[a].Split(';')[0] && Convert.ToInt32(allELS[a].Split(';')[1]) < Convert.ToInt32(el[1]))
                        {
                            try
                            {
                                left_part_weight += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }

                        }
                    }

                   
                    //right zone
                    gr.DrawString(last_element.ToString(), label25.Font, new SolidBrush(cococo), xright+5, yright - 23);
                    gr.DrawString(weight_element.ToString(), label25.Font, new SolidBrush(cococo), xright+5, yright);

                    //center zone
                    gr.DrawString(el[1], label25.Font, new SolidBrush(cococo), x2, y2);
                    gr.DrawString(el[6], label25.Font, new SolidBrush(cococo), x3, y3);
                    gr.DrawString(left_part_weight.ToString(), label25.Font, new SolidBrush(cococo), x3, y3-28);

                    for (int g = 0; g < allELS.Count; g++)
                    {
                        string[] eel = allELS[g].Split(';');
                        if (count == 11)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label25.Font, new SolidBrush(cococo), x1, 219);

                                gr.DrawString(eel[5], label25.Font, new SolidBrush(cococo), x1, y1);


                                //gr.DrawString(cur_el, label25.Font, new SolidBrush(Color.Black), x1, 278);

                                x1 += 53;
                                x2 += 50;
                                x3 += 50;
                                count++;
                            }
                            else
                            {

                                //gr.DrawString("-", label25.Font, new SolidBrush(Color.Black), x1, 219);

                            }


                        }

                        if (g == allELS.Count - 1)
                        {
                            gr.FillRectangle(new SolidBrush(Color.White), x1 - 6, y1 - 20, 999, 999);
                        }



                    }


                }
                image.Save(_manager.folderName + @"/Элемент_" + el[0] + "_" + el[1] /*+ "_" + el[2]*/ + "_схема_2.png", ImageFormat.Png);
            }

            void shema2Gen_6(string picPath, string path_2, string[] el, int x2, int y2, int x3, int y3, int xleft, int yright, int xright)
            {
                Image image = Image.FromFile(picPath + path_2);
                using (Graphics gr = Graphics.FromImage(image))
                {
                    int x1 = 615; //350
                    int y1 = 247;



                    int x = 668;

                    int count = 0;

                    int revers_count = 6;

                    gr.DrawString(el[2], label5.Font, new SolidBrush(cococo), 10, 10);


                    //left zone
                    gr.DrawString(allELS[0].Split(';')[4], label25.Font, new SolidBrush(cococo), xleft+15, yright);
                    gr.DrawString(allELS[0].Split(';')[1], label25.Font, new SolidBrush(cococo), xleft+15, yright - 23);


                   

                    int last_element = 0;
                    int weight_element = 0;
                    int left_part_weight = 0;
                    for (int a = 0; a < allELS.Count; a++)
                    {
                        if (el[0] == allELS[a].Split(';')[0])
                        {
                            if (last_element < Convert.ToInt32(allELS[a].Split(';')[1]))
                            {
                                last_element = Convert.ToInt32(allELS[a].Split(';')[1]);
                            }

                            try
                            {
                                weight_element += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }

                        }

                        if (el[0] == allELS[a].Split(';')[0] && Convert.ToInt32(allELS[a].Split(';')[1]) < Convert.ToInt32(el[1]))
                        {
                            try
                            {
                                left_part_weight += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }

                        }


                    }

                    //right zone
                    gr.DrawString(last_element.ToString(), label25.Font, new SolidBrush(cococo), xright+10, yright - 23);
                    gr.DrawString(weight_element.ToString(), label25.Font, new SolidBrush(cococo), xright+10, yright);

                    //center zone
                    gr.DrawString(el[1], label25.Font, new SolidBrush(cococo), x2, y2);
                    gr.DrawString(el[6], label25.Font, new SolidBrush(cococo), x3, y3);
                    gr.DrawString(weight_element.ToString(), label25.Font, new SolidBrush(cococo), x3, y3-28);

                    for (int g = Convert.ToInt32(el[1]) - 1; g > 0; g--)
                    {
                        string[] eel = allELS[g].Split(';');
                        if (revers_count == 0)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label25.Font, new SolidBrush(cococo), x1, 219);

                                gr.DrawString(eel[5], label25.Font, new SolidBrush(cococo), x1, y1);


                                //gr.DrawString(eel[2], label25.Font, new SolidBrush(Color.Black), x1+53, 278);

                                x1 -= 53;
                                x2 += 50;
                                x3 += 50;
                                revers_count--;
                            }
                            else
                            {

                            }

                        }
                    }

                    for (int g = Convert.ToInt32(el[1]); g < allELS.Count; g++)
                    {
                        string[] eel = allELS[g].Split(';');
                        if (count == 9)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label25.Font, new SolidBrush(cococo), x, 219);

                                gr.DrawString(eel[5], label25.Font, new SolidBrush(cococo), x, y1);

                                //gr.DrawString(eel[2], label25.Font, new SolidBrush(Color.Black), x1, 278);

                                x += 53;
                                x1 += 53;
                                x2 += 50;
                                x3 += 50;
                                count++;
                            }
                            else
                            {

                            }



                        }
                        if (g == allELS.Count - 1)
                        {

                        }

                        count++;
                    }
                    gr.FillRectangle(new SolidBrush(Color.White), x - 6, y1 - 20, 999, 999);
                    gr.FillRectangle(new SolidBrush(Color.White), 926, 216, 999, 999);

                }
                image.Save(_manager.folderName + @"/Элемент_" + el[0] + "_" + el[1] /*+ "_" + el[2]*/ + "_схема_2.png", ImageFormat.Png);
            }



            for (int i = 0; i < allELS.Count; i++)
            {


                string[] el = allELS[i].Split(';');


                #region shema2_load

                string picPath = mainn + @"\patterns\details patts\";

                if (Convert.ToInt32(el[1]) == 1)
                {
                    shema2Gen(picPath, "Элемент_1.png", el, 400, 45, 400, 101, 115, 175, 620);
                }

                if (Convert.ToInt32(el[1]) == 2)
                {
                    shema2Gen(picPath, "Элемент_2.png", el, 450, 45, 450, 101, 165, 175, 670);
                }

                if (Convert.ToInt32(el[1]) == 3)
                {
                    shema2Gen(picPath, "Элемент_3.png", el, 500, 45, 500, 101, 205, 175, 720);
                }

                if (Convert.ToInt32(el[1]) == 4)
                {
                    shema2Gen(picPath, "Элемент_4.png", el, 550, 45, 550, 101, 255, 175, 770);
                }

                if (Convert.ToInt32(el[1]) == 5)
                {
                    shema2Gen(picPath, "Элемент_5.png", el, 600, 45, 600, 101, 305, 175, 820);
                }

                if (Convert.ToInt32(el[1]) >= 6)
                {
                    shema2Gen_6(picPath, "Элемент_6.png", el, 650, 45, 650, 101, 355, 175, 870);
                }



                #endregion

                double height = 0;
                double weight = 0;
                try
                {
                    height = Convert.ToDouble(el[3]) * 100;
                    weight = Convert.ToDouble(el[5]) * 100 - Convert.ToDouble(el[6]) / 10;
                }
                catch 
                {
                    break;
                }
                

                List<string> osob = new List<string>();

                int defs = 0;

                int pad_x = 140; //60
                int pad_y = 40; //20

                int bit_weight = Convert.ToInt32(weight + pad_x + 20)+100;
                int bit_height = Convert.ToInt32(height + 50 + pad_y);

                Image img = new Bitmap(bit_weight, bit_height);


                using (Graphics gr = Graphics.FromImage(img))
                {
                    gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height);

                    if (CHBready.Checked) 
                    {
                        gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height - 50);
                    }
                    else  gr.FillRectangle(new SolidBrush(Color.FromArgb(1, 13, 77)), 0, 0, bit_weight, bit_height - 50);
                    

                    int horizont_count = 0;
                    for (int x = pad_x; x < bit_weight; x += 100)
                    {
                        if (CHBready.Checked)
                        {
                            gr.DrawLine(new Pen(Color.Black), x, 5, x, Convert.ToInt32(height + 25));
                            gr.DrawString(horizont_count.ToString() + " м", label25.Font, new SolidBrush(Color.Black), x - 9, Convert.ToInt32(height + 25));
                        }
                        else 
                        {
                            gr.DrawLine(new Pen(Color.White), x, 5, x, Convert.ToInt32(height + 25));
                            gr.DrawString(horizont_count.ToString() + " м", label25.Font, new SolidBrush(Color.White), x - 9, Convert.ToInt32(height + 25));
                        }
                        
                        horizont_count++;
                    }

                    double vert = height / 12;

                    //MessageBox.Show(count_of_30.ToString());


                    int vert_count = 0;
                    int grad = 0;

                    if (CHBready.Checked)
                    {
                        gr.DrawString("  гр.", label25.Font, new SolidBrush(Color.Black), 0, 0);
                        gr.DrawString(" ч.", label25.Font, new SolidBrush(Color.Black), 35, 0);
                    }
                    else 
                    {
                        gr.DrawString("  гр.", label25.Font, new SolidBrush(Color.White), 0, 0);
                        gr.DrawString(" ч.", label25.Font, new SolidBrush(Color.White), 35, 0);
                    }
                        

                    for (int y = pad_y - 20; y < bit_height; y += Convert.ToInt32(vert))
                    {
                        if (vert_count <= 12)
                        {
                            if(CHBready.Checked) gr.DrawLine(new Pen(Color.Black), pad_x - 80, y, bit_weight - 15, y);

                            else gr.DrawLine(new Pen(Color.White), pad_x - 80, y, bit_weight - 15, y);


                            string n = "";
                            if (vert_count < 10)
                            {
                                n = " " + vert_count;
                            }
                            else n = vert_count.ToString();

                            if (CHBready.Checked) gr.DrawString(n, label25.Font, new SolidBrush(Color.Black), pad_x - 26-80, y - 5);
                            else gr.DrawString(n, label25.Font, new SolidBrush(Color.White), pad_x - 26 - 80, y - 5);
                            
                            vert_count++;

                            if (CHBready.Checked) gr.DrawLine(new Pen(Color.Black), 24, y, 30, y);
                            else gr.DrawLine(new Pen(Color.White), 24, y, 30, y);

                            string nn = "";
                            if (grad < 100)
                            {
                                if (grad == 0)
                                {
                                    nn += "  " + grad;
                                }
                                else nn += " " + grad;
                            }
                            else nn = grad.ToString();

                            if (CHBready.Checked)
                                gr.DrawString(nn, label25.Font, new SolidBrush(Color.Black), 0, y - 5);
                            else
                            {
                                gr.DrawString(nn, label25.Font, new SolidBrush(Color.White), 0, y - 5);
                            }

                            grad += 30;
                        }
                    }

                    if (CHBready.Checked)
                        gr.DrawLine(new Pen(Color.Black), 27, 5, 27, Convert.ToInt32(height + 25));
                    else gr.DrawLine(new Pen(Color.White), 27, 5, 27, Convert.ToInt32(height + 25));

                    //PRODOLNIE SHVI


                    try 
                    {
                        if (Convert.ToInt32(el[1]) > 1)
                        {
                            double shov_one = Convert.ToDouble(el[8]);
                            double shov_two = Convert.ToDouble(el[9]);

                            double svov_one_1 = Convert.ToInt32(allELS[i-1].Split(';')[8]);
                            double svov_two_1 = Convert.ToInt32(allELS[i - 1].Split(';')[9]);

                            double svov_one_2 = Convert.ToInt32(allELS[i + 1].Split(';')[8]);
                            double svov_two_2 = Convert.ToInt32(allELS[i + 1].Split(';')[9]);

                            double cc_of_30 = height / 360;
                            Math.Round(cc_of_30, 0);

                            gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_one * cc_of_30 + pad_y / 2), Convert.ToInt32(weight)+5, 2);
                            gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_two * cc_of_30 + pad_y / 2), Convert.ToInt32(weight)+5, 2);

                            gr.FillRectangle(new SolidBrush(Color.Red), pad_x-80, Convert.ToInt32(svov_one_1 * cc_of_30 + pad_y / 2), pad_x/2+10, 2);
                            gr.FillRectangle(new SolidBrush(Color.Red), pad_x-80, Convert.ToInt32(svov_two_1 * cc_of_30 + pad_y / 2), pad_x/2+10, 2);

                            gr.FillRectangle(new SolidBrush(Color.Red), Convert.ToInt32(weight)+pad_x+5, Convert.ToInt32(svov_one_2 * cc_of_30 + pad_y / 2),80 , 2);
                            gr.FillRectangle(new SolidBrush(Color.Red), Convert.ToInt32(weight)+pad_x+5, Convert.ToInt32(svov_two_2 * cc_of_30 + pad_y / 2), 80, 2);

                        }
                        else 
                        {
                            double shov_one = Convert.ToDouble(el[8]);
                            double shov_two = Convert.ToDouble(el[9]);

                            double cc_of_30 = height / 360;
                            Math.Round(cc_of_30, 0);

                            gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_one * cc_of_30 + pad_y / 2), Convert.ToInt32(weight), 2);

                            gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_two * cc_of_30 + pad_y / 2), Convert.ToInt32(weight), 2);
                        }

                        
                    } 
                    catch
                    {
                    
                    }

                                             

                    //PRODOLNIE SHVI END

                    for (int k = 0; k < allVTOS.Count; k++)
                    {
                        try
                        {

                        }
                        catch { }
                        string[] vto = allVTOS[k].Split(';');

                        if (vto[0] == el[0] && vto[1] == el[1] && !vto[2].ToString().Contains("-"))
                        {
                            double vto_x1 = Convert.ToDouble(vto[4]) * 100;
                            double vto_x2 = Convert.ToDouble(vto[5]) * 100;

                            double vto_y1 = Convert.ToDouble(vto[6]);
                            double vto_y2 = Math.Round(Convert.ToDouble(vto[9]) / 10, 0);


                            //double vto_w = (Convert.ToDouble(vto[8])) / 10;
                            //double vto_h = (Convert.ToDouble(vto[9])) / 10;

                            ////double vto_x = (
                            //double vto_y = (Convert.ToDouble(vto[5])) * 100;

                            Color coco = Color.FromArgb(300 / 100 * 30, 0, 0, 0);
                            SolidBrush br = new SolidBrush(coco);

                            if (CHBready.Checked)
                            {
                                Color fontCol = Color.White;
                                SolidBrush fontBr = new SolidBrush(fontCol);
                            }
                            else 
                            {
                                Color fontCol = Color.Black;
                                SolidBrush fontBr = new SolidBrush(fontCol);
                            }
                            

                            //osob.Add("Механическое повреждение" + ";" + 255 + "," + 5 + "," + 188);

                            for (int c = 0; c < colors_vto.Length; c++)
                            {
                                if (vto[3].Contains(colors_vto[c].Split(';')[0]))
                                {
                                    string[] col = colors_vto[c].Split(';')[1].Split(',');

                                    int r = Convert.ToInt32(col[0]);
                                    int g = Convert.ToInt32(col[1]);
                                    int b = Convert.ToInt32(col[2]);
                                    int alpha = Convert.ToInt32(col[3]);

                                    Color color = Color.FromArgb(alpha, r, g, b);
                                    br = new SolidBrush(color);
                                    Color color1 = Color.FromArgb(r, g, b);
                                    if (osob.Count == 0)
                                    {
                                        osob.Add(colors_vto[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                    }
                                    else
                                    {
                                        int s = 0;
                                        for (int co = 0; co < osob.Count; co++)
                                        {
                                            string[] cl = osob[co].Split(';')[1].Split(',');
                                            int rr = Convert.ToInt32(cl[0]);
                                            int gg = Convert.ToInt32(cl[1]);
                                            int bb = Convert.ToInt32(cl[2]);

                                            Color cll = Color.FromArgb(rr, gg, bb);

                                            if (color1 == cll)
                                            {
                                                s++;
                                            }
                                        }

                                        if (s == 0)
                                        {
                                            osob.Add(colors_vto[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                        }
                                    }

                                }
                            }
                            //TODO RASHET RASPOLOJENIYA






                            //gr.FillRectangle(br, Convert.ToInt32(vto_x)+pad_x+1/*- Convert.ToInt32(vto_w)/2*/, Convert.ToInt32(vto_y)+pad_y+1/* - Convert.ToInt32(vto_y)/2*/,
                            //                     Convert.ToInt32(vto_w),                           Convert.ToInt32(vto_y));

                            double c_of_30 = height / 360;
                            Math.Round(c_of_30, 0);

                            gr.FillRectangle(br,
                                                                        Convert.ToInt32(vto_x1) + pad_x,                        //x1

                                                                         Convert.ToInt32(vto_y1 * c_of_30) + pad_y / 2,         //y1

                                                                         Convert.ToInt32(vto_x2),                               //x2

                                                                        Convert.ToInt32(vto_y2));                               //y2

                            if (CHBready.Checked) gr.DrawString(vto[0] + "." + vto[2], label26.Font, new SolidBrush(Color.Black),
                                          Convert.ToInt32(vto_x1) + pad_x + 1,
                                          Convert.ToInt32(vto_y1) + pad_y / 2 - label26.Font.Size * 2);

                            else gr.DrawString(vto[0] + "." + vto[2], label26.Font, new SolidBrush(Color.White),
                                          Convert.ToInt32(vto_x1) + pad_x + 1,
                                          Convert.ToInt32(vto_y1) + pad_y / 2 - label26.Font.Size * 2);



                            defs++;
                        }
                    }

                    for (int j = 0; j < allMA.Count; j++)
                    {
                        string[] ma = allMA[j].Split(';');

                        if (ma[0] == el[0] && ma[1] == el[1] && (!ma[3].ToString().Contains("-") || !ma[4].ToString().Contains("Дефектов не обнаружено")))
                        {
                            double ma_x1 = Math.Round(Convert.ToDouble(Rmer(ma[5])) / 10, 0);
                            double ma_x2 = Math.Round(Convert.ToDouble(Rmer(ma[8])) / 10, 0);

                            //double ma_y1 = Math.Round(Convert.ToDouble(Rmer(ma[6])) / 10, 0);
                            double ma_y2 = Math.Round(Convert.ToDouble(Rmer(ma[9])) / 10, 0);

                            double ma_y1 = Convert.ToDouble(Rmer(ma[6]));
                            //double ma_y2 = Convert.ToDouble(Rmer(ma[7]));

                            Color color = Color.FromArgb(400 / 100 * 30, 0, 0, 0); ;
                            for (int c = 0; c < colors.Length; c++)
                            {
                                if (ma[4].Contains(colors[c].Split(';')[0]))
                                {
                                    string[] col = colors[c].Split(';')[1].Split(',');

                                    int r = Convert.ToInt32(col[0]);
                                    int g = Convert.ToInt32(col[1]);
                                    int b = Convert.ToInt32(col[2]);
                                    int alpha = Convert.ToInt32(col[3]);

                                    color = Color.FromArgb(alpha, r, g, b);
                                    Color color1 = Color.FromArgb(r, g, b);
                                    if (osob.Count == 0)
                                    {
                                        osob.Add(colors[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                    }
                                    else
                                    {
                                        int s = 0;
                                        for (int co = 0; co < osob.Count; co++)
                                        {
                                            string[] cl = osob[co].Split(';')[1].Split(',');
                                            int rr = Convert.ToInt32(cl[0]);
                                            int gg = Convert.ToInt32(cl[1]);
                                            int bb = Convert.ToInt32(cl[2]);

                                            Color cll = Color.FromArgb(rr, gg, bb);

                                            if (color1 == cll)
                                            {
                                                s++;
                                            }
                                        }

                                        if (s == 0)
                                        {
                                            osob.Add(colors[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                        }
                                    }

                                }
                            }


                            SolidBrush br = new SolidBrush(color);



                            //gr.FillRectangle(br, Convert.ToInt32(ma_x)+pad_x+1, Convert.ToInt32(ma_y) +pad_y+1, 
                            //                     Convert.ToInt32(ma_w),                           Convert.ToInt32(ma_h));



                            //double one_of_meter = weight / 12;
                            //Math.Round(one_of_meter/100,0);
                            //MessageBox.Show(one_of_meter.ToString());

                            double c_of_30 = height / 360;
                            Math.Round(c_of_30, 0);

                            gr.FillRectangle(br,
                                                                        Convert.ToInt32(ma_x1) + pad_x,                        //x1

                                                                         Convert.ToInt32(ma_y1 * c_of_30) + pad_y / 2,         //y1

                                                                         Convert.ToInt32(ma_x2),                               //x2

                                                                        Convert.ToInt32(ma_y2));                               //y2

                            if(CHBready.Checked) gr.DrawString(ma[0] + "." + ma[3], label26.Font, new SolidBrush(Color.Black),
                                          Convert.ToInt32(ma_x1) + pad_x + 1,
                                          Convert.ToInt32(ma_y1) + pad_y + 1 / 2 - label26.Font.Size * 2);

                            else gr.DrawString(ma[0] + "." + ma[3], label26.Font, new SolidBrush(Color.White),
                                          Convert.ToInt32(ma_x1) + pad_x + 1,
                                          Convert.ToInt32(ma_y1) + pad_y + 1 / 2 - label26.Font.Size * 2);

                            defs++;
                        }
                    }

                    if (defs > 0)
                    {
                        
                        Color fontCol = Color.Black;
                       
                        
                        SolidBrush fontBr = new SolidBrush(fontCol);

                        //MessageBox.Show(osob.Count.ToString());

                        int maxLen = 15;

                        try
                        {
                            int le_0 = osob[0].Split(';')[0].Length;
                            int le_1 = osob[1].Split(';')[0].Length;
                            int le_2 = osob[2].Split(';')[0].Length;

                            if (le_0 > le_1 && le_0 > le_2)
                                maxLen = le_0 + 5;

                            else if (le_1 > le_2)
                                maxLen = le_1 + 5;

                            else
                                maxLen = le_2 + 5;
                        }
                        catch { }



                        //ПЕРВЫЙ СТОЛБЕЦ
                        try
                        {
                            string[] os = osob[0].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 5) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[0].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 2) + pad_y);

                        }
                        catch { }

                        try
                        {
                            string[] os = osob[1].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 20) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[1].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 17) + pad_y);

                        }
                        catch { }

                        try
                        {
                            string[] os = osob[2].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 35) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[2].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 32) + pad_y);

                        }
                        catch { }


                        //ВТОРОЙ СТОЛБЕЦ
                        try
                        {
                            string[] os = osob[3].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 5) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[3].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 2) + pad_y);
                        }
                        catch { }

                        try
                        {
                            string[] os = osob[4].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 20) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[4].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 17) + pad_y);
                        }
                        catch { }

                        try
                        {
                            string[] os = osob[5].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 35) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[5].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 32) + pad_y);
                        }
                        catch { }



                        img.Save(_manager.folderName + @"/Элемент_" + el[0] + "_" + el[1] /*+ "_" + el[2]*/ + "_.png", ImageFormat.Png) ;
                    }
                }


            }
        }

  
        void ImageWhiteGenerator(Label label25, Label label26)
        {


            List<string> allELS = new List<string>();
            List<string> allVTOS = new List<string>();
            List<string> allVIKS = new List<string>();
            List<string> allMA = new List<string>();

            for (int i = 0; i < 999; i++)
            {

                if (Directory.Exists(_manager.folderName + @"/ВТО/Маршрут - " + i))
                {
                    List<string> data = ReadAllFiles(_manager.folderName + @"/ВТО/Маршрут - " + i + "/Выявленные особенности маршрут - ");
                    foreach (string dt in data)
                    {
                        allVTOS.Add(dt);
                    }
                }

                //if (Directory.Exists(_manager.folderName + @"/ВИК/Маршрут - " + i))
                //{
                //    List<string> data = ReadAllFiles(_manager.folderName + @"/ВИК/Маршрут - " + i + "/Маршрут - ");
                //    foreach (string dt in data)
                //    {
                //        allVIKS.Add(dt);
                //    }
                //}
            }

            if (Directory.Exists(_manager.folderName + @"/Журнал контроля"))
            {
                for (int i = 0; i < 999; i++)
                {
                    if (File.Exists(_manager.folderName + @"/Журнал контроля/Маршрут - " + i + ".txt"))
                    {
                        using (StreamReader sr = new StreamReader(_manager.folderName + @"/Журнал контроля/Маршрут - " + i + ".txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                allELS.Add(sr.ReadLine());
                            }
                        }
                    }
                }
            }

            if (Directory.Exists(_manager.folderName + @"/Неразрушающий контроль"))
            {
                for (int i = 0; i < 999; i++)
                {
                    if (File.Exists(_manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt"))
                    {
                        using (StreamReader sr = new StreamReader(_manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                allMA.Add(sr.ReadLine());
                            }
                        }
                    }
                }
            }


            string[] colors = File.ReadAllLines(mainn + "/src/Цвета МА.txt");
            string[] colors_vto = File.ReadAllLines(mainn + "/src/Цвета ВТО.txt");
            for (int i = 0; i < allELS.Count; i++)
            {
                string[] el = allELS[i].Split(';');


                #region shema2_load

                string picPath =  mainn + @"\patterns\details patts\";

                if (Convert.ToInt32(el[1]) == 1)
                {
                    shema2Gen(picPath, "Элемент_1.png", el, 400, 45, 400, 101,115,175,620);
                }

                if (Convert.ToInt32(el[1]) == 2)
                {
                    shema2Gen(picPath, "Элемент_2.png", el, 450, 45, 450, 101, 165, 175, 670);
                }

                if (Convert.ToInt32(el[1]) == 3)
                {
                    shema2Gen(picPath, "Элемент_3.png", el, 500, 45, 500, 101, 205, 175, 720);
                }

                if (Convert.ToInt32(el[1]) == 4)
                {
                    shema2Gen(picPath, "Элемент_4.png", el, 550, 45, 550, 101, 255, 175, 770);
                }

                if (Convert.ToInt32(el[1]) == 5)
                {
                    shema2Gen(picPath, "Элемент_5.png", el, 600, 45, 600, 101, 305, 175, 820);
                }

                if (Convert.ToInt32(el[1]) >= 6)
                {
                    shema2Gen_6(picPath, "Элемент_6.png", el, 650, 45, 650, 101, 355, 175, 870);
                }



                #endregion

                double height = 0;
                double weight = 0;

                try
                {
                    height = Convert.ToDouble(el[3]) * 100;
                    weight = Convert.ToDouble(el[5]) * 100 - Convert.ToDouble(el[6]) / 10;
                }
                catch 
                {
                    break;
                }
                

                List<string> osob = new List<string>();

                int defs = 0;

                int pad_x = 60; //25
                int pad_y = 40; //20

                int bit_weight = Convert.ToInt32(weight + pad_x + 20);
                int bit_height = Convert.ToInt32(height + 50 + pad_y);

                Image img = new Bitmap(bit_weight, bit_height);


                using (Graphics gr = Graphics.FromImage(img))
                {
                    gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height);

                    gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height - 50);

                    int horizont_count = 0;
                    for (int x = pad_x; x < bit_weight; x += 100)
                    {
                        gr.DrawLine(new Pen(Color.Black), x, 5, x, Convert.ToInt32(height + 25));
                        gr.DrawString(horizont_count.ToString() + " м", label25.Font, new SolidBrush(Color.Black), x - 9, Convert.ToInt32(height + 25));
                        horizont_count++;
                    }

                    double vert = height / 12;

                    //MessageBox.Show(count_of_30.ToString());


                    int vert_count = 0;
                    int grad = 0;

                    gr.DrawString("  гр.", label25.Font, new SolidBrush(Color.Black), 0, 0);
                    gr.DrawString(" ч.", label25.Font, new SolidBrush(Color.Black), 35, 0);

                    for (int y = pad_y - 20; y < bit_height; y += Convert.ToInt32(vert))
                    {
                        if (vert_count <= 12)
                        {
                            gr.DrawLine(new Pen(Color.Black), pad_x - 10, y, bit_weight - 15, y);

                            string n = "";
                            if (vert_count < 10)
                            {
                                n = " " + vert_count;
                            }
                            else n = vert_count.ToString();

                            gr.DrawString(n, label25.Font, new SolidBrush(Color.Black), pad_x - 26, y - 5);
                            vert_count++;

                            gr.DrawLine(new Pen(Color.Black), 24, y, 30, y);

                            string nn = "";
                            if (grad < 100)
                            {
                                if (grad == 0)
                                {
                                    nn += "  " + grad;
                                }
                                else nn += " " + grad;
                            }
                            else nn = grad.ToString();

                            gr.DrawString(nn, label25.Font, new SolidBrush(Color.Black), 0, y - 5);
                            grad += 30;
                        }
                    }

                    gr.DrawLine(new Pen(Color.Black), 27, 5, 27, Convert.ToInt32(height + 25));


                    for (int k = 0; k < allVTOS.Count; k++)
                    {
                        try
                        {

                        }
                        catch { }
                        string[] vto = allVTOS[k].Split(';');

                        if (vto[0] == el[0] && vto[1] == el[1] && !vto[2].ToString().Contains("-"))
                        {
                            double vto_x1 = Convert.ToDouble(vto[4]) * 100;
                            double vto_x2 = Convert.ToDouble(vto[5]) * 100;

                            double vto_y1 = Convert.ToDouble(vto[6]);
                            double vto_y2 = Math.Round(Convert.ToDouble(vto[9]) / 10, 0);


                            //double vto_w = (Convert.ToDouble(vto[8])) / 10;
                            //double vto_h = (Convert.ToDouble(vto[9])) / 10;

                            ////double vto_x = (
                            //double vto_y = (Convert.ToDouble(vto[5])) * 100;

                            Color coco = Color.FromArgb(300 / 100 * 30, 0, 0, 0);
                            SolidBrush br = new SolidBrush(coco); ;
                            Color fontCol = Color.Black;
                            SolidBrush fontBr = new SolidBrush(fontCol);

                            //osob.Add("Механическое повреждение" + ";" + 255 + "," + 5 + "," + 188);

                            for (int c = 0; c < colors_vto.Length; c++)
                            {
                                if (vto[3].Contains(colors_vto[c].Split(';')[0]))
                                {
                                    string[] col = colors_vto[c].Split(';')[1].Split(',');

                                    int r = Convert.ToInt32(col[0]);
                                    int g = Convert.ToInt32(col[1]);
                                    int b = Convert.ToInt32(col[2]);
                                    int alpha = Convert.ToInt32(col[3]);

                                    Color color = Color.FromArgb(alpha, r, g, b);
                                    br = new SolidBrush(color);
                                    Color color1 = Color.FromArgb(r, g, b);
                                    if (osob.Count == 0)
                                    {
                                        osob.Add(colors_vto[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                    }
                                    else
                                    {
                                        int s = 0;
                                        for (int co = 0; co < osob.Count; co++)
                                        {
                                            string[] cl = osob[co].Split(';')[1].Split(',');
                                            int rr = Convert.ToInt32(cl[0]);
                                            int gg = Convert.ToInt32(cl[1]);
                                            int bb = Convert.ToInt32(cl[2]);

                                            Color cll = Color.FromArgb(rr, gg, bb);

                                            if (color1 == cll)
                                            {
                                                s++;
                                            }
                                        }

                                        if (s == 0)
                                        {
                                            osob.Add(colors_vto[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                        }
                                    }

                                }
                            }
                            //TODO RASHET RASPOLOJENIYA






                            //gr.FillRectangle(br, Convert.ToInt32(vto_x)+pad_x+1/*- Convert.ToInt32(vto_w)/2*/, Convert.ToInt32(vto_y)+pad_y+1/* - Convert.ToInt32(vto_y)/2*/,
                            //                     Convert.ToInt32(vto_w),                           Convert.ToInt32(vto_y));

                            double c_of_30 = height / 360;
                            Math.Round(c_of_30, 0);

                            gr.FillRectangle(br,
                                                                        Convert.ToInt32(vto_x1) + pad_x,                        //x1

                                                                         Convert.ToInt32(vto_y1 * c_of_30) + pad_y / 2,         //y1

                                                                         Convert.ToInt32(vto_x2),                               //x2

                                                                        Convert.ToInt32(vto_y2));                               //y2

                            gr.DrawString(vto[0] + "." + vto[2], label26.Font, new SolidBrush(Color.Black),
                                          Convert.ToInt32(vto_x1) + pad_x + 1,
                                          Convert.ToInt32(vto_y1) + pad_y / 2 - label26.Font.Size * 2);

                            defs++;
                        }
                    }

                    for (int j = 0; j < allMA.Count; j++)
                    {
                        string[] ma = allMA[j].Split(';');

                        if (ma[0] == el[0] && ma[1] == el[1] && (!ma[3].ToString().Contains("-") || !ma[4].ToString().Contains("Дефектов не обнаружено")))
                        {
                            double ma_x1 = Math.Round(Convert.ToDouble(Rmer(ma[5])) / 10, 0);
                            double ma_x2 = Math.Round(Convert.ToDouble(Rmer(ma[8])) / 10, 0);

                            //double ma_y1 = Math.Round(Convert.ToDouble(Rmer(ma[6])) / 10, 0);
                            double ma_y2 = Math.Round(Convert.ToDouble(Rmer(ma[9])) / 10, 0);

                            double ma_y1 = Convert.ToDouble(Rmer(ma[6]));
                            //double ma_y2 = Convert.ToDouble(Rmer(ma[7]));

                            Color color = Color.FromArgb(400 / 100 * 30, 0, 0, 0); ;
                            for (int c = 0; c < colors.Length; c++)
                            {
                                if (ma[4].Contains(colors[c].Split(';')[0]))
                                {
                                    string[] col = colors[c].Split(';')[1].Split(',');

                                    int r = Convert.ToInt32(col[0]);
                                    int g = Convert.ToInt32(col[1]);
                                    int b = Convert.ToInt32(col[2]);
                                    int alpha = Convert.ToInt32(col[3]);

                                    color = Color.FromArgb(alpha, r, g, b);
                                    Color color1 = Color.FromArgb(r, g, b);
                                    if (osob.Count == 0)
                                    {
                                        osob.Add(colors[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                    }
                                    else
                                    {
                                        int s = 0;
                                        for (int co = 0; co < osob.Count; co++)
                                        {
                                            string[] cl = osob[co].Split(';')[1].Split(',');
                                            int rr = Convert.ToInt32(cl[0]);
                                            int gg = Convert.ToInt32(cl[1]);
                                            int bb = Convert.ToInt32(cl[2]);

                                            Color cll = Color.FromArgb(rr, gg, bb);

                                            if (color1 == cll)
                                            {
                                                s++;
                                            }
                                        }

                                        if (s == 0)
                                        {
                                            osob.Add(colors[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                                        }
                                    }

                                }
                            }


                            SolidBrush br = new SolidBrush(color);



                            //gr.FillRectangle(br, Convert.ToInt32(ma_x)+pad_x+1, Convert.ToInt32(ma_y) +pad_y+1, 
                            //                     Convert.ToInt32(ma_w),                           Convert.ToInt32(ma_h));



                            //double one_of_meter = weight / 12;
                            //Math.Round(one_of_meter/100,0);
                            //MessageBox.Show(one_of_meter.ToString());

                            double c_of_30 = height / 360;
                            Math.Round(c_of_30, 0);

                            gr.FillRectangle(br,
                                                                        Convert.ToInt32(ma_x1) + pad_x,                        //x1

                                                                         Convert.ToInt32(ma_y1 * c_of_30) + pad_y / 2,         //y1

                                                                         Convert.ToInt32(ma_x2),                               //x2

                                                                        Convert.ToInt32(ma_y2));                               //y2

                            gr.DrawString(ma[0] + "." + ma[3], label26.Font, new SolidBrush(Color.Black),
                                          Convert.ToInt32(ma_x1) + pad_x + 1,
                                          Convert.ToInt32(ma_y1) + pad_y + 1 / 2 - label26.Font.Size * 2);

                            defs++;
                        }
                    }

                    if (defs > 0)
                    {
                        Color fontCol = Color.Black;
                        SolidBrush fontBr = new SolidBrush(fontCol);

                        //MessageBox.Show(osob.Count.ToString());

                        int maxLen = 15;

                        try
                        {
                            int le_0 = osob[0].Split(';')[0].Length;
                            int le_1 = osob[1].Split(';')[0].Length;
                            int le_2 = osob[2].Split(';')[0].Length;

                            if (le_0 > le_1 && le_0 > le_2)
                                maxLen = le_0 + 5;

                            else if (le_1 > le_2)
                                maxLen = le_1 + 5;

                            else
                                maxLen = le_2 + 5;
                        }
                        catch { }



                        //ПЕРВЫЙ СТОЛБЕЦ
                        try
                        {
                            string[] os = osob[0].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 5) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[0].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 2) + pad_y);

                        }
                        catch { }

                        try
                        {
                            string[] os = osob[1].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 20) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[1].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 17) + pad_y);

                        }
                        catch { }

                        try
                        {
                            string[] os = osob[2].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 35) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[2].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 32) + pad_y);

                        }
                        catch { }


                        //ВТОРОЙ СТОЛБЕЦ
                        try
                        {
                            string[] os = osob[3].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 5) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[3].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 2) + pad_y);
                        }
                        catch { }

                        try
                        {
                            string[] os = osob[4].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 20) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[4].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 17) + pad_y);
                        }
                        catch { }

                        try
                        {
                            string[] os = osob[5].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 35) + pad_y, 9, 9);
                            gr.DrawString("   - " + osob[5].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 32) + pad_y);
                        }
                        catch { }



                        img.Save(_manager.folderName + @"/Элемент_" + el[0] + "_" + el[1] /*+ "_" + el[2]*/ + "_.png", ImageFormat.Png);
                    }
                }


            }
            void shema2Gen(string picPath, string path_2, string[] el, int x2, int y2, int x3, int y3, int xleft, int yright, int xright)
            {
                Image image = Image.FromFile(picPath + path_2);
                using (Graphics gr = Graphics.FromImage(image))
                {
                    int x1 = 350;
                    int y1 = 247;

                    

                    int count = 0;

                    gr.DrawString(el[2], label5.Font, new SolidBrush(Color.Black), 10, 10);

                    //left zone
                    gr.DrawString(allELS[0].Split(';')[4], label25.Font, new SolidBrush(Color.Black), xleft, yright);
                    gr.DrawString(allELS[0].Split(';')[1], label25.Font, new SolidBrush(Color.Black), xleft, yright-23);

                    

                    int last_element = 0;
                    int weight_element = 0;
                    int left_part_weight = 0;
                    for (int a = 0; a < allELS.Count; a++)
                    {
                        if (el[0] == allELS[a].Split(';')[0])
                        {
                            if (last_element < Convert.ToInt32(allELS[a].Split(';')[1]))
                            {
                                last_element = Convert.ToInt32(allELS[a].Split(';')[1]);
                            }
                            try
                            {
                                weight_element += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }

                        }

                        if (el[0] == allELS[a].Split(';')[0] && Convert.ToInt32(allELS[a].Split(';')[1]) < Convert.ToInt32(el[1])) 
                        {
                            try
                            {
                                left_part_weight += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }
                            
                        }

                        

                    }

                    //right zone
                    gr.DrawString(last_element.ToString(), label25.Font, new SolidBrush(Color.Black), xright, yright-23);
                    gr.DrawString(weight_element.ToString(), label25.Font, new SolidBrush(Color.Black), xright, yright);
                    gr.DrawString(left_part_weight.ToString(), label25.Font, new SolidBrush(Color.Black), 20, 20);

                    //center zone
                    gr.DrawString(el[1], label25.Font, new SolidBrush(Color.Black), x2, y2);
                    gr.DrawString(el[6], label25.Font, new SolidBrush(Color.Black), x3, y3);
                    gr.DrawString(left_part_weight.ToString(), label25.Font, new SolidBrush(Color.Black), x3, y3-25);

                    for (int g = 0; g < allELS.Count; g++)
                    {
                        string[] eel = allELS[g].Split(';');
                        if (count == 11)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label25.Font, new SolidBrush(Color.Black), x1, 219);

                                gr.DrawString(eel[5], label25.Font, new SolidBrush(Color.Black), x1, y1);


                                //gr.DrawString(cur_el, label25.Font, new SolidBrush(Color.Black), x1, 278);

                                x1 += 53;
                                x2 += 50;
                                x3 += 50;
                                count++;
                            }
                            else
                            {

                                //gr.DrawString("-", label25.Font, new SolidBrush(Color.Black), x1, 219);

                            }


                        }

                        if (g == allELS.Count - 1)
                        {
                            gr.FillRectangle(new SolidBrush(Color.White), x1 - 6, y1 - 20, 999, 999);
                        }



                    }


                }
                image.Save(_manager.folderName + @"/Элемент_" + el[0] + "_" + el[1] /*+ "_" + el[2]*/ + "_схема_2.png", ImageFormat.Png);
            }

            void shema2Gen_6(string picPath, string path_2, string[] el, int x2, int y2, int x3, int y3, int xleft, int yright, int xright)
            {
                Image image = Image.FromFile(picPath + path_2);
                using (Graphics gr = Graphics.FromImage(image))
                {
                    int x1 = 615; //350
                    int y1 = 247;

                    

                    int x = 668;

                    int count = 0;

                    int revers_count = 6;

                    gr.DrawString(el[2], label5.Font, new SolidBrush(Color.Black), 10, 10);


                    //left zone
                    gr.DrawString(allELS[0].Split(';')[4], label25.Font, new SolidBrush(Color.Black), xleft, yright);
                    gr.DrawString(allELS[0].Split(';')[1], label25.Font, new SolidBrush(Color.Black), xleft, yright - 23);


                   

                    

                    int last_element = 0;
                    int weight_element = 0;
                    int left_part_weight = 0;
                    for (int a = 0; a < allELS.Count; a++)
                    {
                        if (el[0] == allELS[a].Split(';')[0])
                        {
                            if (last_element < Convert.ToInt32(allELS[a].Split(';')[1]))
                            {
                                last_element = Convert.ToInt32(allELS[a].Split(';')[1]);
                            }

                            try
                            {
                                weight_element += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }
                        }
                        if (el[0] == allELS[a].Split(';')[0] && Convert.ToInt32(allELS[a].Split(';')[1]) < Convert.ToInt32(el[1]))
                        {
                            try
                            {
                                left_part_weight += Convert.ToInt32(allELS[a].Split(';')[5]);
                            }
                            catch { }

                        }


                    }

                    //center zone
                    gr.DrawString(el[1], label25.Font, new SolidBrush(Color.Black), x2, y2);
                    gr.DrawString(el[6], label25.Font, new SolidBrush(Color.Black), x3, y3);

                    //right zone
                    gr.DrawString(el[1], label25.Font, new SolidBrush(Color.Black), x2, y2);
                    gr.DrawString(el[6], label25.Font, new SolidBrush(Color.Black), x3, y3);
                    gr.DrawString(left_part_weight.ToString(), label25.Font, new SolidBrush(Color.Black), x3, y3 - 25);

                    for (int g = Convert.ToInt32(el[1]) - 1; g > 0; g--)
                    {
                        string[] eel = allELS[g].Split(';');
                        if (revers_count == 0)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label25.Font, new SolidBrush(Color.Black), x1, 219);

                                gr.DrawString(eel[5], label25.Font, new SolidBrush(Color.Black), x1, y1);


                                //gr.DrawString(eel[2], label25.Font, new SolidBrush(Color.Black), x1+53, 278);

                                x1 -= 53;
                                x2 += 50;
                                x3 += 50;
                                revers_count--;
                            }
                            else
                            {

                            }

                        }
                    }

                    for (int g = Convert.ToInt32(el[1]); g < allELS.Count; g++)
                    {
                        string[] eel = allELS[g].Split(';');
                        if (count == 9)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label25.Font, new SolidBrush(Color.Black), x, 219);

                                gr.DrawString(eel[5], label25.Font, new SolidBrush(Color.Black), x, y1);

                                //gr.DrawString(eel[2], label25.Font, new SolidBrush(Color.Black), x1, 278);

                                x += 53;
                                x1 += 53;
                                x2 += 50;
                                x3 += 50;
                                count++;
                            }
                            else
                            {

                            }



                        }
                        if (g == allELS.Count - 1)
                        {

                        }

                        count++;
                    }
                    gr.FillRectangle(new SolidBrush(Color.White), x - 6, y1 - 20, 999, 999);
                    gr.FillRectangle(new SolidBrush(Color.White), 926, 216, 999, 999);

                }
                image.Save(_manager.folderName + @"/Элемент_" + el[0] + "_" + el[1] /*+ "_" + el[2]*/ + "_схема_2.png", ImageFormat.Png);
            }
        }//!

        string Rmer(string num)
        {
            if (num.Contains('.'))
            {
                string[] dt = num.Split('.');
                num = dt[0] + "," + dt[1];
            }
            return num;
        }

        private void export_Click(object sender, EventArgs e)
        {
            timer2.Start();

            bool exp = true;
            bool wrl = true;
            int progress = 0;

            #region black_or_colorful
            if (detal.Checked) 
            {
                if (CHBready.Checked)
                {
                    ImageBlackGenerator(this.label25, this.label26, Color.Black);
                }
                else
                {
                    ImageBlackGenerator(this.label25, this.label26, Color.Black);
                }

            }
            #endregion

            #region progressline
            if (elements_magazine.Checked)
                {
                    string[] files = Directory.GetFiles(_manager.folderName + @"/Журнал контроля");

                    foreach (string file in files)
                    {
                        string[] all = File.ReadAllLines(file);
                        progress = progress + all.Length;
                    }
                }

                if (VTOcheck.Checked)
                {
                    string[] files = Directory.GetFiles(_manager.folderName + @"/ВТО", "*.txt", SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        string[] all = File.ReadAllLines(file);
                        progress = progress + all.Length;
                    }
                }

                if (VIKcheck.Checked)
                {
                    string[] files = Directory.GetFiles(_manager.folderName + @"/ВИК", "*", SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        string[] all = File.ReadAllLines(file);
                        progress = progress + all.Length;
                    }
                }

                if (UZKcheck.Checked)
                {
                    string[] files = Directory.GetFiles(_manager.folderName + @"/Неразрушающий контроль");

                    foreach (string file in files)
                    {
                        string[] all = File.ReadAllLines(file);
                        progress = progress + all.Length;
                    }
                }

                if (tolchik_check.Checked)
                {
                    string[] files = Directory.GetFiles(_manager.folderName + @"/Толщинометрия");

                    foreach (string file in files)
                    {
                        string[] all = File.ReadAllLines(file);
                        progress = progress + all.Length;
                    }
                }
            progressBar1.Maximum = progress;
            #endregion

            #region copy_file
            try
            {
                CopyFile(mainn + @"\patterns\patt.xlsm", _manager.folderName + "/Экспресс-отчёт.xlsm");
            }
            catch 
            {
                DialogResult result = MessageBox.Show("Есть текущие процессы Excel, которые мешают выгрузке!" +
                                                      "\nЗакрыть их?(Сохраните документы перед закрытием)", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) 
                {
                    Process[] processes = Process.GetProcessesByName("excel"); 
                    foreach (Process process in processes) 
                    {
                        process.Kill(); 
                    }
                    
                    exp = true;
                }
                else
                {
                    exp = false;
                }
            }
            #endregion


            if (exgen.Checked) 
            {
                if (exp)
                {
                    #region excel_needed_thinks
                    List<string> osobN = new List<string>();
                    List<string> defs = new List<string>();

                    string path = _manager.folderName + "/Экспресс-отчёт.xlsm";
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook ewb = xlApp.Workbooks.Open
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
                    Excel.Sheets excelSheets = ewb.Worksheets;

                    xlApp.Interactive = false;
                    xlApp.EnableEvents = false;
                    xlApp.DisplayAlerts = false;
                    #endregion

                    #region title_export
                    Excel.Worksheet title = (Excel.Worksheet)excelSheets.get_Item("Титульный лист");

                    string[] mar_info = File.ReadAllLines(_manager.folderName + @"/Маршруты/Маршрут - 1.txt");
                    title.Cells[9, 2] = mar_info[13].Split(' ')[0];
                    title.Cells[10, 2] = mar_info[14].Split(' ')[0];

                    //title.Cells[5, 2] = "--ВСТАВИТЬ НУЖНОЕ--";
                    if (mar_info[1] == "")
                    {
                        title.Cells[5, 2] = "КЦ-" + mar_info[2] + " " + mar_info[0] + " ЛПУ МГ";
                    }
                    else title.Cells[5, 2] = "КЦ-" + mar_info[2] + " " + mar_info[0] + " ЛПУ МГ " + "КС " + mar_info[1];


                    string[] org_info = File.ReadAllLines(_manager.folderName + @"/Маршруты/Организация.txt");
                    title.Cells[12, 2] = org_info[0];
                    title.Cells[12, 4] = org_info[1];
                    title.Cells[12, 6] = org_info[2];

                    string[] zak_info = File.ReadAllLines(_manager.folderName + @"/Маршруты/Заказчик.txt");
                    title.Cells[14, 2] = zak_info[0];
                    title.Cells[14, 4] = zak_info[1];

                    string[] gran_info = File.ReadAllLines(_manager.folderName + @"/Маршруты/Границы работ.txt");
                    string strl = "";
                    for (int g = 0; g < gran_info.Length; g++)
                    {
                        strl += gran_info[g] + Environment.NewLine;
                    }
                    title.Cells[15, 2] = strl;

                    Excel.Range ra = title.Range["O15", "O15"];
                    ra.RowHeight = 25 * gran_info.Length;

                    //

                    string[] sred = File.ReadAllLines(_manager.folderName + @"/Маршруты/Средства контроля.txt");
                    string[] speki = File.ReadAllLines(_manager.folderName + @"/Маршруты/Состав специалистов.txt");
                    string[] kontr = File.ReadAllLines(mainn + "/src/Контроль проводился в соответствии с.txt");
                    string[] ocenka = File.ReadAllLines(mainn + "/src/Оценка качества производится в соответствии с.txt");

                    string kon = "";
                    for (int ko = 0; ko < kontr.Length; ko++)
                    {
                        kon += kontr[ko] + Environment.NewLine;
                    }
                    title.Cells[16, 2] = kon;

                    string oce = "";
                    for (int oc = 0; oc < ocenka.Length; oc++)
                    {
                        oce += ocenka[oc] + Environment.NewLine;
                    }
                    title.Cells[17, 2] = oce;

                    int etr = 19;
                    for (int s = 0; s < sred.Length; s++)
                    {
                        string[] str = sred[s].Split(';');


                        title.Range[title.Cells[etr, 4], title.Cells[etr, 5]].Merge();
                        title.Range[title.Cells[etr, 6], title.Cells[etr, 7]].Merge();

                        title.Cells[etr, 2] = str[0];
                        title.Cells[etr, 3] = str[1];
                        title.Cells[etr, 4] = str[2];
                        title.Cells[etr, 6] = str[3];
                        etr++;
                    }
                    title.Range[title.Cells[19, 1], title.Cells[etr - 1, 1]].Merge();
                    title.Cells[18, 1] = "Средства проведения диагностики:";

                    //etr++;
                    title.Range[title.Cells[etr, 1], title.Cells[etr + speki.Length, 1]].Merge();
                    title.Cells[etr, 1] = "Состав специалистов:";
                    title.Range[title.Cells[etr, 2], title.Cells[etr, 3]].Merge();
                    title.Cells[etr, 2] = "Ф И О";
                    title.Cells[etr, 4] = "Должность:";
                    title.Cells[etr, 5] = "Вид контроля, уровень:";
                    title.Cells[etr, 6] = "№ удостоверения:";
                    title.Cells[etr, 7] = "Действительно до:";
                    etr++;


                    for (int k = 0; k < speki.Length; k++)
                    {
                        string[] str = speki[k].Split(';');

                        title.Range[title.Cells[etr, 2], title.Cells[etr, 3]].Merge();
                        title.Cells[etr, 2] = str[0];
                        title.Cells[etr, 4] = str[3];
                        //title.Cells[etr, 5] = str[4];
                        title.Cells[etr, 6] = str[1];
                        title.Cells[etr, 7] = str[2];
                        etr++;
                    }

                    etr--;
                    Excel.Range Excelcells = title.get_Range("A1", "G" + etr);
                    Excelcells.Borders.ColorIndex = 0;
                    Excelcells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    Excelcells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;




                    xlApp.Run((object)"PrinTIT");
                    #endregion

                    #region marshrutes
                    Excel.Worksheet mars = (Excel.Worksheet)excelSheets.get_Item("Маршруты");
                    string[] marshutes = Directory.GetFiles(_manager.folderName + @"/Маршруты");
                    List<string> rightList = new List<string>();
                    string[] sredstva = File.ReadAllLines(_manager.folderName + @"/Маршруты/Средства контроля.txt");
                    string[] org = File.ReadAllLines(_manager.folderName + @"/Маршруты/Организация.txt");

                    int es = 3;

                    for (int mar = 0; mar < marshutes.Length; mar++)
                    {
                        marshutes[mar] = Path.GetFileNameWithoutExtension(marshutes[mar]);
                        if (marshutes[mar].Contains("Маршрут - "))
                        {
                            rightList.Add(marshutes[mar]);
                        }
                    }

                    for (int y = 0; y <= 999; y++)
                    {
                        if (File.Exists(_manager.folderName + @"/Маршруты/Маршрут - " + y + ".txt"))
                        {
                            string[] fdata = File.ReadAllLines(_manager.folderName + @"/Маршруты/Маршрут - " + y + ".txt");


                            for (int ee = 0; ee < 10; ee++)
                            {
                                if (ee == 4)
                                {
                                    mars.Cells[es, ee + 1] = y;
                                }
                                else
                                {
                                    mars.Cells[es, ee + 1] = fdata[ee];
                                }

                            }

                            string sr_va = "";
                            for (int sr = 0; sr < sredstva.Length; sr++)
                            {
                                sr_va += sredstva[sr].Split(';')[0] + Environment.NewLine;
                                sr_va += "№ свидетельства о поверке: " + sredstva[sr].Split(';')[1] + Environment.NewLine;
                                sr_va += "Действительно до: " + sredstva[sr].Split(';')[2] + Environment.NewLine + Environment.NewLine;
                            }

                            string isp = org[0];
                            //for (int sp = 0; sp < specs.Length; sp++) 
                            //{
                            //    isp += specs[sp].Split(';')[0] + Environment.NewLine;
                            //    isp += "УД № "+specs[sp].Split(';')[1] + Environment.NewLine;
                            //    isp += "Действительно до: "+specs[sp].Split(';')[2] + Environment.NewLine;
                            //    isp += "Должность: "+specs[sp].Split(';')[3] + Environment.NewLine + Environment.NewLine;
                            //}

                            mars.Cells[es, 11] = isp;
                            mars.Cells[es, 12] = sr_va;
                            mars.Cells[es, 13] = fdata[14].Split(' ')[0];
                            es++;
                        }
                    }
                    xlApp.Run((object)"PrinMRS");
                    //xlApp.Run((object)"mac");

                    #endregion

                    #region export

                    bool del_magazine = false;
                    bool delVik = false;
                    bool delVTO = false;
                    bool delUZK = false;
                    bool delTolch = false;
                    bool imgVTO = false;


                    if (elements_magazine.Checked == true)
                    {
                        Excel.Worksheet elements = (Excel.Worksheet)excelSheets.get_Item("Журнал элементов");
                        string[] files = Directory.GetFiles(_manager.folderName + @"/Журнал контроля");
                        int estr = 3;

                        for (int i = 1; i <= 999; i++)
                        {
                            if (File.Exists(_manager.folderName + @"/Журнал контроля/" + @"Маршрут - " + i + ".txt"))
                            {
                                elements.Range[elements.Cells[estr, 1], elements.Cells[estr, 17]].Merge();
                                elements.Cells[estr, 1] = "Маршрут - " + i;
                                elements.Range[elements.Cells[estr, 1], elements.Cells[estr, 17]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                elements.Range[elements.Cells[estr, 1], elements.Cells[estr, 17]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                elements.Range[elements.Cells[estr, 1], elements.Cells[estr, 17]].Interior.Color = Color.FromArgb(171, 164, 164);
                                estr++;

                                string[] data = File.ReadAllLines(_manager.folderName + @"/Журнал контроля/" + @"Маршрут - " + i + ".txt");
                                for (int dt = 0; dt < data.Length; dt++)
                                {
                                    string[] current = data[dt].Split(';');
                                    for (int s = 1; s <= current.Length; s++)
                                    {
                                        elements.Cells[estr, s] = current[s - 1];

                                    }
                                    estr++;
                                    progressBar1.Value++;

                                }
                            }
                        }

                        //elements.Cells[estr, s] = current[s - 1];

                        xlApp.Run((object)"PrinEL");
                    }
                    else
                    {
                        del_magazine = true;
                    }
                    if (VTOcheck.Checked == true)
                    {
                        Excel.Worksheet VTO = (Excel.Worksheet)excelSheets.get_Item("ВТО");
                        string[] files = Directory.GetFiles(_manager.folderName + @"/ВТО", "*", SearchOption.AllDirectories);
                        int estr = 3;

                        for (int i = 1; i <= 999; i++)
                        {
                            if (File.Exists(_manager.folderName + @"/ВТО/Маршрут - " + i + @"/Выявленные особенности маршрут - " + i + ".txt"))
                            {
                                VTO.Range[VTO.Cells[estr, 1], VTO.Cells[estr, 13]].Merge();
                                VTO.Cells[estr, 1] = "Маршрут - " + i;
                                VTO.Range[VTO.Cells[estr, 1], VTO.Cells[estr, 13]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                VTO.Range[VTO.Cells[estr, 1], VTO.Cells[estr, 13]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                VTO.Range[VTO.Cells[estr, 1], VTO.Cells[estr, 13]].Interior.Color = Color.FromArgb(171, 164, 164);
                                estr++;

                                string[] data = File.ReadAllLines(_manager.folderName + @"/ВТО/Маршрут - " + i + @"/Выявленные особенности маршрут - " + i + ".txt");
                                for (int dt = 0; dt < data.Length; dt++)
                                {

                                    string[] current = data[dt].Split(';');

                                    osobN.Add(current[0] + "." + current[2]);

                                    try
                                    {
                                        defs.Add(current[3]);
                                    }
                                    catch { }


                                    for (int s = 1; s <= current.Length; s++)
                                    {
                                        VTO.Cells[estr, s] = current[s - 1];

                                    }
                                    estr++;
                                    progressBar1.Value++;
                                }

                            }
                        }
                        xlApp.Run((object)"PrinVTO");
                    }
                    else
                    {
                        delVTO = true;
                    }
                    if (VIKcheck.Checked == true)
                    {
                        Excel.Worksheet VIK = (Excel.Worksheet)excelSheets.get_Item("ВИК");
                        string[] files = Directory.GetFiles(_manager.folderName + @"/ВИК", "*", SearchOption.AllDirectories);
                        int estr = 3;

                        for (int i = 1; i <= 999; i++)
                        {
                            if (File.Exists(_manager.folderName + @"/ВИК/Маршрут - " + i + @"/Маршрут - " + i + ".txt"))
                            {
                                VIK.Range[VIK.Cells[estr, 1], VIK.Cells[estr, 12]].Merge();
                                VIK.Cells[estr, 1] = "Маршрут - " + i;
                                VIK.Range[VIK.Cells[estr, 1], VIK.Cells[estr, 12]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                VIK.Range[VIK.Cells[estr, 1], VIK.Cells[estr, 12]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                VIK.Range[VIK.Cells[estr, 1], VIK.Cells[estr, 12]].Interior.Color = Color.FromArgb(171, 164, 164);
                                estr++;

                                string[] data = File.ReadAllLines(_manager.folderName + @"/ВИК/Маршрут - " + i + @"/Маршрут - " + i + ".txt");
                                for (int dt = 0; dt < data.Length; dt++)
                                {
                                    string[] current = data[dt].Split(';');
                                    for (int s = 1; s <= current.Length; s++)
                                    {
                                        VIK.Cells[estr, s] = current[s - 1];

                                    }
                                    estr++;
                                    progressBar1.Value++;
                                }

                            }
                        }
                        xlApp.Run((object)"PrinVIK");
                    }
                    else
                    {
                        delVik = true;
                    }
                    if (UZKcheck.Checked == true)
                    {
                        Excel.Worksheet UZK = (Excel.Worksheet)excelSheets.get_Item("УЗК");
                        string[] files = Directory.GetFiles(_manager.folderName + @"/Неразрушающий контроль");
                        int estr = 3;

                        for (int i = 1; i <= 999; i++)
                        {

                            if (File.Exists(_manager.folderName + @"/Неразрушающий контроль" + @"/Неразрушающий контроль маршрут - " + i + ".txt"))
                            {

                                UZK.Range[UZK.Cells[estr, 1], UZK.Cells[estr, 14]].Merge();
                                UZK.Cells[estr, 1] = "Маршрут - " + i;
                                UZK.Range[UZK.Cells[estr, 1], UZK.Cells[estr, 14]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                UZK.Range[UZK.Cells[estr, 1], UZK.Cells[estr, 14]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                UZK.Range[UZK.Cells[estr, 1], UZK.Cells[estr, 14]].Interior.Color = Color.FromArgb(171, 164, 164);
                                estr++;

                                string[] data = File.ReadAllLines(_manager.folderName + @"/Неразрушающий контроль" + @"/Неразрушающий контроль маршрут - " + i + ".txt");
                                for (int dt = 0; dt < data.Length; dt++)
                                {
                                    string[] current = data[dt].Split(';');
                                    for (int s = 1; s <= current.Length; s++)
                                    {
                                        UZK.Cells[estr, s] = current[s - 1];

                                    }
                                    estr++;
                                    progressBar1.Value++;
                                }

                            }


                        }

                        for (int u = 1; u < 5000; u++)
                        {
                            UZK.Cells[u, 15] = "";
                        }
                        xlApp.Run((object)"PrinUZK");
                    }
                    else
                    {
                        delUZK = true;
                    }
                    if (tolchik_check.Checked == true)
                    {


                        Excel.Worksheet TOL = (Excel.Worksheet)excelSheets.get_Item("Толщинометрия");
                        //TOL.Columns["A:F"].AutoFit();
                        TOL.Columns["A:F"].WrapText = true;

                        string[] derictories = Directory.GetDirectories(_manager.folderName + @"/Толщинометрия");
                        int estr = 4;


                        for (int i = 1; i < 999; i++)
                        {
                            if (Directory.Exists(_manager.folderName + @"/Толщинометрия/Маршрут - " + i))
                            {
                                TOL.Range[TOL.Cells[estr, 1], TOL.Cells[estr, 17]].Merge();
                                TOL.Cells[estr, 1] = "Маршрут - " + i;
                                TOL.Range[TOL.Cells[estr, 1], TOL.Cells[estr, 17]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                TOL.Range[TOL.Cells[estr, 1], TOL.Cells[estr, 17]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                TOL.Range[TOL.Cells[estr, 1], TOL.Cells[estr, 17]].Interior.Color = Color.FromArgb(171, 164, 164);
                                estr++;

                                string[] files = Directory.GetFiles(_manager.folderName + @"/Толщинометрия/Маршрут - " + i);

                                for (int f = 0; f < files.Length; f++)
                                {
                                    files[f] = Path.GetFileNameWithoutExtension(files[f]);
                                }

                                for (int k = 1; k < 999; k++)
                                {
                                    for (int j = 0; j < files.Length; j++)
                                    {
                                        string[] pces = files[j].Split('_');
                                        if (Convert.ToInt32(pces[2]) == k)
                                        {
                                            try
                                            {
                                                string[] data = File.ReadAllLines(_manager.folderName + @"/Толщинометрия/Маршрут - " + i + @"/" + files[j] + ".txt");
                                                string[] leftPart = data[0].Split('_');

                                                if (leftPart[leftPart.Length - 1] == "Труба")
                                                {
                                                    break;
                                                }
                                                TOL.Range[TOL.Cells[estr, 1], TOL.Cells[estr + 8, 1]].Merge();
                                                TOL.Range[TOL.Cells[estr, 2], TOL.Cells[estr + 8, 2]].Merge();
                                                TOL.Range[TOL.Cells[estr, 3], TOL.Cells[estr + 8, 3]].Merge();
                                                TOL.Range[TOL.Cells[estr, 4], TOL.Cells[estr + 8, 4]].Merge();
                                                TOL.Range[TOL.Cells[estr, 5], TOL.Cells[estr + 8, 5]].Merge();
                                                TOL.Range[TOL.Cells[estr, 6], TOL.Cells[estr + 8, 6]].Merge();
                                                TOL.Range[TOL.Cells[estr, 13], TOL.Cells[estr + 8, 17]].Merge();

                                                TOL.Cells[estr, 1] = leftPart[0];
                                                TOL.Cells[estr, 2] = leftPart[1];
                                                TOL.Cells[estr, 3] = leftPart[2];
                                                TOL.Cells[estr, 4] = leftPart[3];
                                                TOL.Cells[estr, 5] = leftPart[leftPart.Length - 1];//+
                                                TOL.Cells[estr, 6] = leftPart[4];

                                                string st = "";
                                                for (int p = 10; p < data.Length; p++)
                                                    st += data[p] + "\n";
                                                TOL.Cells[estr, 13] = st;


                                                TOL.Range[TOL.Cells[estr, 1], TOL.Cells[estr + 8, 6]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                                TOL.Range[TOL.Cells[estr, 1], TOL.Cells[estr + 8, 6]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                                TOL.Range[TOL.Cells[estr, 13], TOL.Cells[estr + 8, 17]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                                TOL.Range[TOL.Cells[estr, 13], TOL.Cells[estr + 8, 17]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                                TOL.Range[TOL.Cells[estr, 7], TOL.Cells[estr + 2, 7]].Merge();
                                                TOL.Cells[estr, 7] = "I";
                                                TOL.Range[TOL.Cells[estr, 7], TOL.Cells[estr + 2, 7]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                                TOL.Range[TOL.Cells[estr, 7], TOL.Cells[estr + 2, 7]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                                TOL.Range[TOL.Cells[estr + 3, 7], TOL.Cells[estr + 5, 7]].Merge();
                                                TOL.Cells[estr + 3, 7] = "II";
                                                TOL.Range[TOL.Cells[estr + 3, 7], TOL.Cells[estr + 5, 7]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                                TOL.Range[TOL.Cells[estr + 3, 7], TOL.Cells[estr + 5, 7]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                                TOL.Range[TOL.Cells[estr + 6, 7], TOL.Cells[estr + 8, 7]].Merge();
                                                TOL.Cells[estr + 6, 7] = "III";
                                                TOL.Range[TOL.Cells[estr + 6, 7], TOL.Cells[estr + 8, 7]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                                TOL.Range[TOL.Cells[estr + 6, 7], TOL.Cells[estr + 8, 7]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                                for (int d = 1; d < 10; d++)
                                                {
                                                    string[] str = data[d].Split(';');

                                                    for (int s = 0; s < str.Length - 1; s++)
                                                    {
                                                        TOL.Cells[estr, 8 + s] = str[s];
                                                    }
                                                    estr++;
                                                }
                                                progressBar1.Value++;
                                            }
                                            catch
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        estr++;
                        estr++;

                        //TOL.Range[TOL.Cells[estr, 3], TOL.Cells[estr, 6]].Merge();
                        //TOL.Range[TOL.Cells[estr, 12], TOL.Cells[estr, 17]].Merge();
                        //TOL.Cells[estr, 3] = "Руководитель работ";
                        //TOL.Cells[estr, 12] = "Панкратов Лев Константинович";
                        //estr++;

                        //char ll = '"';
                        //TOL.Range[TOL.Cells[estr, 3], TOL.Cells[estr, 6]].Merge();
                        //TOL.Range[TOL.Cells[estr, 12], TOL.Cells[estr, 17]].Merge();
                        //TOL.Cells[estr, 3] = ll + "ООО Газпроект-ДКР" + ll;
                        //TOL.Cells[estr, 12] = "УЗК Ур. кв. II Уд № НОАП-0001-37327 Действительно до: 01.04.2020";

                        xlApp.Run((object)"PrinTOL");
                    }
                    else
                    {
                        delTolch = true;
                    }
                    if (img_VTO.Checked == true)
                    {
                        int estr = 1;
                        int est = 1;
                        int nones = 0;


                        Excel.Worksheet IMG = (Excel.Worksheet)excelSheets.get_Item("Снимки");
                        IMG.Select();
                        string[] imgs = Directory.GetFiles(_manager.folderName + @"/ВТО", "*.bmp", SearchOption.AllDirectories);

                        for (int i = 0; i < osobN.Count; i++)
                        {
                            //MessageBox.Show(osobN[i]);
                            for (int j = 0; j < imgs.Length; j++)
                            {
                                string img = Path.GetFileNameWithoutExtension(imgs[j]);
                                if (img.Contains(osobN[i]))
                                {
                                    //MessageBox.Show(osobN[i]+"   "+imgs[j]);       

                                    if (est == 1)
                                    {



                                        Excel.Range pictureTargetRange = IMG.Range["A" + estr, "A" + estr];
                                        pictureTargetRange.Select();
                                        pictureTargetRange.RowHeight = 180;
                                        Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                                        Excel.Picture picture = pictures.Insert(imgs[j], Type.Missing);
                                        picture.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
                                        picture.Width = pictureTargetRange.Width - 2;
                                        picture.Height = pictureTargetRange.RowHeight - 2;
                                        picture.Placement = Excel.XlPlacement.xlMoveAndSize;

                                        estr++;
                                        IMG.Cells[estr, 1] = "Снимок №" + osobN[i] + "\n" + defs[i];

                                        est++;
                                        estr--;
                                        break;



                                    }

                                    if (est == 2)
                                    {
                                        //IMG.Cells[estr, 3] = osobN[i] + "\n" + defs[i];
                                        //estr++;

                                        Excel.Range pictureTargetRange = IMG.Range["C" + estr, "C" + estr];
                                        //Excel.Range pictureTargetRange = IMG.Range[IMG.Cells[1,estr] , IMG.Cells[1, estr]];
                                        try { pictureTargetRange.Select(); } catch { }
                                        pictureTargetRange.RowHeight = 180;
                                        Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                                        Excel.Picture picture = pictures.Insert(imgs[j], Type.Missing);
                                        picture.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
                                        picture.Width = pictureTargetRange.Width - 2;
                                        picture.Height = pictureTargetRange.RowHeight - 2;
                                        picture.Placement = Excel.XlPlacement.xlMoveAndSize;

                                        estr++;
                                        IMG.Cells[estr, 3] = "Снимок №" + osobN[i] + "\n" + defs[i];

                                        est++;
                                        estr--;
                                        break;



                                    }

                                    if (est == 3)
                                    {
                                        //IMG.Cells[estr, 5] = osobN[i] + "\n" + defs[i];
                                        //estr++;

                                        Excel.Range pictureTargetRange = IMG.Range["E" + estr, "E" + estr];
                                        //Excel.Range pictureTargetRange = IMG.Range[IMG.Cells[1,estr] , IMG.Cells[1, estr]];
                                        try { pictureTargetRange.Select(); } catch { }
                                        pictureTargetRange.RowHeight = 180;
                                        Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                                        Excel.Picture picture = pictures.Insert(imgs[j], Type.Missing);
                                        picture.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
                                        picture.Width = pictureTargetRange.Width - 2;
                                        picture.Height = pictureTargetRange.RowHeight - 2;
                                        picture.Placement = Excel.XlPlacement.xlMoveAndSize;

                                        estr++;
                                        IMG.Cells[estr, 5] = "Снимок №" + osobN[i] + "\n" + defs[i];

                                        estr++;
                                        est = 1;
                                        //estr--;
                                        break;



                                    }
                                }
                            }
                        }

                        #region rep
                        //for (int i = 0; i < osobN.Count; i++) 
                        //{
                        //    if (defs[i] == "Особенность не обнаружена") break;

                        //    for (int j = 0; j<imgs.Length; j++) 
                        //    {
                        //        string imgPath = Path.GetFileNameWithoutExtension(imgs[j]);

                        //        if (imgPath.Contains(osobN[i])) 
                        //        {


                        //            if (est == 1)
                        //            {
                        //                IMG.Cells[estr,1] = osobN[i] + "\n" + defs[i];
                        //                estr++;

                        //                Excel.Range pictureTargetRange = IMG.Range["A" + estr, "A" + estr];
                        //                pictureTargetRange.Select();
                        //                pictureTargetRange.RowHeight = 180;
                        //                Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                        //                Excel.Picture picture = pictures.Insert(imgs[j], Type.Missing);
                        //                picture.ShapeRange.LockAspectRatio = MsoTriState.msoFalse;
                        //                picture.Width = pictureTargetRange.Width-2;
                        //                picture.Height = pictureTargetRange.RowHeight - 2;
                        //                picture.Placement = Excel.XlPlacement.xlMoveAndSize;
                        //                est++;
                        //                estr--;
                        //                break;


                        //                //osobN.Remove(osobN[j]);
                        //            }

                        //            if (est == 2)
                        //            {
                        //                IMG.Cells[estr,3] = osobN[i] + "\n" + defs[i];
                        //                estr++;

                        //                Excel.Range pictureTargetRange = IMG.Range["C" + estr, "C" + estr];
                        //                //Excel.Range pictureTargetRange = IMG.Range[IMG.Cells[1,estr] , IMG.Cells[1, estr]];
                        //                try { pictureTargetRange.Select(); } catch { }
                        //                pictureTargetRange.RowHeight = 180;
                        //                Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                        //                Excel.Picture picture = pictures.Insert(imgs[j], Type.Missing);
                        //                picture.ShapeRange.LockAspectRatio = MsoTriState.msoFalse;
                        //                picture.Width = pictureTargetRange.Width-2;
                        //                picture.Height = pictureTargetRange.RowHeight - 2;
                        //                picture.Placement = Excel.XlPlacement.xlMoveAndSize;
                        //                est++;
                        //                estr--;
                        //                break;


                        //                //osobN.Remove(osobN[j]);
                        //            }

                        //            if (est == 3)
                        //            {
                        //                IMG.Cells[estr,5] = osobN[i] + "\n" + defs[i];
                        //                estr++;

                        //                Excel.Range pictureTargetRange = IMG.Range["E" + estr, "E" + estr];
                        //                //Excel.Range pictureTargetRange = IMG.Range[IMG.Cells[1,estr] , IMG.Cells[1, estr]];
                        //                try { pictureTargetRange.Select(); } catch { }
                        //                pictureTargetRange.RowHeight = 180;
                        //                Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                        //                Excel.Picture picture = pictures.Insert(imgs[j], Type.Missing);
                        //                picture.ShapeRange.LockAspectRatio = MsoTriState.msoFalse;
                        //                picture.Width = pictureTargetRange.Width-2;
                        //                picture.Height = pictureTargetRange.RowHeight - 2;
                        //                picture.Placement = Excel.XlPlacement.xlMoveAndSize;
                        //                estr++;
                        //                est = 1;
                        //                //estr--;
                        //                break;


                        //                //osobN.Remove(osobN[j]);
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion
                        #region repair
                        //try 
                        //{
                        //    {

                        //        MessageBox.Show(osobN.Count.ToString());
                        //        for (int j = 0; j <= osobN.Count; j++)
                        //        {

                        //            if (defs[j] == "Особенность не обнаружена")
                        //            {
                        //                break;
                        //            }
                        //            else
                        //            {
                        //                MessageBox.Show(_manager.folderName + @"/ВТО/" + osobN[j] + ".bmp");
                        //                if (File.Exists(_manager.folderName + @"/ВТО/" + osobN[j] + ".bmp"))
                        //                {

                        //                    if (est == 1)
                        //                    {
                        //                        IMG.Cells[estr, est] = osobN[j] + "\n" + defs[j];
                        //                        estr++;

                        //                        Excel.Range pictureTargetRange = IMG.Range["A" + estr, "A" + estr];

                        //                        try { pictureTargetRange.Select(); } catch { }
                        //                        pictureTargetRange.RowHeight = 180;
                        //                        Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                        //                        Excel.Picture picture = pictures.Insert(_manager.folderName + @"/ВТО/" + osobN[j] + ".bmp", Type.Missing);
                        //                        picture.ShapeRange.LockAspectRatio = MsoTriState.msoFalse;
                        //                        picture.Width = pictureTargetRange.Width;
                        //                        picture.Height = pictureTargetRange.RowHeight - 1;
                        //                        picture.Placement = Excel.XlPlacement.xlMoveAndSize;
                        //                        estr++;
                        //                        est++;
                        //                        break;
                        //                        //estr++;

                        //                        //osobN.Remove(osobN[j]);
                        //                    }

                        //                    //if (est == 2)
                        //                    //{
                        //                    //    IMG.Cells[estr, est] = osobN[j] + "\n" + defs[j];
                        //                    //    estr++;

                        //                    //    Excel.Range pictureTargetRange = IMG.Range["C" + estr, "C" + estr];
                        //                    //    //Excel.Range pictureTargetRange = IMG.Range[IMG.Cells[1,estr] , IMG.Cells[1, estr]];
                        //                    //    try { pictureTargetRange.Select(); } catch { }
                        //                    //    pictureTargetRange.RowHeight = 180;
                        //                    //    Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                        //                    //    Excel.Picture picture = pictures.Insert(_manager.folderName + @"/ВТО/" + osobN[j] + ".bmp", Type.Missing);
                        //                    //    picture.ShapeRange.LockAspectRatio = MsoTriState.msoFalse;
                        //                    //    picture.Width = pictureTargetRange.Width;
                        //                    //    picture.Height = pictureTargetRange.RowHeight - 1;
                        //                    //    picture.Placement = Excel.XlPlacement.xlMoveAndSize;
                        //                    //    estr++;
                        //                    //    est++;

                        //                    //    break;
                        //                    //    //estr++;

                        //                    //    //osobN.Remove(osobN[j]);
                        //                    //}

                        //                    //if (est == 3)
                        //                    //{
                        //                    //    IMG.Cells[estr, estr] = osobN[j] + "\n" + defs[j];
                        //                    //    estr++;

                        //                    //    Excel.Range pictureTargetRange = IMG.Range["E" + estr, "E" + estr];
                        //                    //    //Excel.Range pictureTargetRange = IMG.Range[IMG.Cells[1,estr] , IMG.Cells[1, estr]];
                        //                    //    try { pictureTargetRange.Select(); } catch { }
                        //                    //    pictureTargetRange.RowHeight = 180;
                        //                    //    Excel.Pictures pictures = (Excel.Pictures)IMG.Pictures(Type.Missing);
                        //                    //    Excel.Picture picture = pictures.Insert(_manager.folderName + @"/ВТО/" + osobN[j] + ".bmp", Type.Missing);
                        //                    //    picture.ShapeRange.LockAspectRatio = MsoTriState.msoFalse;
                        //                    //    picture.Width = pictureTargetRange.Width;
                        //                    //    picture.Height = pictureTargetRange.RowHeight - 1;
                        //                    //    picture.Placement = Excel.XlPlacement.xlMoveAndSize;
                        //                    //    estr++;
                        //                    //    est = 1;
                        //                    //    break;
                        //                    //    //estr++;

                        //                    //    //osobN.Remove(osobN[j]);
                        //                    //}

                        //                }
                        //            }


                        //        }
                        //    }
                        //} catch { }

                        //IMG.Shapes.AddPicture(_manager.folderName + @"/Снимки ВТО/1.bmp", Microsoft.Office.Core.MsoTriState.msoFalse,
                        //    Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 30, 30);
                        #endregion
                        xlApp.Run((object)"PrinIMG");
                    }
                    else
                    {
                        imgVTO = true;
                    }



                    #endregion

                    #region delete_pages

                    if (!detal.Checked)
                    {
                        Excel.Worksheet detals = (Excel.Worksheet)excelSheets.get_Item("Листы детализации");
                        detals.Delete();
                    }

                    if (del_magazine == true)
                    {
                        Excel.Worksheet elements = (Excel.Worksheet)excelSheets.get_Item("Журнал элементов");
                        elements.Delete();
                        //((Excel.Worksheet)ewb.Sheets[2]).Delete();
                    }

                    if (delVik == true)
                    {
                        Excel.Worksheet VIK = (Excel.Worksheet)excelSheets.get_Item("ВИК");
                        VIK.Delete();
                        //((Excel.Worksheet)ewb.Sheets[3]).Delete();
                    }

                    if (delVTO == true)
                    {
                        Excel.Worksheet VTO = (Excel.Worksheet)excelSheets.get_Item("ВТО");
                        VTO.Delete();
                        //((Excel.Worksheet)ewb.Sheets[4]).Delete();
                    }

                    if (delUZK == true)
                    {
                        Excel.Worksheet UZK = (Excel.Worksheet)excelSheets.get_Item("УЗК");
                        UZK.Delete();
                        //((Excel.Worksheet)ewb.Sheets[5]).Delete();
                    }
                    if (delTolch == true)
                    {
                        Excel.Worksheet TOL = (Excel.Worksheet)excelSheets.get_Item("Толщинометрия");
                        TOL.Delete();
                        //((Excel.Worksheet)ewb.Sheets[5]).Delete();
                    }
                    if (imgVTO == true)
                    {
                        Excel.Worksheet IMG = (Excel.Worksheet)excelSheets.get_Item("Снимки");
                        IMG.Delete();
                    }
                    #endregion

                    #region lists
                    List<string> allELS = new List<string>();
                    List<string> allVTOS = new List<string>();
                    List<string> allMA = new List<string>();

                    for (int i = 0; i < 999; i++)
                    {

                        if (Directory.Exists(_manager.folderName + @"/ВТО/Маршрут - " + i))
                        {
                            List<string> data = ReadAllFiles(_manager.folderName + @"/ВТО/Маршрут - " + i + "/Выявленные особенности маршрут - ");
                            foreach (string dt in data)
                            {
                                allVTOS.Add(dt);
                            }
                        }

                    }

                    if (Directory.Exists(_manager.folderName + @"/Журнал контроля"))
                    {
                        for (int i = 0; i < 999; i++)
                        {
                            if (File.Exists(_manager.folderName + @"/Журнал контроля/Маршрут - " + i + ".txt"))
                            {
                                using (StreamReader sr = new StreamReader(_manager.folderName + @"/Журнал контроля/Маршрут - " + i + ".txt"))
                                {
                                    while (!sr.EndOfStream)
                                    {
                                        allELS.Add(sr.ReadLine());
                                    }
                                }
                            }
                        }
                    }

                    if (Directory.Exists(_manager.folderName + @"/Неразрушающий контроль"))
                    {
                        for (int i = 0; i < 999; i++)
                        {
                            if (File.Exists(_manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt"))
                            {
                                using (StreamReader sr = new StreamReader(_manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt"))
                                {
                                    while (!sr.EndOfStream)
                                    {
                                        allMA.Add(sr.ReadLine());
                                    }
                                }
                            }
                        }
                    }


                    if (detal.Checked)
                    {
                        Excel.Worksheet li = (Excel.Worksheet)excelSheets.get_Item("Листы детализации");
                        li.Select();

                        int si = 1;


                        for (int p = 0; p < 999; p++)
                        {
                            for (int pp = 0; pp < 999; pp++)
                            {
                                if (File.Exists(_manager.folderName + @"/Элемент_" + p + "_" + pp + "_" + ".png"))
                                {
                                    if (File.Exists(_manager.folderName + @"/Элемент_" + p + "_" + pp + "_схема_2" + ".png"))
                                    {
                                        string details_one = _manager.folderName + @"/Элемент_" + p + "_" + pp + "_" + ".png";
                                        string details_two = _manager.folderName + @"/Элемент_" + p + "_" + pp + "_схема_2" + ".png";

                                        //if (details_two[i].Contains(details_one[k]))
                                        {
                                            Excel.Range pictureTargetRange = li.Range["A" + si, "P" + si];
                                            pictureTargetRange.Select();

                                            Excel.Pictures pictures = (Excel.Pictures)li.Pictures(Type.Missing);

                                            Image img1 = Image.FromFile(details_one);
                                            Image img2 = Image.FromFile(details_two);

                                            pictureTargetRange.RowHeight = 350;

                                            Excel.Picture picture = pictures.Insert(details_one, Type.Missing);

                                            picture.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
                                            picture.Width = pictureTargetRange.Width - 2;
                                            picture.Height = pictureTargetRange.RowHeight - 2;
                                            picture.Placement = Excel.XlPlacement.xlMoveAndSize;

                                            si++;

                                            Excel.Range pictureTargetRange1 = li.Range["A" + si, "P" + si];
                                            pictureTargetRange1.Select();

                                            Excel.Pictures pictures1 = (Excel.Pictures)li.Pictures(Type.Missing);

                                            pictureTargetRange1.RowHeight = 300;

                                            Excel.Picture picture1 = pictures.Insert(details_two, Type.Missing);

                                            picture.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
                                            picture1.Width = pictureTargetRange1.Width - 2;
                                            picture1.Height = pictureTargetRange1.RowHeight - 2;
                                            picture1.Placement = Excel.XlPlacement.xlMoveAndSize;

                                            si++;

                                            li.Cells[si, 1] = "№ участка";
                                            li.Cells[si, 2] = "№ эл-та п/п";
                                            li.Cells[si, 3] = "Тип элемента";
                                            li.Cells[si, 4] = "Наружный диаметр элемента, м";
                                            li.Cells[si, 5] = "Расстояние от начала маршрута до начала элемента";
                                            li.Cells[si, 6] = "Длина, м";
                                            li.Cells[si, 7] = "Толщина стенки, мм";
                                            li.Cells[si, 8] = "Конструкция элемента";
                                            li.Cells[si, 9] = "Угловая ориентация продольных швов №1, град";
                                            li.Cells[si, 10] = "Угловая ориентация продольных швов №2, град";
                                            li.Cells[si, 11] = "Плоскость расположения";
                                            li.Cells[si, 12] = "Угол изгиба отвода, град";
                                            li.Cells[si, 13] = "Угол наклона плоскости расположения, град";
                                            li.Cells[si, 14] = "Наружный диаметр ответвления переходного тройника";
                                            li.Cells[si, 15] = "Высота тройника, мм";
                                            li.Cells[si, 16] = "Наружный диаметр перехода (второй), м";

                                            li.Range[li.Cells[si, 1], li.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                            si++;

                                            for (int s = 0; s < allELS.Count; s++)
                                            {
                                                string[] elem = allELS[s].Split(';');

                                                if (Convert.ToInt32(elem[0]) == p && Convert.ToInt32(elem[1]) == pp)
                                                {
                                                    li.Range[li.Cells[si, 1], li.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                                    for (int el = 0; el < elem.Length; el++)
                                                    {
                                                        li.Cells[si, el + 1] = elem[el];
                                                    }
                                                }
                                            }

                                            si++;

                                            //li.Range[li.Cells[si, 13], li.Cells[si, 16]].Merge();
                                            li.Cells[si, 1] = "Номер диагностируемого участка";
                                            li.Cells[si, 2] = "№ элемента п/п";
                                            li.Cells[si, 3] = "№ особенности п/п";
                                            li.Cells[si, 4] = "Тип особенности";
                                            li.Cells[si, 5] = "Расстояние от начала элемента до особенности, м";
                                            li.Cells[si, 6] = "Расстояние от начала элемента до конца особенности, м";
                                            li.Cells[si, 7] = "Угловая ориентация особенности, час (начало)";
                                            li.Cells[si, 8] = "Угловая ориентация особенности, час (конец)";
                                            li.Cells[si, 9] = "Измеренная длина особенности, мм";
                                            li.Cells[si, 10] = "Измеренная ширина особенности , мм";
                                            li.Cells[si, 11] = "№ фото выявленных особенностей";
                                            li.Cells[si, 12] = "Рекомендации";
                                            li.Cells[si, 13] = "Примечание";

                                            si++;
                                            int vto_co = 0;

                                            for (int s = 0; s < allVTOS.Count; s++)
                                            {
                                                string[] vtoha = allVTOS[s].Split(';');

                                                if (Convert.ToInt32(vtoha[0]) == p && Convert.ToInt32(vtoha[1]) == pp && !vtoha[2].Contains("-"))
                                                {
                                                    li.Range[li.Cells[si, 1], li.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                                    if (vto_co == 0)
                                                    {
                                                        li.Range[li.Cells[si - 1, 13], li.Cells[si - 1, 16]].Merge();
                                                        li.Range[li.Cells[si - 1, 1], li.Cells[si - 1, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                                    }
                                                    li.Range[li.Cells[si, 13], li.Cells[si, 16]].Merge();

                                                    for (int v = 0; v < vtoha.Length; v++)
                                                    {
                                                        li.Cells[si, v + 1] = vtoha[v];
                                                    }
                                                    si++;
                                                    vto_co++;
                                                }

                                            }

                                            if (vto_co == 0)
                                            {
                                                si--;
                                            }

                                            int ma_co = 0;


                                            //li.Range[li.Cells[si, 15], li.Cells[si, 16]].Merge();
                                            li.Cells[si, 1] = "Номер диагностируемого участка";
                                            li.Cells[si, 2] = "№ элемента п/п";
                                            li.Cells[si, 3] = "Измеренная толщина стенки элемента, мм";
                                            li.Cells[si, 4] = "№ дефекта п/п";
                                            li.Cells[si, 5] = "Тип дефекта";
                                            li.Cells[si, 6] = "Расположение дефекта от кольцевого шва, мм";
                                            li.Cells[si, 7] = "Угловая ориентация дефекта начало, час";
                                            li.Cells[si, 8] = "Угловая ориентация дефекта конец, час";
                                            li.Cells[si, 9] = "Длина дефекта, мм";
                                            li.Cells[si, 10] = "Ширина дефекта, мм";
                                            li.Cells[si, 11] = "Глубина дефекта,мм";
                                            li.Cells[si, 12] = "Остаточная толщина дефекта";
                                            li.Cells[si, 13] = "Относительная глубина дефекта,мм";
                                            li.Cells[si, 14] = "Примечание";
                                            li.Cells[si, 15] = "Рекомендации к проведению ДДК в шурфах методами НК";

                                            si++;
                                            for (int m = 0; m < allMA.Count; m++)
                                            {
                                                string[] ma = allMA[m].Split(';');
                                                if (Convert.ToInt32(ma[0]) == p && Convert.ToInt32(ma[1]) == pp && !ma[3].Contains("-"))
                                                {
                                                    li.Range[li.Cells[si, 1], li.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                                    if (ma_co == 0)
                                                    {
                                                        li.Range[li.Cells[si - 1, 15], li.Cells[si - 1, 16]].Merge();
                                                        li.Range[li.Cells[si - 1, 1], li.Cells[si - 1, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                                    }
                                                    li.Range[li.Cells[si, 15], li.Cells[si, 16]].Merge();

                                                    for (int mm = 0; mm < ma.Length; mm++)
                                                    {
                                                        li.Cells[si, mm + 1] = ma[mm];
                                                    }
                                                    si++;
                                                    ma_co++;
                                                }
                                            }

                                            if (ma_co == 0)
                                            {
                                                si--;

                                                for (int m = 1; m <= 16; m++)
                                                {
                                                    li.Cells[si, m] = "";
                                                }
                                            }



                                        }
                                    }
                                }
                            }
                        }
                        xlApp.Run((object)"PrinDetails");
                    }

                    if (stat.Checked)
                    {
                        var lis = (Excel.Worksheet)ewb.Sheets.Add(After: ewb.ActiveSheet);
                        lis.Name = "Статистика";
                        lis.Select();
                        int stroka = 0;

                        //string[] files = Directory.GetFiles(_manager.folderName+"/ВТО", "*", SearchOption.AllDirectories);
                        List<string> files = new List<string>();
                        List<string> VTO = new List<string>();

                        for (int i = 1; i < 999; i++)
                        {
                            if (File.Exists(_manager.folderName + "/ВТО/Маршрут - " + i + "/Выявленные особенности маршрут - " + i + ".txt"))
                            {
                                string pathh = _manager.folderName + "/ВТО/Маршрут - " + i + "/Выявленные особенности маршрут - " + i + ".txt";
                                files.Add(pathh);
                            }
                        }

                        for (int i = 0; i < 999; i++)
                        {

                            try
                            {
                                if (File.Exists(files[i]))
                                {
                                    string[] file = File.ReadAllLines(files[i]);

                                    for (int j = 0; j < file.Length; j++)
                                    {
                                        if (!file[j].Split(';')[3].Contains("Особенность не обнаружена"))
                                        {
                                            VTO.Add(file[j].Split(';')[3]);
                                        }

                                    }

                                    VTO = VTO.Distinct().ToList();

                                }
                            }
                            catch
                            { }

                        }


                        lis.Range[lis.Cells[1, 1], lis.Cells[2, 1]].Merge();
                        lis.Cells[1, 1] = "Тип дефекта";

                        int st = 2;
                        for (int i = 0; i < 999; i++)
                        {
                            int si = 3;
                            try
                            {
                                if (File.Exists(files[i]))
                                {
                                    string[] file = File.ReadAllLines(files[i]);

                                    for (int j = 0; j < VTO.Count; j++)
                                    {
                                        int osob = 0;
                                        for (int k = 0; k < file.Length; k++)
                                        {
                                            if (file[k].Contains(VTO[j]))
                                            {
                                                osob++;
                                            }
                                        }


                                        lis.Cells[si, 1] = VTO[j];
                                        lis.Cells[si, st] = osob.ToString();
                                        si++;

                                        stroka = si;
                                    }

                                    string filename = Path.GetFileNameWithoutExtension(files[i]);
                                    string[] name = filename.Split('-');
                                    lis.Cells[2, st] = "М " + name[name.Length - 1];
                                    st++;
                                }
                            }
                            catch
                            { }

                        }

                        for (int row = 3; row <= VTO.Count + 2; row++)
                        {
                            int count = 0;
                            for (int col = 2; col < st; col++)
                            {
                                int current = Convert.ToInt32(lis.Cells[row, col].Value);
                                count = count + current;
                            }
                            lis.Cells[row, st] = count.ToString();
                        }

                        #region page_setting

                        lis.Range[lis.Cells[1, 2], lis.Cells[1, st]].Merge();
                        lis.Cells[1, 2] = "Количество дефектов, шт";

                        lis.Cells[2, st] = "Всего";

                        for (int r = 1; r <= VTO.Count + 2; r++)
                        {
                            for (int c = 1; c <= st; c++)
                            {
                                lis.Cells[r, c].HorizontalAlignment = -4108;//xlCenter
                                lis.Cells[r, c].VerticalAlignment = -4108;//xlCenter

                                lis.Cells[r, c].Borders.ColorIndex = 0;
                                lis.Cells[r, c].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                lis.Cells[r, c].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                            }
                        }

                        lis.Range[lis.Cells[1, 1], lis.Cells[2, st]].Interior.Color = Color.FromArgb(171, 164, 164);
                        lis.Columns[1].ColumnWidth = 32;

                        for (int i = 0; i < 3; i++)
                        {
                            Excel.Range cellRange = (Excel.Range)lis.Cells[1, 1];
                            Excel.Range rowRange = cellRange.EntireRow;
                            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
                        }

                        lis.Range[lis.Cells[3, 1], lis.Cells[3, st]].Merge();
                        lis.Cells[3, 1] = "Результаты ВТО";

                        lis.Cells[3, 1].HorizontalAlignment = -4108;//xlCenter
                        lis.Cells[3, 1].VerticalAlignment = -4108;//xlCenter

                        #endregion

                        #region VIK

                        int rr = lis.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                        rr += 4;

                        List<string> VIK = new List<string>();
                        files.Clear();

                        for (int i = 1; i < 999; i++)
                        {
                            if (File.Exists(_manager.folderName + "/ВИК/Маршрут - " + i + "/Маршрут - " + i + ".txt"))
                            {
                                string pathh = _manager.folderName + "/ВИК/Маршрут - " + i + "/Маршрут - " + i + ".txt";
                                files.Add(pathh);
                            }
                        }

                        for (int i = 0; i < 999; i++)
                        {

                            try
                            {
                                if (File.Exists(files[i]))
                                {
                                    string[] file = File.ReadAllLines(files[i]);

                                    for (int j = 0; j < file.Length; j++)
                                    {
                                        if (!file[j].Split(';')[5].Contains("Дефекты не обнаружены"))
                                        {
                                            VIK.Add(file[j].Split(';')[5]);
                                        }

                                    }

                                    VIK = VIK.Distinct().ToList();

                                }
                            }
                            catch
                            { }

                        }


                        lis.Range[lis.Cells[rr, 1], lis.Cells[rr + 1, 1]].Merge();
                        lis.Cells[rr, 1] = "Тип дефекта";

                        st = 2;
                        for (int i = 0; i < 999; i++)
                        {
                            int si = 3;
                            try
                            {
                                if (File.Exists(files[i]))
                                {
                                    string[] file = File.ReadAllLines(files[i]);

                                    for (int j = 0; j < VIK.Count; j++)
                                    {
                                        int osob = 0;
                                        for (int k = 0; k < file.Length; k++)
                                        {
                                            if (file[k].Contains(VIK[j]))
                                            {
                                                osob++;
                                            }
                                        }


                                        lis.Cells[rr + si - 1, 1] = VIK[j];
                                        lis.Cells[rr + si - 1, st] = osob.ToString();
                                        si++;

                                        stroka = si;
                                    }

                                    string filename = Path.GetFileNameWithoutExtension(files[i]);
                                    string[] name = filename.Split('-');
                                    lis.Cells[rr + 1, st] = "М " + name[name.Length - 1];
                                    st++;
                                }
                            }
                            catch
                            { }

                        }

                        lis.Range[lis.Cells[rr, 2], lis.Cells[rr, st]].Merge();
                        lis.Cells[rr, 2] = "Количество дефектов, шт";

                        lis.Cells[rr + 1, st] = "Всего";

                        for (int row = rr + 2; row < VIK.Count + 2 + rr; row++)
                        {
                            int count = 0;
                            for (int col = 2; col < st; col++)
                            {
                                int current = Convert.ToInt32(lis.Cells[row, col].Value);
                                count = count + current;
                            }
                            lis.Cells[row, st] = count.ToString();
                        }


                        for (int r = rr; r < VIK.Count + 2 + rr; r++)
                        {
                            for (int c = 1; c <= st; c++)
                            {
                                lis.Cells[r, c].HorizontalAlignment = -4108;//xlCenter
                                lis.Cells[r, c].VerticalAlignment = -4108;//xlCenter

                                lis.Cells[r, c].Borders.ColorIndex = 0;
                                lis.Cells[r, c].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                lis.Cells[r, c].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                            }
                        }

                        lis.Range[lis.Cells[rr - 1, 1], lis.Cells[rr - 1, st]].Merge();
                        lis.Cells[rr - 1, 1] = "Результаты ВИК";



                        lis.Cells[rr - 1, 2].Borders.ColorIndex = 0;
                        lis.Cells[rr - 1, 2].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        lis.Cells[rr - 1, 2].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                        lis.Cells[rr - 1, 1].HorizontalAlignment = -4108;//xlCenter
                        lis.Cells[rr - 1, 1].VerticalAlignment = -4108;//xlCenter

                        lis.Range[lis.Cells[rr, 1], lis.Cells[rr + 1, st]].Interior.Color = Color.FromArgb(171, 164, 164);

                        #endregion

                        #region UZK

                        rr = lis.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                        rr += 4;

                        List<string> UZK = new List<string>();
                        files.Clear();

                        for (int i = 1; i < 999; i++)
                        {
                            if (File.Exists(_manager.folderName + "/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt"))
                            {
                                string pathh = _manager.folderName + "/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt";
                                files.Add(pathh);
                            }
                        }

                        for (int i = 0; i < 999; i++)
                        {

                            try
                            {
                                if (File.Exists(files[i]))
                                {
                                    string[] file = File.ReadAllLines(files[i]);

                                    for (int j = 0; j < file.Length; j++)
                                    {
                                        if (!file[j].Split(';')[4].Contains("Дефектов не обнаружено") && file[j].Split(';')[4] != "")
                                        {
                                            UZK.Add(file[j].Split(';')[4]);
                                        }

                                    }

                                    UZK = UZK.Distinct().ToList();

                                }
                            }
                            catch
                            { }

                        }


                        lis.Range[lis.Cells[rr, 1], lis.Cells[rr + 1, 1]].Merge();
                        lis.Cells[rr, 1] = "Тип дефекта";

                        st = 2;
                        for (int i = 0; i < 999; i++)
                        {
                            int si = 3;
                            try
                            {
                                if (File.Exists(files[i]))
                                {
                                    string[] file = File.ReadAllLines(files[i]);

                                    for (int j = 0; j < UZK.Count; j++)
                                    {
                                        int osob = 0;
                                        for (int k = 0; k < file.Length; k++)
                                        {
                                            if (file[k].Contains(UZK[j]))
                                            {
                                                osob++;
                                            }
                                        }


                                        lis.Cells[rr + si - 1, 1] = UZK[j];
                                        lis.Cells[rr + si - 1, st] = osob.ToString();
                                        si++;

                                        stroka = si;
                                    }

                                    string filename = Path.GetFileNameWithoutExtension(files[i]);
                                    string[] name = filename.Split('-');
                                    lis.Cells[rr + 1, st] = "М " + name[name.Length - 1];
                                    st++;
                                }
                            }
                            catch
                            { }

                        }

                        lis.Range[lis.Cells[rr, 2], lis.Cells[rr, st]].Merge();
                        lis.Cells[rr, 2] = "Количество дефектов, шт";

                        lis.Cells[rr + 1, st] = "Всего";

                        for (int row = rr + 2; row < UZK.Count + 2 + rr; row++)
                        {
                            int count = 0;
                            for (int col = 2; col < st; col++)
                            {
                                int current = Convert.ToInt32(lis.Cells[row, col].Value);
                                count = count + current;
                            }
                            lis.Cells[row, st] = count.ToString();
                        }


                        for (int r = rr; r < UZK.Count + 2 + rr; r++)
                        {
                            for (int c = 1; c <= st; c++)
                            {
                                lis.Cells[r, c].HorizontalAlignment = -4108;//xlCenter
                                lis.Cells[r, c].VerticalAlignment = -4108;//xlCenter

                                lis.Cells[r, c].Borders.ColorIndex = 0;
                                lis.Cells[r, c].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                lis.Cells[r, c].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                            }
                        }

                        lis.Range[lis.Cells[rr - 1, 1], lis.Cells[rr - 1, st]].Merge();
                        lis.Cells[rr - 1, 1] = "Результаты УЗК";



                        lis.Cells[rr - 1, 2].Borders.ColorIndex = 0;
                        lis.Cells[rr - 1, 2].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        lis.Cells[rr - 1, 2].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                        lis.Cells[rr - 1, 1].HorizontalAlignment = -4108;//xlCenter
                        lis.Cells[rr - 1, 1].VerticalAlignment = -4108;//xlCenter

                        lis.Range[lis.Cells[rr, 1], lis.Cells[rr + 1, st]].Interior.Color = Color.FromArgb(171, 164, 164);


                        xlApp.Run((object)"PrinStat");
                        #endregion
                    }


                    //for (int i = 0; i < details_two.Length; i++)
                    //{
                    //    for (int k = 0; k < details_one.Count; k++)
                    //    {


                    //    }
                    //}
                    #endregion

                    #region export_finished
                    xlApp.DisplayAlerts = true;

                    if (pdf_gen.Checked)
                    {
                        ewb.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, _manager.folderName + @"/1.pdf");
                    }
                    ewb.Save();
                    ewb.Close();
                    xlApp.Quit();
                    #endregion

                    #region pdf_generation

                    if (pdf_gen.Checked)
                    {
                        if (File.Exists(_manager.folderName + @"/Экспресс-отчёт.xlsm"))
                        {
                            OpenFileDialog f = new OpenFileDialog();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                pdfGeneration(_manager.folderName + @"/Экспресс-отчёт.xlsm", f.FileName);
                            }

                        }
                    }

                    #endregion
                }
            }
            
            if (word_gen.Checked == true)
            {
                string[] org = File.ReadAllLines(_manager.folderName + @"/Маршруты/Организация.txt");
                string[] inf = File.ReadAllLines(_manager.folderName + @"/Маршруты/Поиск.txt");
                string path = _manager.folderName;

                progressBar1.Maximum = 9999 + 999;

                #region application_create_and_open_pattern

                Application app = new Microsoft.Office.Interop.Word.Application();
                Document doc = app.Documents.Open(mainn + @"\patterns\patt.docx");

                #endregion

                #region doc_settings

                app.Visible = false;
                app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                app.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
                app.ScreenUpdating = false;

                #endregion

                #region title
                string sp = @"\";
 
                string[] kskc = path.Split(sp.ToCharArray());

                FindAndReplace(app, "#year", DateTime.Now.Year);

                try 
                {
                    kskc[kskc.Length - 1] = kskc[kskc.Length - 1].Replace("КС ", "КС-");
                }
                catch { }

                try
                {
                    FindAndReplace(app, "#kskc", kskc[kskc.Length - 1].ToUpper()); 
                } 
                catch { }

                FindAndReplace(app, "#datestart", _start);
                FindAndReplace(app, "#dateend", _end);

                try
                {
                    string[] zak = File.ReadAllLines(_manager.folderName + @"/Маршруты/Заказчик.txt");
                    FindAndReplace(app, "#transgaz", zak[2].ToUpper());
                }
                catch { }

                try
                {
                    string[] zak = File.ReadAllLines(_manager.folderName + @"/Маршруты/Заказчик.txt");
                    FindAndReplace(app, "#transga1", zak[2]);
                }
                catch { }

                try
                {
                    string[] orga = File.ReadAllLines(_manager.folderName + @"/Маршруты/Организация.txt");
                    FindAndReplace(app, "#svednum", orga[1]);
                    FindAndReplace(app, "#svedtodata", orga[2]);
                }
                catch { }

                #endregion

                #region table4
                int r = 2;
                Word.Table table = doc.Tables[4];

                for (int i = 0; i < 999; i++)
                {
                    string mpath = _manager.folderName + "/Маршруты/Маршрут - " + i + ".txt";

                    if (File.Exists(mpath))
                    {
                        string[] marshrut = File.ReadAllLines(mpath);
                        for (int m = 0; m < marshrut.Length; m++)
                        {
                            try
                            {
                                if (marshrut[m].Split(';')[0].Contains("погода"))
                                {
                                    string[] details = marshrut[m].Split(';');

                                    if (r != 2)
                                    {
                                        table.Rows.Add();
                                    }

                                    table.Cell(r, 1).Range.Text = details[1];
                                    table.Cell(r, 2).Range.Text = details[2];
                                    table.Cell(r, 3).Range.Text = details[3];
                                    r++;
                                }
                            }
                            catch
                            {
                                //MessageBox.Show(ex.Message);
                            }
                        }
                    }

                    progressBar1.Value++;
                }
                #endregion

                #region table6
                r = 2;
                table = doc.Tables[6];
                if (File.Exists(_manager.folderName + @"/Маршруты/Состав специалистов.txt"))
                {
                    string[] srva = File.ReadAllLines(_manager.folderName + @"/Маршруты/Состав специалистов.txt");

                    for (int i = 0; i < srva.Length; i++)
                    {
                        try
                        {
                            string[] details = srva[i].Split(';');

                            if (r != 2)
                            {
                                table.Rows.Add();
                            }

                            
                            table.Cell(r, 1).Range.Text = details[0];
                            table.Cell(r, 2).Range.Text = details[3];
                            table.Cell(r, 3).Range.Text = details[4];
                            table.Cell(r, 4).Range.Text = details[1];
                            table.Cell(r, 5).Range.Text = details[2];

                            r++;
                        }
                        catch
                        { }
                    }

                    
                    List<int> inds = new List<int>();

                    for (int i = 2; i <= table.Rows.Count; i++)
                    {
                        try 
                        {
                            
                        }
                        catch
                        {
                            
                        }
                    }
                    
                    

                    //inds.Clear();

                    //#region tableMergeColumn2
                    //for (int i = 2; i <= table.Rows.Count; i++)
                    //{
                    //    try
                    //    {
                    //        if (table.Cell(i, 2).Range.Text == table.Cell(i + 1, 2).Range.Text)
                    //        {
                    //            inds.Add(i);
                    //        }
                    //        else
                    //        {
                    //            table.Rows[inds[0]].Cells[2].Merge(table.Rows[inds[inds.Count - 1]].Cells[2]);
                    //            inds.Clear();
                    //        }
                    //    }
                    //    catch
                    //    { }
                    //}
                    //try
                    //{
                    //    for (int ro = 0; ro < inds.Count - 1; ro++)
                    //    {
                    //        table.Cell(inds[ro], 2).Range.Text = "";
                    //    }
                    //    if (inds.Count != 0) 
                    //    {
                    //        table.Rows[inds[0]].Cells[2].Merge(table.Rows[inds[inds.Count - 1]].Cells[2]);
                    //    }
                    //    inds.Clear();
                    //}
                    //catch
                    //{ }

                    //#endregion

                    //inds.Clear();

                    //#region tableMergeColumn3

                    //for (int i = 2; i <= table.Rows.Count; i++)
                    //{
                    //    try
                    //    {
                    //        if (table.Cell(i, 3).Range.Text == table.Cell(i + 1, 3).Range.Text)
                    //        {
                    //            inds.Add(i);
                    //        }
                    //        else
                    //        {
                    //            table.Rows[inds[0]].Cells[3].Merge(table.Rows[inds[inds.Count - 1]].Cells[3]);
                    //            inds.Clear();
                    //        }
                    //    }
                    //    catch
                    //    { }
                    //}
                    //try
                    //{
                    //    for (int ro = 0; ro < inds.Count - 1; ro++)
                    //    {
                    //        table.Cell(inds[ro], 3).Range.Text = "";
                    //    }
                    //    table.Rows[inds[0]].Cells[3].Merge(table.Rows[inds[inds.Count - 1]].Cells[3]);
                    //    inds.Clear();
                    //}
                    //catch
                    //{ }

                    //#endregion

                }

                List<string> diameters = new List<string>();
                List<string> types = new List<string>();

                for (int i = 0; i < 999; i++)
                {
                    string mpath = _manager.folderName + "/Журнал контроля/Маршрут - " + i + ".txt";

                    if (File.Exists(mpath))
                    {
                        string[] file = File.ReadAllLines(mpath);

                        foreach (var f in file)
                        {
                            try
                            {
                                double d = Convert.ToDouble(f.Split(';')[3]) * 1000;
                                diameters.Add(d.ToString());
                            }
                            catch
                            {
                                diameters.Add(f.Split(';')[3]);
                            }

                        }
                    }

                    string info = _manager.folderName + "/Маршруты/Маршрут - " + i + ".txt";

                    if (File.Exists(info))
                    {
                        string[] file = File.ReadAllLines(info);
                        types.Add(file[3]);
                    }

                    progressBar1.Value++;
                }


                diameters = diameters.Distinct().ToList();
                types = types.Distinct().ToList();

                string meters = "";
                for (int i = 0; i < diameters.Count; i++)
                {
                    if (i != diameters.Count - 1)
                    {
                        meters += diameters[i] + ", ";
                    }
                    else
                    {
                        meters += diameters[i];
                    }

                }
                FindAndReplace(app, "#diameters", meters);

                string ttypes = "";
                for (int i = 0; i < types.Count; i++)
                {
                    if (i != types.Count - 1)
                    {
                        ttypes += types[i] + "/";
                    }
                    else
                    {
                        ttypes += types[i];
                    }
                }
                FindAndReplace(app, "#trubatype", ttypes);


                if (File.Exists(_manager.folderName + "/Маршруты/Параметры трубопровода.txt"))
                {
                    string[] file = File.ReadAllLines(_manager.folderName + "/Маршруты/Параметры трубопровода.txt");

                    FindAndReplace(app, "#proectP", file[0].Split(';')[0]);
                    FindAndReplace(app, "#workP", file[0].Split(';')[1]);
                    FindAndReplace(app, "#trubacategory", file[0].Split(';')[2]);
                }
                else
                {
                    FindAndReplace(app, "#proectP", "-");
                    FindAndReplace(app, "#workP", "-");
                    FindAndReplace(app, "#trubacategory", "-");
                }

                #endregion

                #region table7
                r = 2;
                table = doc.Tables[7];

                string sredpath = _manager.folderName + "/Маршруты/Средства контроля.txt";
                string[] sredfile = File.ReadAllLines(sredpath);

                foreach (var s in sredfile)
                {
                    string[] row = s.Split(';');

                    if (r != 2)
                    {
                        table.Rows.Add();
                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        table.Cell(r, i + 1).Range.Text = row[i];
                    }

                    r++;
                }

                #endregion

                #region table23
                r = 4;
                
                table = doc.Tables[23];

                int sum = 0;

                double factsMetrajVTO = 0;
                double colOsobennostei = 0;

                double vikShovsCount = 0;
                double vikDefShovsCount = 0;
                double vikDefsCount = 0;
                double vikDefsDDK = 0;

                //double uzkFactMetr = 0; == factsMetrajVTO
                double uzkControlPl = 0;
                double uzkDefElemCount = 0;
                double uzkDefsCount = 0;
                double uzkDefsCountDDK = 0;


                for (int i = 0; i < 999; i++)
                {
                    bool isHere = false;
                    string vtopath = _manager.folderName + "/ВТО/Маршрут - " + i + "/Выявленные особенности маршрут - " + i + ".txt";
                    string vikpath = _manager.folderName + "/ВИК/Маршрут - " + i + "/Маршрут - " + i + ".txt";
                    string uzkpath = _manager.folderName + "/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt";

                    if (File.Exists(_manager.folderName + "/Маршруты/Маршрут - " + i + ".txt")) 
                    {
                        string[] ffile = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + i + ".txt");
                        table.Cell(r, 2).Range.Text = i.ToString();
                        try 
                        {
                            table.Cell(r, 1).Range.Text = ffile[17];
                        } 
                        catch 
                        {
                            table.Cell(r, 1).Range.Text = "-";
                        }
                        sum++;
                        
                    }

                    if (File.Exists(vtopath))
                    {
                        string[] ffile = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + i + ".txt");
                        string[] file = File.ReadAllLines(vtopath);

                        int vtocount = 0;
                        foreach (var f in file)
                        {
                            try
                            {
                                string[] fl = f.Split(';');

                                if (!fl[3].Contains("Особенность не обнаружена") && !fl[3].Contains("Участок неконтролепригоден"))
                                {
                                    vtocount++;
                                }
                            }
                            catch
                            {
                            }

                        }

                        //table.Cell(r, 2).Range.Text = i.ToString();
                        if (File.Exists(_manager.folderName + "/Маршруты/Маршрут - " + i + ".txt"))
                        {
                            table.Cell(r, 3).Range.Text = ffile[9];
                            table.Cell(r, 4).Range.Text = vtocount.ToString();
                            factsMetrajVTO += Convert.ToDouble(ffile[9]);
                            colOsobennostei += Convert.ToDouble(vtocount);
                        }
                        else
                        {
                            table.Cell(r, 3).Range.Text = 0.ToString();
                            table.Cell(r, 4).Range.Text = 0.ToString();
                        }


                        isHere = true;
                    }

                    if (File.Exists(vikpath))
                    {
                        string[] file = File.ReadAllLines(vikpath);
                        List<string> vikshovs = new List<string>();

                        int vikcount = 0;
                        int vikcount_nodefs = file.Length;
                        vikshovs.Clear();
                        foreach (var f in file)
                        {
                            try
                            {
                                string[] fl = f.Split(';');

                                if (!fl[5].Contains("Дефекты не обнаружены") && !fl[5].Contains("Участок неконтролепригоден"))
                                {
                                    vikcount++;
                                    vikshovs.Add(fl[2]);
                                }
                            }
                            catch
                            {
                            }
                            isHere = true;
                        }

                        vikshovs = vikshovs.Distinct().ToList();

                        table.Cell(r, 5).Range.Text = vikcount_nodefs.ToString();
                        table.Cell(r, 6).Range.Text = vikshovs.Count.ToString();
                        table.Cell(r, 7).Range.Text = vikcount.ToString();

                        vikShovsCount += Convert.ToDouble(vikcount_nodefs);
                        vikDefShovsCount += Convert.ToDouble(vikshovs.Count);
                        vikDefsCount += Convert.ToDouble(vikcount);
                    }

                    if (File.Exists(uzkpath))
                    {
                        int uzkdefs = 0;
                        string[] file = File.ReadAllLines(uzkpath);
                        List<string> uzkelems = new List<string>();

                        uzkelems.Clear();
                        foreach (var f in file)
                        {

                            string[] fl = f.Split(';');

                            if (fl[4] != "Дефектов не обнаружено" && fl[4] != "Участок неконтролепригоден")
                            {
                                uzkdefs++;
                                uzkelems.Add(fl[1]);
                            }
                        }
                        uzkelems = uzkelems.Distinct().ToList();

                        table.Cell(r, 11).Range.Text = uzkelems.Count.ToString();
                        uzkDefElemCount += Convert.ToDouble(uzkelems.Count);
                        table.Cell(r, 12).Range.Text = uzkdefs.ToString();
                        uzkDefsCount += Convert.ToDouble(uzkdefs);

                        if (File.Exists(_manager.folderName + "/Маршруты/Площадь - " + i + ".txt"))
                        {
                            string[] filee = File.ReadAllLines(_manager.folderName + "/Маршруты/Площадь - " + i + ".txt");
                            table.Cell(r, 10).Range.Text = filee[0];
                            uzkControlPl += Convert.ToDouble(filee[0]);
                        }
                        else
                        {
                            table.Cell(r, 10).Range.Text = 0.ToString();
                        }

                        if (File.Exists(_manager.folderName + "/Маршруты/Маршрут - " + i + ".txt"))
                        {
                            string[] ffile = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + i + ".txt");
                            
                            table.Cell(r, 9).Range.Text = ffile[9];
                            //delete r,3
                            //if (ffile[17] != "") 
                            //    table.Cell(r, 1).Range.Text = ffile[17];
                            //else
                            //    table.Cell(r, 1).Range.Text = "-";

                        }
                        else
                        {
                            //delete r,3
                            table.Cell(r, 9).Range.Text = 0.ToString();
                        }
                    }

                    
                    table.Cell(r, 8).Range.Text = "-";
                    table.Cell(r, 13).Range.Text = "-";
                    table.Cell(r, 14).Range.Text = "-";


                    if (isHere)
                    {
                        table.Rows.Add(); 
                        r++;
                        for (int q = 1; q < table.Columns.Count; q++)
                        {
                            table.Cell(r, q).Range.Text = "0";
                        }
                        isHere = false;
                    }

                    progressBar1.Value++;
                }

                table.Cell(r, 3).Range.Text = factsMetrajVTO.ToString();
                table.Cell(r, 4).Range.Text = colOsobennostei.ToString();
                table.Cell(r, 5).Range.Text = vikShovsCount.ToString();
                table.Cell(r, 6).Range.Text = vikDefShovsCount.ToString();
                table.Cell(r, 7).Range.Text = vikDefsCount.ToString();
                //table.Cell(r, 8).Range.Text = vikDefsCount.ToString();
                table.Cell(r, 9).Range.Text = factsMetrajVTO.ToString();
                table.Cell(r, 10).Range.Text = uzkControlPl.ToString();
                table.Cell(r, 11).Range.Text = uzkDefElemCount.ToString();
                table.Cell(r, 12).Range.Text = uzkDefsCount.ToString();
                //table.Cell(r, 13).Range.Text = ;


                table.Cell(r, 1).Range.Text = "Всего:";
                table.Cell(r, 2).Range.Text = (sum-1).ToString();

                #endregion

                #region table24

                r = 2;
                table = doc.Tables[24];
                string[] _sredstva = File.ReadAllLines(_manager.folderName + @"/Маршруты/Средства контроля.txt");

                for (int y = 0; y <= 999; y++)
                {
                    if (File.Exists(_manager.folderName + @"/Маршруты/Маршрут - " + y + ".txt"))
                    {
                        if (r != 2)
                        {
                            table.Rows.Add();
                        }

                        string[] fdata = File.ReadAllLines(_manager.folderName + @"/Маршруты/Маршрут - " + y + ".txt");


                        for (int ee = 0; ee < 10; ee++)
                        {
                            if (ee == 4)
                            {
                                table.Cell(r, ee + 1).Range.Text = y.ToString();
                            }
                            else
                            {
                                table.Cell(r, ee + 1).Range.Text = fdata[ee].ToString();
                            }

                        }

                        string sr_va = "";
                        for (int sr = 0; sr < _sredstva.Length; sr++)
                        {
                            sr_va += _sredstva[sr].Split(';')[0] + Environment.NewLine;
                            sr_va += "№ свидетельства о поверке: " + _sredstva[sr].Split(';')[1] + Environment.NewLine;
                            sr_va += "Действительно до: " + _sredstva[sr].Split(';')[2] + Environment.NewLine + Environment.NewLine;
                        }

                        string isp = org[0];

                        table.Cell(r, 11).Range.Text = isp;
                        table.Cell(r, 12).Range.Text = sr_va;
                        table.Cell(r, 13).Range.Text = fdata[14].Split(' ')[0];

                        r++;
                    }

                    progressBar1.Value++;
                }

                #endregion

                #region table25 //ADD ADK
                r = 2;
                table = doc.Tables[25];

                List<string> defects = new List<string>();
                List<string> noTableDefs = new List<string>();
                List<string> allDefs = new List<string>();

                for (int i = 0; i < 999; i++)
                {
                    string vikpath = _manager.folderName + "/ВИК/Маршрут - " + i + "/Маршрут - " + i + ".txt";

                    if (File.Exists(vikpath))
                    {
                        string[] file = File.ReadAllLines(vikpath);

                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');
                            if (fl[5] != ("Участок неконтролепригоден") &&
                                fl[5] != ("Дефекты не обнаружены") &&
                                fl[5] != (""))
                            {
                                defects.Add(fl[5]);
                                allDefs.Add(fl[5] + "_0");
                            }
                        }
                    }

                    progressBar1.Value++;
                }

                defects = defects.Distinct().ToList();

                for (int i = 0; i < defects.Count; i++)
                {
                    table.Columns.Add();
                    table.Cell(r - 1, i + 2).Range.Text = defects[i];
                }

                for (int i = 0; i < 999; i++)
                {
                    noTableDefs.Clear();
                    for (int j = 0; j < defects.Count; j++)
                    {
                        noTableDefs.Add(defects[j] + "_0");
                    }

                    string vikpath = _manager.folderName + "/ВИК/Маршрут - " + i + "/Маршрут - " + i + ".txt";

                    if (File.Exists(vikpath))
                    {
                        string[] file = File.ReadAllLines(vikpath);

                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');

                            for (int j = 0; j < defects.Count; j++)
                            {
                                if (fl[5] == defects[j])
                                {
                                    string[] tableElement = noTableDefs[j].Split('_');
                                    tableElement[1] = (Convert.ToInt32(tableElement[1]) + 1).ToString();
                                    noTableDefs[j] = tableElement[0] + "_" + tableElement[1];
                                }
                            }
                        }

                        if (r != 2)
                        {
                            table.Rows.Add();
                        }

                        for (int j = 0; j < noTableDefs.Count; j++)
                        {
                            table.Cell(r, j + 2).Range.Text = noTableDefs[j].Split('_')[1];
                        }
                        table.Cell(r, 1).Range.Text = i.ToString();

                        r++;
                    }


                }

                table.Rows.Add();
                int vik842 = 0;
                for (int j = 2; j < table.Columns.Count + 1; j++)
                {
                    int count = 0;
                    for (int i = 2; i < table.Rows.Count; i++)
                    {
                        string val = table.Cell(i, j).Range.Text;
                        count += Convert.ToInt32(val.Split('\r')[0]);
                    }

                    table.Cell(r, j).Range.Text = count.ToString();
                    vik842 += count;
                }

                table.Cell(r, 1).Range.Text = "Всего:";
                FindAndReplace(app, "#842vik", vik842.ToString());
                #endregion

                #region table26 ADD ADK
                r = 2;
                table = doc.Tables[26];

                List<string> uzk = new List<string>();
                List<string> uzkWdt = new List<string>();

                for (int i = 0; i < 999; i++)
                {
                    string uzkpath = _manager.folderName + "/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt";

                    if (File.Exists(uzkpath))
                    {
                        string[] file = File.ReadAllLines(uzkpath);

                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');

                            if (fl[4] != ("Участок неконтролепригоден") &&
                                fl[4] != ("Дефектов не обнаружено") &&
                                fl[4] != (""))
                            {
                                uzk.Add(fl[4]);
                                uzkWdt.Add(fl[4] + "_0");
                            }
                        }
                    }

                    progressBar1.Value++;
                }

                uzk = uzk.Distinct().ToList();

                for (int i = 0; i < uzk.Count; i++)
                {
                    table.Columns.Add();
                    table.Cell(r - 1, i + 2).Range.Text = uzk[i];
                }

                for (int i = 0; i < 999; i++)
                {
                    uzkWdt.Clear();
                    foreach (var u in uzk)
                    {
                        uzkWdt.Add(u + "_0");
                    }

                    string uzkpath = _manager.folderName + "/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt";

                    if (File.Exists(uzkpath))
                    {
                        string[] file = File.ReadAllLines(uzkpath);

                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');

                            for (int j = 0; j < uzk.Count; j++)
                            {
                                if (fl[4] == uzk[j])
                                {
                                    string[] tableElement = uzkWdt[j].Split('_');
                                    tableElement[1] = (Convert.ToInt32(tableElement[1]) + 1).ToString();
                                    uzkWdt[j] = tableElement[0] + "_" + tableElement[1];
                                }
                            }
                        }

                        if (r != 2)
                        {
                            table.Rows.Add();
                        }

                        for (int j = 0; j < uzkWdt.Count; j++)
                        {
                            table.Cell(r, j + 2).Range.Text = uzkWdt[j].Split('_')[1];
                        }
                        table.Cell(r, 1).Range.Text = i.ToString();

                        r++;
                    }
                }

                table.Rows.Add();
                int uzk843 = 0;
                for (int j = 2; j < table.Columns.Count + 1; j++)
                {
                    int count = 0;
                    for (int i = 2; i < table.Rows.Count; i++)
                    {
                        string val = table.Cell(i, j).Range.Text;
                        try
                        {
                            count += Convert.ToInt32(val.Split('\r')[0]);
                        }
                        catch
                        {
                        }


                    }

                    table.Cell(r, j).Range.Text = count.ToString();
                    uzk843 += count;
                }

                table.Cell(r, 1).Range.Text = "Всего:";
                FindAndReplace(app, "#843uzk", uzk843.ToString());
                #endregion

                #region table27 (3 column)

                r = 2;
                table = doc.Tables[27];
                Word.Row roww = table.Rows.Add();
                roww.Cells[1].Range.Text = "Ультразвуковой контроль основного металла тела трубы";
                //doc.Range(roww.Cells[1].Range.Start, roww.Cells[2].Range.End).ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                r++;

                for (int i = 0; i < uzk.Count; i++)
                {
                    table.Rows.Add();
                    table.Cell(r, 1).Range.Text = uzk[i];
                    table.Cell(r, 4).Range.Text = "Рекомендуется проведение ДДК дефектных участков в шурфах. " +
                                                  "Решение о проведении ДДК принято на основании методики автоматизированного внутритрубного технического диагностирования технологических " +
                                                  "трубопроводов компрессорных станций ПАО «Газпром» с применением ТДК-400-М-Л (ИТЦЯ.401171.014 Д1)";
                    r++;
                }

                for (int i = 0; i < 999; i++)
                {
                    string uzkkpath = _manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt";

                    if (File.Exists(uzkkpath))
                    {
                        string[] file = File.ReadAllLines(uzkkpath);

                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');

                            for (int j = 0; j < table.Rows.Count; j++)
                            {
                                string s = table.Cell(j, 1).Range.Text;
                                s = s.Replace("\r\a", string.Empty);
                                if (s == fl[4])
                                {
                                    string curCell = table.Cell(j, 2).Range.Text;
                                    curCell = curCell.Replace("\r\a", string.Empty);
                                    if (curCell == "")
                                    {
                                        curCell += fl[0] + "." + (Convert.ToInt32(fl[1]) - 1).ToString() + "-" + fl[0] + "." + fl[1];
                                    }
                                    else
                                    {
                                        curCell += ", " + fl[0] + "." + (Convert.ToInt32(fl[1]) - 1).ToString() + "-" + fl[0] + "." + fl[1];
                                    }

                                    table.Cell(j, 2).Range.Text = curCell;
                                }
                            }
                        }
                    }

                    progressBar1.Value++;
                }

                Word.Row rowww = table.Rows.Add();
                rowww.Cells[1].Range.Text = "Визуальный и измерительный контроль кольцевых сварных соединений";
                r++;

                for (int i = 0; i < defects.Count; i++)
                {
                    table.Rows.Add();
                    table.Cell(r, 1).Range.Text = defects[i];
                    table.Cell(r, 4).Range.Text = "Рекомендуется проведение ДДК сварного шва. " +
                                                  "Решение о проведении ДДК принято на основании СТО Газпром 2 - 2.4 - 083 - 2006," +
                                                  " п.7.1 СТО Газпром 2 - 2.4 - 715 - 2012";
                    r++;
                }

                for (int i = 0; i < 999; i++)
                {
                    string vikpath = _manager.folderName + @"/ВИК/Маршрут - " + i + @"/Маршрут - " + i + ".txt";

                    if (File.Exists(vikpath))
                    {
                        string[] file = File.ReadAllLines(vikpath);

                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');

                            for (int j = 0; j < table.Rows.Count; j++)
                            {
                                string s = table.Cell(j, 1).Range.Text;
                                s = s.Replace("\r\a", string.Empty);
                                if (s == fl[5])
                                {
                                    string curCell = table.Cell(j, 2).Range.Text;
                                    curCell = curCell.Replace("\r\a", string.Empty);
                                    if (curCell == "")
                                    {
                                        curCell += fl[0] + "." + fl[1];
                                    }
                                    else
                                    {
                                        curCell += ", " + fl[0] + "." + fl[1];
                                    }

                                    table.Cell(j, 2).Range.Text = curCell;
                                }
                            }
                        }
                    }
                }

                doc.Range(roww.Cells[1].Range.Start, roww.Cells[4].Range.End).Cells.Merge();
                doc.Range(rowww.Cells[1].Range.Start, rowww.Cells[4].Range.End).Cells.Merge();

                roww.Shading.BackgroundPatternColor = WdColor.wdColorGray05;
                rowww.Shading.BackgroundPatternColor = WdColor.wdColorGray05;

                for (int c = 1; c <= 4; c++)
                {
                    table.Cell(1, c).Range.Shading.BackgroundPatternColor = WdColor.wdColorGray05;
                }


                #endregion

                #region yes_or_no stat

                string[] vto = Directory.GetFiles(_manager.folderName + "/ВТО", "*", SearchOption.AllDirectories);
                if (vto.Length > 0)
                {
                    FindAndReplace(app, "#isvtodefs", "да");
                    FindAndReplace(app, "#isvtoraz", "да");
                    FindAndReplace(app, "#isvtorasp", "да");
                }
                else
                {
                    FindAndReplace(app, "#isvtodefs", "нет");
                    FindAndReplace(app, "#isvtoraz", "нет");
                    FindAndReplace(app, "#isvtorasp", "нет");
                }

                string[] vik = Directory.GetFiles(_manager.folderName + "/ВИК", "*", SearchOption.AllDirectories);
                if (vik.Length > 0)
                {
                    FindAndReplace(app, "#isvikdefs", "да");
                    FindAndReplace(app, "#isvikraz", "да");
                    FindAndReplace(app, "#isvikrasp", "да");
                }
                else
                {
                    FindAndReplace(app, "#isvikdefs", "нет");
                    FindAndReplace(app, "#isvikraz", "нет");
                    FindAndReplace(app, "#isvikrasp", "нет");
                }

                string[] uzkk = Directory.GetFiles(_manager.folderName + @"/Неразрушающий контроль", "*", SearchOption.AllDirectories);
                if (uzkk.Length > 0)
                {
                    FindAndReplace(app, "#isuzt", "да");
                    FindAndReplace(app, "#isuzkk", "да");
                    FindAndReplace(app, "#isuzkraz", "да");
                    FindAndReplace(app, "#isuzkrasp", "да");
                }
                else
                {
                    FindAndReplace(app, "#isuzt", "нет");
                    FindAndReplace(app, "#isuzkraz", "нет");
                    FindAndReplace(app, "#isuzkrasp", "нет");
                }

                string[] sdtt = Directory.GetFiles(_manager.folderName + @"/Толщинометрия", "*", SearchOption.AllDirectories);
                if (sdtt.Length > 0)
                {
                    FindAndReplace(app, "#issdt", "да");
                }
                else
                {
                    FindAndReplace(app, "#issdt", "нет");
                }

                #endregion

                #region table28
                r = 3;
                table = doc.Tables[28];

                for (int i = 0; i < 999; i++)
                {
                    string elem = _manager.folderName + "/Журнал контроля/Маршрут - " + i + ".txt";

                    if (File.Exists(elem))
                    {
                        string[] file = File.ReadAllLines(elem);

                        foreach (var f in file)
                        {
                            string[] row = f.Split(';');

                            if (r != 3)
                            {
                                table.Rows.Add();
                            }

                            for (int c = 1; c <= 17; c++)
                            {
                                if (c == 9)
                                {
                                    try
                                    {
                                        table.Cell(r, c).Range.Text = Math.Round(Convert.ToDouble(row[c - 1]) / 15,2).ToString();
                                    }
                                    catch 
                                    {
                                        table.Cell(r, c).Range.Text = row[c - 1];
                                    }
                                    
                                }
                                else 
                                {
                                    table.Cell(r, c).Range.Text = row[c - 1];
                                }
                                
                            }

                            r++;
                        }

                    }

                    progressBar1.Value++;

                }

                #endregion

                #region table29 (photos)

                r = 1;
                table = doc.Tables[29];

                string photosPath = _manager.folderName + "/Фото/";
                string[] photoss = Directory.GetFiles(photosPath);
                List<string> photos = new List<string>();

                for (int i = 0; i < photoss.Length; i++)
                {
                    if (photoss[i].Contains("Фото"))
                    {
                        photos.Add(photoss[i]);
                    }
                }

                try
                {
                    photos = CustomSort(photos).ToList();
                }
                catch
                {
                }



                foreach (var p in photos)
                {
                    if (r != 3)
                    {
                        table.Rows.Add();
                        table.Rows.Add();
                    }

                    Range cellRange = table.Cell(r, 1).Range;
                    Word.InlineShape ils = cellRange.InlineShapes.AddPicture(p, false, true, cellRange);
                    r++;

                    ils.Width = 150;
                    ils.Height = 150;
                    table.Cell(r, 1).Range.Text = "Фото №" + Path.GetFileNameWithoutExtension(p);
                    r++;
                }




                #endregion

                #region table30
                r = 3;
                table = doc.Tables[30];

                for (int i = 0; i < 999; i++)
                {
                    string vikpath = _manager.folderName + @"/ВИК/Маршрут - " + i + @"/Маршрут - " + i + ".txt";

                    if (File.Exists(vikpath))
                    {
                        string[] file = File.ReadAllLines(vikpath);

                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');

                            if (r != 3)
                            {
                                table.Rows.Add();
                            }

                            for (int j = 0; j < 12; j++)
                            {
                                table.Cell(r, j + 1).Range.Text = fl[j];
                            }

                            r++;
                        }
                    }

                    progressBar1.Value++;
                }

                #endregion

                #region table31
                r = 3;
                table = doc.Tables[31];

                for (int i = 0; i < 999; i++)
                {
                    string sdt = _manager.folderName + "/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt";

                    if (File.Exists(sdt))
                    {
                        string[] file = File.ReadAllLines(sdt);


                        foreach (var f in file)
                        {
                            string[] fl = f.Split(';');

                            if (r != 3)
                            {
                                table.Rows.Add();
                            }

                            for (int j = 0; j < 14; j++)
                            {
                                try
                                {
                                    table.Cell(r, j + 1).Range.Text = fl[j];
                                }
                                catch
                                {
                                    table.Cell(r, j + 1).Range.Text = "-";
                                }
                            }

                            r++;
                        }
                    }

                    progressBar1.Value++;
                }

                #endregion

                #region table33

                r = 2;
                table = doc.Tables[33];
                List<string> namesList = new List<string>();

                for (int i = 0; i < 999; i++)
                {
                    string uzkkpath = _manager.folderName + @"/Неразрушающий контроль/Неразрушающий контроль маршрут - " + i + ".txt";
                    string mpath = _manager.folderName + "/Журнал контроля/Маршрут - " + i + ".txt";

                    if (File.Exists(uzkkpath))
                    {
                        string[] file = File.ReadAllLines(uzkkpath);

                        foreach (var f in file)
                        {
                            if (f.Split(';')[10] != "-")
                            {
                                if (File.Exists(mpath))
                                {
                                    if (r != 2)
                                    {
                                        table.Rows.Add();
                                    }

                                    string[] mar = File.ReadAllLines(mpath);
                                    string[] row = f.Split(';');
                                    double proc = 0;

                                    try
                                    {
                                        foreach (var m in mar)
                                        {
                                            if (m.Split(';')[1] == row[1])
                                            {

                                                if (row[10].Contains('.'))
                                                {
                                                    string[] st = row[10].Split('.');
                                                    row[10] = st[0] + "," + st[1];
                                                }

                                                proc = Convert.ToDouble(row[10])
                                                       /
                                                       Convert.ToDouble(m.Split(';')[6])
                                                       *
                                                       100;
                                                proc = Math.Round(proc, 1);

                                                table.Cell(r, 3).Range.Text = m.Split(';')[5];

                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    table.Cell(r, 1).Range.Text = row[3] + " (" + row[0] + "." + row[3] + ")";
                                    table.Cell(r, 2).Range.Text = row[1];

                                    table.Cell(r, 4).Range.Text = "-";
                                    table.Cell(r, 5).Range.Text = "-";
                                    table.Cell(r, 6).Range.Text = row[4];
                                    try
                                    {
                                        if (row[6].Contains('.'))
                                        {
                                            string[] st = row[6].Split('.');
                                            row[6] = st[0] + "," + st[1];
                                        }
                                        if (row[7].Contains('.'))
                                        {
                                            string[] st = row[7].Split('.');
                                            row[7] = st[0] + "," + st[1];
                                        }
                                        table.Cell(r, 7).Range.Text = Math.Round(Convert.ToDouble(row[6]), 1).ToString() + "/" + Math.Round(Convert.ToDouble(row[7]), 1).ToString();
                                    }
                                    catch
                                    {
                                        table.Cell(r, 7).Range.Text = row[6] + "/" + row[7];
                                    }
                                    table.Cell(r, 8).Range.Text = row[5];
                                    table.Cell(r, 9).Range.Text = row[8];
                                    table.Cell(r, 10).Range.Text = row[9];
                                    table.Cell(r, 11).Range.Text = proc.ToString();
                                    r++;

                                    namesList.Add(row[0] + "_" + row[1]);
                                }


                            }
                        }
                    }

                    progressBar1.Value++;
                }

                string[] photosss = Directory.GetFiles(_manager.folderName, "Элемент*", SearchOption.AllDirectories);


                r = 1;
                table = doc.Tables[34];

                foreach (var n in namesList)
                {
                    string[] name = n.Split('_');

                    foreach (var p in photosss)
                    {
                        string[] cphoto = p.Split('_');

                        if (cphoto[1] == name[0] && cphoto[2] == name[1])
                        {
                            try
                            {
                                if (r != 1)
                                {
                                    table.Rows.Add();
                                }
                                table.Cell(r, 11).Range.Text = "Детализация трубы №" + cphoto[1];
                                r++;

                                table.Rows.Add();
                                Range cellRange = table.Cell(r, 1).Range;
                                Word.InlineShape ils = cellRange.InlineShapes.AddPicture(p, false, true, cellRange);
                                r++;
                            }
                            catch { }
                        }
                    }
                }

                #endregion

                #region table35

                r = 1;
                table = doc.Tables[35];

                string pwpath = _manager.folderName;
                string[] allphotos = Directory.GetFiles(pwpath, "*", SearchOption.AllDirectories);
                List<string> pwphotos = new List<string>();

                foreach (var pw in allphotos)
                {
                    if (pw.ToLower().Contains("каналы пв"))
                    {
                        pwphotos.Add(pw);
                    }
                }

                try
                {
                    pwphotos = CustomSort(pwphotos).ToList();
                }
                catch
                {
                }



                foreach (var pw in pwphotos)
                {
                    table.Cell(r, 1).Range.Text = "Детализация " + Path.GetFileNameWithoutExtension(pw);
                    table.Rows.Add();
                    r++;

                    Range cellRange = table.Cell(r, 1).Range;
                    Word.InlineShape ils = cellRange.InlineShapes.AddPicture(pw, false, true, cellRange);
                    table.Rows.Add();
                    r++;

                    table.Cell(r, 1).Range.Text = "На развертке выделены наиболее глубокие дефекты " +
                                                  Path.GetFileNameWithoutExtension(pw) +
                                                  ", параметры дефектов приведены в таблице 14.1.";
                    table.Rows.Add();
                    r++;
                }
                #endregion

                #region table36

                int col = 1;
                r = 1;
                table = doc.Tables[36];

                string[] allarchphotos = Directory.GetFiles(_manager.folderName, "*", SearchOption.AllDirectories);
                List<string> skans = new List<string>();
                foreach (var p in allarchphotos)
                {
                    if (p.ToLower().Contains("скан"))
                    {
                        skans.Add(p);
                    }
                }

                try
                {
                    skans = CustomSort(skans).ToList();
                }
                catch
                {
                }



                foreach (var s in skans)
                {
                    table.Cell(r, col).Range.Text = Path.GetFileNameWithoutExtension(s);
                    Range cellRange = table.Cell(r + 1, col).Range;
                    Word.InlineShape ils = cellRange.InlineShapes.AddPicture(s, false, true, cellRange);
                    ils.Width = 600;
                    ils.Height = 500;

                    r++;
                    r++;
                    table.Rows.Add();
                    table.Rows.Add();
                }
                #endregion

                #region table37

                //EMPTY

                #endregion

                #region save_and_quit

                doc.SaveAs(_manager.folderName + @"/Экспресс-отчёт.docx");
                app.Quit();
                if (app != null) Marshal.ReleaseComObject(app);

                #endregion
            }

            MessageBox.Show("Выгрузка окончена!");
            progressBar1.Value = 0;

            timer2.Stop();
            //label9.Text = "";
        }

        public static IEnumerable<string> CustomSort(IEnumerable<string> list)
        {
            int maxLen = list.Select(s => s.Length).Max();

            return list.Select(s => new
                {
                    OrgStr = s,
                    SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, char.IsDigit(m.Value[0]) ? ' ' : '\xffff'))
                })
                .OrderBy(x => x.SortStr)
                .Select(x => x.OrgStr);
        }
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchDiactitics = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchDiactitics, ref matchControl);
        }

        public void pdfGeneration(string excel_file, string word_file) 
        {

            Word.Application word = new Word.Application();
            Word.Document file = word.Documents.Open(word_file);
            file.ExportAsFixedFormat(_manager.folderName + @"/2.pdf", Word.WdExportFormat.wdExportFormatPDF);
            word.Quit();

            string[] lstFiles = new string[2];

            lstFiles[0] = _manager.folderName + @"/1.pdf";
            lstFiles[1] = _manager.folderName + @"/2.pdf";




            PdfReader reader = null;
            iTextSharp.text.Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = _manager.folderName + @"/Отчёт.pdf";

            sourceDocument = new iTextSharp.text.Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            sourceDocument.Open();

            try
            {
                //Loop through the files list 
                for (int f = 0; f < lstFiles.Length; f++)
                {
                    int pages = get_pageCcount(lstFiles[f]);

                    reader = new PdfReader(lstFiles[f]);
                    //Add pages of current file 
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }
                //At the end save the output file 
                sourceDocument.Close();


                int get_pageCcount(string fi)
                {
                    using (StreamReader sr = new StreamReader(File.OpenRead(fi)))
                    {
                        Regex regex = new Regex(@"/Type\s*/Page[^s]");
                        MatchCollection matches = regex.Matches(sr.ReadToEnd());

                        return matches.Count;
                    }
                }

                File.Delete(_manager.folderName + @"/1.pdf");
                File.Delete(_manager.folderName + @"/2.pdf");
            }
            catch
            {

            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            int trueCount = 0;

            foreach (DataGridViewRow t in dataGridView1.Rows) 
            {
                try 
                {
                    if ((bool)t.Cells[3].Value == true)
                    {
                        trueCount++;
                    }
                } catch { }
                
            }
            if (trueCount > 0)
            {
                foreach (DataGridViewRow true_ in dataGridView1.Rows)
                {
                    true_.Cells[3].Value = false;
                }
            }
            else 
            {
                foreach (DataGridViewRow false_ in dataGridView1.Rows)
                {
                    false_.Cells[3].Value = true;
                }
            }
        }

        void ProcessKiller(string name) 
        {
            Process[] processes = Process.GetProcessesByName(name); // Получим все процессы Google Chrome

            foreach (Process process in processes) // В цикле их переберём
            {
                process.Kill(); // завершим процесс
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProcessKiller("excel");
            ProcessKiller("WINWORD");
        }

        private void Менеджер_файлов_Click(object sender, EventArgs e)
        {
            
        }

        DateTime date1 = new DateTime(0, 0);
        private void timer1_Tick(object sender, EventArgs e)
        {
            processCountRefresh("excel");

        }
        static void InsertPageNumbers(Word.Document doc, Word.WdPageNumberAlignment alignment)
        {
            //Переход на вторую страницу (вернее, в начало третьей)
            Word.Range range = doc.Range().GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, 1);

            //Вставка разрыва раздела в конце второй страницы. 
            doc.Sections.Add(range, Word.WdSectionStart.wdSectionContinuous);

            //Колонтитул второго раздела
            Word.HeaderFooter hf = doc.Sections[doc.Sections.Count].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];

            //Открепление нумерации от колонтитула предыдущего раздела
            hf.LinkToPrevious = false;

            //Не начинать нумерацию с 1
            hf.PageNumbers.RestartNumberingAtSection = false;

            //Добавление нумерации по заданному выравниванию
            hf.PageNumbers.Add(alignment, true);
        }

        void TextCrearting(Spire.Doc.Document doc, string text) 
        {
            Section sec = doc.AddSection();
            Paragraph par = sec.AddParagraph();
            par.ApplyStyle(BuiltinStyle.Heading1);
            Spire.Doc.Fields.TextRange textBox = par.AppendText(text+ "\n");
        }
        void TableCreating(List<string> rows, Spire.Doc.Table table, ParagraphStyle style) 
        {
            for (int i = 0; i < rows.Count; i++)
            {
                string[] onerow = rows[i].Split(';');

                for (int j = 0; j < onerow.Length-1; j++)
                {
                    
                    TableCell cell = table.Rows[i+1].Cells[j];

                    //Add paragraph and fill text

                    Spire.Doc.Documents.Paragraph para = cell.AddParagraph();

                    para.Text = onerow[j];

                    //Apply paragraph style and set table style
                    para.ApplyStyle(style.Name);
                    para.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                    cell.CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    table.Rows[i].Height = 60;
                }
            }
        }

        private void word_gen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            date1 = date1.AddSeconds(1);
            //label9.Text = date1.ToString("mm:ss");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void exgen_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void exgen_CheckedChanged(object sender, EventArgs e)
        {
            if (exgen.Checked)
            {
                elements_magazine.Checked = true;
                VTOcheck.Checked = true;
                VIKcheck.Checked = true;
                UZKcheck.Checked = true;
                tolchik_check.Checked = true;
                img_VTO.Checked = true;
                detal.Checked = true;
                stat.Checked = true;
            }
            else 
            {
                elements_magazine.Checked = false;
                VTOcheck.Checked = false;
                VIKcheck.Checked = false;
                UZKcheck.Checked = false;
                tolchik_check.Checked = false;
                img_VTO.Checked = false;
                detal.Checked = false;
                stat.Checked = false;
            }
        }
    }
}
