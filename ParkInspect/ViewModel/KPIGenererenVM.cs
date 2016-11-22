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
        private string _selectedOption;

        public string SelectedOption
        {
            get
            {
                return _selectedOption;
            }
            set
            {
                _selectedOption = value;
                SetVisibilitys();
            }
        }
        public ICommand GenerateDiagramCommand { get; set; }
        public ICommand NavigateBackCommand { get; set; }
        private bool _date;

        public bool Date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisePropertyChanged();
            }
        }

        private bool _klant;

        public bool Klant
        {
            get { return _klant; }
            set
            {
                _klant = value;
                RaisePropertyChanged();
            }
        }

        private bool _opdracht;

        public bool Opdracht
        {
            get { return _opdracht; }
            set
            {
                _opdracht = value;
                RaisePropertyChanged();
            }
        }

        private bool _locatie;

        public bool Locatie
        {
            get { return _locatie; }
            set
            {
                _locatie = value;
                RaisePropertyChanged();
            }
        }

        private bool _inspecteur;

        public bool Inspecteur
        {
            get { return _inspecteur; }
            set
            {
                _inspecteur = value;
                RaisePropertyChanged();
            }
        }
        private bool _manager;

        public bool Manager
        {
            get { return _manager; }
            set
            {
                _manager = value;
                RaisePropertyChanged();
            }
        }
        private bool _functie;

        public bool Functie
        {
            get { return _functie; }
            set
            {
                _functie = value;
                RaisePropertyChanged();
            }
        }

        private bool _antwoord;
        public bool Antwoord
        {
            get { return _antwoord; }
            set
            {
                _antwoord = value;
                RaisePropertyChanged();
            }
        }
        private bool _status;
        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged();
            }
        }

        private IDiagram _selectedDiagram;
        public IDiagram SelectedDiagram
        {
            get { return _selectedDiagram; }
            set
            {
                _selectedDiagram = DiagramFactory.GetDiagram(value.Name);
                ComboBox1List = _selectedDiagram.Options.Keys.ToList();
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
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
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

        private void SetVisibilitys()
        {
            Date = false;
            Klant = false;
            Opdracht = false;
            Locatie = false;
            Inspecteur = false;
            Manager = false;
            Functie = false;
            Antwoord = false;
            Status = false;
            if (SelectedOption != null)
            {
                foreach (string s in SelectedDiagram.Options[SelectedOption])
                {
                    switch (s)
                    {
                        case "tijdsperiode":
                            Date = true;
                            break;
                        case "klant":
                            Klant = true;
                            break;
                        case "opdracht":
                            Opdracht = true;
                            break;
                        case "locatie":
                            Locatie = true;
                            break;
                        case "antwoord":
                            Antwoord = true;
                            break;
                        case "inspecteur":
                            Inspecteur = true;
                            break;
                        case "manager":
                            Manager = true;
                            break;
                        case "functie":
                            Functie = true;
                            break;
                        case "status":
                            Status = true;
                            break;
                    }
                }
            }
        }

        
    }
}
