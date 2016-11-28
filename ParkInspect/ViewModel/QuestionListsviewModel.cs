using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class QuestionListsviewModel : MainViewModel
    {
        private IQuestionListRepository _repository;
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; set; }

        public QuestionListsviewModel(IQuestionListRepository repo)
        {
            _repository = repo;
            QuestionLists = new ObservableCollection<QuestionListViewModel>(_repository.All());
        }
    }
}
