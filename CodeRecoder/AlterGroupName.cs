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
    public partial class AlterGroupName : Form
    {
        public string ID = "";
        public string GroupID = "";
        public string GroupName = "";
        public AlterGroupName()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("新组名不能为空！");
                return;
            }

            SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
            string sql = string.Format("update Item set GroupName='{0}' where CategoryID='{1}' and GroupID='{2}'", textBox2.Text.Trim(),ID,GroupID);
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

            //更新主界面
            main form = (main)this.Owner;
            form.SearchItem();
            this.Close();
        }

        private void AlterGroupName_Load(object sender, EventArgs e)
        {
            textBox1.Text = GroupName;
            textBox1.ReadOnly = true;

        }
    }
}
