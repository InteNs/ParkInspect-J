using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ParkInspect.ViewModel;

namespace ParkInspect.View
{
    /// <summary>
    /// Interaction logic for ManagementView.xaml
    /// </summary>
    public partial class ManagementView : UserControl
    {
        public ManagementView()
        {
            InitializeComponent();
        }
        private void ComboBox_OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ComboBox db = (ComboBox)sender;
            db.SelectedIndex = -1;
        }

        private void TextBox_OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = null;
        }
    }
}
