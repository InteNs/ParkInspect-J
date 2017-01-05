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
        private string errorMessage;

        public AddInspectionViewModel(IInspectionsRepository inspectionRepository, /*CommissionViewModel cvm, */IRouterService router) : base(router)
        {
            Inspection = new InspectionViewModel();
            Inspection.StartTime = DateTime.Now;
            Inspection.EndTime = DateTime.Now;
            Inspection.cvm = /*cvm*/new CommissionViewModel();
            _inspectionRepository = inspectionRepository;
            AddInspectionCommand = new RelayCommand(AddInspection, CanAddInspection);
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
