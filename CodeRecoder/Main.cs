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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Details form = new Details();
            form.Show(this);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Details form = new Details();
            form.Show(this);
        }
    }
}
