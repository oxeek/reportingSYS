
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporting_v1._0.modules
{
    public class DefectsGeneration
    {
        Manager _manager = new Manager();
        string mainn = Environment.CurrentDirectory;
        public Image Generate(Manager manager, Label linersFont,Label defectFont, string Sweight, string Sheight, int elementNum, int marshrutNum) 
        {
            int weight = toInt(stoDob(Sweight) * 10);
            int height = toInt(stoDob(Sheight));
            _manager = manager;
            //создание листов для данных
            #region lists_section

            List<string> allELS = new List<string>(); //_manager.folderName + @"/Журнал контроля"
            List<string> allVTOS = new List<string>(); //_manager.folderName + @"/ВТО/Маршрут - " + i
            List<string> allMA = new List<string>(); //_manager.folderName + @"/Неразрушающий контроль"

            #endregion
            //загрузка данных из трёх журналов
            #region loading_from_journals

            for (int i = 0; i < 999; i++)
            {
                if (Directory.Exists(_manager.folderName + @"/ВТО/Маршрут - " + i))
                {
                    string[] data = File.ReadAllLines(_manager.folderName + @"/ВТО/Маршрут - " + i + "/Выявленные особенности маршрут - " + i + ".txt");
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

            #endregion
            //настройки битмапа тут ->
            #region bitmap_settings

            int bitmap_x = 13000;
            int bitmap_y = 1900; //1370 
            int margin_x = 500;
            int margin_y = 50;
            int fixedMargin = 0; //TODO фикс для труб больше в диаметре чем 1200

            #endregion
            //подготовка шаблона
            #region create_stock_pattern

            Image img = new Bitmap(bitmap_x, bitmap_y);
            using (Graphics gr = Graphics.FromImage(img))
            {
                weight = weight * 100; //Умножали на 1000, но теперь на 100, потому что в вызове доп. умножение на 10
                gr.FillRectangle(new SolidBrush(Color.White), 0, 0, bitmap_x, bitmap_y);//background
                gr.FillRectangle(new SolidBrush(Color.Blue), margin_x, margin_y, weight, height);//труба
                gr.FillRectangle(new SolidBrush(Color.Black), margin_x, margin_y + 1200, 12000, 5);//горизонтальная линейка

                if (height > 1200)
                    fixedMargin = height - 1200;

                //вертикальная линейка большая
                int w = 0;
                for (int i = margin_x; i <= 12000 + margin_x; i += 1000)
                {
                    gr.FillRectangle(new SolidBrush(Color.Black), i, 0, 5, margin_y + 1300);
                    gr.DrawString(w.ToString() + "м", linersFont.Font, new SolidBrush(Color.Black), i - 40, margin_y + 1305);
                    w++;
                }

                //вертикальная линейка маленькая
                for (int i = margin_x; i <= 12000 + margin_x; i += 100)
                    gr.FillRectangle(new SolidBrush(Color.Black), i, margin_y + 1200, 5, 50);

                //горизонтальная линейка
                int h = 0;
                int h_o = 0;
                int subHeight = Convert.ToInt32(height / 12);
                for (int i = 50; i <= height + margin_y; i += subHeight)
                {
                    gr.FillRectangle(new SolidBrush(Color.Black), margin_x - 100, i, 12200, 5);
                    gr.DrawString(h.ToString() + "ч", linersFont.Font, new SolidBrush(Color.Black), margin_x - 280, i - 50);
                    gr.DrawString(h_o.ToString() + "°", linersFont.Font, new SolidBrush(Color.Black), 0, i - 50);
                    h++;
                    h_o += 30;
                }
            }
            #endregion
            //нанесение дефектов на карту
            #region create_defects_map

            using (Graphics gr = Graphics.FromImage(img))
            {
                List<string> allDefectsInMap = new List<string>();

                foreach (string element in allELS) //наносим название элемента и нумерация
                {
                    string[] currentElement = element.Split(';');

                    if (currentElement[0] == marshrutNum.ToString() && currentElement[1] == elementNum.ToString()) 
                    {
                        gr.DrawString("М"+ currentElement[0] + " Э"+ currentElement[1]+" "+ currentElement[2], linersFont.Font, new SolidBrush(Color.Black), 0, 1450);

                        //###### Отметка шва на карте
                        if (currentElement[8] != "-") 
                        {
                            double subHeight = itoDob(height) / itoDob(360);
                            double y = stoDob(currentElement[8])*subHeight;
                            gr.FillRectangle(new SolidBrush(Color.Red),margin_x,toInt(y)+margin_y,weight,10);
                        }


                        if (currentElement[9] != "-") 
                        {
                            double subHeight = itoDob(height) / itoDob(360);
                            double y = stoDob(currentElement[9]) * subHeight;
                            gr.FillRectangle(new SolidBrush(Color.Red), margin_x, toInt(y) + margin_y, weight, 10);
                        }
                    }
                }

                //######### Блок дефектов ВТО
                string[] vtoColors = File.ReadAllLines(mainn + "/src/Цвета ВТО.txt");
                foreach (string vto in allVTOS) //пробегаем по всем ВТО дефектам
                {
                    Color currentColor = Color.Aqua;
                    string[] currentVto = vto.Split(';');

                    if (marshrutNum.ToString() == currentVto[0] && elementNum.ToString() == currentVto[1] && currentVto[2]!="-")
                    {
                        foreach (string col in vtoColors) 
                        {
                            string[] color = col.Split(';');

                            if (currentVto[3] == color[0]) 
                            {
                                int a = Convert.ToInt32(color[1].Split(',')[3]);
                                int r = Convert.ToInt32(color[1].Split(',')[0]);
                                int g = Convert.ToInt32(color[1].Split(',')[1]);
                                int b = Convert.ToInt32(color[1].Split(',')[2]);

                                currentColor = Color.FromArgb(a, r, g, b);
                            }
                        }

                        allDefectsInMap.Add(currentVto[3] + ";" + currentColor.A+"," + currentColor.R + "," + currentColor.G + "," + currentColor.B);

                        double subHeight = itoDob(height) / itoDob(360);

                        double def_x = stoDob(currentVto[4]) * 1000;
                        double def_y = stoDob(currentVto[6]) * subHeight;
                        double def_w = stoDob(currentVto[8]);
                        double def_h = stoDob(currentVto[7]) * subHeight;

                        if (def_h < 2)
                            def_h = 20;

                        if (stoDob(currentVto[6]) < stoDob(currentVto[7])) 
                        {
                            if (def_h > height)
                                def_h = height;
                            gr.FillRectangle(new SolidBrush(currentColor), toInt(def_x) + margin_x, toInt(def_y) + margin_y, toInt(def_w), toInt(def_h - margin_y)); 
                        }  
                        else 
                        {
                            double def_lower_h = height - def_y;
                            double def_upper_h = def_h - def_lower_h-4;
                            gr.FillRectangle(new SolidBrush(Color.FromArgb(80, currentColor)), toInt(def_x) + margin_x, toInt(0) + margin_y, toInt(def_w), toInt(height));//средняя задняя часть (невидимая)
                            gr.FillRectangle(new SolidBrush(currentColor), toInt(def_x) + margin_x, toInt(def_y) + margin_y, toInt(def_w), toInt(def_lower_h));//нижняя первая часть
                            gr.FillRectangle(new SolidBrush(currentColor), toInt(def_x) + margin_x, toInt(0) + margin_y, toInt(def_w), toInt(def_upper_h));//верхняя вторая часть
                        }
                        gr.DrawString(currentVto[1] + "." + currentVto[2], defectFont.Font, new SolidBrush(Color.Black), toInt(def_x + margin_x), toInt(def_y + margin_y));

                    }

                }

                //####### Блок дефектов МА
                string[] maColors = File.ReadAllLines(mainn + "/src/Цвета МА.txt");
                foreach (string ma in allMA) //пробегаем по всем МА дефектам
                {
                    string[] currentMA = ma.Split(';');
                    Color currentColor = Color.Aqua;

                    if (marshrutNum.ToString() == currentMA[0] && elementNum.ToString() == currentMA[1] && currentMA[3]!="-") 
                    {
                        foreach (string col in maColors) 
                        {
                            string[] color = col.Split(';');

                            if (currentMA[4] == color[0])
                            {
                                int a = Convert.ToInt32(color[1].Split(',')[3]);
                                int r = Convert.ToInt32(color[1].Split(',')[0]);
                                int g = Convert.ToInt32(color[1].Split(',')[1]);
                                int b = Convert.ToInt32(color[1].Split(',')[2]);

                                currentColor = Color.FromArgb(a, r, g, b);
                            }
                        }

                        allDefectsInMap.Add(currentMA[4] + ";" + currentColor.A + "," + currentColor.R + "," + currentColor.G + "," + currentColor.B);
                        double subHeight = itoDob(height) / itoDob(12);

                        
                        double def_x = stoDob(currentMA[5])/1000;
                        double def_y = stoDob(currentMA[6]) * subHeight;
                        double def_w = stoDob(currentMA[8]);
                        double def_h = stoDob(currentMA[7]) * subHeight;


                        double normaly_def_h = def_h - def_y;
                        if (normaly_def_h < 2)
                            normaly_def_h = 20;

                        if (normaly_def_h > height)
                            normaly_def_h = height;

                        MessageBox.Show(normaly_def_h.ToString());
                        gr.FillRectangle(new SolidBrush(currentColor), toInt(def_x) + margin_x, toInt(def_y) + margin_y, toInt(def_w), toInt(normaly_def_h));

                        gr.DrawString(currentMA[1] + "." + currentMA[3], defectFont.Font, new SolidBrush(Color.Black), toInt(def_x + margin_x), toInt(def_y + margin_y));
                    }
                }
                
                //###### Блок последефектной информации
                allDefectsInMap = allDefectsInMap.Distinct().ToList();

                int row = 0;
                int x = 0;

                foreach (string defectColor in allDefectsInMap) 
                {
                    string[] defcol = defectColor.Split(';');

                    int r = Convert.ToInt32(defcol[1].Split(',')[1]);
                    int g = Convert.ToInt32(defcol[1].Split(',')[2]);
                    int b = Convert.ToInt32(defcol[1].Split(',')[3]);

                    if (row == 0)
                    {
                        gr.FillRectangle(new SolidBrush(Color.FromArgb(255, r, g, b)), x, 1600, 100, 100);
                        gr.DrawString(defcol[0], defectFont.Font, new SolidBrush(Color.Black), x + 100, 1630);
                        row++;
                    }
                    else
                    {
                        gr.FillRectangle(new SolidBrush(Color.FromArgb(255, r, g, b)), x, 1800, 100, 100);
                        gr.DrawString(defcol[0], defectFont.Font, new SolidBrush(Color.Black), x + 100, 1830);
                        x += 1000;
                        row = 0;
                    }
                }

            }
            
            #endregion

            return img;
        }

        int toInt(double n) 
        {
            return Convert.ToInt32(n);
        }
        double itoDob(int n) 
        {
            return Convert.ToDouble(n);
        }
        double stoDob(string n) 
        {
            return Convert.ToDouble(n);
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
    }
}
