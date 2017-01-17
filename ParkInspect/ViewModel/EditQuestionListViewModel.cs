using GalaSoft.MvvmLight.Command;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class EditQuestionListViewModel : MainViewModel
    {
        private IQuestionListRepository _repository;
        public QuestionListViewModel QuestionList { get; set; }
        public RelayCommand EditQuestionCommand { get; set; }
        public EditQuestionListViewModel(IQuestionListRepository repo, IRouterService router, QuestionListsviewModel qlvm) : base(router)
        {
            _repository = repo;
            QuestionList = qlvm.SelectedQuestionList;
            EditQuestionCommand = new RelayCommand(EditquestionList);
        }

        private void EditquestionList()
        {
            if (this.ValidateInput())
            {
                if (_repository.Update(QuestionList))
                {
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                new MetroDialogService().ShowMessage("Error", ShowValidationError());
            }
        }

        private bool ValidateInput()
        {
            //check if all fields are filled in
            if (QuestionList.Description == null)
            {
                return false;
            }

            return true;
        }

        private string ShowValidationError()
        {
            return "Error, de velden zijn niet juist ingevuld.";
        }
    }
}
