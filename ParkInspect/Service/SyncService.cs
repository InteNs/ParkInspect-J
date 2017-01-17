using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IniParser;
using IniParser.Model;
using ParkInspect.Helper;

namespace ParkInspect.Service
{
    class SyncService : ISyncService
    {
        private string dbPath;
        private string remoteConnString;
        private string localConnString;

        public SyncService()
        {
            var parser = new FileIniDataParser();
            IniData data = new IniData();
            try
            {
                data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini");
            }
            catch (Exception)
            {
                new MetroDialogService().ShowMessage("Geen configuratie bestand (config.ini) aanwezig of bestand is corrupt!", "Fatale fout");
                return;
            }
            
            remoteConnString = @"Data Source=avans.database.windows.net;Initial catalog=ParkInspect;Persist security info=True;user Id=beheer;Password=ParkInspect1";
            localConnString = String.Format(@"Data Source={1}; Initial Catalog={0}; Integrated Security=True",data["Database"]["Name"], data["Database"]["Server"]);
        }

        public SqlCeConnection InitializeDatabase()
        {
            string connectionString = CreateDatabase();
            SqlCeConnection conn = new SqlCeConnection(connectionString);
            conn.Open();

            CreateTable(conn);

            return conn;
        }

        public string getPath()
        {
            return dbPath;
        }

        public string CreateDatabase()
        {
            dbPath = String.Format("{0}\\ParkInspect.sdf", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            if (File.Exists(dbPath))
                File.Delete(dbPath);

            string connectionString = String.Format("DataSource=\"{0}\";Max Database Size=3000;", dbPath);
            SqlCeEngine en = new SqlCeEngine(connectionString);
            en.CreateDatabase();
            en.Dispose();

            return connectionString;
        }

        public string getRemoteConnString()
        {
            return remoteConnString;
        }

        public string getLocalConnString()
        {
            return localConnString;
        }

        public void CreateTable(SqlCeConnection conn)
        {
            using (SqlCeCommand comm = new SqlCeCommand())
            {
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "CREATE TABLE Inspection( Id INT primary key,Guid uniqueidentifier NOT NULL, CommissionId int NOT NULL,CommissionGuid uniqueidentifier NOT NULL, DateTimeStart datetime NOT NULL, DateTimeEnd datetime, DateCancelled datetime)";
                comm.ExecuteNonQuery();
            }
        }

        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public void WriteFeature(SqlCeConnection conn, int userID ,string name, string surname)
        {
            int newid = getNewID(conn, userID);
            using (SqlCeCommand comm = new SqlCeCommand())
            {
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO medewerker (globalID,PersonID, [LastName], [FirstName])  VALUES (NEWID(), @a ,@b, @c)";
                comm.Parameters.AddWithValue("@a", newid);
                comm.Parameters.AddWithValue("@b", name);
                comm.Parameters.AddWithValue("@c", surname);
                comm.ExecuteNonQuery();
            }
        }

        private int getNewID(SqlCeConnection conn, int userID)
        {
            
            var comm = new SqlCeCommand("SELECT TOP(1) PersonID FROM medewerker WHERE PersonID BETWEEN @a AND @b ORDER BY PersonID DESC", conn);
            comm.Parameters.AddWithValue("@a", String.Format("{0}00000000", userID));
            comm.Parameters.AddWithValue("@b", String.Format("{0}99999999", userID));

            SqlCeDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                    return Convert.ToInt32(reader["PersonID"])+1;
            }
            return  (userID * 100000000) + 1; ;
                
        }
    }
}
