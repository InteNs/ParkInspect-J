using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ParkInspect.Helper
{
    public class MetroDialogService
    {
        public bool IsAffirmative { get; private set; }

        private async Task<MessageDialogResult> ShowMessageAsync(string title, string message, MessageDialogStyle style, MetroDialogSettings settings)
        {
            return await ((MetroWindow)(Application.Current.MainWindow)).ShowMessageAsync(title, message, style, settings);
        }

        public async Task ShowConfirmative(string title, string message)
        {
            MessageDialogStyle style = MessageDialogStyle.AffirmativeAndNegative;
            MetroDialogSettings settings = null;

            var res =
                await
                    ShowMessageAsync(title,
                        message, style, settings);
            IsAffirmative = res == MessageDialogResult.Affirmative;
        }

        public async void ShowMessage(string title, string message)
        {
            MessageDialogStyle style = MessageDialogStyle.Affirmative;
            MetroDialogSettings settings = null;

            var res =
                await
                    ShowMessageAsync(title,
                        message, style, settings);
            IsAffirmative = res == MessageDialogResult.Affirmative;
        }
    }
}
