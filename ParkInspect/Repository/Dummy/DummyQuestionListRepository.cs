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
            _questionLists = new ObservableCollection<QuestionListViewModel>
            {
                new QuestionListViewModel(
                    new List<QuestionItemViewModel>
                    {
                        new QuestionItemViewModel
                        {
                            Answer = "45",
                            Question = new QuestionViewModel
                            {
                                Description = "Hoeveel autos staan er op de parkeerplaats?",
                                Id = 1,
                                Version = 1,
                                QuestionType = QuestionType.Count
                            }
                        },
                        new QuestionItemViewModel
                        {
                            Answer = "5",
                            Question = new QuestionViewModel
                            {
                                Description = "Hoeveel overtredingen zijn er?",
                                Id = 2,
                                Version = 1,
                                QuestionType = QuestionType.Count
                            }
                        },
                        new QuestionItemViewModel
                        {
                            Answer = "Ja",
                            Question = new QuestionViewModel
                            {
                                Description = "Is de parkeerplaats leeg?",
                                Id = 3,
                                Version = 1,
                                QuestionType = QuestionType.Boolean
                            }
                        },
                        new QuestionItemViewModel
                        {
                            Answer = "Alles is kapot.",
                            Question = new QuestionViewModel
                            {
                                Description = "Zijn er bijzonderheden zo ja, welke?",
                                Id = 3,
                                Version = 1,
                                QuestionType = QuestionType.Open
                            }
                        }
                    }
                )
            };
            _questionLists[0].Id = 1;
            _questionLists[0].Description = "The first questionlist";

        }

        public ObservableCollection<QuestionListViewModel> GetAll()
        {
            return _questionLists;
        }

        public bool Add(QuestionListViewModel item)
        {
            _questionLists.Add(item);
            return true;
        }

        public bool Delete(QuestionListViewModel item)
        {
            return _questionLists.Remove(item);
        }

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
    }
}
