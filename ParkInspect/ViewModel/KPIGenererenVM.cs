using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using ParkInspect.DiagramModels;

namespace ParkInspect.ViewModel
{
    public class KPIGenererenVM : ViewModelBase
    {
        public ICommand GenerateDiagramCommand { get; set; }
        public ICommand NavigateBackCommand { get; set; }
        private IDiagram _selectedDiagram;
        public IDiagram SelectedDiagram
        {
            get { return _selectedDiagram; }
            set
            {
                _selectedDiagram = DiagramFactory.GetDiagram(value.Name);
                ComboBox1List = _selectedDiagram.Properties;
            }
        }
        public ObservableCollection<IDiagram> Diagrams { get; set; }
        private List<string> _comboBox1List;

        public List<string> ComboBox1List
        {
            get
            {
                return _comboBox1List;
            }
            set
            {
                _comboBox1List = value;
                RaisePropertyChanged();
            }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DiagramFactory DiagramFactory { get; set; }

        public KPIGenererenVM()
        {
            _selectedDiagram = new Cirkeldiagram();
            DiagramFactory = new DiagramFactory();
            Diagrams = new ObservableCollection<IDiagram>(DiagramFactory.DiagramNames);

            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            NavigateBackCommand = new RelayCommand(NavigateBack);
            ComboBox1List = new List<string>();
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
