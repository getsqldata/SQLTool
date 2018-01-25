using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLTool.Klasy;

namespace SQLTool
{
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();
            string querySql = richTextBox1.Text;            
            dataGridView1.DataSource = logic.querySQL(querySql);
        }

        private void Query_Load(object sender, EventArgs e)
        {
            button1.Text = button1.Text + " on "  + Form1.usingDatabase;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
