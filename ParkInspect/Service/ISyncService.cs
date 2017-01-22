using System.Data.SqlServerCe;

namespace ParkInspect.Service
{
    public interface ISyncService
    {
        SqlCeConnection InitializeDatabase();
        string GetPath();
        string CreateDatabase();
        void CreateTable(SqlCeConnection conn);
        bool CheckForInternetConnection();
        string GetRemoteConnString();
        string GetLocalConnString();
    }
}