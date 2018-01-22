using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Sql;

namespace SQLTool.Klasy
{
    class Logic
    {

        internal List<string> GetDatabase()
        {

            //string nameServer = Form1.nameServer;
            List<string> dbases = new List<string>(); //lists of databases in instance
            //string connectionString = "Data Source=MCEDRO-DELL\\SQLSRV; Integrated Security=True;";
            string connectionString = "Data Source=" + Form1.nameServer + "; Integrated Security=True;";

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
    }
}
