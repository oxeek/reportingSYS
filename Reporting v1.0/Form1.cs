using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporting_v1._0
{
    public partial class Form1 : Form
    {
        Manager _manager = new Manager();
        List<Category> lpumg_list = new List<Category>();
        List<Category> ks_list = new List<Category>();
        List<Category> ttks_list = new List<Category>();
        List<Category> proklad_list = new List<Category>();
        List<Category> control_view_list = new List<Category>();
        List<Category> worker_list = new List<Category>();
        List<Category> sredstv_list = new List<Category>();
        List<Category> doljnost_list = new List<Category>();

        string mainn = Environment.CurrentDirectory;
        public Form1(Manager manager)
        {
            _manager = manager;
            InitializeComponent();
            
            try { FormParser(); }
            catch { MessageBox.Show("Возникла проблема!\nПроведите переустановку ПО!"); }

            if (Convert.ToString(1) == Convert.ToString(10)) 
            {
                MessageBox.Show("!");
            }

        }

        void Filling(List<Category> categories, ComboBox box) 
        {
            foreach (Category cat in categories) 
            {
                box.Items.Add(cat.GetContent());
            }
        }
        void FormParser() 
        {
        
            using (StreamReader sr1 = new StreamReader(mainn+@"/src/ЛПУ МГ.txt"))
            {
                _manager.ReadCategories(sr1);
                lpumg_list = _manager.GetCategories();
                lpumg_box.Items.Clear();
                Filling(lpumg_list, lpumg_box);
            }
            //2
            using (StreamReader sr2 = new StreamReader(mainn + @"/src/КС.txt"))
            {
                _manager.ReadCategories(sr2);
                ks_list = _manager.GetCategories();
                ks_box.Items.Clear();
                Filling(ks_list, ks_box);
            }
            //4
            using (StreamReader sr4 = new StreamReader(mainn + @"/src/Тип ТТКС.txt"))
            {
                _manager.ReadCategories(sr4);
                ttks_list = _manager.GetCategories();
                ttks_box.Items.Clear();
                Filling(ttks_list, ttks_box);
            }
            //6
            using (StreamReader sr6 = new StreamReader(mainn + @"/src/Способ прокладки.txt"))
            {
                _manager.ReadCategories(sr6);
                proklad_list = _manager.GetCategories();
                proklad_box.Items.Clear();
                Filling(proklad_list, proklad_box);
            }
            //9
            using (StreamReader sr9 = new StreamReader(mainn + @"/src/Вид контроля при ТД.txt"))
            {
                _manager.ReadCategories(sr9);
                control_view_list = _manager.GetCategories();
                control_box.Items.Clear();
                Filling(control_view_list, control_box);
            }
            //11
            worker_box.Items.Clear();
            string[] udovs = File.ReadAllLines(mainn + @"/src/Исполнитель.txt");

            for (int i = 0; i < udovs.Length; i++) 
            {
                worker_box.Items.Add(udovs[i].Split(';')[0]);
            }

            //12
            sred_box.Items.Clear();

            string[] sreds = File.ReadAllLines(mainn + @"/src/Средства проведения.txt");

            for (int i = 0; i < sreds.Length; i++) 
            {
                sred_box.Items.Add(sreds[i].Split(';')[0]);
            }

            //13

            using (StreamReader sr13 = new StreamReader(mainn + @"/src/Должности.txt")) 
            {
                _manager.ReadCategories(sr13);
                doljnost_list = _manager.GetCategories();
                doljnost_box.Items.Clear();
                Filling(doljnost_list, doljnost_box);
            }


        }

        string GettingPreset() 
        {
            string preset = lpumg_box.Text + "\n" +
                            ks_box.Text + "\n" +
                            kc_text.Text + "\n" +
                            ttks_box.Text + "\n" +
                            nuber_text.Text + "\n" +
                            proklad_box.Text + "\n" +
                            obj_text.Text + "\n" +
                            distance_text.Text + "\n" +
                            control_box.Text + "\n" +
                            lenght_text.Text + "\n" +
                            worker_box.Text + "\n" +
                            doljnost_box.Text + "\n" + // NEW
                            sred_box.Text + "\n" +
                            start_date.Value.Date + "\n" + // NEW 
                            end_date.Value.Date + "\n" +
                            _manager.folderName + "\n" + 
                            0 + "\n" + 
                            zagrpc.Text;
                            

                            
            return preset;
        }
        
        private void сохранитьПрисетToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void загрузитьПрисетToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void выгрузитьтестToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        void NuberCloser() 
        {
            if (nuber_text.Text != "") 
            {
                nuber_text.ReadOnly = true;
                nuber_text.BackColor = Color.LightSeaGreen;
            }
            
        }
        private void журналЭлементовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            _manager.diagnostic_number = nuber_text.Text;
            if (_manager.folderName == null) { MessageBox.Show("Сначала создайте архив!"); }
            else
            {
                
                if (!File.Exists(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt"))
                {
                    MessageBox.Show("Маршрута не существует!");
                }
                else 
                {
                    _manager.JournalOpened = true;
                    NuberCloser();
                    Диагностируемый_участок du = new Диагностируемый_участок(_manager, nuber_text);
                    du.Show();
                }
               
            }
        }
        void CreateFolder(string number, string adder) 
        {
            string directory = _manager.folderName + adder;
            DirectoryInfo folder = new DirectoryInfo(directory);
            folder.CreateSubdirectory("Маршрут - " + number);
        }

        private void журналВыявленныхОсобенностейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _manager.diagnostic_number = nuber_text.Text;
            if (_manager.folderName == null) { MessageBox.Show("Сначала создайте архив!"); }
            else 
            {
                
                if (!File.Exists(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt"))
                {
                    MessageBox.Show("Маршрута не существует!");
                }
                else 
                {
                    string[] data = File.ReadAllLines(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt");
                    if (data.Length > 0)
                    {
                        _manager.JournalOpened = true;
                        NuberCloser();
                        Журнал_выявленных_особенностей oj = new Журнал_выявленных_особенностей(_manager, nuber_text);
                        oj.Show();
                    }
                    else MessageBox.Show("Заполните хотя бы один элемент в Журнале элементов!");
                    
                }
                
            }
               
        }

       

        private void отчетКонтроляКольцевыхСварныхСоединенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.diagnostic_number = nuber_text.Text;
            if (_manager.folderName == null) { MessageBox.Show("Сначала создайте архив!"); }
            else 
            {
                string[] data = File.ReadAllLines(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt");
                if (data.Length > 0)
                {
                    _manager.JournalOpened = true;
                    NuberCloser();
                    Отчет_контроля_кольцевых_сварных_соединений ok = new Отчет_контроля_кольцевых_сварных_соединений(_manager, nuber_text);
                    ok.Show();
                }
                else MessageBox.Show("Заполните хотя бы один элемент в Журнале элементов!");
            }
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _manager.ReadMainPath();

            try 
            {
                string[] orga = File.ReadAllLines(mainn + "/src/Организация.txt");
                org_name.Text = orga[0];
                sved.Text = orga[1];
                dei_do.Text = orga[2];
            }
            catch { }
            
        }

        private void обновитьПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormParser();
        }

       

        private void создатьАрхивToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ks_box.Text == "")
            {
                _manager.object_of_diagnostic_name = "КЦ-" + kc_text.Text + " " + lpumg_box.Text + " ЛПУМГ";
            }
            else _manager.object_of_diagnostic_name = "КЦ-" + kc_text.Text + " КС " + ks_box.Text + " " + lpumg_box.Text + " ЛПУМГ";

            if (dataGridView1.Rows.Count < 1 || dataGridView2.Rows.Count < 1|| nuber_text.Text.Length<1)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else 
            {
                FolderBrowserDialog archive = new FolderBrowserDialog();
                if (archive.ShowDialog() == DialogResult.OK)
                {
                    _manager.folderName = archive.SelectedPath + "/" + _manager.object_of_diagnostic_name;
                    DirectoryInfo archivePath = new DirectoryInfo(_manager.folderName);

                    if (!archivePath.Exists)
                    {
                        archivePath.Create();
                        archivePath.CreateSubdirectory("ВТО");
                        archivePath.CreateSubdirectory("ВИК");
                        archivePath.CreateSubdirectory("Протоколы");
                        archivePath.CreateSubdirectory("ЭМА-ПВ");
                        archivePath.CreateSubdirectory("ЭМА-СВ");
                        archivePath.CreateSubdirectory("Журнал контроля");
                        archivePath.CreateSubdirectory("Маршруты");
                        archivePath.CreateSubdirectory("Неразрушающий контроль");
                        archivePath.CreateSubdirectory("Толщинометрия");
                        archivePath.CreateSubdirectory("Ведомости журнала элементов");
                        archivePath.CreateSubdirectory("Фото");

                        using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Маршрут - 1.txt"))
                        {
                          
                            {
                                sw.WriteLine(GettingPreset());
                            }
                            
                        }


                        
                        {
                            using (File.Create(_manager.folderName + @"/Маршруты/Состав специалистов.txt")) ;
                            using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Состав специалистов.txt"))
                            {
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                    {
                                        sw.Write(dataGridView1[j, i].Value + ";");
                                    }
                                    sw.WriteLine();
                                }
                            }
                        }

                        {
                            using (File.Create(_manager.folderName + @"/Маршруты/Средства контроля.txt")) ;
                            using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Средства контроля.txt"))
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                                    {
                                        sw.Write(dataGridView2[j, i].Value + ";");
                                    }
                                    sw.WriteLine();
                                }
                            }
                        }

                        if (org_name.Text == "" || sved.Text == "" || dei_do.Text == "")
                        {
                            MessageBox.Show("Не все данные организации, которая проводила контроль, заполнены!");
                        }
                        else
                        {
                            using (File.Create(_manager.folderName + @"/Маршруты/Организация.txt")) ;

                                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Организация.txt")) 
                                {
                                    sw.WriteLine(org_name.Text);
                                    sw.WriteLine(sved.Text);
                                    sw.WriteLine(dei_do.Text);
                                }
                           
                        }

                        if (name_org.Text == "" || dogovor_n.Text == "")
                        {
                            MessageBox.Show("Не все данные заказчика заполнены!");
                        }
                        else 
                        {
                            using (File.Create(_manager.folderName + @"/Маршруты/Заказчик.txt")) ;
                       
                                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Заказчик.txt"))
                                {
                                    sw.WriteLine(name_org.Text);
                                    sw.WriteLine(dogovor_n.Text);
                                    sw.WriteLine(transgaz.Text);
                                }
                        }

                        if (granici_work.Text == "")
                        {
                            using (File.Create(_manager.folderName + @"/Маршруты/Границы работ.txt")) ;

                            using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Границы работ.txt"))
                            {
                                sw.WriteLine("-");
                            }
                        }
                        else 
                        {
                            using (File.Create(_manager.folderName + @"/Маршруты/Границы работ.txt")) ;

                            using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Границы работ.txt"))
                            {
                                sw.WriteLine(granici_work.Text);
                            }
                        }

                        if (aaaaa.Text == "" || category.Text == "")
                        {
                            
                        }
                        else
                        {
                            using (File.Create(_manager.folderName+"/Маршруты/Параметры трубопровода.txt"));
                            using (StreamWriter sw =
                                new StreamWriter(_manager.folderName + "/Маршруты/Параметры трубопровода.txt"))
                            {
                                sw.Write("-"+ ";" + workP.Text + ";" + category.Text);
                            }


                        }

                    }
                    else { MessageBox.Show("Архив уже существует!"); }


                }
            }
           
        }

        private void открытьАрхивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog archive = new FolderBrowserDialog();
            if (archive.ShowDialog() == DialogResult.OK)
            {
                _manager.folderName = archive.SelectedPath;

                if (File.Exists(_manager.folderName + @"/Маршруты/" + "Маршрут - 1.txt")) 
                {
                    List<string> preset = new List<string>();
                    
                   
                        using (StreamReader sr = new StreamReader(_manager.folderName + @"/Маршруты/" + "Маршрут - 1.txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                preset.Add(sr.ReadLine());
                            }
                        }

                    try
                    {
                        lpumg_box.Text = preset[0];
                        ks_box.Text = preset[1];
                        kc_text.Text = preset[2];
                        ttks_box.Text = preset[3];
                        nuber_text.Text = preset[4];
                        proklad_box.Text = preset[5];
                        obj_text.Text = preset[6];
                        distance_text.Text = preset[7];
                        control_box.Text = preset[8];
                        lenght_text.Text = preset[9];
                        worker_box.Text = preset[10];
                        doljnost_box.Text = preset[11];
                        sred_box.Text = preset[12];
                        try { start_date.Value = Convert.ToDateTime(preset[13]); } catch { }
                        try { end_date.Value = Convert.ToDateTime(preset[14]); } catch { }
                        //_manager.folderName = preset[15];
                        try { zagrpc.Text = preset[17]; } catch { }
                    }
                    catch { }
                        

                    try 
                    {
                        string[] sostav = File.ReadAllLines(_manager.folderName + @"/Маршруты/Состав специалистов.txt");

                        foreach (string so in sostav)
                        {
                            string[] s = so.Split(';');
                            dataGridView1.Rows.Add(s);
                        }
                    } 
                    catch { }

                    try 
                    {
                        string[] sred = File.ReadAllLines(_manager.folderName + @"/Маршруты/Средства контроля.txt");

                        foreach (string sr in sred) 
                        {
                            string[] s = sr.Split(';');
                            dataGridView2.Rows.Add(s);
                        }
                    }
                    catch{ }

                    try
                    {
                        string[] org = File.ReadAllLines(_manager.folderName + @"/Маршруты/Организация.txt");

                        org_name.Text = org[0];
                        sved.Text = org[1];
                        dei_do.Text = org[2];
                    }
                    catch { }

                    try
                    {
                        string[] zak = File.ReadAllLines(_manager.folderName + @"/Маршруты/Заказчик.txt");

                        name_org.Text = zak[0];
                        dogovor_n.Text = zak[1];
                        transgaz.Text = zak[2];
                    }
                    catch { }

                    try
                    {
                        string[] gran = File.ReadAllLines(_manager.folderName + @"/Маршруты/Границы работ.txt");

                        for (int i = 0; i < gran.Length; i++) 
                        {
                            granici_work.AppendText(gran[i] + Environment.NewLine);

                        }


                    }
                    catch { }

                    if (File.Exists(_manager.folderName + "/Маршруты/Параметры трубопровода.txt"))
                    {
                        try
                        {
                            string[] file = File.ReadAllLines(_manager.folderName + "/Маршруты/Параметры трубопровода.txt");

                            proektP.Text = file[0].Split(';')[0];
                            workP.Text = file[0].Split(';')[1];
                            category.Text = file[0].Split(';')[2];
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void редакторВыпадающихСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Редактор rs = new Редактор(_manager);
            //rs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void пресетыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void формаОтчетаНеразрушающегоКонтроляОсновногоМеталлаТрубИСДТToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            _manager.diagnostic_number = nuber_text.Text;
            if (_manager.folderName == null) { MessageBox.Show("Сначала создайте архив!"); }
            else
            {
                if (nuber_text.Text == "")
                {
                    MessageBox.Show("Номер участка не указан!");
                }
                else 
                {
                    string[] data = File.ReadAllLines(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt");
                    if (data.Length > 0)
                    {
                        _manager.JournalOpened = true;
                        NuberCloser();
                        Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ ok = new Отчет_неразрушающего_контроля_основного_металла_труб_и_СДТ(_manager, nuber_text);
                        ok.Show();
                    }
                    else MessageBox.Show("Заполните хотя бы один элемент в Журнале элементов!");
                    
                }
               
            }
               
        }

        //private void distance_text_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //------------/- Невозможно поставить запятую -\------------//
        //    if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back
        //         & e.KeyChar != ',')
        //    {
        //        e.Handled = true;
        //    }

        //    base.OnKeyPress(e);
        //}

        private void distance_text_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void distance_text_Enter(object sender, EventArgs e)
        {
         
        }
        void Creating()
        {
            if (!File.Exists(_manager.folderName + @"/Маршруты/" + "Маршрут - " + nuber_text.Text + ".txt"))
            {
                using (File.Create(_manager.folderName + @"/Маршруты/" + "Маршрут - " + nuber_text.Text + ".txt")) ;
                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/" + "Маршрут - " + nuber_text.Text + ".txt"))
                {
                    sw.Write(GettingPreset());
                }
            }

            if (!File.Exists(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt"))
            {
                using (File.Create(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt"));
                Directory.CreateDirectory(_manager.folderName + @"/Толщинометрия/" + "Маршрут - " + nuber_text.Text);
                CreateFolder(nuber_text.Text, "/ВИК");
                CreateFolder(nuber_text.Text, "/ВТО");
                CreateFolder(nuber_text.Text, "/Протоколы");
                CreateFolder(nuber_text.Text, "/ЭМА-ПВ");
                CreateFolder(nuber_text.Text, "/ЭМА-СВ");

            }
            else MessageBox.Show("Маршрут уже создан!");
        }
        private void маршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manager.folderName != null)
            {
                Creating();
            }
            else MessageBox.Show("Сначала создайте архив!");
 
        }

        private void журналыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void архивToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuber_text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pogodaGrid.Rows.Clear();
                string[] current_marshrut = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt");
                lenght_text.Text = current_marshrut[9];

                foreach (var m in current_marshrut)
                {
                    if (m.Split(';')[0].Contains("погода"))
                    {
                        string[] mr = new string[3];
                        mr[0] = m.Split(';')[1];
                        mr[1] = m.Split(';')[2];
                        mr[2] = m.Split(';')[3];

                        pogodaGrid.Rows.Add(mr);
                    }
                }


                zagrpc.Text = current_marshrut[17];
            }
            catch
            {
            }



        }

        private void nuber_text_Enter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            void csvInit()
            {

                FolderBrowserDialog fl = new FolderBrowserDialog();
                if (fl.ShowDialog() == DialogResult.OK)
                {
                    string path = fl.SelectedPath;
                    string[] files = Directory.GetFiles(path);
                    List<string> fileNames = new List<string>();

                    foreach (string file in files)
                    {
                        fileNames.Add(Path.GetFileName(file));
                    }

                    for (int i = 0; i < fileNames.Count; i++)
                    {
                        string[] data = fileNames[i].Split('-');
                        string[] _first = data[0].Split('_');
                        string[] _second = data[1].Split('_');

                        if (nuber_text.Text == Convert.ToInt32(_first[0]).ToString()) 
                        {
                            
                        }
                    }



                }

                csvInit(); //TESTING FUNCTION
            }

            //MessageBox.Show(i.ToString());
        }

        private void менеджерФайловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manager.folderName != null)
            {
                Менеджер_файлов mf = new Менеджер_файлов(_manager, nuber_text,start_date,end_date);
                mf.Show();
            }
            else MessageBox.Show("Сначала создайте архив!");

           
        }

        private void редакторСписковToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_manager.RedactorOpened) 
            {
                FormParser();
            }
            if (_manager.JournalOpened)
            {
                try
                {
                    string[] current_marshrut = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt");
                    lenght_text.Text = current_marshrut[9];
                    журналыToolStripMenuItem.Enabled = false;
                }
                catch { }
            }
            else 
            {

                журналыToolStripMenuItem.Enabled = true;
            }
            
        }

        private void редакторСписковToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _manager.RedactorOpened = true;
            Редактор rd = new Редактор(_manager);
            rd.Show();
        }

        private void пресетыToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manager.folderName == null) { MessageBox.Show("Сначала создайте архив!"); }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(save.FileName + ".txt",true))
                    {
                        sw.Write(lpumg_box.Text + "\n" +
                            ks_box.Text + "\n" +
                            kc_text.Text + "\n" +
                            ttks_box.Text + "\n" +
                            nuber_text.Text + "\n" +
                            proklad_box.Text + "\n" +
                            obj_text.Text + "\n" +
                            distance_text.Text + "\n" +
                            control_box.Text + "\n" +
                            lenght_text.Text + "\n" +
                            start_date.Value.Date + "\n" + // NEW 
                            end_date.Value.Date + "\n");

                        if (org_name.Text == "" || sved.Text == "" || dei_do.Text == "")
                        {
                            MessageBox.Show("Не все данные организации, которая проводила контроль, заполнены!");
                        }
                        else
                        {
                            
                                sw.WriteLine(org_name.Text);
                                sw.WriteLine(sved.Text);
                                sw.WriteLine(dei_do.Text);
      

                        }

                        if (name_org.Text == "" || dogovor_n.Text == "")
                        {
                            MessageBox.Show("Не все данные заказчика заполнены!");
                        }
                        else
                        {
                           
                                sw.WriteLine(name_org.Text);
                                sw.WriteLine(dogovor_n.Text);
                        }

                        if (granici_work.Text == "")
                        {
                            
                                sw.WriteLine("-");

                        }
                        else
                        {

                              sw.WriteLine(granici_work.Text);
                           
                        }
                    }

                    
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> preset = new List<string>();
            OpenFileDialog folder = new OpenFileDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(folder.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        preset.Add(sr.ReadLine());
                    }
                }

                lpumg_box.Text = preset[0];
                ks_box.Text = preset[1];
                kc_text.Text = preset[2];
                ttks_box.Text = preset[3];
                nuber_text.Text = preset[4];
                proklad_box.Text = preset[5];
                obj_text.Text = preset[6];
                distance_text.Text = preset[7];
                control_box.Text = preset[8];
                lenght_text.Text = preset[9];

                try { start_date.Value = Convert.ToDateTime(preset[10]); } catch { }
                try { end_date.Value = Convert.ToDateTime(preset[11]); } catch { }

                org_name.Text = preset[12];
                sved.Text = preset[13];
                dei_do.Text = preset[14];
                name_org.Text = preset[15];
                dogovor_n.Text = preset[16];
                granici_work.Text = preset[17];




                //_manager.folderName = preset[13];
            }
        }

        private void lpumg_box_Leave(object sender, EventArgs e)
        {
           //TODO add in list
        }

        private void журналТолщинометрииСДТToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.diagnostic_number = nuber_text.Text;
            if (_manager.folderName == null) { MessageBox.Show("Сначала создайте архив!"); }
            else
            {
                if (!File.Exists(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt"))
                {
                    MessageBox.Show("Маршрута не существует!");
                }
                else
                {
                    string[] data = File.ReadAllLines(_manager.folderName + "/Журнал контроля/" + "Маршрут - " + nuber_text.Text + ".txt");
                    if (data.Length > 0)
                    {
                        _manager.JournalOpened = true;
                        NuberCloser();
                        Журнал_толщинометрии_СДТ ok = new Журнал_толщинометрии_СДТ(_manager, nuber_text);
                        ok.Show();
                    }
                    else MessageBox.Show("Заполните хотя бы один элемент в Журнале элементов!");
                }
                
            }

            //Журнал_толщинометрии_СДТ ok = new Журнал_толщинометрии_СДТ();
            //ok.Show();
        }

        
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (worker_box.SelectedItem.ToString() == "" || doljnost_box.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
                else
                {
                    string[] doljn = File.ReadAllLines(mainn + "/src/Исполнитель.txt");

                    foreach (string dol in doljn)
                    {
                        string[] dol_pe = dol.Split(';');

                        if (dol_pe[0].ToLower().Contains(worker_box.SelectedItem.ToString().ToLower()))
                        {
                            string[] st = new string[5];
                            for (int i = 0; i <= 3; i++)
                            {
                                if (i == 3)
                                {
                                    st[i] = doljnost_box.SelectedItem.ToString();
                                }
                                else st[i] = dol_pe[i];
                            }

                            if (dol_pe[dol_pe.Length - 1] == "")
                            {
                                st[4] = dol_pe[dol_pe.Length - 2];
                            }
                            else
                            {
                                st[4] = dol_pe[dol_pe.Length - 1];
                            }


                            dataGridView1.Rows.Add(st);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] sved = File.ReadAllLines(mainn + @"/src/Средства проведения.txt");

                foreach (string sv in sved)
                {
                    string[] sv_pe = sv.Split(';');
                    if (sv_pe[0].ToLower().Contains(sred_box.SelectedItem.ToString().ToLower()))
                    {
                        dataGridView2.Rows.Add(sv_pe);
                    }
                }
            }
            catch { }
            
        }

        private void обновитьИнформациюЖурналаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] allFiles = Directory.GetFiles(_manager.folderName + @"/Маршруты");
            List<string> f = new List<string>();
            foreach (string file in allFiles) 
            {
                if (Path.GetFileNameWithoutExtension(file).Contains("Маршрут - ")) 
                {
                    f.Add(file);
                }
            }

            if (File.Exists(_manager.folderName + "/Маршруты/Параметры трубопровода.txt"))
            {
                using (StreamWriter sw =
                    new StreamWriter(_manager.folderName + "/Маршруты/Параметры трубопровода.txt"))
                {
                    sw.Write(proektP.Text + ";" + workP.Text + ";" + category.Text);
                }
            }
            else
            {
                using (File.Create(_manager.folderName + "/Маршруты/Параметры трубопровода.txt"));

                using (StreamWriter sw =
                    new StreamWriter(_manager.folderName + "/Маршруты/Параметры трубопровода.txt"))
                {
                    sw.Write(proektP.Text + ";" + workP.Text + ";" + category.Text);
                }
            }




            if (!File.Exists(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt"))
            {
                MessageBox.Show("Маршрут для записи погодных условий не найден!");
            }
            else
            {
                string[] current_marshrut = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt");

                using (StreamWriter sw = new StreamWriter(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt"))
                {
                    sw.WriteLine(GettingPreset());

                    for (int i = 0; i < pogodaGrid.Rows.Count; i++)
                    {
                        string row = "погода;";
                        for (int j = 0; j < pogodaGrid.ColumnCount; j++)
                        {
                            row += pogodaGrid[j, i].Value + ";";
                        }

                        sw.WriteLine(row);
                    }


                }
            }


            {
                using (File.Create(_manager.folderName + @"/Маршруты/Состав специалистов.txt"));
                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Состав специалистов.txt"))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            sw.Write(dataGridView1[j, i].Value + ";");
                        }
                        sw.WriteLine();
                    }
                }
            }

            {
                using (File.Create(_manager.folderName + @"/Маршруты/Средства контроля.txt")) ;
                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Средства контроля.txt"))
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            sw.Write(dataGridView2[j, i].Value + ";");
                        }
                        sw.WriteLine();
                    }
                }
            }

            if (org_name.Text == "" || sved.Text == "" || dei_do.Text == "")
            {
                MessageBox.Show("Не все данные организации, которая проводила контроль, заполнены!");
            }
            else
            {
                using (File.Create(_manager.folderName + @"/Маршруты/Организация.txt")) ;

                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Организация.txt"))
                {
                    sw.WriteLine(org_name.Text);
                    sw.WriteLine(sved.Text);
                    sw.WriteLine(dei_do.Text);
                }

            }

            if (name_org.Text == "" || dogovor_n.Text == "")
            {
                MessageBox.Show("Не все данные заказчика заполнены!");
            }
            else
            {
                using (File.Create(_manager.folderName + @"/Маршруты/Заказчик.txt")) ;

                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Заказчик.txt"))
                {
                    sw.WriteLine(name_org.Text);
                    sw.WriteLine(dogovor_n.Text);
                    sw.WriteLine(transgaz.Text);
                }
            }

            if (granici_work.Text == "")
            {
                MessageBox.Show("Границы проведения работ не указаны!");
            }
            else
            {
                using (File.Create(_manager.folderName + @"/Маршруты/Границы работ.txt")) ;

                using (StreamWriter sw = new StreamWriter(_manager.folderName + @"/Маршруты/Границы работ.txt"))
                {
                    sw.WriteLine(granici_work.Text);
                }
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height < 845) 
            {
                
            }
        }

        private void картиночкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        string Rmer(string num) 
        {
            if (num.Contains('.')) 
            {
                string[] dt = num.Split('.');
                num = dt[0] + "," + dt[1];
            }
            return num;
        }
        private void button3_Click(object sender, EventArgs e)
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

            #region repair
            //for (int i = 0; i < allELS.Count; i++)
            //{
            //    try
            //    {
            //        string[] el = allELS[i].Split(';');
            //        Image img;

            //        double d1 = Convert.ToDouble(el[5]) * 100;
            //        double d2 = Convert.ToDouble(el[3]) * 100;

            //        img = new Bitmap(Convert.ToInt32(d1) + 10, Convert.ToInt32(d2) + 10 + 50);

            //        using (Graphics gr = Graphics.FromImage(img))
            //        {
            //            gr.DrawRectangle(new Pen(Color.DarkBlue, 2), 5, 5, Convert.ToInt32(d1), Convert.ToInt32(d2));

            //            //MessageBox.Show(allVTOS.Count.ToString());
            //            for (int vo = 0; vo < allVTOS.Count; vo++)
            //            {

            //                string[] vt = allVTOS[vo].Split(';');

            //                if (vt[0] == el[0] && vt[1] == el[1])
            //                {
            //                    if (vt[2] != "-")
            //                    {
            //                        Color color = Color.FromArgb(400 / 100 * 40, 228, 255, 5);
            //                        SolidBrush br = new SolidBrush(color);
            //                        Color fontCol = Color.Black;
            //                        SolidBrush fontBr = new SolidBrush(fontCol);

            //                        Font font = new Font(this.label25.Font, FontStyle.Regular);

            //                        double dl1 = Math.Round(Convert.ToDouble(vt[8]), 0) / 10;
            //                        double dl2 = Math.Round(Convert.ToDouble(vt[9]), 0) / 10;

            //                        double rasp1 = Convert.ToDouble(vt[4]) * 100;
            //                        double rasp2 = Convert.ToDouble(vt[5]) * 100;

            //                        gr.FillRectangle(br, Convert.ToInt32(rasp1 - (dl1 / 2) + 5), Convert.ToInt32(rasp2 - (dl2 / 2) + 5),
            //                                             Convert.ToInt32(dl1), Convert.ToInt32(dl2));

            //                        gr.DrawString(vt[0] + "." + vt[2], font, fontBr,
            //                            Convert.ToInt32(rasp1 - (dl1 / 2) + 5),
            //                            Convert.ToInt32(rasp2 - (dl2 / 2) + 5));

            //                        img.Save(_manager.folderName + @"/Элемент_" + i + "_" + el[2] + "_.png", ImageFormat.Png);
            //                    }
            //                }
            //            }

            //            for (int m = 0; m < allMA.Count; m++)
            //            {
            //                string[] ma = allMA[m].Split(';');

            //                if (el[0] == ma[0] && el[1] == ma[1])
            //                {
            //                    if (ma[3] != "-")
            //                    {
            //                        MessageBox.Show("!");
            //                        Color color = Color.FromArgb(400 / 100 * 40, 203, 5, 252);
            //                        SolidBrush br = new SolidBrush(color);
            //                        Color fontCol = Color.Black;
            //                        SolidBrush fontBr = new SolidBrush(fontCol);

            //                        Font font = new Font(this.label25.Font, FontStyle.Regular);

            //                        double dl1 = Math.Round(Convert.ToDouble(ma[8]), 0) / 10;
            //                        double dl2 = Math.Round(Convert.ToDouble(ma[9]), 0) / 10;

            //                        double rasp1 = Convert.ToDouble(ma[5]) * 100;
            //                        double rasp2 = Convert.ToDouble(ma[5]) + dl1 * 100;

            //                        gr.FillRectangle(br, Convert.ToInt32(rasp1 - (dl1 / 2) + 5), Convert.ToInt32(rasp2 - (dl2 / 2) + 5),
            //                                             Convert.ToInt32(dl1), Convert.ToInt32(dl2));
            //                        gr.DrawString(ma[0] + "." + ma[2], font, fontBr,
            //                           Convert.ToInt32(rasp1 + 5),
            //                           Convert.ToInt32(rasp2 + 5));

            //                        img.Save(_manager.folderName + @"/Элемент_" + i + "_" + el[2] + "_.png", ImageFormat.Png);
            //                    }
            //                }
            //            }

            //            //img.Save(_manager.folderName + @"/Элемент_" + i+"_" + el[2]  + "_.png", ImageFormat.Png) ;
            //        }
            //    }
            //    catch { break; }



            //}
            #endregion

            string[] colors = File.ReadAllLines(mainn + @"/src/Цвета МА.txt");
            string[] colors_vto = File.ReadAllLines(mainn + @"/src/Цвета ВТО.txt");
            for (int i = 0; i < allELS.Count; i++)
            {
                string[] el = allELS[i].Split(';');
                double height = Convert.ToDouble(el[3]) * 100;
                double weight = Convert.ToDouble(el[5]) * 100-Convert.ToDouble(el[6])/10;

                List<string> osob = new List<string>(); 

                int defs = 0;

                int pad_x = 60; //25
                int pad_y = 40; //20

                int bit_weight = Convert.ToInt32(weight + pad_x + 20);
                int bit_height = Convert.ToInt32(height + 50 + pad_y);

                Image img = new Bitmap(bit_weight, bit_height);
                

                using (Graphics gr = Graphics.FromImage(img)) 
                {
                    gr.FillRectangle(new SolidBrush(Color.White),0,0,bit_weight,bit_height);
                                                   
                    gr.FillRectangle(new SolidBrush(Color.FromArgb(1,13,77)), 0, 0, bit_weight, bit_height-50);

                    int horizont_count = 0;
                    for (int x = pad_x; x < bit_weight; x += 100) 
                    {
                        gr.DrawLine(new Pen(Color.White),x,5,x,Convert.ToInt32(height+25));
                        gr.DrawString(horizont_count.ToString()+" м", label25.Font, new SolidBrush(Color.White),x-9, Convert.ToInt32(height + 25));
                        horizont_count++;
                    }

                    double vert = height / 12;
                    
                    //MessageBox.Show(count_of_30.ToString());
                    

                    int vert_count = 0;
                    int grad = 0;

                    gr.DrawString("  гр.", label25.Font, new SolidBrush(Color.White), 0, 0);
                    gr.DrawString(" ч.", label25.Font, new SolidBrush(Color.White), 35, 0);

                    for (int y = pad_y-20; y < bit_height; y += Convert.ToInt32(vert)) 
                    {
                        if (vert_count <= 12) 
                        {
                            gr.DrawLine(new Pen(Color.White), pad_x-10, y, bit_weight - 15, y);

                            string n = "";
                            if (vert_count < 10)
                            {
                                n = " " + vert_count;
                            }
                            else n = vert_count.ToString();

                            gr.DrawString(n, label25.Font, new SolidBrush(Color.White), pad_x-26, y - 5);
                            vert_count ++;

                            gr.DrawLine(new Pen(Color.White), 24, y, 30, y);

                            string nn = "";
                            if (grad < 100)
                            {
                                if (grad == 0) 
                                {
                                    nn += "  "+grad;
                                }
                                else nn += " " + grad;
                            }
                            else nn = grad.ToString();

                            gr.DrawString(nn, label25.Font, new SolidBrush(Color.White), 0, y - 5);
                            grad += 30;
                        } 
                    }

                    gr.DrawLine(new Pen(Color.White), 27, 5, 27, Convert.ToInt32(height + 25));

                    //gr.FillRectangle(new SolidBrush(Color.Aquamarine),0+pad_x,0+pad_y/2,10,10);                                               //0;0
                    //gr.FillRectangle(new SolidBrush(Color.Azure), 0 + pad_x, Convert.ToInt32(height)+pad_y/2-10, 10, 10);                     //0;-

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
                            double vto_y2 = Math.Round(Convert.ToDouble(vto[9])/10,0);


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

                            gr.DrawString(vto[0] + "." + vto[2], label26.Font, new SolidBrush(Color.White), 
                                          Convert.ToInt32(vto_x1) + pad_x + 1,
                                          Convert.ToInt32(vto_y1) + pad_y/2 -label26.Font.Size*2);

                            defs++;
                        }
                    }

                    for (int j = 0; j < allMA.Count; j++)
                    {
                        string[] ma = allMA[j].Split(';');

                        if (ma[0] == el[0] && ma[1] == el[1] && (!ma[3].ToString().Contains("-")|| !ma[4].ToString().Contains("Дефектов не обнаружено")))
                        {
                            double ma_x1 = Math.Round(Convert.ToDouble(Rmer(ma[5]))/10 , 0);
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

                                    color = Color.FromArgb(alpha*10 / 100 * alpha,r,g,b);
                                    Color color1 = Color.FromArgb(r, g, b);
                                    if (osob.Count == 0)
                                    {
                                        osob.Add(colors[c].Split(';')[0] + ";" + r + "," + g + "," +b);
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

                                            Color cll = Color.FromArgb(rr,gg,bb);

                                            if (color1 == cll)
                                            {
                                                s++;
                                            }
                                        }

                                        if (s == 0)
                                        {
                                            osob.Add(colors[c].Split(';')[0]+";"+r+","+g+","+b);
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

                            gr.DrawString(ma[0] + "." + ma[3], label26.Font, new SolidBrush(Color.White),
                                          Convert.ToInt32(ma_x1) + pad_x + 1,
                                          Convert.ToInt32(ma_y1) + pad_y + 1/2 - label26.Font.Size * 2);

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
                                maxLen = le_0+5;

                            else if (le_1 > le_2)
                                maxLen = le_1+5;

                            else
                                maxLen = le_2+5;
                        }
                        catch { }
                        
                       

                        //ПЕРВЫЙ СТОЛБЕЦ
                        try 
                        {
                            string[] os = osob[0].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r,g,b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 5)+pad_y, 9, 9);
                            gr.DrawString("   - "+osob[0].Split(';')[0],label25.Font,fontBr,15, Convert.ToInt32(height + 2)+pad_y);

                        } 
                        catch { }

                        try
                        {
                            string[] os = osob[1].Split(';');
                            int r = Convert.ToInt32(os[1].Split(',')[0]);
                            int g = Convert.ToInt32(os[1].Split(',')[1]);
                            int b = Convert.ToInt32(os[1].Split(',')[2]);

                            Color col = Color.FromArgb(r, g, b);

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 20)+pad_y, 9, 9);
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

                            gr.FillRectangle(new SolidBrush(col), 10, Convert.ToInt32(height + 35)+pad_y, 9, 9);
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

                            gr.FillRectangle(new SolidBrush(col), maxLen*7 + 7, Convert.ToInt32(height + 5)+pad_y, 9, 9);
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

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 20)+pad_y, 9, 9);
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

                            gr.FillRectangle(new SolidBrush(col), maxLen * 7 + 7, Convert.ToInt32(height + 35)+pad_y, 9, 9);
                            gr.DrawString("   - " + osob[5].Split(';')[0], label25.Font, fontBr, maxLen * 7 + 10, Convert.ToInt32(height + 32) + pad_y);
                        }
                        catch { }



                        img.Save(_manager.folderName + @"/Элемент_" + el[0] + "_" + el[1] + /*"_" + el[2] +*/ "_.png", ImageFormat.Png);
                    }
                }
               
                
            }
        }

        private void редакторЦветовогоОтображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.RedactorOpened = true;
            Цветовой_редактор rd = new Цветовой_редактор(_manager);
            rd.Show();
        }

        private void конвертерЖурналовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Конвертер_журналов kj = new Конвертер_журналов(_manager, nuber_text);
            kj.Show();
        }

        private void ведомостьЖурналаЭлементовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ведомость_журнала_элементов vd = new Ведомость_журнала_элементов(_manager,nuber_text);
            vd.Show();
        }

        private void ведомостьДефектовОсновногоМеталлаЭлементовТрубопроводаПоРезультатамДДКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ведомость_дефектов_основного_металла vd = new Ведомость_дефектов_основного_металла(_manager, nuber_text);
            vd.Show();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (temperatura.Text == "" || vlaga.Text == "")
            {
                MessageBox.Show("Не все критерии погодных условий заполнены!");
            }
            else
            {
                if (nuber_text.Text == "")
                {
                    MessageBox.Show("Укажите номер маршрута!");
                }
                else
                {
                    if (!File.Exists(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt"))
                    {
                        MessageBox.Show("Маршрут для записи погодных условий не найден!");
                    }
                    else
                    {
                        string[] pogods = new string[3];
                        pogods[0] = pogodaTime.Text;
                        pogods[1] = temperatura.Text;
                        pogods[2] = vlaga.Text;

                        pogodaGrid.Rows.Add(pogods);

                        string[] current_marshrut = File.ReadAllLines(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt");

                        using (StreamWriter sw = new StreamWriter(_manager.folderName + "/Маршруты/Маршрут - " + nuber_text.Text + ".txt"))
                        {
                            foreach (string s in current_marshrut)
                            {
                                sw.WriteLine(s);
                            }

                            sw.WriteLine("погода;" + pogods[0]+ ";" + pogods[1] + ";" + pogods[2]);
                        }

                        temperatura.Clear();
                        vlaga.Clear();
                    }
                }
                 
            }
        }

        private void groupBox24_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox21_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox24_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void журналыToolStripMenuItem_EnabledChanged(object sender, EventArgs e)
        {
            if (!журналыToolStripMenuItem.Enabled) 
            {
                
                
            }
            
        }
    }
}
