using System.Data.SqlServerCe;

namespace ParkInspect.Service
{
    public interface ISyncService
    {
        SqlCeConnection InitializeDatabase();
        string getPath();
        string CreateDatabase();
        void CreateTable(SqlCeConnection conn);
        bool CheckForInternetConnection();
        string getRemoteConnString();
        string getLocalConnString();
    }
}