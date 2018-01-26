using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SQLTool.Forms
{
    public partial class OptimaAddons : Form
    {
        SQLTool.Klasy.Logic logic = new Klasy.Logic();

        public OptimaAddons()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Process();
                p.StartInfo.FileName = "C:\\Windows\\system32\\cliconfg.exe";
                p.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error - File not exists");
                throw;
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                var p = new Process();
                p.StartInfo.FileName = "C:\\Windows\\SysWow64\\cliconfg.exe";
                p.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error - File not exists");
                throw;
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                var p = new Process();
                p.StartInfo.FileName = "SQLServerManager12.msc";
                MessageBox.Show("Pracujesz na wersji SQL 2014");
                p.Start();                
            }
            catch 
            {
                try
                {
                    var p = new Process();
                    p.StartInfo.FileName = "SQLServerManager10.msc";
                    MessageBox.Show("Pracujesz na wersji SQL 2008");
                    p.Start();
                }
                catch 
                {
                    try
                    {
                        var p = new Process();
                        p.StartInfo.FileName = "SQLServerManager14.msc";
                        MessageBox.Show("Pracujesz na wersji SQL 2017");
                        p.Start();
                    }
                    catch 
                    {
                        MessageBox.Show("Pracujesz na wersji SQL nie wiadomo jakiej");
                        throw;
                    }
                }                
                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string test = Form1.usingDatabase;
            if (Form1.connectionString != null)
            {
                DialogResult dr = MessageBox.Show("Are you sure reset admin password for Optima on " + Form1.usingDatabase + " database", "Reset admin password for Optima", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        try
                        {
                            string query = "update cdn.Operatorzy set Ope_Haslo='xMs3s6HjOEg', Ope_HasloChk='Fm'where Ope_Kod='ADMIN'";
                            logic.querySQL(query);
                            MessageBox.Show("Password is empty. Please restart Optima");
                        }
                        catch 
                        {
                            MessageBox.Show("Warning! You must use Optima database configuration.");
                            throw;
                        }
                        
                        break;
                    case DialogResult.No:

                        break;
                }
            }
            else
            {
                MessageBox.Show("You did not select database to use ");
            }

        }
    }
}
