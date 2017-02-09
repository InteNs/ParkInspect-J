using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly IInspectionsRepository _inspectionRepo;
        private readonly IQuestionListRepository _questionListRepoRepo;
        private QuestionListsviewModel _questionLists;
        private bool _isManager;
        private bool _isInspecteur;
        private readonly IAuthService _authservice;
        private ObservableCollection<CommissionViewModel> _commissionList;
        private ObservableCollection<InspectionViewModel> _inspectionList;

        public ICommand CancelInspectionCommand { get; set; }

        public ICommand DoInspectionCommand { get; set; }

        public ObservableCollection<InspectionViewModel> InspectionList
        {
            get { return GetInspectionList(); }
            private set { _inspectionList = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<CommissionViewModel> CommissionList
        {
            get { return GetCommissionList(); }
            private set { _commissionList = value; RaisePropertyChanged(); }
        }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set { _selectedCommission = value; RaisePropertyChanged(); RaisePropertyChanged("InspectionList"); SelectedInspection = null; }
        }

        public InspectionViewModel SelectedInspection
        {
            get { return _selectedInspection; }
            set {
                _selectedInspection = value;
                if(_questionListRepoRepo.GetAll() != null)
                if(value != null) _questionLists.SelectedQuestionList =
                   _questionListRepoRepo.GetAll().FirstOrDefault(ql => ql?.Inspection?.Id == value.Id);

                RaisePropertyChanged();
                RaisePropertyChanged("ButtonEnabled");
            }
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

        public ObservableCollection<InspectionViewModel> GetInspectionList()
        {
            var insp = new ObservableCollection<InspectionViewModel>();
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

        public ObservableCollection<CommissionViewModel> GetCommissionList()
        {
            if (_authservice.CurrentFunction(_authservice.GetLoggedInUser()).ToLower() == "inspecteur")
            {
                var coms = new ObservableCollection<CommissionViewModel>();
                foreach (var cvm in _commissionList)
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


        public InspectionsViewModel(ICommissionRepository commissionRepository,
            IInspectionsRepository inspectionsRepository, IQuestionListRepository questionListRepo, IRouterService router, IAuthService auth, QuestionListsviewModel questionLists) : base(router)
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
            _questionListRepoRepo = questionListRepo;
            _questionLists = questionLists;
            InspectionList = inspectionsRepository.GetAll();
            CommissionList = commissionRepository.GetAll();
            DoInspectionCommand = new RelayCommand(DoInspection);
            CancelInspectionCommand = new RelayCommand(CancelInspection);
        }
        public void DoInspection()
        {
            var questionItems = new ObservableCollection<QuestionItemViewModel>();
            foreach (var questionList in _questionListRepoRepo.GetAll())
            {
                if (questionList.Inspection != null && questionList.Inspection.Id == SelectedInspection.Id)
                {
                    questionItems = questionList.QuestionItems;
                }
            }
            if(questionItems.Count == 0)
            {
                var dialog = new MetroDialogService();
                dialog.ShowMessage("Error", "De inspectie heeft geen vragen");
                return;
            }
            RouterService.SetView("questionnaire-start");
            MessengerInstance.Send(questionItems);
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
    }
}
