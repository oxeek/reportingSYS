using System;
using System.Drawing;
using System.Windows.Forms;

namespace InputBox
{
    public class InputBox : Form
    {
        private readonly TextBox _textBox;

        public InputBox(string labeltext = "", bool isDigits = false)
        {
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(300, 150);
            
            _textBox = new TextBox
            {
                Size = new Size(250, 25),
                Font = new Font(DefaultFont, FontStyle.Regular),
                Location = new Point(20, 50),
                Text = ""
            };

            if (isDigits)
            {
                _textBox.KeyPress += SetOnlyDigits;
            }

            Controls.Add(_textBox);

            _textBox.Show();

            _textBox.KeyPress += textBox_KeyPress;

            var label = new Label
            {
                AutoSize = false,
                Size = new Size(250, 25)
            };
            label.Font = new Font(label.Font, FontStyle.Regular);
            label.Location = new Point(20, 25);
            label.Text = labeltext;

            Controls.Add(label);

            label.Show();

            var buttonOk = new Button
            {
                Size = new Size(80, 25),
                Location = new Point(105, 75),
                DialogResult = DialogResult.OK,
                Text = "OK"
            };


            Controls.Add(buttonOk);

            buttonOk.Show();





        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Enter)
            {
                return;
            }
            DialogResult = DialogResult.OK;

            Close();
        }

      

        public string GetString()
        {
            return ShowDialog() != DialogResult.OK ? null : _textBox.Text;
        }

        public void SetOnlyDigits(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.ClientSize = new System.Drawing.Size(282, 219);
            this.ControlBox = false;
            this.Name = "InputBox";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);

        }

        private void InputBox_Load(object sender, EventArgs e)
        {

        }
    }
}
