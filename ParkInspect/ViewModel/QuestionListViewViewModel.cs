using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{
    public class QuestionListViewViewModel : MainViewModel
    {
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public QuestionViewModel QuestionToAdd;

        public QuestionListViewViewModel(IQuestionRepository questionRepo, IQuestionsRepository questionsRepo, IRouterService router, CustomersViewModel cvm) : base(router)
        {
            QuestionItems = questionsRepo.GetAll();
            Questions = questionRepo.GetAll();

            QuestionToAdd = new QuestionViewModel();
        }
    }
}
