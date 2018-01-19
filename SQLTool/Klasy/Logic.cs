using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using System.Data.Sql;

namespace SQLTool.Klasy
{
    public class Logic
    {
        //SQLTool.Form1 FormOne = new Form1();

        

        

        public void ConnectToSQL()
        {

            Form1 form = new Form1();

            Server MyServer = new Server();
            MessageBox.Show(MyServer.Name);
            DatabaseCollection db = MyServer.Databases;
            for( int i = 0; i < db.Count;i++)
            {
                form.comboBox1.Items.Add(db[i].Name);
            }
            MessageBox.Show(MyServer.Name);
            

        }



    }
}
