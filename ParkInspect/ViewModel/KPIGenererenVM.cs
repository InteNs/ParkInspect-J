using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class KPIGenererenVM
    {
        public ICommand GenerateDiagramCommand { get; set; }
        public ICommand NavigateBackCommand { get; set; }

        public KPIGenererenVM()
        {
            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            NavigateBackCommand = new RelayCommand(NavigateBack);
        }

        private void NavigateBack()
        {
            throw new NotImplementedException();
        }

        private void GenerateDiagram()
        {
            throw new NotImplementedException();
        }
    }
}
