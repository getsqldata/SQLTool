using System;
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
        public static int Err;

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

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.DataSource = logic.getInstance();
        }

        private void getConnectionString()
        {
            if (radioButton2.Checked)
            {
                
                if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Fill username and password !");
                    Err = 1;
                }
                else
                {
                    userNameSQL = textBox2.Text;
                    passwordSQL = textBox3.Text;
                    connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";User Id=" + userNameSQL + ";Password=" + passwordSQL + "; Connection Timeout = 30";
                    MessageBox.Show(connectionString);
                    usingDatabase = comboBox1.Text;
                    Err = 0;
                }
                
            }
            else
            {
                connectionString = "Data Source=" + Form1.nameServer + "; Initial Catalog=" + comboBox1.Text + ";Integrated Security=True;";
                MessageBox.Show(connectionString);
                usingDatabase = comboBox1.Text;
                Err = 0;
            }            
        }


        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Do you want compress bak file after create?", " Compress backup? ",  MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.No:
                  
                    logic.backup();                    
                    break;

                case DialogResult.Yes:
                    logic.backup();
                    logic.CreateZip();
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLTool.Forms.OptimaAddons optimaAddons = new Forms.OptimaAddons();
            optimaAddons.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            getConnectionString();

            if (Err == 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Connection string is wrong");
            }
            
        }
    }
}
