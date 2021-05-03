using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Reporting_v1._0
{

    public partial class Конвертер_журналов : Form
    {
        Manager _manager = new Manager();
        TextBox _value = new TextBox();

        string path = "";
        string path_w = "";

        string mainn = Environment.CurrentDirectory;
        public Конвертер_журналов(Manager manager, TextBox value)
        {
            _manager = manager;
            _value = value;
            InitializeComponent();

            label2.Visible = false;
            label1.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();

            if (of.ShowDialog() == DialogResult.OK) 
            {
                path = of.FileName;
                file_path.Text = path;

                path_w = Path.GetDirectoryName(path);

                if (!Path.GetExtension(path).Contains("xls"))
                {
                    MessageBox.Show("Убедитесь, что выбрали нужный файл!\nРасширение файла отличается от расширений программы Excel");
                }
            }
        }

        void ExcelParse(string path, string journal_name, int[] cells) 
        {
            Excel.Application app = new Excel.Application();

            Excel.Workbook workbook = app.Workbooks.Open(path, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value);

            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(journal_name);
            
            Excel.Range range = worksheet.UsedRange;


            int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row-4;
            int columns = worksheet.Columns.Count;

            Directory.CreateDirectory(path_w+@"/Экспорт");
            using (File.Create(path_w + @"/Экспорт/"+journal_name+".txt")) ;
            using (StreamWriter sw = new StreamWriter(path_w + @"/Экспорт/" + journal_name + ".txt"))
            {
                for (int r = 6; r <= rows; r++)
                {
                    for (int i = 0; i < cells.Length; i++) 
                    {
                        if (i == cells.Length - 1) 
                        {
                            sw.Write(worksheet.Cells[r, cells[i]].Text);
                        }
                        else sw.Write(worksheet.Cells[r, cells[i]].Text + ";");
                    }

                    sw.WriteLine();
                }
            }

        }

        void VikParse(string path, string journal_name)
        {
            Excel.Application app = new Excel.Application();

            Excel.Workbook workbook = app.Workbooks.Open(path, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value);

            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(journal_name);

            Excel.Range range = worksheet.UsedRange;


            int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row - 4;
            int columns = worksheet.Columns.Count;

            Directory.CreateDirectory(path_w + @"/Экспорт");
            using (File.Create(path_w + @"/Экспорт/" + journal_name + ".txt")) ;
            using (StreamWriter sw = new StreamWriter(path_w + @"/Экспорт/" + journal_name + ".txt"))
            {
                for (int r = 6; r <= rows; r++)
                {
                    int ddo = 0;

                    try 
                    {
                        ddo = Convert.ToInt32(worksheet.Cells[r, 3].Text) - 1;
                    } 
                    catch { }
                      

                    sw.Write(worksheet.Cells[r, 2].Text + ";");
                    sw.Write(worksheet.Cells[r, 1].Text + ";");
                    sw.Write(ddo.ToString() + ";");
                    sw.Write(worksheet.Cells[r, 3].Text + ";");
                    sw.Write(worksheet.Cells[r, 16].Text + ";");
                    sw.Write(worksheet.Cells[r, 17].Text + ";");
                    sw.Write(worksheet.Cells[r, 19].Text + ";");
                    sw.Write(worksheet.Cells[r, 20].Text + ";");
                    sw.Write(worksheet.Cells[r, 21].Text + ";");
                    sw.Write(worksheet.Cells[r, 18].Text + ";");
                    sw.Write("-" + ";");
                    sw.Write(worksheet.Cells[r, 23].Text + ";");
                    sw.Write("-" );

                    sw.WriteLine();
                }
            }

        }

        void UzkParse(string path, string journal_name)
        {
            Excel.Application app = new Excel.Application();

            Excel.Workbook workbook = app.Workbooks.Open(path, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value);

            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(journal_name);

            Excel.Range range = worksheet.UsedRange;


            int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row - 4;
            int columns = worksheet.Columns.Count;

            Directory.CreateDirectory(path_w + @"/Экспорт");
            using (File.Create(path_w + @"/Экспорт/" + journal_name + ".txt")) ;
            using (StreamWriter sw = new StreamWriter(path_w + @"/Экспорт/" + journal_name + ".txt"))
            {
                for (int r = 6; r <= rows; r++)
                {
                    sw.Write(worksheet.Cells[r, 2].Text + ";");
                    sw.Write(worksheet.Cells[r, 1].Text + ";");
                    sw.Write(worksheet.Cells[r, 6+1].Text + ";");
                    //sw.Write(worksheet.Cells[r, 10 + 1].Text + ";");
                    sw.Write(worksheet.Cells[r, 11 + 1].Text + ";");
                    sw.Write(worksheet.Cells[r, 12 + 1].Text + ";");
                    sw.Write(worksheet.Cells[r, 14 ].Text + ";");
                    sw.Write(worksheet.Cells[r, 15 + 1].Text + ";");
                    sw.Write(worksheet.Cells[r, 16 + 1].Text + ";");
                    sw.Write(worksheet.Cells[r, 17 + 1].Text + ";");
                    sw.Write(worksheet.Cells[r, 19 ].Text + ";");
                    sw.Write(worksheet.Cells[r, 18 + 3].Text + ";"); //
                    sw.Write("-" + ";");
                    sw.Write("-" + ";");
                    sw.Write(worksheet.Cells[r, 20+2].Text + ";");

                    sw.WriteLine();
                }
            }

        }
        void ImageBlackGenerator(Label label25, Label label26, Color cococo, Excel.Workbook workbook)
        {
            List<string> allELS = new List<string>();
            List<string> allVTOS = new List<string>();
            List<string> allVIKS = new List<string>();
            List<string> allMA = new List<string>();

            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item("Журнал элементов");
            int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            

            for (int i = 3; i <=rows-2; i++) 
            {
                try 
                {
                    string cell = worksheet.Cells[i, 1].Value;

                    if (!cell.Contains("Маршрут"))
                    {
                        string element = worksheet.Cells[i, 3].Value;
                        if (element.Contains("Труба"))
                        {
                            string row = "";
                            for (int j = 1; j <= 16; j++)
                            {
                                row += worksheet.Cells[i, j].Value + ";";
                            }
                            MessageBox.Show(row);
                            allELS.Add(row);
                        }
                    }

                }
                catch
                { }
            }


            string[] colors = File.ReadAllLines(mainn + "/src/Цвета МА.txt");
            string[] colors_vto = File.ReadAllLines(mainn + "/src/Цвета ВТО.txt");

            


            //MessageBox.Show(allELS.Count.ToString());

            for (int i = 0; i < allELS.Count; i++)
            {
               

                string[] el = allELS[i].Split(';');


                #region shema2_load

                //string picPath = @"C:\Users\" + Environment.UserName + @"\Desktop\Система Формирования Отчётов\patterns\details patts\";

                //if (Convert.ToInt32(el[1]) == 1)
                //{
                //    shema2Gen(picPath, "Элемент_1.png", el, 400, 45, 400, 101, 115, 175, 620);
                //}

                //if (Convert.ToInt32(el[1]) == 2)
                //{
                //    shema2Gen(picPath, "Элемент_2.png", el, 450, 45, 450, 101, 165, 175, 670);
                //}

                //if (Convert.ToInt32(el[1]) == 3)
                //{
                //    shema2Gen(picPath, "Элемент_3.png", el, 500, 45, 500, 101, 205, 175, 720);
                //}

                //if (Convert.ToInt32(el[1]) == 4)
                //{
                //    shema2Gen(picPath, "Элемент_4.png", el, 550, 45, 550, 101, 255, 175, 770);
                //}

                //if (Convert.ToInt32(el[1]) == 5)
                //{
                //    shema2Gen(picPath, "Элемент_5.png", el, 600, 45, 600, 101, 305, 175, 820);
                //}

                //if (Convert.ToInt32(el[1]) >= 6)
                //{
                //    shema2Gen_6(picPath, "Элемент_6.png", el, 650, 45, 650, 101, 355, 175, 870);
                //}



                #endregion

                double height = 0;
                double weight = 0;
                try
                {
                    height = Convert.ToDouble(el[4]) * 100;
                    weight = Convert.ToDouble(el[5]) * 100 - Convert.ToDouble(el[6]) / 10;

                    MessageBox.Show(height + " "+ weight);
                }
                catch
                {
                    break;
                }


                List<string> osob = new List<string>();

                int defs = 0;

                int pad_x = 140; //60
                int pad_y = 40; //20

                int bit_weight = Convert.ToInt32(weight + pad_x + 20) + 100;
                int bit_height = Convert.ToInt32(height + 50 + pad_y);

                Image img = new Bitmap(bit_weight, bit_height);


                using (Graphics gr = Graphics.FromImage(img))
                {
                    gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height);

                    if (CHBready.Checked)
                    {
                        gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height - 50);
                    }
                    else gr.FillRectangle(new SolidBrush(Color.FromArgb(1, 13, 77)), 0, 0, bit_weight, bit_height - 50);


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
                            if (CHBready.Checked) gr.DrawLine(new Pen(Color.Black), pad_x - 80, y, bit_weight - 15, y);

                            else gr.DrawLine(new Pen(Color.White), pad_x - 80, y, bit_weight - 15, y);


                            string n = "";
                            if (vert_count < 10)
                            {
                                n = " " + vert_count;
                            }
                            else n = vert_count.ToString();

                            if (CHBready.Checked) gr.DrawString(n, label25.Font, new SolidBrush(Color.Black), pad_x - 26 - 80, y - 5);
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


                    //try
                    //{
                    //    if (Convert.ToInt32(el[1]) > 1)
                    //    {
                    //        double shov_one = Convert.ToDouble(el[8]);
                    //        double shov_two = Convert.ToDouble(el[9]);

                    //        double svov_one_1 = Convert.ToInt32(allELS[i - 1].Split(';')[8]);
                    //        double svov_two_1 = Convert.ToInt32(allELS[i - 1].Split(';')[9]);

                    //        double svov_one_2 = Convert.ToInt32(allELS[i + 1].Split(';')[8]);
                    //        double svov_two_2 = Convert.ToInt32(allELS[i + 1].Split(';')[9]);

                    //        double cc_of_30 = height / 360;
                    //        Math.Round(cc_of_30, 0);

                    //        gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_one * cc_of_30 + pad_y / 2), Convert.ToInt32(weight) + 5, 2);
                    //        gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_two * cc_of_30 + pad_y / 2), Convert.ToInt32(weight) + 5, 2);

                    //        gr.FillRectangle(new SolidBrush(Color.Red), pad_x - 80, Convert.ToInt32(svov_one_1 * cc_of_30 + pad_y / 2), pad_x / 2 + 10, 2);
                    //        gr.FillRectangle(new SolidBrush(Color.Red), pad_x - 80, Convert.ToInt32(svov_two_1 * cc_of_30 + pad_y / 2), pad_x / 2 + 10, 2);

                    //        gr.FillRectangle(new SolidBrush(Color.Red), Convert.ToInt32(weight) + pad_x + 5, Convert.ToInt32(svov_one_2 * cc_of_30 + pad_y / 2), 80, 2);
                    //        gr.FillRectangle(new SolidBrush(Color.Red), Convert.ToInt32(weight) + pad_x + 5, Convert.ToInt32(svov_two_2 * cc_of_30 + pad_y / 2), 80, 2);

                    //    }
                    //    else
                    //    {
                    //        double shov_one = Convert.ToDouble(el[8]);
                    //        double shov_two = Convert.ToDouble(el[9]);

                    //        double cc_of_30 = height / 360;
                    //        Math.Round(cc_of_30, 0);

                    //        gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_one * cc_of_30 + pad_y / 2), Convert.ToInt32(weight), 2);

                    //        gr.FillRectangle(new SolidBrush(Color.Red), pad_x, Convert.ToInt32(shov_two * cc_of_30 + pad_y / 2), Convert.ToInt32(weight), 2);
                    //    }


                    //}
                    //catch
                    //{

                    //}



                    //PRODOLNIE SHVI END

                    //for (int k = 0; k < allVTOS.Count; k++)
                    //{
                    //    try
                    //    {

                    //    }
                    //    catch { }
                    //    string[] vto = allVTOS[k].Split(';');

                    //    if (vto[0] == el[0] && vto[1] == el[1] && !vto[2].ToString().Contains("-"))
                    //    {
                    //        double vto_x1 = Convert.ToDouble(vto[4]) * 100;
                    //        double vto_x2 = Convert.ToDouble(vto[5]) * 100;

                    //        double vto_y1 = Convert.ToDouble(vto[6]);
                    //        double vto_y2 = Math.Round(Convert.ToDouble(vto[9]) / 10, 0);


                    //        //double vto_w = (Convert.ToDouble(vto[8])) / 10;
                    //        //double vto_h = (Convert.ToDouble(vto[9])) / 10;

                    //        ////double vto_x = (
                    //        //double vto_y = (Convert.ToDouble(vto[5])) * 100;

                    //        Color coco = Color.FromArgb(300 / 100 * 30, 0, 0, 0);
                    //        SolidBrush br = new SolidBrush(coco);

                    //        if (CHBready.Checked)
                    //        {
                    //            Color fontCol = Color.White;
                    //            SolidBrush fontBr = new SolidBrush(fontCol);
                    //        }
                    //        else
                    //        {
                    //            Color fontCol = Color.Black;
                    //            SolidBrush fontBr = new SolidBrush(fontCol);
                    //        }


                    //        //osob.Add("Механическое повреждение" + ";" + 255 + "," + 5 + "," + 188);

                    //        for (int c = 0; c < colors_vto.Length; c++)
                    //        {
                    //            if (vto[3].Contains(colors_vto[c].Split(';')[0]))
                    //            {
                    //                string[] col = colors_vto[c].Split(';')[1].Split(',');

                    //                int r = Convert.ToInt32(col[0]);
                    //                int g = Convert.ToInt32(col[1]);
                    //                int b = Convert.ToInt32(col[2]);
                    //                int alpha = Convert.ToInt32(col[3]);

                    //                Color color = Color.FromArgb(alpha, r, g, b);
                    //                br = new SolidBrush(color);
                    //                Color color1 = Color.FromArgb(r, g, b);
                    //                if (osob.Count == 0)
                    //                {
                    //                    osob.Add(colors_vto[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                    //                }
                    //                else
                    //                {
                    //                    int s = 0;
                    //                    for (int co = 0; co < osob.Count; co++)
                    //                    {
                    //                        string[] cl = osob[co].Split(';')[1].Split(',');
                    //                        int rr = Convert.ToInt32(cl[0]);
                    //                        int gg = Convert.ToInt32(cl[1]);
                    //                        int bb = Convert.ToInt32(cl[2]);

                    //                        Color cll = Color.FromArgb(rr, gg, bb);

                    //                        if (color1 == cll)
                    //                        {
                    //                            s++;
                    //                        }
                    //                    }

                    //                    if (s == 0)
                    //                    {
                    //                        osob.Add(colors_vto[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                    //                    }
                    //                }

                    //            }
                    //        }
                    //        //TODO RASHET RASPOLOJENIYA






                    //        //gr.FillRectangle(br, Convert.ToInt32(vto_x)+pad_x+1/*- Convert.ToInt32(vto_w)/2*/, Convert.ToInt32(vto_y)+pad_y+1/* - Convert.ToInt32(vto_y)/2*/,
                    //        //                     Convert.ToInt32(vto_w),                           Convert.ToInt32(vto_y));

                    //        double c_of_30 = height / 360;
                    //        Math.Round(c_of_30, 0);

                    //        gr.FillRectangle(br,
                    //                                                    Convert.ToInt32(vto_x1) + pad_x,                        //x1

                    //                                                     Convert.ToInt32(vto_y1 * c_of_30) + pad_y / 2,         //y1

                    //                                                     Convert.ToInt32(vto_x2),                               //x2

                    //                                                    Convert.ToInt32(vto_y2));                               //y2

                    //        if (CHBready.Checked) gr.DrawString(vto[0] + "." + vto[2], label26.Font, new SolidBrush(Color.Black),
                    //                      Convert.ToInt32(vto_x1) + pad_x + 1,
                    //                      Convert.ToInt32(vto_y1) + pad_y / 2 - label26.Font.Size * 2);

                    //        else gr.DrawString(vto[0] + "." + vto[2], label26.Font, new SolidBrush(Color.White),
                    //                      Convert.ToInt32(vto_x1) + pad_x + 1,
                    //                      Convert.ToInt32(vto_y1) + pad_y / 2 - label26.Font.Size * 2);



                    //        defs++;
                    //    }
                    //}

                    //for (int j = 0; j < allMA.Count; j++)
                    //{
                    //    string[] ma = allMA[j].Split(';');

                    //    if (ma[0] == el[0] && ma[1] == el[1] && (!ma[3].ToString().Contains("-") || !ma[4].ToString().Contains("Дефектов не обнаружено")))
                    //    {
                    //        double ma_x1 = Math.Round(Convert.ToDouble(Rmer(ma[5])) / 10, 0);
                    //        double ma_x2 = Math.Round(Convert.ToDouble(Rmer(ma[8])) / 10, 0);

                    //        //double ma_y1 = Math.Round(Convert.ToDouble(Rmer(ma[6])) / 10, 0);
                    //        double ma_y2 = Math.Round(Convert.ToDouble(Rmer(ma[9])) / 10, 0);

                    //        double ma_y1 = Convert.ToDouble(Rmer(ma[6]));
                    //        //double ma_y2 = Convert.ToDouble(Rmer(ma[7]));

                    //        Color color = Color.FromArgb(400 / 100 * 30, 0, 0, 0); ;
                    //        for (int c = 0; c < colors.Length; c++)
                    //        {
                    //            if (ma[4].Contains(colors[c].Split(';')[0]))
                    //            {
                    //                string[] col = colors[c].Split(';')[1].Split(',');

                    //                int r = Convert.ToInt32(col[0]);
                    //                int g = Convert.ToInt32(col[1]);
                    //                int b = Convert.ToInt32(col[2]);
                    //                int alpha = Convert.ToInt32(col[3]);

                    //                color = Color.FromArgb(alpha, r, g, b);
                    //                Color color1 = Color.FromArgb(r, g, b);
                    //                if (osob.Count == 0)
                    //                {
                    //                    osob.Add(colors[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                    //                }
                    //                else
                    //                {
                    //                    int s = 0;
                    //                    for (int co = 0; co < osob.Count; co++)
                    //                    {
                    //                        string[] cl = osob[co].Split(';')[1].Split(',');
                    //                        int rr = Convert.ToInt32(cl[0]);
                    //                        int gg = Convert.ToInt32(cl[1]);
                    //                        int bb = Convert.ToInt32(cl[2]);

                    //                        Color cll = Color.FromArgb(rr, gg, bb);

                    //                        if (color1 == cll)
                    //                        {
                    //                            s++;
                    //                        }
                    //                    }

                    //                    if (s == 0)
                    //                    {
                    //                        osob.Add(colors[c].Split(';')[0] + ";" + r + "," + g + "," + b);
                    //                    }
                    //                }

                    //            }
                    //        }


                    //        SolidBrush br = new SolidBrush(color);



                    //        //gr.FillRectangle(br, Convert.ToInt32(ma_x)+pad_x+1, Convert.ToInt32(ma_y) +pad_y+1, 
                    //        //                     Convert.ToInt32(ma_w),                           Convert.ToInt32(ma_h));



                    //        //double one_of_meter = weight / 12;
                    //        //Math.Round(one_of_meter/100,0);
                    //        //MessageBox.Show(one_of_meter.ToString());

                    //        double c_of_30 = height / 360;
                    //        Math.Round(c_of_30, 0);

                    //        gr.FillRectangle(br,
                    //                                                    Convert.ToInt32(ma_x1) + pad_x,                        //x1

                    //                                                     Convert.ToInt32(ma_y1 * c_of_30) + pad_y / 2,         //y1

                    //                                                     Convert.ToInt32(ma_x2),                               //x2

                    //                                                    Convert.ToInt32(ma_y2));                               //y2

                    //        if (CHBready.Checked) gr.DrawString(ma[0] + "." + ma[3], label26.Font, new SolidBrush(Color.Black),
                    //                       Convert.ToInt32(ma_x1) + pad_x + 1,
                    //                       Convert.ToInt32(ma_y1) + pad_y + 1 / 2 - label26.Font.Size * 2);

                    //        else gr.DrawString(ma[0] + "." + ma[3], label26.Font, new SolidBrush(Color.White),
                    //                      Convert.ToInt32(ma_x1) + pad_x + 1,
                    //                      Convert.ToInt32(ma_y1) + pad_y + 1 / 2 - label26.Font.Size * 2);

                    //        defs++;
                    //    }
                    //}

                    //if (defs > 0)
                    //{

                    //    Color fontCol = Color.Black;


                    //    SolidBrush fontBr = new SolidBrush(fontCol);

                    //    //MessageBox.Show(osob.Count.ToString());

                    //    int maxLen = 15;

                    //    try
                    //    {
                    //        int le_0 = osob[0].Split(';')[0].Length;
                    //        int le_1 = osob[1].Split(';')[0].Length;
                    //        int le_2 = osob[2].Split(';')[0].Length;

                    //        if (le_0 > le_1 && le_0 > le_2)
                    //            maxLen = le_0 + 5;

                    //        else if (le_1 > le_2)
                    //            maxLen = le_1 + 5;

                    //        else
                    //            maxLen = le_2 + 5;
                    //    }
                    //    catch { }



                    //    //ПЕРВЫЙ СТОЛБЕЦ
                    //    try
                    //    {
                    //        string[] os = osob[0].Split(';');
                    //        int r = Convert.ToInt32(os[1].Split(',')[0]);
                    //        int g = Convert.ToInt32(os[1].Split(',')[1]);
                    //        int b = Convert.ToInt32(os[1].Split(',')[2]);

                    //        Color col = Color.FromArgb(r, g, b);

                    //        gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 5) + pad_y, 9, 9);
                    //        gr.DrawString("   - " + osob[0].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 2) + pad_y);

                    //    }
                    //    catch { }

                    //    try
                    //    {
                    //        string[] os = osob[1].Split(';');
                    //        int r = Convert.ToInt32(os[1].Split(',')[0]);
                    //        int g = Convert.ToInt32(os[1].Split(',')[1]);
                    //        int b = Convert.ToInt32(os[1].Split(',')[2]);

                    //        Color col = Color.FromArgb(r, g, b);

                    //        gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 20) + pad_y, 9, 9);
                    //        gr.DrawString("   - " + osob[1].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 17) + pad_y);

                    //    }
                    //    catch { }

                    //    try
                    //    {
                    //        string[] os = osob[2].Split(';');
                    //        int r = Convert.ToInt32(os[1].Split(',')[0]);
                    //        int g = Convert.ToInt32(os[1].Split(',')[1]);
                    //        int b = Convert.ToInt32(os[1].Split(',')[2]);

                    //        Color col = Color.FromArgb(r, g, b);

                    //        gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 35) + pad_y, 9, 9);
                    //        gr.DrawString("   - " + osob[2].Split(';')[0], label25.Font, fontBr, 15, Convert.ToInt32(height + 32) + pad_y);

                    //    }
                    //    catch { }


                    //    //ВТОРОЙ СТОЛБЕЦ
                    //    try
                    //    {
                    //        string[] os = osob[3].Split(';');
                    //        int r = Convert.ToInt32(os[1].Split(',')[0]);
                    //        int g = Convert.ToInt32(os[1].Split(',')[1]);
                    //        int b = Convert.ToInt32(os[1].Split(',')[2]);

                    //        Color col = Color.FromArgb(r, g, b);

                    //        gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 5) + pad_y, 9, 9);
                    //        gr.DrawString("   - " + osob[3].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 2) + pad_y);
                    //    }
                    //    catch { }

                    //    try
                    //    {
                    //        string[] os = osob[4].Split(';');
                    //        int r = Convert.ToInt32(os[1].Split(',')[0]);
                    //        int g = Convert.ToInt32(os[1].Split(',')[1]);
                    //        int b = Convert.ToInt32(os[1].Split(',')[2]);

                    //        Color col = Color.FromArgb(r, g, b);

                    //        gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 20) + pad_y, 9, 9);
                    //        gr.DrawString("   - " + osob[4].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 17) + pad_y);
                    //    }
                    //    catch { }

                    //    try
                    //    {
                    //        string[] os = osob[5].Split(';');
                    //        int r = Convert.ToInt32(os[1].Split(',')[0]);
                    //        int g = Convert.ToInt32(os[1].Split(',')[1]);
                    //        int b = Convert.ToInt32(os[1].Split(',')[2]);

                    //        Color col = Color.FromArgb(r, g, b);

                    //        gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 35) + pad_y, 9, 9);
                    //        gr.DrawString("   - " + osob[5].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 32) + pad_y);
                    //    }
                    //    catch { }

                    MessageBox.Show(img.Size.ToString());
                    img.Save(@"C:\Users\Рабочий дух\Desktop\ТЕСТИРОВАНИЕ\ЭО\Элемент_" + el[0] + "_" + el[1] + "_.png", ImageFormat.Png);

                    //}
                }


            }
        }

        string Rmer(string num)
        {
            if (num.Contains('.'))
            {
                string[] dt = num.Split('.');
                num = dt[0] + "," + dt[1];
            }
            return num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region excel_lists_export
            string fileName = Path.GetFileNameWithoutExtension(path);
            string path_ = Path.GetDirectoryName(path);



            Excel.Application app1 = new Excel.Application();

            Aspose.Cells.Workbook workbook1 = new Aspose.Cells.Workbook(path_ + "/" + fileName + ".xlsx");

            workbook1.Save(path_ + "/" + fileName + " (Новый).xlsm", Aspose.Cells.SaveFormat.Xlsm);

            label2.Visible = true;
            label1.Visible = true;

            timer1.Start();

            if (vto_export.Checked)
            {
                int[] cellsVTO = { 2, 1, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
                ExcelParse(path, "ВТО", cellsVTO);
            }
            if (vik_export.Checked)
            {
                VikParse(path, "ВИК");
            }
            if (uzk_export.Checked)
            {
                UzkParse(path, "УЗК");
            }


            Excel.Application app = new Excel.Application();

            Excel.Workbook workbook = app.Workbooks.Open(path_ + "/" + fileName + " (Новый).xlsm", Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value);

            app.Interactive = false;
            app.EnableEvents = false;
            app.DisplayAlerts = false;


            try
            {


                

            }
            catch 
            {
            
            }
            if (elements.Checked) 
            {
                #region preparing_to_export
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item("ВИК");
                int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

                var newWS = (Excel.Worksheet)workbook.Sheets.Add(After: workbook.ActiveSheet);
                newWS.Name = "Журнал элементов";

                #endregion

                #region header_seting

                newWS.Columns.AutoFit();
                newWS.Rows.AutoFit();

                for (int i = 1; i <= 7; i++)
                {
                    newWS.Range[newWS.Cells[1, i], newWS.Cells[2, i]].Merge();
                    newWS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].Orientation = 90;
                }

                for (int i = 10; i <= 16; i++)
                {
                    newWS.Range[newWS.Cells[1, i], newWS.Cells[2, i]].Merge();
                    newWS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].Orientation = 90;
                }

                newWS.Range[newWS.Cells[1, 8], newWS.Cells[1, 9]].Merge();

                Excel.Range headerRange = newWS.Range["A" + 1, "M" + 1];
                headerRange.RowHeight = 129;

                Excel.Range headerRange1 = newWS.Range["A" + 2, "M" + 2];
                headerRange1.RowHeight = 23;

                newWS.Columns[3].ColumnWidth = 30;

                #endregion

                #region header_text

                newWS.Cells[1, 1] = "№ участка";
                newWS.Cells[1, 2] = "№ эл-та п/п";
                newWS.Cells[1, 3] = "Тип эл-та";
                newWS.Cells[1, 4] = "Наружный диаметр" + Environment.NewLine + " эл-та, cм";

                newWS.Cells[1, 5] = "Длина, м";
                newWS.Cells[1, 6] = "Толщина стенки, мм";
                newWS.Cells[1, 7] = "Конструкция эл-та";

                newWS.Cells[1, 8] = "угловая ориентация" + Environment.NewLine + " продольных швов, град.";
                newWS.Cells[2, 8] = "№1";
                newWS.Cells[2, 9] = "№2";

                newWS.Cells[1, 10] = "Расстояние" + Environment.NewLine + " от начала маршрута" + Environment.NewLine + " до начала элемента";
                newWS.Cells[1, 11] = "Плоскость расположения";
                newWS.Cells[1, 12] = "Угол изгиба отвода, град";
                newWS.Cells[1, 13] = "Угол наклона " + Environment.NewLine + "плоскости расположения," + Environment.NewLine + " град";
                newWS.Cells[1, 14] = "Наружный диаметр " + Environment.NewLine + "ответвления переходного тройника";
                newWS.Cells[1, 15] = "Высота тройника, мм";
                newWS.Cells[1, 16] = "Наружный диаметр " + Environment.NewLine + "перехода(второй)";
                #endregion

                #region table_export

                for (int i = 6; i <= rows; i++)
                {
                    newWS.Cells[i - 3, 1] = worksheet.Cells[i, 2];
                    newWS.Cells[i - 3, 2] = worksheet.Cells[i, 1];
                    newWS.Cells[i - 3, 3] = worksheet.Cells[i, 6];
                    newWS.Cells[i - 3, 4] = worksheet.Cells[i, 4];

                    newWS.Cells[i - 3, 5] = worksheet.Cells[i, 8];
                    newWS.Cells[i - 3, 6] = worksheet.Cells[i, 7];
                    newWS.Cells[i - 3, 7] = "-";
                    newWS.Cells[i - 2, 8] = worksheet.Cells[i, 9];
                    newWS.Cells[i - 3, 9] = worksheet.Cells[i, 10];
                    newWS.Cells[i - 3, 10] = worksheet.Cells[i, 5];
                    newWS.Cells[i - 2, 11] = "-";
                    newWS.Cells[i - 2, 12] = "-";
                    newWS.Cells[i - 2, 13] = "-";
                    newWS.Cells[i - 2, 14] = "-";
                    newWS.Cells[i - 2, 15] = "-";
                    newWS.Cells[i - 2, 16] = "-";

                }

                #endregion

                #region empty_merge

                for (int i = 3; i <= rows; i++)
                {

                    string val = newWS.Cells[i, 2].Text;
                    if (val.Contains("Маршрут"))
                    {
                        newWS.Range[newWS.Cells[i, 1], newWS.Cells[i, 16]].Merge();

                        newWS.Cells[i, 1].HorizontalAlignment = -4108;//xlCenter
                        newWS.Cells[i, 1].VerticalAlignment = -4108;//xlCenter

                        Color color = Color.FromArgb(205, 205, 205);

                        newWS.Range[newWS.Cells[i, 1], newWS.Cells[i, 13]].Interior.Color = Color.FromArgb(205, 205, 205);
                    }
                    if (val == "")
                    {
                        newWS.Rows[i].Delete();
                    }
                }

                for (int i = 1; i <= rows; i++)
                {
                    for (int j = 1; j <= 16; j++)
                    {
                        newWS.Cells[i, j].HorizontalAlignment = -4108;//xlCenter
                        newWS.Cells[i, j].VerticalAlignment = -4108;//xlCenter
                    }

                }

                #endregion

                string MacroCommand = "'" + mainn+"/patterns/patt2.xlsm" + "'!" + "PrinEL";
                app.DisplayAlerts = false;
                app.Run(MacroCommand);
            }

            if (vto_export.Checked)
            {
                #region preparing_to_export
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item("ВТО");
                worksheet.Select();
                int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

                worksheet.Cells.ClearFormats();
                worksheet.Cells.ClearContents();

                worksheet.Delete();

                var newWS = (Excel.Worksheet)workbook.Sheets.Add(After: workbook.ActiveSheet);
                newWS.Name = "ВТО";

                string[] vto = File.ReadAllLines(path_w + @"/Экспорт/ВТО.txt");

                #endregion

                #region header_setting

                newWS.Columns.AutoFit();
                newWS.Rows.AutoFit();

                newWS.Range[newWS.Cells[1, 7], newWS.Cells[1, 8]].Merge();
                for (int i = 1; i <= 6; i++) 
                {
                    newWS.Range[newWS.Cells[1, i], newWS.Cells[2, i]].Merge();
                    newWS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].Orientation = 90;
                }

                newWS.Cells[1, 7].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[1, 7].VerticalAlignment = -4108;//xlCenter

                newWS.Cells[2, 7].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 7].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 7].Orientation = 90;

                newWS.Cells[2, 8].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 8].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 8].Orientation = 90;

                for (int i = 9; i <= 13; i++) 
                {
                    newWS.Range[newWS.Cells[1, i], newWS.Cells[2, i]].Merge();
                    newWS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].Orientation = 90;
                }

                Excel.Range headerRange = newWS.Range["A" + 1, "M" + 1];
                headerRange.RowHeight = 100;

                newWS.Columns[4].ColumnWidth = 20;
                newWS.Columns[7].ColumnWidth = 10;
                newWS.Columns[8].ColumnWidth = 10;
                newWS.Columns[12].ColumnWidth = 52;
                newWS.Columns[13].ColumnWidth = 20;

                #endregion

                #region header_text
                newWS.Cells[1, 1] = "Номер"+Environment.NewLine+" диагностируемого" + Environment.NewLine + " участка";
                newWS.Cells[1, 2] = "№ элемента п/п";
                newWS.Cells[1, 3] = "№ особенности п/п";
                newWS.Cells[1, 4] = "Тип особенности";
                newWS.Cells[1, 5] = "Расстояние от начала" + Environment.NewLine + " элемента до особенности, м";
                newWS.Cells[1, 6] = "Расстояние от начала" + Environment.NewLine + " элемента до конца особенности, м";

                newWS.Cells[1, 7] = "Угловая ориентация" + Environment.NewLine + " особенности, час";
                 
                newWS.Cells[1, 9] = "Измеренная длина" + Environment.NewLine + " особенности, мм";
                newWS.Cells[1, 10] = "Измеренная ширина" + Environment.NewLine + " особенности , мм";
                newWS.Cells[1, 11] = "№ фото выявленных" + Environment.NewLine + " особенностей";
                newWS.Cells[1, 12] = "Рекомендации";
                newWS.Cells[1, 13] = "Примечание";

                newWS.Cells[2, 7] = "начало";
                newWS.Cells[2, 8] = "конец";

                #endregion

                #region teble_export
                for (int i = 0; i < vto.Length; i++)
                {
                    string[] vtoha = vto[i].Split(';');

                    for (int j = 0; j < vtoha.Length; j++)
                    {
                        if (vtoha[1].Contains("Маршрут")) 
                        {
                            newWS.Range[newWS.Cells[i+3, 1], newWS.Cells[i+3, 13]].Merge();

                            newWS.Cells[i+3, 1].HorizontalAlignment = -4108;//xlCenter
                            newWS.Cells[i+3, 1].VerticalAlignment = -4108;//xlCenter

                            Color color = Color.FromArgb(205, 205, 205);

                            newWS.Range[newWS.Cells[i+3, 1], newWS.Cells[i+3, 13]].Interior.Color = Color.FromArgb(205, 205, 205);

                            newWS.Cells[i + 3, j + 1] = vtoha[1];
                        }
                        else
                        {
                            newWS.Cells[i + 3, j + 1] = vtoha[j];
                        }
                        
                    }
                }

                #endregion

                #region empty_merge

                for (int i = 1; i <= vto.Length; i++) 
                {
                    if (newWS.Cells[i + 3, 1].Text == "")
                    {
                        newWS.Cells[i + 3, 1] = newWS.Cells[i + 2, 1];
                    }

                    if (newWS.Cells[i + 3, 2].Text == "")
                    {
                        newWS.Cells[i + 3, 2] = newWS.Cells[i + 2, 2];
                    }
                    if (newWS.Cells[i + 3, 3].Text == "" && newWS.Cells[i + 3, 2].Text != "")
                    {
                        newWS.Rows[i+3].Delete();
                    }
                }

                #endregion

                #region finish_setting
                newWS.Columns[12].Delete();
                newWS.Range["A" + 1, "M" + rows].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                newWS.Range["A" + 1, "M" + rows].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                string MacroCommand = "'" + mainn+"/patterns/patt2.xlsm" + "'!" + "PrinVTO";
                app.DisplayAlerts = false;
                app.Run(MacroCommand);

                #endregion

            }
            if (vik_export.Checked)
            {
                #region preparing_to_export
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item("ВИК");
                int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

                worksheet.Cells.ClearFormats();
                worksheet.Cells.ClearContents();

                worksheet.Delete();

                var newWS = (Excel.Worksheet)workbook.Sheets.Add(After: workbook.ActiveSheet);
                newWS.Name = "ВИК";

                string[] vik = File.ReadAllLines(path_w + @"/Экспорт/ВИК.txt");

                #endregion

                #region header_setting

                newWS.Columns.AutoFit();
                newWS.Rows.AutoFit();

                Excel.Range headerRange = newWS.Range["A" + 1, "M" + 1];
                headerRange.RowHeight = 55;

                Excel.Range headerRange1 = newWS.Range["A" + 2, "M" + 2];
                headerRange1.RowHeight = 100;

                newWS.Range[newWS.Cells[1, 7], newWS.Cells[1, 8]].Merge();
                newWS.Range[newWS.Cells[1, 9], newWS.Cells[1, 10]].Merge();

                for (int i = 1; i <= 6; i++) 
                {
                    newWS.Range[newWS.Cells[1, i], newWS.Cells[2, i]].Merge();

                    newWS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].Orientation = 90;
                }

                newWS.Range[newWS.Cells[1, 11], newWS.Cells[2, 11]].Merge();
                newWS.Range[newWS.Cells[1, 12], newWS.Cells[2, 12]].Merge();
                newWS.Range[newWS.Cells[1, 13], newWS.Cells[2, 13]].Merge();

                newWS.Cells[1, 11].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[1, 11].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[1, 11].Orientation = 90;

                newWS.Cells[1, 12].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[1, 12].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[1, 12].Orientation = 90;

                newWS.Cells[1, 13].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[1, 13].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[1, 13].Orientation = 90;

                newWS.Cells[1, 7].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[1, 7].VerticalAlignment = -4108;//xlCenter

                newWS.Cells[1, 9].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[1, 9].VerticalAlignment = -4108;//xlCenter

                newWS.Cells[2, 7].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 7].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 7].Orientation = 90;

                newWS.Cells[2, 8].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 8].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 8].Orientation = 90;

                newWS.Cells[2, 9].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 9].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 9].Orientation = 90;

                newWS.Cells[2, 10].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 10].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 10].Orientation = 90;

                newWS.Columns[6].ColumnWidth = 45;
                newWS.Columns[12].ColumnWidth = 20;
                newWS.Columns[13].ColumnWidth = 30;
                #endregion

                #region header_text

                newWS.Cells[1, 1] = "Номер"+Environment.NewLine+ " диагностируемого" + Environment.NewLine + " участка";
                newWS.Cells[1, 2] = "№  КСС  п/п";
                newWS.Cells[1, 3] = "№ элемента" + Environment.NewLine + " до сварного шва";
                newWS.Cells[1, 4] = "№ элемента после" + Environment.NewLine + " сварного шва";
                newWS.Cells[1, 5] = "№ дефекта п/п";
                newWS.Cells[1, 6] = "Тип дефекта";
                newWS.Cells[1, 7] = "Угловая ориентация" + Environment.NewLine + " дефекта";

                newWS.Cells[1, 9] = "Геометрические " + Environment.NewLine + "характеристики дефектов";

                newWS.Cells[1, 11] = "Диапазон номеров" + Environment.NewLine + " кадров (при ВИК)";
                newWS.Cells[1, 12] = "Рекомендации";
                newWS.Cells[1, 13] = "Примечание";


                newWS.Cells[2, 7] = "Начало, час";
                newWS.Cells[2, 8] = "Конец, час";
                newWS.Cells[2, 9] = "Длина, мм";
                newWS.Cells[2, 10] = "Высота "+Environment.NewLine+"(глубина), мм";


                #endregion

                #region table_export

                newWS.Range["F" + 4, "F" + rows].WrapText = true;
                newWS.Range["L" + 4, "L" + rows].WrapText = true;

                for (int i = 0; i < vik.Length; i++) 
                {
                    string[] vikuha = vik[i].Split(';');

                    for (int j = 0; j < vikuha.Length; j++) 
                    {
                        if (vikuha[1].Contains("Маршрут"))
                        {
                            newWS.Range[newWS.Cells[i + 3, 1], newWS.Cells[i + 3, 13]].Merge();

                            newWS.Cells[i + 3, 1].HorizontalAlignment = -4108;//xlCenter
                            newWS.Cells[i + 3, 1].VerticalAlignment = -4108;//xlCenter

                            Color color = Color.FromArgb(205, 205, 205);

                            newWS.Range[newWS.Cells[i + 3, 1], newWS.Cells[i + 3, 1]].Interior.Color = Color.FromArgb(205, 205, 205);

                            newWS.Cells[i + 3, j + 1] = vikuha[1];
                        }
                        else
                        {
                            newWS.Cells[i + 3, j + 1] = vikuha[j];
                        }
                    }
                }

                #endregion

                #region empty_merge

                for (int i = 1; i <= vik.Length; i++) 
                {
                    if (newWS.Cells[i + 3, 5].Text == "Дефектов не обнаружено") 
                    {
                        //newWS.Range[newWS.Cells[i + 3, 5], newWS.Cells[i + 3, 10]].Merge();
                        //newWS.Cells[i+3, 5].HorizontalAlignment = -4108;//xlCenter
                        //newWS.Cells[i+3, 5].VerticalAlignment = -4108;//xlCenter

                        for (int c = 5; c <= 10; c++)
                        {
                            if (c != 6)
                            {
                                newWS.Cells[i + 3, c] = "-";
                            }
                            else newWS.Cells[i + 3, c] = "Дефектов не обнаружено";
                        }

                    }

                    if (newWS.Cells[i + 3, 1].Text == "") 
                    {
                        newWS.Cells[i + 3, 1] = newWS.Cells[i + 2, 1];
                        newWS.Cells[i + 3, 2] = newWS.Cells[i + 2, 2];
                        newWS.Cells[i + 3, 3] = newWS.Cells[i + 2, 3];
                        newWS.Cells[i + 3, 4] = newWS.Cells[i + 2, 4];
                    }
                }

                #endregion

                #region finish_setting

                newWS.Columns[12].Delete();

                newWS.Range["A" + 1, "M" + rows].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                newWS.Range["A" + 1, "M" + rows].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                string MacroCommand = "'" + mainn+"/patterns/patt2.xlsm" + "'!" + "PrinVIK";
                app.DisplayAlerts = false;
                app.Run(MacroCommand);

                #endregion
            }
            if (uzk_export.Checked)
            {
                #region preparing_to_export
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.get_Item("УЗК");
                int rows = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

                worksheet.Delete();

                var newWS = (Excel.Worksheet)workbook.Sheets.Add(After: workbook.ActiveSheet);
                newWS.Name = "УЗК";

                string[] uzk = File.ReadAllLines(path_w + @"/Экспорт/УЗК.txt");
                #endregion

                #region header_settings

                newWS.Columns.AutoFit();
                newWS.Rows.AutoFit();



                Excel.Range headerRange = newWS.Range["A" + 1, "M" + 1];
                headerRange.RowHeight = 40;

                Excel.Range headerRange1 = newWS.Range["A" + 2, "M" + 2];
                headerRange1.RowHeight = 135;

                for (int i = 1; i <= 5; i++) 
                {
                    newWS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].Orientation = 90;

                    newWS.Range[newWS.Cells[1, i], newWS.Cells[2, i]].Merge();
                }



                for (int i = 9; i <= 14; i++)
                {
                    newWS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                    newWS.Cells[1, i].Orientation = 90;

                    newWS.Range[newWS.Cells[1, i], newWS.Cells[2, i]].Merge();
                }

                newWS.Cells[1, 6].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[1, 6].VerticalAlignment = -4108;//xlCenter

                newWS.Cells[2, 6].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 6].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 6].Orientation = 90;

                newWS.Cells[2, 7].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 7].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 7].Orientation = 90;

                newWS.Cells[2, 8].HorizontalAlignment = -4108;//xlCenter
                newWS.Cells[2, 8].VerticalAlignment = -4108;//xlCenter
                newWS.Cells[2, 8].Orientation = 90;

                newWS.Range[newWS.Cells[1, 6], newWS.Cells[1, 8]].Merge();

                newWS.Columns[4].ColumnWidth = 27;
                newWS.Columns[5].ColumnWidth = 27;
                newWS.Columns[14].ColumnWidth = 45;
                #endregion

                #region header_text

                newWS.Cells[1, 1] = "Номер диагностируемого"+Environment.NewLine+" участка";
                newWS.Cells[1, 2] = "№ элемента п/ п";
                newWS.Cells[1, 3] = "Измеренная" + Environment.NewLine + " толщина стенки " + Environment.NewLine + "элемента, мм";
                newWS.Cells[1, 4] = "№ дефекта п/п";
                newWS.Cells[1, 5] = "Тип дефекта";
                newWS.Cells[2, 6] = "От кольцевого" + Environment.NewLine + " шва, мм";
                newWS.Cells[2, 7] = "Угловая ориентация" + Environment.NewLine + " дефекта начало, час";
                newWS.Cells[2, 8] = "Угловая ориентация" + Environment.NewLine + " дефекта конец, час";
                newWS.Cells[1, 9] = "Длина дефекта, мм";
                newWS.Cells[1, 10] = "Ширина дефекта, мм";
                newWS.Cells[1, 11] = "Глубина дефекта,мм";
                newWS.Cells[1, 12] = "Относительная" + Environment.NewLine + " глубина дефекта %";
                newWS.Cells[1, 13] = "Примечание";
                newWS.Cells[1, 14] = "Рекомендации к проведению " + Environment.NewLine + "ДДК в шурфах методами НК";

                newWS.Cells[1, 6] = "Расположение дефекта";

                #endregion

                #region table_export

                newWS.Range["D" + 4, "E" + rows].WrapText = true;
                newWS.Range["N" + 4, "N" + rows].WrapText = true;

                for (int i = 0; i < uzk.Length; i++)
                {
                    try 
                    {
                        string[] uzkha = uzk[i].Split(';');

                        for (int j = 0; j < uzkha.Length; j++)
                        {
                            if (uzkha[1].Contains("Маршрут"))
                            {
                                newWS.Range[newWS.Cells[i + 3, 1], newWS.Cells[i + 3, 14]].Merge();

                                //newWS.Cells[i + 3, 1].HorizontalAlignment = -4108;//xlCenter
                                //newWS.Cells[i + 3, 1].VerticalAlignment = -4108;//xlCenter

                                newWS.Cells[i + 3, 1].HorizontalAlignment = HorizontalAlignment.Center;
                                newWS.Cells[i + 3, 1].VerticalAlignment = -4108;

                                


                                Color color = Color.FromArgb(205, 205, 205);

                                newWS.Range[newWS.Cells[i + 3, 1], newWS.Cells[i + 3, 1]].Interior.Color = Color.FromArgb(205, 205, 205);

                                newWS.Cells[i + 3, j + 1] = uzkha[1];
                            }
                            else
                            {
                                newWS.Cells[i + 3, j + 1] = uzkha[j];
                            }
                        }

                    }
                    catch { }

                    
                }
                #endregion

                #region empty_merge

                for (int i = 1; i <= uzk.Length; i++)
                {
                    if (newWS.Cells[i + 3, 4].Text.Contains("Дефектов не обнаружено"))
                    {
                        newWS.Cells[i + 3, 4] = "-";

                        newWS.Cells[i + 3, 5] = "Дефектов не обнаружено";

                        for (int c = 6; c <= 11; c++) 
                        {
                            newWS.Cells[i + 3, c] = "-";
                        }
                        
                    }

                    if (newWS.Cells[i + 3, 4].Text.Contains("Результаты толщинометрии приведены в диагностическом формуляре"))
                    {
                        newWS.Cells[i + 3, 4] = "-";

                        newWS.Cells[i + 3, 5] = "Результаты толщинометрии приведены в диагностическом формуляре";

                        for (int c = 6; c <= 11; c++)
                        {
                            newWS.Cells[i + 3, c] = "-";
                        }

                    }

                    if (newWS.Cells[i + 3, 4].Text.Contains("Диагностика не проводилась"))
                    {
                        newWS.Cells[i + 3, 4] = "-";

                        newWS.Cells[i + 3, 5] = "Диагностика не проводилась";

                        for (int c = 6; c <= 11; c++)
                        {
                            newWS.Cells[i + 3, c] = "-";
                        }

                    }
                    if (newWS.Cells[i + 3, 1].Text == "")
                    {
                        newWS.Cells[i + 3, 1] = newWS.Cells[i + 2, 1];
                        newWS.Cells[i + 3, 2] = newWS.Cells[i + 2, 2];
                        newWS.Cells[i + 3, 3] = newWS.Cells[i + 2, 3];
                    }



                }

                #endregion

                #region finish_setting

                newWS.Range["A" + 1, "L" + rows].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                newWS.Range["A" + 1, "L" + rows].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                newWS.Range["O" + 1, "O" + rows].ClearContents();

                string MacroCommand = "'" + mainn + "/patterns/patt2.xlsm" + "'!" + "PrinUZK";
                app.DisplayAlerts = false;
                app.Run(MacroCommand);

                #endregion
            }

            #region TD_fix

            // ВСТАВИТЬ СЮДА АКТИВАЦИЮ ЛИСТА С ОПАСНЫМИ ДЕФЕКТАМИ
            
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets.get_Item("Сводная таблица результатов");

            int _rows = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            Excel.Range rng = sheet.get_Range("G1", Type.Missing);

            rng.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftToRight,
                                    Excel.XlInsertFormatOrigin.xlFormatFromRightOrBelow);

            sheet.Range[sheet.Cells[5, 7], sheet.Cells[6, 7]].Merge();
            sheet.Range[sheet.Cells[4, 6], sheet.Cells[4, 7]].Merge();

            sheet.Cells[5, 7] = "Количество опасных дефектов,"+Environment.NewLine+" требующих ДДК";
            sheet.Cells[5, 7].HorizontalAlignment = -4108;//xlCenter
            sheet.Cells[5, 7].VerticalAlignment = -4108;//xlCenter
            sheet.Cells[5, 7].Orientation = 90;
            sheet.Columns[7].ColumnWidth = 16;

            

            for (int i = 6; i <=_rows; i++) 
            {
                sheet.Cells[i, 7] = "-"; //ТУТ БУДЕТ ЗНАЧЕНИЕ ИЗ ЖУРНАЛА С ОПАСНЫМИ ДЕФЕКТАМИ
            }



            rng = sheet.get_Range("L1", Type.Missing);

            rng.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftToRight,
                                    Excel.XlInsertFormatOrigin.xlFormatFromRightOrBelow);

            sheet.Range[sheet.Cells[5, 12], sheet.Cells[6, 12]].Merge();
            sheet.Range[sheet.Cells[4, 11], sheet.Cells[4, 12]].Merge();

            sheet.Cells[5, 12] = "Количество опасных дефектов," + Environment.NewLine + " требующих ДДК";
            sheet.Cells[5, 12].HorizontalAlignment = -4108;//xlCenter
            sheet.Cells[5, 12].VerticalAlignment = -4108;//xlCenter
            sheet.Cells[5, 12].Orientation = 90;
            sheet.Columns[12].ColumnWidth = 16;

            for (int i = 6; i <= _rows; i++)
            {
                sheet.Cells[i, 12] = "-"; //ТУТ БУДЕТ ЗНАЧЕНИЕ ИЗ ЖУРНАЛА С ОПАСНЫМИ ДЕФЕКТАМИ
            }
            #endregion

            #region create_marshrutes_journal

            #region journal_prepare
            Excel.Worksheet work = (Excel.Worksheet)workbook.Sheets.get_Item("Журнал элементов");
            int __rows = work.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            List<string> marshs = new List<string>();

            for (int i = 1; i <= __rows; i++) 
            {
                try 
                {
                    string s = work.Cells[i, 1].Value;
                    if (s.Contains("Маршрут №"))
                    {
                        int value;
                        int.TryParse(string.Join("", s.Where(c => char.IsDigit(c))), out value);
                        marshs.Add(value.ToString());
                    }
                } 
                catch { }
                //Маршрут № 1.
            }

           
            var newS = (Excel.Worksheet)workbook.Sheets.Add(After: workbook.Sheets.get_Item("Сводная таблица результатов"));
            newS.Name = "Информация об участке ТТ КС";

            #endregion

            #region table_header

            newS.Cells[1, 1] = "ЛПУ МГ";
            newS.Cells[1, 2] = "КС";
            newS.Cells[1, 3] = "КЦ";
            newS.Cells[1, 4] = "Тип ТТ КС";
            newS.Cells[1, 5] = "№ участка";
            newS.Cells[1, 6] = "Способ прокладки";
            newS.Cells[1, 7] = "Объект привязки";
            newS.Cells[1, 8] = "Расстояние от объекта привзяки до "+Environment.NewLine+" начала участка диагностирования, м";
            newS.Cells[1, 9] = "Вид контроля при ТД";
            newS.Cells[1, 10] = "Протяженность участка";
            newS.Cells[1, 11] = "Исполнитель работ при ТД";
            newS.Cells[1, 12] = "Средства проведения контроля";
            newS.Cells[1, 13] = "Дата завершения диагностического"+Environment.NewLine+" обследования";

            #endregion

            #region header_settings

            //for (int i = 1; i <= 4; i++)
            //{
            //    newS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
            //    newS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
            //    newS.Cells[1, i].Orientation = 90;

            //    newS.Range[newS.Cells[1, i], newS.Cells[2, i]].Merge();
            //}

            //newS.Cells[1, 5].HorizontalAlignment = -4108;//xlCenter
            //newS.Cells[1, 5].VerticalAlignment = -4108;//xlCenter

            for (int i = 1; i <= 15; i++)
            {
                newS.Cells[1, i].HorizontalAlignment = -4108;//xlCenter
                newS.Cells[1, i].VerticalAlignment = -4108;//xlCenter
                newS.Cells[1, i].Orientation = 90;

                newS.Range[newS.Cells[1, i], newS.Cells[2, i]].Merge();
            }

            Excel.Range header = newS.Range["A" + 2, "M" + 2];
            header.RowHeight = 25;

            Excel.Range header1 = newS.Range["A" + 1, "M" + 1];
            header1.RowHeight = 170;


            //newS.Cells[2, 5].HorizontalAlignment = -4108;//xlCenter
            //newS.Cells[2, 5].VerticalAlignment = -4108;//xlCenter

            //newS.Cells[2, 6].HorizontalAlignment = -4108;//xlCenter
            //newS.Cells[2, 6].VerticalAlignment = -4108;//xlCenter

            #endregion

            #region table_export

            #region export_prepare
            Excel.Worksheet _work = (Excel.Worksheet)workbook.Sheets.get_Item("Титульный лист");
            int ___rows = work.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            string[] object_c;

            string lpumg = null;
            string ks = null;
            string kc = null;
            string konec_data = null;
            string ttks = null;
            List<string> sred = new List<string>();

            #endregion

            #region find_object-control_name
            for (int i = 1; i < ___rows; i++) 
            {
                
                try
                {
                    string cell = _work.Cells[i, 1].Value;
                    if (cell.Contains("Наименование обьекта контроля"))
                    {
                        cell = _work.Cells[i, 2].Value;

                        object_c = cell.Split(' ');

                        if (object_c.Length > 3)
                        {
                            lpumg = object_c[3];
                            ks = object_c[1]/* + " " + object_c[2]*/;
                            kc = object_c[0];
                        }
                        else
                        {
                            lpumg = object_c[1];
                            kc = object_c[0];
                            ks = "-";
                        }
                    }
                }
                catch { }

            }
            #endregion

            #region find_sredstva_control
            for (int i = 1; i < ___rows; i++) 
            {
                try
                {
                    string cell1 = _work.Cells[i, 1].Value;

                    if (cell1.Contains("Средства проведения диагностики"))
                    {
                        cell1 = _work.Cells[i, 2].Value;
                        while (!cell1.Contains("Ф И О")) 
                        {
                            sred.Add(_work.Cells[i + 1, 2].Value + " " + _work.Cells[i + 1, 3].Value + " " + _work.Cells[i + 1, 4].Value + " " + _work.Cells[i + 1, 5].Value);
                            i++;
                            cell1 = _work.Cells[i, 2].Value;
                        }

                        
                    }
                } 
                catch { }

            }
            #endregion

            #region find_end-date
            string ppath = path_ + @"\1.txt";

            using (File.Create(ppath)) ;

            using (StreamWriter sw = new StreamWriter(ppath))
            {
                for (int i = 4; i <= 12; i++)
                {
                    for (int j = 1; j <= 7; j++)
                    {
                        try
                        {
                            sw.Write(_work.Cells[i, j].Value+ " ");
                        }
                        catch { }
                    }
                    sw.WriteLine();
                }
            }

            string[] h = File.ReadAllLines(ppath);

            #endregion

            #region find_ttks

            for (int i = 1; i < ___rows; i++)
            {
                try
                {
                    string cell2 = _work.Cells[i, 1].Value;

                    if (cell2.Contains("Вид обьекта контроля"))
                    {
                        ttks = _work.Cells[i, 2].Value;
                    }

                }
                catch { }
            }
            #endregion

            #region find_metraj

            string ppath2 = path_ + @"\2.txt";

            using (File.Create(ppath2)) ;

            using (StreamWriter sw = new StreamWriter(ppath2))
            {

                for (int i = 1; i <= _rows; i++)
                {
                    for (int j = 1; j <= 14; j++)
                    {
                        try
                        {
                            sw.Write(sheet.Cells[i, j].Value + ";"); //sheet
                        }
                        catch { }
                    }
                    sw.WriteLine();
                }
            }

            #endregion

            string[] metraj = File.ReadAllLines(ppath2);
            List<string> li = new List<string>();

            bool longer = false;
            for (int k = 1; k < 8; k++)
            {
                for (int kk = 1; kk < 13; kk++)
                {
                    try
                    {
                        string kkk = sheet.Cells[k, kk].Value;

                        if (kkk == "Маршрут перемещения")
                        {
                            longer = true;
                        }
                    }
                    catch { }
                   
                }
            }

            if (!longer)
            {
                for (int m = 0; m < metraj.Length; m++)
                {
                    if (m != 0) 
                    {
                        if (metraj[m].Split(';')[0].Contains("Рез №") || metraj[m].Split(';')[0].Contains("Обратный клапан") || metraj[m].Split(';')[0].Contains("Люк-лаз") ||
                        metraj[m].Split(';')[0].Contains("Рез № ") || metraj[m].Split(';')[0].Contains("ОК №"))
                        {
                            string[] st = metraj[m].Split(';');
                            string rez_number = st[1]/*.Split('№')[1]*/;
                            li.Add(rez_number + ";" + st[2]);
                        }
                        else 
                        {
                            try
                            {
                                if (m != metraj.Length) 
                                {
                                    double num;
                                    if (Double.TryParse(metraj[m].Split(';')[1], out num))
                                    {
                                        string[] st = metraj[m].Split(';');
                                        li.Add(st[1] + ";" + st[2]);
                                    }
                                }
                            }
                            catch 
                            {
                            
                            }    
                        }
                    }
                    
                }
            }
            else 
            {
                for (int m = 0; m < metraj.Length; m++)
                {
                    if (metraj[m].Split(';')[0].Contains("Рез №") || metraj[m].Split(';')[0].Contains("Обратный клапан") || metraj[m].Split(';')[0].Contains("Люк-лаз") ||
                        metraj[m].Split(';')[0].Contains("Рез № ") || metraj[m].Split(';')[0].Contains("ОК №"))
                    {
                        string[] st = metraj[m].Split(';');
                        string rez_number = st[1]/*.Split('№')[1]*/;
                        li.Add(rez_number + ";" + st[3]);

                    }
                    else
                    {
                        try
                        {
                            if (m != metraj.Length) 
                            {
                                double num;
                                if (Double.TryParse(metraj[m].Split(';')[1], out num))
                                {
                                    string[] st = metraj[m].Split(';');
                                    li.Add(st[1] + ";" + st[3]);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            

            for (int i = 0; i < li.Count; i++) 
            {
                newS.Cells[i+3, 1] = lpumg;
                newS.Cells[i+3, 2] = ks;
                newS.Cells[i+3, 3] = kc;
                newS.Cells[i + 3, 4] = ttks;

                

                newS.Cells[i + 3, 6] = "Подземный";
                newS.Cells[i + 3, 7] = "-";
                newS.Cells[i + 3, 8] = "-";
                newS.Cells[i + 3, 9] = "ВТО, ВИК, УЗК, УЗТ";
                

                newS.Cells[i + 3, 11] = "ООО Газпроект-ДКР";

                string sre = "";
                for (int j = 0; j < sred.Count-1; j++) 
                {
                    sre += sred[j] + Environment.NewLine;
                }
                newS.Cells[i + 3, 12] = sre;

                for (int hh = 0; hh < h.Length; hh++)
                {
                    if (h[hh].Contains("Дата окончания"))
                    {
                        konec_data = h[hh].Split(' ')[2];
                    }
                }
                newS.Cells[i + 3, 13] = konec_data ;
            }

            for (int j = 0; j < li.Count; j++) 
            {
                try
                {
                    //MessageBox.Show(li[j].Split(';')[0]);
                    newS.Cells[j + 3, 5] = li[j].Split(';')[0]/*marshs[i]*/;
                }
                catch { }

                try
                {
                    //MessageBox.Show(li[j].Split(';')[1]);
                    newS.Cells[j + 3, 10] = li[j].Split(';')[1];
                }
                catch { }
            }

            #region table_settings
            int n_rows = newS.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            for (int i = 1; i <= n_rows; i++) 
            {
                for (int j = 1; j <= 13; j++) 
                {
                    newS.Cells[i, j].HorizontalAlignment = -4108;//xlCenter
                    newS.Cells[i, j].VerticalAlignment = -4108;//xlCenter
                }
            }
            
            newS.Columns[1].ColumnWidth = 26;
            newS.Columns[4].ColumnWidth = 50;
            newS.Columns[6].ColumnWidth = 17;
            newS.Columns[9].ColumnWidth = 23;
            newS.Columns[11].ColumnWidth = 23;
            newS.Columns[12].ColumnWidth = 36;
            newS.Columns[13].ColumnWidth = 18;

            string Macro = "'" + mainn + "/patterns/patt2.xlsm" + "'!" + "PrinTTKS";
            app.DisplayAlerts = false;
            app.Run(Macro);
            #endregion

            #endregion

            #endregion

            #endregion

            #region details_list_generation
            string[] colors_vto = File.ReadAllLines(mainn + "/src/Цвета ВТО.txt");
            string[] colors = File.ReadAllLines(mainn + "/src/Цвета МА.txt");
            Excel.Worksheet wo = (Excel.Worksheet)workbook.Sheets.get_Item("Журнал элементов");
            int rrr = wo.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            List<string> AllEls = new List<string>();
            List<string> allVTOS = new List<string>();
            List<string> allMA = new List<string>();

            for (int i = 3; i <= rrr; i++)
            {
                string ele = "";
                for (int j = 1; j <= 16; j++)
                {
                    string v = Convert.ToString(wo.Cells[i, j].Value);
                    string v3 = Convert.ToString(wo.Cells[i, 3].Value);
                    try
                    {
                        if (v3.Contains("Труба"))
                        {
                            ele += v + ";";
                        }
                        else goto next;
                    }
                    catch
                    {
                        goto next;
                    }
                }
                AllEls.Add(ele);

            next:;
            }



            wo = (Excel.Worksheet)workbook.Sheets.get_Item("ВТО");
            rrr = wo.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            for (int i = 3; i <= rrr; i++)
            {
                string ele = "";
                for (int j = 1; j <= 16; j++)
                {
                    string v = Convert.ToString(wo.Cells[i, j].Value);
                    string v3 = Convert.ToString(wo.Cells[i, 1].Value);
                    try
                    {
                        if (!v3.Contains("Маршрут"))
                        {
                            ele += v + ";";
                        }
                        else goto next;
                    }
                    catch
                    {
                        goto next;
                    }
                }
                allVTOS.Add(ele);


            next:;
            }
            Directory.CreateDirectory(path_+"/схемы");


            for (int i = 0; i < AllEls.Count; i++) 
            {
                string[] el = AllEls[i].Split(';');

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

                double height = 0;
                double weight = 0;

                try 
                {
                    height = Convert.ToDouble(el[3]);
                    weight = Convert.ToDouble(el[4])*100;
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

                //MessageBox.Show(img.Width.ToString() + " " + img.Height.ToString());

                using (Graphics gr = Graphics.FromImage(img)) 
                {
                    gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height);

                    gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bit_weight, bit_height - 50);

                    int horizont_count = 0;
                    for (int x = pad_x; x < bit_weight; x += 100)
                    {
                        if (horizont_count == 0)
                        {
                            gr.DrawLine(new Pen(Color.Black), x, 5, x, Convert.ToInt32(height + 25));
                            gr.DrawLine(new Pen(Color.Black), x+1, 5, x+1, Convert.ToInt32(height + 25));
                            gr.DrawString(horizont_count.ToString() + " м", label5.Font, new SolidBrush(Color.Black), x - 9, Convert.ToInt32(height + 25));
                        }
                        else 
                        {
                            gr.DrawLine(new Pen(Color.Black), x, 5, x, Convert.ToInt32(height + 25));
                            gr.DrawString(horizont_count.ToString() + " м", label5.Font, new SolidBrush(Color.Black), x - 9, Convert.ToInt32(height + 25));
                        }
                        horizont_count++;
                    }

                    double vert = height / 12;

                    int vert_count = 0;
                    int grad = 0;

                    gr.DrawString("  гр.", label5.Font, new SolidBrush(Color.Black), 0, 0);
                    gr.DrawString(" ч.", label5.Font, new SolidBrush(Color.Black), 35, 0);


                    for (int y = pad_y - 20; y < bit_height; y += Convert.ToInt32(vert))
                    {
                        if (vert_count <= 12)
                        {
                            if (vert_count == 0) 
                            {
                                gr.DrawLine(new Pen(Color.Black), pad_x - 10+1, y, bit_weight - 15+1, y);
                            }
                            gr.DrawLine(new Pen(Color.Black), pad_x - 10, y, bit_weight - 15, y);

                            string n = "";
                            if (vert_count < 10)
                            {
                                n = " " + vert_count;
                            }
                            else n = vert_count.ToString();

                            gr.DrawString(n, label5.Font, new SolidBrush(Color.Black), pad_x - 26, y - 5);
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

                            gr.DrawString(nn, label5.Font, new SolidBrush(Color.Black), 0, y - 5);
                            grad += 30;
                        }
                    }

                    gr.DrawLine(new Pen(Color.Black), 27, 5, 27, Convert.ToInt32(height + 25));

                    #endregion
                    //try 
                    {
                        for (int k = 0; k < allVTOS.Count; k++)
                        {
                            string[] vto = allVTOS[k].Split(';');

                            if (vto[0] == el[0] && vto[1] == el[1] && !vto[2].ToString().Contains("-"))
                            {

                                double vto_x1 = 0;
                                try
                                {
                                    vto_x1 = Convert.ToDouble(vto[4]) * 100;
                                }
                                catch 
                                {
                                    vto_x1 = 1;
                                }
                                double vto_x2 = 0;
                                try 
                                {
                                    //
                                    vto_x2 = Convert.ToDouble(vto[5]);
                                }
                                catch 
                                {
                                 
                                    vto_x2 = 5;
                                }

                                double vto_y1 = 0;
                                try
                                {
                                    
                                    vto_y1 = Convert.ToDouble(vto[6])/10;
                                }
                                catch 
                                {
                                   
                                    vto_y1 = 1;
                                }
                                double vto_y2 = 0;
                                try
                                {
                                    
                                    vto_y2 = Math.Round(Convert.ToDouble(vto[9])/10, 0);
                                }
                                catch 
                                {
                                   
                                    vto_y2 = 180;
                                }

                                Color coco = Color.FromArgb(300 / 100 * 30, 0, 0, 0);
                                SolidBrush br = new SolidBrush(coco); ;
                                Color fontCol = Color.Black;
                                SolidBrush fontBr = new SolidBrush(fontCol);

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

                                double c_of_30 = height / 360;
                                Math.Round(c_of_30, 0);

                                gr.FillRectangle(br,
                                                                            Convert.ToInt32(vto_x1) + pad_x,                        //x1

                                                                             Convert.ToInt32(vto_y1 * c_of_30) + pad_y / 2,         //y1

                                                                             Convert.ToInt32(vto_x2)*10,                               //x2

                                                                            Convert.ToInt32(vto_y2));                               //y2

                                gr.DrawString(vto[0] + "." + vto[2]+"  ", label26.Font, new SolidBrush(Color.Black),
                                              Convert.ToInt32(vto_x1) + pad_x + 1,
                                              Convert.ToInt32(vto_y1) + pad_y / 2 - label26.Font.Size * 4);

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
                            gr.DrawString("   - " + osob[0].Split(';')[0], label5.Font, fontBr, 15, Convert.ToInt32(height + 2) + pad_y);

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
                            gr.DrawString("   - " + osob[1].Split(';')[0], label5.Font, fontBr, 15, Convert.ToInt32(height + 17) + pad_y);

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
                            gr.DrawString("   - " + osob[2].Split(';')[0], label5.Font, fontBr, 15, Convert.ToInt32(height + 32) + pad_y);

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
                            gr.DrawString("   - " + osob[3].Split(';')[0], label5.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 2) + pad_y);
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
                            gr.DrawString("   - " + osob[4].Split(';')[0], label5.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 17) + pad_y);
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
                            gr.DrawString("   - " + osob[5].Split(';')[0], label5.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 32) + pad_y);
                        }
                        catch { }



                        img.Save(path_ + @"/схемы/элемент_" + el[0] + "_" + el[1] + ".png", ImageFormat.Png);
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
                    gr.DrawString(AllEls[0].Split(';')[4], label5.Font, new SolidBrush(Color.Black), xleft, yright);
                    gr.DrawString(AllEls[0].Split(';')[1], label5.Font, new SolidBrush(Color.Black), xleft, yright - 23);



                    int last_element = 0;
                    int weight_element = 0;
                    int left_part_weight = 0;
                    for (int a = 0; a < AllEls.Count; a++)
                    {
                        if (el[0] == AllEls[a].Split(';')[0])
                        {
                            if (last_element < Convert.ToInt32(AllEls[a].Split(';')[1]))
                            {
                                last_element = Convert.ToInt32(AllEls[a].Split(';')[1]);
                            }
                            try
                            {
                                weight_element += Convert.ToInt32(AllEls[a].Split(';')[5]);
                            }
                            catch { }

                        }

                        if (el[0] == AllEls[a].Split(';')[0] && Convert.ToInt32(AllEls[a].Split(';')[1]) < Convert.ToInt32(el[1]))
                        {
                            try
                            {
                                left_part_weight += Convert.ToInt32(AllEls[a].Split(';')[5]);
                            }
                            catch { }

                        }



                    }

                    //right zone
                    gr.DrawString(last_element.ToString(), label5.Font, new SolidBrush(Color.Black), xright, yright - 23);
                    gr.DrawString(weight_element.ToString(), label5.Font, new SolidBrush(Color.Black), xright, yright);
                    gr.DrawString(left_part_weight.ToString(), label5.Font, new SolidBrush(Color.Black), 20, 20);

                    //center zone
                    gr.DrawString(el[1], label5.Font, new SolidBrush(Color.Black), x2, y2);
                    gr.DrawString(el[6], label5.Font, new SolidBrush(Color.Black), x3, y3);
                    gr.DrawString(left_part_weight.ToString(), label5.Font, new SolidBrush(Color.Black), x3, y3 - 25);

                    for (int g = 0; g < AllEls.Count; g++)
                    {
                        string[] eel = AllEls[g].Split(';');
                        if (count == 11)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label5.Font, new SolidBrush(Color.Black), x1, 219);

                                gr.DrawString(eel[5], label5.Font, new SolidBrush(Color.Black), x1, y1);


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

                        if (g == AllEls.Count - 1)
                        {
                            gr.FillRectangle(new SolidBrush(Color.White), x1 - 6, y1 - 20, 999, 999);
                        }



                    }


                }
                image.Save(path_ + @"/схемы/элемент_" + el[0] + "_" + el[1] + "_схема_2.png", ImageFormat.Png);
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
                    gr.DrawString(AllEls[0].Split(';')[4], label5.Font, new SolidBrush(Color.Black), xleft, yright);
                    gr.DrawString(AllEls[0].Split(';')[1], label5.Font, new SolidBrush(Color.Black), xleft, yright - 23);






                    int last_element = 0;
                    int weight_element = 0;
                    int left_part_weight = 0;
                    for (int a = 0; a < AllEls.Count; a++)
                    {
                        if (el[0] == AllEls[a].Split(';')[0])
                        {
                            if (last_element < Convert.ToInt32(AllEls[a].Split(';')[1]))
                            {
                                last_element = Convert.ToInt32(AllEls[a].Split(';')[1]);
                            }

                            try
                            {
                                weight_element += Convert.ToInt32(AllEls[a].Split(';')[5]);
                            }
                            catch { }
                        }
                        if (el[0] == AllEls[a].Split(';')[0] && Convert.ToInt32(AllEls[a].Split(';')[1]) < Convert.ToInt32(el[1]))
                        {
                            try
                            {
                                left_part_weight += Convert.ToInt32(AllEls[a].Split(';')[5]);
                            }
                            catch { }

                        }


                    }

                    //center zone
                    gr.DrawString(el[1], label5.Font, new SolidBrush(Color.Black), x2, y2);
                    gr.DrawString(el[6], label5.Font, new SolidBrush(Color.Black), x3, y3);

                    //right zone
                    gr.DrawString(el[1], label5.Font, new SolidBrush(Color.Black), x2, y2);
                    gr.DrawString(el[6], label5.Font, new SolidBrush(Color.Black), x3, y3);
                    gr.DrawString(left_part_weight.ToString(), label5.Font, new SolidBrush(Color.Black), x3, y3 - 25);

                    for (int g = Convert.ToInt32(el[1]) - 1; g > 0; g--)
                    {
                        string[] eel = AllEls[g].Split(';');
                        if (revers_count == 0)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label5.Font, new SolidBrush(Color.Black), x1, 219);

                                gr.DrawString(eel[5], label5.Font, new SolidBrush(Color.Black), x1, y1);


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

                    for (int g = Convert.ToInt32(el[1]); g < AllEls.Count; g++)
                    {
                        string[] eel = AllEls[g].Split(';');
                        if (count == 9)
                        {
                            break;
                        }
                        else
                        {
                            string nu = eel[0] + "." + eel[1];
                            if (eel[0] == el[0])
                            {
                                gr.DrawString(nu, label5.Font, new SolidBrush(Color.Black), x, 219);

                                gr.DrawString(eel[5], label5.Font, new SolidBrush(Color.Black), x, y1);

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
                        if (g == AllEls.Count - 1)
                        {

                        }

                        count++;
                    }
                    gr.FillRectangle(new SolidBrush(Color.White), x - 6, y1 - 20, 999, 999);
                    gr.FillRectangle(new SolidBrush(Color.White), 926, 216, 999, 999);

                }
                image.Save(path_ + @"/схемы/элемент_" + el[0] + "_" + el[1] + "_схема_2.png", ImageFormat.Png);
            }

            #region lists_to_excel

            var lis = (Excel.Worksheet)workbook.Sheets.Add(After: workbook.ActiveSheet);
            lis.Name = "Листы детализации";
            lis.Select();
            int si = 1;

            for (int p = 0; p < 999; p++)
            {
                for (int pp = 0; pp < 999; pp++)
                {
                    //File.Exists(path_ + @"/схемы/элемент_" + p + "_" + pp + "_схема_2.png"
                    if (File.Exists(path_ + @"/схемы/элемент_" + p + "_" + pp + ".png"))
                    {
                        if (File.Exists(path_ + @"/схемы/элемент_" + p + "_" + pp + "_схема_2.png"))
                        {
                            string details_one = path_ + @"/схемы/элемент_" + p + "_" + pp + ".png";
                            string details_two = path_ + @"/схемы/элемент_" + p + "_" + pp + "_схема_2.png";

                            //if (details_two[i].Contains(details_one[k]))
                            {
                                Excel.Range pictureTargetRange = lis.Range["A" + si, "P" + si];
                                pictureTargetRange.Select();

                                Excel.Pictures pictures = (Excel.Pictures)lis.Pictures(Type.Missing);

                                Image img1 = Image.FromFile(details_one);
                                Image img2 = Image.FromFile(details_two);

                                pictureTargetRange.RowHeight = 350;

                                Excel.Picture picture = pictures.Insert(details_one, Type.Missing);

                                picture.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;

                                //picture.Width = pictureTargetRange.Width - 2;
                                picture.Height = pictureTargetRange.RowHeight - 2;
                                picture.Placement = Excel.XlPlacement.xlMoveAndSize;

                                lis.Range[lis.Cells[si, 1], lis.Cells[si, 16]].Merge();

                                si++;

                                Excel.Range pictureTargetRange1 = lis.Range["A" + si, "P" + si];
                                pictureTargetRange1.Select();

                                Excel.Pictures pictures1 = (Excel.Pictures)lis.Pictures(Type.Missing);

                                pictureTargetRange1.RowHeight = 300;

                                Excel.Picture picture1 = pictures.Insert(details_two, Type.Missing);

                                picture.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
                                picture1.Width = pictureTargetRange1.Width - 2;
                                picture1.Height = pictureTargetRange1.RowHeight - 2;
                                picture1.Placement = Excel.XlPlacement.xlMoveAndSize;


                                si++;

                                lis.Cells[si, 1] = "№ участка";
                                lis.Cells[si, 2] = "№ эл-та п/п";
                                lis.Cells[si, 3] = "Тип элемента";
                                lis.Cells[si, 4] = "Наружный диаметр"+Environment.NewLine+"элемента, м";
                               
                                lis.Cells[si, 5] = "Длина, м";
                                lis.Cells[si, 6] = "Толщина стенки, мм";
                                lis.Cells[si, 7] = "Конструкция элемента";
                                lis.Cells[si, 8] = "Угловая ориентация" + Environment.NewLine + " продольных швов №1, град";
                                lis.Cells[si, 9] = "Угловая ориентация" + Environment.NewLine + " продольных швов №2, град";

                                lis.Cells[si, 10] = "Расстояние от начала" + Environment.NewLine + " маршрута до начала " + Environment.NewLine + "элемента";

                                lis.Cells[si, 11] = "Плоскость " + Environment.NewLine + "расположения";
                                lis.Cells[si, 12] = "Угол изгиба " + Environment.NewLine + "отвода, град";
                                lis.Cells[si, 13] = "Угол наклона плоскости" + Environment.NewLine + " расположения, град";
                                lis.Cells[si, 14] = "Наружный диаметр" + Environment.NewLine + " ответвления переходного " + Environment.NewLine + "тройника";
                                lis.Cells[si, 15] = "Высота" + Environment.NewLine + " тройника, мм";
                                lis.Cells[si, 16] = "Наружный диаметр" + Environment.NewLine + " перехода (второй), м";

                                for (int i = 1; i <= 16; i++)
                                {
                                    newS.Cells[si, i].HorizontalAlignment = -4108;//xlCenter
                                    newS.Cells[si, i].VerticalAlignment = -4108;//xlCenter
                                    lis.Columns[i].ColumnWidth = 21;
                                }


                                lis.Range[lis.Cells[si, 1], lis.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                si++;

                                for (int s = 0; s < AllEls.Count; s++)
                                {
                                    string[] elem = AllEls[s].Split(';');

                                    if (Convert.ToInt32(elem[0]) == p && Convert.ToInt32(elem[1]) == pp)
                                    {
                                        lis.Range[lis.Cells[si, 1], lis.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                        for (int el = 0; el < elem.Length; el++)
                                        {
                                            lis.Cells[si, el + 1] = elem[el];
                                        }
                                    }
                                }

                                si++;

                                //li.Range[li.Cells[si, 13], li.Cells[si, 16]].Merge();
                                lis.Cells[si, 1] = "Номер диагностируемого" + Environment.NewLine + " участка";
                                lis.Cells[si, 2] = "№ элемента п/п";
                                lis.Cells[si, 3] = "№ особенности п/п";
                                lis.Cells[si, 4] = "Тип особенности";
                                lis.Cells[si, 5] = "Расстояние от начала" + Environment.NewLine + " элемента до особенности, м";
                                lis.Cells[si, 6] = "Расстояние от начала" + Environment.NewLine + " элемента до конца особенности, м";
                                lis.Cells[si, 7] = "Угловая ориентация" + Environment.NewLine + " особенности, час (начало)";
                                lis.Cells[si, 8] = "Угловая ориентация" + Environment.NewLine + " особенности, час (конец)";
                                lis.Cells[si, 9] = "Измеренная длина" + Environment.NewLine + "особенности, мм";
                                lis.Cells[si, 10] = "Измеренная ширина " + Environment.NewLine + "особенности , мм";
                                lis.Cells[si, 11] = "№ фото выявленных" + Environment.NewLine + " особенностей";
                                lis.Cells[si, 12] = "Рекомендации";
                                lis.Cells[si, 13] = "Примечание";

                                for (int i = 1; i <= 13; i++)
                                {
                                    newS.Cells[si, i].HorizontalAlignment = -4108;//xlCenter
                                    newS.Cells[si, i].VerticalAlignment = -4108;//xlCenter
                                }

                                si++;
                                int vto_co = 0;

                                for (int s = 0; s < allVTOS.Count; s++)
                                {
                                    string[] vtoha = allVTOS[s].Split(';');

                                    try 
                                    {
                                        if (Convert.ToInt32(vtoha[0]) == p && Convert.ToInt32(vtoha[1]) == pp && !vtoha[2].Contains("-"))
                                        {
                                            lis.Range[lis.Cells[si, 1], lis.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                            if (vto_co == 0)
                                            {
                                                lis.Range[lis.Cells[si - 1, 13], lis.Cells[si - 1, 16]].Merge();
                                                lis.Range[lis.Cells[si - 1, 1], lis.Cells[si - 1, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                            }
                                            lis.Range[lis.Cells[si, 13], lis.Cells[si, 16]].Merge();

                                            for (int v = 0; v < vtoha.Length; v++)
                                            {
                                                lis.Cells[si, v + 1] = vtoha[v];
                                            }
                                            si++;
                                            vto_co++;
                                        }
                                    } 
                                    catch 
                                    {
                                    
                                    }
                                    

                                }

                                if (vto_co == 0)
                                {
                                    si--;
                                }

                                int ma_co = 0;


                                //li.Range[li.Cells[si, 15], li.Cells[si, 16]].Merge();
                                lis.Cells[si, 1] = "Номер диагностируемого" + Environment.NewLine + " участка";
                                lis.Cells[si, 2] = "№ элемента п/п";
                                lis.Cells[si, 3] = "Измеренная толщина" + Environment.NewLine + " стенки элемента, мм";
                                lis.Cells[si, 4] = "№ дефекта п/п";
                                lis.Cells[si, 5] = "Тип дефекта";
                                lis.Cells[si, 6] = "Расположение дефекта" + Environment.NewLine + " от кольцевого шва, мм";
                                lis.Cells[si, 7] = "Угловая ориентация " + Environment.NewLine + "дефекта начало, час";
                                lis.Cells[si, 8] = "Угловая ориентация" + Environment.NewLine + " дефекта конец, час";
                                lis.Cells[si, 9] = "Длина дефекта, мм";
                                lis.Cells[si, 10] = "Ширина дефекта, мм";
                                lis.Cells[si, 11] = "Глубина дефекта,мм";
                                lis.Cells[si, 12] = "Остаточная толщина" + Environment.NewLine + " дефекта";
                                lis.Cells[si, 13] = "Относительная глубина" + Environment.NewLine + " дефекта,мм";
                                lis.Cells[si, 14] = "Примечание";
                                lis.Cells[si, 15] = "Рекомендации к проведению ДДК" + Environment.NewLine + " в шурфах методами НК";

                                for (int i = 1; i <= 15; i++) 
                                {
                                    newS.Cells[si, i].HorizontalAlignment = -4108;//xlCenter
                                    newS.Cells[si, i].VerticalAlignment = -4108;//xlCenter
                                }

                                si++;
                                for (int m = 0; m < allMA.Count; m++)
                                {
                                    string[] ma = allMA[m].Split(';');

                                    try
                                    {
                                        if (Convert.ToInt32(ma[0]) == p && Convert.ToInt32(ma[1]) == pp && !ma[3].Contains("-"))
                                        {
                                            lis.Range[lis.Cells[si, 1], lis.Cells[si, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                            if (ma_co == 0)
                                            {
                                                lis.Range[lis.Cells[si - 1, 15], lis.Cells[si - 1, 16]].Merge();
                                                lis.Range[lis.Cells[si - 1, 1], lis.Cells[si - 1, 16]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                            }
                                            lis.Range[lis.Cells[si, 15], lis.Cells[si, 16]].Merge();

                                            for (int mm = 0; mm < ma.Length; mm++)
                                            {
                                                lis.Cells[si, mm + 1] = ma[mm];
                                            }
                                            si++;
                                            ma_co++;
                                        }
                                    }
                                    catch 
                                    {
                                    
                                    }
                                    
                                }

                                if (ma_co == 0)
                                {
                                    si--;

                                    for (int m = 1; m <= 16; m++)
                                    {
                                        lis.Cells[si, m] = "";
                                    }
                                }



                            }
                        }
                    }
                }
            }

            string ttkss = "'" + mainn + "/patterns/patt2.xlsm" + "'!" + "PrinTTKS";
            app.Run(ttkss);
            #endregion

            #region evalution_del
            try
            {
                Excel.Worksheet worksheet1 = (Excel.Worksheet)workbook.Sheets.get_Item("Evaluation Warning");
                worksheet1.Delete();
            }
            catch
            { }
            #endregion

            #region create_oglavlenie
            var oglav = (Excel.Worksheet)workbook.Sheets.Add(After: workbook.Sheets.get_Item("Титульный лист"));
            
            oglav.Name = "Оглавление";
            oglav.Select();

            string Mac = "'" + mainn + "/patterns/patt2.xlsm" + "'!" + "Oglav";
            app.Run(Mac);

            int o = oglav.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            for (int i = 1; i <= o; i++) 
            {
                string name = Convert.ToString(oglav.Cells[i, 1].Value);
                if (name.Contains("Титульный лист"))
                {
                    oglav.Cells[i, 1] = "";
                }

                if (name.Contains("Оглавление"))
                {
                    oglav.Cells[i, 1] = "";
                }

                if (name.Contains("Сводная таблица результатов"))
                {
                    oglav.Cells[i, 1] = "Результаты диагностики";
                }

                if (name.Contains("Информация об участке ТТ КС"))
                {
                    oglav.Cells[i, 1] = "Общая информация о диагностируемом участке ТТ КС";
                }

                if (name.Contains("Статистика"))
                {
                    oglav.Cells[i, 1] = "Перечень дефектов обнаруженных при проведении ВТО, ВИК, УЗК";
                }

                if (name.Contains("ВТО"))
                {

                    oglav.Cells[i, 1] = "Результаты внутритрубного обследования";
                }

                if (name.Contains("Снимки ВТО"))
                {
                    oglav.Cells[i, 1] = "Снимки внутритрубного обследования";
                }

                if (name.Contains("ВИК"))
                {
                    oglav.Cells[i, 1] = "Визуальный и измерительный контроль кольцевых сварных швов";
                }

                if (name.Contains("УЗК"))
                {
                    oglav.Cells[i, 1] = "Ультразвуковой контроль основного металла труб";
                }

                if (name.Contains("УЗТ"))
                {
                    oglav.Cells[i, 1] = "УЗ толщинометрия соединительных деталей трубопроводов";
                }

                if (name.Contains("Журнал элементов"))
                {
                    oglav.Cells[i, 1] = "Журнал элементов диагностируемого участка трубопровода";
                }
            }

            oglav.Columns[1].ColumnWidth = 62;

            string Mac1 = "'" + mainn + "/patterns/patt2.xlsm" + "'!" + "PrinOglav";
            app.DisplayAlerts = false;
            app.Run(Mac1);


            Excel.Range rg = (Excel.Range)oglav.Rows[1, Type.Missing];
            rg.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);

            Excel.Range rg1 = (Excel.Range)oglav.Rows[1, Type.Missing];
            rg1.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);

            #endregion

            #region excel_end



            workbook.Save();
            workbook.Close();
            app.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            #endregion
            //image.Save(path_ + @"/схемы/элемент_" + el[0] + "_" + el[1] + "_" + el[2] + ".png", ImageFormat.Png);



            try 
            {

                string[] del_files = Directory.GetFiles(path_ + "/Экспорт");
                for (int i = 0; i < del_files.Length; i++)
                {
                    File.Delete(del_files[i]);
                }

                Directory.Delete(path_ + "/Экспорт");
               

            } 
            catch { }

            try
            {
                File.Delete(ppath);
                File.Delete(ppath2);
            }
            catch { }
            

            timer1.Stop();
            label1.Visible = false;
            label2.Visible = false;
        }

       

        private void Конвертер_журналов_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("excel"); // Получим все процессы Google Chrome

            foreach (Process process in processes) // В цикле их переберём
            {
                process.Kill(); // завершим процесс
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();

            Excel.Workbook workbook = app.Workbooks.Open(@"C:\Users\Рабочий дух\Desktop\ТЕСТИРОВАНИЕ\ЭО\Экспресс-отчет внутрицеховка КЦ-1 Писаревского ЛПУМГ.xlsx", Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value);

            Excel.Worksheet _work = (Excel.Worksheet)workbook.Sheets.get_Item("Сводная таблица результатов");
            int ___rows = _work.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            using (File.Create(@"C:\Users\Рабочий дух\Desktop\ТЕСТИРОВАНИЕ\ЭО\2.txt"));

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Рабочий дух\Desktop\ТЕСТИРОВАНИЕ\ЭО\2.txt")) 
            {
                for (int i = 1; i <= ___rows; i++)
                {
                    for (int j = 1; j <= 14; j++)
                    {
                        try
                        {
                            sw.Write(_work.Cells[i, j].Value + ";");
                        } catch { } 
                    }
                    sw.WriteLine();
                }
            }
                

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void file_path_MouseClick(object sender, MouseEventArgs e)
        {
            string file = file_path.Text;

            string[] peaces = file.Split('\\');
            string path = "";
            for (int i = 0; i < peaces.Length - 1; i++)
            {
                path += peaces[i] + "\\";
            }

            Process.Start("explorer.exe", path);
        }
    }
}
