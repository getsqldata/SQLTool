using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var p = new Process();
            p.StartInfo.FileName = "C:\\Windows\\system32\\cliconfg.exe";  
            p.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var p = new Process();
            p.StartInfo.FileName = "C:\\Windows\\SysWow64\\cliconfg.exe"; 
            p.Start();
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
                    MessageBox.Show("Pracujesz na wersji SQL nie wiadomo jakiej");
                }                
                throw;
            }           

            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult dr =  MessageBox.Show("Are you sure", "Reset admin password for Optima", MessageBoxButtons.YesNo);
            switch(dr)
            {
                case DialogResult.Yes:
                    string query = "update cdn.Operatorzy set Ope_Haslo='xMs3s6HjOEg', Ope_HasloChk='Fm'where Ope_Kod='ADMIN'";
                    logic.querySQL(query);
                    break;
                case DialogResult.No:

                    break;              

            }
         

        }
    }
}
