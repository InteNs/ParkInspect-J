using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Factory;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class ManagementRapportenViewModel : MainViewModel
    {
        private IManagementRapportenRepository Repository { get; set; }
        private bool _date, _klant, _opdracht, _locatie, _inspecteur, _manager, _functie, _antwoord, _status;
        private string _selectedOption;
        private IDiagram _selectedDiagram;
        private IEmployeeRepository _employeeRepository;
        private ICustomerRepository _customerRepository;
        private IQuestionRepository _questionRepository;
        private ITaskRepository _taskRepository;
        public CustomerViewModel SelectedCustomer { get; set; }
        public EmployeeViewModel SelectedInspector { get; set; }
        public EmployeeViewModel SelectedManager { get; set; }
        public QuestionViewModel SelectedQuestion { get; set; }
        public string SelectedFunction { get; set; }
        public string SelectedRegion { get; set; }
        public string SelectedStatus { get; set; }
        public TaskViewModel SelectedTask { get; set; }
        public string SelectedAnswer { get; set; }
        public ICommand GenerateDiagramCommand { get; set; }
        private List<string> _comboBox1List;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DiagramFactory DiagramFactory { get; set; }
        public ObservableCollection<IDiagram> Diagrams { get; set; }
        public List<string> Functions => _employeeRepository.GetFunctions().ToList();
        public List<string> Locations => _employeeRepository.GetRegions().ToList();
        public List<CustomerViewModel> Customers => _customerRepository.GetAll().ToList();
        public List<QuestionViewModel> Questions => _questionRepository.GetAll().ToList();

        public List<EmployeeViewModel> Inspectors
            => _employeeRepository.GetAll().Where(e => e.Function == "Inspecteur").ToList();

        public List<EmployeeViewModel> Managers
            => _employeeRepository.GetAll().Where(e => e.Function == "Manager").ToList();

        public List<TaskViewModel> Tasks => _taskRepository.GetAll().ToList();

        public ManagementRapportenViewModel(IManagementRapportenRepository repo, ICustomerRepository cust,
            IEmployeeRepository emp, IQuestionRepository ques, ITaskRepository task)
        {
            Repository = repo;
            _employeeRepository = emp;
            _customerRepository = cust;
            _questionRepository = ques;
            _taskRepository = task;

            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            DiagramFactory = new DiagramFactory();
            Diagrams = new ObservableCollection<IDiagram>(DiagramFactory.DiagramNames);

            GenerateDiagramCommand = new RelayCommand(GenerateDiagram);
            ComboBox1List = new List<string>();
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
                SetVisibilitys();
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