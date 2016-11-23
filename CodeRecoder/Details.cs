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
    public partial class Details : Form
    {
        public string chapter="";
        public string title = "";
        public string path = "";
        public string content = "";
        public Details()
        {
            InitializeComponent();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string path = "";
            try
            {
                richTextBox1.SaveFile(path);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.LoadFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            this.richTextBox1.SelectAll();
            //this.richTextBox1.SelectionColor = Color.Black;
            Font font = new Font("微软雅黑",10);
            this.richTextBox1.SelectionFont = font;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
