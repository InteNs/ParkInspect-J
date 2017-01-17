using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Service;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization;

namespace ParkInspect.ViewModel
{
    public class SyncViewModel : MainViewModel
    {
        private readonly ISyncService _syncService;
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
                try
                {

                    // _syncService.InitializeDatabase();

                    ProvisionServer();
                    ProvisionClient();

                    // create a connection to the SyncCompactDB database
                    var clientConn = new SqlConnection(_syncService.getLocalConnString());

                    // create a connection to the SyncDB server database
                    var serverConn = new SqlConnection(_syncService.getRemoteConnString());

                    // create the sync orhcestrator
                    var syncOrchestrator = new SyncOrchestrator
                    {
                        // set local provider of orchestrator to a CE sync provider associated with the 
                        // ProductsScope in the SyncCompactDB compact client database
                        LocalProvider = new SqlSyncProvider("ParkInspectScope", clientConn),
                        // set the remote provider of orchestrator to a server sync provider associated with
                        // the ProductsScope in the SyncDB server database
                        RemoteProvider = new SqlSyncProvider("ParkInspectScope", serverConn),
                        // set the direction of sync session to Upload and Download
                        Direction = SyncDirectionOrder.UploadAndDownload
                    };

                    // subscribe for errors that occur when applying changes to the client
                    ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += Program_ApplyChangeFailed;

                    // execute the synchronization process
                    syncOrchestrator.Synchronize();

                    MessageBox.Show("Synchronisatie voltooid!");
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Er is een fout opgetreden in de sync configuratie! Neem contact op met uw systeembeheerder.",
                        "Fatale fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("U dient met internet verbonden te zijn om te synchroniseren.");
            }
        }

        private static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            // display conflict type
            MessageBox.Show(e.Conflict.Type.ToString());

            // display error message 
            MessageBox.Show(e.Error.Message);
        }

        private void ProvisionServer()
        {
            var serverConn = new SqlConnection(_syncService.getRemoteConnString());

            // define a new scope named ParkInspectScope
            var scopeDesc = new DbSyncScopeDescription("ParkInspectScope");

            //DB Tables!
            var tables = new[]
            {
                "Inspection", "Answer", "Commission", "Customer", "Employee", "Function", "Location", "Person",
                "Question", "QuestionItem", "QuestionList","QuestionType", "Region", "Workday"
            };
            foreach (var name in tables)
            {
                // get the description of the Products table from SyncDB dtabase
                var tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(name, serverConn);

                // add the table description to the sync scope definition
                scopeDesc.Tables.Add(tableDesc);
            }



            // create a server scope provisioning object based on the ProductScope
            var serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

            // skipping the creation of table since table already exists on server
            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

            // start the provisioning process
            if (!serverProvision.ScopeExists("ParkInspectScope"))
                serverProvision.Apply();
        }

        private void ProvisionClient()
        {
            // create a connection to the SyncCompactDB database
            var clientConn = new SqlConnection(_syncService.getLocalConnString());

            // create a connection to the SyncDB server database
            var serverConn = new SqlConnection(_syncService.getRemoteConnString());

            // get the description of ProductsScope from the SyncDB server database
            var scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("ParkInspectScope", serverConn);

            // create CE provisioning object based on the ProductsScope
            var clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);
            // starts the provisioning process
            if (!clientProvision.ScopeExists("ParkInspectScope"))
                clientProvision.Apply();

        }

    }
}