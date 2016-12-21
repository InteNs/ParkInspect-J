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
        private DateTime? _endDate;
        private IGraphViewModel _currentGraph;
        private IDiagram _selectedDiagram;
        private readonly ICommissionRepository _commissionRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IQuestionListRepository _questionListRepository;
        private readonly IInspectionsRepository _inspectionRepository;

        public PieChartViewModel PieChart { get; set; }
        public BarGraphViewModel BarGraph { get; set; }
        public LineChartViewModel LineChart { get; set; }

        public IGraphViewModel CurrentGraph
        {
            get { return _currentGraph; }
            set { _currentGraph = value; RaisePropertyChanged(); }
        }

        public CustomerViewModel SelectedCustomer { get; set; }
        public EmployeeViewModel SelectedInspector { get; set; }
        public EmployeeViewModel SelectedManager { get; set; }
        public QuestionItemViewModel SelectedQuestion { get; set; }
        public string SelectedFunction { get; set; }
        public string SelectedRegion { get; set; }
        public string SelectedStatus { get; set; }
        public ObservableCollection<string> Statuses { get; set; }
        public CommissionViewModel SelectedCommission { get; set; }
        public string SelectedAnswer { get; set; }
        public ICommand GenerateDiagramCommand { get; set; }

        private List<string> _options;

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
        public ObservableCollection<CommissionViewModel> Commissions { get; set; }
        public ObservableCollection<InspectionViewModel> Inspections { get; set; }
        public ObservableCollection<QuestionItemViewModel> Questions { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }
        public IEnumerable<EmployeeViewModel> Managers => Employees.Where(e => e.Function.Equals("Manager"));
        public IEnumerable<EmployeeViewModel> Inspectors => Employees.Where(e => e.Function.Equals("Inspecteur"));

        public ManagementRapportenViewModel(ICommissionRepository repo, ICustomerRepository cust, IRegionRepository region,
            IEmployeeRepository emp, IQuestionListRepository ques, IInspectionsRepository insp)
        {
            _inspectionRepository = insp;
            _commissionRepository = repo;
            _employeeRepository = emp;
            _customerRepository = cust;
            _questionListRepository = ques;
            _regionRepository = region;
            Employees = _employeeRepository.GetAll();
            Functions  = _employeeRepository.GetFunctions();
            Commissions = _commissionRepository.GetAll();
            Customers  = _customerRepository.GetAll();
            Locations  = _regionRepository.GetAll();
            Questions = _questionListRepository.GetAllQuestionItems();
            Statuses = _commissionRepository.GetStatuses();
            Inspections = _inspectionRepository.GetAll();

           
            DiagramFactory = new DiagramFactory();
            Diagrams = new ObservableCollection<IDiagram>(DiagramFactory.DiagramNames);

            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            Options = new List<string>();
            
        }

        private void GenerateDiagram()
        {
            if(SelectedOption == null || SelectedDiagram == null) return;

            if (SelectedDiagram.Name.Equals("Cirkeldiagram"))
            {
                if (SelectedOption.Equals("Verdeling van de functies van de werknemers"))
                {
                    PieChart = new PieChartViewModel(Employees, Functions, SelectedRegion);
                    CurrentGraph = PieChart;
                }
                if (SelectedOption.Equals("Verdeling van de status van de opdrachten"))
                {
                    PieChart = new PieChartViewModel(Commissions, _commissionRepository.GetStatuses(), StartDate, EndDate, SelectedCustomer);
                    CurrentGraph = PieChart;
                }
                if (
                    SelectedOption.Equals(
                        "Verdeling van de verschillende antwoorden dat is gegeven op een specifieke vraag"))
                {
                    PieChart = new PieChartViewModel(Questions, Commissions, SelectedCommission, SelectedRegion, StartDate, EndDate, SelectedQuestion);
                    CurrentGraph = PieChart;
                }

            }

            if (SelectedDiagram.Name.Equals("Staafdiagram"))
            {
                if (SelectedOption.Equals("Aantal inspecties per inspecteur"))
                {
                    BarGraph = new BarGraphViewModel(Inspections, Commissions, Customers, Employees, StartDate, EndDate, SelectedQuestion, SelectedCommission, SelectedCustomer, "inspecteur");
                    CurrentGraph = BarGraph;
                }

                else if (SelectedOption.Equals("Aantal inspecties per klant"))
                {
                    BarGraph = new BarGraphViewModel(Inspections, Commissions, Customers, Employees, StartDate, EndDate, SelectedQuestion, SelectedCommission, SelectedCustomer, "klant");
                    CurrentGraph = BarGraph;
                }

                else if (SelectedOption.Equals("Aantal opdrachten per inspecteur"))
                {
                    BarGraph = new BarGraphViewModel(Commissions, Inspectors, StartDate, EndDate, SelectedStatus, SelectedCustomer);
                    CurrentGraph = BarGraph;
                }
                else if (SelectedOption.Equals("Aantal opdrachten per klant"))
                {
                    BarGraph = new BarGraphViewModel(Commissions, Customers, StartDate, EndDate, SelectedStatus, SelectedCustomer);
                    CurrentGraph = BarGraph;
                }
            }

            
                if (SelectedDiagram.Name.Equals("Lijndiagram"))
                {
                    if (SelectedOption.Equals("Aantal inspecties die zijn uitgevoerd per dag"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal inspecties die zijn uitgevoerd per week"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal inspecties die zijn uitgevoerd per maand"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal inspecties die zijn uitgevoerd per jaar"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal opdrachten die zijn aangemaakt/afgerond per week"))
                    {
                        LineChart = new LineChartViewModel(Commissions, StartDate, EndDate, SelectedCustomer, "week");
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal opdrachten die zijn aangemaakt/afgerond per maand"))
                    {
                    LineChart = new LineChartViewModel(Commissions, StartDate, EndDate, SelectedCustomer, "maand");
                    CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal opdrachten die zijn aangemaakt/afgerond per jaar"))
                    {
                    LineChart = new LineChartViewModel(Commissions, StartDate, EndDate, SelectedCustomer, "jaar");
                    CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal werknemers die zijn aangenomen/ontslagen per maand"))
                    {
                        LineChart = new LineChartViewModel(Employees, StartDate, EndDate, SelectedFunction, SelectedRegion, "maand");
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal werknemers die zijn aangenomen/ontslagen per jaar"))
                    {
                    LineChart = new LineChartViewModel(Employees, StartDate, EndDate, SelectedFunction, SelectedRegion, "jaar");
                    CurrentGraph = LineChart;
                    }
                }
            RaisePropertyChanged("");
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
            foreach (var s in SelectedDiagram.Options[SelectedOption])
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
                Options = _selectedDiagram.Options.Keys.ToList();
            }
        }

        public List<string> Options
        {
            get { return _options; }
            set
            {
                _options = value;
                RaisePropertyChanged();
            }
        }
    }
}