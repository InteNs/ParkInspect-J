using Domain.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

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
        public TestViewModel1 tvm1;
        public TestViewModel2 tvm2;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IBaseRepository baseRepository)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            tvm1 = new TestViewModel1(this);
            tvm2 = new TestViewModel2(this);
            CurrentView = tvm1;
            ToggleScreenCommand = new RelayCommand(ToggleScreen);
        }

        public ViewModelBase CurrentView { get; set; }

        public void ToggleScreen()
        {
            if (CurrentView.Equals(tvm1))
            {
                CurrentView = tvm2;
            }
            else
            {
                CurrentView = tvm1;
            }
            RaisePropertyChanged("");
        }
    }
}