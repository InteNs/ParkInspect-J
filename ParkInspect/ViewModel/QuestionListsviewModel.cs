﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class QuestionListsviewModel : MainViewModel
    {
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; set; }
        private QuestionListViewModel _selectedQuestionList;
        private IQuestionListRepository _repository;
        public QuestionListViewModel SelectedQuestionList
        {
            get { return _selectedQuestionList; }
            set
            {
                _selectedQuestionList = value;
                EditQuestionCommand.RaiseCanExecuteChanged();
                DisableQuestionCommand.RaiseCanExecuteChanged();
                EditQuestionListCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        //constructor for unittest
        public QuestionListsviewModel()
        {

        }
        public RelayCommand EditQuestionCommand { get; set; }
        public RelayCommand DisableQuestionCommand { get; set; }
        public RelayCommand EditQuestionListCommand { get; set; }
        public ICommand NewQuestionCommand { get; set; }
        public QuestionListsviewModel(IQuestionListRepository repo, IRouterService router) : base(router)
        {
            _repository = repo;
            QuestionLists = repo.GetAll();
            DisableQuestionCommand = new RelayCommand(DisableQuestionList, CanEditquestionList);
            EditQuestionCommand = new RelayCommand(() => RouterService.SetView("question-list"), CanEditquestionList);
            EditQuestionListCommand = new RelayCommand(() => RouterService.SetView("questionList-edit"), CanEditquestionList);
            NewQuestionCommand = new RelayCommand(CreateQuestionList);
            SelectedQuestionList = QuestionLists[0];
        }

        private bool CanEditquestionList() => SelectedQuestionList != null; 

        private void DisableQuestionList()
        {
            _repository.Delete(SelectedQuestionList);
            QuestionLists.Remove(SelectedQuestionList);
        }
        private void CreateQuestionList()
        {
            QuestionListViewModel newList = new QuestionListViewModel();
            newList.Description = "nieuwe vragenlijst nr: " + newList.Id;
            _repository.Add(newList);
        }
    }
}
