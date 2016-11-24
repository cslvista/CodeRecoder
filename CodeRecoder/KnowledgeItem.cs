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

namespace CodeRecoder
{
    public partial class KnowledgeItem : Form
    {
       
        public string ID = "";
        public string Category = "";
        public string GroupID = "";
        public string GroupName= "";
        public string ItemID = "";      
        public string ItemName = "";
        public bool alter = false;
        public bool addNew = false;
        public bool addNewGroup = false;
        public KnowledgeItem()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("组名、标题和内容不得为空！");
                return;
            }

            //写入数据库
            string sql = "";

            if (addNew == true)
            {
                sql = string.Format("insert into Item(ID,GroupID,GroupName,ItemType,ItemID,ItemName,ItemSolution,Time) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", ID, GroupID, textBox1.Text.Trim(), 0, ItemID, textBox3.Text, textBox2.Text, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            }
            else if (addNewGroup == true)                
            {
                sql = string.Format("insert into Item(ID,GroupID,GroupName,ItemType,ItemID,ItemName,ItemSolution,Time) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", ID, GroupID, GroupName, 0, ItemID, textBox3.Text, textBox2.Text, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            }else if (alter == true)
            {
                sql = string.Format("update Item set ItemName='{0}',ItemSolution='{1}',Time='{2}' where ID='{3}' and GroupID='{4}' and ItemID='{5}'", textBox3.Text, textBox2.Text, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"),ID,GroupID,ItemID);
            }

            using (SQLiteConnection conn1 = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db"))
            {
                using (SQLiteCommand comm = new SQLiteCommand(sql, conn1))
                {
                    try
                    {
                        conn1.Open();
                        comm.ExecuteNonQuery();
                        conn1.Close();
                    }
                    catch (Exception ex)
                    {
                        conn1.Close();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
                            
            //写回主界面
            main form = (main)this.Owner;
            form.SearchItem();
            this.Close();
        }

        private void KnowledgeItem_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db");

            this.Text = "知识点 " + string.Format("({0})",Category);

            if (alter == true)//如果是修改，则获取答案
            {
                textBox1.Text = GroupName;
                textBox1.ReadOnly = true;
                textBox3.Text = ItemName;

                //获取答案
                string sql = string.Format("select ItemSolution from Item where ID='{0}' and GroupID='{1}' and ItemID='{2}'", ID, GroupID, ItemID);
                try
                {
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    textBox2.Text = reader.GetString(0);
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
            else if (addNewGroup == true) //往组中添加项
            {
                textBox1.Text = GroupName;
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
            else if (addNew== true)//添加新的组
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
            

            label4.Text = "组号："+GroupID;
            label3.Text = "编号："+ItemID;
            textBox1.Text = GroupName;
            textBox3.Text = ItemName;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
