using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ParkInspect.Helper
{
    public class MetroDialogService
    {
        public  bool IsAffirmative { get; private set; }

        private async Task<MessageDialogResult> ShowMessageAsync(string title, string message, MessageDialogStyle style = MessageDialogStyle.AffirmativeAndNegative, MetroDialogSettings settings = null)
        {
            return await ((MetroWindow)(Application.Current.MainWindow)).ShowMessageAsync(title, message, style, settings);
        }

        public async Task Show(string title, string message)
        {
            var res =
                await
                    ShowMessageAsync(title,
                        message);
            IsAffirmative = res == MessageDialogResult.Affirmative;
        }
    }
}
