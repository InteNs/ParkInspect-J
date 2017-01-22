using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Entity
{
    public class EntityTemplateRepository : ITemplateRepository
    {
        private ParkInspectEntities _context;
        private ObservableCollection<TemplateViewModel> _templates;

        public EntityTemplateRepository(ParkInspectEntities context)
        {
            _context = context;
        }

        public ObservableCollection<TemplateViewModel> GetAll()
        {
            _templates = new ObservableCollection<TemplateViewModel>();
            var questionlists = _context.QuestionList.Include("QuestionItem")
                .Include("QuestionItem.Answer")
                .Include("QuestionItem.Question")
                .Include("QuestionItem.Question.QuestionType")
                .ToList();

            foreach (var questionlist in questionlists)
            {
                List<QuestionItemViewModel> itemList = new List<QuestionItemViewModel>();
                foreach (var item in questionlist.QuestionItem)
                {
                    int qEnum;
                    Enum.TryParse(item.Question.QuestionType.Name, true, out qEnum);
                    itemList.Add(new QuestionItemViewModel()
                    {
                        Answer = item.Answer.Value,
                        Question = new QuestionViewModel
                        {
                            Description = item.Question.Description,
                            Id = item.QuestionId,
                            Version = item.QuestionVersion,
                            QuestionType = (Enumeration.QuestionType) qEnum
                        }
                    });
                }
                _templates.Add(new TemplateViewModel(itemList)
                {
                    Description = questionlist.Description,
                    Id = questionlist.Id
                });
            }
            return _templates;
        }

        public bool Add(TemplateViewModel item)
        {
            //Wat is het nut van de dbQuestionItems lijst?
            Collection<QuestionItem> dbQuestionItems = new Collection<QuestionItem>();
            foreach (var qItem in item.QuestionItems)
            {
                var dbQitem =
                    _context.QuestionItem.FirstOrDefault(
                        q =>
                            q.QuestionListId == item.Id && q.QuestionId == qItem.QuestionId &&
                            q.QuestionVersion == qItem.QuestionVersion);
                dbQuestionItems.Add(dbQitem);
            }
            var questionList = new QuestionList()
            {
                Guid = new Guid(),
                Description = item.Description,
            };
            _context.QuestionList.Add(questionList);
            _templates.Add(item);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(TemplateViewModel item)
        {
            //Niet zeker of dit de bedoeling is
            var template = _context.QuestionList.Include("QuestionItem").FirstOrDefault(t => t.Id == item.Id);
            if (template == null) return false;
            _context.QuestionList.Attach(template);
            _context.QuestionList.Remove(template);
            _context.SaveChanges();
            return true;
        }

        public bool Update(TemplateViewModel item)
        {
            //Niet gebruikt zei Pim
            throw new NotImplementedException();
        }

        public bool AddItem(TemplateViewModel list, QuestionItemViewModel item)
        {
            //Niet af
            var template = _context.QuestionList.FirstOrDefault(t => t.Id == list.Id);
            if (template == null) return false;
            
            return true;
        }

        public bool RemoveItem(TemplateViewModel list, QuestionItemViewModel item)
        {
            //Niet af
            throw new NotImplementedException();
        }
    }
}
