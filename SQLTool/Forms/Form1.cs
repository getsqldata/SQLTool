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
        public static string userNameSQL;
        public static string passwordSQL;
        public static string connectionString;

        SQLTool.Klasy.Logic logic = new Klasy.Logic();


        public Form1()
        {
            InitializeComponent();
        }       
      

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            visibleAuth = 1;           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (visibleAuth==1)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                visibleAuth = 0;
            }      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nameServer = textBox1.Text;             
            comboBox1.DataSource = logic.GetDatabase();  
            
            if(radioButton2.Checked)
            {
                userNameSQL = textBox2.Text;
                passwordSQL = textBox3.Text;
                connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";User Id=" + userNameSQL + ";Password=" + passwordSQL +";Asynchronous Processing=true;";
                //MessageBox.Show("testmesedżboxa");

            } else
            {
                connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";Trusted_Connection=True;";

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
