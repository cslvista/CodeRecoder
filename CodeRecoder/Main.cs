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
    public partial class main : Form
    {
        public DataTable Category = new DataTable();
        public DataTable Item = new DataTable();

        SQLiteConnection conn = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db");
        SQLiteDataAdapter DataAdapter = null;

        public StringBuilder SelectCategoryID = new StringBuilder();
        public StringBuilder SelectCategory = new StringBuilder();
        public StringBuilder SelectGroupID = new StringBuilder();
        public StringBuilder SelectGroupName = new StringBuilder();
        public StringBuilder SelectItemID = new StringBuilder();
        public StringBuilder SelectItemName = new StringBuilder();



        public main()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "代码")
            {
                FileItem form = new FileItem();
                form.Show(this);
            }
            else if(comboBox1.Text == "知识点")
            {
                KnowledgeItem form = new KnowledgeItem();
                form.Show(this);
            }
           
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            SelectCategoryID.Length = 0;
            SelectCategory.Length = 0;
            Item.Clear();
            //1.获取主表内容
            try
            {
                SelectCategoryID.Append(gridView1.GetFocusedRowCellValue("ID").ToString());
                SelectCategory.Append(gridView1.GetFocusedRowCellValue("Category").ToString());
            }
            catch
            {
                return;
            }

            SearchItem();

        }

        public void SearchItem()
        {
            string sql = "";
            if (comboBox1.Text == "代码")
            {
                sql = string.Format("select * from FileItem where ID='{0}'", SelectCategoryID.ToString());
            }
            else
            {
                sql = string.Format("select * from KnowledgeItem where ID='{0}'", SelectCategoryID.ToString());
            }

            SQLiteCommand comm = new SQLiteCommand(sql, conn);

            try
            {
                conn.Open();
                DataAdapter = new SQLiteDataAdapter(comm);
                conn.Close();
                DataAdapter.Fill(Item);
                gridControl2.DataSource = Item;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings form = new settings();
            form.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {
            searchControl1.Properties.NullValuePrompt = " ";
            searchControl2.Properties.NullValuePrompt = " ";
            gridView2.OptionsBehavior.AutoExpandAllGroups = true;
            comboBox1.Text =null;

            Category.Columns.Add("ID", typeof(string));
            Category.Columns.Add("Category", typeof(string));

            Item.Columns.Add("ID", typeof(string));
            Item.Columns.Add("GroupID", typeof(string));
            Item.Columns.Add("GroupName", typeof(string));
            Item.Columns.Add("ItemID", typeof(string));
            Item.Columns.Add("ItemName", typeof(string));
            Item.Columns.Add("Time", typeof(string));

            SearchCategory();
        }

        public void SearchCategory()
        {
            Category.Clear();
            string sql = "select ID,Category from Category";
            SQLiteCommand comm = new SQLiteCommand(sql, conn);

            try
            {
                conn.Open();
                DataAdapter = new SQLiteDataAdapter(comm);
                conn.Close();
                DataAdapter.Fill(Category);
                gridControl1.DataSource = Category;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAlter_Click(object sender, EventArgs e)
        {
            try
            {
                FileItem form = new FileItem();
                form.Show(this);
            }
            catch { }
            
        }

        private void 新增ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCategory form = new AddCategory();
            form.Show(this);
        }

        private void 修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlterCategory form = new AlterCategory();
            form.ID = SelectCategoryID.ToString();
            form.Category = SelectCategory.ToString();
            form.Show(this);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            test form = new test();
            form.Show();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            SelectGroupID.Length = 0;
            SelectGroupName.Length = 0;
            SelectItemID.Length = 0;
            SelectItemName.Length = 0;

            try
            {
                SelectGroupID.Append(gridView1.GetFocusedRowCellValue("GroupID").ToString());
                SelectGroupName.Append(gridView1.GetFocusedRowCellValue("GroupName").ToString());
                SelectItemID.Append(gridView1.GetFocusedRowCellValue("ItemID").ToString());
                SelectItemName.Append(gridView1.GetFocusedRowCellValue("ItemName").ToString());
            }
            catch
            {

            }
        }

        private void searchControl2_TextChanged(object sender, EventArgs e)
        {
            Category.DefaultView.RowFilter = string.Format("Category like '{0}%'", searchControl2.Text);
        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            Item.DefaultView.RowFilter = string.Format("ItemName like '{0}%'", searchControl1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl1_Click(null, null);
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridControl1_Click(null, null);
            }
        }
    }
}
