﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLTool
{
    public partial class Form1 : Form
    {

        static int visibleAuth; //check radiobutton
        public static string nameServer;
        public static string userName;
        public static string passwordSQL;
        public static string connectionString;

        SQLTool.Klasy.Logic logic = new Klasy.Logic();


        public Form1()
        {
            InitializeComponent();
        }       
      

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            visibleAuth = 1;           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (visibleAuth==1)
            {
                label2.Visible = false;
                label3.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                visibleAuth = 0;
            }      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nameServer = textBox1.Text;             
            comboBox1.DataSource = logic.GetDatabase();  
            
            if(radioButton2.Checked)
            {

                MessageBox.Show("testmesedżboxa");

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query QueryForm = new Query();
            QueryForm.Show();
        }
    }
}
