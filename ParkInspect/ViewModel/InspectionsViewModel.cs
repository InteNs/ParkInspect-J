using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.Helper;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ParkInspect.ViewModel
{
    public class InspectionsViewModel : MainViewModel
    {
        private CommissionViewModel _selectedCommission;
        private InspectionViewModel _selectedInspection;
        private IInspectionsRepository _inspectionRepo;
        private IQuestionListRepository _questionListRepo;
        private bool _isManager;
        private bool _isInspecteur;
        private IAuthService _authservice;
        private ObservableCollection<CommissionViewModel> _commissionList;
        private ObservableCollection<InspectionViewModel> _inspectionList;

        public ICommand CancelInspectionCommand { get; set; }

        public ICommand DoInspectionCommand { get; set; }

        public ObservableCollection<InspectionViewModel> InspectionList
        {
            get
            {
                return getInspectionList(); 
            }
            private set
            {
                _inspectionList = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<CommissionViewModel> CommissionList
        {
            get
            {
                return getCommissionList();
            }
            private set
            {
                _commissionList = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<InspectionViewModel> getInspectionList()
        {
            ObservableCollection<InspectionViewModel> insp = new ObservableCollection<InspectionViewModel>();
            if (SelectedCommission == null)
            {
                return insp;
            }
            foreach (InspectionViewModel ivm in _inspectionList)
            {
                if (ivm.CommissionViewModel.Id == SelectedCommission.Id)
                {
                    insp.Add(ivm);
                }
            }
            return insp;
        }

        public ObservableCollection<CommissionViewModel> getCommissionList()
        {
            if (_authservice.CurrentFunction(_authservice.GetLoggedInUser()).ToLower() == "inspecteur")
            {
                ObservableCollection<CommissionViewModel> coms = new ObservableCollection<CommissionViewModel>();
                foreach (CommissionViewModel cvm in _commissionList)
                {
                    if (cvm.Employee.Id == _authservice.GetLoggedInUser().EmployeeId)
                    {
                        coms.Add(cvm);
                    }
                }
                return coms;
            }
            return _commissionList;
        }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set { _selectedCommission = value; RaisePropertyChanged(); RaisePropertyChanged("InspectionList"); SelectedInspection = null; }
        }

        public InspectionViewModel SelectedInspection
        {
            get { return _selectedInspection; }
            set { _selectedInspection = value; RaisePropertyChanged(); RaisePropertyChanged("ButtonEnabled"); }
        }

        public bool ButtonEnabled => _selectedInspection != null;

        public bool IsManager
        {
            get { return _isManager; }
            set { _isManager = value; RaisePropertyChanged(); }
        }

        public bool IsInspecteur
        {
            get { return _isInspecteur; }
            set { _isInspecteur = value; RaisePropertyChanged(); }
        }

        public InspectionsViewModel(ICommissionRepository commissionRepository,
            IInspectionsRepository inspectionsRepository, IQuestionListRepository questionLists, IRouterService router, IAuthService auth) : base(router)
        {
            _authservice = auth;
            switch (RouterService.CurrentDashboard)
            {
                case "dashboard-inspecteur":
                    IsInspecteur = true;
                    IsManager = false;
                    break;
                case "dashboard-manager":
                    IsInspecteur = false;
                    IsManager = true;
                    break;
                default:
                    IsInspecteur = false;
                    IsManager = false;
                    break;
            }
            _inspectionRepo = inspectionsRepository;
            _questionListRepo = questionLists;
            InspectionList = inspectionsRepository.GetAll();
            CommissionList = commissionRepository.GetAll();
            DoInspectionCommand = new RelayCommand(DoInspection);
            CancelInspectionCommand = new RelayCommand(CancelInspection);
        }
        
        //constructor for unittest
        public InspectionsViewModel()
        {
           
        }

        private async void CancelInspection()
        {
            var dialog = new MetroDialogService();
            await dialog.ShowConfirmative("Inspectie annuleren",
                "Weet u zeker dat u " + SelectedInspection.Id + " - " + SelectedInspection.Name + " (" + SelectedInspection.StartTime.ToShortDateString() + ") wilt annuleren?");

            if (dialog.IsAffirmative)
            {
                _inspectionRepo.Delete(SelectedInspection);
                RaisePropertyChanged("InspectionList");
            }
        }

        public void DoInspection()
        {
            RouterService.SetView("questionnaire-start");
            ObservableCollection<QuestionItemViewModel> questionItems = new ObservableCollection<QuestionItemViewModel>();
            foreach(QuestionListViewModel questionList in _questionListRepo.GetAll())
            {
                if(questionList.Inspection != null && questionList.Inspection.Id == SelectedInspection.Id)
                {
                    questionItems = questionList.QuestionItems;
                }
            }
            MessengerInstance.Send(questionItems);
        }
    }

    
}
