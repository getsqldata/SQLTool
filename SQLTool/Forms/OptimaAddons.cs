using System;
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
            logic.RunCliconfg_x86();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logic.RunCliconfg_x64();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logic.LunchSqlConfigurationManager();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            logic.ResetPassOptima();   
        }

        private void OptimaAddons_Load(object sender, EventArgs e)
        {

        }
    }
}
