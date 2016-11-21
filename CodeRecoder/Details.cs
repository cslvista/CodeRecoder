﻿using System;
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
    public partial class Details : Form
    {
        public string chapter="";
        public string title = "";
        public string content = "";
        public Details()
        {
            InitializeComponent();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile("c:\\abc.rtf");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("c:\\abc.rtf");
        }
    }
}