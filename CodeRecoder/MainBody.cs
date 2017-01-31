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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace CodeRecoder
{
    public partial class MainBody : Form
    {
        public DataTable Category = new DataTable();
        public DataTable Item = new DataTable();

        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
        SQLiteDataAdapter DataAdapter = null;
        public MainBody()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }

            FileItem form = new FileItem();
            form.CategoryID = gridView1.GetFocusedRowCellValue("ID").ToString();
            form.Category = gridView1.GetFocusedRowCellValue("Category").ToString();
            form.addNew = true;
            form.Show(this);           
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (Category.Rows.Count > 0)
            {
                SearchItem();
            }
            
        }

        public void SearchItem()
        {
            Item.Clear();           
            string sql = string.Format("select * from Item where CategoryID='{0}'", gridView1.GetFocusedRowCellValue("ID").ToString());
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

        private void main_Load(object sender, EventArgs e)
        {
            searchControl1.Properties.NullValuePrompt = " ";
            searchControl2.Properties.NullValuePrompt = "搜索类别名称";
            gridView2.OptionsBehavior.AutoExpandAllGroups = true;

            Category.Columns.Add("ID", typeof(int));
            Category.Columns.Add("Category", typeof(string));

            Item.Columns.Add("CategoryID", typeof(string));
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
                form.CategoryID = gridView1.GetFocusedRowCellValue("ID").ToString();
                form.Category = gridView1.GetFocusedRowCellValue("Category").ToString();
                form.GroupID = gridView2.GetFocusedRowCellValue("GroupID").ToString();
                form.GroupName = gridView2.GetFocusedRowCellValue("GroupName").ToString();
                form.ItemID = gridView2.GetFocusedRowCellValue("ItemID").ToString();
                form.ItemName = gridView2.GetFocusedRowCellValue("ItemName").ToString();
                form.alter = true;
                form.Show(this);
            }
            catch { }
            
        }

        private void 新增ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Alter_Category form = new Add_Alter_Category();
            form.Show(this);
        }

        private void 修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Alter_Category form = new Add_Alter_Category();
            form.ID = gridView1.GetFocusedRowCellValue("ID").ToString();
            form.Category = gridView1.GetFocusedRowCellValue("Category").ToString();
            form.Show(this);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("是否删除'{0}'？", gridView1.GetFocusedRowCellDisplayText("Category").ToString()), "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            try
            {
                DelItem form = new DelItem();
                form.ID = gridView1.GetFocusedRowCellValue("ID").ToString();
                form.Category = gridView1.GetFocusedRowCellValue("Category").ToString();
                form.GroupID = gridView2.GetFocusedRowCellValue("GroupID").ToString();
                form.GroupName = gridView2.GetFocusedRowCellValue("GroupName").ToString();
                form.ItemID = gridView2.GetFocusedRowCellValue("ItemID").ToString();
                form.ItemName = gridView2.GetFocusedRowCellValue("ItemName").ToString();
                form.Show(this);
            }
            catch
            {

            }
            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            test form = new test();
            form.Show();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            
        }

        private void searchControl2_TextChanged(object sender, EventArgs e)
        {
            Category.DefaultView.RowFilter = string.Format("Category like '{0}%'", searchControl2.Text);
        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            Item.DefaultView.RowFilter = string.Format("ItemName like '%{0}%' or GroupName like '%{0}%'", searchControl1.Text);
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

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileItem form = new FileItem();
                form.CategoryID = gridView1.GetFocusedRowCellValue("ID").ToString();
                form.Category = gridView1.GetFocusedRowCellValue("Category").ToString();
                form.GroupID = gridView2.GetFocusedRowCellValue("GroupID").ToString();
                form.GroupName = gridView2.GetFocusedRowCellValue("GroupName").ToString();
                form.addNewGroup = true;
                form.Show(this);
            }
            catch { }
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {            
            FileItem form = new FileItem();
            form.CategoryID = gridView1.GetFocusedRowCellValue("ID").ToString();
            form.Category= gridView1.GetFocusedRowCellValue("Category").ToString();
            form.GroupID = gridView2.GetFocusedRowCellValue("GroupID").ToString();
            form.GroupName = gridView2.GetFocusedRowCellValue("GroupName").ToString();
            form.ItemID = gridView2.GetFocusedRowCellValue("ItemID").ToString();
            form.ItemName = gridView2.GetFocusedRowCellValue("ItemName").ToString();
            form.alter = true;
            form.Show(this);
        }


        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            SearchItem();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonAlter_Click(null, null);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonDelete_Click(null, null);
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ItemType")
            {
                switch (e.Value.ToString())
                {
                    case "0": e.DisplayText = "数据库"; break;
                    case "1": e.DisplayText = "文件"; break;
                }
            }
        }

        private void 修改组名toolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterGroupName form = new AlterGroupName();
            form.ID = gridView1.GetFocusedRowCellValue("ID").ToString();
            form.GroupID = gridView2.GetFocusedRowCellValue("GroupID").ToString(); 
            form.GroupName = gridView2.GetFocusedRowCellValue("GroupName").ToString(); 
            form.Show(this);
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ItemType")
            {
                string ItemType = gridView2.GetRowCellDisplayText(e.RowHandle, gridView2.Columns["ItemType"]);

                if (ItemType == "文件")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }else
                {
                    e.Appearance.ForeColor = Color.Green;
                }
            }
        }

        private void gridView2_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo GridGroupRowInfo = e.Info as GridGroupRowInfo;
            int index = gridView2.GetDataRowHandleByGroupRowHandle(e.RowHandle);

            //string text = "组名：" + gridView2.GetRowCellValue(index, "GroupName").ToString();

            //label1.Text = text;
            //int length1 = label1.Width;            
            //label1.Text = "你";
            //int lengthspace = label1.Width;

            //int length = System.Convert.ToInt32((160 - length1) / lengthspace);

            //StringBuilder space = new StringBuilder();

            //for (int i = 1; i <= length; i++)
            //{
            //    space.Append(" ");
            //}

            GridGroupRowInfo.GroupText = "组名："+gridView2.GetRowCellValue(index, "GroupName").ToString()
                + "     "+ "组号：" + gridView2.GetRowCellValue(index, "GroupID").ToString();
        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangeGroup form = new ChangeGroup();
            form.ID = gridView1.GetFocusedRowCellValue("ID").ToString();
            form.Category = gridView1.GetFocusedRowCellValue("Category").ToString();
            form.GroupID = gridView2.GetFocusedRowCellValue("GroupID").ToString();
            form.GroupName = gridView2.GetFocusedRowCellValue("GroupName").ToString();
            form.ItemID = gridView2.GetFocusedRowCellValue("ItemID").ToString();
            form.ItemName = gridView2.GetFocusedRowCellValue("ItemName").ToString();
            form.Show(this);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("是否删除'{0}'？", gridView1.GetFocusedRowCellDisplayText("Category").ToString()), "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            try
            {
                string sql = string.Format("delete from Category where ID='{0}';", gridView1.GetFocusedRowCellValue("ID").ToString())
                           + string.Format("delete from Item where CategoryID='{0}';", gridView1.GetFocusedRowCellValue("ID").ToString())
                           + " VACUUM";
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                conn.Open();
                comm.ExecuteNonQuery();               
                conn.Close();
                SearchCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误1:" + ex.Message, "提示");
                return;
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            Add_Alter_Category form = new Add_Alter_Category();
            form.Show(this);
        }

        private void toolStripButtonAlter_Click(object sender, EventArgs e)
        {
            Add_Alter_Category form = new Add_Alter_Category();
            form.ID = gridView1.GetFocusedRowCellValue("ID").ToString();
            form.Category = gridView1.GetFocusedRowCellValue("Category").ToString();
            form.alter = true;
            form.Show(this);
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButtonDelete_Click(sender, e);
        }

        private void 清理数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "VACUUM";
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("清理成功！", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误1:" + ex.Message, "提示");
                return;
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer form = new Transfer();
            form.Show();
        }
    }
}
