using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Net;
using IniParser;
using IniParser.Model;
using ParkInspect.Helper;

namespace ParkInspect.Service
{
    public class SyncService : ISyncService
    {
        private string _dbPath;
        private string _remoteConnString;
        private string _localConnString;

        public SyncService()
        {
            var parser = new FileIniDataParser();
            IniData data;
            try
            {
                data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini");
            }
            catch (Exception)
            {
                new MetroDialogService().ShowMessage("Fatale fout", "Geen configuratie bestand (config.ini) aanwezig of bestand is corrupt!");
                return;
            }

            _remoteConnString = @"Data Source=avans.database.windows.net;Initial catalog=ParkInspect;Persist security info=True;user Id=beheer;Password=ParkInspect1";
            _localConnString = string.Format(@"Data Source={1}; Initial Catalog={0}; Integrated Security=True", data["Database"]["Name"], data["Database"]["Server"]);
        }

        public SqlCeConnection InitializeDatabase()
        {
            string connectionString = CreateDatabase();
            SqlCeConnection conn = new SqlCeConnection(connectionString);
            conn.Open();

            CreateTable(conn);

            return conn;
        }

        public string GetPath() => _dbPath;

        public string CreateDatabase()
        {
            _dbPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\ParkInspect.sdf";

            if (File.Exists(_dbPath))
                File.Delete(_dbPath);

            string connectionString = $"DataSource=\"{_dbPath}\";Max Database Size=3000;";
            SqlCeEngine en = new SqlCeEngine(connectionString);
            en.CreateDatabase();
            en.Dispose();

            return connectionString;
        }

        public string GetRemoteConnString() => _remoteConnString;

        public string GetLocalConnString() => _localConnString;

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
            //Niet bepaald de mooiste manier :/
            try
            {
                using (var client = new WebClient())
                {
                    client.OpenRead("http://www.google.com");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void WriteFeature(SqlCeConnection conn, int userId, string name, string surname)
        {
            int newid = GetNewId(conn, userId);
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

        private int GetNewId(SqlCeConnection conn, int userId)
        {

            var comm = new SqlCeCommand("SELECT TOP(1) PersonID FROM medewerker WHERE PersonID BETWEEN @a AND @b ORDER BY PersonID DESC", conn);
            comm.Parameters.AddWithValue("@a", $"{userId}00000000");
            comm.Parameters.AddWithValue("@b", $"{userId}99999999");

            SqlCeDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                return Convert.ToInt32(reader["PersonID"]) + 1;
            }
            return userId * 100000000 + 1;
        }
    }
}
