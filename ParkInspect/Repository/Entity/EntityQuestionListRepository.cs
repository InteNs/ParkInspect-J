using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Entity
{
    public class EntityQuestionListRepository : IQuestionListRepository
    {
        private ObservableCollection<QuestionListViewModel> _questionLists;
        private readonly ObservableCollection<QuestionItemViewModel> _questionItems;
        private readonly ParkInspectEntities _context;

        public EntityQuestionListRepository(ParkInspectEntities context)
        {
            _context = context;
        }

        public ObservableCollection<QuestionListViewModel> GetAll()
        {
            var questionlist = _context.QuestionList.Include("QuestionItem")
                .Include("QuestionItem.Answer")
                .Include("QuestionItem.Question")
                .Include("QuestionItem.Question.QuestionType")
                .ToList();

            foreach (var list in questionlist)
            {
                List<QuestionItemViewModel> itemList = new List<QuestionItemViewModel>();
                foreach (var item in list.QuestionItem.ToList())
                {
                    itemList.Add(new QuestionItemViewModel()
                    {
                        
                    });
                }
                var qlist = new QuestionListViewModel(itemList);
            }
            _questionLists = new ObservableCollection<QuestionListViewModel>();

            return _questionLists;
        }

        public bool Add(QuestionListViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(QuestionListViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool Update(QuestionListViewModel item)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<QuestionItemViewModel> GetAllQuestionItems()
        {
            throw new NotImplementedException();
        }

        public bool AddItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
