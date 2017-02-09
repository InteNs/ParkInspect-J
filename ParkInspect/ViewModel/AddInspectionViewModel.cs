using GalaSoft.MvvmLight.Command;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddInspectionViewModel : MainViewModel
    {

        private string _errorMessage;
        private readonly ICommissionRepository _commissionrepository;
        private readonly IInspectionsRepository _inspectionRepository;
        private readonly IQuestionListRepository _questionListRepository;
        private QuestionListViewModel _selectedQuestionList;
        private TimeLineViewModel _timeLine;

        public InspectionViewModel Inspection { get; set; }
        public ICommand AddInspectionCommand { get; set; }
        public ObservableCollection<CommissionViewModel> CommissionList { get;}
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; private set; }
        public QuestionListViewModel SelectedQuestionList
        {
            get { return _selectedQuestionList; }
            set { _selectedQuestionList = value; RaisePropertyChanged(); }
        }

        public AddInspectionViewModel(IInspectionsRepository inspectionRepository, ICommissionRepository commissionrepo, IQuestionListRepository questionListRepository, IAuthService auth, IRouterService router, TimeLineViewModel timeLine) : base(router)
        {
            _timeLine = timeLine;
            Inspection = new InspectionViewModel
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };
            _inspectionRepository = inspectionRepository;
            _questionListRepository = questionListRepository;
            _commissionrepository = commissionrepo;

            AddInspectionCommand = new RelayCommand(AddInspection);
            CommissionList = new ObservableCollection<CommissionViewModel>();
            QuestionLists = questionListRepository.GetAll();
            if(commissionrepo.GetAll() != null)
            foreach (CommissionViewModel commission in commissionrepo.GetAll())
            {
                if (auth.CurrentEmployee(auth.GetLoggedInUser()).Id== commission.Employee.Id)
                {
                    CommissionList.Add(commission);
                }
            }
        }

      
        public bool ValidateInput()
        {
            if(Inspection.EndTime <= Inspection.StartTime)
            {
                _errorMessage = "De eindtijd moet later zijn dan de starttijd.";
                return false;
            }
            if (Inspection.EndTime.DayOfYear != Inspection.StartTime.DayOfYear || Inspection.EndTime.Year != Inspection.StartTime.Year)
            {
                _errorMessage = "De start en eindtijd moeten op dezelfde dag plaatsvinden.";
                return false;
            }
            if(Inspection.CommissionViewModel == null)
            {
                _errorMessage = "Selecteer eerst een opdracht.";
                return false;
            }
            if (SelectedQuestionList == null)
            {
                _errorMessage = "Selecteer eerst een vragenlijst.";
                return false;
            }
            return true;
        }

        private void AddInspection()
        {
            if (ValidateInput())
            {
                Inspection.Name = Inspection.StartTime.ToShortDateString() + " Inspectie : " + Inspection.CommissionViewModel.Description;
                if (!_inspectionRepository.Add(Inspection)) return;
                _questionListRepository.CopyTemplate(SelectedQuestionList, Inspection);
                RouterService.SetPreviousView();
                _timeLine.UpdateTimeLineItems();
            }
            else
            {
                ShowValidationError();
            }
        }

        private void ShowValidationError()
        {
            //TODO: Validation error
            var dialog = new MetroDialogService();
            dialog.ShowMessage("Error", _errorMessage);
        }
    }
}
