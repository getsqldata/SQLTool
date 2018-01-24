using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SQLTool
{
    public partial class Form1 : Form
    {

        static int visibleAuth; //check radiobutton
        public static string nameServer;
        public static string userNameSQL;
        public static string passwordSQL;
        public static string connectionString;
        public static string usingDatabase;

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
            nameServer = comboBox2.Text;             
            comboBox1.DataSource = logic.GetDatabase();
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (radioButton2.Checked)
            {
                userNameSQL = textBox2.Text;
                passwordSQL = textBox3.Text;
                connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";User Id=" + userNameSQL + ";Password=" + passwordSQL + "; Connection Timeout = 30";
                MessageBox.Show(connectionString);

            }
            else
            {
                connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";Integrated Security=True;";
                MessageBox.Show(connectionString);
            }

            usingDatabase = comboBox1.Text;
            Query QueryForm = new Query();
            QueryForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.DataSource = logic.getInstance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                userNameSQL = textBox2.Text;
                passwordSQL = textBox3.Text;
                connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";User Id=" + userNameSQL + ";Password=" + passwordSQL + "; Connection Timeout = 30";
                MessageBox.Show(connectionString);

            }
            else
            {
                connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";Integrated Security=True;";
                MessageBox.Show(connectionString);
            }

            usingDatabase = comboBox1.Text;
            logic.backup();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            SQLTool.Forms.OptimaAddons optimaAddons = new Forms.OptimaAddons();
            optimaAddons.Show();
          



        }
    }
}
