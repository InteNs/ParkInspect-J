using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GoogleMaps.LocationServices;
using MapControl;
using ParkInspect.Factory;
using ParkInspect.Repository.Interface;
using MapPoint = ParkInspect.Maps.MapPoint;

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
        private Location _mapCenter;
        public PieChartViewModel PieChart { get; set; }
        public BarGraphViewModel BarGraph { get; set; }
        public LineChartViewModel LineChart { get; set; }
        public CustomerViewModel SelectedCustomer { get; set; }
        public EmployeeViewModel SelectedInspector { get; set; }
        public EmployeeViewModel SelectedManager { get; set; }
        public QuestionItemViewModel SelectedQuestion { get; set; }
        public GoogleLocationService LocationService { get; set; }
        public string SelectedFunction { get; set; }
        public string SelectedRegion { get; set; }
        public string SelectedStatus { get; set; }
        public ObservableCollection<string> Statuses { get; set; }
        public CommissionViewModel SelectedCommission { get; set; }
        public string SelectedAnswer { get; set; }
        public ICommand GenerateDiagramCommand { get; set; }
        private List<string> _options;
        private DateTime? _startDate;
        public bool DateSelected { get; set; }
        public DiagramFactory DiagramFactory { get; set; }
        public ObservableCollection<IDiagram> Diagrams { get; set; }
        public IEnumerable<string> Functions { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public ObservableCollection<CustomerViewModel> Customers { get; set; }
        public ObservableCollection<CommissionViewModel> Commissions { get; set; }
        public ObservableCollection<QuestionItemViewModel> Questions { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }
        public IEnumerable<EmployeeViewModel> Managers => Employees.Where(e => e.Function.Equals("Manager"));
        public IEnumerable<EmployeeViewModel> Inspectors => Employees.Where(e => e.Function.Equals("Inspecteur"));
        public ObservableCollection<MapPoint> Points { get; set; }

        public ManagementRapportenViewModel(ICommissionRepository repo, ICustomerRepository cust, IRegionRepository region,
            IEmployeeRepository emp, IQuestionListRepository ques)
        {
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

            LocationService = new GoogleLocationService();

            var avans = LocationService.GetLatLongFromAddress("Onderwijsboulevard 215, 5223 DE");
            _mapCenter = new Location(avans.Latitude, avans.Longitude);

            DiagramFactory = new DiagramFactory();
            Diagrams = new ObservableCollection<IDiagram>(DiagramFactory.DiagramNames);

            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            Options = new List<string>();
            
        }

        private void GenerateDiagram()
        {
            if(SelectedOption == null || SelectedDiagram == null) return;

            switch (SelectedDiagram.Name)
            {
                case "Cirkeldiagram":
                    switch (SelectedOption)
                    {
                        case "Verdeling van de functies van de werknemers":
                            PieChart = new PieChartViewModel(Employees, Functions, SelectedRegion);
                            break;
                        case "Verdeling van de status van de opdrachten":
                            PieChart = new PieChartViewModel(Commissions, _commissionRepository.GetStatuses(), StartDate, EndDate, SelectedCustomer);
                            break;
                        case "Verdeling van de verschillende antwoorden dat is gegeven op een specifieke vraag":
                            PieChart = new PieChartViewModel(Questions, SelectedCommission, SelectedRegion, StartDate, EndDate, SelectedQuestion);
                            break;
                    }
                    CurrentGraph = PieChart;
                    break;

                case "Staafdiagram":
                    switch (SelectedOption)
                    {
                        case "Aantal inspecties per inspecteur":
                            break;
                        case "Aantal inspecties per klant":
                            break;
                        case "Aantal opdrachten per manager":
                            BarGraph = new BarGraphViewModel(Commissions, Managers, StartDate, EndDate, SelectedStatus, SelectedManager);
                            break;
                        case "Aantal opdrachten per klant":
                            BarGraph = new BarGraphViewModel(Commissions, Customers, StartDate, EndDate, SelectedStatus, SelectedCustomer);
                            break;
                    }
                    CurrentGraph = BarGraph;
                    break;

                case "Lijndiagram":
                    switch (SelectedOption)
                    {
                        case "Aantal inspecties die zijn uitgevoerd per dag":
                            break;
                        case "Aantal inspecties die zijn uitgevoerd per week":
                            break;
                        case "Aantal inspecties die zijn uitgevoerd per maand":
                            break;
                        case "Aantal inspecties die zijn uitgevoerd per jaar":
                            break;
                        case "Aantal opdrachten die zijn aangemaakt/afgerond per week":
                            LineChart = new LineChartViewModel(Commissions, StartDate, EndDate, SelectedCustomer, "week");
                            break;
                        case "Aantal opdrachten die zijn aangemaakt/afgerond per maand":
                            LineChart = new LineChartViewModel(Commissions, StartDate, EndDate, SelectedCustomer, "maand");
                            break;
                        case "Aantal opdrachten die zijn aangemaakt/afgerond per jaar":
                            LineChart = new LineChartViewModel(Commissions, StartDate, EndDate, SelectedCustomer, "jaar");
                            break;
                        case "Aantal werknemers die zijn aangenomen/ontslagen per maand":
                            LineChart = new LineChartViewModel(Employees, StartDate, EndDate, SelectedFunction, SelectedRegion, "maand");
                            break;
                        case "Aantal werknemers die zijn aangenomen/ontslagen per jaar":
                            LineChart = new LineChartViewModel(Employees, StartDate, EndDate, SelectedFunction, SelectedRegion, "jaar");
                            break;
                    }
                    CurrentGraph = LineChart;
                    break;

                case "Kaart":
                    switch (SelectedOption)
                    {
                        case "Aantal opdrachten per locatie":
                            break;
                        case "Aantal inspecties per locatie":
                            break;
                        case "Aantal inspecteurs per locatie":
                            break;
                        case "Aantal klanten per locatie":
                            break;
                    }
                    break;
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
        public IGraphViewModel CurrentGraph
        {
            get { return _currentGraph; }
            set { _currentGraph = value; RaisePropertyChanged(); }
        }

        public Location MapCenter
        {
            get { return _mapCenter; }
            set
            {
                _mapCenter = value;
                RaisePropertyChanged("MapCenter");
            }
        }
    }
}