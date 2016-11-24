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
    public partial class FileItem : Form
    {
        public string ID = "";
        public string Category = "";
        public string GroupID = "";
        public string GroupName = "";
        public string ItemID = "";
        public string ItemName = "";
        public bool alter = false;
        public bool addNew = false;
        public bool addNewGroup = false;
        public FileItem()
        {
            InitializeComponent();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            this.Text = "代码 " +string.Format("({0})", Category);
            textBox1.Text = GroupName;
            textBox3.Text = ItemName;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || richTextBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("组名、标题和内容不得为空！");
                return;
            }

            string TotalPath = System.Environment.CurrentDirectory + "//FileItem//" + string.Format("{0}//{1}//{2}.rtf", Category, GroupID, ItemID);

            try
            {
                richTextBox1.SaveFile(TotalPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //写回主界面
            main form = (main)this.Owner;
            form.SearchItem();
            this.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string TotalPath = System.Environment.CurrentDirectory + "//FileItem//" + string.Format("{0}//{1}//{2}.rtf", Category, GroupID, ItemID);
            try
            {
                richTextBox1.LoadFile(TotalPath);
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
            this.richTextBox1.SelectionColor = Color.Black;
            Font font = new Font("微软雅黑",10);
            this.richTextBox1.SelectionFont = font;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
