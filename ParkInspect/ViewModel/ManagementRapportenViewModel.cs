using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Factory;
using ParkInspect.Repositories;
using ParkInspect.Repository.Dummy;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
    public class ManagementRapportenViewModel : MainViewModel
    {
        
        private bool _date, _klant, _opdracht, _locatie, _inspecteur, _manager, _functie, _antwoord, _status;
        private string _selectedOption;
        public IDiagram _selectedDiagram;
        private readonly IManagementRapportenRepository _managementRapportenRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IQuestionListRepository _questionListRepository;
        public PieChartViewModel PieChart { get; set; }
        public BarGraphViewModel BarGraph { get; set; }
        public MainViewModel CurrentGraph { get; set; }
        public CustomerViewModel SelectedCustomer { get; set; }
        public EmployeeViewModel SelectedInspector { get; set; }
        public EmployeeViewModel SelectedManager { get; set; }
        public QuestionItemViewModel SelectedQuestion { get; set; }
        public string SelectedFunction { get; set; }
        public string SelectedRegion { get; set; }
        public string SelectedStatus { get; set; }
        public string[] Statuses { get; set; } = new string[] {"Nieuw", "Ingedeeld", "Bezig", "Klaar"};
        public CommissionViewModel SelectedCommission { get; set; }
        public string SelectedAnswer { get; set; }
        public ICommand GenerateDiagramCommand { get; set; }
        private List<string> _comboBox1List;
        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get
            {
                return DateSelected ? _startDate : null;
            }
            set
            {
                _startDate = value;
                RaisePropertyChanged();
            }
        }
        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get
            {
                return DateSelected ? _endDate : null;
            }
            set
            {
                _endDate = value;
                RaisePropertyChanged();
            }
        }
        public bool DateSelected { get; set; }
        public DiagramFactory DiagramFactory { get; set; }
        public ObservableCollection<IDiagram> Diagrams { get; set; }
        public IEnumerable<string> Functions { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public ObservableCollection<CustomerViewModel> Customers { get; set; }
        public ObservableCollection<QuestionItemViewModel> Questions { get; set; }
        public IEnumerable<EmployeeViewModel> Inspectors { get; set; }
        public IEnumerable<EmployeeViewModel> Managers { get; set; }
        
        public ManagementRapportenViewModel(IManagementRapportenRepository repo, ICustomerRepository cust, IRegionRepository region,
            IEmployeeRepository emp, IQuestionListRepository ques)
        {
            _managementRapportenRepository = repo;
            _employeeRepository = emp;
            _customerRepository = cust;
            _questionListRepository = ques;
            _regionRepository = region;
            Inspectors = _employeeRepository.GetByFunction("Inspecteur");
            Managers   = _employeeRepository.GetByFunction("Manager");
            Functions  = _employeeRepository.GetFunctions();
            Customers  = _customerRepository.GetAll();
            Locations  = _regionRepository.GetAll();
            Questions = _questionListRepository.GetAllQuestionItems();

           
            DiagramFactory = new DiagramFactory();
            Diagrams = new ObservableCollection<IDiagram>(DiagramFactory.DiagramNames);

            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            ComboBox1List = new List<string>();
            
        }

        private void GenerateDiagram()
        {
            if (SelectedDiagram.Name.Equals("Cirkeldiagram"))
            {
                if (SelectedOption.Equals("Verdeling van de functies van de werknemers"))
                {
                    PieChart = new PieChartViewModel(new DummyEmployeesRepository(), SelectedRegion);
                    CurrentGraph = PieChart;
                }
                if (SelectedOption.Equals("Verdeling van de status van de opdrachten"))
                {
                    PieChart = new PieChartViewModel(new DummyCommissionRepository(), StartDate, EndDate, SelectedCustomer);
                    CurrentGraph = PieChart;
                }
                if (
                    SelectedOption.Equals(
                        "Verdeling van de verschillende antwoorden dat is gegeven op een specifieke vraag"))
                {
                    PieChart = new PieChartViewModel(new DummyQuestionListRepository(), SelectedCommission, SelectedRegion, StartDate, EndDate, SelectedQuestion);
                    CurrentGraph = PieChart;
                }

            }

            if (SelectedDiagram.Name.Equals("Staafdiagram"))
            {
                if (SelectedOption.Equals("Aantal inspecties per inspecteur"))
                {
                    //insert right constructor
                }

                if (SelectedOption.Equals("Aantal inspecties per klant"))
                {
                    //insert right constructor
                }

                if (SelectedOption.Equals("Aantal opdrachten per manager"))
                {
                    BarGraph = new BarGraphViewModel(new DummyCommissionRepository(), StartDate, EndDate, SelectedStatus, SelectedManager);
                    CurrentGraph = BarGraph;
                }
                if (SelectedOption.Equals("Aantal opdrachten per klant"))
                {
                    BarGraph = new BarGraphViewModel(new DummyCommissionRepository(), StartDate, EndDate, SelectedStatus, SelectedCustomer);
                    CurrentGraph = BarGraph;
                }
            }
            RaisePropertyChanged("CurrentGraph");
        }

        private void SetVisibilities()
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
            if (SelectedOption == null) return;
            foreach (Filter s in SelectedDiagram.Options[SelectedOption])
                switch (s)
                {
                    case Filter.Tijdsperiode:
                        Date = true;
                        break;
                    case Filter.Klant:
                        Klant = true;
                        break;
                    case Filter.Opdracht:
                        Opdracht = true;
                        break;
                    case Filter.Locatie:
                        Locatie = true;
                        break;
                    case Filter.Vraag:
                        Antwoord = true;
                        break;
                    case Filter.Inspecteur:
                        Inspecteur = true;
                        break;
                    case Filter.Manager:
                        Manager = true;
                        break;
                    case Filter.Functie:
                        Functie = true;
                        break;
                    case Filter.Status:
                        Status = true;
                        break;
                }
        }

        // Helper Classes


        public string SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                _selectedOption = value;
                SetVisibilities();
            }
        }

        public bool Date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisePropertyChanged();
            }
        }

        public bool Klant
        {
            get { return _klant; }
            set
            {
                _klant = value;
                RaisePropertyChanged();
            }
        }

        public bool Opdracht
        {
            get { return _opdracht; }
            set
            {
                _opdracht = value;
                RaisePropertyChanged();
            }
        }

        public bool Locatie
        {
            get { return _locatie; }
            set
            {
                _locatie = value;
                RaisePropertyChanged();
            }
        }

        public bool Inspecteur
        {
            get { return _inspecteur; }
            set
            {
                _inspecteur = value;
                RaisePropertyChanged();
            }
        }

        public bool Manager
        {
            get { return _manager; }
            set
            {
                _manager = value;
                RaisePropertyChanged();
            }
        }

        public bool Functie
        {
            get { return _functie; }
            set
            {
                _functie = value;
                RaisePropertyChanged();
            }
        }

        public bool Antwoord
        {
            get { return _antwoord; }
            set
            {
                _antwoord = value;
                RaisePropertyChanged();
            }
        }

        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged();
            }
        }

        public IDiagram SelectedDiagram
        {
            get { return _selectedDiagram; }
            set
            {
                _selectedDiagram = DiagramFactory.GetDiagram(value.Name);
                ComboBox1List = _selectedDiagram.Options.Keys.ToList();
            }
        }

        public List<string> ComboBox1List
        {
            get { return _comboBox1List; }
            set
            {
                _comboBox1List = value;
                RaisePropertyChanged();
            }
        }
    }
}