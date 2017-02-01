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
    public partial class Transfer : Form
    {
        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
        SQLiteDataAdapter DataAdapter = null;
        DataTable Item = new DataTable();
        public Transfer()
        {
            InitializeComponent();
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            Item.Columns.Add("CategoryID", typeof(string));
            Item.Columns.Add("GroupID", typeof(string));
            Item.Columns.Add("GroupName", typeof(string));
            Item.Columns.Add("ItemID", typeof(string));
            Item.Columns.Add("ItemName", typeof(string));
            Item.Columns.Add("ItemSolution", typeof(byte []));
            Item.Columns.Add("Time", typeof(string));

            string sql = string.Format("select * from Item");
            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            try
            {
                conn.Open();
                DataAdapter = new SQLiteDataAdapter(comm);
                conn.Close();
                DataAdapter.Fill(Item);
                gridControl1.DataSource = Item;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ButtonTranfer_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < Item.Rows.Count; i++)
            {
                byte[] bWrite = null;
                byte[] bWrite1 = null;

                MemoryStream mstream = new MemoryStream(Item.Rows[i]["ItemSolution"] as byte[]);
                richTextBox1.LoadFile(mstream, RichTextBoxStreamType.RichText);

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
                Item.Rows[i]["ItemSolution"] = bWrite1;
            }

            
        }

        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            conn.Open();
            for (int i = 0; i < Item.Rows.Count; i++)
            {
                sql.Clear();
                sql.Append(string.Format("update Item set ItemSolution=@ItemSolution where CategoryID='{0}' and GroupID='{1}' and ItemID='{2}';", Item.Rows[i]["CategoryID"], Item.Rows[i]["GroupID"], Item.Rows[i]["ItemID"]));
                try
                {                   
                    SQLiteCommand comm = new SQLiteCommand(sql.ToString(), conn);
                    comm.Parameters.Add("@ItemSolution", DbType.Binary).Value = Item.Rows[i]["ItemSolution"];
                    comm.ExecuteNonQuery();                   
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            conn.Close();



        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            richTextBox1.Text = System.Text.Encoding.Default.GetString((byte[])Item.Rows[a]["ItemSolution"]);
        }
    }
}
