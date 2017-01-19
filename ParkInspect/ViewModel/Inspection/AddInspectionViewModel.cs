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
        private readonly IInspectionsRepository _inspectionRepository;
        private readonly IQuestionListRepository _questionListRepository;
        private QuestionListViewModel _selectedQuestionList;

        public InspectionViewModel Inspection { get; set; }
        public ICommand AddInspectionCommand { get; set; }
        public ObservableCollection<CommissionViewModel> CommissionList { get; private set; }
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; private set; }
        public QuestionListViewModel SelectedQuestionList
        {
            get
            {
                return _selectedQuestionList;
            }
            set
            {
                _selectedQuestionList = value;
                RaisePropertyChanged();
            }
        }
        private string _errorMessage;

        public AddInspectionViewModel(IInspectionsRepository inspectionRepository, IQuestionListRepository questionListRepository, IAuthService auth, IRouterService router) : base(router)
        {
            Inspection = new InspectionViewModel
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };
            _inspectionRepository = inspectionRepository;
            _questionListRepository = questionListRepository;
            AddInspectionCommand = new RelayCommand(AddInspection);
            CommissionList = new ObservableCollection<CommissionViewModel>();
            QuestionLists = questionListRepository.GetAll();
            foreach (InspectionViewModel ivm in inspectionRepository.GetAll())
            {
                if (ivm.CommissionViewModel.Employee.Id == auth.CurrentEmployee(auth.GetLoggedInUser()).Id)
                {
                    CommissionList.Add(ivm.CommissionViewModel);
                }
            }
        }

        private bool ValidateInput()
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
                if (!_inspectionRepository.Add(Inspection)) return;
                Inspection.Id = _inspectionRepository.GetAll().ToList().First(ins => ins.CommissionViewModel.Id == Inspection.CommissionViewModel.Id && ins.StartTime == Inspection.StartTime).Id;
                QuestionListViewModel ql = new QuestionListViewModel(SelectedQuestionList.QuestionItems);
                foreach(QuestionItemViewModel qivm in ql.QuestionItems)
                {
                    qivm.Answer = null;
                }
                ql.Description = SelectedQuestionList.Description;
                ql.Inspection = Inspection;
                _questionListRepository.Add(SelectedQuestionList);
                RouterService.SetPreviousView();
            }
            else
            {
                ShowValidationError();
            }
        }

        private async void ShowValidationError()
        {
            //TODO: Validation error
            var dialog = new MetroDialogService();
            dialog.ShowMessage("Error", _errorMessage);


        }
    }
}
