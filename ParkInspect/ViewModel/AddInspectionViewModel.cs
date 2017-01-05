using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddInspectionViewModel : MainViewModel
    {
        private readonly IInspectionsRepository _inspectionRepository;
        
        
        public InspectionViewModel Inspection { get; set; }
        public ICommand AddInspectionCommand { get; set; }
        public ObservableCollection<CommissionViewModel> CommissionList { get; private set; }
        private string errorMessage;

        public AddInspectionViewModel(IInspectionsRepository inspectionRepository, ICommissionRepository commissionRepository, IRouterService router) : base(router)
        {
            Inspection = new InspectionViewModel();
            Inspection.StartTime = DateTime.Now;
            Inspection.EndTime = DateTime.Now;
            _inspectionRepository = inspectionRepository;
            AddInspectionCommand = new RelayCommand(AddInspection, CanAddInspection);
            CommissionList = new ObservableCollection<CommissionViewModel>(commissionRepository.GetAll());
        }

        private bool ValidateInput()
        {
            if(Inspection.EndTime <= Inspection.StartTime)
            {
                errorMessage = "De eindtijd moet later zijn dan de starttijd.";
                return false;
            }
            if (Inspection.EndTime.DayOfYear != Inspection.StartTime.DayOfYear || Inspection.EndTime.Year != Inspection.StartTime.Year)
            {
                errorMessage = "De start en eindtijd moeten op dezelfde dag plaatsvinden.";
                return false;
            }
            if(Inspection.cvm == null)
            {
                errorMessage = "Selecteer eerst een opdracht.";
                return false;
            }
            return true;
        }

        private void AddInspection()
        {
            if (ValidateInput())
            {
                if (_inspectionRepository.Add(Inspection))
                {
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                ShowValidationError();
            }
        }

        private bool CanAddInspection()
        {
            return true;
        }

        private async void ShowValidationError()
        {
            //TODO: Validation error
            var dialog = new MetroDialogService();
            dialog.ShowMessage("Error", errorMessage);


        }
    }
}
