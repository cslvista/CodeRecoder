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
    public partial class AlterCategory : Form
    {
        public string ID="";
        public string Category = "";

        SQLiteConnection conn = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db");
        public AlterCategory()
        {
            InitializeComponent();
        }

        private void AlterCategory_Load(object sender, EventArgs e)
        {
            textBox1.Text = ID;
            textBox2.Text = Category;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("编号和名称不得为空！");
                return;
            }

            string sql = "";

            if (checkBox1.Checked == true)
            { 
                sql = string.Format("delete from Category where ID='{0}'",ID);
            }
            else
            {
                sql = string.Format("update Category set ID='{0}',Category='{1}' where ID='{0}'", textBox1.Text.Trim(), textBox2.Text.Trim(),ID);

            }

            try
            {
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
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
            //文件操作
            string totalPath = System.Environment.CurrentDirectory + "\\FileItem\\" + Category;
            try
            {
                if (checkBox1.Checked == true)
                {
                    Directory.Delete(totalPath,true);
                }
                else
                {
                    string midPath = System.Environment.CurrentDirectory + textBox2.Text;
                    string newPath = System.Environment.CurrentDirectory + "\\FileItem\\" + textBox2.Text;
                    Directory.Move(totalPath, midPath);
                    Directory.Move(midPath, newPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            

            //更新主界面
            main form = (main)this.Owner;
            form.SearchCategory();
            this.Close();
        }
    }
}
