using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace CodeRecoder
{
    public partial class FileItem : Form
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db");

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

            if (alter == true)//则获取答案
            {
                textBox1.ReadOnly = true;
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
            else if (addNewGroup == true) //往组中添加项
            {
                textBox1.ReadOnly = true;

                //获取项目编号
                string sql = string.Format("select max(ItemID) from Item where ID='{0}' and GroupID='{1}' ", ID, GroupID);
                try
                {
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ItemID = (reader.GetInt32(0) + 1).ToString();
                    }
                    else
                    {
                        ItemID = "1";
                    }
                    conn.Close();
                }

                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }

            }
            else if (addNew == true)//添加新的组
            {
                ItemID = "1";

                //获取组号
                string sql = string.Format("select max(GroupID) from Item where ID='{0}' ", ID);
                try
                {
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = comm.ExecuteReader();
                    try
                    {
                        reader.Read();
                        GroupID = (reader.GetInt32(0) + 1).ToString();
                    }
                    catch
                    {
                        GroupID = "1";
                    }

                    conn.Close();
                }

                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            textBox1.Text = GroupName;
            textBox3.Text = ItemName;
            label4.Text = "组号：" + GroupID;
            label3.Text = "编号：" + ItemID;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || richTextBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("组名、标题和内容不得为空！");
                return;
            }
            //保存到磁盘
            string TotalPath= System.Environment.CurrentDirectory + "//FileItem//" + string.Format("{0}//{1}", Category, GroupID);
            string FilePath = System.Environment.CurrentDirectory + "//FileItem//" + string.Format("{0}//{1}//{2}.rtf", Category, GroupID, ItemID);

            if (Directory.Exists(TotalPath) == false)
            {
                Directory.CreateDirectory(TotalPath);
            }

            try
            {
                richTextBox1.SaveFile(FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //写数据库
            string sql = "";
            if (addNew == true)
            {
                sql = string.Format("insert into Item(ID,GroupID,GroupName,ItemType,ItemID,ItemName,Time) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", ID, GroupID, textBox1.Text.Trim(), 1, ItemID, textBox3.Text, textBox3.Text, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            }
            else if (addNewGroup == true)
            {
                sql = string.Format("insert into Item(ID,GroupID,GroupName,ItemType,ItemID,ItemName,Time) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", ID, GroupID, GroupName, 1, ItemID, textBox3.Text, textBox3.Text, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            }
            else if (alter == true)
            {
                sql = string.Format("update Item set ItemName='{0}',Time='{1}' where ID='{2}' and GroupID='{3}' and ItemID='{4}'", textBox3.Text, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"), ID, GroupID, ItemID);
            }

            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return;
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
            Font font = new Font("微软雅黑",10);
            this.richTextBox1.SelectionFont = font;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
