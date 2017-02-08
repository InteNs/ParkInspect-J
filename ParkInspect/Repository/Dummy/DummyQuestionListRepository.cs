using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ParkInspect.Enumeration;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyQuestionListRepository : IQuestionListRepository
    {
        private readonly ObservableCollection<QuestionListViewModel> _questionLists;
        private readonly ObservableCollection<QuestionItemViewModel> _questionItems;

        public DummyQuestionListRepository()
        {
            _questionItems = new ObservableCollection<QuestionItemViewModel>();
            _questionLists = new ObservableCollection<QuestionListViewModel>();
        }

        public ObservableCollection<QuestionListViewModel> GetAll() => _questionLists;

        public bool Add(QuestionListViewModel item)
        {
            _questionLists.Add(item);
            return true;
        }

        public bool Delete(QuestionListViewModel item) => _questionLists.Remove(item);

        public bool Update(QuestionListViewModel item)
        {
            var index = _questionLists.IndexOf(item);
            if (index < 0) return false;
            _questionLists.RemoveAt(index);
            _questionLists.Insert(index, item);
            return true;
        }

        public ObservableCollection<QuestionItemViewModel> GetAllQuestionItems()
        {
            _questionItems.Clear();
            _questionLists.SelectMany(l => l.QuestionItems).ToList().ForEach(i => _questionItems.Add(i));
            return _questionItems;
        }

        public bool AddItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            list.QuestionItems.Add(item);
            return Update(list);
        }

        public bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            list.QuestionItems.Remove(item);
            return Update(list);
        }

        public bool CopyTemplate(QuestionListViewModel template, InspectionViewModel inspection)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuestionItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
