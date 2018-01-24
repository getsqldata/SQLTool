using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            p.StartInfo.FileName = "C:\\Windows\\system32\\cliconfg.exe";  // just for example, you can use yours.
            p.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
