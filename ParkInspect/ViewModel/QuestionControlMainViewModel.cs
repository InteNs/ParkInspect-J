using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class QuestionControlMainViewModel : MainViewModel
    {
        public QuestionControlMainViewModel(IRouterService router) : base(router)
        {

        }
    }
}
