using System;
using System.Data;
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
            string connectionString = "Data Source=" + Form1.nameServer + "; Integrated Security=True;Connection Timeout=5";

            try
            {

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
            } catch

            {
                MessageBox.Show("UPS - Check server name");
            }
            return dbases;

        }       

        public DataTable querySQL(string sql)

        {
            DataTable querySQL = new DataTable();

            //string connStringErp = "Data Source=" + Form1.nameServer + "; Integrated Security=True;";
            string connStringErp = Form1.connectionString;
            using (SqlConnection conErp = new SqlConnection(connStringErp))
            {
                
                using (SqlCommand cmdErp = new SqlCommand(sql, conErp))
                {
                    conErp.Open();

                    SqlDataReader readerErp = cmdErp.ExecuteReader();

                    querySQL.Load(readerErp);                    
                }
            }
            
            return querySQL;
        }



    }
}
