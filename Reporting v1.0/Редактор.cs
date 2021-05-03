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
    public partial class Редактор : Form
    {

        Manager _manager = new Manager();
        
        string _name;

        string mainn = Environment.CurrentDirectory;
        public Редактор(Manager manager)
        {
            _manager = manager;
            InitializeComponent();
            listBox1.DoubleClick += new EventHandler(doubleClickByItem);
            fileNamesGetter("*");
        }
        
        private void Редактор_Load(object sender, EventArgs e)
        {
            tb.Enabled = false;
        }

        void fileNamesGetter(string pattern) 
        {
            listBox1.Items.Clear();
            string[] files = Directory.GetFiles(mainn+"/src/",pattern);
            foreach (string file in files) 
            {
                string fileName = Path.GetFileName(file);
                listBox1.Items.Add(fileName);
            }
            
        }
        void doubleClickByItem(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) 
            {
                tb.Clear();
                tb.Enabled = true;
                _name = listBox1.SelectedItem.ToString();
                using (StreamReader sr = new StreamReader(mainn + "/src/" + _name)) 
                {
                    while (!sr.EndOfStream) 
                    {
                        tb.Text+=sr.ReadLine() + "\n";
                    }
                    
                }
            }
            
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            tb.Enabled = false;
            using (StreamWriter sw = new StreamWriter(mainn + "/src/" + _name)) 
            {
                sw.Write(tb.Text);
            }
            tb.Clear();

            

        }

        private void Редактор_FormClosing(object sender, FormClosingEventArgs e)
        {
            _manager.RedactorOpened = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ColorDialog col = new ColorDialog();
            //col.FullOpen = true;


            //if (col.ShowDialog() == DialogResult.OK) 
            //{
            //    MessageBox.Show(col.Color.ToString());
            //}
        }

        private void finder_TextChanged(object sender, EventArgs e)
        {
            fileNamesGetter(finder.Text+"*");
        }
    }
}
