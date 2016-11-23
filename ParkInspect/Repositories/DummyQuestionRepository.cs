using System;
using System.Collections.Generic;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    class DummyQuestionRepository : IQuestionRepository
    {
        public QuestionViewModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionViewModel> All()
        {
            throw new NotImplementedException();
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
