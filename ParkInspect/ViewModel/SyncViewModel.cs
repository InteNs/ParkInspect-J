using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Service;

using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data.SqlServerCe;
using Microsoft.Synchronization;

namespace ParkInspect.ViewModel
{
    public class SyncViewModel:MainViewModel
    {
        private ISyncService _syncService;
        public ICommand DoSyncCommand { get; set; }

        public SyncViewModel(ISyncService syncService)
        {
            _syncService = syncService;
            DoSyncCommand = new RelayCommand(Sync);
        }

        private void Sync()
        {
            if (_syncService.CheckForInternetConnection())
            {
                ProvisionServer();
                ProvisionClient();

                // create a connection to the SyncCompactDB database
                SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='" + _syncService.getPath() + "'");

                // create a connection to the SyncDB server database
                SqlConnection serverConn = new SqlConnection(@"data source=avans.database.windows.net;initial catalog=ParkInspect;persist security info=True;user id=beheer;password=ParkInspect1;MultipleActiveResultSets=True;");

                // create the sync orhcestrator
                Microsoft.Synchronization.SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

                // set local provider of orchestrator to a CE sync provider associated with the 
                // ProductsScope in the SyncCompactDB compact client database
                syncOrchestrator.LocalProvider = new SqlCeSyncProvider("ParkInspectScope", clientConn);

                // set the remote provider of orchestrator to a server sync provider associated with
                // the ProductsScope in the SyncDB server database
                syncOrchestrator.RemoteProvider = new SqlSyncProvider("ParkInspectScope", serverConn);

                // set the direction of sync session to Upload and Download
                syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;

                // subscribe for errors that occur when applying changes to the client
                ((SqlCeSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);

                // execute the synchronization process
                SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

                MessageBox.Show("Synchronisatie voltooid!");


            }
            else
            {
                MessageBox.Show("U dient met internet verbonden te zijn om te synchroniseren.");
            }
        }

        static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            // display conflict type
            MessageBox.Show(e.Conflict.Type.ToString());

            // display error message 
            MessageBox.Show(e.Error.Message);
        }

        private void ProvisionServer()
        {
            SqlConnection serverConn = new SqlConnection(@"data source=avans.database.windows.net;initial catalog=ParkInspect;persist security info=True;user id=beheer;password=ParkInspect1;MultipleActiveResultSets=True;");

            // define a new scope named ProductsScope
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("ParkInspectScope");

            // get the description of the Products table from SyncDB dtabase
            DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable("medewerker", serverConn);

            // add the table description to the sync scope definition
            scopeDesc.Tables.Add(tableDesc);

            // create a server scope provisioning object based on the ProductScope
            SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

            // skipping the creation of table since table already exists on server
            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

            // start the provisioning process
            if (!serverProvision.ScopeExists("ParkInspectScope"))
                serverProvision.Apply();
        }

        private void ProvisionClient()
        {
            // create a connection to the SyncCompactDB database
            SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='" + _syncService.getPath() + "'");

            // create a connection to the SyncDB server database
            SqlConnection serverConn = new SqlConnection(@"data source=avans.database.windows.net;initial catalog=ParkInspect;persist security info=True;user id=beheer;password=ParkInspect1;MultipleActiveResultSets=True;");

            // get the description of ProductsScope from the SyncDB server database
            DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("ParkInspectScope", serverConn);

            // create CE provisioning object based on the ProductsScope
            SqlCeSyncScopeProvisioning clientProvision = new SqlCeSyncScopeProvisioning(clientConn, scopeDesc);
            // starts the provisioning process
            if (!clientProvision.ScopeExists("ParkInspectScope"))
                clientProvision.Apply();

        }

    }
}
