using GalaSoft.MvvmLight.Command;
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
    public class QuestionListItemsViewModel : MainViewModel
    {
        private QuestionListViewModel _qlvm;
        private QuestionViewModel _selectedQuestion;
        private QuestionItemViewModel _selectedQuestionItem;
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }
        public QuestionItemViewModel SelectedQuestionItem
        {
            get { return _selectedQuestionItem; }
            set
            {
                _selectedQuestionItem = value;
                DeleteQuestionCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public RelayCommand AddQuestionCommand { get; set; }
        public RelayCommand DeleteQuestionCommand { get; set; }
        public QuestionViewModel QuestionToAdd
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                AddQuestionCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public QuestionListItemsViewModel(IQuestionRepository questionRepo, IRouterService router, QuestionListsviewModel qvm) : base(router)
        {
            _qlvm = qvm.SelectedQuestionList;
            QuestionItems = qvm.SelectedQuestionList.QuestionItems;
            Questions = new ObservableCollection<QuestionViewModel>(questionRepo.GetAll());
            AddQuestionCommand = new RelayCommand(() => addQuestion(), CanAddQuestion);
            DeleteQuestionCommand = new RelayCommand(() => deleteQuestion(), canDeleteQuestion);
            if (Questions.Count > 0)
            {
                QuestionToAdd = Questions[0];
            }
        }

        private bool CanAddQuestion()
        {
            return QuestionToAdd != null;
        }
        private bool canDeleteQuestion()
        {
            return SelectedQuestionItem != null;
        }

        private void addQuestion()
        {
            QuestionItemViewModel qivm = new QuestionItemViewModel();
            qivm.Question = QuestionToAdd;
            qivm.questionList = _qlvm;
            QuestionItems.Add(qivm);
        }

        private void deleteQuestion()
        {
            QuestionItems.Remove(SelectedQuestionItem);
            SelectedQuestionItem = null;
        }
    }
}
