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
using System.IO.Compression;

namespace CodeRecoder
{
    public partial class FileItem : Form
    {
        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);

        public string CategoryID = "";
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
            this.Text = Category;

            if (alter == true)//则获取答案
            {
                string sql = string.Format("select ItemSolution from Item where CategoryID='{0}' and GroupID='{1}' and ItemID='{2}'", CategoryID, GroupID, ItemID);
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                try
                {                    
                    reader.Read();                    
                    MemoryStream ms = new MemoryStream(reader[0] as byte[]);
                    reader.Close();
                    GZipStream zip = new GZipStream(ms, CompressionMode.Decompress);
                    using(MemoryStream ms1 = new MemoryStream())
                    {
                        int b = -1;
                        while ((b = zip.ReadByte()) != -1)
                        {
                            ms1.WriteByte((byte)b);
                        }
                        ms1.Position = 0;
                        richTextBox1.LoadFile(ms1, RichTextBoxStreamType.RichText);
                    }                                          
                    conn.Close();
                }
                catch (Exception ex)
                {
                    reader.Close();
                    conn.Close();                    
                    MessageBox.Show(ex.Message);
                    //return;
                }
                textBox1.Enabled = false;

            }
            else if (addNewGroup == true) //往组中添加项
            {
                textBox1.ReadOnly = true;

                //获取项目编号
                string sql = string.Format("select max(ItemID) from Item where CategoryID='{0}' and GroupID='{1}' ", CategoryID, GroupID);
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
                    reader.Close();
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
                string sql = string.Format("select max(GroupID) from Item where CategoryID='{0}' ", CategoryID);
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
                    reader.Close();
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

            //写数据库
            string sql = "";
            if (addNew == true)
            {
                sql = string.Format("insert into Item(CategoryID,GroupID,GroupName,ItemID,ItemName,ItemSolution,Time) values ('{0}','{1}','{2}','{3}','{4}',@ItemSolution,'{5}')", CategoryID, GroupID, textBox1.Text.Trim(),ItemID, textBox3.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            }
            else if (addNewGroup == true)
            {
                sql = string.Format("insert into Item(CategoryID,GroupID,GroupName,ItemID,ItemName,ItemSolution,Time) values ('{0}','{1}','{2}','{3}','{4}',@ItemSolution,'{5}')", CategoryID, GroupID, GroupName,ItemID, textBox3.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            }
            else if (alter == true)
            {
                sql = string.Format("update Item set ItemName='{0}',Time='{1}',ItemSolution=@ItemSolution where CategoryID='{2}' and GroupID='{3}' and ItemID='{4}';", textBox3.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm"), CategoryID, GroupID, ItemID)
                    + "VACUUM;";
            }

            byte[] bWrite = null;
            byte[] bWrite1 = null;
            using (MemoryStream ms = new MemoryStream())
            {
                richTextBox1.SaveFile(ms, RichTextBoxStreamType.RichText);
                bWrite = ms.ToArray();
            }

            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress))
                {
                    zip.Write(bWrite, 0, bWrite.Length);
                }                    
                bWrite1 = ms.ToArray();
            }
                           
            try
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                comm.Parameters.Add("@ItemSolution", DbType.Binary).Value = bWrite1;
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
            MainBody form = (MainBody)this.Owner;
            form.SearchItem();
            this.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Details_Load(sender, e);
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
            myFont form = new myFont();
            form.Show(this);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
