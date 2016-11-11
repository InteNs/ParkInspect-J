using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public ICommand ToggleScreenCommand { get; set; }
        public TestViewModel1 tvm1 { get; set; }
        public TestViewModel2 tvm2 { get; set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            tvm1 = new TestViewModel1(this, new DummyTestItemRepository());
            tvm2 = new TestViewModel2(this);
            CurrentView = tvm1;
            ToggleScreenCommand = new RelayCommand<ViewModelBase>(ToggleScreen);
        }

        public ViewModelBase CurrentView { get; set; }

        public void ToggleScreen(ViewModelBase vmb)
        {
            CurrentView = vmb;
            RaisePropertyChanged("");
        }
    }
}