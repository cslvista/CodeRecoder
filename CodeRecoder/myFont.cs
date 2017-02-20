using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRecoder
{
    public partial class myFont : Form
    {
        public myFont()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FileItem form = (FileItem)this.Owner;
            form.richTextBox1.SelectAll();
            Font font = new Font(comboBox1.Text, Convert.ToInt32(textBox1.Text));
            form.richTextBox1.SelectionFont = font;
            this.Close();
        }

        private void myFont_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Consolas";
            textBox1.Text = "12";
            textBox2.Text = "13";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FileItem form = (FileItem)this.Owner;
            form.richTextBox1.SelectAll();
            Font font = new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text));
            form.richTextBox1.SelectionFont = font;
            this.Close();
        }
    }
}
