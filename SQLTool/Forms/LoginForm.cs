using System;
using System.Windows.Forms;

namespace SQLTool.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        void loginToProgram()
        {
            string user = "admin";
            string pass = "";
            if (textBox1.Text == user && textBox2.Text == pass)
            {
                //MessageBox.Show("Login Successful!");
                progressBar1.Visible = true;
                int i;
                for (i = 0; i < 100; i++)
                {
                    progressBar1.Increment(i);
                    System.Threading.Thread.Sleep(5);
                }
                this.Hide();
                Form1 programform = new Form1();
                programform.Show();               
            }
            else
            {
                MessageBox.Show("Username and password is incorrect \nTry again or leave!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginToProgram();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginToProgram();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginToProgram();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginToProgram();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginToProgram();
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
