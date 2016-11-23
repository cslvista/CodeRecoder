﻿using System;
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
    public partial class KnowledgeItem : Form
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=" + System.Environment.CurrentDirectory + "/Database/CodeRecoder.db");

        public string ID = "";
        public string GroupID = "";
        public string GroupName= "";
        public string ItemID = "";      
        public string ItemName = "";
        public bool alter = false;
        public bool addNewGroup = false;
        public KnowledgeItem()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("insert into Item(ID,GroupID,GroupName,ItemType,ItemID,ItemName,ItemSolution,Time) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", ID, GroupID, GroupName, 0, ItemID, textBox3.Text, textBox2.Text, System.DateTime.Now.ToString());
            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return;
            }

            main form = (main)this.Owner;
            form.SearchItem();
            this.Close();
        }

        private void KnowledgeItem_Load(object sender, EventArgs e)
        {
            if (alter == true)
            {
                textBox1.Text = GroupName;
                textBox1.ReadOnly = true;
                textBox3.Text = ItemName;

                string sql =string.Format("select ItemSolution from Item where ID='{0}' and GroupID='{1}' and ItemID='{2}'");
                try
                {
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox2.Text=reader.GetString(0);
                    }
                    conn.Close();
                }

                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else if (addNewGroup == true)
            {
                textBox1.Text = GroupName;
                textBox1.ReadOnly = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
