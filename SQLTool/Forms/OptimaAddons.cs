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
                p.StartInfo.FileName = "SQLServerManager10.msc";
                p.Start();
                MessageBox.Show("Pracujesz na wersji SQL 2014");
            }
            catch 
            {

                try
                {
                    var p = new Process();
                    p.StartInfo.FileName = "SQLServerManager12.msc";
                    p.Start();
                    MessageBox.Show("Pracujesz na wersji SQL 2008");

                }
                catch 
                {
                    MessageBox.Show("Pracujesz na wersji nie wiadomo jakiej");
                }                
                throw;
            }           

            
        }
    }
}
