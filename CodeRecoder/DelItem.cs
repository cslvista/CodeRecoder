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
        public string ItemID = "";
        public string ItemName = "";
        int labelLength;

        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
        public DelItem()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = string.Format("delete from Item where CategoryID='{0}' and GroupID='{1}' and ItemID='{2}' and ItemName='{3}'", ID, GroupID, ItemID, ItemName);

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
            MainBody form = (MainBody)this.Owner;
            form.SearchItem();
            this.Close();

        }

        private void DelItem_Load(object sender, EventArgs e)
        {
            label1.Text = "主类："+ Category;
            label2.Text= "组名：" + GroupName;
                                 
            label4.Text = "标题：" + ItemName;

            if (label1.Width> label4.Width)
            {
                labelLength = label1.Width;
            }
            else
            {
                labelLength = label4.Width;
            }
            
            groupBox1.Width = labelLength + label4.Location.X * 2;
            this.Width = groupBox1.Width + groupBox1.Location.X * 2+15;
            simpleButton1.Location= new Point((this.Width-simpleButton1.Width)/2, simpleButton1.Location.Y);
        }
    }
}
