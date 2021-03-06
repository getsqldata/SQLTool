﻿using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Sql;
using System.IO;
using System.Diagnostics;
using System;

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
            List<string> dbases = new List<string>(); //lists of databases in instance
            //string connectionString = "Data Source=MCEDRO-DELL\\SQLSRV; Integrated Security=True;";
            //string connectionString = "Data Source=" + Form1.nameServer + "; Integrated Security=True;Connection Timeout=5;";

            try
            {
                using (SqlConnection con = new SqlConnection(Form1.connectionStringDB))
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
            try
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
            catch (System.Exception)
            {
                MessageBox.Show("Error!!");
                throw;
            }         
        }
        #endregion

        #region GetInstanceNames in local network
        internal List<string> getInstance()
        {

            try
            {
                List<string> serverInstance = new List<string>();
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable tblServerInstance = instance.GetDataSources();
                List<DataRow> list = tblServerInstance.AsEnumerable().ToList();

                foreach (System.Data.DataRow row in tblServerInstance.Rows)
                {
                    foreach (System.Data.DataColumn col in tblServerInstance.Columns)
                    {
                        if (col.ColumnName == "ServerName")
                        {
                            serverInstance.Add(row[0] + "\\" + row[1]);
                        }
                    }
                }

                return serverInstance;
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error");
                throw;
            }           
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
                //MessageBox.Show(Path.GetFullPath(backupSQL.FileName));
                //MessageBox.Show(Directory.GetCurrentDirectory());
                string queryBackup = "BACKUP DATABASE " + Form1.usingDatabase + " TO DISK ='" + fullPathToBackup + "'";
                querySQL(queryBackup);
            }
            catch 
            {
                MessageBox.Show("Backup fail");
            }           
        }        
        
        public void CreateZip()
        {
            MessageBox.Show(fullPathToBackup + pathRoot + fileName);      
            string targetName = pathRoot+"\\" + fileName+".gzip";
            ProcessStartInfo p = new ProcessStartInfo();
            if (File.Exists(@"C:\Program Files\7-Zip\7zG.exe") == true) 
            {
                p.FileName = @"C:\Program Files\7-Zip\7zG.exe";
            }
            else
            {
                p.FileName = Directory.GetCurrentDirectory() + "\\7za.exe";
            }
            p.Arguments = "a -tgzip \"" + targetName + "\" \"" + fullPathToBackup + "\" -mx=9";
            //p.WindowStyle = ProcessWindowStyle.Hidden;
            Process x = Process.Start(p);
            x.WaitForExit();
            File.Delete(fullPathToBackup);
            MessageBox.Show("Backup done");
        }

        #endregion

        #region Reset admin password for Comarch Optima
        public void ResetPassOptima()
        {
            string test = Form1.usingDatabase;
            if (Form1.connectionString != null)
            {
                DialogResult dr = MessageBox.Show("Are you sure reset admin password for Optima on " + Form1.usingDatabase + " database", "Reset admin password for Optima", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        try
                        {
                            string query = "update cdn.Operatorzy set Ope_Haslo='xMs3s6HjOEg', Ope_HasloChk='Fm'where Ope_Kod='ADMIN'";
                            querySQL(query);
                            MessageBox.Show("Password is empty. Please restart Optima");
                        }
                        catch
                        {
                            MessageBox.Show("Warning! You must use Optima database configuration.");
                            throw;
                        }

                        break;
                    case DialogResult.No:

                        break;
                }
            }
            else
            {
                MessageBox.Show("You did not select database to use ");
            }
        }
        #endregion

        #region Lunch cliconfg x86
        public void RunCliconfg_x86()
        {
            try
            {
                var p = new Process();
                p.StartInfo.FileName = "C:\\Windows\\system32\\cliconfg.exe";
                p.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error - File not exists");
                throw;
            }
        }
        #endregion

        #region Lunch cliconfg x64
        public void RunCliconfg_x64()
        {
            try
            {
                var p = new Process();
                p.StartInfo.FileName = "C:\\Windows\\SysWow64\\cliconfg.exe";
                p.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error - File not exists");
                throw;
            }
        }
        #endregion

        #region Run SQL Server Configuration Manager
        public void LunchSqlConfigurationManager()
        {

            int ver = 0; // wersja sql
            var p = new Process();
            try
            {
                p.StartInfo.FileName = "SQLServerManager12.msc";
                ver = 12;
                p.Start();
            }
            catch
            {
                try
                {
                    p.StartInfo.FileName = "SQLServerManager10.msc";
                    ver = 10;                    
                    p.Start();
                }
                catch
                {
                    try
                    {
                        p.StartInfo.FileName = "SQLServerManager14.msc";
                        ver = 14;
                        p.Start();
                    }
                    catch
                    {
                        try
                        {                          
                            p.StartInfo.FileName = "SQLServerManager11.msc";
                            ver = 11;
                            p.Start();
                        }
                        catch
                        {
                            try
                            {
                                p.StartInfo.FileName = "SQLServerManager13.msc";
                                ver = 11;
                                p.Start();
                            }
                            catch
                            {
                                //MessageBox.Show("Pracujesz na wersji SQL nie wiadomo jakiej lub nie masz zainstalowanego serwera MS SQL");
                            }
                        }
                    }
                }

            }
           // /*
            switch (ver)
            {
                case 10:
                    MessageBox.Show("Pracujesz na wersji SQL 2008");
                    break;
                case 11:
                    MessageBox.Show("Pracujesz na wersji SQL 2012");
                    break;
                case 12:
                    MessageBox.Show("Pracujesz na wersji SQL 2014");
                    break;
                case 13:
                    MessageBox.Show("Pracujesz na wersji SQL 2016");
                    break;
                case 14:
                    MessageBox.Show("Pracujesz na wersji SQL 2017");
                    break;
                default:
                    MessageBox.Show("Pracujesz na wersji SQL 2017");
                    break;


            }

         //    */
        }
        #endregion
        
    }
}
