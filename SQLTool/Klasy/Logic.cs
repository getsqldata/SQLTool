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

        internal List<string> GetDatabase()
        {
            SQLTool.Form1 FormOne = new Form1();
            List<string> dbases = new List<string>(); //lists of databases in instance
            string connectionString = "Data Source=MCEDRO-DELL\\SQLSRV; Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (SqlDataReader db = cmd.ExecuteReader())
                    {
                        while (db.Read())
                        {
                            dbases.Add(db[0].ToString());
                            //MessageBox.Show(db[0].ToString());
                        }
                        db.Close();
                    }
                }

            }
            return dbases;

        }


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
