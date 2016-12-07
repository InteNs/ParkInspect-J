using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Factory;
using ParkInspect.Repositories;
using System.Diagnostics;

namespace ParkInspect.ViewModel
{
    public class ManagementRapportenViewModel : MainViewModel
    {
        private IManagementRapportenRepository Repository { get; set; }
        private bool _date, _klant, _opdracht, _locatie, _inspecteur, _manager, _functie, _antwoord, _status;
        private string _selectedOption;
        public IDiagram _selectedDiagram;
        private IEmployeeRepository _employeeRepository;
        private ICustomerRepository _customerRepository;
        private IQuestionListRepository _questionListRepository;
        private ITaskRepository _taskRepository;
        public PieChartViewModel PieChart { get; set; }
        public BarGraphViewModel BarGraph { get; set; }
        public LineChartViewModel LineChart { get; set; }
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
                if (DateSelected)
                {
                    return _startDate;
                }
                return null;
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
                if (DateSelected)
                {
                    return _endDate;
                }
                return null;
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
        public List<string> Functions => _employeeRepository.GetFunctions().ToList();
        public List<string> Locations => _employeeRepository.GetRegions().ToList();
        public List<CustomerViewModel> Customers => _customerRepository.GetAll().ToList();
        public List<QuestionItemViewModel> Questions { get; set; }

        public List<EmployeeViewModel> Inspectors
            => _employeeRepository.GetAll().Where(e => e.Function == "Inspecteur").ToList();

        public List<EmployeeViewModel> Managers
            => _employeeRepository.GetAll().Where(e => e.Function == "Manager").ToList();

        public List<TaskViewModel> Tasks => _taskRepository.GetAll().ToList();

        public ManagementRapportenViewModel(IManagementRapportenRepository repo, ICustomerRepository cust,
            IEmployeeRepository emp, IQuestionListRepository ques, ITaskRepository task)
        {
            Repository = repo;
            _employeeRepository = emp;
            _customerRepository = cust;
            _questionListRepository = ques;
            _taskRepository = task;
            DiagramFactory = new DiagramFactory();
            Diagrams = new ObservableCollection<IDiagram>(DiagramFactory.DiagramNames);

            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            ComboBox1List = new List<string>();
            Questions = new List<QuestionItemViewModel>();
            List<QuestionListViewModel> questionLists = _questionListRepository.GetAll().ToList();
            foreach (QuestionListViewModel qlvm in questionLists)
            {
                foreach (QuestionItemViewModel qivm in qlvm.QuestionItems)
                {
                    Questions.Add(qivm);
                }
            }
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

                if (SelectedDiagram.Name.Equals("Grafiek"))
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
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal opdrachten die zijn aangemaakt/afgerond per maand"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal opdrachten die zijn aangemaakt/afgerond per jaar"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal werknemers die zijn aangenomen/ontslagen per maand"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
                    if (SelectedOption.Equals("Aantal werknemers die zijn aangenomen/ontslagen per jaar"))
                    {
                        //insert right constructor
                        CurrentGraph = LineChart;
                    }
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