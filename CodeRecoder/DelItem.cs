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
    public partial class DelItem : Form
    {
        public string ID = "";
        public string Category = "";
        public string GroupID = "";
        public string GroupName = "";
        public string ItemType = "";
        public string ItemID = "";
        public string ItemName = "";

        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
        public DelItem()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (ItemType == "0")
            {
                sql = string.Format("delete from Item where ID='{0}' and GroupID='{1}' and ItemID='{2}' and ItemName='{3}' and ItemType='0'",ID,GroupID,ItemID,ItemName);
            }
            else
            {
                sql = string.Format("delete from Item where ID='{0}' and GroupID='{1}' and ItemID='{2}' and ItemName='{3}' and ItemType='1'", ID,GroupID,ItemID,ItemName);
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

            //删除文件
            if (ItemType == "1")
            {
                string TotalPath = DataPath.FilePath + string.Format("{0}\\{1}\\{2}.rtf",Category,GroupID,ItemID);

                try
                {
                    if (File.Exists(TotalPath))
                    {
                        File.Delete(TotalPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }

            //写回主界面
            main form = (main)this.Owner;
            form.SearchItem();
            this.Close();

        }

        private void DelItem_Load(object sender, EventArgs e)
        {
            label1.Text = "主类："+ Category;
            label2.Text= "组名：" + GroupName;
            switch (ItemType)
            {
                case "0": label3.Text = "类别：" + "知识点"; break;
                case "1": label3.Text = "类别：" + "代码"; break;
            }           
            label4.Text = "标题：" + ItemName;
        }
    }
}
