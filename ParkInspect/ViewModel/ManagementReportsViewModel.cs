using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GoogleMaps.LocationServices;
using ParkInspect.DiagramModels;
using ParkInspect.Factory;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
    public class ManagementReportsViewModel : MainViewModel
    {
        private bool _date, _customer, _commission, _location, _inspector, _manager, _function, _answer, _status;
        private string _selectedOption;
        private DateTime? _endDate;
        private IGraphViewModel _currentGraph;
        private IDiagram _selectedDiagram;
        private readonly ICommissionRepository _commissionRepository;
        public PieChartViewModel PieChart { get; set; }
        public BarGraphViewModel BarGraph { get; set; }
        public LineChartViewModel LineChart { get; set; }
        public MapViewModel Map { get; set; }
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
        public ObservableCollection<InspectionViewModel> Inspections { get; set; }
        public ObservableCollection<QuestionItemViewModel> Questions { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }
        public IEnumerable<EmployeeViewModel> Managers => Employees.Where(e => e.Function.Equals("Manager"));
        public IEnumerable<EmployeeViewModel> Inspectors => Employees.Where(e => e.Function.Equals("Inspecteur"));

        public ManagementReportsViewModel(ICommissionRepository repo, ICustomerRepository cust, IRegionRepository region,
            IEmployeeRepository emp, IQuestionListRepository ques, IInspectionsRepository insp)
        {
            _commissionRepository = repo;
            var employeeRepository = emp;
            Employees = employeeRepository.GetAll();
            Functions  = employeeRepository.GetFunctions();
            Commissions = _commissionRepository.GetAll();
            Customers  = cust.GetAll();
            Locations  = region.GetAll();
            Questions = ques.GetAllQuestionItems();
            Statuses = _commissionRepository.GetStatuses();
            Inspections = insp.GetAll();

            DiagramFactory = new DiagramFactory();
            Diagrams = new ObservableCollection<IDiagram>(DiagramFactory.DiagramNames);

            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            Options = new List<string>();

            DiagramView = true;
        }

        // Best veel nesting
        private void GenerateDiagram()
        {
            if(SelectedOption == null || SelectedDiagram == null) return;

            switch (SelectedDiagram.Name)
            {
                case "Cirkeldiagram":
                    if (MapView) { MapView = false; }
                    DiagramView = true;
                    switch (SelectedOption)
                    {
                        case "Verdeling van de functies van de werknemers":
                            PieChart = new PieChartViewModel(Employees, Functions, SelectedRegion);
                            break;
                        case "Verdeling van de status van de opdrachten":
                            PieChart = new PieChartViewModel(Commissions, _commissionRepository.GetStatuses(), StartDate,
                                EndDate, SelectedCustomer);
                            break;
                        case "Verdeling van de verschillende antwoorden dat is gegeven op een specifieke vraag":
                            PieChart = new PieChartViewModel(Questions, Commissions, SelectedCommission, SelectedRegion,
                                StartDate, EndDate, SelectedQuestion);
                            break;
                    }
                    CurrentGraph = PieChart;
                    break;

                case "Staafdiagram":
                    if (MapView) { MapView = false; }
                    DiagramView = true;
                    switch (SelectedOption)
                    {
                        case "Aantal inspecties per inspecteur":
                            BarGraph = new BarGraphViewModel(Inspections, Commissions, Customers, Employees, StartDate,
                                EndDate, SelectedQuestion, SelectedCommission, SelectedCustomer, "inspecteur");
                            break;
                        case "Aantal inspecties per klant":
                            BarGraph = new BarGraphViewModel(Inspections, Commissions, Customers, Employees, StartDate,
                                EndDate, SelectedQuestion, SelectedCommission, SelectedCustomer, "klant");
                            break;
                        case "Aantal opdrachten per inspecteur":
                            BarGraph = new BarGraphViewModel(Commissions, Inspectors, StartDate, EndDate, SelectedStatus,
                                SelectedCustomer);
                            break;
                        case "Aantal opdrachten per klant":
                            BarGraph = new BarGraphViewModel(Commissions, Customers, StartDate, EndDate, SelectedStatus,
                                SelectedCustomer);
                            break;
                    }
                    CurrentGraph = BarGraph;
                    break;

                case "Lijndiagram":
                    if (MapView) { MapView = false; }
                    DiagramView = true;
                    switch (SelectedOption)
                    {
                        case "Aantal inspecties die zijn uitgevoerd per dag":
                            LineChart = new LineChartViewModel(Commissions, Inspections, StartDate, EndDate,
                                SelectedCommission, SelectedCustomer, SelectedQuestion, "dag");
                            break;
                        case "Aantal inspecties die zijn uitgevoerd per week":
                            LineChart = new LineChartViewModel(Commissions, Inspections, StartDate, EndDate,
                                SelectedCommission, SelectedCustomer, SelectedQuestion, "week");
                            break;
                        case "Aantal inspecties die zijn uitgevoerd per maand":
                            LineChart = new LineChartViewModel(Commissions, Inspections, StartDate, EndDate,
                                SelectedCommission, SelectedCustomer, SelectedQuestion, "maand");
                            break;
                        case "Aantal inspecties die zijn uitgevoerd per jaar":
                            LineChart = new LineChartViewModel(Commissions, Inspections, StartDate, EndDate,
                                SelectedCommission, SelectedCustomer, SelectedQuestion, "jaar");
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
                            LineChart = new LineChartViewModel(Employees, StartDate, EndDate, SelectedFunction,
                                SelectedRegion, "maand");
                            break;
                        case "Aantal werknemers die zijn aangenomen/ontslagen per jaar":
                            LineChart = new LineChartViewModel(Employees, StartDate, EndDate, SelectedFunction,
                                SelectedRegion, "jaar");
                            break;
                    }
                    CurrentGraph = LineChart;
                    break;

                case "Kaart":
                    if (DiagramView) { DiagramView = false; }
                    MapView = true;
                    Map = new MapViewModel(Commissions, Inspections, Inspectors, Customers);
                    switch (SelectedOption)
                    {
                        case "Aantal opdrachten per locatie":
                            // Tijdsperiode 
                            // Medewerker
                            // Status van Opdrachten
                            Map.AssigmentsPerLocation(StartDate, EndDate, SelectedInspector);
                            break;
                        case "Aantal inspecties per locatie":
                            // Tijdsperiode 
                            // Medewerker
                            // Vraag & Antwoord
                            Map.InspectionsPerLocation(StartDate, EndDate, SelectedQuestion, SelectedAnswer);
                            break;
                        case "Aantal inspecteurs per locatie":
                            Map.InspectorsPerLocation();
                            break;
                        case "Aantal klanten per locatie":
                            Map.CustomersPerLocation();
                            break;
                    }
                    break;
            }
            RaisePropertyChanged("");
        }

        private void SetVisibilities()
        {
            Date = false;
            Customer = false;
            Commission = false;
            Location = false;
            Inspector = false;
            Manager = false;
            Function = false;
            Answer = false;
            Status = false;
            if (SelectedOption == null) return;
            foreach (var s in SelectedDiagram.Options[SelectedOption])
                switch (s)
                {
                    case Filter.Tijdsperiode:
                        Date = true;
                        break;
                    case Filter.Klant:
                        Customer = true;
                        break;
                    case Filter.Opdracht:
                        Commission = true;
                        break;
                    case Filter.Locatie:
                        Location = true;
                        break;
                    case Filter.Vraag:
                        Answer = true;
                        break;
                    case Filter.Inspecteur:
                        Inspector = true;
                        break;
                    case Filter.Manager:
                        Manager = true;
                        break;
                    case Filter.Functie:
                        Function = true;
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
            set { _selectedOption = value; SetVisibilities(); }
        }

        public bool Date
        {
            get { return _date; }
            set { _date = value; RaisePropertyChanged(); }
        }

        public bool Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                RaisePropertyChanged();
            }
        }

        public bool Commission
        {
            get { return _commission; }
            set { _commission = value; RaisePropertyChanged(); }
        }

        public bool Location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged(); }
        }

        public bool Inspector
        {
            get { return _inspector; }
            set { _inspector = value; RaisePropertyChanged(); }
        }

        public bool Manager
        {
            get { return _manager; }
            set { _manager = value; RaisePropertyChanged(); }
        }

        public bool Function
        {
            get { return _function; }
            set { _function = value; RaisePropertyChanged(); }
        }

        public bool Answer
        {
            get { return _answer; }
            set { _answer = value; RaisePropertyChanged(); }
        }

        public bool Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged(); }
        }

        public bool DiagramView { get; set; }

        public bool MapView { get; set; }

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
            set {  _options = value; RaisePropertyChanged(); }
        }

        public DateTime? StartDate
        {
            get { return DateSelected ? _startDate : null; }
            set { _startDate = value; RaisePropertyChanged(); }
        }

        public DateTime? EndDate
        {
            get { return DateSelected ? _endDate : null; }
            set { _endDate = value; RaisePropertyChanged(); }
        }
        public IGraphViewModel CurrentGraph
        {
            get { return _currentGraph; }
            set { _currentGraph = value; RaisePropertyChanged(); }
        }
    }
}