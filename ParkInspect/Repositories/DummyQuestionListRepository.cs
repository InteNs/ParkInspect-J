using System;
using System.Collections.Generic;
using ParkInspect.Enumeration;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public class DummyQuestionListRepository : IQuestionListRepository
    {
        private List<QuestionListViewModel> QuestionLists { get; set; }

        public DummyQuestionListRepository()
        {
            QuestionLists = new List<QuestionListViewModel>
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
        }

        public IEnumerable<QuestionListViewModel> GetAll()
        {
            return QuestionLists;
        }

        public QuestionListViewModel Create(QuestionListViewModel questionList)
        {
            QuestionLists.Add(questionList);
            return questionList;
        }

        public QuestionListViewModel Update(QuestionListViewModel questionList)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            list.QuestionItems.Add(item);
            return true;
        }

        public bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            return list.QuestionItems.Remove(item);
        }
    }
}
