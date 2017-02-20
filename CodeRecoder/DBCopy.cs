using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CodeRecoder
{
    public partial class DBCopy : Form
    {
        public DBCopy()
        {
            InitializeComponent();
        }

        private void DBCopy_Load(object sender, EventArgs e)
        {
            try{
                string path = Application.StartupPath + "\\path1.txt";
                StreamReader sr = new StreamReader(path, Encoding.GetEncoding("utf-8"));
                txtPath1.Text = sr.ReadLine();
                sr.Close();
            }
            catch
            {

            }

            try{
                string path = Application.StartupPath + "\\path2.txt";
                StreamReader sr = new StreamReader(path, Encoding.GetEncoding("utf-8"));
                txtPath2.Text = sr.ReadLine();
                sr.Close();
            }
            catch { }


        }

        private void btnCopy1_Click(object sender, EventArgs e)
        {
            DBcopy(txtPath1);
        }

        private void DBcopy(TextBox txt)
        {
            string startPath = Application.StartupPath + "\\Data\\CodeRecoder.db";
            if (txt.Text.Trim() == "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "(*.db)|*.db";
                sfd.AddExtension = true;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txt.Text = sfd.FileName;                           
                }

            }
            //复制文件
            try
            {
                File.Copy(startPath, txt.Text,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (txt.Name == "txtPath1")
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\path1.txt", false);
                sw.WriteLine(txt.Text);
                sw.Close();
            }

            if (txt.Name == "txtPath2")
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\path2.txt", false);
                sw.WriteLine(txt.Text);
                sw.Close(); 
            }

            MessageBox.Show("复制成功！");
            

        }

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            DBcopy(txtPath2);
        }

        private void btnRead1_Click(object sender, EventArgs e)
        {
            try
            {
                int location = txtPath1.Text.LastIndexOf("\\");
                string path = txtPath1.Text.Substring(0, location);
                System.Diagnostics.Process.Start("Explorer.exe", @path);
            }
            catch { }
            
        }

        private void btnRead2_Click(object sender, EventArgs e)
        {
            try
            {
                int location = txtPath2.Text.LastIndexOf("\\");
                string path = txtPath2.Text.Substring(0, location);
                System.Diagnostics.Process.Start("Explorer.exe", @path);
            }
            catch { }
        }
    }
}
