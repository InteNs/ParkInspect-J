using System;
using System.Collections.Generic;
using ParkInspect.Enumeration;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public class DummyQuestionRepository : IQuestionRepository
    {
        public QuestionViewModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionViewModel> GetAll()
        {
            return new List<QuestionViewModel>
            {
                new QuestionViewModel { Id = 1, Version = 4, Description = "Is de parkeerplaats vol?", QuestionType = QuestionType.Open},
                new QuestionViewModel { Id = 2, Version = 1, Description = "Hoeveel auto's staan op de parkeerplaats?", QuestionType = QuestionType.Count},
                new QuestionViewModel { Id = 3, Version = 2, Description = "Welk merk auto is het meest aanwezig?", QuestionType = QuestionType.Open}
            };
        }

        public QuestionViewModel Create(QuestionViewModel question)
        {
            throw new NotImplementedException();
        }

        public QuestionViewModel Update(QuestionViewModel question)
        {
            throw new NotImplementedException();
        }
    }
}
