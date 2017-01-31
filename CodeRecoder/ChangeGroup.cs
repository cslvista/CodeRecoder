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
    public partial class ChangeGroup : Form
    {
        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
        public string ID = "";
        public string Category = "";
        public string GroupID = "";
        public string GroupName = "";
        string newGroupName = "";
        public string ItemID = "";
        public string ItemName = "";

        public ChangeGroup()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("不得为空！");
                return;
            }

            //查找该组名
            string sql1= string.Format("select GroupName from Item where CategoryID='{0}' and GroupID='{1}'", textBox1.Text, textBox2.Text);
            SQLiteCommand comm = new SQLiteCommand(sql1, conn);
            try
            {
                conn.Open();                
                SQLiteDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    newGroupName = reader.GetString(0);
                }else
                {
                    reader.Close();
                    conn.Close();
                    MessageBox.Show("没有这个组!");
                    return;
                }
                reader.Close();//不加这句就会造成database is locked
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return;
            }

            string sql2 = string.Format("update Item set CategoryID='{0}',GroupID='{1}',ItemID='{2}',GroupName='{3}' where CategoryID='{4}' and GroupID='{5}' and ItemID='{6}' and ItemName='{7}'", textBox1.Text.Trim(), textBox2.Text.Trim(),textBox3.Text.Trim(),newGroupName,ID,GroupID,ItemID,ItemName);
            SQLiteCommand comm1 = new SQLiteCommand(sql2, conn);
            try
            {
                conn.Open();
                comm1.ExecuteNonQuery();
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

        private void ChangeGroup_Load(object sender, EventArgs e)
        {
            label1.Text = "类别：  "+ Category;
            label2.Text = "组名：  "+ GroupName;
            label3.Text = "编号：  "+ItemID;
            textBox1.Text = ID;
        }
    }
}
