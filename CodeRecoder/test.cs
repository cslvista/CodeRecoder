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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db");
            string sql = "select * from Category";
            SQLiteCommand comm= new SQLiteCommand(sql, conn);
            conn.Open();
            try
            {
                SQLiteDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show(reader.GetString(1));
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db");
            string sql = string.Format("insert into Category (id,category) values('{0}','{1}')",textBox1.Text,textBox2.Text);
            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
