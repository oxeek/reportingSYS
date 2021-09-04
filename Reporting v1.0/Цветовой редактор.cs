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
    public partial class Цветовой_редактор : Form
    {
        Manager _manager = new Manager();

        string mainn = Environment.CurrentDirectory;
        public Цветовой_редактор(Manager manager)
        {
            _manager = manager;
            InitializeComponent();
        }

        private void Цветовой_редактор_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(mainn + "/src/", "Цвета*");

            foreach (string f in files) 
            {
                comboBox1.Items.Add(Path.GetFileNameWithoutExtension(f));
            }
        }

        private void color_pick_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (File.Exists(mainn + "/src/" + comboBox1.SelectedItem.ToString() + ".txt")) 
            {
                string[] file = File.ReadAllLines(mainn + "/src/" + 
                                                 comboBox1.SelectedItem.ToString() + ".txt");
                foreach (string s in file) 
                {
                    string[] ss = s.Split(';');
                    listBox1.Items.Add(ss[0]);
                }
            }
            
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string[] file = File.ReadAllLines(mainn + "/src/" +
                                                 comboBox1.SelectedItem.ToString() + ".txt");
            
            for (int i = 0; i < file.Length; i++) 
            {
                if (listBox1.SelectedItem.ToString() == file[i].Split(';')[0]) 
                {
                    int r = Convert.ToInt32(file[i].Split(';')[1].Split(',')[0]);
                    int g = Convert.ToInt32(file[i].Split(';')[1].Split(',')[1]);
                    int b = Convert.ToInt32(file[i].Split(';')[1].Split(',')[2]);
                    int a = Convert.ToInt32(file[i].Split(';')[1].Split(',')[3]);

                    Image img = new Bitmap(213,55);
                    using (Graphics gr = Graphics.FromImage(img)) 
                    {
                        gr.FillRectangle(new SolidBrush(Color.FromArgb(a,r,g,b)),0,0,213,55);
                    }
                    pictureBox1.Image = img;
                }
            }

            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            if (colorPicker.ShowDialog() == DialogResult.OK) 
            {
                string[] file = File.ReadAllLines(mainn + "/src/" +
                                                 comboBox1.SelectedItem.ToString() + ".txt");

                for (int i = 0; i < file.Length; i++) 
                {
                    string[] f = file[i].Split(';');

                    if (f[0] == listBox1.SelectedItem.ToString()) 
                    {
                        int r = colorPicker.Color.R;
                        int g = colorPicker.Color.G;
                        int b = colorPicker.Color.B;
                        int a = 150; 

                        string rgba = r + "," + g + "," + b + "," + a;
                        string itog = f[0] + ";" + rgba;
                        file[i] = itog;
                    }
                }

                using (StreamWriter sw = new StreamWriter(mainn + "/src/" +
                                                 comboBox1.SelectedItem.ToString() + ".txt")) 
                {
                    foreach (string s in file) 
                    {
                        sw.WriteLine(s);
                    }
                }
            }
        }
    }
}
