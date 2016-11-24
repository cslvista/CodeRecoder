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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("编号和名称不得为空！");
                return;
            }

            SQLiteConnection conn = new SQLiteConnection("Data Source="+ System.Environment.CurrentDirectory+"/Database/CodeRecoder.db");

            string sql =string.Format( "insert into Category (ID,Category) values ('{0}','{1}')",textBox1.Text.Trim(),textBox2.Text.Trim());
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

            string totalPath = System.Environment.CurrentDirectory + "\\FileItem\\"+ textBox2.Text.Trim();
            //建立文件夹
            if (Directory.Exists(totalPath) ==false)
            {
                Directory.CreateDirectory(totalPath); 
            }

            //更新主界面
           main form = (main)this.Owner;
           form.SearchCategory();
           this.Close();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
