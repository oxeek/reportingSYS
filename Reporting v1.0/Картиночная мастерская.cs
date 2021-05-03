using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace Reporting_v1._0
{
    public partial class Картиночная_мастерская : Form
    {
        Manager _manager = new Manager();
        TextBox value = new TextBox();
        public Картиночная_мастерская(Manager manager, TextBox tb)
        {
            _manager = manager;
            value = tb;
            InitializeComponent();
        }

        private Image CreateImageWithRectangle()
        {
            Image img = new Bitmap(1000, 500);

            using (Graphics gr = Graphics.FromImage(img))
            {
                Color color = Color.FromArgb(250 / 100 * 25, 217, 43, 43);
                gr.DrawRectangle(new Pen(Color.DarkBlue, 2), 0, 0, 1000, 500);

                SolidBrush br = new SolidBrush(color);
                
                gr.FillRectangle(br, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 
                                     Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));

                
            }

            return img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = CreateImageWithRectangle();
            img.Save(_manager.folderName+@"/image.png", ImageFormat.Png);
            pictureBox1.Image = img;
        }

        private void Картиночная_мастерская_Load(object sender, EventArgs e)
        {

        }
    }
}
