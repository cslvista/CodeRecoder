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
    public partial class Add_Alter_Category : Form
    {
        public string ID="";
        public string Category = "";
        public bool alter = false;
        bool success = false;
        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
        public Add_Alter_Category()
        {
            InitializeComponent();
        }

        private void AlterCategory_Load(object sender, EventArgs e)
        {
            textBox1.Text = ID;
            textBox2.Text = Category;
            if (alter)
            {
                this.Text = "修改类别";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("编号和名称不得为空！");
                return;
            }

            if (alter == true)
            {
                success = Alter();
            }
            else
            {
                success = Add();
            }

            //更新主界面
            if (success)
            {
                MainBody form = (MainBody)this.Owner;
                form.SearchCategory();
                this.Close();
            }
                   
        }

        private bool Add()
        {                       
            try
            {
                string sql = string.Format("insert into Category (ID,Category) values ('{0}','{1}')", textBox1.Text.Trim(), textBox2.Text.Trim());
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool Alter()
        {
            try
            {
                string sql = string.Format("update Category set ID='{0}',Category='{1}' where ID='{2}';", textBox1.Text.Trim(), textBox2.Text.Trim(), ID)
                           + string.Format("update Item set CategoryID='{0}' where CategoryID='{1}'", textBox1.Text.Trim(), ID);
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
