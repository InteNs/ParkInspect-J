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
            _questionLists = new ObservableCollection<QuestionListViewModel>
            {
                new QuestionListViewModel(
                    new List<QuestionItemViewModel>
                    {
                        new QuestionItemViewModel
                        {
                            Answer = "45",
                             QuestionList = new QuestionListViewModel(new List<QuestionItemViewModel> { new QuestionItemViewModel()}) { Id = 1, Inspection = new InspectionViewModel {Id = 1, StartTime = new DateTime(2016, 11, 5), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel {Id = 1, Name = "Pim Westervoort"}} } },
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
                             QuestionList = new QuestionListViewModel(new List<QuestionItemViewModel> { new QuestionItemViewModel()}) { Id = 1, Inspection = new InspectionViewModel {Id = 1, StartTime = new DateTime(2016, 5, 5), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel {Id = 1, Name = "Pim Westervoort"}} } },
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
                             QuestionList = new QuestionListViewModel(new List<QuestionItemViewModel> { new QuestionItemViewModel()}) { Id = 1, Inspection = new InspectionViewModel {Id = 1, StartTime = new DateTime(2016, 7, 5), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel {Id = 1, Name = "Pim Westervoort"}} } },
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
                            QuestionList = new QuestionListViewModel(new List<QuestionItemViewModel> { new QuestionItemViewModel()}) { Id = 1, Inspection = new InspectionViewModel {Id = 1, StartTime = new DateTime(2016, 3, 5), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel {Id = 1, Name = "Pim Westervoort"}} } },
                            Question = new QuestionViewModel
                            
                            {
                                Description = "Zijn er bijzonderheden zo ja, welke?",
                                Id = 4,
                                Version = 1,
                                QuestionType = QuestionType.Open
                            }
                        }
                    }
                )
            };
            _questionLists[0].Description = "Een paar vraagjes enzo.";
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
    }
}
