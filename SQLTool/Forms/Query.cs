﻿using System;
using System.Windows.Forms;
using SQLTool.Klasy;

namespace SQLTool
{
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();
            string querySql = richTextBox1.Text;            
            dataGridView1.DataSource = logic.querySQL(querySql);
        }

        private void Query_Load(object sender, EventArgs e)
        {
            button1.Text = button1.Text + " on "  + Form1.usingDatabase;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Query_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
