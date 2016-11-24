using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRecoder
{
    public partial class Choose : Form
    {
        public string ID = "";
        public string Category = "";
        public Choose()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                KnowledgeItem form = new KnowledgeItem();
                form.ID = ID;
                form.Category = Category;
                form.addNew = true;
                form.Show(this.Owner);
            }
            else if (radioButton2.Checked == true)
            {
                FileItem form = new FileItem();
                form.ID = ID;
                form.Category = Category;
                form.addNew = true;
                form.Show(this.Owner);
            }
            this.Close();
        }

        private void Choose_Load(object sender, EventArgs e)
        {

        }
    }
}
