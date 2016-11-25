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
    public partial class main : Form
    {
        public DataTable Category = new DataTable();
        public DataTable Item = new DataTable();

        SQLiteConnection conn = new SQLiteConnection(DataPath.DBPath);
        SQLiteDataAdapter DataAdapter = null;

        public StringBuilder SelectID = new StringBuilder();
        public StringBuilder SelectCategory = new StringBuilder();
        public StringBuilder SelectGroupID = new StringBuilder();
        public StringBuilder SelectGroupName = new StringBuilder();
        public StringBuilder SelectItemID = new StringBuilder();
        public StringBuilder SelectItemName = new StringBuilder();
        public StringBuilder SelectItemType = new StringBuilder();



        public main()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (SelectID.ToString() == "")
            {
                return;
            }

            if (comboBox1.Text == "数据库")
            {
                FileItem form = new FileItem();
                form.ID = SelectID.ToString();
                form.Category = SelectCategory.ToString();
                form.addNew = true;
                form.Show(this);
            }
            else if(comboBox1.Text == "文件")
            {
                KnowledgeItem form = new KnowledgeItem();
                form.ID = SelectID.ToString();
                form.Category = SelectCategory.ToString();
                form.addNew = true;
                form.Show(this);
            }else if (comboBox1.Text == "全部")
            {
                Choose form = new Choose();
                form.ID = SelectID.ToString();
                form.Category = SelectCategory.ToString();
                form.Show(this);
            }

        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            SelectID.Length = 0;
            SelectCategory.Length = 0;
            Item.Clear();
            //1.获取主表内容
            try
            {
                SelectID.Append(gridView1.GetFocusedRowCellValue("ID").ToString());
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
            Item.Clear();
            string sql = "";
            if (comboBox1.Text == "文件")
            {
                sql = string.Format("select ID,GroupID,GroupName,ItemType,ItemID,ItemName,Time from Item where ID='{0}' and ItemType='1'", SelectID.ToString());
            }
            else if (comboBox1.Text == "数据库")
            {
                sql = string.Format("select ID,GroupID,GroupName,ItemType,ItemID,ItemName,Time from Item where ID='{0}' and ItemType='0'", SelectID.ToString());
            }
            else if (comboBox1.Text == "全部")
            {
                sql = string.Format("select ID,GroupID,GroupName,ItemType,ItemID,ItemName,Time from Item where ID='{0}'", SelectID.ToString());
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
            label1.Visible = false;//用于测量gridview2 中组名的长度
            searchControl1.Properties.NullValuePrompt = " ";
            searchControl2.Properties.NullValuePrompt = " ";
            gridView2.OptionsBehavior.AutoExpandAllGroups = true;
            comboBox1.Text ="全部";

            Category.Columns.Add("ID", typeof(string));
            Category.Columns.Add("Category", typeof(string));

            Item.Columns.Add("ID", typeof(string));
            Item.Columns.Add("GroupID", typeof(string));
            Item.Columns.Add("GroupName", typeof(string));
            Item.Columns.Add("ItemType", typeof(string));
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
                if (SelectItemType.ToString()=="1")
                {
                    FileItem form = new FileItem();
                    form.ID = SelectID.ToString();
                    form.Category = SelectCategory.ToString();
                    form.GroupID = SelectGroupID.ToString();
                    form.GroupName = SelectGroupName.ToString();
                    form.ItemID = SelectItemID.ToString();
                    form.ItemName = SelectItemName.ToString();
                    form.alter = true;
                    form.Show(this);
                }else if (SelectItemType.ToString() == "0")
                {
                    KnowledgeItem form = new KnowledgeItem();
                    form.ID =SelectID.ToString();
                    form.Category = SelectCategory.ToString();
                    form.GroupID = SelectGroupID.ToString();
                    form.GroupName = SelectGroupName.ToString();
                    form.ItemID = SelectItemID.ToString();
                    form.ItemName = SelectItemName.ToString();                    
                    form.alter = true;
                    form.Show(this);
                }
                
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
            form.ID = SelectID.ToString();
            form.Category = SelectCategory.ToString();
            form.Show(this);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectItemID.ToString() == "")
                {
                    return;
                }
                else
                {
                    DelItem form = new DelItem();
                    form.ID = SelectID.ToString();
                    form.Category = SelectCategory.ToString();
                    form.GroupID = SelectGroupID.ToString();
                    form.GroupName = SelectGroupName.ToString();
                    form.ItemID = SelectItemID.ToString();
                    form.ItemName = SelectItemName.ToString();
                    form.ItemType = SelectItemType.ToString();
                    form.Show(this);
                }
                
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
            SelectGroupID.Length = 0;
            SelectGroupName.Length = 0;
            SelectItemID.Length = 0;
            SelectItemName.Length = 0;
            SelectItemType.Length = 0;
            try
            {
                SelectGroupID.Append(gridView2.GetFocusedRowCellValue("GroupID").ToString());
                SelectGroupName.Append(gridView2.GetFocusedRowCellValue("GroupName").ToString());
                SelectItemID.Append(gridView2.GetFocusedRowCellValue("ItemID").ToString());
                SelectItemName.Append(gridView2.GetFocusedRowCellValue("ItemName").ToString());
                SelectItemType.Append(gridView2.GetFocusedRowCellValue("ItemType").ToString());
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

           
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            SelectGroupID.Length = 0;
            SelectGroupName.Length = 0;
            SelectItemID.Length = 0;
            SelectItemName.Length = 0;
            SelectItemType.Length = 0;
            try
            {
                SelectGroupID.Append(gridView2.GetFocusedRowCellValue("GroupID").ToString());
                SelectGroupName.Append(gridView2.GetFocusedRowCellValue("GroupName").ToString());
                SelectItemID.Append(gridView2.GetFocusedRowCellValue("ItemID").ToString());
                SelectItemName.Append(gridView2.GetFocusedRowCellValue("ItemName").ToString());
                SelectItemType.Append(gridView2.GetFocusedRowCellValue("ItemType").ToString());
                if (SelectItemType.ToString() == "1")
                {
                    FileItem form = new FileItem();
                    form.ID = SelectID.ToString();
                    form.Category = SelectCategory.ToString();
                    form.GroupID = SelectGroupID.ToString();
                    form.GroupName = SelectGroupName.ToString();
                    form.ItemID= SelectItemID.ToString();
                    form.ItemName = SelectItemName.ToString();
                    form.alter = true;
                    form.Show(this);
                }else
                {
                    KnowledgeItem form = new KnowledgeItem();
                    form.ID = SelectID.ToString();
                    form.Category = SelectCategory.ToString();
                    form.GroupID = SelectGroupID.ToString();
                    form.GroupName = SelectGroupName.ToString();
                    form.ItemID = SelectItemID.ToString();
                    form.ItemName = SelectItemName.ToString();
                    form.alter = true;
                    form.Show(this);
                }
            }
            catch
            {

            }
        }

        private void gridControl2_MouseUp(object sender, MouseEventArgs e)
        {
            gridControl2_Click(null, null);
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            SearchItem();
            //test form = new test();
            //form.Show();
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

        private void 代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                FileItem form = new FileItem();
                form.ID = SelectID.ToString();
                form.Category = SelectCategory.ToString();
                form.GroupID = SelectGroupID.ToString();
                form.GroupName = SelectGroupName.ToString();
                form.addNewGroup = true;
                form.Show(this);                        
        }

        private void 知识点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                KnowledgeItem form = new KnowledgeItem();
                form.ID = SelectID.ToString();
                form.Category = SelectCategory.ToString();
                form.GroupID = SelectGroupID.ToString();
                form.GroupName = SelectGroupName.ToString();
                form.addNewGroup = true;
                form.Show(this);
        }

        private void 修改组名toolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterGroupName form = new AlterGroupName();
            form.ID = SelectID.ToString();
            form.GroupID = SelectGroupID.ToString();
            form.GroupName = SelectGroupName.ToString();
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
    }
}
