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
                                Description = "hoeveel autos",
                                Id = 1,
                                Version = 1,
                                QuestionType = QuestionType.Count
                            }
                        }
                    }
                )
            };
        }

        public IEnumerable<QuestionListViewModel> All()
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
