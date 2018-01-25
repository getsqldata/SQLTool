using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Sql;
using System.IO;
using System.Diagnostics;

namespace SQLTool.Klasy
{
    class Logic
    {
        public string fullPathToBackup;
        public string pathRoot;
        public string fileName;
        #region GetDatabase in selected instance
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
            }
            catch

            {
                MessageBox.Show("UPS - Check server name");
            }
            return dbases;

        }
        #endregion

        #region Logic for quering sql
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
        #endregion

        #region GetInstanceNames in local network
        internal List<string> getInstance()
        {
            List<string> serverInstance = new List<string>();
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable tblServerInstance = instance.GetDataSources();
            List<DataRow> list = tblServerInstance.AsEnumerable().ToList();

            foreach (System.Data.DataRow row in tblServerInstance.Rows)
            {
                foreach (System.Data.DataColumn col in tblServerInstance.Columns )
                {
                    if (col.ColumnName == "ServerName")
                    {
                        serverInstance.Add( row[0] + "\\" + row[1]);
                    }                    
                }

            }

            return serverInstance;

        }
        #endregion

        #region Backup logic and zip implementation
        public void backup()
        {

            try
            {
                SaveFileDialog backupSQL = new SaveFileDialog();
                backupSQL.Filter = "Bak|*.bak";
                backupSQL.Title = "Save copy SQL in:";
                backupSQL.ShowDialog();
                fullPathToBackup = Path.GetFullPath(backupSQL.FileName);
                pathRoot = Path.GetDirectoryName(backupSQL.FileName);
                fileName = Path.GetFileNameWithoutExtension(backupSQL.FileName);
                MessageBox.Show(Path.GetFullPath(backupSQL.FileName));
                string queryBackup = "BACKUP DATABASE " + Form1.usingDatabase + " TO DISK ='" + fullPathToBackup + "'";
                querySQL(queryBackup);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Backup fail");
                throw;
            }
           
        }        
        
        public void CreateZip()
        {
            MessageBox.Show(fullPathToBackup + pathRoot + fileName);      
            string targetName = pathRoot+"\\" + fileName+".gzip";
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = @"C:\Program Files\7-Zip\7zG.exe";
            p.Arguments = "a -tgzip \"" + targetName + "\" \"" + fullPathToBackup + "\" -mx=9";
            //p.WindowStyle = ProcessWindowStyle.Hidden;
            Process x = Process.Start(p);
            x.WaitForExit();
            File.Delete(fullPathToBackup);           
        }
    }
    #endregion
}
