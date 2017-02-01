namespace CodeRecoder
{
    partial class Transfer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonWrite = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonTranfer = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.类别ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.组号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.组名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.项目编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.标题 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.内容 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(997, 620);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.ButtonWrite);
            this.panel1.Controls.Add(this.ButtonTranfer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 54);
            this.panel1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(266, 14);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(71, 32);
            this.simpleButton1.TabIndex = 39;
            this.simpleButton1.Text = "引入";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ButtonWrite
            // 
            this.ButtonWrite.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonWrite.Appearance.Options.UseFont = true;
            this.ButtonWrite.Image = ((System.Drawing.Image)(resources.GetObject("ButtonWrite.Image")));
            this.ButtonWrite.Location = new System.Drawing.Point(529, 14);
            this.ButtonWrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonWrite.Name = "ButtonWrite";
            this.ButtonWrite.Size = new System.Drawing.Size(71, 32);
            this.ButtonWrite.TabIndex = 38;
            this.ButtonWrite.Text = "写入";
            this.ButtonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
            // 
            // ButtonTranfer
            // 
            this.ButtonTranfer.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonTranfer.Appearance.Options.UseFont = true;
            this.ButtonTranfer.Image = ((System.Drawing.Image)(resources.GetObject("ButtonTranfer.Image")));
            this.ButtonTranfer.Location = new System.Drawing.Point(410, 14);
            this.ButtonTranfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonTranfer.Name = "ButtonTranfer";
            this.ButtonTranfer.Size = new System.Drawing.Size(71, 32);
            this.ButtonTranfer.TabIndex = 37;
            this.ButtonTranfer.Text = "转换";
            this.ButtonTranfer.Click += new System.EventHandler(this.ButtonTranfer_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(991, 554);
            this.panel2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(597, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(325, 375);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, -3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(575, 558);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.类别ID,
            this.组号,
            this.组名,
            this.项目编号,
            this.标题,
            this.内容});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // 类别ID
            // 
            this.类别ID.Caption = "类别ID";
            this.类别ID.FieldName = "CategoryID";
            this.类别ID.Name = "类别ID";
            this.类别ID.Visible = true;
            this.类别ID.VisibleIndex = 0;
            this.类别ID.Width = 119;
            // 
            // 组号
            // 
            this.组号.Caption = "组号";
            this.组号.FieldName = "GroupID";
            this.组号.Name = "组号";
            this.组号.Visible = true;
            this.组号.VisibleIndex = 2;
            this.组号.Width = 111;
            // 
            // 组名
            // 
            this.组名.Caption = "组名";
            this.组名.FieldName = "GroupName";
            this.组名.Name = "组名";
            this.组名.Visible = true;
            this.组名.VisibleIndex = 1;
            this.组名.Width = 119;
            // 
            // 项目编号
            // 
            this.项目编号.Caption = "编号";
            this.项目编号.FieldName = "ItemID";
            this.项目编号.Name = "项目编号";
            this.项目编号.Visible = true;
            this.项目编号.VisibleIndex = 3;
            this.项目编号.Width = 126;
            // 
            // 标题
            // 
            this.标题.Caption = "标题";
            this.标题.FieldName = "ItemName";
            this.标题.Name = "标题";
            this.标题.Visible = true;
            this.标题.VisibleIndex = 4;
            this.标题.Width = 179;
            // 
            // 内容
            // 
            this.内容.Caption = "内容";
            this.内容.FieldName = "ItemSolution";
            this.内容.Name = "内容";
            this.内容.Visible = true;
            this.内容.VisibleIndex = 5;
            this.内容.Width = 319;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 40;
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 620);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Transfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转换";
            this.Load += new System.EventHandler(this.Transfer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton ButtonWrite;
        private DevExpress.XtraEditors.SimpleButton ButtonTranfer;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 组号;
        private DevExpress.XtraGrid.Columns.GridColumn 组名;
        private DevExpress.XtraGrid.Columns.GridColumn 项目编号;
        private DevExpress.XtraGrid.Columns.GridColumn 标题;
        private DevExpress.XtraGrid.Columns.GridColumn 类别ID;
        private DevExpress.XtraGrid.Columns.GridColumn 内容;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox textBox1;
    }
}