using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ParkInspect.Enumeration;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyTemplateRepository : ITemplateRepository
    {
        private readonly ObservableCollection<TemplateViewModel> _templates;

        public DummyTemplateRepository()
        {
            _templates = new ObservableCollection<TemplateViewModel>
            {
                new TemplateViewModel(new List<QuestionItemViewModel>
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
                        },
                        new QuestionItemViewModel
                        {
                            Answer = "5",
                            Question = new QuestionViewModel
                            {
                                Description = "hoeveel overtredingen ofzo",
                                Id = 2,
                                Version = 1,
                                QuestionType = QuestionType.Count
                            }
                        }
                    }) { Description = "template 1"}
            };
        }
        public ObservableCollection<TemplateViewModel> GetAll() =>  _templates;

        public bool Add(TemplateViewModel item)
        {
            _templates.Add(item);
            return true;
        }

        public bool Delete(TemplateViewModel item) => _templates.Remove(item);

        public bool Update(TemplateViewModel item)
        {
            var index = _templates.IndexOf(item);
            if (index < 0) return false;
            _templates.RemoveAt(index);
            _templates.Insert(index, item);
            return true;
        }

        public bool AddItem(TemplateViewModel list, QuestionItemViewModel item)
        {
            list.QuestionItems.Add(item);
            return Update(list);
        }

        public bool RemoveItem(TemplateViewModel list, QuestionItemViewModel item)
        {
            list.QuestionItems.Remove(item);
            return Update(list);
        }
    }
}
